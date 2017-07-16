using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPush;

namespace hospital
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string result=push_message.PushMessageToSingle("a1234");
            this.Label1.Text = result;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("followp.aspx?role_id=3&table_id=22&follow_id=1");
        }
    }
}