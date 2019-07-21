using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class PositionRules : ZASuiteDAORulesSys
    {
        string strStoredProcAdd = "sys_position_ADD";//���_���� 
        string strStoredProcDelete = "sys_position_Delete";//���_ɾ�� 
        string strStoredProcUpdate = "sys_position_Update";//���_�޸�         
        string strStrKey = "fposition_id";//������      
        string strStrTableName = "sys_position";//���� 
        string strStrSortId = "fsort_id";//�����ֶ� 
        
        public PositionRules()
        {
            
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }

        /// <summary>
        /// ȡ�ø�λ���ݼ� ֻ��
        /// </summary>      
        /// <returns></returns>
        public DataSet ZAGetDataSetRead()
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_position WHERE (fstatus = 1)");
        }

        /// <summary>
        /// ����������֯IDȡ�ø�λ���ݼ�
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
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdate(DataSet dsObject)
        {
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }

        /// <summary>
        /// ɾ����λ
        /// </summary>
        /// <param name="strId">��λID</param>
        /// <returns></returns>
        public bool ZADelPosition(string strId)
        {
            bool result = false;
            string delPosition = "Delete sys_position WHERE (fposition_id = '" + strId + "')";
            string delOrg = "Delete sys_org WHERE (fposition_id = '" + strId + "')";
            if (this.ExecuteTransaction2(delOrg, delPosition))
            {
                result = true;
            }
            return result;
        }
    }
}
