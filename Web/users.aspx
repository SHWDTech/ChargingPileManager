﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="ZDEnterprise.Web.users" %>
<%@ Register Src="controls/main_top.ascx" TagName="main_top" TagPrefix="uc1" %>
<%@ Register Src="controls/main_menu.ascx" TagName="main_menu" TagPrefix="uc2" %>
<%@ Register Src="controls/main_style.ascx" TagName="main_style" TagPrefix="uc3" %>

<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="utf-8" />
		<title><%=websitetitle%></title>
		<meta name="keywords" content="" />
		<meta name="description" content="" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
 
		<link href="assets/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="assets/css/font-awesome.min.css" />
 
		<link rel="stylesheet" href="assets/css/ace.min.css" />
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />
		<link rel="stylesheet" href="assets/css/ace-skins.min.css" />
 
		<script src="assets/js/ace-extra.min.js"></script>
	</head>

	<body>
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
							<li>
								<i class="icon-home home-icon"></i>
								<a href="main.aspx">首页</a>
							</li>

							<li>
								<a>系统管理</a>
							</li>
							<li class="active">用户管理</li>
						</ul><!-- .breadcrumb -->


					</div>

					<div class="page-content">
						<div class="page-header">
							<h1>
								用户管理
								<small>
									<i class="icon-double-angle-right"></i>
									用户列表
								</small>
							</h1>
						</div><!-- /.page-header -->

						<div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->
 
								<div class="row">
									<div class="col-xs-12">

<form runat="server" id="form1">
<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>
<asp:HiddenField runat="server" ID="hidSort" />
<asp:HiddenField runat="server" ID="hidOrder" />
<asp:HiddenField runat="server" ID="hidCurrentPage" />

										<div class="table-responsive">
										
										<div class="dataTables_wrapper" role="grid">
										
                                            <div class="row">
                                            <div class="col-sm-6">
                                            <div class="dataTables_length">
                                            
                                            <div class="col-xs-12 col-sm-8">
																<div class="input-group">
																	<asp:TextBox runat="server" ID="txtCx" class="form-control search-query" placeholder="搜索条件"></asp:TextBox>
																	<span class="input-group-btn">
																		<asp:LinkButton runat="server" ID="btnCx" onclick="btnCx_Click" class="btn btn-purple btn-sm">查询
																			<i class="icon-search icon-on-right bigger-110"></i></asp:LinkButton>
																	</span>
																</div>
															</div>
                                            </div>
                                            </div>
                                            <div class="col-sm-6">
                                            <div class="dataTables_filter">
                                            <label style=" padding-top:4px">每页显示 <asp:DropDownList runat="server" ID="ddlPage"  AutoPostBack="true" aria-controls="sample-table-2" Width="65" Height="25"  onselectedindexchanged="ddlPage_SelectedIndexChanged"><asp:ListItem Value="15" Selected="True">15</asp:ListItem><asp:ListItem Value="30">30</asp:ListItem><asp:ListItem Value="50">50</asp:ListItem></asp:DropDownList> 条 搜索到 <span style=" color:Red; font-weight:bold"><asp:Label runat="server" ID="lblZs" Text="0"></asp:Label></span> 条记录</label>
                                            </div>
                                            </div>
                                            </div>
                                            
											<table  class="table table-striped table-bordered table-hover">
											
												<thead>
													<tr>
														<th class="center">选择<%--<label><asp:CheckBox runat="server" id="controlAll"/></label>--%></th>
														<%--<th>头像</th>--%>
														<th>姓名</th>
														<th>帐号</th>
														<th>角色</th>
														<th>联系电话</th>
								 
														<th>操作</th>
													</tr>
												</thead>

												<tbody>
												
<asp:Repeater ID="rptDetail" runat="server">
 <ItemTemplate>
													<tr>
														<td class="center"><label>
														<asp:CheckBox runat="server" id="cbxId" />
														<asp:Label ID="lblId" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "usersId")%>'></asp:Label>
														</label></td>
														<%--<td align="center"><img src="<%# VirturlPath + (DataBinder.Eval(Container.DataItem, "imgUrl").ToString() == "" ? "/Upload/logo/zw.png" : DataBinder.Eval(Container.DataItem, "imgUrl").ToString())%>" width="30" height="30" /></td>--%>
														<td><%#DataBinder.Eval(Container.DataItem, "name")%></td>
														<td><%#DataBinder.Eval(Container.DataItem, "code")%></td>
														<td><%#RoleName(DataBinder.Eval(Container.DataItem, "roleId").ToString())%></td>
														<td><%#DataBinder.Eval(Container.DataItem, "phone")%></td>
													 

														<td>
																<a class="green"  style=" text-decoration:none" href="users_edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "usersId")%>"><i class="icon-pencil bigger-130" title="编辑"></i></a>
																<a class="red"  style=" text-decoration:none" href="javascript:if(confirm('确定要删除吗?'))window.location='users.aspx?m=del&id=<%#DataBinder.Eval(Container.DataItem, "usersId")%>'"><i class="icon-trash bigger-130" title="删除"></i></a>
														</td>
													</tr>
