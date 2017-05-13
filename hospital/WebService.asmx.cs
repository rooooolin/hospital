using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using Model;
using System.Data;
using System.Xml;
using System.Reflection;
using System.Web.Mvc;
namespace hospital
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {


        [WebMethod(Description = "输入患者(或医生)手机号和密码，以及用户角色ID(患者=3,医生=2)。登录成功返回患者(或医生)ID,登录失败返回0。")]
        public string login(string u_phone,string u_passwd,int u_roleId)
        {
            string u_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(u_passwd, "MD5"), "MD5");
            bll_patient user = new bll_patient();
            model_patient_info model = new model_patient_info();
            model.user_password = u_pwd;
            model.user_roleid = u_roleId;
            model.user_phone = u_phone;
            int  result = user.user_login(model);
            return result != 0 ? result.ToString() : "0"; 
        }

        [WebMethod(Description="输入患者(或医生)ID和新密码，以及用户角色ID(患者=3,医生=2)。修改成功修改返回1，失败则返回0")]
        public string modify_password(string u_id, string u_password,int u_roldId)
        {
            model_patient_info model = new model_patient_info();
            model.ID = Int32.Parse(u_id);
            model.user_password = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(u_password, "MD5"), "MD5");
            model.user_roleid = u_roldId;
            bll_patient user = new bll_patient();
            return user.update_password(model) != 0 ? "1" : "0";
        }
        public Dictionary<string, dynamic> map { get; set; }
        public List<string> model_names;

        [WebMethod(Description = "输入患者ID和需要修改的信息,成功修改返回1，失败则返回0")]
        public string modify_patientinfo(string u_id, string u_name, string u_idcard, string u_patient_number, string u_phone, string u_sex, string u_birthday, string u_work_address, string u_is_married, string u_contact, string u_contact_rela, string u_contact_phone)
        {
            model_patient_info model = new model_patient_info();
            model.ID = Int32.Parse(u_id);
            model.user_name = u_name;
            model.user_ID_Card = u_idcard;
            model.user_patient_number = u_patient_number;
            model.user_phone = u_phone;
            model.user_birthday = u_birthday;
            model.user_work_address = u_work_address;
            if (u_is_married != "" || u_is_married != null)
            {
                model.user_is_married = Boolean.Parse(u_is_married);
            }
            model.user_contact = u_contact;
            model.user_contact_rela = u_contact_rela;
            model.user_contact_phone = u_contact_phone;
            bll_patient user = new bll_patient();
            return user.update_info(model) != 0 ? "1" : "0";
        }

        [WebMethod(Description = "患者表搜索。输入需要搜索的字段,以及搜索内容。搜索成功返回相关字符串，失败返回0")]
        public string patient_search(string filed, string content)
        {
            DataSet ds=new DataSet();
            bll_search search = new bll_search();

            ds = search.fully_search(filed, content);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string return_str = "[";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string temp_str = "{";
                    temp_str += "\"user_name\":\""+ds.Tables[0].Rows[i]["user_name"].ToString()+"\",";
                    temp_str += "\"user_patient_number\":\"" + ds.Tables[0].Rows[i]["user_patient_number"].ToString() + "\"";
                    if (i < ds.Tables[0].Rows.Count - 1)
                        temp_str += "},";
                    else
                        temp_str += "}";

                    return_str += temp_str;
                }
                return_str += "]";
                return return_str;
            }
            else
                return "0";
        }

        [WebMethod(Description = "输入医生ID和需要修改的信息,成功修改返回1，失败则返回0")]
        public string modify_doctorinfo(string d_id, string doctor_name, string doctor_education, string doctor_title, string doctor_telphone, string doctor_license, string doctor_phone, string doctor_email, string doctor_unit, int doctor_depart_id)
        {
            model_doctor_info model = new model_doctor_info();
            model.ID = Int32.Parse(d_id);
            model.doctor_name = doctor_name;
            model.doctor_education = doctor_education;
            model.doctor_title = doctor_title;
            model.doctor_telphone = doctor_telphone;
            model.doctor_license = doctor_license;
            model.doctor_phone = doctor_phone;
            model.doctor_email = doctor_email;
            model.doctor_unit = doctor_unit;
            model.doctor_depart_id = doctor_depart_id;
            bll_doctor doctor = new bll_doctor();
            return doctor.update_info(model) != 0 ? "1" : "0";
        }

        [WebMethod(Description="通过患者ID获取患者所有信息")]
        public string get_patientinfo(int u_id)
        {
           
                bll_patient user = new bll_patient();
                model_patient_info model = new model_patient_info();
                string id = u_id.ToString();
                model = user.get_model(int.Parse(id));
                return JsonHelper.GetJson<model_patient_info>(model);
          
        }
        [WebMethod(Description = "通过医生ID获取医生所有信息")]
        public string get_doctorinfo(int d_id)
        {

            bll_doctor doctor = new bll_doctor();
            model_doctor_info model = new model_doctor_info();
            string id = d_id.ToString();
            model = doctor.get_model(int.Parse(id));
            return JsonHelper.GetJson<model_doctor_info>(model);

        }

        [WebMethod(Description = "添加医患从属关系。输入为医生ID和患者ID,以及可选备注。成功添加返回1,失败则返回0")]
        public string add_dp_map(int d_id,int p_id,string remarks)
        {
            bll_dpmap bpmap = new bll_dpmap();
            return bpmap.add_map(d_id, p_id, remarks) != 0 ? "1" : "0";
        }
        [WebMethod(Description = "通过医生ID获取该医生下所有患者信息")]
        public string get_dpatient_list(int d_id)
        {

            bll_doctor doctor = new bll_doctor();
            bll_patient patient = new bll_patient();
            DataSet ds = doctor.get_dpatient(d_id);
            string return_str="[";
            var json_object = new JObject();
            model_patient_tolist model = new model_patient_tolist();
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    return_str += JsonHelper.GetJson<model_patient_tolist>(patient.model_tolist(int.Parse(ds.Tables[0].Rows[i]["p_id"].ToString())));
                    if (i < ds.Tables[0].Rows.Count-1)
                        return_str += ",";
                }
            }
            return_str += "]";
            //json_object.Add("patient", return_str);
            return return_str;
            //string id = d_id.ToString();
            //model = doctor.get_model(int.Parse(id));
            //return JsonHelper.GetJson<model_doctor_info>(model);

        }
        [WebMethod(Description = "通过患者ID获取该患者下所有患医生信息")]
        public string get_pdoctor_list(int p_id)
        {

            bll_doctor doctor = new bll_doctor();
            bll_patient patient = new bll_patient();
            DataSet ds = patient.get_pdoctor(p_id);
            var json_object = new JObject();
            model_doctor_tolist model = new model_doctor_tolist();
            string return_str = "[";
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    return_str += JsonHelper.GetJson<model_doctor_tolist>(doctor.model_tolist(int.Parse(ds.Tables[0].Rows[i]["d_id"].ToString())));
                    if (i < ds.Tables[0].Rows.Count - 1)
                        return_str += ",";
                }
            }
            return_str += "]";
            //json_object.Add("patient", return_str);
            return return_str;
            //string id = d_id.ToString();
            //model = doctor.get_model(int.Parse(id));
            //return JsonHelper.GetJson<model_doctor_info>(model);

        }

        //public string modify_userinfo(int[] pos,string[] info_list)
        //{
        //    model_user model = new model_user();
        //    bll_user user = new bll_user();
        //    Type model_type = model.GetType();
        //    model_names = new List<string>();
        //    map = new Dictionary<string, dynamic>();
        //    int cunt_pos = 0; int cunt_info = -1;
        //    foreach (var property in model_type.GetProperties())
        //    {
        //        map.Add(property.Name, null);
        //        model_names.Add(property.Name.ToString());
        //    }
        //    foreach (string name in model_names)
        //    {
        //        if (pos[cunt_pos++] == 1)
        //        {
        //            map[name] = info_list[++cunt_info];
        //        }
        //    }
        //    return user.mobile_update_info(model_names, map) != 0 ? "1" : "0";
        //}

       
    }
}
