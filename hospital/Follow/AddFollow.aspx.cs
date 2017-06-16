using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace hospital.Follow
{
    public partial class AddFollow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             RestoreControls();
        }
        static List<TextBox> txtbox_list = new List<TextBox>();
        static List<Label> label_list = new List<Label>();
        static List<DropDownList> dpd_list = new List<DropDownList>();
        static string filed_str = "[record_title] [varchar](50) NULL,[follow_time] [varchar](50) NULL,[table_name_iden] [varchar](50) NULL,";
        
        static string json_str = "[";
        void RestoreControls()
        {
            foreach (var label_item in label_list)
            {
                bool flag = false;
                if (label_item != null)
                {
                    this.LabelPanel.Controls.Add(new LiteralControl("<span class=\"laber_from\">&nbsp;&nbsp;"));
                    this.LabelPanel.Controls.Add(label_item);
                    this.LabelPanel.Controls.Add(new LiteralControl("</span>"));
                    this.LabelPanel.Controls.Add(new LiteralControl("<br /><br />"));
                    string label_id = label_item.ID.ToString().Split(new char[1] { '_' })[1];
                    if (!flag)
                    {
                        foreach (var txtbox_item in txtbox_list)
                        {
                            if (txtbox_item != null)
                            {
                                string txtbox_id = txtbox_item.ID.ToString().Split(new char[1] { '_' })[1];
                                if (label_id == txtbox_id)
                                {
                                    this.ValuePanel.Controls.Add(txtbox_item);
                                    
                                    this.ValuePanel.Controls.Add(new LiteralControl("<br /><br />"));
                                    if (txtbox_item.ID.ToString().Split(new char[1] { '_' })[2].ToString() == "muti")
                                    {
                                       
                                        this.LabelPanel.Controls.Add(new LiteralControl("<br /><br />"));
                                        this.ValuePanel.Controls.Add(new LiteralControl("<br /><br />"));
                                    }
                                    flag = true;
                                    break;
                                }

                            }
                        }
                    }
                    if (!flag)
                    {
                        foreach (var dpd_item in dpd_list)
                        {
                            if (dpd_item != null)
                            {
                                string dpd_id = dpd_item.ID.ToString().Split(new char[1] { '_' })[1];
                                if (label_id == dpd_id)
                                {
                                    this.ValuePanel.Controls.Add(dpd_item);
                                    this.ValuePanel.Controls.Add(new LiteralControl("<br /><br />"));
                                    flag = true;
                                    break;
                                }

                            }
                        }
                    }
                   
                }
            }
           
        }
       
        protected void AddControl_Click(object sender, EventArgs e)
        {
            Label lb = new Label();
            
            
            lb.Text = this.ControlName.Text.ToString().Trim();
            lb.ID = "lb_" + this.ControlID.Text.ToString().Trim();
            if (int.Parse(ControlType.SelectedValue) == 3)
            {
                DropDownList dpd = new DropDownList();
                dpd.ID = "dpd_" + ControlID.Text.ToString().Trim();
                dpd.Style["Style"] = "width: 22%; height: 35px; border: 1px solid #ccc;";
                filed_str += "[" + ControlID.Text.ToString().Trim() + "] [varchar](50) NULL,";
                json_str += "{\"ID\":\"" + ControlID.Text.ToString().Trim() + "\",\"control_name\":\"" + this.ControlName.Text.ToString().Trim() + "\",\"control_type\":\"DropDownList\",\"control_value\":\"" + this.TxtCandidate.Text.ToString().Trim() + "\"},";
                string[] dpd_candidate = this.TxtCandidate.Text.ToString().Trim().Split(new char[1] { '|' });
                int cunt = 1;
                foreach (string candidate in dpd_candidate)
                {
                    dpd.Items.Add(new ListItem(candidate, cunt.ToString()));
                    cunt++;
                }
               
                this.LabelPanel.Controls.Add(new LiteralControl("<span class=\"laber_from\">"));
                this.LabelPanel.Controls.Add(lb);
                this.LabelPanel.Controls.Add(new LiteralControl("</span>"));
                this.ValuePanel.Controls.Add(dpd);
                dpd_list.Add(dpd);
                label_list.Add(lb);
            }
            else
            {
                TextBox tb = new TextBox();
                tb.ID = "txt_" + this.ControlID.Text.ToString().Trim();
                tb.Attributes.Add("placeholder","请输入" + this.ControlName.Text.ToString().Trim());
                
                if (int.Parse(ControlType.SelectedValue) == 2)
                {
                    tb.ID += "_muti";
                    tb.TextMode = TextBoxMode.MultiLine;
                    filed_str += "[" + this.ControlID.Text.ToString().Trim() + "] [varchar](200) NULL,";
                    json_str += "{\"ID\":\"" + this.ControlID.Text.ToString().Trim() + "\",\"control_name\":\"" + this.ControlName.Text.ToString().Trim() + "\",\"control_type\":\"MutiLine\",\"control_value\":\"null\"},";
                }
                else 
                {
                    tb.ID += "_single";
                    filed_str += "[" + this.ControlID.Text.ToString().Trim() + "] [varchar](50) NULL,";
                    json_str += "{\"ID\":\"" + this.ControlID.Text.ToString().Trim() + "\",\"control_name\":\"" + this.ControlName.Text.ToString().Trim() + "\",\"control_type\":\"SingleLine\",\"control_value\":\"null\"},";
                }
                
                this.LabelPanel.Controls.Add(new LiteralControl("<span class=\"laber_from\">&nbsp;&nbsp;"));
                this.LabelPanel.Controls.Add(lb);
                this.LabelPanel.Controls.Add(new LiteralControl("</span>"));
                this.ValuePanel.Controls.Add(tb);
                txtbox_list.Add(tb);
                label_list.Add(lb);
            }
        }

        protected void Addbtn_Click(object sender, EventArgs e)
        {
            json_str = json_str.TrimEnd(',');
            json_str += "]";
            bll_follow follow = new bll_follow();
            int reslut1 = follow.creat_follow_table(this.table_name.Text.ToString().Trim(), filed_str);
            int reslut2 = follow.add_table_record(this.follow_name.Text.ToString().Trim(),this.table_name.Text.Trim(), json_str);
            if (reslut1 != 0 && reslut2 != 0)
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>"); 
            }
        }

        protected void ClearControls_Click(object sender, EventArgs e)
        {
            this.LabelPanel.Controls.Clear();
            this.ValuePanel.Controls.Clear();
            txtbox_list = new List<TextBox>();
            label_list = new List<Label>();
            dpd_list = new List<DropDownList>();
        }
    }
}