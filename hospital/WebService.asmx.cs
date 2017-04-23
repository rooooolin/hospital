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
using System.Data.SqlClient;
using System.Web.Security;
using Model;
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

        public static string ModelToXML(object model)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement ModelNode = xmldoc.CreateElement("Model");
            xmldoc.AppendChild(ModelNode);

            if (model != null)
            {
                foreach (PropertyInfo property in model.GetType().GetProperties())
                {
                    XmlElement attribute = xmldoc.CreateElement(property.Name);
                    if (property.GetValue(model, null) != null)
                        attribute.InnerText = property.GetValue(model, null).ToString();
                    else
                        attribute.InnerText = "[Null]";
                    ModelNode.AppendChild(attribute);
                }
            }

            return xmldoc.OuterXml;
        }
        [WebMethod(Description="通过患者ID获取患者所有信息")]
        public string get_patientinfo(int u_id)
        {
           
                bll_patient user = new bll_patient();
                model_patient_info model = new model_patient_info();
                string id = u_id.ToString();
                model = user.get_model(int.Parse(id));
                return ModelToXML(model); 
          
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
