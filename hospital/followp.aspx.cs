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
using GPush;

namespace hospital
{
    public partial class followp : System.Web.UI.Page
    {
        public static string table_name;
        public static int role_id;
        public static int follow_id;
        public static int d_id;
        public static int p_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["role_id"] != null && Request.QueryString["follow_id"]!=null&& Request.QueryString["p_id"]!=null)
                {
                    role_id = int.Parse(Request.QueryString["role_id"].ToString());
                    follow_id = int.Parse(Request.QueryString["follow_id"].ToString());
                    p_id = int.Parse(Request.QueryString["p_id"].ToString());
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
                                this.Controls_list.Controls.Add(new LiteralControl("<label>"));
                                Label lb = new Label();
                                TextBox tb = new TextBox();
                                lb.ID = "lb_" + model.ID;
                                lb.Text = model.control_name;
                                lb.Attributes.Add("class", "layer");
                                tb.ID = model.ID;
                                tb.Attributes.Add("placeholder", "请输入" + model.control_name);
                                tb.Attributes.Add("style", "width:100%");
                                tb.Attributes.Add("type", "text");
                                if (model.control_type == "MutiLine")
                                    tb.TextMode = TextBoxMode.MultiLine;
                                tb.Attributes.Add("runat", "server");
                                this.Controls_list.Controls.Add(lb);
                                this.Controls_list.Controls.Add(tb);
                            }

                            else if (model.control_type == "DropDownList")
                            {
                                this.Controls_list.Controls.Add(new LiteralControl("<label>"));
                                DropDownList dpd = new DropDownList();
                                Label lb = new Label();
                                lb.ID = "lb_" + model.ID;
                                lb.Text = model.control_name;
                                lb.Attributes.Add("class", "layer");
                                dpd.ID = model.ID;
                                dpd.Attributes.Add("style", "width:100%");
                                string[] dpd_item_list = model.control_value.Split(new char[1] { '|' });
                                foreach (string item in dpd_item_list)
                                    dpd.Items.Add(item);
                                this.Controls_list.Controls.Add(lb);
                                this.Controls_list.Controls.Add(dpd);
                            }
                            this.Controls_list.Controls.Add(new LiteralControl("</label>"));
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
                d_id = int.Parse(ds.Tables[0].Rows[0]["d_id"].ToString());
            }
        }
        protected string get_push_target()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string alias = "";

            DataSet ds = sqlcmd.getCommonDatads(" DoctorInfo", " doctor_telphone", " ID=" + d_id);
            if (ds != null)
            {
                string doctor_telphone = ds.Tables[0].Rows[0]["doctor_telphone"].ToString();
                alias = doctor_telphone;
            }
            
            
            return alias;
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

                string push_result = "";
                string transmission_str = "{\"action\":\"p_push_d\",\"parameter\":\"no_parameter\",\"value\":\"no_value\"}";

                push_result = push_message.PushMessageToSingle(get_push_target(), "随访通知", "您有一条新的随访确认通知", transmission_str, 3);
               
                bll_push push = new bll_push();
                model_pushlog model = new model_pushlog();
                model.activator = p_id.ToString();
                model.target = d_id.ToString();
                model.push_time = System.DateTime.Now.ToString();
                model.result = push_result;
                model.remarks = "患者确认随访";
                int int_push_result = push.add_push_log(model);
                
                int result = follow.update_follow_record("Follow_" + table_name, columns, " ID =" + follow_id);
                if (result != 0)
                {
                    Response.Write("<script>alert('您已确认随访')</script>");
                }
                else
                {

                    Response.Write("<script>alert('确认失败')</script>");
                }
             

            }
        }
    }
}