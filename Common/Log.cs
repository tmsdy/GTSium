using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Silt.Base.Common
{
    /// <summary>
    /// ��־
    /// </summary>
    public class Log
    {
        public Log()
        {
            ///
            /// TODO: �ڴ˴���ӹ��캯���߼�
            ///
        }
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="strErrorTitle">�������</param>
        /// <param name="strException">�쳣����</param>
        public void ZASaveLog(string strErrorTitle, string strException)
        {
            if (strErrorTitle == "" || strErrorTitle == "")
            {
                strErrorTitle = "һ���쳣";
            }
            StreamWriter sw;            
            //sw = File.AppendText(Server.MapPath(null) + "\\ZASuite~Log.log");//Web
            sw = File.AppendText(System.Configuration.ConfigurationSettings.AppSettings["SysLogFileName"]);//Winform
            sw.WriteLine("--------��ʼ-------");
            sw.WriteLine("ʱ�䣺" + System.DateTime.Now.ToString());
            sw.WriteLine("ϵͳ��" + System.Configuration.ConfigurationSettings.AppSettings["SysName"]);
            sw.WriteLine("���⣺" + strErrorTitle);
            sw.WriteLine(strException);
            sw.WriteLine("--------����-------");
            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }
    }
}
