using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace hospital.Case
{
    public partial class ModifyCase : System.Web.UI.Page
    {
        public static int Paid;
        public static int Doid;
        public static int Caseid;
        public static string file_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["case_id"] != null && Request.QueryString["p_id"] != null && Request.QueryString["d_id"] != null)
                {
                    Paid = int.Parse(Request.QueryString["p_id"].ToString());
                    Doid = int.Parse(Request.QueryString["d_id"].ToString());
                    Caseid = int.Parse(Request.QueryString["case_id"].ToString());
                    bll_doctor doctor = new bll_doctor();
                    DataSet ds = doctor.get_doc_name();
                    if (ds != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            
                           // AffDoc.Items.Add(
                            ListItem li= new ListItem(ds.Tables[0].Rows[i]["doctor_name"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString());
                            //);
                            if (int.Parse((ds.Tables[0].Rows[i]["ID"].ToString())) == Doid)
                            {
                                li.Selected = true;
                            }
                            AffDoc.Items.Add(li);
                        }
                    }
                    bll_case bcase = new bll_case();
                    DataSet bds = bcase.get_info(Caseid,Paid,1);
                    if (bds != null)
                    {
                        this.case_title.Text = bds.Tables[0].Rows[0]["case_title"].ToString();
                        this.case_brief.Text = bds.Tables[0].Rows[0]["case_brief"].ToString();
                        imgLogo.ImageUrl  = bds.Tables[0].Rows[0]["case_path"].ToString();
                    }
                }
            }
        }
        protected void UploadFileBtn_Click(object sender, EventArgs e)
        {
            UploadFile uploadFileObj = new UploadFile();
            uploadFileObj.MaxFileSize = 30000;
            uploadFileObj.FileType = "jpg|png|pdf";

            string uploadPath = Server.MapPath("~/UploadFiles/Case/");
            uploadFileObj.UploadFileGo(uploadPath, UploadFile);
            FileLabel.Text = uploadFileObj.UploadInfo;
            if (uploadFileObj.UploadState == true)
            {
                imgLogo.ImageUrl = "~/UploadFiles/Case/" + uploadFileObj.NewFileName;
            }
            file_name = "UploadFiles/Case/" + uploadFileObj.NewFileName;

        }
        protected void AffDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            Doid = Convert.ToInt32(this.AffDoc.SelectedValue.ToString());

        }
        protected void ModifyBtn_Click(object sender, EventArgs e)
        {
           
            bll_case bcase =new bll_case();
            int result = bcase.ModifyCase(case_title.Text, case_brief.Text, Paid, Doid, file_name,Caseid);
            if (result != 0)
            {
                Response.Write("<script>alert('修改成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }
    }
}