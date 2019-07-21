using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Silt.Base.Common;
//using Silt.Server.RemoteObj;
namespace Silt.Client.Rules
{
    /// <summary>
    /// ZASuite ���ݿ�浽����
    /// ������
    /// 2007.2
    /// </summary>   
    public class ZASuiteDAORules
    {
        
        Silt.Base.Common.DAO zadao = new DAO();       
        //public DAOServer zadao = new DAOServer();

        private string _ZAStrConn;
        /// <summary>
        /// ���ݿ������ִ�
        /// </summary>
        public string ZAStrConn
        {
            set { _ZAStrConn = value; }
            get { return _ZAStrConn; }
        }

        public ZASuiteDAORules()
        {
           // zadao = (DAOServer)Activator.GetObject(typeof(DAOServer), System.Configuration.ConfigurationSettings.AppSettings["ServerUri"]);
        }
        /*
        /// <summary>
        /// ���ݿ⹹�� ����
        /// </summary>       
        public Database DatabaseCreate()
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database ds = zadao.DatabaseCreate(ZAStrConn);
            //Database ds = zadao.DatabaseCreate(ZAStrConn);
            return ds;
        }*/
        /// <summary>
        /// ���ݼ�װ�� ����SQL
        /// </summary>
        /// <param name="strSql">SQL</param>
        /// <param name="strLoadTableName">װ�ر���</param>
        /// <returns></returns>        

        public DataSet DataSetLoadBySql(string strSql, string strLoadTableName)
        {
            return zadao.LoadDataSet(ZAStrConn,strSql, strLoadTableName);
        }
        /// <summary>
        /// ���ݼ�ִ�� ����SQL
        /// </summary>
        /// <param name="strSql">SQL</param>
        /// <param name="strLoadTableName">װ�ر���</param>
        /// <returns></returns>        

        public DataSet DataSetExecuteBySql(string strSql)
        {
            return zadao.ExecuteDataSet(ZAStrConn, strSql);
        }

        /// <summary>
        /// װ�����ݼ� ���ݴ��
        /// </summary>
        /// <param name="strStoredProcName">�����</param>
        /// <param name="strLoadTableName">װ�ر���</param>
        /// <param name="strInParameter">��������ֵ</param>
        /// <returns></returns>        

        public DataSet DataSetLoadByStoredProc(string strStoredProcName, string strLoadTableName,
            string strInParameterName, string strInParameterValue)
        {
            return zadao.LoadDataSetByStoredProc(ZAStrConn, strStoredProcName, strLoadTableName, strInParameterName, strInParameterValue);

        }
        /// <summary>
        /// ִ�����ݼ� ���ݴ��
        /// </summary>
        /// <param name="strStoredProcName">�����</param>
        /// <returns></returns>        

