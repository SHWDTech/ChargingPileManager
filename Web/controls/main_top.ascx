<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main_top.ascx.cs" Inherits="ZDEnterprise.Web.controls.main_top" %>
<div class="navbar navbar-default" id="navbar">
    <div style="display: none">
        <input type="text" id="txtOrderId" value="<%=orderId %>" />
    </div>
    <script type="text/javascript" src="assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="layer/layer.js"></script>
    <script>
        function funcTest() {
            //window.setInterval("timelyFun()", 10000);
        }
        function timelyFun() {

            $.ajax({
                type: "get",
                cache: false,
                url: "ajax.aspx",
                dataType: "json",
                data: "m=1&orderId=" + $('#txtOrderId').val(),
                success: function (data) {
                    if (data.sta == 1) {
                        $('#txtOrderId').val(data.orderId);

                        $('<audio id="chatAudio"><source src="img/notify.mp3" type="audio/mpeg"></audio>').appendTo('body');
                        $('#chatAudio')[0].play();
                        layer.msg('您有新的订单来啦，请及时处理哦', function () {

                        });
                    }
                },
                async: false
            })

        }
        window.onload = funcTest;

    </script>
    <script type="text/javascript">
        try { ace.settings.check('navbar', 'fixed') } catch (e) { }
    </script>
    <div class="navbar-container" id="navbar-container">
        <div class="navbar-header pull-left">
            <a class="navbar-brand"><small>
                <%--<i class="icon-leaf"></i>--%>
                <%=websitetitle %>
            </small></a>
            <!-- /.brand -->
        </div>
        <!-- /.navbar-header -->
        <div class="navbar-header pull-right" role="navigation">
            <ul class="nav ace-nav">
                <li class="light-blue"><a data-toggle="dropdown" href="#" class="dropdown-toggle">
                    <img class="nav-user-photo" src="<%=logo %>" alt="Jason's Photo" />
                    <span class="user-info"><small>欢迎光临,</small>
                        <%=name %>
                    </span><i class="icon-caret-down"></i></a>
                    <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                        <li><a href="password.aspx"><i class="icon-pencil"></i>修改密码 </a></li>
                        <li><a href="personal.aspx"><i class="icon-user"></i>个人资料 </a></li>
                        <li class="divider"></li>
                        <li><a href="out.aspx"><i class="icon-off"></i>退出 </a></li>
                    </ul>
                </li>
            </ul>
            <!-- /.ace-nav -->
        </div>
        <!-- /.navbar-header -->
    </div>
    <!-- /.container -->
</div>
