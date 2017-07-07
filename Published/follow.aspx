<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="follow.aspx.cs" Inherits="hospital.follow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <title>添加随访记录</title>
    <link rel="stylesheet" href="../Js/dist/pikaday-package.css" />
    <link href="Css/form.min.css" type="text/css" rel="stylesheet" />
  <script src="../Js/dist/dependencies/pikaday-responsive-modernizr.js"></script>
    <style type="text/css">
        #bottom_info {
            position: relative;
            top: -3.8em;
            margin: 0 0.5em;
            padding: .8em 0;
            text-align: center;
            background-color: #18c178;
            color: #ffffff;
            border: medium hidden;
            border-radius: 0.1em;
            box-sizing: border-box;
            display: none;
        }

            #bottom_info a {
            
                width: 100%;
                text-decoration: none;
                outline: none;
            }

        #bottom_jump {
            position: relative;
            top: -3em;
            margin: 0 0.5em;
            padding: .8em 0;
            text-align: center;
            background-color: #62A9E3;
            color: #ffffff;
            border: medium hidden;
            border-radius: 0.1em;
            box-sizing: border-box;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form_ctrl page_head">
            <h2>添加随访记录</h2>
        </div>
        <div class="form_ctrl page_text">
            <p> </p>
        </div>
        <div class="form_ctrl form_select">
            <label class="ctrl_title">推送目标<asp:RadioButtonList ID="RadioTarget" OnSelectedIndexChanged="RadioTarget_SelectedIndexChanged" AutoPostBack="true" runat="server">
                <asp:ListItem selected="true">单人</asp:ListItem>
                <asp:ListItem>组员</asp:ListItem>
   
                                          </asp:RadioButtonList>
            <asp:DropDownList ID="FollowTarget" runat="server"  AutoPostBack="true" ></asp:DropDownList>
            
            <div></div>
        </div>
        <div class="form_ctrl input_text">
            <label class="ctrl_title">标题</label>
           <asp:TextBox type="text" ID="record_title" placeholder=" 请输入标题"   runat="server"></asp:TextBox>
            <label style="color:red">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="标题不能为空！" ControlToValidate="record_title"></asp:RequiredFieldValidator></label>
        </div>
        <div class="form_ctrl input_text">
            <label class="ctrl_title">随访时间</label>
           <asp:TextBox type="text" ID="follow_time"   placeholder=" 请输入时间"  runat="server"></asp:TextBox>
            <label style="color:red">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="随访时间不能为空！" ControlToValidate="follow_time"></asp:RequiredFieldValidator></label>
        </div>
        <script src="../Js/dist/dependencies/jquery.min.js"></script>
<script src="../Js/dist/dependencies/moment.min.js"></script>
<script src="../Js/dist/dependencies/pikaday.min.js"></script>
<script src="../Js/dist/pikaday-responsive.js"></script>

<script>
    var $date1 = $("#follow_time");
    var instance1 = pikadayResponsive($date1);
    $date1.on("change", function () {
        $("#output1").html($(this).val());
    });

    $("#clear").click(function () {
        instance3.setDate(null);
    });

    $("#today").click(function () {
        instance3.setDate(moment());
    });

</script>
         <asp:Panel ID="Controls_list" runat="server"></asp:Panel>
        <div class="form_ctrl form_submit">
            <asp:Button ID="SubmitBtn" type="submit" runat="server" Text="提交" OnClick="SubmitBtn_Click" />
           
        </div>
    </form>
</body>
</html>
