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
        ConfigSaver configSaver = new ConfigSaver();
        public bool IsFetchingData { get; set; } = false;
        public bool IsUpdating { get; set; } = false;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            txtRegex.Enabled = chkRegex.Checked;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                var config = new YtdConfig()
                {
                    Link = txtLink.Text.Trim(),

                    IsRegexChecked = chkRegex.Checked,
                    Regex = txtRegex.Text.Trim(),
                    QualityIndex = cmbQuality.SelectedIndex,

                    IsPlaylistStart = chkPlaylistStart.Checked,
                    PlaylistStart = (int)txtPlaylistStart.Value,

                    IsPlaylistEnd = chkPlaylistEnd.Checked,
                    PlaylistEnd = (int)txtPlaylistEnd.Value,

                    IsNotPlaylist = chkNotPlaylist.Checked,
                    IsShowDownloadLinks = chkDownloadLink.Checked,

                    IsCustomArgs = chkCustomArgs.Checked,
                    CustomArgs = txtCustomArgs.Text.Trim(),

                    IsExternalApp = chkExternalApp.Checked,
                    ExternalAppLocation = txtExternalApp.Text.Trim(),
                    ExternalAppArgs = txtExternalAppArgs.Text.Trim(),

                    IsAutoNumberingStart = chkAutoNumber.Checked,
                    AutoNumberStart = (int)txtAutoNumber.Value,
                    AutoNumberPadding = (int)txtPad.Value,
                };
                configSaver.SaveConfig(config);
                Environment.Exit(0);
            }
            catch { }
        }

        private void btnGetData_Click(object sender, EventArgs e)
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
                if (chkRegex.Checked && string.IsNullOrWhiteSpace(txtRegex.Text) == false)
                {
                    args += " --match-title \"" + txtRegex.Text.Trim() + "\"";
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
            txtRegex.Enabled = false;
            chkRegex.Enabled = false;

            chkNotPlaylist.Enabled = false;
            chkDownloadLink.Enabled = false;
            chkPlaylistStart.Enabled = false;
            chkPlaylistEnd.Enabled = false;
            chkAutoNumber.Enabled = false;
            chkExternalApp.Enabled = false;
            btnSend.Enabled = false;
            txtPlaylistStart.Enabled = false;
            txtPlaylistEnd.Enabled = false;
            txtExternalApp.Enabled = false;
            txtExternalAppArgs.Enabled = false;
            txtPad.Enabled = false;
            txtAutoNumber.Enabled = false;

            cmbQuality.Enabled = false;
            btnReset.Enabled = false;
            btnUpdateYoutubeDL.Enabled = false;
            btnCopyToClipboard.Enabled = false;

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
            chkRegex.Enabled = true;
            txtRegex.Enabled = chkRegex.Checked;

            chkNotPlaylist.Enabled = true;
            chkDownloadLink.Enabled = true;
            chkPlaylistStart.Enabled = true;
            chkPlaylistEnd.Enabled = true;
            chkAutoNumber.Enabled = true;
            chkExternalApp.Enabled = true;
            btnSend.Enabled = chkExternalApp.Checked;
            txtPlaylistStart.Enabled = chkPlaylistStart.Checked;
            txtPlaylistEnd.Enabled = chkPlaylistEnd.Checked;
            txtExternalApp.Enabled = chkExternalApp.Checked;
            txtExternalAppArgs.Enabled = chkExternalApp.Checked;
            txtPad.Enabled = chkExternalApp.Checked && chkAutoNumber.Checked && chkAutoNumber.Enabled;
            txtAutoNumber.Enabled = chkExternalApp.Checked && chkAutoNumber.Checked && chkAutoNumber.Enabled;

            btnReset.Enabled = true;
            btnUpdateYoutubeDL.Enabled = true;
            btnCopyToClipboard.Enabled = true;

            btnGetData.Text = "Get Data";
            proc = null;
            Counter = 0;
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
                    Invoke(new Action(() =>
                    {
                        lblVidCount.Text = vidLinks.Count + " videos loaded";
                    }));
                }

                if (Counter % 2 == 0 || chkDownloadLink.Checked)
                {
                    WriteToOut(e.Data);
                    if (!chkCustomArgs.Checked && Counter % 2 == 0)
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

        private void mainWindow_Load(object sender, EventArgs e)
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

            var config = configSaver.GetConfig();
            ResetInterface(config);
        }

        private void chkAutoNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtAutoNumber.Enabled = chkAutoNumber.Checked;
            txtPad.Enabled = chkAutoNumber.Checked;
        }

        private void chkPlaylistStart_CheckedChanged(object sender, EventArgs e)
        {
            txtPlaylistStart.Enabled = chkPlaylistStart.Checked;
        }

        private void chkPlaylistEnd_CheckedChanged(object sender, EventArgs e)
        {
            txtPlaylistEnd.Enabled = chkPlaylistEnd.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOut.Clear();
        }

        private void chkExternalApp_CheckedChanged(object sender, EventArgs e)
        {
            txtExternalApp.Enabled = chkExternalApp.Checked;
            txtExternalAppArgs.Enabled = chkExternalApp.Checked;
            btnSend.Enabled = chkExternalApp.Checked;
            chkAutoNumber.Enabled = chkExternalApp.Checked;
            txtAutoNumber.Enabled = chkExternalApp.Checked && chkAutoNumber.Checked;
            txtPad.Enabled = chkExternalApp.Checked && chkAutoNumber.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var invalidChars = Path.GetInvalidFileNameChars().ToList();
            var counter = txtAutoNumber.Value;
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
                var counterPad = chkAutoNumber.Checked ? counter.ToString().PadLeft(maxPadding, '0') + ". " : "";
                var title = vidTitles[i];
                foreach (var c in invalidChars)
                    title = title.Replace(c.ToString(), "");

                if (string.IsNullOrWhiteSpace(title))
                    title = "Invalid Name";

                var _p = new Process();
                _p.StartInfo.FileName = txtExternalApp.Text;
                _p.StartInfo.Arguments = txtExternalAppArgs.Text.Replace("{url}", vidLinks[i]).Replace("{file}", counterPad + (vidTitles.Count > i ? title : ""));
                _p.Start();
                counter++;
                System.Threading.Thread.Sleep(500);
            }

            txtOut.AppendText("Sent " + vidLinks.Count + " links to external app.\r\n\r\n");
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
            IsUpdating = true;
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
                IsUpdating = false;
            }));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInterface(new YtdConfig());
            lblVidCount.Text = "0 videos loaded";
            txtOut.Clear();
            vidTitles.Clear();
            vidLinks.Clear();
        }

        private void ResetInterface(YtdConfig config)
        {
            txtLink.Text = config.Link;
            chkRegex.Checked = config.IsRegexChecked;
            txtRegex.Text = config.Regex;
            cmbQuality.SelectedIndex = config.QualityIndex;

            chkNotPlaylist.Checked = config.IsNotPlaylist;
            chkDownloadLink.Checked = config.IsShowDownloadLinks;

            chkPlaylistStart.Checked = config.IsPlaylistStart;
            txtPlaylistStart.Value = config.PlaylistStart;
            txtPlaylistStart.Enabled = chkPlaylistStart.Checked;

            chkPlaylistEnd.Checked = config.IsPlaylistEnd;
            txtPlaylistEnd.Value = config.PlaylistEnd;
            txtPlaylistEnd.Enabled = chkPlaylistEnd.Checked;

            chkCustomArgs.Checked = config.IsCustomArgs;
            txtCustomArgs.Text = config.CustomArgs;
            txtCustomArgs.Enabled = chkCustomArgs.Checked;

            chkExternalApp.Checked = config.IsExternalApp;
            txtExternalApp.Text = config.ExternalAppLocation;
            txtExternalApp.Enabled = chkExternalApp.Checked;
            txtExternalAppArgs.Text = config.ExternalAppArgs;
            txtExternalAppArgs.Enabled = chkExternalApp.Checked;

            chkAutoNumber.Checked = config.IsAutoNumberingStart;
            chkAutoNumber.Enabled = chkExternalApp.Checked;
            txtAutoNumber.Value = config.AutoNumberStart;
            txtAutoNumber.Enabled = chkAutoNumber.Checked && chkAutoNumber.Enabled;
            txtPad.Value = config.AutoNumberPadding;
            txtPad.Enabled = chkAutoNumber.Checked && chkAutoNumber.Enabled;

            if (config.ExternalAppLocation == (new YtdConfig()).ExternalAppLocation)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    txtExternalApp.Text = "C:\\Program Files (x86)\\Internet Download Manager\\idman.exe";
                }
                else
                {
                    txtExternalApp.Text = "C:\\Program Files\\Internet Download Manager\\idman.exe";
                }
            }
        }
    }
}
