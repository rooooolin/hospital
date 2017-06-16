<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFollow.aspx.cs" Inherits="hospital.Follow.AddFollow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="../Css/add.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Css/bootstrap.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_from_aoto">
            <div class="control-group">
                        <label class="laber_from">随访表名称</label>
                        <div class="controls">
                            <asp:TextBox ID="follow_name" placeholder=" 请输入名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p>
                        </div>
                    </div>
            <div class="control-group">
                        <label class="laber_from">标识</label>
                        <div class="controls">
                            <asp:TextBox ID="table_name" placeholder=" 请输入英文标识（10字符以内）" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p>
                        </div>
                    </div>
           
            <div class="control-group">
                <label class="laber_from"></label>
                <div class="controls">
                    <asp:Button ID="ShowBlockbtn" runat="server" class="btn btn-success" Text="添加控件" Style="width: 80px; font-size:12px; height:30px;" OnClientClick="return ShowBlock();" ></asp:Button>
                    <asp:Button ID="ClearControls" runat="server" class="btn btn-success" Text="清空" Style="width: 80px; margin-left:20px; font-size:12px; height:30px;" OnClick="ClearControls_Click"></asp:Button>
                </div>
            </div>
           
         <div class="control-group" style=" width:500px; margin-left:30px; border: #ccc solid 5px;">
              <div  class="control-group" style="width:100%;">
                <div style="float:left;width:60px">
                     <asp:Panel ID="LabelPanel" runat="server"></asp:Panel>
                </div>
                <div style="float:left;width:60%;margin-left:20px;">
                     <asp:Panel ID="ValuePanel" runat="server"> </asp:Panel>
                </div>
                 
            </div>
             <div class="control-group"></div>
         </div>
           

            <div class="control-group">
                <label class="laber_from"></label>
                <div class="controls">
                    <asp:Button ID="Addbtn" runat="server" class="btn btn-success" Text="添加随访表" Style="width: 120px;" OnClick="Addbtn_Click"/>
                    
                </div>
            </div>
        </div>

        <div id="divNewBlock" style="border: solid 5px; background-color:#fff; padding: 10px; width: 600px; z-index: 1001; position: absolute; display: none; top: 30%; left: 30%; margin: -50px;">
            <div style="padding: 3px 15px 3px 15px; text-align: left; vertical-align: middle;">
                <div>
                    <asp:Button ID="BttCancel" runat="server" Text="关闭" BorderStyle="None" Style="float: right; width: 50px;" OnClientClick="return HideBlock();" />
                </div>
                <div>
                    <div class="control-group">
                        <label class="laber_from">控件名称</label>
                        <div class="controls">
                            <asp:TextBox ID="ControlName" placeholder=" 请输入名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="laber_from">控件ID</label>
                        <div class="controls">
                            <asp:TextBox ID="ControlID" placeholder=" 请输入ID(英文小写)" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="laber_from">候选项</label>
                        <div class="controls">
                            <asp:TextBox ID="TxtCandidate"  placeholder="格式：男|女|不男不女（下拉框必填项）" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="laber_from">控件类型</label>
                        <div class="controls">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ControlType" runat="server" Style="width: 22%; height: 35px; border: 1px solid #ccc;" AutoPostBack="true" >
                                        <asp:ListItem Value="1" Selected="True" Text="单行输入框"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="多行输入框"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="下拉框"></asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                                
                            </asp:UpdatePanel>
                            <p class="help-block"></p>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="laber_from"></label>
                        <div class="controls">
                            <asp:Button ID="AddControl" runat="server" class="btn btn-success" Text="添加" Style="width: 120px;" OnClick="AddControl_Click"/>
                        </div>
                    </div>

                </div>
            </div>
        </div>


        <script type="text/javascript" language="javascript">
            function HideBlock() {
                document.getElementById("divNewBlock").style.display = "none";
                return false;
            }


            function ShowBlock() {
                var set = SetBlock();
                document.getElementById("divNewBlock").style.display = "";
                return false;
            }


            function SetBlock() {
                var top = document.body.scrollTop;
                var left = document.body.scrollLeft;
                var height = document.body.clientHeight;
                var width = document.body.clientWidth;


                if (top == 0 && left == 0 && height == 0 && width == 0) {
                    top = document.documentElement.scrollTop;
                    left = document.documentElement.scrollLeft;
                    height = document.documentElement.clientHeight;
                    width = document.documentElement.clientWidth;
                }
                return { top: top, left: left, height: height, width: width };
            }


            function Operate() {
                return false;
            }
        </script>
    </form>

</body>
</html>
