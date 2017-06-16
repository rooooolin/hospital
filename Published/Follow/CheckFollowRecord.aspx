<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckFollowRecord.aspx.cs" Inherits="hospital.Follow.CheckFollowRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Css/add.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Css/bootstrap.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="control-group">
                        <label class="laber_from">随访目标</label>
                        <div class="controls">
                            <asp:Label ID="FollowTarget" runat="server" Text="Label"></asp:Label><p class="help-block"></p>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="control-group">
                <label class="laber_from">标题</label>
                <div class="controls">
                    <asp:Label ID="record_title" runat="server" Text="Label"></asp:Label><p class="help-block"></p>
                </div>
            </div>
            <div class="control-group">
                <label class="laber_from">随访时间</label>
                <div class="controls">
                    <asp:Label ID="follow_time" runat="server" Text="Label"></asp:Label><p class="help-block"></p>
                </div>
            </div>
            <asp:Panel ID="Controls_list" runat="server"></asp:Panel>
           
        </div>
    </form>
</body>
</html>