        public DataSet DataSetExecuteByStoredProc(string strStoredProcName)
        {
            return zadao.ExecuteDataSetByStoredProc(ZAStrConn, strStoredProcName);
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

        public DataSet DataSetLoadPagingReadWrite(string tblName, string fldName, Int32 PageSize, Int32 PageIndex, Int32 IsReCount, Int32 OrderType, string strWhere, string strLoadTableName)
        {
            return zadao.LoadDataSetPaging(ZAStrConn, tblName, fldName, PageSize, PageIndex, IsReCount, OrderType, strWhere, strLoadTableName);
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

        public DataSet DataSetLoadPagingRead(string tblName, string fldName, Int32 PageSize, Int32 PageIndex, Int32 IsReCount, Int32 OrderType, string strWhere)
        {
            return zadao.ExecuteDataSetPaging(ZAStrConn, tblName, fldName, PageSize, PageIndex, IsReCount, OrderType, strWhere);
        }

        /// <summary>
        /// ͨ���洢������������ɾ�������ݼ�
        /// </summary>
        /// <param name="strKey">�����ֶ���</param>
        /// <param name="strStoredProcInsertCommand">�����洢������</param>
        /// <param name="strStoredProcDeleteCommand">ɾ���洢������</param>
        /// <param name="strStoredProcupdateCommand">�޸Ĵ洢������</param>
        /// <returns></returns>        

        public int DataSetUpdate
            (DataSet dsObject, string strTableName, string strKey, string strStoredProcInsertCommand, string strStoredProcDeleteCommand, string strStoredProcupdateCommand)
        {
            return zadao.UpdateDataSet(ZAStrConn, dsObject, strTableName, strKey, strStoredProcInsertCommand, strStoredProcDeleteCommand, strStoredProcupdateCommand,0);

        }
        /// <summary>
        /// ִ��ExecuteNonQuery
        /// �÷������ص���SQL���ִ��Ӱ������������ǿ������ø÷�����ִ��һЩû�з���ֵ�Ĳ���(Insert,Update,Delete)
        /// </summary>
        /// <param name="strSql">һ���SQL���</param>        

        public int ExecuteNonQuery(string strSql)
        {
            return zadao.ExecuteNonQuery(ZAStrConn, strSql);
        }
        /// <summary>
        /// ͨ���洢�������� ���ݼ�
        /// </summary>
        /// <param name="strConn">�����ִ�</param>
        /// <param name="dsObject">���ݼ�</param>
        /// <param name="strTableName">���ݱ�</param>
        /// <param name="strStoredProcInsertCommand">��������</param>
        /// <returns></returns>        
       // public int DataSetRowsInsert
           // (DataSet dsObject, string strTableName, string strStoredProcInsertCommand)
        //{
            //return zadao.DataSetRowsInsert(ZAStrConn, dsObject, strTableName, strStoredProcInsertCommand);
        //}
        /// <summary>
        /// ִ��ExecuteNonQuery
        /// �÷������ص���SQL���ִ��Ӱ������������ǿ������ø÷�����ִ��һЩû�з���ֵ�Ĳ���(Insert,Update,Delete)
        /// </summary>
        /// <param name="dbcomm">�������</param>     
       // public int ExecuteNonQueryByStoredProc(string strStoredProc)
       // {
            //return zadao.ExecuteNonQueryByStoredProc(ZAStrConn, strStoredProc);
       // }
        /// <summary>
        /// ִ��ExecuteScalar���ص�ֵ
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>        

        public string ExecuteScalarGetString(string strSql)
        {
            object obj = zadao.ExecuteScalar(ZAStrConn, strSql);

            return (string)obj;
        }

        /// <summary>
        /// ִ��ExecuteScalar���ص�ֵ ��ֵ
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>        

        public Double ExecuteScalarGetDouble(string strSql)
        {                       
            object obj = zadao.ExecuteScalar(ZAStrConn, strSql);
            return Convert.ToDouble(obj);
        }
        /// <summary>
        /// ִ��ExecuteScalar���ص�ֵ ����ֵ
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>        

        public Int32 ExecuteScalarGetInt32(string strSql)
        {
            object obj = zadao.ExecuteScalar(ZAStrConn, strSql);
            return Convert.ToInt32(obj);
            
        }
        /// <summary>
        /// ִ��ExecuteScalar���ص�ֵ ����ʱ�� ����SQL
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>        

        public DateTime ExecuteScalarGetDateTime(string strSql)
        { 
            object obj = zadao.ExecuteScalar(ZAStrConn, strSql);
            return (DateTime)obj;           
        }
        /// <summary>
        /// ִ��ExecuteScalar���ص�ֵ ����ʱ�� ���ݴ��
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>        

        public DateTime ExecuteScalarGetDateTimeByStoredProc(string strStoredProc)
        {
            object obj = zadao.ExecuteScalarByStoredProc(ZAStrConn, strStoredProc);
            return (DateTime)obj;
          
        }
        /// <summary>
        ///  ������ 2sql
        /// </summary>
        /// <param name="strSql1">sql1</param>
        /// <param name="strSql2">sql2</param>
        /// <returns></returns>     

        public bool ExecuteTransaction2(string strSql1, string strSql2)
        {
            return zadao.ExecuteNonQueryTransaction2(ZAStrConn, strSql1, strSql2);
        }
        /// <summary>
        ///  ������  3sql
        /// </summary>
        /// <param name="strSql1">sql1</param>
        /// <param name="strSql2">sql2</param>
        ///  <param name="strSql3">strSql3</param>
        /// <returns></returns>      

        public bool ExecuteTransaction3(string strSql1, string strSql2, string strSql3)
        {
            return zadao.ExecuteNonQueryTransaction3(ZAStrConn, strSql1, strSql2, strSql3);
        }
        /// <summary>
        ///  ������ 4sql
        /// </summary>
        /// <param name="strSql1">sql1</param>
        /// <param name="strSql2">sql2</param>
        ///  <param name="strSql3">strSql3</param>
        /// <param name="strSql4">strSql4</param>
        /// <returns></returns>     

        public bool ExecuteTransaction4(string strSql1, string strSql2, string strSql3, string strSql4)
        {
            return zadao.ExecuteNonQueryTransaction4(ZAStrConn, strSql1, strSql2, strSql3, strSql4);

        }
        //-----------------------------------------�¼�
        /// <summary>
        /// ȡ�õ�ǰ����������ʱ�� Sql Server��Oracle
        /// </summary>       
        /// <returns></returns>
        public string ZAGetCurrentServerDateTim()
        {
            string strServerDateTime = strServerDateTime = ExecuteScalarGetDateTime("SELECT ServerDateTime FROM v_sys_ServerDateTime").ToString();
            
            return strServerDateTime;
            /*
            int intSysDataBase = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SysDataBaseType"]);
            
            if (intSysDataBase == 0)
            {
            
                strServerDateTime = this.ExecuteScalarGetDateTimeByStoredProc("sys_ServerDateTime").ToString();
            }
            else if (intSysDataBase == 1)
            {
                strServerDateTime = this.ExecuteScalarGetDateTime("select sysdate from dual").ToString();
            }
             * */

        }
        public string JPOrderID()
        {
            string strServerDateTime =ExecuteScalarGetDateTime("SELECT ServerDateTime FROM v_sys_ServerDateTime").ToString();
            string txtJPorderID = strServerDateTime.Replace("-", "").Replace(" ", "").Replace(":", "");
            return txtJPorderID;
           

        }
        /// <summary>
        /// ȡ�÷�������ǰ��ʼ����
        /// </summary>
        /// <returns></returns>
        public DateTime ZAGetCurrentServerStartData()
        {
            string DateTemp = string.Empty;
            System.DateTime date = Convert.ToDateTime(ZAGetCurrentServerDateTim());
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day) + " 00:00:00";
            return Convert.ToDateTime(DateTemp);

        }
        /// <summary>
        /// ȡ�õ�ǰ��������
        /// </summary>
        /// <returns></returns>
        public DateTime ZAGetCurrentServerEndData()
        {
            return Convert.ToDateTime(ZAGetCurrentServerDateTim());
        }

        /// <summary>
        /// ȡ����������
        /// </summary>
        /// <returns></returns>
        public string ZAGetHostName()
        {
            Silt.Base.Common.Net net = new Silt.Base.Common.Net();
            string strHostName = "";
            strHostName = net.GetHostName();
            return strHostName;
        }

        /// <summary>
        /// ȡ������IP
        /// </summary>
        /// <returns></returns>
        public string ZAGetHostIpAddress()
        {
            Silt.Base.Common.Net net = new Silt.Base.Common.Net();
            string strHostIpAddress = net.GetHostIpAddress();            
            return strHostIpAddress;
        }

        /// <summary>
        /// �������ݱ� һ�� 
        /// </summary>
        /// <param name="dt">��</param>
        /// <param name="strKey">����ID</param>
        /// <param name="strKeyValue">����IDֵ</param>
        public void ZAAddRow(DataTable dt, string strKey, string strKeyValue)
        {
            DataRow dr = null;
            dr = dt.NewRow();
            dr[strKey] = strKeyValue;
            dt.Rows.Add(dr);
        }
        /// <summary>
        /// ɾ�����ݱ� ��
        /// </summary>
        /// <param name="table">��</param>
        /// <param name="strKey">����ID</param>
        /// <param name="strKeyValue">����IDֵ</param>
        public void ZADelRows(DataTable table, string strKey, string strKeyValue)
        {
            DataRow[] pdrs = table.Select(strKey + "='" + strKeyValue + "'");
            if (pdrs != null)
            {
                foreach (DataRow dr in pdrs)
                {
                    dr.Delete();
                }
            }

        }
        /// <summary>
        /// �ж�ָ���д��ڷ�
        /// </summary>
        /// <param name="table">��</param>
        /// <param name="strKey">����ID</param>
        /// <param name="strKeyValue">����IDֵ</param>
        public bool ZARowsOK(DataTable table, string strKey, string strKeyValue)
        {
            bool b=false;
            DataRow[] pdrs = table.Select(strKey + "='" + strKeyValue + "'");
            if (pdrs != null)
            {
                foreach (DataRow dr in pdrs)
                {
                    b = true;
                }
            }
            return b;

        }
        /// <summary>
        /// ȡ��32λGUID
        /// </summary>
        /// <returns></returns>
        public string ZAGetGuid()
        {
            string strGuid = "";
            //string strGuid = System.Guid.NewGuid().ToString().ToUpper();
            strGuid = System.Guid.NewGuid().ToString();
            return strGuid.Replace("-", "");
        }
        /// <summary>
        /// �������кŶ���Id��ȡ��ǰ��
        /// </summary>
        /// <param name="strid">ȡ��ǰ������ֵ</param>
        /// <returns></returns>
        public string ZAGetCurrentNO(string strid)
        {
            int intCurrentno;
            String sql;
            string ls_id, ls_tail;
            string za_sysyear, za_sysmonth, za_sysday, za_Prehead;
            int za_currentno, za_Length;//��ǰ��
            string ls_sysyear = "", ls_sysmonth = "", ls_sysday = "";
            DateTime ldt_systime;
            sql = "SELECT * FROM sys_serialNumber WHERE id='" + strid + "'";
            DataSet ds = this.zadao.LoadDataSet(ZAStrConn, sql, "sys_serialNumber");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                za_sysyear = dt.Rows[0]["YearBegin"].ToString();
                za_sysmonth = dt.Rows[0]["MonthBegin"].ToString();
                za_sysday = dt.Rows[0]["DayBegin"].ToString();
                za_currentno = Convert.ToInt32(dt.Rows[0]["currentno"].ToString());
                za_Prehead = dt.Rows[0]["prehead"].ToString();
                za_Length = Convert.ToInt32(dt.Rows[0]["length"].ToString());
                if ((za_sysyear == null || za_sysyear.Length == 0) & (za_sysmonth == null || za_sysmonth.Length == 0) & (za_sysday == null || za_sysday.Length == 0))
                {
                    intCurrentno = za_currentno + 1;
                    this.zadao.ExecuteNonQuery(ZAStrConn, "Update sys_serialNumber Set currentno=" + intCurrentno + " where id='" + strid + "'");
                }
                else
                {
                    ldt_systime = Convert.ToDateTime(ZAGetCurrentServerDateTim());
                    ls_sysyear = ldt_systime.ToString("yyyy");
                    ls_sysmonth = ldt_systime.ToString("MM");
                    ls_sysday = ldt_systime.ToString("dd");
                    if ((za_sysyear != ls_sysyear) || (za_sysmonth != ls_sysmonth) || (za_sysday != ls_sysday))
                    {
                        intCurrentno = 1;
                        this.zadao.ExecuteNonQuery(ZAStrConn, "Update sys_serialNumber Set currentno=" + intCurrentno + ",yearbegin='" + ls_sysyear + "',monthbegin='" + ls_sysmonth + "',daybegin='" + ls_sysday + "' where id='" + strid + "'");
                    }
                    else
                    {
                        ls_sysyear = za_sysyear;
                        ls_sysmonth = za_sysmonth;
                        ls_sysday = za_sysday;
                        intCurrentno = za_currentno + 1;
                        this.zadao.ExecuteNonQuery(ZAStrConn, "Update sys_serialNumber Set currentno=" + intCurrentno + " where id='" + strid + "'");
                    }

                }

                if (za_Prehead == null)
                {
                    za_Prehead = "";
                }
                ls_tail = za_currentno.ToString();
                if (ls_tail.Length <= za_Length)
                {
                    ls_tail = ls_sysyear + ls_sysmonth + ls_sysday + ls_tail.PadLeft(za_Length, '0');
                }
                if (strid == null || strid.Length == 0)
                {
                    ls_id = "0";
                }
                else
                {
                    ls_id = za_Prehead.Trim() + ls_tail;
                }
            }
            else
            {
                ls_id = "0";
            }
            return ls_id;
        }
        //-----------------------------------------�¼�
        /// <summary>
        /// ���ݸ��� ������ (��������ű������¼�¼)
        /// </summary>
        /// <param name="dsObject_1">���ݼ�_1</param>
        /// <param name="strTableName_1">��_1</param>
        /// <param name="strStoredProcInsertCommand_1">��1���</param>
        /// <param name="dsObject_2"></param>
        /// <param name="strTableName_2"></param>
        /// <param name="strStoredProcInsertCommand_2"></param>
        /// <returns></returns>        
        public int DataSetUpdateStoredProcInsert2(DataSet dsObject_1, string strTableName_1, string strStoredProcInsertCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcInsertCommand_2)
        {
            return zadao.UpdateDataSetStoredProcInsert2(ZAStrConn, dsObject_1, strTableName_1, strStoredProcInsertCommand_1, dsObject_2, strTableName_2, strStoredProcInsertCommand_2);
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
        public int DataSetUpdateStoredProcInsert3(DataSet dsObject_1, string strTableName_1, string strStoredProcInsertCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcInsertCommand_2, DataSet dsObject_3, string strTableName_3, string strStoredProcInsertCommand_3)
        {
            return zadao.UpdateDataSetStoredProcInsert3(ZAStrConn, dsObject_1, strTableName_1, strStoredProcInsertCommand_1, dsObject_2, strTableName_2, strStoredProcInsertCommand_2, dsObject_3, strTableName_3, strStoredProcInsertCommand_3);
        }

        //
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
        public int DataSetUpdateStoredProcUpdate2(DataSet dsObject_1, string strTableName_1, string strStoredProcUpdateCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcUpdateCommand_2)
        {
            return zadao.UpdateDataSetStoredProcUpdate2(ZAStrConn, dsObject_1, strTableName_1, strStoredProcUpdateCommand_1, dsObject_2, strTableName_2, strStoredProcUpdateCommand_2);
        }

        /// <summary>
        ///  ���ݸ��� ������ (��������ű��޸ļ�¼)
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
        public int DataSetUpdateStoredProcUpdate3(DataSet dsObject_1, string strTableName_1, string strStoredProcUpdateCommand_1, DataSet dsObject_2, string strTableName_2, string strStoredProcUpdateCommand_2, DataSet dsObject_3, string strTableName_3, string strStoredProcUpdateCommand_3)
        {
            return zadao.UpdateDataSetStoredProcUpdate3(ZAStrConn, dsObject_1, strTableName_1, strStoredProcUpdateCommand_1, dsObject_2, strTableName_2, strStoredProcUpdateCommand_2, dsObject_3, strTableName_3, strStoredProcUpdateCommand_3);
        }

        /// <summary>
        /// ȡ����ƴ������ĸ
        /// </summary>
        /// <param name="strChinese"></param>       
        /// <returns></returns>
        public string ZAMakeSpellCode(string strChinese)
        {
            Silt.Base.Common.Spell sp = new Silt.Base.Common.Spell();
            //Silt.Base.Common.Spell.MakeSpellCode()
            return sp.MakeSpellCodeFirstLetterOnly(strChinese);     
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists( string sql)
        {
            return zadao.RecordExists(ZAStrConn, sql);        
        }
        /// <summary>
        /// ���ݹ���IDȡ������
        /// </summary>
        /// <param name="strFuncID">����ID</param>
        /// <returns></returns>
        public string ZAGetFuncNameByFuncID(string strFuncID)
        {
            string sql = "SELECT fname FROM sys_func WHERE (ffunc_id = '" + strFuncID + "')";
            return this.ExecuteScalarGetString(sql);
        }
        
        //
    }
}