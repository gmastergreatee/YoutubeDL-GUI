using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace YoutubeDL_GUI
{
    [Serializable]
    public class YtdConfig
    {
        public string Link { get; set; } = "https://www.youtube.com/playlist?list=PLwLSw1_eDZl0hI_XedalMVIvHcVLOouiv";
        public bool IsRegexChecked { get; set; } = false;
        public string Regex { get; set; } = " - Episode \\d{1,2}";
        public int QualityIndex { get; set; } = 1;

        public bool IsNotPlaylist { get; set; } = false;
        public bool IsShowDownloadLinks { get; set; } = false;

        public bool IsPlaylistStart { get; set; } = false;
        public int PlaylistStart { get; set; } = 1;

        public bool IsPlaylistEnd { get; set; } = false;
        public int PlaylistEnd { get; set; } = 1;

        public bool IsCustomArgs { get; set; } = false;
        public string CustomArgs { get; set; } = "-o \"%(autonumber)02d. %(title)s.%(ext)s\" --write-sub --sub-lang en --sub-format srt --skip-download {link}";

        public bool IsExternalApp { get; set; } = false;
        public string ExternalAppLocation { get; set; } = "C:\\Program Files (x86)\\Internet Download Manager\\idman.exe";
        public string ExternalAppArgs { get; set; } = "/a /d \"{url}\" /f \"{file}.mp4\"";

        public bool IsAutoNumberingStart { get; set; } = false;
        public int AutoNumberStart { get; set; } = 1;
        public int AutoNumberPadding { get; set; } = 1;
    }
}
