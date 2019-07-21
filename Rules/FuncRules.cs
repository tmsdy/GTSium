using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Silt.Client.Rules
{
    public class FuncRules : ZASuiteDAORulesSys
    {
       
        string strStrTableName = "sys_func";//���� 
        string strStrSortId = "fsort_id";//�����ֶ� 
        
        public FuncRules()
        {

            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }

        
        /// <summary>
        /// ����������֯IDȡ�ù������ݼ�
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
            sql = "SELECT * FROM sys_func WHERE fparent_id='" + strFparent_id + "' ORDER BY fsort_id";
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }

        

        /// <summary>
        /// ȡ��ֻ�� �������ݼ��б�
        /// </summary>    
        /// <returns></returns>
        public DataSet ZAGetFuncDataSetRead()
        {

            return this.DataSetExecuteBySql("SELECT * FROM sys_func WHERE (fstatus = 1) order by fsort_id");

        }

        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
       // public int ZADataSetUpdate(DataSet dsObject)
       // {
          //  return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        //}

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="strId">����ID</param>
        /// <returns></returns>
        public bool ZADelDept(string strId)
        {
            bool result = false;
            string delSQL = "Delete sys_func WHERE (ffunc_id = '" + strId + "')";
            if (this.ExecuteNonQuery(delSQL) > 0)
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
            strid = this.ExecuteScalarGetString("SELECT ffunc_id FROM sys_func WHERE (fparent_id = '" + strId + "')");
            if (strid == "" || strid == null || strid.Length == 0)
            {
            }
            else
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="funcmodel">����ģ��</param>
        /// <returns></returns>
        public bool FuncAdd(FuncModel modelobject)
        {
            bool result = false;

            /*
            Database db = DatabaseFactory.CreateDatabase(ZAStrConn);
            DbCommand dbCommandObject = db.GetStoredProcCommand("sys_func_ADD");

            db.AddInParameter(dbCommandObject, "ffunc_id", DbType.String, modelobject.ffunc_id);
            db.AddInParameter(dbCommandObject, "fname", DbType.String, modelobject.fname);
            db.AddInParameter(dbCommandObject, "fwinform", DbType.String, modelobject.fwinform);
            db.AddInParameter(dbCommandObject, "fparent_id", DbType.String, modelobject.fparent_id);
            db.AddInParameter(dbCommandObject, "fstatus", DbType.String, modelobject.fstatus);
            db.AddInParameter(dbCommandObject, "fsort_id", DbType.Decimal, modelobject.fsort_id);
            db.AddInParameter(dbCommandObject, "fremark", DbType.String, modelobject.fremark);       
           */

            string strSql = "INSERT INTO sys_func([ffunc_id],[fname],[fwinform],[fparent_id],[fstatus],[fsort_id],[fremark],[fopen_page],[fpluggableUnit],[fpluggableUnitName],[fpluggableUnitAssembly],[ficon])VALUES('" + modelobject.ffunc_id + "','" + modelobject.fname + "','" + modelobject.fwinform + "','" + modelobject.fparent_id + "','" + modelobject.fstatus + "'," + modelobject.fsort_id + ",'" + modelobject.fremark + "','" + modelobject.fopen_page + "','"+modelobject.fpluggableUnit+"','"+modelobject.fpluggableUnitName+"','"+modelobject.fpluggableUnitAssembly+"','"+modelobject.ficon+"')";
            if (this.ExecuteNonQuery(strSql) > 0)
            {
              result = true;
            }       
            return result;
        }

        //-------------------�����������
        /// <summary>
        /// ���ݹ���ID���ϼ�IDȡ�ù����������ݼ�,�ɶ�д
        /// </summary>
        /// <param name="FFunc_id">����ID</param>
        /// <param name="FParent_ID">�ϼ�ID</param>
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyByFFunc_id(string FFunc_id, string FParent_ID)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_func_property Where FFunc_id='" + FFunc_id + "' and FParent_ID='" + FParent_ID + "'";
            ds = this.DataSetLoadBySql(sql, "sys_func_property");
            return ds;
        }
        /// <summary>
        /// ���ݹ���IDȡ�ù����������ݼ�,ֻ��
        /// </summary>
        /// <param name="FFunc_id">����ID</param>
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyByFFunc_idRead(string FFunc_id)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_func_property Where FFunc_id='" + FFunc_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// �����ϼ�IDȡ�ù����������ݼ�,ֻ��
        /// </summary>
        /// <param name="FParent_ID">�ϼ�ID</param>
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyByFParent_IDRead(string FParent_ID)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_func_property Where FParent_ID='" + FParent_ID + "' Order By FIndex";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// ȡ�û������������б�ֻ��
        /// </summary>       
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyBaseList()
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_func_property Where FStatus=1 and FFunc_id='-1'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// ͨ���洢���� ��������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int ZAUpdateFuncProperty(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_func_property_ADD";//���_���� 
            string strStoredProcDelete = "sys_func_property_Delete";//���_ɾ�� 
            string strStoredProcUpdate = "sys_func_property_Update";//���_�޸�         
            string strStrKey = "FProperty_ID";//������      
            string strStrTableName = "sys_func_property";//����          
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        //----------------------------------
    }
}
