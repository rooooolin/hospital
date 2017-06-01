<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseManage.aspx.cs" Inherits="hospital.Case.CaseManage" %>

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
            
            <span class="posi"><b>当前位置：<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath> </b></span>

        </div>
        <asp:Repeater runat="server" ID="CaseRepeter">
            <HeaderTemplate>
            <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
                <caption></caption>
                
                <tr>
                    <th width="5%"><span class="btn_all" onclick="checkAll(this);">全选</span></th>
                    <th width="5%">ID</th>
                    <th width="10%">病人ID</th>
                    <th width="15%">姓名</th>
                    <th width="15%">病号</th>
                    <th width="10%">医生ID</th>
                    <th width="15%">医生姓名</th>
                    <th width="10%">病例地址</th>
                    
                    <th width="15%">操作</th>
                </tr>
                </table>
                </HeaderTemplate>
            <ItemTemplate>
            <table id="mytable" cellspacing="2" summary="The technical specifications of the Apple PowerMac G5 series">
                <tr>
                    <td width="5%"><asp:CheckBox CssClass="checkall" ID="CaseCheck" runat="server" /></td>
                    <td width="5%"><asp:Label ID="ID" runat="server" Text='<%#Eval("ID")%>'></asp:Label></td>
                     <td width="10%"><asp:Label ID="user_ID" runat="server" Text='<%#Eval("p_id") %>'></asp:Label></td>
                    <td width="15%"><asp:Label ID="user_name" runat="server" Text='<%#Eval("user_name") %>'></asp:Label></td>
                    <td width="15%"><asp:Label ID="user_patient_number" runat="server" Text='<%#Eval("user_patient_number") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="d_id" runat="server" text='<%#Eval("d_id") %>'></asp:Label></td>
                    <td width="15%"><asp:Label ID="doctor_name" runat="server"  Text='<%#Eval("doctor_name") %>'></asp:Label></td>
                    <td width="10%"><asp:Label ID="case_path" runat="server" Text='<%#Eval("case_path") %>'></asp:Label></td>
                    <td width="15%"><a href="../<%#Eval("case_path") %>" target="_blank">查看病例</a>&nbsp;&nbsp;<a href="ModifyCase.aspx?case_id=<%#Eval("ID") %>&p_id=<%#Eval("p_id") %>&d_id=<%#Eval("d_id") %>">修改</a>&nbsp;&nbsp;</td>
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
