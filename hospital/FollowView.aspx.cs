using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;

namespace hospital
{
    public partial class FollowView : System.Web.UI.Page
    {
        public static int follow_id;
        public static string table_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["follow_id"] != null)
                {
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
                    string json_str = ds.Tables[0].Rows[0]["json_filed"].ToString();
                    json_str = json_str.Replace("[", "").Replace("]", "").Replace("},{", "}*{");
                    string[] str_ = json_str.Split(new char[1] { '*' });
                    model_control model = new model_control();

                    foreach (string data in str_)
                    {
                        model = JsonHelper.ParseFormJson<model_control>(data);
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
                            tb.Attributes.Add("ReadOnly", "true");
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
                            dpd.Attributes.Add("ReadOnly", "true");
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

            get_follow_record_alr(table_name);
        }
        private void get_follow_record_alr(string table_name)
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            DataSet ds = sqlcmd.getCommonDatads("Follow_" + table_name, "*", " ID =" + follow_id);
            if (ds != null)
            {
                record_title.Text = ds.Tables[0].Rows[0]["record_title"].ToString();
                follow_time.Text = ds.Tables[0].Rows[0]["follow_time"].ToString();
                foreach (Control item in this.Controls_list.Controls)
                {

                    if (item is TextBox)
                    {
                        (item as TextBox).Text = ds.Tables[0].Rows[0][(item as TextBox).ID].ToString();
                        
                    }
                    else if (item is DropDownList)
                    {
                        (item as DropDownList).SelectedValue = ds.Tables[0].Rows[0][(item as DropDownList).ID].ToString();
                    }
                }
            }
        }
    }
}