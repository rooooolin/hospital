<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FollowView.aspx.cs" Inherits="hospital.FollowView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Css/style.css" />
</head>
<body>
    <form id="form1" runat="server"  width="100%" class="bootstrap-frm">
         <h1>查看随访</h1>
    <label>
            <label class="layer">标题</label>
            <asp:TextBox ID="record_title" type="text"  runat="server" ReadOnly="true" Style="width:100%"></asp:TextBox>
           
        </label>
        <label>
            <label class="layer">随访时间</label>
          <asp:TextBox ID="follow_time" type="text"  runat="server" ReadOnly="true" Style="width:100%"></asp:TextBox> 
            
        </label>
        
         <asp:Panel ID="Controls_list" runat="server"></asp:Panel>
    </form>
</body>
</html>