</ItemTemplate>
</asp:Repeater>
												 
												</tbody>
											</table>
											
											<div class="wushuju" runat="server" id="divWu" style=" display:none">未搜索到数据</div>
											
											<div class="row" runat="server" id="divYes" style=" display:block">
											<div class="col-sm-6">
											<div class="dataTables_info" style=" padding-top:5px;" >
											  <table cellspacing="0" cellpadding="0" border="0" class="ui-pg-table navtable" style="float:left;table-layout:auto;">
											    <tbody>
											     <tr>
											      <td class="ui-pg-button ui-corner-all" title="" id="add_grid-table" data-original-title="Add new row" style=" width:25px;">
											        <div class="ui-pg-div"><a href="users_add.aspx" style=" text-decoration:none"><span class="ui-icon icon-plus-sign purple" title="新增"></span></a></div>
											       </td>
											       <td class="ui-pg-button ui-corner-all" title="" id="del_grid-table" data-original-title="Delete selected row" style=" width:25px;">
											        <div class="ui-pg-div"><span class="ui-icon icon-trash red"  onclick="if(confirm('确定要删除吗?'))__doPostBack('btnDel','')" title="删除"></span>
                                                        <asp:LinkButton runat="server" ID="btnDel" onclick="btnDel_Click"></asp:LinkButton></div>
											       </td>
											      </tr>
											     </tbody>
											    </table>
											</div>
											</div>
											<div class="col-sm-6">
											  <div class="page_03"> <%=pageName %> </div>
                                              <asp:LinkButton runat="server" ID="btnPage" onclick="btnPage_Click"></asp:LinkButton>
											</div>
											</div>
											
						 
										</div>	
										</div>
										
