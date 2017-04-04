using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Uwin
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidatedCode v = new ValidatedCode();
            string code = v.CreateVerifyCode();            //取随机码  
            v.CreateImageOnPage(code, this.Context);       // 输出图片  
            Session["CheckCode"] = code;                   //Session 取出验证码 
        }
    }
}