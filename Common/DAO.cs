using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Silt.Base.Common
{
    /// <summary>
    /// ���ݿ��ȡ����
    /// </summary>
    /// <remarks>
    /// ���ߣ�������
    /// ʱ�䣺2007.3
    /// �Ķ���[�����ޣ�2007.5]
    /// </remarks>
    public class DAO
    {      
        public DAO()
        {           
            ///
            /// TODO: �ڴ˴���ӹ��캯���߼�
            ///         
        }        
         
        /// <summary>
        /// װ�� ���ݼ� �ɶ�д
        /// </summary>
        /// <param name="strSql">SQL</param>
        /// <param name="strTableName">װ�ر���</param>
        /// <returns></returns>        
        public DataSet LoadDataSet(string strConn, string strSql, string strTableName)
        {
            DataSet DataSetObject = new DataSet();      
            Database db = DatabaseFactory.CreateDatabase(strConn);                  
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.LoadDataSet(dbCommand, DataSetObject, strTableName);
            return DataSetObject;
        }
       /// <summary>
        /// װ�����ݼ� ���ݴ��
       /// </summary>
       /// <param name="strConn"></param>
       /// <param name="strStoredProcName"></param>
       /// <param name="strTableName"></param>
       /// <param name="strInParameterName"></param>
       /// <param name="strInParameterValue"></param>
       /// <returns></returns> 
        public DataSet LoadDataSetByStoredProc(string strConn, string strStoredProcName, string strTableName,
            string strInParameterName, string strInParameterValue)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            DataSet DataSetObject = new DataSet();
            DbCommand dbCommand = db.GetStoredProcCommand(strStoredProcName);
            db.AddInParameter(dbCommand, strInParameterName, DbType.String, strInParameterValue);
            db.LoadDataSet(dbCommand, DataSetObject, strTableName);
            return DataSetObject;
        }

       /// <summary>
        /// ִ�� ���ݼ� ֻ��
       /// </summary>
       /// <param name="strConn"></param>
       /// <param name="strSql"></param>
       /// <returns></returns>      
        public DataSet ExecuteDataSet(string strConn, string strSql)
        {
            DataSet DataSetObject = null;
            Database db = DatabaseFactory.CreateDatabase(strConn);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            DataSetObject = db.ExecuteDataSet(dbCommand);
            return DataSetObject;
        }
       
        /// <summary>
        /// ִ�����ݼ� ���ݴ��
        /// </summary>
        /// <param name="strStoredProcName">�����</param>
        /// <returns></returns>        
        public DataSet ExecuteDataSetByStoredProc(string strConn, string strStoredProcName)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            DataSet DataSetObject = null;
            string sqlCommand = strStoredProcName;
            DbCommand dbCommand = db.GetStoredProcCommand(strStoredProcName);
            DataSetObject = db.ExecuteDataSet(dbCommand);
            return DataSetObject;           
        }               

        /// <summary>
        /// װ�����ݼ�(��ҳ���ɶ���д LoadDataSet)
        /// </summary>
        /// <param name="tblName">�����(��ͼ)��</param>
        /// <param name="fldName">������</param>
        /// <param name="PageSize"> ҳ�ߴ�</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="IsReCount">���ؼ�¼����, �� 0 ֵ�򷵻�</param>
        /// <param name="OrderType">������������, �� 0 ֵ����</param>
        /// <param name="strWhere">��ѯ���� (ע��: ��Ҫ�� where)</param>
        ///   <param name="strLoadTableName">װ�ر���</param>
        /// <returns></returns>        
        public DataSet LoadDataSetPaging(string strConn, string tblName, string fldName, Int32 PageSize, Int32 PageIndex, Int32 IsReCount, Int32 OrderType, string strWhere, string strLoadTableName)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            DataSet DataSetObject = new DataSet();
            string sqlCommand = "Sys_GetRecordByPage";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "tblName", DbType.String, tblName);
            db.AddInParameter(dbCommand, "fldName", DbType.String, fldName);
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Int32, IsReCount);
            db.AddInParameter(dbCommand, "OrderType", DbType.Int32, OrderType);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);      
            db.LoadDataSet(dbCommand, DataSetObject, strLoadTableName);
            //��¼����Ϊ��
            //ZAGetPageTableRowsCount = this.ExecuteScalar("SELECT COUNT(*) AS Total FROM COMMON_CODE");
            return DataSetObject;
        }

        /// <summary>
        /// װ�����ݼ�(��ҳ��ֻ��ExecuteDataSet)
        /// </summary>
        /// <param name="tblName">�����(��ͼ)��</param>
        /// <param name="fldName">������</param>
        /// <param name="PageSize"> ҳ�ߴ�</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="IsReCount">���ؼ�¼����, �� 0 ֵ�򷵻�</param>
        /// <param name="OrderType">������������, �� 0 ֵ����</param>
        /// <param name="strWhere">��ѯ���� (ע��: ��Ҫ�� where)</param>       
        /// <returns></returns>        
        public DataSet ExecuteDataSetPaging(string strConn, string tblName, string fldName, Int32 PageSize, Int32 PageIndex, Int32 IsReCount, Int32 OrderType, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            DataSet DataSetObject = null;
            string sqlCommand = "Sys_GetRecordByPage";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "tblName", DbType.String, tblName);
            db.AddInParameter(dbCommand, "fldName", DbType.String, fldName);
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Int32, IsReCount);
            db.AddInParameter(dbCommand, "OrderType", DbType.Int32, OrderType);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);

            DataSetObject = db.ExecuteDataSet(dbCommand);
            return DataSetObject;
        }


        /// <summary>
        /// ��System.Typeת���ɳ�System.Data.DbType 
        /// </summary>
        /// <param name="type">System.Type</param>
        /// <returns></returns>
        protected static DbType ZAGetDbType(Type type)
        {
            /*
              cmd.Parameters.Add("@UpdateImage", SqlDbType.Image);
                    cmd.Parameters["@UpdateImage"].Value = picbyte;
             */
            //SqlDbType.Image
            DbType result = DbType.String;
            if (type.Equals(typeof(int)) || type.IsEnum)
                result = DbType.Int32;
            else if (type.Equals(typeof(Int16)))
                result = DbType.Int16;
            else if (type.Equals(typeof(Int32)))
                result = DbType.Int32;
            else if (type.Equals(typeof(Int64)))
                result = DbType.Int64;
            else if (type.Equals(typeof(Object)))
                result = DbType.Object;
            else if (type.Equals(typeof(Byte)))
                result = DbType.Byte;
            else if (type.Equals(typeof(Single)))
                result = DbType.Single;
            else if (type.Equals(typeof(long)))
                result = DbType.Int32;
            else if (type.Equals(typeof(double)) || type.Equals(typeof(Double)))
                result = DbType.Decimal;
            else if (type.Equals(typeof(DateTime)))
                result = DbType.DateTime;
            else if (type.Equals(typeof(bool)))
                result = DbType.Boolean;
            else if (type.Equals(typeof(Boolean)))
                result = DbType.Boolean;
            else if (type.Equals(typeof(string)))
                result = DbType.String;
            else if (type.Equals(typeof(decimal)))
                result = DbType.Decimal;
            else if (type.Equals(typeof(byte[])))
                result = DbType.Binary;
            else if (type.Equals(typeof(Guid)))
                result = DbType.Guid;
            else if (type.Equals(typeof(Decimal)))
                result = DbType.Decimal;
            return result;

        }
        /// <summary>
        /// ִ��ExecuteNonQuery
        /// �÷������ص���SQL���ִ��Ӱ������������ǿ������ø÷�����ִ��һЩû�з���ֵ�Ĳ���(Insert,Update,Delete)
        /// </summary>
        /// <param name="strSql">һ���SQL���</param>        
        public int ExecuteNonQuery(string strConn, string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);           
            DbCommand dbcomm = db.GetSqlStringCommand(strSql);
            return db.ExecuteNonQuery(dbcomm);
        }
        /// <summary>
        ///  �Ƿ���ڸü�¼
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="sql">SELECT count(1) FROM v_sys_org_func where fparent_id='dc791e654f6e415da953281ea8358dff'</param>
        /// <returns></returns>
        public bool RecordExists(string strConn, string sql)
        {
            //SELECT count(1) FROM v_sys_org_func where fparent_id='dc791e654f6e415da953281ea8358dff'
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sql);
            Database db = DatabaseFactory.CreateDatabase(strConn);           
            object obj = db.ExecuteScalar(CommandType.Text, strSql.ToString());
            int cmdresult = 0;
            try
            {
                cmdresult = int.Parse(obj.ToString());
            }
            catch
            {
                return false;
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        /// <summary>
        /// ִ��ExecuteScalar ���ض���
        /// (DateTime)obj
        /// Convert.ToInt32(obj)
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>     
        public object ExecuteScalar(string strConn, string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);          
            DbCommand dbcomm = db.GetSqlStringCommand(strSql);
            object obj = db.ExecuteScalar(dbcomm);
            return obj;
        }
        /// <summary>
        /// ִ��ExecuteScalar ���ض���
        /// (DateTime)obj
        /// Convert.ToInt32(obj)
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="strStoredProc"></param>
        /// <returns></returns>     
        public object ExecuteScalarByStoredProc(string strConn, string strStoredProc)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            DbCommand dbcomm = db.GetStoredProcCommand(strStoredProc);
            object obj = db.ExecuteScalar(dbcomm);
            return obj;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strKey">�����ֶ���</param>
        /// <param name="strStoredProcInsertCommand">�����洢������</param>
        /// <param name="strStoredProcDeleteCommand">ɾ���洢������</param>
        /// <param name="strStoredProcupdateCommand">�޸Ĵ洢������</param>
        /// <returns></returns>        
      /// <summary>
        ///  ͨ���洢������������ɾ�������ݼ� һ�ű�
      /// </summary>
      /// <param name="strConn"></param>
      /// <param name="dsObject"></param>
      /// <param name="strTableName"></param>
      /// <param name="strKey"></param>
        /// <param name="strStoredProcInsertCommand">�����洢������</param>
        /// <param name="strStoredProcDeleteCommand">ɾ���洢������</param>
        /// <param name="strStoredProcupdateCommand">�޸Ĵ洢������</param>
        /// <param name="intUpdateBehavior">�޸�����(Standard = 0,Continue = 1,Transactional = 2,)</param>
      /// <returns></returns>
        public int UpdateDataSet
            (string strConn, DataSet dsObject, string strTableName, string strKey, string strStoredProcInsertCommand, string strStoredProcDeleteCommand, string strStoredProcupdateCommand,int intUpdateBehavior)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            String columnName = "";
            System.Type columnType;
            int columnsCount = 0;
            DataSet ds = new DataSet();
            ds = dsObject;
            DataTable table = new DataTable();
            table = ds.Tables[strTableName];
            columnsCount = table.Columns.Count;

            DbCommand insertCommand = db.GetStoredProcCommand(strStoredProcInsertCommand);
            for (int i = 0; i < columnsCount; i++)
            {
                columnType = table.Columns[i].DataType;
                columnName = table.Columns[i].ColumnName;
                db.AddInParameter(insertCommand, columnName, ZAGetDbType(columnType), columnName, DataRowVersion.Current);
            }

            DbCommand deleteCommand = db.GetStoredProcCommand(strStoredProcDeleteCommand);
            db.AddInParameter(deleteCommand, strKey, DbType.String, strKey, DataRowVersion.Current);

            DbCommand updateCommand = db.GetStoredProcCommand(strStoredProcupdateCommand);
            for (int ii = 0; ii < columnsCount; ii++)
            {
                columnType = table.Columns[ii].DataType;
                columnName = table.Columns[ii].ColumnName;
                db.AddInParameter(updateCommand, columnName, ZAGetDbType(columnType), columnName, DataRowVersion.Current);
            }

            /*
              Standard = 0,Continue = 1,Transactional = 2,
             */
            int rowsAffected = 0;
            switch (intUpdateBehavior)
            {
                case 0:                   
                        rowsAffected = 
                            db.UpdateDataSet(ds, strTableName, insertCommand, updateCommand,deleteCommand, UpdateBehavior.Standard);
                   
                    break;
                case 1:
                    rowsAffected = 
                        db.UpdateDataSet(ds, strTableName, insertCommand, updateCommand,
                                                 deleteCommand, UpdateBehavior.Continue);
                    break;
                case 2:
                    rowsAffected = 
                        db.UpdateDataSet(ds, strTableName, insertCommand, updateCommand,
                                                 deleteCommand, UpdateBehavior.Transactional);
                    break;
                default:
                    rowsAffected = 
                        db.UpdateDataSet(ds, strTableName, insertCommand, updateCommand,
                                                 deleteCommand, UpdateBehavior.Standard);
                    break;
            }                     
            return rowsAffected;

        }
       /// <summary>
        /// ���ݸ��� ������ (��������ű������¼�¼)
       /// </summary>
       /// <param name="strConn"></param>
       /// <param name="dsObject_1"></param>
       /// <param name="strTableName_1"></param>
       /// <param name="strStoredProcInsertCommand_1"></param>
       /// <param name="dsObject_2"></param>
       /// <param name="strTableName_2"></param>
       /// <param name="strStoredProcInsertCommand_2"></param>
       /// <returns></returns>
        public int UpdateDataSetStoredProcInsert2(string strConn, DataSet dsObject_1, string strTableName_1, string strStoredProcInsertCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcInsertCommand_2)
        {
            int result = 0;
            Database db = DatabaseFactory.CreateDatabase(strConn);

            //��_1
            DataSet ds_1 = new DataSet();
            ds_1 = dsObject_1;
            String columnName_1;
            System.Type columnType_1;
            int columnsCount_1 = 0;
            DataTable table_1 = new DataTable();
            table_1 = ds_1.Tables[strTableName_1];
            columnsCount_1 = table_1.Columns.Count;
            DbCommand insertCommand_1 = db.GetStoredProcCommand(strStoredProcInsertCommand_1);
            for (int i = 0; i < columnsCount_1; i++)
            {
                columnType_1 = table_1.Columns[i].DataType;
                columnName_1 = table_1.Columns[i].ColumnName;
                db.AddInParameter(insertCommand_1, columnName_1, ZAGetDbType(columnType_1), columnName_1, DataRowVersion.Current);
            }

            //��_2
            DataSet ds_2 = new DataSet();
            ds_2 = dsObject_2;
            String columnName_2;
            System.Type columnType_2;
            int columnsCount_2 = 0;
            DataTable table_2 = new DataTable();
            table_2 = ds_2.Tables[strTableName_2];
            columnsCount_2 = table_2.Columns.Count;
            DbCommand insertCommand_2 = db.GetStoredProcCommand(strStoredProcInsertCommand_2);
            for (int i = 0; i < columnsCount_2; i++)
            {
                columnType_2 = table_2.Columns[i].DataType;
                columnName_2 = table_2.Columns[i].ColumnName;
                db.AddInParameter(insertCommand_2, columnName_2, ZAGetDbType(columnType_2), columnName_2, DataRowVersion.Current);
            }

            DbCommand deleteCommand = null;
            DbCommand updateCommand = null;
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    int i1, i2;
                    i1 = db.UpdateDataSet(ds_1, strTableName_1, insertCommand_1, updateCommand,
                                                  deleteCommand, trans);
                    i2 = db.UpdateDataSet(ds_2, strTableName_2, insertCommand_2, updateCommand,
                       deleteCommand, trans);
                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = i1 + i2;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();                   
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }

      /// <summary>
        /// ���ݸ��� ������ (��������ű������¼�¼)
      /// </summary>
      /// <param name="strConn"></param>
      /// <param name="dsObject_1"></param>
      /// <param name="strTableName_1"></param>
      /// <param name="strStoredProcInsertCommand_1"></param>
      /// <param name="dsObject_2"></param>
      /// <param name="strTableName_2"></param>
      /// <param name="strStoredProcInsertCommand_2"></param>
      /// <param name="dsObject_3"></param>
      /// <param name="strTableName_3"></param>
      /// <param name="strStoredProcInsertCommand_3"></param>
      /// <returns></returns>
        public int UpdateDataSetStoredProcInsert3(string strConn, DataSet dsObject_1, string strTableName_1, string strStoredProcInsertCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcInsertCommand_2, DataSet dsObject_3, string strTableName_3, string strStoredProcInsertCommand_3)
        {
            int result = 0;
            Database db = DatabaseFactory.CreateDatabase(strConn);

            //��_1
            DataSet ds_1 = new DataSet();
            ds_1 = dsObject_1;
            String columnName_1;
            System.Type columnType_1;
            int columnsCount_1 = 0;
            DataTable table_1 = new DataTable();
            table_1 = ds_1.Tables[strTableName_1];
            columnsCount_1 = table_1.Columns.Count;
            DbCommand insertCommand_1 = db.GetStoredProcCommand(strStoredProcInsertCommand_1);
            for (int i = 0; i < columnsCount_1; i++)
            {
                columnType_1 = table_1.Columns[i].DataType;
                columnName_1 = table_1.Columns[i].ColumnName;
                db.AddInParameter(insertCommand_1, columnName_1, ZAGetDbType(columnType_1), columnName_1, DataRowVersion.Current);
            }

            //��_2
            DataSet ds_2 = new DataSet();
            ds_2 = dsObject_2;
            String columnName_2;
            System.Type columnType_2;
            int columnsCount_2 = 0;
            DataTable table_2 = new DataTable();
            table_2 = ds_2.Tables[strTableName_2];
            columnsCount_2 = table_2.Columns.Count;
            DbCommand insertCommand_2 = db.GetStoredProcCommand(strStoredProcInsertCommand_2);
            for (int i = 0; i < columnsCount_2; i++)
            {
                columnType_2 = table_2.Columns[i].DataType;
                columnName_2 = table_2.Columns[i].ColumnName;
                db.AddInParameter(insertCommand_2, columnName_2, ZAGetDbType(columnType_2), columnName_2, DataRowVersion.Current);
            }


            //��_3
            DataSet ds_3 = new DataSet();
            ds_3 = dsObject_3;
            String columnName_3;
            System.Type columnType_3;
            int columnsCount_3 = 0;
            DataTable table_3 = new DataTable();
            table_3 = ds_3.Tables[strTableName_3];
            columnsCount_3 = table_3.Columns.Count;
            DbCommand insertCommand_3 = db.GetStoredProcCommand(strStoredProcInsertCommand_3);
            for (int i = 0; i < columnsCount_3; i++)
            {
                columnType_3 = table_3.Columns[i].DataType;
                columnName_3 = table_3.Columns[i].ColumnName;
                db.AddInParameter(insertCommand_3, columnName_3, ZAGetDbType(columnType_3), columnName_3, DataRowVersion.Current);
            }

            DbCommand deleteCommand = null;
            DbCommand updateCommand = null;
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    int i1, i2, i3;
                    i1 = db.UpdateDataSet(ds_1, strTableName_1, insertCommand_1, updateCommand,
                                                  deleteCommand, trans);
                    i2 = db.UpdateDataSet(ds_2, strTableName_2, insertCommand_2, updateCommand,
                       deleteCommand, trans);
                    i3 = db.UpdateDataSet(ds_3, strTableName_3, insertCommand_3, updateCommand,
                       deleteCommand, trans);
                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = i1 + i2 + i3;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }
        /// <summary>
        /// ���ݸ��� ������ (��������ű��޸ļ�¼)
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="dsObject_1"></param>
        /// <param name="strTableName_1"></param>
        /// <param name="strStoredProcUpdateCommand_1"></param>
        /// <param name="dsObject_2"></param>
        /// <param name="strTableName_2"></param>
        /// <param name="strStoredProcUpdateCommand_2"></param>
        /// <returns></returns>
        public int UpdateDataSetStoredProcUpdate2(string strConn, DataSet dsObject_1, string strTableName_1, string strStoredProcUpdateCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcUpdateCommand_2)
        {
            int result = 0;
            Database db = DatabaseFactory.CreateDatabase(strConn);

            //��_1
            DataSet ds_1 = new DataSet();
            ds_1 = dsObject_1;
            String columnName_1;
            System.Type columnType_1;
            int columnsCount_1 = 0;
            DataTable table_1 = new DataTable();
            table_1 = ds_1.Tables[strTableName_1];
            columnsCount_1 = table_1.Columns.Count;
            DbCommand updateCommand_1 = db.GetStoredProcCommand(strStoredProcUpdateCommand_1);
            for (int i = 0; i < columnsCount_1; i++)
            {
                columnType_1 = table_1.Columns[i].DataType;
                columnName_1 = table_1.Columns[i].ColumnName;
                db.AddInParameter(updateCommand_1, columnName_1, ZAGetDbType(columnType_1), columnName_1, DataRowVersion.Current);
            }


            //��_2
            DataSet ds_2 = new DataSet();
            ds_2 = dsObject_2;
            String columnName_2;
            System.Type columnType_2;
            int columnsCount_2 = 0;
            DataTable table_2 = new DataTable();
            table_2 = ds_2.Tables[strTableName_2];
            columnsCount_2 = table_2.Columns.Count;
            DbCommand updateCommand_2 = db.GetStoredProcCommand(strStoredProcUpdateCommand_2);
            for (int i = 0; i < columnsCount_2; i++)
            {
                columnType_2 = table_2.Columns[i].DataType;
                columnName_2 = table_2.Columns[i].ColumnName;
                db.AddInParameter(updateCommand_2, columnName_2, ZAGetDbType(columnType_2), columnName_2, DataRowVersion.Current);
            }


            DbCommand deleteCommand = null;
            DbCommand insertCommand = null;
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    int i1, i2;
                    i1 = db.UpdateDataSet(ds_1, strTableName_1, insertCommand, updateCommand_1,
                                                  deleteCommand, trans);
                    i2 = db.UpdateDataSet(ds_2, strTableName_2, insertCommand, updateCommand_2,
                       deleteCommand, trans);

                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = i1 + i2;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }
        /// <summary>
        /// ���ݸ��� ������ (��������ű��޸ļ�¼)
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="dsObject_1"></param>
        /// <param name="strTableName_1"></param>
        /// <param name="strStoredProcUpdateCommand_1"></param>
        /// <param name="dsObject_2"></param>
        /// <param name="strTableName_2"></param>
        /// <param name="strStoredProcUpdateCommand_2"></param>
        /// <param name="dsObject_3"></param>
        /// <param name="strTableName_3"></param>
        /// <param name="strStoredProcUpdateCommand_3"></param>
        /// <returns></returns>
        public int UpdateDataSetStoredProcUpdate3(string strConn, DataSet dsObject_1, string strTableName_1, string strStoredProcUpdateCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcUpdateCommand_2, DataSet dsObject_3, string strTableName_3, string strStoredProcUpdateCommand_3)
        {
            int result = 0;
            Database db = DatabaseFactory.CreateDatabase(strConn);

            //��_1
            DataSet ds_1 = new DataSet();
            ds_1 = dsObject_1;
            String columnName_1;
            System.Type columnType_1;
            int columnsCount_1 = 0;
            DataTable table_1 = new DataTable();
            table_1 = ds_1.Tables[strTableName_1];
            columnsCount_1 = table_1.Columns.Count;
            DbCommand updateCommand_1 = db.GetStoredProcCommand(strStoredProcUpdateCommand_1);
            for (int i = 0; i < columnsCount_1; i++)
            {
                columnType_1 = table_1.Columns[i].DataType;
                columnName_1 = table_1.Columns[i].ColumnName;
                db.AddInParameter(updateCommand_1, columnName_1, ZAGetDbType(columnType_1), columnName_1, DataRowVersion.Current);
            }


            //��_2
            DataSet ds_2 = new DataSet();
            ds_2 = dsObject_2;
            String columnName_2;
            System.Type columnType_2;
            int columnsCount_2 = 0;
            DataTable table_2 = new DataTable();
            table_2 = ds_2.Tables[strTableName_2];
            columnsCount_2 = table_2.Columns.Count;
            DbCommand updateCommand_2 = db.GetStoredProcCommand(strStoredProcUpdateCommand_2);
            for (int i = 0; i < columnsCount_2; i++)
            {
                columnType_2 = table_2.Columns[i].DataType;
                columnName_2 = table_2.Columns[i].ColumnName;
                db.AddInParameter(updateCommand_2, columnName_2, ZAGetDbType(columnType_2), columnName_2, DataRowVersion.Current);
            }


            //��_3
            DataSet ds_3 = new DataSet();
            ds_3 = dsObject_3;
            String columnName_3;
            System.Type columnType_3;
            int columnsCount_3 = 0;
            DataTable table_3 = new DataTable();
            table_3 = ds_3.Tables[strTableName_3];
            columnsCount_3 = table_3.Columns.Count;
            DbCommand updateCommand_3 = db.GetStoredProcCommand(strStoredProcUpdateCommand_3);
            for (int i = 0; i < columnsCount_3; i++)
            {
                columnType_3 = table_3.Columns[i].DataType;
                columnName_3 = table_3.Columns[i].ColumnName;
                db.AddInParameter(updateCommand_3, columnName_3, ZAGetDbType(columnType_3), columnName_3, DataRowVersion.Current);
            }

            DbCommand deleteCommand = null;
            DbCommand insertCommand = null;
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    int i1, i2, i3;
                    i1 = db.UpdateDataSet(ds_1, strTableName_1, insertCommand, updateCommand_1,
                                                  deleteCommand, trans);
                    i2 = db.UpdateDataSet(ds_2, strTableName_2, insertCommand, updateCommand_2,
                       deleteCommand, trans);
                    i3 = db.UpdateDataSet(ds_3, strTableName_3, insertCommand, updateCommand_3,
                       deleteCommand, trans);
                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = i1 + i2 + i3;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }

        /// <summary>
        /// ������ 2sql
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="strSql1"></param>
        /// <param name="strSql2"></param>
        /// <returns></returns>
  
        public bool ExecuteNonQueryTransaction2(string strConn, string strSql1, string strSql2)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            bool result = false;           
            DbCommand dbcomm1 = db.GetSqlStringCommand(strSql1);
            DbCommand dbcomm2 = db.GetSqlStringCommand(strSql2);
            //DbCommand dbcomm1 = db.GetSqlStringCommand("update person set name='pw'");
            //DbCommand dbcomm2 = db.GetSqlStringCommand("delete from person where id=1");
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbcomm1, trans);
                    db.ExecuteNonQuery(dbcomm2, trans);
                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = true;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }
        /// <summary>
        /// ������  3sql
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="strSql1"></param>
        /// <param name="strSql2"></param>
        /// <param name="strSql3"></param>
        /// <returns></returns>
     
        public bool ExecuteNonQueryTransaction3(string strConn, string strSql1, string strSql2, string strSql3)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            bool result = false;           
            DbCommand dbcomm1 = db.GetSqlStringCommand(strSql1);
            DbCommand dbcomm2 = db.GetSqlStringCommand(strSql2);
            DbCommand dbcomm3 = db.GetSqlStringCommand(strSql3);           
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbcomm1, trans);
                    db.ExecuteNonQuery(dbcomm2, trans);
                    db.ExecuteNonQuery(dbcomm3, trans);
                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = true;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }
       /// <summary>
        /// ������ 4sql
       /// </summary>
       /// <param name="strConn"></param>
       /// <param name="strSql1"></param>
       /// <param name="strSql2"></param>
       /// <param name="strSql3"></param>
       /// <param name="strSql4"></param>
       /// <returns></returns>
    
        public bool ExecuteNonQueryTransaction4(string strConn, string strSql1, string strSql2, string strSql3, string strSql4)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            bool result = false;            
            DbCommand dbcomm1 = db.GetSqlStringCommand(strSql1);
            DbCommand dbcomm2 = db.GetSqlStringCommand(strSql2);
            DbCommand dbcomm3 = db.GetSqlStringCommand(strSql3);
            DbCommand dbcomm4 = db.GetSqlStringCommand(strSql4);            
            using (DbConnection conn = db.CreateConnection())
            {
                //������
                conn.Open();
                //��������
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbcomm1, trans);
                    db.ExecuteNonQuery(dbcomm2, trans);
                    db.ExecuteNonQuery(dbcomm3, trans);
                    db.ExecuteNonQuery(dbcomm4, trans);
                    //��ִ�гɹ����ύ����
                    trans.Commit();
                    result = true;
                }
                catch (Exception)
                {
                    //�����쳣������ع�
                    trans.Rollback();
                }
                //�ر�����
                conn.Close();
                return result;
            }
        }
        /// <summary>
        /// ����SQLȡ�� IDataReader ��ΪExecuteReader������һ��ʼִ��ʱ�ʹ���һ�������ݿ�����ӣ��������Ǳ���ע����ʹ�ý���ʱ�ر�����
        /// </summary>
        /// <param name="strSql">SQL���</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string strConn, string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            IDataReader dr = null;
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            dr = db.ExecuteReader(dbCommand);            
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                dr = dataReader;
            }
            return dr;
        }
        /// <summary>
        /// ����SQLȡ�� IDataReader ��ΪExecuteReader������һ��ʼִ��ʱ�ʹ���һ�������ݿ�����ӣ��������Ǳ���ע����ʹ�ý���ʱ�ر�����
        /// </summary>
        /// <param name="strStoredProc">���</param>
        /// <returns></returns>
        public IDataReader ExecuteReaderByStoredProc(string strConn, string strStoredProc)
        {
            Database db = DatabaseFactory.CreateDatabase(strConn);
            IDataReader dr = null;
            DbCommand dbCommand = db.GetStoredProcCommand(strStoredProc);
            dr = db.ExecuteReader(dbCommand);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                dr = dataReader;
            }
            return dr;
        }
    }
}
