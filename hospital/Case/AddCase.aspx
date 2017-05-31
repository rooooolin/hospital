<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCase.aspx.cs" Inherits="hospital.Case.AddCase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../Css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../Css/bootstrap.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_from_aoto" >
        <div class="control-group">
            <label class="laber_from">病例名称</label>
            <div class="controls"><asp:TextBox ID="case_title" placeholder="请输入标题" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="case_titleValidator" runat="server" 
            ErrorMessage="名称不能为空！" ControlToValidate="case_title"></asp:RequiredFieldValidator>
</p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">简要描述</label>
            <div class="controls"><asp:TextBox ID="case_brief" placeholder="请输入描述" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="描述不能为空！" ControlToValidate="case_brief"></asp:RequiredFieldValidator>
</p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">所属医生</label>
            <div class="controls">
                <asp:DropDownList ID="AffDoc" style="width:22%; height:35px; border:1px solid #ccc;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AffDoc_SelectedIndexChanged">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <p class="help-block"></p></div>
        </div>
    
        <div class="control-group" style="height:100px;">
            <label class="laber_from"  style="margin-top:40px;">文件(jpg|png|pdf)</label>
            <div class="controls">
                <asp:Image ID="imgLogo" runat="server" Width="60px" Height="80px" /><br/>
         <asp:FileUpload ID="UploadFile"  runat="server" />  
        <asp:Button ID="UploadFileBtn" runat="server" Text="上传" OnClick="UploadFileBtn_Click" />  
        <asp:Label ID="FileLabel" runat="server" Text="" Style="color: Red"></asp:Label> 

            </div>
        </div>
           <div class="control-group" style="width:100px; height:50px"></div>
             <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="添加" style="width:120px;" OnClick="AddBtn_Click" /></div>
        </div>
    </div>
    </form>
</body>
</html>
