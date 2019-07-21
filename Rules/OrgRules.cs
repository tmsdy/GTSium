using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class OrgRules : ZASuiteDAORulesSys
    {
        //ZAWebServices.ZAWebServices zaws = new ZAWebServices.ZAWebServices();
        //DataSet ds = new DataSet();
        
        public static string StrUserOrgId = "";//��Ա ����֯ ID
        public static string StrDeptId = "";//����ID
        public static string StrPositionId = "";//��λID
        public static string StrUserName = "";//��Ա����
        public static string StrLoginName = "";//��Ա��¼��

        public static string StrDeptName = "";//��������
        public static string StrPositionName = "";//��λ����
        public static string StrLoginDateTime;//��¼ʱ��
        public static string StrPersonId = "";//��ԱID

        
        private DataSet m_dsObjectOrg = null;
        /// <summary>
        /// ���ݼ�����
        /// </summary>
        public DataSet dsObjectOrg
        {
            get
            {
                return this.m_dsObjectOrg;
            }
            set
            {
                this.m_dsObjectOrg = value;
            }
        }
       
        public OrgRules()
        {
         
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }
       
        
       /// <summary>
       /// ��¼�Ƿ�ɹ�
       /// </summary>
       /// <param name="strLoginName">��¼��</param>
       /// <param name="SysLoginPassword">����</param>
       /// <returns></returns>
        public bool LoginSuccess(string strLoginName, string SysLoginPassword)
        {
            bool b = false;
            DataSet ds = null;//            
            string sql =  "SELECT fperson_id FROM sys_person where FLOGIN_NAME='" + strLoginName + "' AND (fpassword='" + SysLoginPassword + "')";          
            ds = this.DataSetExecuteBySql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                StrPersonId = ds.Tables[0].Rows[0]["fperson_id"].ToString();
                StrLoginName = strLoginName;
                b = true;
            }
            return b;
        }
        /// <summary>
        /// ������ԱIDȡ����֯��Ա��Ϣ�б��������Ϊ1��ȡ����֯��Ϣ���������1����ʾ�б�
        /// </summary>
        /// <param name="StrPersonId">��ԱID</param>
        /// <returns></returns>
        public int GetOrgInfoCountByPersonId(string StrPersonId)
        {
            string strOrgId = "";
            int orgcount = 0;
            DataSet ds = null;           
            string sql = "SELECT * FROM v_sys_org where fperson_id='" + StrPersonId + "'";
            ds = this.DataSetExecuteBySql(sql);
            orgcount = ds.Tables[0].Rows.Count;
            if (orgcount==1)
            {               
                strOrgId = ds.Tables[0].Rows[0]["forg_id"].ToString();//��Ա ����֯ ID 
                GetOrgInfoByOrgId(strOrgId);                
            }
            else if (orgcount > 1)
            {
                this.m_dsObjectOrg = ds;
            }
            return orgcount;
        }
        /// <summary>
        /// ������֯IDȡ����֯��Ϣ
        /// </summary>
        /// <param name="strForg_id">��֯ID</param>
        /// <returns></returns>
        public void GetOrgInfoByOrgId(string strForg_id)
        {           
            DataSet ds = null;           
            string sql = "SELECT * FROM v_sys_org where forg_id='" + strForg_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {                
                StrUserOrgId = ds.Tables[0].Rows[0]["forg_id"].ToString();//��Ա ����֯ ID 
                StrDeptId = ds.Tables[0].Rows[0]["fdept_id"].ToString();//����ID
                StrPositionId = ds.Tables[0].Rows[0]["fposition_id"].ToString();//��λID
                StrUserName = ds.Tables[0].Rows[0]["personName"].ToString();//��Ա����
                StrDeptName = ds.Tables[0].Rows[0]["deptName"].ToString();//��������
                StrPositionName = ds.Tables[0].Rows[0]["positionName"].ToString();//��λ����
                StrPersonId = ds.Tables[0].Rows[0]["fperson_id"].ToString();//��ԱID
                //Silt.Base.Common.Time time = new Silt.Base.Common.Time();
                StrLoginDateTime =this.ZAGetCurrentServerDateTim();//��¼ʱ��
            }
            else
            {
                StrUserOrgId = "";//��Ա ����֯ ID 
                StrDeptId = "";//����ID
                StrPositionId = "";//��λID
                StrUserName = "";//��Ա����
                StrDeptName = "";//��������
                StrPositionName = "";//��λ����
                StrPersonId = "";//��ԱID
                //Silt.Base.Common.Time time = new Silt.Base.Common.Time();
                StrLoginDateTime = this.ZAGetCurrentServerDateTim(); ;//��¼ʱ��
            }
        }
        
        /*
        /// <summary>
        /// ȡ����֯��Ա��Ϣ
        /// </summary>
        /// <param name="strPersonId">��ԱID</param>
        /// <returns></returns>
        public bool GetOrgInfo()
        {
            bool b = false;
            ds = null;
            sql = "";
            sql = "SELECT * FROM sys_org where fperson_id='" + StrPersonId + "'";
            ds = this.DataSetLoadBySql(sql, "sys_org");
            if (ds.Tables[0].Rows.Count > 0)
            {
                b = true;
                StrUserOrgId = ds.Tables[0].Rows[0]["forg_id"].ToString();//��Ա ����֯ ID 
                StrDeptId = ds.Tables[0].Rows[0]["fdept_id"].ToString();//����ID
                StrPositionId = ds.Tables[0].Rows[0]["fposition_id"].ToString();//��λID
                StrUserName = ds.Tables[0].Rows[0]["fname"].ToString();//��Ա����
                try
                {
                    StrDeptName = this.ExecuteScalarGetString("SELECT fname FROM sys_dept WHERE fdept_id='" + StrDeptId + "'");//��������
                }
                catch { }
                try
                {
                    StrPositionName = this.ExecuteScalarGetString("SELECT fname FROM sys_position WHERE fposition_id='" + StrPositionId + "'");///��λ����
                }
                catch { }
                Silt.Base.Common.Time time = new Silt.Base.Common.Time();
                StrLoginDateTime = time.GetDataTime();//��¼ʱ��
            }
            return b;
        }*/
    }
}
