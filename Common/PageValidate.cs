using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace Silt.Base.Common
{
    /// <summary>
    /// ������
    /// ������
    /// 2007.1
    /// </summary>
	public class PageValidate
	{
      private static Regex RegNumber = new Regex("^[0-9]+$");
		private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //�ȼ���^[+-]?\d+[.]?\d+$
		private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w Ӣ����ĸ�����ֵ��ַ������� [a-zA-Z0-9] �﷨һ�� 
		private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");


        public PageValidate()
		{
			///
			/// TODO: �ڴ˴���ӹ��캯���߼�
			///            
           
		}     

		#region �����ַ������		
		
				
		/// <summary>
		/// �Ƿ������ַ���
		/// </summary>
		/// <param name="inputData">�����ַ���</param>
		/// <returns></returns>
		public static bool IsNumber(string inputData)
		{
			Match m = RegNumber.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// �Ƿ������ַ��� �ɴ�������
		/// </summary>
		/// <param name="inputData">�����ַ���</param>
		/// <returns></returns>
		public static bool IsNumberSign(string inputData)
		{
			Match m = RegNumberSign.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// �Ƿ��Ǹ�����
		/// </summary>
		/// <param name="inputData">�����ַ���</param>
		/// <returns></returns>
		public static bool IsDecimal(string inputData)
		{
			Match m = RegDecimal.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// �Ƿ��Ǹ����� �ɴ�������
		/// </summary>
		/// <param name="inputData">�����ַ���</param>
		/// <returns></returns>
		public static bool IsDecimalSign(string inputData)
		{
			Match m = RegDecimalSign.Match(inputData);
			return m.Success;
		}		

		#endregion

		#region ���ļ��

		/// <summary>
		/// ����Ƿ��������ַ�
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsHasCHZN(string inputData)
		{
			Match m = RegCHZN.Match(inputData);
			return m.Success;
		}	

		#endregion

		#region �ʼ���ַ
		/// <summary>
		/// �Ƿ��Ǹ����� �ɴ�������
		/// </summary>
		/// <param name="inputData">�����ַ���</param>
		/// <returns></returns>
		public static bool IsEmail(string inputData)
		{
			Match m = RegEmail.Match(inputData);
			return m.Success;
		}		

		#endregion

		#region ����

		/// <summary>
		/// ����ַ�����󳤶ȣ�����ָ�����ȵĴ�
		/// </summary>
		/// <param name="sqlInput">�����ַ���</param>
		/// <param name="maxLength">��󳤶�</param>
		/// <returns></returns>			
		public static string SqlText(string sqlInput, int maxLength)
		{			
			if(sqlInput != null && sqlInput != string.Empty)
			{
				sqlInput = sqlInput.Trim();							
				if(sqlInput.Length > maxLength)//����󳤶Ƚ�ȡ�ַ���
					sqlInput = sqlInput.Substring(0, maxLength);
			}
			return sqlInput;
		}



		#endregion


	}
}