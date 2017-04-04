using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
using System.Data.SqlClient;
using System.Web.Security;
using Model;

namespace hospital.Login
{
    public partial class login : System.Web.UI.Page
    {
        public static int RoleID = 1; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bll_role role = new bll_role();
                DataSet ds = role.get_role_model();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Role.Items.Add(new ListItem(ds.Tables[0].Rows[i]["RoleName"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));
                    }
                }
                    
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string vCode = Session["CheckCode"].ToString();
            if (ValidCode.Text.Trim().ToUpper() != vCode.ToUpper())
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "StartUp","alert('验证码不正确');", true);
            }
            else
            {
                string u_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text.Trim(), "MD5"), "MD5");
                bll_admin admin = new bll_admin();
                model_admin model = new model_admin();
                model.UserName = name.Text.Trim(); ;
                model.PassWd = u_pwd;
                model.RoleID = RoleID;
                int count = admin.admin_login(model);
                if (count != 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, false);

                    Response.Redirect("../index.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('请检查您的用户名或密码是否正确')", true);

                }
            }
        }
        protected void Role_SelectedIndexChanged(object sender, EventArgs e)
        {

            RoleID = Convert.ToInt32(this.Role.SelectedValue.ToString());

        }
    }
}