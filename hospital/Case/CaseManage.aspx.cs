using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using BLL;

namespace hospital.Case
{
    public partial class CaseManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            case_list();
        }
        protected void case_list()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.TriJoinPageIndex("Pcase", "PatientInfo", "DoctorInfo", "m.ID,m.p_id,a.user_name,a.user_patient_number,m.d_id,b.doctor_name,m.case_path", "a.ID = m.p_id", "b.ID=m.d_id");
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, CaseRepeter, pagesize);
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CaseRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)CaseRepeter.Items[i].FindControl("UserCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)CaseRepeter.Items[i].FindControl("ID");

                    sqlcmd.CommonDeleteColumns("Pcase", " where ID= " + lb.Text);


                }
            }
            case_list();
        }
    }
}