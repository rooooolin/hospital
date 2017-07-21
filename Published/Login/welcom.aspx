<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcom.aspx.cs" Inherits="hospital.Login.welcom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" media="screen" />
	<link href="../Css/font-awesome.min.css" rel="stylesheet" media="screen" />
	<link href="../Css/stylewelcome.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jquery.circliful.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Js/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../Js/jquery.circliful.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
		<div class="pad20">

			<div class="stats-cont row mart20">
				<div class="col-sm-3 ">
					<div class="stats-panel stats-blue clear">
						<div class="left"><img src="images/stats1.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>医生总数</p>
							<p class="stats-num"><a href="#"><asp:Label ID="DoctorCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="../Users/DoctorList.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-red clear">
						<div class="left"><img src="images/stats2.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>用户总数</p>
							<p class="stats-num"><a href="#"><asp:Label ID="UserCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="../Users/UserList.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-green clear">
						<div class="left"><img src="images/stats3.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>随访样式表</p>
							<p class="stats-num"><a href="#"><asp:Label ID="FollowTableCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="../Follow/FollowManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-purple clear">
						<div class="left"><img src="images/stats4.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>病例数量</p>
							<p class="stats-num"><a href="#"><asp:Label ID="CaseCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="../Case/CaseManage.aspx"  target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
			</div>

			<div class="chart mart20">
				<div class="tit1 clear">
					<span class="left txt-left txt-red"><i class="fa fa-share-alt"></i>随访统计</span>
					<div class="right chart-tit-date">
						
					</div>
				</div>

				<div class="padt10">
					<div class="chart-tag"><a href="#" class="active">日随访量</a><a href="#">月随访量</a></div>
					<div class="chart-box padt10">
						<div id="chart-container" class="chart-container"></div>
					</div>
				</div>
			</div>

			<div class="sales-list row mart20">
				<div class="col-sm-9">
					<div class="pad20 bgf">
						<div class="tit1 clear">
							<span class="left txt-left txt-blue"><i class="ico i-rank"></i>最新添加</span>
							<div class="right ">
								
							</div>
						</div>
						<div class="tab">
						
							<ul class="nav nav-tabs sale-tabs" role="tablist">
								<li class="active"><a href="#tab1"  role="tab" data-toggle="tab">注册医生</a></li>
                                
								<li><a href="#tab2"  role="tab" data-toggle="tab">注册用户</a></li>
								<li><a href="#tab3"  role="tab" data-toggle="tab">随访样式</a></li>
								<li><a href="#tab4"  role="tab" data-toggle="tab">病例列表</a></li>
								
							</ul>

						
							<div class="tab-content">
								
                                <div role="tabpanel" class="tab-pane active" id="tab1">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                            <asp:Repeater runat="server" ID="DoctorRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">医生ID</td>
												<td width="30%">姓名</td>
												<td width="15%">手机号</td>
												<td width="15%">科室</td>
												<td width="20%">用户状态</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate><ItemTemplate>
											<tr>
												<td><%#Eval("ID")%></td>
												<td><%#Eval("doctor_name") %></td>
												<td><%#Eval("doctor_telphone") %></td>
												<td><%#Eval("doctor_depart_id") %></td>
												<td><asp:Label ID="doctor_state" runat="server" Text='<%# Int32.Parse(Eval("doctor_state").ToString())==1?"使用中":"X 已禁用" %>'></asp:Label></td>
												<td><a href="#">查看</a></td>
											</tr>
                    </ItemTemplate></asp:Repeater>
											
										</table>
									</div>
								</div>

							
								<div role="tabpanel" class="tab-pane" id="tab2">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                                            <asp:Repeater runat="server" ID="UserRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">用户ID</td>
												<td width="30%">用户名</td>
												<td width="25%">病号</td>
												<td width="25%">用户状态</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate>
                                                                <ItemTemplate>
											<tr>
												<td><%#Eval("ID")%></td>
												<td><%#Eval("user_name") %></td>
												<td><%#Eval("user_patient_number") %></td>
												<td><asp:Label ID="user_state" runat="server" Text='<%# Int32.Parse(Eval("user_state").ToString())==1?"使用中":"X 已禁用" %>'></asp:Label></td>
												<td><a href="../Case/AddCase.aspx?id=<%#Eval("ID") %>">添加病例</a>&nbsp;&nbsp;</td>
											</tr>
                                                                    </ItemTemplate></asp:Repeater>
											
										</table>
									</div>
								</div>
							
								<div role="tabpanel" class="tab-pane" id="tab3">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                            <asp:Repeater runat="server" ID="FollowRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">ID</td>
												<td width="20%">随访表名称</td>
												<td width="10%">存储标识</td>
                                                <td width="40%">字段值</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate><ItemTemplate>
											<tr>
												<td><%#Eval("ID")%></td>
												<td><%#Eval("follow_name") %></td>
												<td><%#Eval("table_name") %></td>
                                                <td><asp:Label ID="json_filed" runat="server" Text='<%#get_filed((string)Eval("json_filed")) %>'></asp:Label></td>
												<td><a href="../Follow/TextJump.aspx?id=<%#Eval("ID") %>&follow_name=<%# get_encode((string)Eval("follow_name")) %>&role_id=2" target="_blank">添加随访记录</a></td>
											</tr>
                    </ItemTemplate></asp:Repeater>
											
										</table>
									</div>
								</div>
							
								

                                <div role="tabpanel" class="tab-pane" id="tab4">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                            <asp:Repeater runat="server" ID="CaseRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">ID</td>
												<td width="10%">病人ID</td>
												<td width="15%">姓名</td>
												<td width="15%">医生ID</td>
												<td width="10%">医生姓名</td>
                                                <td width="30%">病例地址</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate>
                                                <ItemTemplate>
											<tr>
												<td><%#Eval("ID") %></td>
												<td><%#Eval("p_id") %></td>
												<td><%#Eval("user_name") %></td>
												<td><%#Eval("d_id") %></td>
												<td><%#Eval("doctor_name") %></td>
                                                <td><%#Eval("case_path") %></td>
												<td><a href="../<%#Eval("case_path") %>" target="_blank">查看病例</a></td>
											</tr>
                                                     </ItemTemplate>
            </asp:Repeater>
											
										</table>
									</div>
								</div>

								
							</div>
						</div>
					</div>
				</div>
				<div class="col-sm-3">
					<div class="pad20 bgf">
						<div class="tit1 clear">
							<span class="left txt-left txt-blue"><i class="ico i-rank"></i>系统状态</span>
						</div>
						<div class="report-list ">
                            <asp:Label ID="IpAddress" runat="server" Text="Label"></asp:Label><br /><br /><br />
							<asp:Label ID="serverName" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            <asp:Label ID="serverNet" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            <asp:Label ID="serverSession" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            <asp:Label ID="serverIIS" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            
						</div>
					</div>
				</div>
			</div>



		</div>

		
	</div>



        <script src="../Js/jquery-1.9.1.min.js"></script> 
	<script src="../Js/bootstrap.min.js"></script> 
	<script src="../Js/highcharts.js"></script> 
	<script src="../Js/admin.js"></script>
	<script type="text/javascript">
	    $(function () {
	        $('#chart-container').highcharts({
	            chart: {
	                type: 'area',
	                spacingBottom: 30
	            },
	            title: {
	                text: ''
	            },
	            subtitle: {
	                text: '',
	                floating: true,
	                align: 'right',
	                verticalAlign: 'bottom',
	                y: 15
	            },
	            legend: {
	                layout: 'vertical',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 150,
	                y: 100,
	                floating: true,
	                borderWidth: 1,
	                backgroundColor: '#FFFFFF'
	            },
	            xAxis: {
	                categories: [<%=RowsDay%>]
	            },
	            yAxis: {
	                title: {
	                    text: '随访数'
	                },
	                labels: {
	                    formatter: function () {
	                        return this.value;
	                    }
	                }
	            },
	            tooltip: {
	                formatter: function () {
	                    return '<b>' + this.series.name + '</b><br/>' +
                        this.x + ': ' + this.y;
	                }
	            },
	            plotOptions: {
	                area: {
	                    fillOpacity: 0.5
	                }
	            },
	            credits: {
	                enabled: false
	            },
	            series: [{
	                name: '数量',
	                data: [<%=FollowNum%>]
	            }]
	        });
	    });
</script>
    </form>
</body>
</html>
