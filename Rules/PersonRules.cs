using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class PersonRules : ZASuiteDAORulesSys
    {
        string strStoredProcAdd = "sys_person_ADD";//���_���� 
        string strStoredProcDelete = "sys_person_Delete";//���_ɾ�� 
        string strStoredProcUpdate = "sys_person_Update";//���_�޸�         
        string strStrKey = "fperson_id";//������      
        string strStrTableName = "sys_person";//���� 
        string strStrSortId = "fsort_id";//�����ֶ� 
       
        public PersonRules()
        {
           
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }
        /// <summary>
        /// ȡ����Ա���ݼ� ֻ��
        /// </summary>      
        /// <returns></returns>
        public DataSet ZAGetDataSetRead()
        {
            DataSet ds = null;
            ds = this.DataSetExecuteBySql("SELECT * FROM sys_person WHERE (fstatus = 1) Order By fname");
            return ds;
        }
        /*
        /// <summary>
        /// �������� ȡ���б�
        /// </summary>
        /// <param name="strflogin_name">��¼��</param>
        /// <returns></returns>
        public IDataReader ZAGetIDataReaderPersonList(string strflogin_name)
        {
            string strSql = "SELECT * FROM sys_person WHERE (fstatus = '1') AND (flogin_name LIKE '" + strflogin_name + "%') Order By fname";
            return this.IDataReaderBySql(strSql);
        }*/
        /// <summary>
        /// ����������֯IDȡ����Ա���ݼ�
        /// </summary>
        /// <param name="strWhere">�������ݼ�����</param>
        /// <returns></returns>
        public DataSet ZAGetDataSet(string strWhere)
        {
            string sql;
            DataSet ds = new DataSet();
            if (strWhere == "" || strWhere == null)
            {
                sql = "SELECT * FROM " + strStrTableName + " ORDER BY " + strStrSortId;
            }
            else
            {
                sql = "SELECT * FROM " + strStrTableName + " WHERE " + strWhere + " ORDER BY " + strStrSortId;
            }
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }


        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdate(DataSet dsObject)
        {
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        /// <summary>
        /// ��¼�����ڷ�
        /// </summary>
        /// <param name="strloginname"></param>
        /// <returns></returns>
        public bool ZALoginNameExists(string strloginname)
        {
           return this.Exists("SELECT COUNT(1) FROM sys_person WHERE (flogin_name = '" + strloginname + "')");
        }
        /// <summary>
        /// ɾ����Ա
        /// </summary>
        /// <param name="strId">��ԱID</param>
        /// <returns></returns>
        public bool ZADelPerson(string strId)
        {
            bool result = false;
            string delPerson = "Delete sys_person WHERE (fperson_id = '" + strId + "')";
            string delOrg = "", delOrg_Func = "";
            string strforg_id = "";
            string sqlOrg = "SELECT forg_id FROM sys_org WHERE (fperson_id = '" + strId + "') and ftype='Person'";
            DataSet dsOrg = new DataSet();
            dsOrg = this.DataSetLoadBySql(sqlOrg, "sys_org");
            for (int i = 0; i < dsOrg.Tables[0].Rows.Count; i++)
            {
                strforg_id = dsOrg.Tables[0].Rows[i]["forg_id"].ToString();//��Ա ����֯ ID 
                delOrg = "Delete sys_org Where forg_id='" + strforg_id + "' and ftype='Person'";
                delOrg_Func = "Delete sys_org_func Where forg_id = '" + strforg_id + "'";
                this.ExecuteNonQuery(delOrg_Func);//ɾ����Ա���ܼ�¼  
                this.ExecuteNonQuery(delOrg);//ɾ����Ա��֯��¼
            }
            if (this.ExecuteNonQuery(delPerson) > 0)//ɾ����Ա
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// ���ݣɣ�ȡ�õ�¼����
        /// </summary>
        /// <param name="strID">����ID</param>
        /// <returns></returns>
        public string ZAGetPersonByLloginName(string strID)
        {
            string sql = "SELECT fname FROM sys_person WHERE flogin_name='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
        /// <summary>
        /// ���ݣɣ�ȡ������
        /// </summary>
        /// <param name="strID">����ID</param>
        /// <returns></returns>
        public string ZAGetPersonNameByID(string strID)
        {
            string sql = "SELECT fname FROM sys_person WHERE fperson_id='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
    }
}
