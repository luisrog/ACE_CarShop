using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class LogHelper
    {
        public static void WriteLog(string message)
        {
            try
            {
                DateTime date = DateTime.Now;
                string path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "/Log/" + date.ToString("yyyy-MM-dd") + ".txt").LocalPath;

                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine(DateTime.Now.ToString() + " : " + message + "\n");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteLog(Exception e)
        {
            try
            {
                DateTime date = DateTime.Now;
                string path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "/Log/" + date.ToString("yyyy-MM-dd") + ".txt").LocalPath;

                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine(DateTime.Now.ToString() + " - Details Exception");
                    w.WriteLine("Message: " + e.Message);
                    w.WriteLine("Source: " + e.Source);
                    w.WriteLine("TargetSite: " + e.TargetSite);
                    w.WriteLine("StackTrace: " + e.StackTrace);
                    w.WriteLine("InnerException: " + e.InnerException + "\n");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
