using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Silt.Client.Rules
{

    /// <summary>
    /// Lis��Ŀ ����
    /// </summary>
    public class ExcelImp : ZASuiteDAORulesSys
    {
        public ExcelImp()
        {
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }

        /// <summary>
        /// ȡ�ñ�lTabel�����ֶ��б�
        /// </summary>    
        /// <returns></returns>
        public DataSet ZAGetFieldAllLis(string lType)
        {
            string sql;
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_excel WHERE FType = '" + lType + "'" + "  ORDER BY FORDER_NUM";
            ds = this.DataSetLoadBySql(sql, "sys_excel");
            return ds;
        }

        /// <summary>
        /// ִ��ExecuteNonQuery
        /// �÷������ص���SQL���ִ��Ӱ������������ǿ������ø÷�����ִ��һЩû�з���ֵ�Ĳ���(Insert,Update,Delete)
        /// </summary>
        /// <param name="strSql">һ���SQL���</param>
        public int ExecuteNonQuery(string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbcomm = db.GetSqlStringCommand("insert into person values(1,'shy','Ů','123456')");
            DbCommand dbcomm = db.GetSqlStringCommand(strSql);
            return db.ExecuteNonQuery(dbcomm);
        }
        /// <summary>
        /// ȡ��32λGUID
        /// </summary>
        /// <returns></returns>
        public string  ZAGetGuid()
        {
            string strGuid = "";
            //string strGuid = System.Guid.NewGuid().ToString().ToUpper();
            strGuid = System.Guid.NewGuid().ToString();
            return strGuid.Replace("-", "");
        }

        
    }
}
