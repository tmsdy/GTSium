using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class OrgFuncRules : ZASuiteDAORulesSys
    {
        //ZAWebServices.ZAWebServices zaws = new ZAWebServices.ZAWebServices();
        DataSet ds = new DataSet();
        string sql = "";       
        private DataSet m_dsObjectOrgFunc = null;
        /// <summary>
        /// ���ݼ�����
        /// </summary>
        public DataSet dsObjectOrgFunc
        {
            get
            {
                return this.m_dsObjectOrgFunc;
            }
            set
            {
                this.m_dsObjectOrgFunc = value;
            }
        }
         
        public OrgFuncRules()
        {
            
            // 
            // TODO: �ڴ˴���ӹ��캯���߼�
            //	
        }

        /// <summary>
        /// ȡ��ֻ�� ��֯���ݼ��б�
        /// </summary>    
        /// <returns></returns>
        public DataSet ZAGetOrgDataSetRead()
        {         
            
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE (fstatus = 1)");
           
        }
        /// <summary>
        /// ȡ��ֻ�� ��֯���ݼ��б� �����ϼ�ID
        /// </summary>
        /// <param name="fparent_id"></param>
        /// <returns></returns>
        public DataSet ZAGetOrgListByFparent_id(string fparent_id)
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE fparent_id='" + fparent_id + "'");

        }
        public string ZAGetOrgChildOrgID(string fparent_id)
        {
            return this.ExecuteScalarGetString(" SELECT TOP 1 forg_id FROM sys_org WHERE (fparent_id = '" + fparent_id + "')");
        } 
       //
       /// <summary>
        /// �����ϼ�����IDȡ��ֻ�� ��֯���ݼ��б�
       /// </summary>
       /// <param name="strDeptId"></param>
       /// <returns></returns>
        public DataSet ZAGetOrgDataSetRead(string strDeptId)
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE (fstatus = 1) AND (ftype = 'Position') AND (fparent_id = '" + strDeptId + "')");
        } 
        /// <summary>
        /// �����ϼ���λIDȡ��ֻ�� ��֯���ݼ��б�
        /// </summary>
        /// <param name="strPositionId"></param>
        /// <returns></returns>
        public DataSet ZAGetOrgDataSetReadByPositionId(string strPositionId)
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE (fstatus = 1) AND (ftype = 'Person') AND (fparent_id = '" + strPositionId + "')");
        }
        /// <summary>
        /// ������֯����ȡ�����
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string ZAGetOrgType(string strId)
        {
            return this.ExecuteScalarGetString("SELECT ftype FROM sys_org WHERE (forg_id = '" + strId + "')");
        }

        /// <summary>
        /// ������֯����ȡ�ø�λ
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string ZAGetOrgfposition_id(string strId)
        {
            return this.ExecuteScalarGetString("SELECT fposition_id FROM sys_org WHERE (forg_id = '" + strId + "')");
        }  
        /// <summary>
        /// ������֯����ȡ�ò���
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string ZAGetOrgfdept_id(string strId)
        {
            return this.ExecuteScalarGetString("SELECT fdept_id FROM sys_org WHERE (forg_id = '" + strId + "')");
        }

        /// <summary>
        /// �ж�ͬ�����¸�λ�Ƿ����
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool ZAOrgPositionOK(string strfparent_id, string strfposition_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_id FROM sys_org WHERE (fparent_id = '" + @strfparent_id + "') AND (ftype = 'Position') AND (fposition_id = '" + @strfposition_id + "')");
            if (strforid == "" || strforid == null)
            {              
            }
            else
            {
                ok = true;
            }
            return ok;
        }


        /// <summary>
        /// �ж�ͬ��λ����Ա�Ƿ����
        /// </summary>       
        /// <returns></returns>
        public bool ZAOrgPersonOK(string strfparent_id, string strperson_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_id FROM sys_org WHERE (fparent_id = '" + @strfparent_id + "') AND (ftype = 'Person') AND (fperson_id = '" + strperson_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// �жϸ�λ�Ƿ���� �¼���Ա
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool ZAOrgPositionPersonOK(string strfposition_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_id FROM sys_org WHERE (fparent_id = '" + strfposition_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
        }


        //SELECT forg_id FROM sys_org WHERE (fparent_id = '\ROOT\KMSETYY.OGN\JYK.dpt') AND (ftype = 'Position') AND (fposition_id = 'CYJS')


        /// <summary>
        /// ������֯IDȡ�ù����б�
        /// </summary>
        /// <param name="StrOrgId">��֯ID</param>
        /// <returns></returns>
        public int GetOrgFuncInfoCountByOrgId(string StrOrgId)
        {           
            int i = 0;           
            ds = null;
            sql = "";
            sql = "SELECT * FROM sys_org_func where forg_id='" + StrOrgId + "'";
            ds = this.DataSetExecuteBySql(sql);
            i = ds.Tables[0].Rows.Count;            
            if (i > 0)
            {
                this.m_dsObjectOrgFunc = ds;
            }
            return i;
        }
        /// <summary>
        /// ������֯IDȡ�ù����б� ���õ�
        /// </summary>
        /// <param name="StrOrgId">��֯ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgID(string strforg_id,string strParent)
        {           
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id";
            //sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);         
            return ds;
        }
        /// <summary>
        /// ������֯IDȡ�ù����б� ���õ�
        /// </summary>
        /// <param name="StrOrgId">��֯ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgID(string strforg_id)
        {
            ds = null;
            //sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id";
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
           // this.Exists();
        }
        
        /// <summary>
        /// �Ƿ�����¼�����
        /// </summary>
        /// <param name="strfparent_id"></param>
        /// <param name="strforg_id"></param>
        /// <returns></returns>
        public bool ChildFuncExists(string strfparent_id, string strforg_id)
        {
            ds = null;
            sql = "SELECT count(1) FROM v_sys_org_func where fparent_id='" + strfparent_id + "' and forg_id='" + strforg_id + "' and fstatus=1";
            return this.Exists(sql);
        }
        /// <summary>
        /// ȡ���ӹ����б�
        /// </summary>
        /// <param name="strfparent_id"></param>
        /// <param name="strforg_id"></param>
        /// <returns></returns>
        public DataSet GetChildFuncList(string strfparent_id, string strforg_id)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where fparent_id='" + strfparent_id + "' and forg_id='" + strforg_id + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// ������֯IDȡ�ù����б� ���õ�  ֻ�����ݼ�
        /// </summary> 
        /// <param name="StrOrgId">��֯ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgIDRead(string strforg_id, string strParent)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// ������֯IDȡ�ù����б� ���õ�  ֻ�����ݼ�
        /// </summary> 
        /// <param name="StrOrgId">��֯ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgIDReadDesc(string strforg_id, string strParent)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id Desc";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// ������֯IDȡ�ù����б� ����
        /// </summary>
        /// <param name="StrOrgId">��֯ID</param>
        /// <returns></returns>
        public DataSet GetAllOrgFuncDSByforgID(string strforg_id, string strParent)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' order by fsort_id";
            ds = this.DataSetLoadBySql(sql, "v_sys_org_func");
            return ds;
        }


        /// <summary>
        /// �жϴ˹����Ƿ���� �¼�����
        /// </summary>
        /// <param name="strffunc_id">����ID</param>
        /// <param name="strforg_id">��֯ID</param>
        /// <returns></returns>
        public bool GetAllOrgChildFuncOK(string strffunc_id, string strforg_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT ffunc_id FROM v_sys_org_func WHERE (fparent_id = '" + strffunc_id + "')and (forg_id = '" + strforg_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
            
        }

        /// <summary>
        /// �жϴ˹����Ƿ����
        /// </summary>
        /// <param name="strffunc_id">����ID</param>
        ///  <param name="strforg_id">��֯ID</param>
        /// <returns></returns>
        public bool GetAllOrgFuncOK(string strffunc_id, string strforg_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_func_id FROM sys_org_func WHERE (ffunc_id = '" + strffunc_id + "') and (forg_id = '" + strforg_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
        }
        /*
        /// <summary>
        /// ���ݹ��ܣɣ�ȡ��ҳ��򿪷�ʽ
        /// </summary>
        /// <param name="strffunc_id">��������ID</param>
        /// <returns></returns>
        public string ZAGetFwinformOpenTypeByID(string strffunc_id)
        {
            string sql = "SELECT fopen_page FROM sys_func WHERE (ffunc_id = '" + strffunc_id + "')";
            return this.ExecuteScalarGetString(sql);
        }
        */
        public DataSet ZAFuncListByFuncID(string strffunc_id)
        {
            ds = null;
            string sql = "SELECT * FROM sys_func WHERE (ffunc_id = '" + strffunc_id + "')";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        //---------------��֯�����ܡ����ԣ����ݷ�Χ��
        /// <summary>
        /// ���ݹ���ID���ϼ�IDȡ�ù����������ݼ�,�ɶ�д
        /// </summary>        
        /// <param name="Forg_id">��֯ID</param>
        /// <param name="FFunc_id">����ID</param>
        /// <returns></returns>
        public DataSet OrgFuncPropertyLoadDS(string Forg_id, string FFunc_id)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_org_func_property Where Forg_id='" + Forg_id + "' and FFunc_id='" + FFunc_id + "' Order by FIndex";
            ds = this.DataSetLoadBySql(sql, "sys_org_func_property");
            return ds;
        }

        /// <summary>
        /// ���ݹ���ID���ϼ�IDȡ�ù����������ݼ�,�ɶ�
        /// </summary>        
        /// <param name="Forg_id">��֯ID</param>
        /// <param name="FFunc_id">����ID</param>
        /// <returns></returns>
        public DataSet OrgFuncPropertyExcuteDS(string Forg_id, string FFunc_id)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_org_func_property Where Forg_id='" + Forg_id + "' and FFunc_id='" + FFunc_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
       

        /// <summary>
        /// ͨ���洢���� ��������ɾ�������ݼ�
        /// </summary>
        /// <returns></returns>
        public int OrgFuncPropertyUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_org_func_property_ADD";//���_���� 
            string strStoredProcDelete = "sys_org_func_property_Delete";//���_ɾ�� 
            string strStoredProcUpdate = "sys_org_func_property_Update";//���_�޸�         
            string strStrKey = "FProperty_ID";//������      
            string strStrTableName = "sys_org_func_property";//����          
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        /// <summary>
        /// ������֯IDȡ����֯���ݼ���ֻ��
        /// </summary>
        /// <param name="strForg_id">��֯ID</param>
        /// <returns></returns>
        public DataSet GetOrgDSByOrgId(string strForg_id)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM v_sys_org where forg_id='" + strForg_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        //---------------��֯�����ܡ����ԣ����ݷ�Χ��
    }
}
