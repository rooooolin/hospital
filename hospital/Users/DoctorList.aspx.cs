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
    public partial class DoctorList : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;

        string condition = " 1=1 order by ID desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doctor_list();
            }
        }
        protected void doctor_list()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("DoctorInfo", "*", condition);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, DoctorRepeter, pagesize);
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DoctorRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)DoctorRepeter.Items[i].FindControl("UserCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)DoctorRepeter.Items[i].FindControl("ID");

                    sqlcmd.CommonDeleteColumns("DoctorInfo", " where ID= " + lb.Text);
                }
            }
            doctor_list();
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
            int result = sqlcmd.CommonUpdate("DoctorInfo", " doctor_state = " + NowState, " ID = " + userID);
            if (result != 0)
            {
                if ("1" == StateCondi)
                {
                    Response.Write("<script>alert('成功禁用一个用户')</script>");
                    doctor_list();
                }
                else
                {
                    Response.Write("<script>alert('重新启用一个用户成功')</script>");
                    doctor_list();
                }
            }
            else
            {

                Response.Write("<script>alert('发生错误')</script>");
                doctor_list();

            }
        }
        protected void userState_SelectedIndexChanged(object sender, EventArgs e)
        {

            condition = "DoctorInfo.doctor_state =" + this.userState.SelectedValue.ToString();
            doctor_list();
        }

        
    }
}