</ContentTemplate></asp:UpdatePanel>
</form>
									</div>
								</div>

								 <!-- PAGE CONTENT ENDS -->
							</div><!-- /.col -->
						</div><!-- /.row -->
					</div><!-- /.page-content -->
				</div><!-- /.main-content -->

				<uc3:main_style ID="main_style" runat="server" /><!-- /#ace-settings-container -->
			</div><!-- /.main-container-inner -->

			<a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
				<i class="icon-double-angle-up icon-only bigger-110"></i>
			</a>
		</div><!-- /.main-container -->
 

		<script type="text/javascript">
		    window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
		</script>
 
		<script type="text/javascript">
		    if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<script src="assets/js/bootstrap.min.js"></script>
		<script src="assets/js/typeahead-bs2.min.js"></script>

		<script src="assets/js/date-time/bootstrap-datepicker.min.js"></script>
		<script src="assets/js/jqGrid/jquery.jqGrid.min.js"></script>
		<script src="assets/js/jqGrid/i18n/grid.locale-en.js"></script>

		<!-- page specific plugin scripts -->

		<script src="assets/js/jquery.dataTables.min.js"></script>
		<script src="assets/js/jquery.dataTables.bootstrap.js"></script>

		<!-- ace scripts -->

		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>

		<!-- inline scripts related to this page -->

		<script type="text/javascript">
		    jQuery(function($) {
		        var oTable1 = $('#sample-table-2').dataTable({
		            "aoColumns": [
			      { "bSortable": false },
			      null, null, null, null, null,
				  { "bSortable": false }
				]
		        });


		        $('table th input:checkbox').on('click', function() {
		            var that = this;
		            $(this).closest('table').find('tr > td:first-child input:checkbox')
					.each(function() {
					    this.checked = that.checked;
					    $(this).closest('tr').toggleClass('selected');
					});

		        });


		        $('[data-rel="tooltip"]').tooltip({ placement: tooltip_placement });
		        function tooltip_placement(context, source) {
		            var $source = $(source);
		            var $parent = $source.closest('table')
		            var off1 = $parent.offset();
		            var w1 = $parent.width();

		            var off2 = $source.offset();
		            var w2 = $source.width();

		            if (parseInt(off2.left) < parseInt(off1.left) + parseInt(w1 / 2)) return 'right';
		            return 'left';
		        }
		    })
		</script>
		<script>
		    function page(num) {
		        document.getElementById("hidCurrentPage").value = num;
		        __doPostBack('btnPage', '');
		    }
		</script>
		
		<script type="text/javascript">
			var grid_data = 
			[ 
				{id:"1",name:"Desktop Computer",note:"note",stock:"Yes",ship:"FedEx", sdate:"2007-12-03"},
				{id:"2",name:"Laptop",note:"Long text ",stock:"Yes",ship:"InTime",sdate:"2007-12-03"},
				{id:"3",name:"LCD Monitor",note:"note3",stock:"Yes",ship:"TNT",sdate:"2007-12-03"},
				{id:"4",name:"Speakers",note:"note",stock:"No",ship:"ARAMEX",sdate:"2007-12-03"},
				{id:"5",name:"Laser Printer",note:"note2",stock:"Yes",ship:"FedEx",sdate:"2007-12-03"},
				{id:"6",name:"Play Station",note:"note3",stock:"No", ship:"FedEx",sdate:"2007-12-03"},
				{id:"7",name:"Mobile Telephone",note:"note",stock:"Yes",ship:"ARAMEX",sdate:"2007-12-03"},
				{id:"8",name:"Server",note:"note2",stock:"Yes",ship:"TNT",sdate:"2007-12-03"},
				{id:"9",name:"Matrix Printer",note:"note3",stock:"No", ship:"FedEx",sdate:"2007-12-03"},
				{id:"10",name:"Desktop Computer",note:"note",stock:"Yes",ship:"FedEx", sdate:"2007-12-03"},
				{id:"11",name:"Laptop",note:"Long text ",stock:"Yes",ship:"InTime",sdate:"2007-12-03"},
				{id:"12",name:"LCD Monitor",note:"note3",stock:"Yes",ship:"TNT",sdate:"2007-12-03"},
				{id:"13",name:"Speakers",note:"note",stock:"No",ship:"ARAMEX",sdate:"2007-12-03"},
				{id:"14",name:"Laser Printer",note:"note2",stock:"Yes",ship:"FedEx",sdate:"2007-12-03"},
				{id:"15",name:"Play Station",note:"note3",stock:"No", ship:"FedEx",sdate:"2007-12-03"},
				{id:"16",name:"Mobile Telephone",note:"note",stock:"Yes",ship:"ARAMEX",sdate:"2007-12-03"},
				{id:"17",name:"Server",note:"note2",stock:"Yes",ship:"TNT",sdate:"2007-12-03"},
				{id:"18",name:"Matrix Printer",note:"note3",stock:"No", ship:"FedEx",sdate:"2007-12-03"},
				{id:"19",name:"Matrix Printer",note:"note3",stock:"No", ship:"FedEx",sdate:"2007-12-03"},
				{id:"20",name:"Desktop Computer",note:"note",stock:"Yes",ship:"FedEx", sdate:"2007-12-03"},
				{id:"21",name:"Laptop",note:"Long text ",stock:"Yes",ship:"InTime",sdate:"2007-12-03"},
				{id:"22",name:"LCD Monitor",note:"note3",stock:"Yes",ship:"TNT",sdate:"2007-12-03"},
				{id:"23",name:"Speakers",note:"note",stock:"No",ship:"ARAMEX",sdate:"2007-12-03"}
			];	
			
			jQuery(function($) {
				var grid_selector = "#grid-table";
				var pager_selector = "#grid-pager";
			
				jQuery(grid_selector).jqGrid({
					//direction: "rtl",
					
					data: grid_data,
					datatype: "local",
					height: 250,
					colNames:[' ', 'ID','Last Sales','Name', 'Stock', 'Ship via','Notes'],
					colModel:[
						{name:'myac',index:'', width:80, fixed:true, sortable:false, resize:false,
							formatter:'actions', 
							formatoptions:{ 
								keys:true,
								
								delOptions:{recreateForm: true, beforeShowForm:beforeDeleteCallback},
								//editformbutton:true, editOptions:{recreateForm: true, beforeShowForm:beforeEditCallback}
							}
						},
						{name:'id',index:'id', width:60, sorttype:"int", editable: true},
						{name:'sdate',index:'sdate',width:90, editable:true, sorttype:"date",unformat: pickDate},
						{name:'name',index:'name', width:150,editable: true,editoptions:{size:"20",maxlength:"30"}},
						{name:'stock',index:'stock', width:70, editable: true,edittype:"checkbox",editoptions: {value:"Yes:No"},unformat: aceSwitch},
						{name:'ship',index:'ship', width:90, editable: true,edittype:"select",editoptions:{value:"FE:FedEx;IN:InTime;TN:TNT;AR:ARAMEX"}},
						{name:'note',index:'note', width:150, sortable:false,editable: true,edittype:"textarea", editoptions:{rows:"2",cols:"10"}} 
					], 
			
					viewrecords : true,
					rowNum:10,
					rowList:[10,20,30],
					pager : pager_selector,
					altRows: true,
					//toppager: true,
					
					multiselect: true,
					//multikey: "ctrlKey",
			        multiboxonly: true,
			
					loadComplete : function() {
						var table = this;
						setTimeout(function(){
							styleCheckbox(table);
							
							updateActionIcons(table);
							updatePagerIcons(table);
							enableTooltips(table);
						}, 0);
					},
			
					editurl: $path_base+"/dummy.html",//nothing is saved
					caption: "jqGrid with inline editing",
			
			
					autowidth: true
			
				});
			
				//enable search/filter toolbar
				//jQuery(grid_selector).jqGrid('filterToolbar',{defaultSearch:true,stringResult:true})
			
				//switch element when editing inline
				function aceSwitch( cellvalue, options, cell ) {
					setTimeout(function(){
						$(cell) .find('input[type=checkbox]')
								.wrap('<label class="inline" />')
							.addClass('ace ace-switch ace-switch-5')
							.after('<span class="lbl"></span>');
					}, 0);
				}
				//enable datepicker
				function pickDate( cellvalue, options, cell ) {
					setTimeout(function(){
						$(cell) .find('input[type=text]')
								.datepicker({format:'yyyy-mm-dd' , autoclose:true}); 
					}, 0);
				}
			
			
				//navButtons
				jQuery(grid_selector).jqGrid('navGrid',pager_selector,
					{ 	//navbar options
						edit: true,
						editicon : 'icon-pencil blue',
						add: true,
						addicon : 'icon-plus-sign purple',
						del: true,
						delicon : 'icon-trash red',
						search: true,
						searchicon : 'icon-search orange',
						refresh: true,
						refreshicon : 'icon-refresh green',
						view: true,
						viewicon : 'icon-zoom-in grey',
					},
					{
						//edit record form
						//closeAfterEdit: true,
						recreateForm: true,
						beforeShowForm : function(e) {
							var form = $(e[0]);
							form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
							style_edit_form(form);
						}
					},
					{
						//new record form
						closeAfterAdd: true,
						recreateForm: true,
						viewPagerButtons: false,
						beforeShowForm : function(e) {
							var form = $(e[0]);
							form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
							style_edit_form(form);
						}
					},
					{
						//delete record form
						recreateForm: true,
						beforeShowForm : function(e) {
							var form = $(e[0]);
							if(form.data('styled')) return false;
							
							form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
							style_delete_form(form);
							
							form.data('styled', true);
						},
						onClick : function(e) {
							alert(1);
						}
					},
					{
						//search form
						recreateForm: true,
						afterShowSearch: function(e){
							var form = $(e[0]);
							form.closest('.ui-jqdialog').find('.ui-jqdialog-title').wrap('<div class="widget-header" />')
							style_search_form(form);
						},
						afterRedraw: function(){
							style_search_filters($(this));
						}
						,
						multipleSearch: true,
						/**
						multipleGroup:true,
						showQuery: true
						*/
					},
					{
						//view record form
						recreateForm: true,
						beforeShowForm: function(e){
							var form = $(e[0]);
							form.closest('.ui-jqdialog').find('.ui-jqdialog-title').wrap('<div class="widget-header" />')
						}
					}
				)
			
			
				
				function style_edit_form(form) {
					//enable datepicker on "sdate" field and switches for "stock" field
					form.find('input[name=sdate]').datepicker({format:'yyyy-mm-dd' , autoclose:true})
						.end().find('input[name=stock]')
							  .addClass('ace ace-switch ace-switch-5').wrap('<label class="inline" />').after('<span class="lbl"></span>');
			
					//update buttons classes
					var buttons = form.next().find('.EditButton .fm-button');
					buttons.addClass('btn btn-sm').find('[class*="-icon"]').remove();//ui-icon, s-icon
					buttons.eq(0).addClass('btn-primary').prepend('<i class="icon-ok"></i>');
					buttons.eq(1).prepend('<i class="icon-remove"></i>')
					
					buttons = form.next().find('.navButton a');
					buttons.find('.ui-icon').remove();
					buttons.eq(0).append('<i class="icon-chevron-left"></i>');
					buttons.eq(1).append('<i class="icon-chevron-right"></i>');		
				}
			
				function style_delete_form(form) {
					var buttons = form.next().find('.EditButton .fm-button');
					buttons.addClass('btn btn-sm').find('[class*="-icon"]').remove();//ui-icon, s-icon
					buttons.eq(0).addClass('btn-danger').prepend('<i class="icon-trash"></i>');
					buttons.eq(1).prepend('<i class="icon-remove"></i>')
				}
				
				function style_search_filters(form) {
					form.find('.delete-rule').val('X');
					form.find('.add-rule').addClass('btn btn-xs btn-primary');
					form.find('.add-group').addClass('btn btn-xs btn-success');
					form.find('.delete-group').addClass('btn btn-xs btn-danger');
				}
				function style_search_form(form) {
					var dialog = form.closest('.ui-jqdialog');
					var buttons = dialog.find('.EditTable')
					buttons.find('.EditButton a[id*="_reset"]').addClass('btn btn-sm btn-info').find('.ui-icon').attr('class', 'icon-retweet');
					buttons.find('.EditButton a[id*="_query"]').addClass('btn btn-sm btn-inverse').find('.ui-icon').attr('class', 'icon-comment-alt');
					buttons.find('.EditButton a[id*="_search"]').addClass('btn btn-sm btn-purple').find('.ui-icon').attr('class', 'icon-search');
				}
				
				function beforeDeleteCallback(e) {
					var form = $(e[0]);
					if(form.data('styled')) return false;
					
					form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
					style_delete_form(form);
					
					form.data('styled', true);
				}
				
				function beforeEditCallback(e) {
					var form = $(e[0]);
					form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
					style_edit_form(form);
				}
			
			
			
				//it causes some flicker when reloading or navigating grid
				//it may be possible to have some custom formatter to do this as the grid is being created to prevent this
				//or go back to default browser checkbox styles for the grid
				function styleCheckbox(table) {
				/**
					$(table).find('input:checkbox').addClass('ace')
					.wrap('<label />')
					.after('<span class="lbl align-top" />')
			
			
					$('.ui-jqgrid-labels th[id*="_cb"]:first-child')
					.find('input.cbox[type=checkbox]').addClass('ace')
					.wrap('<label />').after('<span class="lbl align-top" />');
				*/
				}
				
			
				//unlike navButtons icons, action icons in rows seem to be hard-coded
				//you can change them like this in here if you want
				function updateActionIcons(table) {
					/**
					var replacement = 
					{
						'ui-icon-pencil' : 'icon-pencil blue',
						'ui-icon-trash' : 'icon-trash red',
						'ui-icon-disk' : 'icon-ok green',
						'ui-icon-cancel' : 'icon-remove red'
					};
					$(table).find('.ui-pg-div span.ui-icon').each(function(){
						var icon = $(this);
						var $class = $.trim(icon.attr('class').replace('ui-icon', ''));
						if($class in replacement) icon.attr('class', 'ui-icon '+replacement[$class]);
					})
					*/
				}
				
				//replace icons with FontAwesome icons like above
				function updatePagerIcons(table) {
					var replacement = 
					{
						'ui-icon-seek-first' : 'icon-double-angle-left bigger-140',
						'ui-icon-seek-prev' : 'icon-angle-left bigger-140',
						'ui-icon-seek-next' : 'icon-angle-right bigger-140',
						'ui-icon-seek-end' : 'icon-double-angle-right bigger-140'
					};
					$('.ui-pg-table:not(.navtable) > tbody > tr > .ui-pg-button > .ui-icon').each(function(){
						var icon = $(this);
						var $class = $.trim(icon.attr('class').replace('ui-icon', ''));
						
						if($class in replacement) icon.attr('class', 'ui-icon '+replacement[$class]);
					})
				}
			
				function enableTooltips(table) {
					$('.navtable .ui-pg-button').tooltip({container:'body'});
					$(table).find('.ui-pg-div').tooltip({container:'body'});
				}
			
				//var selr = jQuery(grid_selector).jqGrid('getGridParam','selrow');
			
			
			});
		</script>
		<script>
		    function selectAll() {
		        var checklist = document.getElementsByName("selected");
		        if (document.getElementById("controlAll").checked) {
		            for (var i = 0; i < checklist.length; i++) {
		                checklist[i].checked = 1;
		            }
		        } else {
		            for (var j = 0; j < checklist.length; j++) {
		                checklist[j].checked = 0;
		            }
		        }
		    }
       </script>
	
</body>
</html>
