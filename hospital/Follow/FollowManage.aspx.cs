using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;
using Newtonsoft.Json.Linq;


namespace hospital.Follow
{
    public partial class FollowManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;

        string condition = " 1=1 order by ID desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                follow_list();
            }
        }
        protected void follow_list()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("FollowManage", "*", condition);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, FollowRepeter, pagesize);
        }
        public string get_filed(string json_str)
        {
            
            model_control model = new model_control();
            json_str = json_str.Replace("[", "").Replace("]","").Replace("},{", "}*{");
            string[] str_ = json_str.Split(new char [1]{'*'});
            string return_str = "";
            foreach (string data in str_)
            {

                model = JsonHelper.ParseFormJson<model_control>(data);
                return_str += model.control_name+",";
            }
            
            return return_str.TrimEnd(',');
        }
        public string get_encode(string str_)
        {
            string str_temp = HttpContext.Current.Server.UrlEncode(str_);
            return str_temp;
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FollowRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)FollowRepeter.Items[i].FindControl("FollowCheck");
                if (cb.Checked)
                {
                    Label lb_id = (Label)FollowRepeter.Items[i].FindControl("ID");
                    Label lb_table = (Label)FollowRepeter.Items[i].FindControl("table_name");

                    sqlcmd.CommonDeleteColumns("FollowManage", " where ID= " + lb_id.Text);
                    sqlcmd.DropTable("Follow_"+lb_table.Text);


                }
            }
            follow_list();
        }
        
    }
}