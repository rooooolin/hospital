<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="hospital.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Css/index.css" type="text/css" media="screen" />

<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/tendina.js"></script>
<script type="text/javascript" src="js/common.js"></script>
</head>
<body>
     <div class="layout_top_header">
            <div style="float: left"><span style="font-size: 16px;line-height: 45px;padding-left: 20px;color: #8d8d8d">管理后台</span></div>
            <div id="ad_setting" class="ad_setting">
                <a class="ad_setting_a" href="javascript:;">
                    <i class="icon-user glyph-icon" style="font-size: 20px"></i>
                    <span>
                        <asp:Label ID="AdminName" runat="server" Text="Label"></asp:Label></span>
                    <i class="icon-chevron-down glyph-icon"></i>
                </a>
                <ul class="dropdown-menu-uu" style="display: none" id="ad_setting_ul">
                    <li class="ad_setting_ul_li"> <a href="" target="menuFrame"><i class="icon-user glyph-icon"></i> 修改信息 </a> </li>
                    <li class="ad_setting_ul_li"> <a href="" target="menuFrame"><i class="icon-cog glyph-icon"></i> 系统信息 </a> </li>
                    <li class="ad_setting_ul_li"><form id="form2" runat="server"><i class="icon-signout glyph-icon"></i><asp:LinkButton ID="LoginOut" OnClick="LoginOut_Click" runat="server" class="font-bold">退出</asp:LinkButton></form>
                       </li>
                </ul>
            </div>
    </div>
    <div class="layout_left_menu">
        <ul class="tendina" id="menu">
            <li class="childUlLi">
               <a href="#" target="menuFrame"><i class="glyph-icon icon-home"></i>用户管理</a>
                 <ul style="display: none;">
                     <li><a href="" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>管理员</a></li>
                    <li><a href="Users/UserList.aspx?user_roleid=2" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>医生</a></li>
                    <li><a href="Users/UserList.aspx?user_roleid=3" target="menuFrame"><i class="glyph-icon icon-chevron-right"></i>用户</a></li>
               
                </ul>
            </li>
        </ul>
    </div>
    <div id="layout_right_content" class="layout_right_content">
        <div class="route_bg">
            <a href="#">主页</a><i class="glyph-icon icon-chevron-right"></i>
            <a href="#">菜单管理</a>
        </div>
        <div class="mian_content">
            <div id="page_content">
                <iframe id="menuFrame" name="menuFrame" src="welcom.aspx" style="overflow:visible;" scrolling="yes" frameborder="no" height="100%" width="100%"></iframe>
            </div>
        </div>
    </div>
</body>
</html>
