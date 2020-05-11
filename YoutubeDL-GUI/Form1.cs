using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace YoutubeDL_GUI
{
    public partial class mainWindow : Form
    {
        List<string> vidTitles = new List<string>();
        List<string> vidLinks = new List<string>();
        List<string> qualities = new List<string>()
        {
            "",
            "best[ext=mp4]",
            "best[height<=1080]+best[ext=mp4]",
            "best[height<=720]+best[ext=mp4]",
            "best[height<=480]+best[ext=mp4]",
            "best[height<=360]+best[ext=mp4]",
            "best[height<=144]+best[ext=mp4]",
        };

        Process proc = null;
        public bool IsFetchingData { get; set; } = false;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            txtTitle.Enabled = chkTitle.Checked;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsFetchingData)
            {
                if (proc != null)
                {
                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                    proc = null;
                }

                EnableEverything();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLink.Text))
                MessageBox.Show("Please enter a valid link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (proc != null)
            {
                if (!proc.HasExited)
                {
                    proc.Kill();
                }
                return;
            }

            vidTitles.Clear();
            vidLinks.Clear();
            lblVidCount.Text = "0 videos loaded";

            proc = new Process();
            proc.EnableRaisingEvents = true;
            proc.OutputDataReceived += ytdOut;
            proc.ErrorDataReceived += ytdError;
            proc.Exited += ytdExit;
            proc.StartInfo.FileName = "youtube-dl.exe";

            var args = "";
            if (!chkCustomArgs.Checked)
            {
                args = "-e";
                if (cmbQuality.SelectedIndex > 0)
                {
                    args += " -f " + qualities[cmbQuality.SelectedIndex];
                }
                if (chkTitle.Checked && string.IsNullOrWhiteSpace(txtTitle.Text) == false)
                {
                    args += " --match-title \"" + txtTitle.Text.Trim() + "\"";
                }
                if (chkNotPlaylist.Checked)
                {
                    args += " --no-playlist";
                }
                if (chkPlaylistStart.Checked && txtPlaylistStart.Value > 0)
                {
                    args += " --playlist-start " + txtPlaylistStart.Value;
                }
                if (chkPlaylistEnd.Checked && txtPlaylistEnd.Value > 0)
                {
                    args += " --playlist-end " + txtPlaylistEnd.Value;
                }
                proc.StartInfo.Arguments = args + " -g " + txtLink.Text.Trim();
            }
            else
            {
                proc.StartInfo.Arguments = txtCustomArgs.Text.Trim().Replace("{link}", txtLink.Text.Trim());
            }
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            btnGetData.Text = "Stop";

            txtLink.Enabled = false;
            txtTitle.Enabled = false;
            chkTitle.Enabled = false;

            chkNotPlaylist.Enabled = false;
            chkDownloadLink.Enabled = false;
            chkPlaylistStart.Enabled = false;
            chkPlaylistEnd.Enabled = false;
            chkNumber.Enabled = false;
            chkExternalApp.Enabled = false;
            btnSend.Enabled = false;
            txtPlaylistStart.Enabled = false;
            txtPlaylistEnd.Enabled = false;
            txtExternalApp.Enabled = false;
            txtExternalAppArgs.Enabled = false;
            txtPad.Enabled = false;
            txtNumber.Enabled = false;

            if (!chkCustomArgs.Checked)
            {
                txtOut.AppendText("COMMAND : youtube-dl.exe " + args + (chkDownloadLink.Checked ? " -g" : "") + " " + txtLink.Text + "\r\n\r\n");
            }
            else
            {
                txtOut.AppendText("COMMAND : youtube-dl.exe " + txtCustomArgs.Text.Trim().Replace("{link}", txtLink.Text.Trim()) + "\r\n\r\n");
            }
        }

        private void EnableEverything()
        {
            txtOut.AppendText("\r\nOperation completed\r\n\r\n");
            IsFetchingData = false;
            txtLink.Enabled = true;
            chkTitle.Enabled = true;
            txtTitle.Enabled = chkTitle.Checked;

            chkNotPlaylist.Enabled = true;
            chkDownloadLink.Enabled = true;
            chkPlaylistStart.Enabled = true;
            chkPlaylistEnd.Enabled = true;
            chkNumber.Enabled = true;
            chkExternalApp.Enabled = true;
            btnSend.Enabled = chkExternalApp.Checked;
            txtPlaylistStart.Enabled = chkPlaylistStart.Checked;
            txtPlaylistEnd.Enabled = chkPlaylistEnd.Checked;
            txtExternalApp.Enabled = chkExternalApp.Checked;
            txtExternalAppArgs.Enabled = chkExternalApp.Checked;
            txtPad.Enabled = chkExternalApp.Checked && chkNumber.Checked && chkNumber.Enabled;
            txtNumber.Enabled = chkExternalApp.Checked && chkNumber.Checked && chkNumber.Enabled;

            btnGetData.Text = "Get Data";
            proc = null;
            Counter = 0;
            lblVidCount.Text = vidLinks.Count + " videos loaded";
        }

        private void ytdExit(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                EnableEverything();
            }));
        }

        private void ytdError(object sender, DataReceivedEventArgs e)
        {
            WriteToOut(e.Data);
        }

        private void ytdOut(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                if (vidLinks.FirstOrDefault(i => i == e.Data.Trim().Replace("\r\n", "").Replace("\n", "")) != null)
                {
                    return;
                }

                if ((e.Data.Trim().StartsWith("http://") || e.Data.Trim().StartsWith("https://")) && Counter % 2 == 0)
                {
                    if (chkDownloadLink.Checked)
                    {
                        WriteToOut("Mirror : " + e.Data);
                    }
                    return;
                }

                if (Counter % 2 == 1 && chkCustomArgs.Checked == false)
                {
                    vidLinks.Add(e.Data.Replace("\r\n", "").Replace("\n", ""));
                }

                if (Counter % 2 == 0 || chkDownloadLink.Checked)
                {
                    WriteToOut(e.Data);
                    if (!chkCustomArgs.Checked)
                        vidTitles.Add(e.Data.Replace("\r\n", "").Replace("\n", ""));
                }

                Counter++;
            }
        }

        private int Counter = 0;

        private void WriteToOut(string text)
        {
            Invoke(new Action(() =>
            {
                if (text != null)
                {
                    txtOut.AppendText(text + "\r\n");
                }
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("youtube-dl.exe"))
            {
                MessageBox.Show("\"youtube-dl.exe\" is missing from the current directory.\nPlease add the file here.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }

            cmbQuality.Items.Add("---");
            cmbQuality.Items.Add("Best");
            cmbQuality.Items.Add("1080p");
            cmbQuality.Items.Add("720p");
            cmbQuality.Items.Add("480p");
            cmbQuality.Items.Add("360p");
            cmbQuality.Items.Add("144p");

            cmbQuality.SelectedIndex = 1;

            if (Environment.Is64BitOperatingSystem)
            {
                txtExternalApp.Text = "C:\\Program Files (x86)\\Internet Download Manager\\idman.exe";
            }
            else
            {
                txtExternalApp.Text = "C:\\Program Files\\Internet Download Manager\\idman.exe";
            }

            txtCustomArgs.Text = "-o \"%(autonumber)s-%(title)s.%(ext)s\" --write-sub --sub-lang en --sub-format srt --skip-download {link}";
        }

        private void chkNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtNumber.Enabled = chkNumber.Checked;
            txtPad.Enabled = chkNumber.Checked;
        }

        private void chkPlaylistStart_CheckedChanged(object sender, EventArgs e)
        {
            txtPlaylistStart.Enabled = chkPlaylistStart.Checked;
        }

        private void chkPlaylistEnd_CheckedChanged(object sender, EventArgs e)
        {
            txtPlaylistEnd.Enabled = chkPlaylistEnd.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtOut.Clear();
        }

        private void chkExternalApp_CheckedChanged(object sender, EventArgs e)
        {
            txtExternalApp.Enabled = chkExternalApp.Checked;
            txtExternalAppArgs.Enabled = chkExternalApp.Checked;
            btnSend.Enabled = chkExternalApp.Checked;
            chkNumber.Enabled = chkExternalApp.Checked;
            txtNumber.Enabled = chkExternalApp.Checked && chkNumber.Checked;
            txtPad.Enabled = chkExternalApp.Checked && chkNumber.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var counter = txtNumber.Value;
            if (vidLinks.Count <= 0)
            {
                MessageBox.Show("No videos added yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(txtExternalApp.Text))
            {
                MessageBox.Show("Invalid path to external app", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var maxPadding = (int)txtPad.Value;
            for (var i = 0; i < vidLinks.Count; i++)
            {
                var counterPad = chkNumber.Checked ? counter.ToString().PadLeft(maxPadding, '0') + ". " : "";

                var _p = new Process();
                _p.StartInfo.FileName = txtExternalApp.Text;
                _p.StartInfo.Arguments = txtExternalAppArgs.Text.Replace("{url}", vidLinks[i]).Replace("{file}", counterPad + (vidTitles.Count > i ? vidTitles[i] : ""));
                _p.Start();
                counter++;
                System.Threading.Thread.Sleep(500);
            }
        }

        private void chkCustomArgs_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomArgs.Enabled = chkCustomArgs.Checked;
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            var links = "";
            foreach (var itm in vidLinks)
            {
                links += itm + "\n";
            }

            if (!string.IsNullOrWhiteSpace(links))
                Clipboard.SetText(links);

            if (vidLinks.Count > 0)
                txtOut.AppendText("Copied " + vidLinks.Count + " link/s to clipboard\r\n\r\n");
            else
                txtOut.AppendText("No links captured yet\r\n\r\n");
        }

        private void btnUpdateYoutubeDL_Click(object sender, EventArgs e)
        {
            Hide();
            var _uproc = new Process();
            _uproc.EnableRaisingEvents = true;
            _uproc.StartInfo.FileName = "youtube-dl.exe";
            _uproc.StartInfo.Arguments = "-U";
            _uproc.Exited += ytd_update_complete;
            _uproc.Start();
        }

        private void ytd_update_complete(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Show();
            }));
        }
    }
}
