using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class DeptRules : ZASuiteDAORulesSys
    {
        //string strStoredProcAdd = "sys_dept_ADD";//���_���� 
        //string strStoredProcDelete = "sys_dept_Delete";//���_ɾ�� 
        //string strStoredProcUpdate = "sys_dept_Update";//���_�޸�         
        //string strStrKey = "fdept_id";//������      
        string strStrTableName = "sys_dept";//���� 
        string strStrSortId = "fsort_id";//�����ֶ� 
       
        public DeptRules()
        {           
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }
        
        /// <summary>
        /// ����������֯IDȡ�ò������ݼ�
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
                sql = "SELECT * FROM " + strStrTableName + " WHERE '" + strWhere + "' ORDER BY " + strStrSortId;
            }
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }

        /// <summary>
        /// �����ϼ�ID
        /// </summary>
        /// <param name="strFparent_id">�ϼ�ID</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetByFparent_id(string strFparent_id)
        {
            string sql;
           // string strWhere = " fparent_id='" + strFparent_id + "' ";
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_dept WHERE fparent_id='" + strFparent_id + "' ORDER BY fsort_id";
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }
        /// <summary>
        /// ȡ�ò����б�  ֻ��������״̬
        /// </summary>
        /// <param name="strFStatus"></param>
        /// <returns></returns>
        public DataSet ZAGetDataSetByFStatus(string strFStatus)
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM sys_dept WHERE fstatus='" + strFStatus + "' ORDER BY fsort_id,fname";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// ���ݣɣ�ȡ������
        /// </summary>
        /// <param name="strID">����ID</param>
        /// <returns></returns>
        public string ZAGetDeptNameByID(string strID)
        {
            string sql = "SELECT fname FROM sys_dept WHERE fdept_id='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }

        /*
        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdate(DataSet dsObject)
        {
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        */
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="strId">����ID</param>
        /// <returns></returns>
        public bool ZADelDept(string strId)
        {
            bool result = false;
            string delPosition = "Delete sys_dept WHERE (fdept_id = '" + strId + "')";
            string delOrg = "Delete sys_org WHERE (fdept_id = '" + strId + "')";
            if (this.ExecuteTransaction2(delOrg, delPosition))
            {
                result = true;
            }
            return result;
        }


        /// <summary>
        ///���� �Ƿ�����¼�
        /// </summary>
        /// <param name="strId">����ID</param>
        /// <returns></returns>
        public bool ZADeptHaveChild(string strId)
        {
            string strid = null;
            bool b = false;
            strid = this.ExecuteScalarGetString("SELECT fdept_id FROM sys_dept WHERE (fparent_id = '" + strId + "')");
            if (strid == "" || strid == null || strid.Length == 0)
            { 
            }
            else
            {
                b = true;
            }
            return b;
        }

      

        //-------------------------------------------------------------
        /// <summary>
        /// �����ϼ�ID ȡ����֯����
        /// </summary>
        /// <param name="strFparent_id">�ϼ�ID</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetOrg(string strFparent_id)
        {
            string sql;
            // string strWhere = " fparent_id='" + strFparent_id + "' ";
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_org WHERE fparent_id='" + strFparent_id + "' and  ftype='Dept' ORDER BY fsort_id";
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }


        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdateOrg(DataSet dsObject)
        {
            string strStoredProcAdd1 = "sys_org_ADD";//���_���� 
            string strStoredProcDelete1 = "sys_org_Delete";//���_ɾ�� 
            string strStoredProcUpdate1 = "sys_org_Update";//���_�޸�         
            string strStrKey1 = "forg_id";//������      
            string strStrTableName1 = "sys_org";//����             
            return this.DataSetUpdate(dsObject, strStrTableName1, strStrKey1, strStoredProcAdd1, strStoredProcDelete1, strStoredProcUpdate1);
        }
    }
}
