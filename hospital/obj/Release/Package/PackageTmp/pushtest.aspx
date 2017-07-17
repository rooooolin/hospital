<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pushtest.aspx.cs" Inherits="hospital.pushtest" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="APPID"></asp:Label><asp:TextBox ID="APPID" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="APPKEY"></asp:Label><asp:TextBox ID="APPKEY" runat="server"></asp:TextBox><br />
         <asp:Label ID="Label4" runat="server" Text="MASTERSECRET"></asp:Label><asp:TextBox ID="MASTERSECRET" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label8" runat="server" Text="ALIAS"></asp:Label><asp:TextBox ID="ALIAS" runat="server"></asp:TextBox><br />
         <asp:Label ID="Label5" runat="server" Text="通知标题"></asp:Label><asp:TextBox ID="Title" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label6" runat="server" Text="通知内容"></asp:Label><asp:TextBox ID="Text" runat="server"></asp:TextBox><br />
         <asp:Label ID="Label7" runat="server" Text="透传内容"></asp:Label><asp:TextBox ID="TransmissionContent" runat="server"></asp:TextBox><br />

        <asp:Button ID="Button1" runat="server" Text="推送" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="结果"></asp:Label><br /><br /><br />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
