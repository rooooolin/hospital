using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace hospital.Follow
{
    public partial class AddDisease : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string disease_name="'"+this.name.Text.ToString().Trim()+"'";
            if (disease_name != "")
            {
                int reslutl = sqlcmd.CommonInsert("Disease", "disease_name", disease_name);
                if (reslutl != 0)
                {
                    Response.Write("<script>alert('添加成功')</script>");
                }
                else
                {
 
                    Response.Write("<script>alert('添加失败')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('疾病名称不能为空')</script>");
            }
            
        }
    }
}