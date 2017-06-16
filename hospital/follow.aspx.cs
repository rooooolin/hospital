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
    public partial class follow : System.Web.UI.Page
    {
        public static string table_name;
        public static int d_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["d_id"] != null)
                {
                    d_id = int.Parse(Request.QueryString["d_id"].ToString());

                    bll_doctor doctor = new bll_doctor();
                    bll_patient patient = new bll_patient();
                    DataSet ds = doctor.get_dpatient(d_id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            model_patient_tolist model = new model_patient_tolist();
                            model = patient.model_tolist(int.Parse(ds.Tables[0].Rows[i]["p_id"].ToString()));
                            FollowTarget.Items.Add(new ListItem(model.user_name, model.ID.ToString()));
                        }
                    }

                }
            }
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                bll_follow follow = new bll_follow();
                DataSet ds = new DataSet();
                ds = follow.get_table_byID(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    table_name = ds.Tables[0].Rows[0]["table_name"].ToString();
                    string json_str = ds.Tables[0].Rows[0]["json_filed"].ToString();
                    json_str = json_str.Replace("[", "").Replace("]", "").Replace("},{", "}*{");
                    string[] str_ = json_str.Split(new char[1] { '*' });
                    model_control model = new model_control();

                    foreach (string data in str_)
                    {


                        model = JsonHelper.ParseFormJson<model_control>(data);
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
                            {
                                tb.TextMode = TextBoxMode.MultiLine;
                            }
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
                            {
                                dpd.Items.Add(item);
                            }
                            this.Controls_list.Controls.Add(lb);
                            this.Controls_list.Controls.Add(dpd);

                        }
                        this.Controls_list.Controls.Add(new LiteralControl("<p class=\"help-block\"></p></div></div>"));
                    }

                }
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string insert_values = "";
            string columns = "record_title,follow_time,table_name_iden,";
            insert_values += "'" + record_title.Text + "',";
            insert_values += "'" + follow_time.Text.Split()[0] + "',";
            insert_values += "'" + table_name + "',";
            bool flag=true;
            foreach (Control item in this.Controls_list.Controls)
            {

                flag = true;
                if (item is TextBox)
                {
                    if ((item as TextBox).Text == null || (item as TextBox).Text == "")
                    {
                        string write_str = (item as TextBox).Attributes["placeholder"].ToString();
                        Response.Write("<script>alert('"+write_str+"')</script>");
                        flag = false;
                        break;
                    }
                    else
                    {
                        columns += item.ID + ",";
                        insert_values += "'" + (item as TextBox).Text.ToString() + "',";
                    }
                }
                else if (item is DropDownList)
                {
                    columns += item.ID + ",";
                    insert_values += "'" + (item as DropDownList).SelectedValue + "',";
                }
            }
            insert_values += d_id + "," + FollowTarget.SelectedValue;
            if (flag)
            {
                bll_follow follow = new bll_follow();
                int result = follow.add_follow_record("Follow_" + table_name, columns, insert_values);
                if (result != 0)
                {
                    Response.Write("<script>alert('成功添加随访记录')</script>");
                }
                else
                {

                    Response.Write("<script>alert('添加失败')</script>");
                }
            }
           
        }
       
    }
}