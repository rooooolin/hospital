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
   <link rel="stylesheet" type="text/css" href="Css/style.css" />
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
    <form id="form1" runat="server" width="100%" class="bootstrap-frm">
      <h1>随访表</h1>
       
        <label>
            <label class="layer">标题</label>
            <asp:TextBox ID="record_title" type="text"  runat="server" ReadOnly="true" Style="width:100%"></asp:TextBox>
           
        </label>
        <label>
            <label class="layer">随访时间</label>
          <asp:TextBox ID="follow_time" type="text"  runat="server" ReadOnly="true" Style="width:100%"></asp:TextBox> 
            
        </label>
        
         <asp:Panel ID="Controls_list" runat="server"></asp:Panel>
        <div>
            <asp:Button ID="SubmitBtn" type="submit" runat="server" Text="提交" OnClick="SubmitBtn_Click" />
           
        </div>
    </form>
</body>
</html>
