using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace hospital.Follow
{
    public partial class AddCycle : System.Web.UI.Page
    {
        protected static int disease_id;
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["disease_id"] != "" || Request.QueryString["disease_id"] != "")
                {
                    disease_id = int.Parse(Request.QueryString["disease_id"].ToString());
                    DataSet ds = sqlcmd.getCommonDatads("Disease", "*", " DiseaseID=" + disease_id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DiseaseT.Text = ds.Tables[0].Rows[0]["disease_name"].ToString();
                    }
                }
                
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string cycle_name = "'" + this.name.Text.ToString().Trim() + "'";
            if (cycle_name != "")
            {
                int reslutl = sqlcmd.CommonInsert("FollowCycle", "cycle_name,disease_id", cycle_name+","+disease_id);
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
                Response.Write("<script>alert('周期名称不能为空')</script>");
            }
        }
    }
}