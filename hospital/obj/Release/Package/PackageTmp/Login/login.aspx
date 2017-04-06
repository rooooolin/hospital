<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="hospital.Login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <link rel="stylesheet" href="../Css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../Css/bootstrap.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">用户名</label>
            <div class="controls"><asp:TextBox ID="name" placeholder=" 请输入用户名" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">密码</label>
            <div class="controls"><asp:TextBox ID="password" placeholder=" 请输入密码" TextMode="Password" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">选择身份</label>
            <div class="controls">
                <asp:DropDownList ID="Role" style="width:22%; height:35px; border:1px solid #ccc;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Role_SelectedIndexChanged"></asp:DropDownList><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">验证码</label>
            <div class="controls"><asp:TextBox ID="ValidCode" placeholder=" 验证码" class="input_from" width="200px" runat="server"></asp:TextBox><p class="help-block"><asp:Image style="margin-left:30px; margin-top:-10px;" ID="ValidCodeImg" ImageUrl="../common/ValidateCode.aspx"   runat="server" /></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="LoginBtn" runat="server" class="btn btn-success" Text="登录" style="width:120px;" OnClick="LoginBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
