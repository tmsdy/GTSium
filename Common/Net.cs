using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;
namespace Silt.Base.Common
{
	//// <summary>
    //// SysUtil ��ժҪ˵����
	//// Purpose: ͬϵͳ������ع�����Դ
	//// Version:ZASuite1.0 @2006
	//// Author: ������
	//// Date: 2006
    //// </summary>
	public class Net
	{

        public Net()
		{
			///
			/// TODO: �ڴ˴���ӹ��캯���߼�
			///            
           
		}
        /// <summary>
        /// ȡ��������
        /// </summary>
        /// <returns></returns>
        public string GetHostName()
        {
            IPHostEntry ipHE = Dns.GetHostByName(Dns.GetHostName());
            return ipHE.HostName.ToString();
        }
        /// <summary>
        /// ȡ������IP
        /// </summary>
        /// <returns></returns>
        public string GetHostIpAddress()
        {
            IPHostEntry ipHE = Dns.GetHostByName(Dns.GetHostName());
            return ipHE.AddressList[0].ToString();
        }
       
	}
}
