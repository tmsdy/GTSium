using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    /// <summary>
    /// ϵͳ�����б����� 
    /// </summary>
    public class BaseListRules : ZASuiteDAORulesSys
    {
        /// <summary>
        /// ���￪�����շѷ�
        /// </summary>
        public static int LisClinicChargeOk = 0;
        /// <summary>
        /// ���￪�����ӡ��
        /// </summary>
        public static int LisClinicApplyPrintOk = 0;
        /// <summary>
        /// �����������Ϸ�
        /// </summary>
        public static int LisClinicChargeCancel = 0;
        /// <summary>
        /// ����ȡ����HIS�ӿڷ�
        /// </summary>
        public static int LisClinicPatientOk = 0;
        /// <summary>
        /// ����ȡ����HIS�ӿڷ� �ӿ��ļ�url
        /// </summary>
        public static string LisClinicPatientOkValue = "d:\\lis.txt";
        /// <summary>
        /// סԺ�������ӡ��
        /// </summary>
        public static int LisInHospitalApplyPrintOk = 0;
        /// <summary>
        /// סԺ�շ����Ϸ�
        /// </summary>
        public static int LisInHospitalChargeCancel = 0;
        /// <summary>
        /// סԺ�շѷ�
        /// </summary>
        public static int LisInHospitalChargeOk = 0;
        
        public BaseListRules()
        {           
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }
        /// <summary>
        /// ���ò���ֵ
        /// </summary>
        public void ZASetParamValue()
        {
            DataSet ds = ZAGetBaseListOnlyRead();
            DataTable dt = ds.Tables[0];
            DataRow dr = null;
            string strkey = "";
            int intUserId = 0;
            string strValue = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                strkey = dr["fkey"].ToString();
                intUserId = Convert.ToInt32(dr["fuse_id"].ToString());
                strValue =dr["fvalue"].ToString();
                switch (strkey)
                {
                    case "LisClinicChargeOk":
                        LisClinicChargeOk = intUserId;
                        break;
                    case "LisClinicApplyPrintOk":
                        LisClinicApplyPrintOk = intUserId;
                        break;
                    case "LisClinicChargeCancel":
                        LisClinicChargeCancel = intUserId;
                        break;                   
                    case "LisClinicPatientOk":
                        {
                            LisClinicPatientOk = intUserId;
                            LisClinicPatientOkValue = strValue;
                            break;
                        }
                    case "LisInHospitalApplyPrintOk":
                        LisInHospitalApplyPrintOk = intUserId;
                        break;
                    case "LisInHospitalChargeCancel":
                        LisInHospitalChargeCancel = intUserId;
                        break;
                    case "LisInHospitalChargeOk":
                        LisInHospitalChargeOk = intUserId;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// ����������֯IDȡ����־���ݼ�
        /// </summary>
        /// <param name="strWhere">�������ݼ�����</param>
        /// <returns></returns>
        public DataSet ZAGetDataSet()
        {
            string sql;
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_base_list ORDER BY ftype, fsort_id";
            ds = this.DataSetLoadBySql(sql, "sys_base_list");
            return ds;
        }
        
        public DataSet ZAGetBaseListOnlyRead()
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM sys_base_list";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// ����������֯IDȡ����־���ݼ�
        /// </summary>
        /// <param name="strUse_id">���÷�</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetOnlyRead(string strUse_id)
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM sys_base_list Where fuse_id = '" + strUse_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
       /// <summary>
        /// ���ݹؼ���ȡ��ֵ
       /// </summary>  
        /// <param name="strfkey">�ؼ���</param>
       /// <returns></returns>
        public string ZAGetFvalueByFkey(string strFkey)
        {
            string sql = "SELECT fvalue FROM sys_base_list WHERE (fkey='" + strFkey + "')";
            return this.ExecuteScalarGetString(sql);
        }

        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZAUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_base_list_ADD";//���_���� 
            string strStoredProcDelete = "sys_base_list_Delete";//���_ɾ�� 
            string strStoredProcUpdate = "sys_base_list_Update";//���_�޸�         
            string strStrKey = "fkey";//������      
            string strStrTableName = "sys_base_list";//����             
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
    }
}
