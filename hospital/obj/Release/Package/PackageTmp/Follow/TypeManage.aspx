<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeManage.aspx.cs" Inherits="hospital.Follow.TypeManage" %>

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
       
        <td width="100px" align="center">按疾病类型查看：</td>
        <td>
            <asp:DropDownList ID="DiseaseType" style="width:22%; height:35px; border:1px solid #ccc;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DiseaseType_SelectedIndexChanged"></asp:DropDownList>&nbsp;
           
        </td>
          
        </tr>
    </table>
    <div>
    <div class="navi">
            <span class="option">
               </span>
            <span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span>

        </div>
        <asp:Repeater runat="server" ID="TypeRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="30%">疾病</th>
                    <th width="50%">周期</th>
                    
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="TypeCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="ID" runat="server" Text='<%#Eval("CycleID")%>'></asp:Label></td>
                     <td width="30%"><asp:Label ID="disease_name" runat="server" Text='<%#Eval("disease_name") %>'></asp:Label></td>
                    <td width="50%"><asp:Label ID="cycle_name" runat="server" Text='<%#Eval("cycle_name") %>'></asp:Label></td>
                   
                    <td width="10%"><a href="AddCycle.aspx?disease_id=<%# Eval("DiseaseID") %>">添加周期</a>&nbsp;&nbsp;&nbsp;&nbsp;
                       </td>
                </tr>
               

            </table>
                </ItemTemplate>
            </asp:Repeater>
        <div class="btnmenu">
               
                  <asp:LinkButton ID="DelBtn" runat="server" onclick="DelBtn_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton> &nbsp;&nbsp;<a href="AddDisease.aspx">添加疾病</a> 
                 

        </div>
    </div>
         <div style=" width:95%; float:right; height:30px; margin-right:10px; margin-top:10px; text-align:right;">
                <div id="PageInfo" runat="server" class="anpager"></div>
            </div>
    </form>
</body>
</html>
