using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Silt.Base.Common
{
	
	public class Time
	{

        public Time()
		{
			///
			/// TODO: �ڴ˴���ӹ��캯���߼�
			///            
           
		}
        ///ȡ�õ�ǰ����ʱ��
        public String GetDataTime()
        {
            return GetData() + " " + GetTime();
        }
        ///ȡ�õ�ǰ����
        public String GetData()
        {
            string DateTemp = string.Empty;
            System.DateTime date = System.DateTime.Now;
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day);
            return DateTemp;

        }
        ///ȡ�õ�ǰʱ��
        public String GetTime()
        {
            string DateTemp = string.Empty;
            System.DateTime date = System.DateTime.Now;
            DateTemp = Convert.ToString(date.Hour) + ":"
               + Convert.ToString(date.Minute) + ":"
               + Convert.ToString(date.Second);
            return DateTemp;
        }
        /// <summary>
        /// ȡ�õ�ǰ��ʼ����
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ZAGetStartData(DateTime dt)
        {
            string DateTemp = string.Empty;
            System.DateTime date = dt;
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day) + " 00:00:00";
            string strdata = Convert.ToDateTime(DateTemp).ToString();
            return strdata;

        }

        /// <summary>
        /// ȡ�õ�ǰ��������
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ZAGetEndData(DateTime dt)
        {
            string DateTemp = string.Empty;
            System.DateTime date = dt;
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day) + " 23:59:59";
            string strdata = Convert.ToDateTime(DateTemp).ToString();
            return strdata;
        }
	}
}
