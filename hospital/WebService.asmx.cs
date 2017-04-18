﻿using System;
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

       
        [WebMethod(Description="用户(医生，患者)登录成功返回ID,登录失败返回0。管理员登录成功返回1,失败返回0")]
        public string login(string u_name,string u_phone,string u_passwd,int u_roleId)
        {
            string u_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(u_passwd, "MD5"), "MD5");
            int result = 0;
            if (u_roleId == 1 || u_roleId == 2)
            {
                bll_admin admin = new bll_admin();
                model_admin model = new model_admin();
                model.admin_name = u_name;
                model.admin_password = u_pwd;
                model.admin_roleid = u_roleId;
                result = admin.admin_login(model);
            }
            else 
            {
                bll_user user = new bll_user();
                model_user model = new model_user();
                model.user_name = u_name;
                model.user_phone = u_phone;
                model.user_password = u_pwd;
                model.user_roleid = u_roleId;
                result = user.user_login(model);
            }
            return result != 0 ? result.ToString() : "0"; 
        }
        [WebMethod(Description="输入用户ID和新密码，成功修改返回1，失败则返回0")]
        public string modify_password(string u_id, string u_password)
        {
            model_user model = new model_user();
            model.ID = Int32.Parse(u_id);
            model.user_password = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(u_password, "MD5"), "MD5");
            bll_user user = new bll_user();
            return user.update_password(model) != 0 ? "1" : "0";
        }
        public Dictionary<string, dynamic> map { get; set; }
        public List<string> model_names;

        [WebMethod(Description = "输入用户ID和需要修改的信息,成功修改返回1，失败则返回0")]
        public string modify_userinfo(string u_id, string u_name, string u_idcard, string u_patient_number, string u_phone, string u_sex, string u_birthday, string u_work_address, string u_is_married, string u_contact, string u_contact_rela, string u_contact_phone)
        {
            model_user model = new model_user();
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
            bll_user user = new bll_user();
            return user.update_info(model) != 0 ? "1" : "0";
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
