<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ZDEnterprise.Web.login" %>


<!DOCTYPE html>
<html>
<head runat="server">
  <title><%=websitetitle %></title>
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link href="assets/login/css/bootstrap.css" rel="stylesheet">
  <link href="assets/login/css/lock.css" rel="stylesheet">
  <link href="assets/login/css/animate.css" rel="stylesheet">
  <link href="assets/login/css/font-awesome.css" rel="stylesheet">
  <link rel="stylesheet" href="assets/css/font-awesome.min.css" />	
</head>

<body>
<form runat="server" id="form1">
    <div class="logo">
      <h4><a><img src="assets/login/images/logoed.png" alt=""></a></h4>
    </div>
    <div class="lock-holder">      
          <div class="form-group pull-left input-username">
                   <div class="input-group">
                    <asp:TextBox runat="server" ID="txtCode" class="form-control" placeholder="登录帐号"></asp:TextBox>
                    <span class="input-group-addon"><i class="fa fa-user"></i></span> </div>
          </div>
          <i class="fa fa-ellipsis-h dot-left"></i>
          <i class="fa fa-ellipsis-h dot-right"></i>
          <div class="form-group pull-right input-password">
                   <div class="input-group">
                    <asp:TextBox runat="server" ID="txtPwd" class="form-control " TextMode="Password" placeholder="登录密码"></asp:TextBox>
                    <span class="input-group-addon"><i class="fa fa-key"></i></span> </div>
          </div>    
    </div>
    <div class="avatar">
           <img id="imgLogo" src="Upload/logo/zw.png" alt="">
    </div> 
    <div class="submit">
    <button id="btn1" type="button" class="btn btn-success btn-submit"><i class="fa fa-unlock"></i> 登录</button>   
    </div>
</form>
</body>
<script src="assets/login/js/jquery/jquery.js"></script>
<script src="assets/login/js/bootstrap.min.js"></script>
<script src="assets/login/js/bootstrap-progressbar.js"></script>
<script type="text/javascript">

    $(document).ready(function() {


        $("body").keypress(function(e) {
            if (e.which == 13) {
                $('.btn-submit').click();
            }

        });

        var strCookie = document.cookie;
        var arrCookie = strCookie.split("; ");
        var logo;
        var code;
        //遍历cookie数组，处理每个cookie对 
        for (var i = 0; i < arrCookie.length; i++) {
            var arr = arrCookie[i].split("=");
            //找到名称为logo的cookie，并返回它的值
            if ("logo" == arr[0]) {
                logo = arr[1];
                break;
            }
        }
        for (var i = 0; i < arrCookie.length; i++) {
            var arr = arrCookie[i].split("=");
            //找到名称为logo的cookie，并返回它的值
            if ("code" == arr[0]) {
                code = arr[1];
                break;
            }
        }
        if (code != null && code != "") {
            $('#txtCode').val(code);
            $('#txtPwd').focus();
        }
        else {
            $('#txtCode').focus();
        }
        if (logo == null || logo == "") {
            $("#imgLogo").attr("src", "<%=VirturlPath %>/Upload/logo/zw.png");
        }
        else {
            $("#imgLogo").attr("src", "<%=VirturlPath %>" + logo);

        }

        $('.btn-submit').click(function(e) {
            var login = false;
            $.ajax({
                type: "get",
                cache: false,
                url: "login.aspx",
                dataType: "json",
                data: "m=1&code=" + $('#txtCode').val() + "&pwd=" + $('#txtPwd').val(),
                success: function(data) {
                    if (data.sta == 1) {
                        login = true;



                        //获取当前时间 
                        var date = new Date();
                        var expiresDays = 10;
                        //将date设置为10天以后的时间 
                        date.setTime(date.getTime() + expiresDays * 24 * 3600 * 1000);
                        //将userId和userName两个cookie设置为10天后过期
                        var d = data.logo;
                        document.cookie = "logo=" + d + "; expires=" + date.toGMTString();
                        document.cookie = "code=" + $('#txtCode').val() + "; expires=" + date.toGMTString();


                    }
                },
                async: false
            })


            if (login == true) {
                $('.input-username,dot-left').addClass('animated fadeOutRight');
                $('.input-password,dot-right').addClass('animated fadeOutLeft');
                $('.btn-submit').addClass('animated fadeOutUp');
                setTimeout(function() {
                    $('.avatar').addClass('avatar-top');
                    //$('.submit').html('<i class="fa fa-spinner fa-spin text-white"></i>');
                    $('.submit').html('<div class="progress"><div class="progress-bar progress-bar-success" aria-valuetransitiongoal="100"></div></div>');
                    $('.progress .progress-bar').progressbar();
                },
		500);

                setTimeout(function() {
                    window.location.href = 'main.aspx';
                },
		1500);
            }
            else {
                alert("用户名或密码错误!");
            }


        });
    });
   
</script>

</html>
 