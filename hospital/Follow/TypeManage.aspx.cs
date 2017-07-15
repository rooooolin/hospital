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
    public partial class TypeManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected string condition = "Disease.DiseaseID=FollowCycle.disease_id";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = sqlcmd.getCommonDatads("Disease","*","1=1");
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DiseaseType.Items.Add(new ListItem(ds.Tables[0].Rows[i]["disease_name"].ToString(), ds.Tables[0].Rows[i]["DiseaseID"].ToString()));
                    }
                }
                type_list();
            }
        }
        protected void type_list()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.JoinPageIndex("FollowCycle right join Disease", "*", condition);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, TypeRepeter, 9);
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TypeRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)TypeRepeter.Items[i].FindControl("TypeCheck");
                if (cb.Checked)
                {
                    Label lb_id = (Label)TypeRepeter.Items[i].FindControl("ID");

                    sqlcmd.CommonDeleteColumns("FollowCycle", " where CycleID= " + lb_id.Text);


                }
            }
            type_list();
        }
       
        protected void DiseaseType_SelectedIndexChanged(object sender, EventArgs e)
        {

            condition = "Disease.DiseaseID=FollowCycle.disease_id where Disease.DiseaseID =" + this.DiseaseType.SelectedValue.ToString();
            type_list();
        }
    }
}