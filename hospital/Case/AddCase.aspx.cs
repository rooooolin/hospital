using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.Sql;


namespace hospital.Case
{
    public partial class AddCase : System.Web.UI.Page
    {
        public static string file_name;
        public static int DocID = 0;
        public static int Paid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Paid = int.Parse(Request.QueryString["id"].ToString());
                    bll_doctor doctor = new bll_doctor();
                    DataSet ds = doctor.get_doc_name();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            AffDoc.Items.Add(new ListItem(ds.Tables[0].Rows[i]["doctor_name"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));
                        }
                    }
                }
            }
        }
        protected void UploadFileBtn_Click(object sender, EventArgs e)
        {
            UploadFile uploadFileObj = new UploadFile();
            uploadFileObj.MaxFileSize = 10240;
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

            DocID = Convert.ToInt32(this.AffDoc.SelectedValue.ToString());

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            bll_case bcase =new bll_case();
            int result=bcase.AddCase(case_title.Text,case_brief.Text,Paid, DocID, file_name);
            if (result != 0)
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
        }
    }
}