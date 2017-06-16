using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using BLL;

namespace hospital.Follow
{
    public partial class FollowRecordManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;

        string condition = " 1=1 order by ID desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                follow_recoed_list(); 
            }
        }
        public string get_table(string table_name_iden)
        {
            DataSet ds = new DataSet();
            bll_follow follow = new bll_follow();
            ds = follow.get_table_byname(table_name_iden);
            string return_str="";
            if (ds.Tables[0].Rows.Count > 0)
            {
                return_str= ds.Tables[0].Rows[0]["follow_name"].ToString();
            }
            return return_str;
        }
        public int get_table_id(string table_name_iden)
        {
            DataSet ds = new DataSet();
            bll_follow follow = new bll_follow();
            ds = follow.get_table_byname(table_name_iden);
            int table_id=0 ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                table_id = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            return table_id;
        }
        public void follow_recoed_list()
        {
            string tables_str = "";
            bll_follow follow = new bll_follow();
            DataSet ds_tables = follow.get_tables();
            if (ds_tables.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds_tables.Tables[0].Rows.Count; i++)
                {
                    tables_str += ds_tables.Tables[0].Rows[i]["Name"].ToString() + ",";
                }
            }
            tables_str = tables_str.TrimEnd(',');
            string[] tables = tables_str.Split(new char[1] { ',' });
            DataTable dt = new DataTable();
            foreach (string table in tables)
            {
                int index = table.IndexOf("Follow_");
                if (index > -1)
                {
                    DataTable dt_temp = new DataTable();
                    dt_temp = sqlcmd.TriJoinPageIndexdt(table, "DoctorInfo", "PatientInfo", "m.ID,m.record_title,m.follow_time,m.table_name_iden,m.p_id,m.d_id,a.doctor_name,b.user_name", "a.ID=m.d_id","b.ID=m.p_id");
                    dt.Merge(dt_temp);
                }
            }
            DataSet ds = new DataSet();
            ds.Merge(dt.Copy());
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, FollowRecordRepeter, pagesize);
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FollowRecordRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)FollowRecordRepeter.Items[i].FindControl("FollowCheck");
                if (cb.Checked)
                {
                    Label lb_id = (Label)FollowRecordRepeter.Items[i].FindControl("ID");
                    Label table_id = (Label)FollowRecordRepeter.Items[i].FindControl("table_name_iden");

                    sqlcmd.CommonDeleteColumns(table_id.Text.ToString(), " where ID= " + lb_id.Text);


                }
            }
            follow_recoed_list();
        }
    }
}