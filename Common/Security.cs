using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;
namespace Silt.Base.Common
{
    public class Security
    {
        public Security()
        {
            ///
            /// TODO: �ڴ˴���ӹ��캯���߼�
            ///

        }
        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="format">���ܸ�ʽ SHA1,MD5����ǰϵͳ����MD5</param>
        /// <param name="str">�����ַ�</param>       
        /// <returns>��������ַ�</returns>
        public static string StrToEncrypt(string format, string str)
        {
            //SHA1,MD5           
            string password = str;
            byte[] dataOfPwd = (new UnicodeEncoding()).GetBytes(password);
            byte[] hashValueOfPwd = ((HashAlgorithm)CryptoConfig.CreateFromName(format)).ComputeHash(dataOfPwd);
            password = BitConverter.ToString(hashValueOfPwd);
            return password;
        }
    }
}
