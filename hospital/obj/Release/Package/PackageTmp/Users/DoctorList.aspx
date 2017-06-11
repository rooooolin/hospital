<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorList.aspx.cs" Inherits="hospital.Users.DoctorList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link href="../css/PageIndex.css" type="text/css" rel="stylesheet" />
 
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
       
        <td width="100px" align="center">按用户状态查看：</td>
        <td>
            <asp:DropDownList ID="userState" runat="server" CssClass="select" 
                onselectedindexchanged="userState_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="1" Text="使用中"></asp:ListItem>
                <asp:ListItem Value="0" Text="已禁用"></asp:ListItem>
            </asp:DropDownList>&nbsp;
           
        </td>
          
        </tr>
    </table>
    <div>
        <div class="navi">
            <span class="option"><a href="#">添加用户</a></span>
            <span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span>

        </div>
    <asp:Repeater runat="server" ID="DoctorRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="8%">用户名</th>
                    <th width="7%">教育水平</th>
                    <th width="10%">职称</th>
                    <th width="10%">手机号</th>
                    <th width="10%">许可证</th>
                    <th width="5%">座机</th>
                     <th width="10%">Email</th>
                     <th width="10%">组织单位</th>
                     <th width="5%">科室</th>
                    <th width="5%">用户状态</th>
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="UserCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="ID" runat="server" Text='<%#Eval("ID")%>'></asp:Label></td>
                     <td width="8%"><asp:Label ID="doctor_name" runat="server" Text='<%#Eval("doctor_name") %>'></asp:Label></td>
                    <td width="7%"><asp:Label ID="doctor_education" runat="server" Text='<%#Eval("doctor_education") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="doctor_title" runat="server" Text='<%#Eval("doctor_title") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="doctor_telphone" runat="server" text='<%#Eval("doctor_telphone") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="doctor_license" runat="server"  Text='<%#Eval("doctor_license") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="doctor_phone" runat="server" Text='<%#Eval("doctor_phone") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="doctor_email" runat="server" Text='<%#Eval("doctor_email") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="doctor_unit" runat="server" Text='<%#Eval("doctor_unit") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="doctor_depart_id" runat="server" Text='<%#Eval("doctor_depart_id") %>'></asp:Label></td>
                    <td width="5%"><asp:Label ID="doctor_state" runat="server" Text='<%# Int32.Parse(Eval("doctor_state").ToString())==1?"使用中":"X 已禁用" %>'></asp:Label></td>
                    <td width="10%"><a href="ModifyInfo.aspx?id=<%#Eval("ID") %>">编辑</a>&nbsp;&nbsp;<asp:LinkButton Class="spebtn"  CommandName='<%#Eval("doctor_state") %>' CommandArgument='<%#Eval("ID")%>' ID="StateBtn" oncommand="StateBtn_Command" runat="server" Text='<%# Int32.Parse(Eval("doctor_state").ToString())==1?"禁用":"启用" %>'></asp:LinkButton></td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>
                 

        </div>
    </div>
        <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
    </form>
</body>
</html>
