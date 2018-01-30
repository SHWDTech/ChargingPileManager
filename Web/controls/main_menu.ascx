<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main_menu.ascx.cs" Inherits="ZDEnterprise.Web.controls.main_menu" %>


				<a class="menu-toggler" id="menu-toggler" href="#">
					<span class="menu-text"></span>
				</a>

				<div class="sidebar" id="sidebar">
					<script type="text/javascript">
						try{ace.settings.check('sidebar' , 'fixed')}catch(e){}
					</script>

					<div class="sidebar-shortcuts" id="sidebar-shortcuts">
						<div class="sidebar-shortcuts-large" id="sidebar-shortcuts-large">
						
							<button class="btn btn-success" title="主页" onclick="window.location.href='main.aspx'">
								<i class="icon-home"></i>
							</button>

							<button class="btn btn-info" title="修改密码" onclick="window.location.href='password.aspx'">
								<i class="icon-pencil"></i>
							</button>

							<button class="btn btn-warning" title="个人资料" onclick="window.location.href='personal.aspx'">
								<i class="icon-user"></i>
							</button>

							<button class="btn btn-danger" title="退出" onclick="window.location.href='out.aspx'">
								<i class="icon-off"></i>
							</button>
							
						</div>

						<div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini">
							<span class="btn btn-success"></span>

							<span class="btn btn-info"></span>

							<span class="btn btn-warning"></span>

							<span class="btn btn-danger"></span>
						</div>
					</div><!-- #sidebar-shortcuts -->

					<ul class="nav nav-list">
						<li <%=menuCss1=="1" ? "class=\"active\"" : "" %>>
							<a href="<%=VirturlPath %>/main.aspx"><i class="icon-dashboard"></i><span class="menu-text"> 控制台 </span></a>
						</li>
						
                        <%=menuString %>
 
					</ul>
					
					<!-- /.nav-list -->

					<div class="sidebar-collapse" id="sidebar-collapse">
						<i class="icon-double-angle-left" data-icon1="icon-double-angle-left" data-icon2="icon-double-angle-right"></i>
					</div>

					<script type="text/javascript">
						try{ace.settings.check('sidebar' , 'collapsed')}catch(e){}
					</script>
				</div>