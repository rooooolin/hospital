<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyInfo.aspx.cs" Inherits="hospital.Case.ModifyInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息修改</title>
     <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">用户名</label>
            <div class="controls"><asp:TextBox ID="user_name"  CssClass="input required" placeholder=" 请输入用户名" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="user_name"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">身份证号</label>
            <div class="controls"><asp:TextBox ID="user_ID_Card"  CssClass="input required" placeholder=" 请输入身份证号" class="input_from" runat="server"></asp:TextBox><p class="help-block">
               </p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">病号</label>
            <div class="controls"><asp:TextBox ID="user_patient_number"  CssClass="input required" placeholder=" 请输入病号" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入用户名" ControlToValidate="user_patient_number"></asp:RequiredFieldValidator></p></div>
        </div>
        
        <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
            <div class="control-group">
            <label class="laber_from">性别</label>
            <div class="controls">
                <asp:DropDownList ID="user_sex" runat="server" AutoPostBack="true" >
                    <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <p class="help-block">
              </p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">婚否</label>
            <div class="controls">
                <asp:DropDownList ID="user_is_married" runat="server" AutoPostBack="true" >
                    <asp:ListItem Text="已婚" Value="1"></asp:ListItem>
                    <asp:ListItem Text="未婚" Value="0"></asp:ListItem>
                </asp:DropDownList>
               <p class="help-block">
                
</p></div>
        </div>
             </ContentTemplate></asp:UpdatePanel>
        <div class="control-group">
            <label class="laber_from">联系电话</label>
            <div class="controls"><asp:TextBox ID="user_phone"  CssClass="input required" placeholder=" 请输入联系电话" class="input_from" runat="server"></asp:TextBox><p class="help-block">
               </p></div>
        </div>
        
        <div class="control-group">
            <label class="laber_from">出生日期</label>
            <div class="controls"><asp:TextBox ID="user_birthday"  CssClass="input required" placeholder=" 请输入用户名" class="input_from" runat="server"></asp:TextBox><p class="help-block">
               </p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">工作地址</label>
            <div class="controls"><asp:TextBox ID="user_work_address" placeholder=" 请输入工作地址" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">常用联系人</label>
            <div class="controls"><asp:TextBox ID="user_contact" placeholder=" 请输入常用联系人" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">联系人关系</label>
            <div class="controls"><asp:TextBox ID="user_contact_rela" placeholder=" 请输入联系人关系" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">联系人电话</label>
            <div class="controls"><asp:TextBox ID="user_contact_phone" placeholder=" 请输入联系人电话" class="input_from" runat="server" ></asp:TextBox><p class="help-block"></p></div>
        </div>

        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="确认修改" style="width:120px;" OnClick="EditBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
