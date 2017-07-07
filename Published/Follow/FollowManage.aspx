<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FollowManage.aspx.cs" Inherits="hospital.Follow.FollowManage" %>

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
    <div>
        <div class="navi">
            <span class="option">
               </span>
            <span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span>

        </div>
    <asp:Repeater runat="server" ID="FollowRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="10%">随访表名称</th>
                    <th width="10%">存储标识</th>
                    <th width="60%">字段值</th>
                    
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="FollowCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="ID" runat="server" Text='<%#Eval("ID")%>'></asp:Label></td>
                     <td width="10%"><asp:Label ID="follow_name" runat="server" Text='<%#Eval("follow_name") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="table_name" runat="server" Text='<%#Eval("table_name") %>'></asp:Label></td>
                    <td width="60%"><asp:Label ID="json_filed" runat="server" Text='<%#get_filed((string)Eval("json_filed")) %>'></asp:Label></td>
                   
                    <td width="10%"><a href="TextJump.aspx?id=<%#Eval("ID") %>&follow_name=<%# get_encode((string)Eval("follow_name")) %>&role_id=1" target="_blank">添加随访记录</a>&nbsp;&nbsp;&nbsp;&nbsp;
                       </td>
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
