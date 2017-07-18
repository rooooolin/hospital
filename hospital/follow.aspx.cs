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
    public partial class follow : System.Web.UI.Page
    {
        public static string table_name;
        public static int d_id;
        public static int role_id;
        public static string p_id_list_str;
        public static int table_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["role_id"] != null)
                {
                    role_id = int.Parse(Request.QueryString["role_id"].ToString());
                }
                if (Request.QueryString["d_id"] != null)
                {
                    d_id = int.Parse(Request.QueryString["d_id"].ToString());
                    if (role_id == 1)
                    {
                        get_target(d_id);
                    }

                }
            }
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());

                bll_follow follow = new bll_follow();
                DataSet ds = new DataSet();
                ds = follow.get_table_byID(id);
                if (ds != null)
                {
                    table_name = ds.Tables[0].Rows[0]["table_name"].ToString();
                    table_id = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
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
                                this.Controls_list.Controls.Add(new LiteralControl("<lable>"));
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
                                this.Controls_list.Controls.Add(new LiteralControl("<lable>"));
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
                            this.Controls_list.Controls.Add(new LiteralControl("</lable>"));
                        }
                    }

                }
            }
        }
        private void get_target(int d_id)
        {
            FollowTarget.Items.Clear();
            if (RadioTarget.SelectedItem.Text == "单人")
            {
                bll_doctor doctor = new bll_doctor();
                bll_patient patient = new bll_patient();
                DataSet ds = doctor.get_dpatient(d_id);
                if (ds != null)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        model_patient_tolist model = new model_patient_tolist();
                        model = patient.model_tolist(int.Parse(ds.Tables[0].Rows[i]["p_id"].ToString()));
                        FollowTarget.Items.Add(new ListItem(model.user_name, model.ID.ToString()));
                    }
                }
            }
            else if (RadioTarget.SelectedItem.Text == "组员")
            {
                bll_group group = new bll_group();
                DataSet ds = group.get_group_list(d_id);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        FollowTarget.Items.Add(new ListItem(ds.Tables[0].Rows[i]["group_name"].ToString(), ds.Tables[0].Rows[i]["ID"].ToString()));
                    }
                }
            }

        }
        protected void get_p_id_list()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            DataSet ds = sqlcmd.getCommonDatads(" CustomGroup", " p_id_list", " ID=" + int.Parse(FollowTarget.SelectedValue));
            if (ds != null)
            {
                p_id_list_str = ds.Tables[0].Rows[0]["p_id_list"].ToString();
            }
        }
        protected string get_push_target()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string alias = "";
            if (RadioTarget.SelectedItem.Text == "单人")
            {
                DataSet ds = sqlcmd.getCommonDatads(" PatientInfo", " user_phone", " ID=" + int.Parse(FollowTarget.SelectedValue));
                if (ds != null)
                {
                    string user_phone = ds.Tables[0].Rows[0]["user_phone"].ToString();
                    alias = user_phone;
                }
            }
            else if (RadioTarget.SelectedItem.Text == "组员")
            {
                string[] p_id_list = p_id_list_str.Split(new char[1] { ',' });
                foreach (string p_id in p_id_list)
                {
                    DataSet ds2 = sqlcmd.getCommonDatads(" PatientInfo", " user_phone", " ID=" + int.Parse(p_id));
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        alias += ds2.Tables[0].Rows[0]["user_phone"].ToString() + ",";
                    }
                }
                alias = alias.TrimEnd(',');
            }
            return alias;
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string insert_values = "";
            string columns = "record_title,follow_time,table_name_iden,";
            insert_values += "'" + record_title.Text + "',";
            insert_values += "'" + follow_time.Text.Split()[0] + "',";
            insert_values += "'" + table_name + "',";


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

            if (RadioTarget.SelectedItem.Text == "单人")
            {
                insert_values += d_id + "," + FollowTarget.SelectedValue;
                p_id_list_str = FollowTarget.SelectedValue;
            }

            else if (RadioTarget.SelectedItem.Text == "组员")
            {
                get_p_id_list();
                insert_values += d_id + ",'" + p_id_list_str+"'";
            }
            if (flag)
            {
                bll_follow follow = new bll_follow();

                int result = follow.add_follow_record("Follow_" + table_name, columns, insert_values);
                string push_result = "";
                string transmission_str = "{\"action\":\"d_push_p\",\"parameter\":\"table_id,follow_id\",\"value\":\""+table_id+","+result+"\"}";
                
                if (RadioTarget.SelectedItem.Text == "单人")
                {
                    push_result = push_message.PushMessageToSingle(get_push_target(), "随访通知", "您有一条新的随访通知", transmission_str,2);
                }
                else if (RadioTarget.SelectedItem.Text == "组员")
                {
                    push_result = push_message.PushMessageToList(get_push_target(), "随访通知", "您有一条新的随访通知", transmission_str,2);
                }
                bll_push push=new bll_push();
                model_pushlog model=new model_pushlog();
                model.activator=d_id.ToString();
                model.target=p_id_list_str;
                model.push_time=System.DateTime.Now.ToString();
                model.result=push_result;
                model.remarks="医生发起随访";
                int int_push_result = push.add_push_log(model);

                if (result != 0 && int_push_result !=0)
                {
                    Response.Write("<script>alert('成功添加并推送随访记录')</script>");
                }
                else
                {

                    Response.Write("<script>alert('添加失败')</script>");
                }



            }

        }

        protected void RadioTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_target(d_id);
        }



    }
}