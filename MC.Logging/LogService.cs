using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Logging
{
    public static class LogService
    {
        public static void Log(string content)
        {
            content = content + "....." + DateTime.Now.ToString();
            string logPath = ConfigurationManager.AppSettings["LogPath"].ToString();
            FileStream fs = new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
        }

    }
}
