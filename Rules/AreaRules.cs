using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    /// <summary>
    /// �������� ����
    /// </summary>
    public class AreaRules : ZASuite.Lis.Rules.ZASuiteDAORulesLis
    {
        public AreaRules()
        {
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }

        /// <summary>
        /// ȡ��Ѫ��ⷿ�����б��ɶ�д
        /// </summary>    
        /// <returns></returns>
        public DataSet GetListWrite()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area ORDER BY FNumber";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// �������� ȡ��Ѫ��ⷿ�����б��ɶ�д
        /// </summary>      
        ///  <param name="strWhere">����</param>
        /// <returns></returns>
        public DataSet GetListWrite(string strWhere)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area " + strWhere;
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// ����������� ȡ�� ���� �����б��ɶ�д
        /// </summary>      
        ///  <param name="strClassName">��������</param>
        /// <returns></returns>
        public DataSet GetListByClassName(string strClassName)
        {
            string sql;
            DataSet ds = new DataSet();
            if (strClassName == "" || strClassName == null)
                sql = "SELECT * FROM sys_area ORDER BY FNumber";
            else
                sql = "SELECT * FROM sys_area WHERE (FClassName = '" + strClassName.Trim() + "') ORDER BY FNumber";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// �������� ȡ��Ѫ��ⷿ�����б��ɶ�д
        /// </summary>      
        ///  <param name="strFClassName">����</param>
        /// <returns></returns>
        public DataSet GetListWriteByType(string strFClassName)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area Where FClassName = '" + strFClassName + "'";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// ȡ�ÿɶ�д�б������ϼ�ID
        /// </summary>
        /// <param name="strFParentID"></param>
        /// <returns></returns>
        public DataSet GetListWriteByFParentID(string strFParentID)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area Where FID<>'0' and FParentID = '" + strFParentID + "'";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// ȡ��Ѫ��ⷿ�����б� ���ã�ֻ��
        /// </summary>       
        /// <returns></returns>
        public DataSet GetList()
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_area Where FStatus = '1' ORDER BY FNumber";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// ȡ��Ѫ��ⷿ�����б�ֻ��
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_area " + strWhere;
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// ȡ�����ƣ�����ID
        /// </summary>
        /// <param name="strID">����</param>       
        /// <returns></returns>
        public string ZAFName(string strID)
        {
            string sql = "SELECT FName FROM sys_area Where FID='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
        /// <summary>
        /// ȡ�ô��룬����ID
        /// </summary>
        /// <param name="strID">����</param>       
        /// <returns></returns>
        public string ZAFCode(string strID)
        {
            string sql = "SELECT FCode FROM sys_area Where FID='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZAUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_area_ADD";//���_���� 
            string strStoredProcDelete = "sys_area_Delete";//���_ɾ�� 
            string strStoredProcUpdate = "sys_area_Update";//���_�޸�         
            string strStrKey = "FID";//������      
            string strStrTableName = "sys_area";//���� 
            //string strStrSortId = "FNumber";//�����ֶ�          
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        
    }
}
