<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FollowRecordManage.aspx.cs" Inherits="hospital.Follow.FollowRecordManage" %>

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
    <asp:Repeater runat="server" ID="FollowRecordRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="20%">标题</th>
                    <th width="20%">随访时间</th>
                    <th width="20%">随访表类型</th>
                    <th width="10%">随访发起人</th>
                    <th width="10%">目标患者</th>
                    
                    
                    <th width="10%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="FollowCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="ID" runat="server" Text='<%#Eval("ID")%>'></asp:Label></td>
                     <td width="20%"><asp:Label ID="record_title" runat="server" Text='<%#Eval("record_title") %>'></asp:Label></td>
                    <td width="20%"><asp:Label ID="follow_time" runat="server" Text='<%#Eval("follow_time") %>'></asp:Label></td>
                    <td width="20%"><asp:Label ID="table_name_iden" runat="server" Text='<%#get_table((string)Eval("table_name_iden")) %>'></asp:Label></td>
                  <td width="10%"><asp:Label ID="doctor_name" runat="server" Text='<%#Eval("doctor_name") %>'></asp:Label></td> 
                    <td width="10%"><asp:Label ID="user_name" runat="server" Text='<%#Eval("user_name") %>'></asp:Label></td>
                    <td width="10%"><a href="CheckFollowRecord.aspx?id=<%#get_table_id((string)Eval("table_name_iden")) %>&p_id=<%#Eval("p_id") %>&record_id=<%#Eval("ID")%>" target="_blank">查看</a>&nbsp;&nbsp;&nbsp;&nbsp;
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
