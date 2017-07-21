using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using BLL;
using Model;

namespace hospital
{
    public partial class welcom : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();

        protected int RowsCount;
        protected string FollowNum;
        string colums = "substring(CONVERT(char(10),follow_time,120),1,10)";

        protected string RowsDay;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable CountName = new DataTable(); ;
                GetRepeterData(DoctorRepeter, "DoctorInfo", " top 10 * ",  CountName, DoctorCount);
                GetRepeterData(UserRepeter, "PatientInfo", " top 10 * ", CountName, UserCount);
                GetRepeterData(FollowRepeter, "FollowManage", " top 10 *",CountName, FollowTableCount);
                case_list();
                getFollowCount();


                this.IpAddress.Text = "当前登录IP：" + System.Web.HttpContext.Current.Request.UserHostAddress;
                this.serverName.Text = "主域名：" + "http://" + Request.Url.Host;

                this.serverNet.Text = ".NET解释引擎版本：" + ".NET CLR" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;
                this.serverSession.Text = "虚拟目录Session总数：" + Session.Contents.Count.ToString();


                this.serverIIS.Text = "IIS 版本：" + Request.ServerVariables["SERVER_SOFTWARE"].ToString();
            }
        }
        private void GetRepeterData(Repeater RepeterName, string table, string columns,DataTable CountName, Label LableName)
        {
            DataTable dt = sqlcmd.getCommonData(table, columns, " 1=1 order by ID desc");
            RepeterName.DataSource = dt.DefaultView;
            RepeterName.DataBind();
            if (table == "Merchant")
                table = "Orders";
            CountName = sqlcmd.getCommonData(table, " COUNT(*) count ", " 1=1 ");
            if (CountName.Rows.Count > 0)
                LableName.Text = CountName.Rows[0]["count"].ToString();
        }
        protected void case_list()
        {
            DataTable dt = new DataTable();
            dt = sqlcmd.TriJoinPageIndexdt("Pcase", "PatientInfo", "DoctorInfo", "m.ID,m.p_id,a.user_name,a.user_patient_number,m.d_id,b.doctor_name,m.case_path", "a.ID = m.p_id", "b.ID=m.d_id order by m.ID desc");
            CaseRepeter.DataSource = dt.DefaultView;
            CaseRepeter.DataBind();
        }
        public string get_encode(string str_)
        {
            string str_temp = HttpContext.Current.Server.UrlEncode(str_);
            return str_temp;
        }
        public string get_filed(string json_str)
        {

            model_control model = new model_control();
            json_str = json_str.Replace("[", "").Replace("]", "").Replace("},{", "}*{");
            string[] str_ = json_str.Split(new char[1] { '*' });
            string return_str = "";
            foreach (string data in str_)
            {

                model = JsonHelper.ParseFormJson<model_control>(data);
                return_str += model.control_name + ",";
            }

            return return_str.TrimEnd(',');
        }

        private void getFollowCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Follow_tnsec", colums, "1=1");
            if (dt.Rows.Count > 0)
            {

                RowsCount = dt.Rows.Count;
                if (RowsCount > 15)
                    RowsCount = 15;
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();


                        if (i < dt.Rows.Count - 1)
                            FollowNum += ", " + daynum;
                        else
                            FollowNum += daynum;
                    }
                    if (dt.Rows[i]["Dates"].ToString() != null)
                    {
                        string day = dt.Rows[i]["Dates"].ToString();
                        if (i < dt.Rows.Count - 1)
                            RowsDay += "," + day.Replace("-", "");
                        else
                            RowsDay += day.Replace("-", "");
                    }
                }
            }

        }
    }
}