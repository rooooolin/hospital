using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;

namespace hospital.Users
{
    public partial class UserList : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;
        
        string condition = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user_roleid"] != null)
            {
                if (Request.QueryString["user_roleid"].ToString() == "2")
                { condition = " user_roleid=2 order by ID desc"; }
                if (Request.QueryString["user_roleid"].ToString() == "3")
                { condition = " user_roleid=3 order by ID desc"; }
                user_list();
            }
           
        }
        
        protected void user_list()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("UserInfo", "*", condition);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, UserRepeter, pagesize);
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UserRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)UserRepeter.Items[i].FindControl("UserCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)UserRepeter.Items[i].FindControl("ID");

                    sqlcmd.CommonDeleteColumns("dbo.UserInfo", "where ID= " + lb.Text);


                }
            }
            user_list();
        }
        protected void StateBtn_Command(object sender, CommandEventArgs e)
        {
            string StateCondi = e.CommandName.ToString().Trim();
            string userID = e.CommandArgument.ToString().Trim();
            string NowState = "";
            if ("1" == StateCondi)
                NowState = "0";
            else
                NowState = "1";


            int result = sqlcmd.CommonUpdate("UserInfo", " user_state = " + NowState, " ID = " + userID);
            if (result != 0)
            {
                if ("1" == StateCondi)
                {
                    Response.Write("<script>alert('成功禁用一个用户')</script>");
                    user_list();
                }
                else
                {
                    Response.Write("<script>alert('重新启用一个用户成功')</script>");
                    user_list();
                }
            }
            else
            {

                Response.Write("<script>alert('发生错误')</script>");
                user_list();

            }
        }
        protected void userState_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = " UserInfo.user_state =" + this.userState.SelectedValue.ToString();
            user_list();
        }

    }
}