using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hospital
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userName = User.Identity.Name;
                this.AdminName.Text = userName;
            }
            else
            {
                Response.Redirect("Login/login.aspx");
            }
        }
        protected void LoginOut_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("Login/login.aspx");
        }
    }
}