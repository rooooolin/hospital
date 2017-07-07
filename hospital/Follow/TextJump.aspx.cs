using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hospital.Follow
{
    public partial class TextJump : System.Web.UI.Page
    {
        protected static int ttable_id;
        protected static int role_id;
        protected static int disease_id;
        protected static int cycle_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["follow_name"] != null && Request.QueryString["role_id"] != null )
                {
                    ttable_id = int.Parse(Request.QueryString["id"].ToString());
                    string follow_name = HttpContext.Current.Server.UrlDecode(Request.QueryString["follow_name"].ToString());
                    this.Label1.Text = follow_name;

                    role_id = int.Parse(Request.QueryString["role_id"].ToString());
                  
                   
                    
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int td_id = int.Parse(this.TextBox1.Text.ToString());
            string url = "../follow.aspx?id=" + ttable_id + "&d_id=" + td_id+"&role_id="+role_id;
            Response.Redirect(url);
        }
    }
}