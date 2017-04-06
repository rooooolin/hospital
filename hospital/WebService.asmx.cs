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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string admin_login(string u_name,string u_passwd,int u_roleId)
        {
            string u_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(u_passwd, "MD5"), "MD5");
            bll_admin admin = new bll_admin();
            model_admin model = new model_admin();
            model.UserName = u_name;
            model.PassWd = u_pwd;
            model.RoleID = u_roleId;
            int count = admin.admin_login(model);
            if (count != 0)
            {
                return "1"; 
            }
            else
            {
                return "0";

            }
        }
        [WebMethod]
        public string user_login(string u_name, string u_phone, string u_passwd, int u_roleId)
        {
            string u_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(FormsAuthentication.HashPasswordForStoringInConfigFile(u_passwd, "MD5"), "MD5");
            bll_user user = new bll_user();
            model_user model = new model_user();
            model.user_name = u_name;
            model.user_phone = u_phone;
            model.user_password=u_passwd;
            model.user_roleid = u_roleId;
            return user.user_login(model) != 0 ? "1" : "0";
            
        }
    }
}
