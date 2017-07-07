<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="followp.aspx.cs" Inherits="hospital.followp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <title></title>
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
       
        <div class="form_ctrl input_text">
            <label class="ctrl_title">标题</label>
            <asp:Label ID="record_title" type="text" runat="server" Text="Label"></asp:Label>
           
        </div>
        <div class="form_ctrl input_text">
            <label class="ctrl_title">随访时间</label>
            <asp:Label ID="follow_time" type="text" runat="server" Text=""></asp:Label>
           
            
        </div>
        
         <asp:Panel ID="Controls_list" runat="server"></asp:Panel>
        <div class="form_ctrl form_submit">
            <asp:Button ID="SubmitBtn" type="submit" runat="server" Text="提交" OnClick="SubmitBtn_Click" />
           
        </div>
    </form>
</body>
</html>
