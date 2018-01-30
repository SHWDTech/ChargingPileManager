<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="role_qx.aspx.cs" Inherits="ZDEnterprise.Web.role_qx" %>

<%@ Register Src="controls/main_top.ascx" TagName="main_top" TagPrefix="uc1" %>
<%@ Register Src="controls/main_menu.ascx" TagName="main_menu" TagPrefix="uc2" %>
<%@ Register Src="controls/main_style.ascx" TagName="main_style" TagPrefix="uc3" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>
        <%=websitetitle%></title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- basic styles -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <!-- page specific plugin styles -->
    <!-- fonts -->
    <!-- ace styles -->
    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="assets/css/ace-skins.min.css" />
    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
    <!-- inline styles related to this page -->
    <!-- ace settings handler -->

    <script src="assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
</head>
<body>
<form class="form-horizontal" role="form" runat="server" id="form1"  >
								<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
								<asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>
    <uc1:main_top ID="main_top" runat="server" />
    <div class="main-container" id="main-container">

        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <uc2:main_menu ID="main_menu" runat="server" />
            <div class="main-content">
                <div class="breadcrumbs" id="breadcrumbs">

                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb">
                        <li><i class="icon-home home-icon"></i><a href="main.aspx">首页</a> </li>
                        <li><a>系统管理</a> </li>
                        <li class="active">角色管理</li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>
                <div class="page-content">
                    <div class="page-header">
                        <h1>
                            角色管理 <small><i class="icon-double-angle-right"></i>权限分配（<%=roleName %>） </small>
                        </h1>
                    </div>
                    <!-- /.page-header -->
                    <div class="row">
                        <div class="col-xs-12">
                        <div class="row">
                            <!-- PAGE CONTENT BEGINS -->
                            
                                <%=data %>
                            
                            <!-- PAGE CONTENT ENDS -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->
            <uc3:main_style ID="main_style" runat="server" />
            <!-- /#ace-settings-container -->
        </div>
        <!-- /.main-container-inner -->
        <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse"><i class="icon-double-angle-up icon-only bigger-110">
        </i></a>
    </div>
    <!-- /.main-container -->
    <!-- basic scripts -->
    <!--[if !IE]> -->
    <!-- <![endif]-->
    <!--[if IE]>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<![endif]-->
    <!--[if !IE]> -->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>

    <!-- <![endif]-->
    <!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
</script>
<![endif]-->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>

    <script src="assets/js/bootstrap.min.js"></script>

    <script src="assets/js/typeahead-bs2.min.js"></script>

    <!-- page specific plugin scripts -->

 

    <script src="assets/js/fuelux/fuelux.tree.min.js"></script>

    <!-- ace scripts -->

    <script src="assets/js/ace-elements.min.js"></script>

    <script src="assets/js/ace.min.js"></script>

    <!-- inline scripts related to this page -->
    <script>
        function cbx(name, id, roleId) {
            var name1 = name;
            var name2 = name + "_i";
            if ($("#" + name1).attr('class') == "tree-item tree-selected") {
                $("#" + name1).attr('class', 'tree-item');
                $("#" + name2).attr('class', 'icon-remove');
                $.ajax({
                    type: "get",
                    cache: false,
                    url: "role_qx_edit.aspx",
                    dataType: "json",
                    data: "m=2&roleId=" + roleId + "&permissionsId=" + id,
                    success: function(data) {
                        if (data.sta == 1) {
                            //操作成功
                        }
                    },
                    async: false
                })
            }
            else {
                $("#" + name1).attr('class', 'tree-item tree-selected');
                $("#" + name2).attr('class', 'icon-ok');
                $.ajax({
                    type: "get",
                    cache: false,
                    url: "role_qx_edit.aspx",
                    dataType: "json",
                    data: "m=1&roleId=" + roleId + "&permissionsId=" + id,
                    success: function(data) {
                        if (data.sta == 1) {
                            //操作成功
                        }
                    },
                    async: false
                })
                
            }
       
        
        }
    </script>
 </ContentTemplate>
 </asp:UpdatePanel>
 </form>
</body>
</html>
