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

namespace hospital.Follow
{
    public partial class CheckFollowRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["p_id"] != null)
                {
                    int p_id = int.Parse(Request.QueryString["p_id"].ToString());
                    bll_patient patient = new bll_patient();
                    model_patient_info model = new model_patient_info();
                    model = patient.get_model(p_id);
                    this.FollowTarget.Text = model.user_name;
                }
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    if (Request.QueryString["record_id"] != null)
                    {
                        int record_id = int.Parse(Request.QueryString["record_id"].ToString());
                        DataSet ds_record = new DataSet();
                        bll_follow follow = new bll_follow();
                        DataSet ds = new DataSet();
                        ds = follow.get_table_byID(id);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string table_name = ds.Tables[0].Rows[0]["table_name"].ToString();
                            string json_str = ds.Tables[0].Rows[0]["json_filed"].ToString();
                            json_str = json_str.Replace("[", "").Replace("]", "").Replace("},{", "}*{");
                            string[] str_ = json_str.Split(new char[1] { '*' });
                            model_control model = new model_control();
                            ds_record = follow.get_record_byID("Follow_" + table_name, record_id);
                            if (ds_record.Tables[0].Rows.Count > 0)
                            {
                                record_title.Text = ds_record.Tables[0].Rows[0]["record_title"].ToString();
                                follow_time.Text = ds_record.Tables[0].Rows[0]["follow_time"].ToString();

                                foreach (string data in str_)
                                {


                                    model = JsonHelper.ParseFormJson<model_control>(data);
                                    this.Controls_list.Controls.Add(new LiteralControl("<div class=\"control-group\">"));

                                    Label lb = new Label();
                                    Label tb = new Label();
                                    lb.ID = "lb_" + model.ID;
                                    lb.Text = model.control_name;
                                    lb.Attributes.Add("class", "laber_from");
                                    tb.ID = model.ID;
                                    tb.Text = ds_record.Tables[0].Rows[0][model.ID].ToString();

                                    this.Controls_list.Controls.Add(new LiteralControl("<div class=\"controls\">"));
                                    this.Controls_list.Controls.Add(lb);
                                    this.Controls_list.Controls.Add(tb);



                                    this.Controls_list.Controls.Add(new LiteralControl("<p class=\"help-block\"></p></div></div>"));
                                }
                            }
                            

                        }
                    }
                    
                }
            }

        }
    }
}