using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Classes
{
    [Serializable]
    public class CreateLogFiles
    {
        public void WriteToFile(string Message, string Process)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + Process;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + Process + "\\ErrorLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }

        }
    }
}