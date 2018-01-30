<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderSetPrint.aspx.cs" Inherits="ZDEnterprise.Web.orderSetPrint" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>打印订单</title>
<link href="img/index.css" rel="stylesheet"><style>
#sp {  border-style:dotted; border-width:0px; border-right-width:1px; border-bottom-width:1px; margin:0; padding:0; border-spacing:0; font-size:17px;}
#sp td {  border-style:dotted; border-width:0px; border-top-width:1px; border-left-width:1px; padding:0; height:45px; font-size:17px; }
#sp th { border-style:dotted; border-width:0px; border-top-width:1px; border-left-width:1px; padding:0; background:#ffffff;height:45px; font-size:17px; }
dl{ height:40px; line-height:40px; font-size:17px;}
.printListInfo dt{ font-weight:500; font-size:17px;}
.td11 {  border-style:dotted; border-width:0px; border-top-width:1px; border-left-width:1px; padding:0; height:45px; font-size:17px; }
.printListInfo dd{ width:800px}
</style>
    
</head>
<body>
    <form id="form1" runat="server">
 
	<input type="hidden" id="onPage" value=""/>
	
 
<table width="1024" align="center">
<tr>
<td>
<div >
                    <!-- 发货单开始 -->
                    
	                    <div class="printListBox" style=" width:1024px">
	                        <div class="printListBoxT" style=" width:1024px">
	                            <div class="printListBoxB" style=" width:1024px">
	                                <div class="printListBoxMain" style=" width:980px"> 
	                                    <h2 class="printListBoxHead" style=" text-align:center">中国超市网发货单</h2>
	                                    <div class="printListInfo">
	                                        <dl>
	                                            <dt style=" width:90px;font-size:17px; ">收货信息：</dt><dd  class="address" runat="server" id="lblAdress" style="font-size:17px;"></dd>
	                                        </dl>
	                                        <dl>
	                                            <dt style=" width:90px ;font-size:17px;">下单时间：</dt><dd class="w200 orderTime" runat="server" id="lblTime" style="font-size:17px;"></dd>
	                                            <dt style=" width:90px;font-size:17px; ">订单编号：</dt><dd class="w200 telphone" runat="server" id="lblOrderId" style="font-size:17px;"></dd>
	                                        </dl>
	                                        <dl>
	                                            <dt style=" width:90px;font-size:17px; ">商家名称：</dt><dd class="w200 orderTime" runat="server" id="lblSj" style="font-size:17px;"></dd>
	                                            <dt style=" width:90px;font-size:17px; ">支付方式：</dt><dd class="w200 telphone" runat="server" id="lblZffs" style="font-size:17px;"></dd>
	                                        </dl>
	                                        <dl>
	                                            <dt style=" width:90px;font-size:17px; ">买家留言：</dt><dd  class="address" runat="server" id="lblLy" style="font-size:17px;"></dd>
	                                        </dl>
	                                         
	                                      
	                                    </div>
	                                    <div class="printListTableWrap">
	                                        <table class="printListTable" id="sp">
	                                        
	                                            <tr><th>商品名称</th><th>单价</th><th>数量</th></tr>
<asp:Repeater ID="rptDetail" runat="server">
 <ItemTemplate>
	                                            	 <tr>
		                                                <td class="left">&nbsp;<%#GetTitle(DataBinder.Eval(Container.DataItem, "goodsId").ToString())%></td>
		                                   
		                                                <td><%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "money")).ToString("0.00")%>元</td>
		                                                <td><%#DataBinder.Eval(Container.DataItem, "spNum")%></td>
		                                                
		                                              </tr>
</ItemTemplate>
</asp:Repeater>

	                                          
	                                        </table>
<table class="printListTable" id="sp">
<tr>
<td colspan="6" style=" text-align:right; padding-right:10px;border-top-width:0px">优惠：<%=yf%>元&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;合计：<%=hj%>元</td>
</tr>
</table>
	                                    </div>
	                                    
	                                </div>
	                            </div>
	                        </div>
	                    </div>
                    
	  
                    <!-- 发货单列表结束 -->
                </div>
</td>
</tr>
</table>
 
    </form>
</body>
</html>
 