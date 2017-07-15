using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;
using System.Web.UI.HtmlControls;

namespace hospital
{
    public partial class followp : System.Web.UI.Page
    {
        public static string table_name;
        public static int role_id;
        public static int follow_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["role_id"] != null && Request.QueryString["follow_id"]!=null)
                {
                    role_id = int.Parse(Request.QueryString["role_id"].ToString());
                    follow_id = int.Parse(Request.QueryString["follow_id"].ToString());
                }
            }
            if (Request.QueryString["table_id"] != null)
            {
                int id = int.Parse(Request.QueryString["table_id"].ToString());

                bll_follow follow = new bll_follow();
                DataSet ds = new DataSet();
                ds = follow.get_table_byID(id);
                if (ds != null)
                {
                    table_name = ds.Tables[0].Rows[0]["table_name"].ToString();
                    get_follow_record_alr(table_name);
                    string json_str = ds.Tables[0].Rows[0]["json_filed"].ToString();
                    json_str = json_str.Replace("[", "").Replace("]", "").Replace("},{", "}*{");
                    string[] str_ = json_str.Split(new char[1] { '*' });
                    model_control model = new model_control();

                    foreach (string data in str_)
                    {
                        model = JsonHelper.ParseFormJson<model_control>(data);
                        if (model.role_id == role_id)
                        {
                            if (model.control_type == "SingleLine" || model.control_type == "MutiLine")
                            {
                                this.Controls_list.Controls.Add(new LiteralControl("<div class=\"form_ctrl input_text\">"));
                                Label lb = new Label();
                                TextBox tb = new TextBox();
                                lb.ID = "lb_" + model.ID;
                                lb.Text = model.control_name;
                                lb.Attributes.Add("class", "ctrl_title");
                                tb.ID = model.ID;
                                tb.Attributes.Add("placeholder", "请输入" + model.control_name);
                                tb.Attributes.Add("type", "text");
                                if (model.control_type == "MutiLine")
                                    tb.TextMode = TextBoxMode.MultiLine;
                                tb.Attributes.Add("runat", "server");
                                this.Controls_list.Controls.Add(lb);
                                this.Controls_list.Controls.Add(tb);
                            }

                            else if (model.control_type == "DropDownList")
                            {
                                this.Controls_list.Controls.Add(new LiteralControl("<div class=\"form_ctrl form_select\">"));
                                DropDownList dpd = new DropDownList();
                                Label lb = new Label();
                                lb.ID = "lb_" + model.ID;
                                lb.Text = model.control_name;
                                lb.Attributes.Add("class", "ctrl_title");
                                dpd.ID = model.ID;
                                string[] dpd_item_list = model.control_value.Split(new char[1] { '|' });
                                foreach (string item in dpd_item_list)
                                    dpd.Items.Add(item);
                                this.Controls_list.Controls.Add(lb);
                                this.Controls_list.Controls.Add(dpd);
                            }
                            this.Controls_list.Controls.Add(new LiteralControl("<p class=\"help-block\"></p></div></div>"));
                        }
                    }

                }
            }
        }
        private void get_follow_record_alr(string table_name)
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            DataSet ds = sqlcmd.getCommonDatads("Follow_"+table_name,"*"," ID ="+ follow_id);
            if (ds != null)
            {
                record_title.Text = ds.Tables[0].Rows[0]["record_title"].ToString();
                follow_time.Text = ds.Tables[0].Rows[0]["follow_time"].ToString();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string columns = "";
            bool flag = true;
            foreach (Control item in this.Controls_list.Controls)
            {

                flag = true;
                if (item is TextBox)
                {
                    if ((item as TextBox).Text == null || (item as TextBox).Text == "")
                    {
                        string write_str = (item as TextBox).Attributes["placeholder"].ToString();
                        Response.Write("<script>alert('" + write_str + "')</script>");
                        flag = false;
                        break;
                    }
                    else
                    {
                        columns += item.ID + "='" + (item as TextBox).Text.ToString() + "',";
                       
                    }
                }
                else if (item is DropDownList)
                {
                    columns += item.ID + "='" + (item as DropDownList).SelectedValue + "',";
                }
            }
            columns = columns.TrimEnd(',');
            if (flag)
            {
                bll_follow follow = new bll_follow();

                int result = follow.update_follow_record("Follow_" + table_name, columns, " ID =" + follow_id);
                if (result != 0)
                {
                    Response.Write("<script>alert('你已确认随访')</script>");
                }
                else
                {

                    Response.Write("<script>alert('确认失败')</script>");
                }
             

            }
        }
    }
}