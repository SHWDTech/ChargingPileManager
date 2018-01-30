<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faqdetails.aspx.cs" Inherits="ZDEnterprise.Web.json.faq.faqdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server" id="titles"></title>
    <meta name="viewport" content="initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            font-variant: "微软雅黑";
        }
        .issue
        {
            width: 90%;
            margin: 0 auto;
            margin-top: 25px;
        }
        .answer
        {
            width: 90%;
            margin: 0 auto;
            margin-top: 15px;
        }
        .issueimg
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <img src="/img/faq_help.jpg" alt="Alternate Text" class="issueimg" />
    <hr />
    <h4 class="issue" runat="server" id="issue">
    </h4>
    <div class="answer" runat="server" id="answer">
    </div>
    </form>
</body>
</html>
