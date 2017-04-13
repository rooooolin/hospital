using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using DAL;
using BLL;
using Model;
namespace hospital.Users
{
    public partial class ModifyInfo : System.Web.UI.Page
    {
        public static int roleId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("UserList.aspx");
                else
                {
                    show();

                }
            }
        }
        bll_user user = new bll_user();
        model_user model = new model_user();
        private void show()
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                model = user.get_model(int.Parse(id));
                user_name.Text = model.user_name;
                user_ID_Card.Text = model.user_ID_Card;
                user_patient_number.Text = model.user_patient_number;
                user_phone.Text = model.user_phone;
                user_sex.SelectedItem.Text = model.user_sex;
                user_birthday.Text = model.user_birthday;
                user_work_address.Text = model.user_work_address;
                user_is_married.SelectedValue=model.user_is_married?"1":"0";
                user_contact.Text = model.user_contact;
                user_contact_rela.Text = model.user_contact_rela;
                user_contact_phone.Text = model.user_contact_phone;

            }
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            model.ID = int.Parse(Request.QueryString["id"].ToString());
            model.user_name = "'" + user_name.Text + "'";
            model.user_ID_Card = "'" + user_ID_Card.Text + "'";
            model.user_patient_number = "'" + user_patient_number.Text + "'";
            model.user_phone = "'" + user_phone.Text + "'";
            model.user_sex = "'" + user_sex.Text + "'";
            model.user_birthday = "'" + user_birthday.Text + "'";
            model.user_work_address = "'" + user_work_address.Text + "'";
            if (user_is_married.SelectedValue == "1")
            {
                model.user_is_married = true;
            }
            else
                model.user_is_married = false;
            model.user_contact = "'" + user_contact.Text + "'";
            model.user_contact_rela = "'" + user_contact_rela.Text + "'";
            model.user_contact_phone = "'" + user_contact_phone.Text + "'";
            if (user.update_info(model) != 0)
            {
                Response.Write("修改成功");
            }
            else
            {
                Response.Write("修改失败");
            }
        }
    }
}