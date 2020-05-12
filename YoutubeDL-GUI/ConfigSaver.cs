using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace YoutubeDL_GUI
{
    public class ConfigSaver
    {
        string fileName = "youtubedl-gui";
        string DefaultSavePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YoutubeDL-GUI";

        public ConfigSaver()
        {
            if (!Directory.Exists(DefaultSavePath))
            {
                Directory.CreateDirectory(DefaultSavePath);
            }
        }

        public void SaveConfig(YtdConfig config)
        {
            var targetFile = Path.Combine(DefaultSavePath, fileName + ".ytgui");

            if (File.Exists(targetFile))
            {
                var asdasd = new FileInfo(targetFile).FullName;
                File.Delete(targetFile);
            }

            using (var fStream = File.Create(targetFile))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fStream, config);
                fStream.Close();
            }
        }

        public YtdConfig GetConfig()
        {
            var retThis = new YtdConfig();
            var targetFile = Path.Combine(DefaultSavePath, fileName + ".ytgui");
            if (!File.Exists(targetFile))
                return retThis;

            try
            {
                using (var fStream = File.OpenRead(targetFile))
                {
                    var formatter = new BinaryFormatter();
                    retThis = (YtdConfig)formatter.Deserialize(fStream);
                    fStream.Close();
                }
            }
            catch { }
            return retThis;
        }
    }
}
