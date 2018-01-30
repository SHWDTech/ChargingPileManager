<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest ="false"  CodeBehind="role_edit.aspx.cs" Inherits="ZDEnterprise.Web.role_edit" %>
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

		<link rel="stylesheet" href="assets/css/jquery-ui-1.10.3.custom.min.css" />
		<link rel="stylesheet" href="assets/css/chosen.css" />
		<link rel="stylesheet" href="assets/css/datepicker.css" />
		<link rel="stylesheet" href="assets/css/bootstrap-timepicker.css" />
		<link rel="stylesheet" href="assets/css/daterangepicker.css" />
		<link rel="stylesheet" href="assets/css/colorpicker.css" />


		<link rel="stylesheet" href="assets/css/ace.min.css" />
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />
		<link rel="stylesheet" href="assets/css/ace-skins.min.css" />

			 
		<script src="assets/js/ace-extra.min.js"></script>

    <link rel="stylesheet" href="KindEdit/themes/default/default.css" />
    <link rel="stylesheet" href="KindEdit/plugins/code/prettify.css" />

    <script type="text/javascript" charset="utf-8" src="KindEdit/kindeditor.js"></script>

    <script type="text/javascript" charset="utf-8" src="KindEdit/lang/zh_CN.js"></script>

    <script type="text/javascript" charset="utf-8" src="KindEdit/plugins/code/prettify.js"></script>

    <script type="text/javascript">
        KindEditor.ready(function(K) {
            var editor1 = K.create('#fckContent', {
                cssPath: 'KindEdit/plugins/code/prettify.css',
                uploadJson: 'upload_json.ashx?vipId=<%=Convert.ToString(Session["vipId"]) %>',
                fileManagerJson: 'file_manager_json.ashx?vipId=<%=Convert.ToString(Session["vipId"]) %>',
                allowFileManager: true,
                afterBlur: function(){this.sync();},
                afterCreate: function() {
                    var self = this;
                    K.ctrl(document, 13, function() {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function() {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
	</head>

	<body>
		<uc1:main_top ID="main_top" runat="server" />

		<div class="main-container" id="main-container">
			<script type="text/javascript">
				try{ace.settings.check('main-container' , 'fixed')}catch(e){}
			</script>

			<div class="main-container-inner">
				<uc2:main_menu ID="main_menu" runat="server" />

				<div class="main-content">
					<div class="breadcrumbs" id="breadcrumbs">
						<script type="text/javascript">
							try{ace.settings.check('breadcrumbs' , 'fixed')}catch(e){}
						</script>

						<ul class="breadcrumb">
							<li>
								<i class="icon-home home-icon"></i>
								<a href="main.aspx">首页</a>
							</li>

							<li>
								<a >系统管理</a>
							</li>
							<li class="active">角色管理</li>
						</ul><!-- .breadcrumb -->

					</div>

					<div class="page-content">
						<div class="page-header">
							<h1>
								角色管理
								<small>
									<i class="icon-double-angle-right"></i>
									新增角色
								</small>
							</h1>
						</div><!-- /.page-header -->

						<div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->

								<form class="form-horizontal" role="form" runat="server" id="form1"  >
								<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
								<asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 角色名称 </label>

										<div class="col-sm-9">
											<asp:TextBox runat="server" ID="txtName"  placeholder=" 角色名称" class="col-xs-10 col-sm-5" ></asp:TextBox>
											 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" *" ControlToValidate="txtName"></asp:RequiredFieldValidator>
										</div>
									</div>
									<div class="space-4"></div>
									 
									
									<div class="clearfix form-actions">
										<div class="col-md-offset-3 col-md-9">
											<asp:LinkButton runat="server" ID="btnBc" onclick="btnBc_Click" class="btn btn-info" ><i class="icon-ok bigger-110"></i>
												保存</asp:LinkButton>

											&nbsp; &nbsp; &nbsp;
											<button class="btn" type="reset">
												<i class="icon-undo bigger-110"></i>
												重置
											</button>
										</div>
									</div>

									<!-- /row -->

									<!-- /row -->
                               </ContentTemplate>
                               <Triggers><asp:PostBackTrigger ControlID="btnBc" /></Triggers>
                               </asp:UpdatePanel>
							</form>
 
								
							</div><!-- /.col -->
						</div><!-- /.row -->
					</div><!-- /.page-content -->
				</div><!-- /.main-content -->

				<uc3:main_style ID="main_style" runat="server" /><!-- /#ace-settings-container -->
			</div><!-- /.main-container-inner -->

			<a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
				<i class="icon-double-angle-up icon-only bigger-110"></i>
			</a>
		</div> 

 
			<script type="text/javascript">
			    window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
		</script>

 
		<script type="text/javascript">
		    if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<script src="assets/js/bootstrap.min.js"></script>
		<script src="assets/js/typeahead-bs2.min.js"></script>

		<!-- page specific plugin scripts -->

		<script src="assets/js/bootstrap-tag.min.js"></script>
		<script src="assets/js/jquery.hotkeys.min.js"></script>
		<script src="assets/js/bootstrap-wysiwyg.min.js"></script>
		<script src="assets/js/jquery-ui-1.10.3.custom.min.js"></script>
		<script src="assets/js/jquery.ui.touch-punch.min.js"></script>
		<script src="assets/js/jquery.slimscroll.min.js"></script>

		<!-- ace scripts -->

		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>

		<!-- inline scripts related to this page -->

		<script type="text/javascript">
		    jQuery(function($) {

		        //handling tabs and loading/displaying relevant messages and forms
		        //not needed if using the alternative view, as described in docs
		        var prevTab = 'inbox'
		        $('#inbox-tabs a[data-toggle="tab"]').on('show.bs.tab', function(e) {
		            var currentTab = $(e.target).data('target');
		            if (currentTab == 'write') {
		                Inbox.show_form();
		            }
		            else {
		                if (prevTab == 'write')
		                    Inbox.show_list();

		                //load and display the relevant messages 
		            }
		            prevTab = currentTab;
		        })



		        //basic initializations
		        $('.message-list .message-item input[type=checkbox]').removeAttr('checked');
		        $('.message-list').delegate('.message-item input[type=checkbox]', 'click', function() {
		            $(this).closest('.message-item').toggleClass('selected');
		            if (this.checked) Inbox.display_bar(1); //display action toolbar when a message is selected
		            else {
		                Inbox.display_bar($('.message-list input[type=checkbox]:checked').length);
		                //determine number of selected messages and display/hide action toolbar accordingly
		            }
		        });


		        //check/uncheck all messages
		        $('#id-toggle-all').removeAttr('checked').on('click', function() {
		            if (this.checked) {
		                Inbox.select_all();
		            } else Inbox.select_none();
		        });

		        //select all
		        $('#id-select-message-all').on('click', function(e) {
		            e.preventDefault();
		            Inbox.select_all();
		        });

		        //select none
		        $('#id-select-message-none').on('click', function(e) {
		            e.preventDefault();
		            Inbox.select_none();
		        });

		        //select read
		        $('#id-select-message-read').on('click', function(e) {
		            e.preventDefault();
		            Inbox.select_read();
		        });

		        //select unread
		        $('#id-select-message-unread').on('click', function(e) {
		            e.preventDefault();
		            Inbox.select_unread();
		        });

		        /////////

		        //display first message in a new area
		        $('.message-list .message-item:eq(0) .text').on('click', function() {
		            //show the loading icon
		            $('.message-container').append('<div class="message-loading-overlay"><i class="icon-spin icon-spinner orange2 bigger-160"></i></div>');

		            $('.message-inline-open').removeClass('message-inline-open').find('.message-content').remove();

		            var message_list = $(this).closest('.message-list');

		            //some waiting
		            setTimeout(function() {

		                //hide everything that is after .message-list (which is either .message-content or .message-form)
		                message_list.next().addClass('hide');
		                $('.message-container').find('.message-loading-overlay').remove();

		                //close and remove the inline opened message if any!

		                //hide all navbars
		                $('.message-navbar').addClass('hide');
		                //now show the navbar for single message item
		                $('#id-message-item-navbar').removeClass('hide');

		                //hide all footers
		                $('.message-footer').addClass('hide');
		                //now show the alternative footer
		                $('.message-footer-style2').removeClass('hide');


		                //move .message-content next to .message-list and hide .message-list
		                message_list.addClass('hide').after($('.message-content')).next().removeClass('hide');

		                //add scrollbars to .message-body
		                $('.message-content .message-body').slimScroll({
		                    height: 200,
		                    railVisible: true
		                });

		            }, 500 + parseInt(Math.random() * 500));
		        });


		        //display second message right inside the message list
		        $('.message-list .message-item:eq(1) .text').on('click', function() {
		            var message = $(this).closest('.message-item');

		            //if message is open, then close it
		            if (message.hasClass('message-inline-open')) {
		                message.removeClass('message-inline-open').find('.message-content').remove();
		                return;
		            }

		            $('.message-container').append('<div class="message-loading-overlay"><i class="icon-spin icon-spinner orange2 bigger-160"></i></div>');
		            setTimeout(function() {
		                $('.message-container').find('.message-loading-overlay').remove();
		                message
							.addClass('message-inline-open')
							.append('<div class="message-content" />')
		                var content = message.find('.message-content:last').html($('#id-message-content').html());

		                content.find('.message-body').slimScroll({
		                    height: 200,
		                    railVisible: true
		                });

		            }, 500 + parseInt(Math.random() * 500));

		        });



		        //back to message list
		        $('.btn-back-message-list').on('click', function(e) {
		            e.preventDefault();
		            Inbox.show_list();
		            $('#inbox-tabs a[data-target="inbox"]').tab('show');
		        });



		        //hide message list and display new message form
		        /**
		        $('.btn-new-mail').on('click', function(e){
		        e.preventDefault();
		        Inbox.show_form();
		        });
		        */




		        var Inbox = {
		            //displays a toolbar according to the number of selected messages
		            display_bar: function(count) {
		                if (count == 0) {
		                    $('#id-toggle-all').removeAttr('checked');
		                    $('#id-message-list-navbar .message-toolbar').addClass('hide');
		                    $('#id-message-list-navbar .message-infobar').removeClass('hide');
		                }
		                else {
		                    $('#id-message-list-navbar .message-infobar').addClass('hide');
		                    $('#id-message-list-navbar .message-toolbar').removeClass('hide');
		                }
		            }
					,
		            select_all: function() {
		                var count = 0;
		                $('.message-item input[type=checkbox]').each(function() {
		                    this.checked = true;
		                    $(this).closest('.message-item').addClass('selected');
		                    count++;
		                });

		                $('#id-toggle-all').get(0).checked = true;

		                Inbox.display_bar(count);
		            }
					,
		            select_none: function() {
		                $('.message-item input[type=checkbox]').removeAttr('checked').closest('.message-item').removeClass('selected');
		                $('#id-toggle-all').get(0).checked = false;

		                Inbox.display_bar(0);
		            }
					,
		            select_read: function() {
		                $('.message-unread input[type=checkbox]').removeAttr('checked').closest('.message-item').removeClass('selected');

		                var count = 0;
		                $('.message-item:not(.message-unread) input[type=checkbox]').each(function() {
		                    this.checked = true;
		                    $(this).closest('.message-item').addClass('selected');
		                    count++;
		                });
		                Inbox.display_bar(count);
		            }
					,
		            select_unread: function() {
		                $('.message-item:not(.message-unread) input[type=checkbox]').removeAttr('checked').closest('.message-item').removeClass('selected');

		                var count = 0;
		                $('.message-unread input[type=checkbox]').each(function() {
		                    this.checked = true;
		                    $(this).closest('.message-item').addClass('selected');
		                    count++;
		                });

		                Inbox.display_bar(count);
		            }
		        }

		        //show message list (back from writing mail or reading a message)
		        Inbox.show_list = function() {
		            $('.message-navbar').addClass('hide');
		            $('#id-message-list-navbar').removeClass('hide');

		            $('.message-footer').addClass('hide');
		            $('.message-footer:not(.message-footer-style2)').removeClass('hide');

		            $('.message-list').removeClass('hide').next().addClass('hide');
		            //hide the message item / new message window and go back to list
		        }

		        //show write mail form
		        Inbox.show_form = function() {
		            if ($('.message-form').is(':visible')) return;
		            if (!form_initialized) {
		                initialize_form();
		            }


		            var message = $('.message-list');
		            $('.message-container').append('<div class="message-loading-overlay"><i class="icon-spin icon-spinner orange2 bigger-160"></i></div>');

		            setTimeout(function() {
		                message.next().addClass('hide');

		                $('.message-container').find('.message-loading-overlay').remove();

		                $('.message-list').addClass('hide');
		                $('.message-footer').addClass('hide');
		                $('.message-form').removeClass('hide').insertAfter('.message-list');

		                $('.message-navbar').addClass('hide');
		                $('#id-message-new-navbar').removeClass('hide');


		                //reset form??
		                $('.message-form .wysiwyg-editor').empty();

		                $('.message-form .ace-file-input').closest('.file-input-container:not(:first-child)').remove();
		                $('.message-form input[type=file]').ace_file_input('reset_input');

		                $('.message-form').get(0).reset();

		            }, 300 + parseInt(Math.random() * 300));
		        }




		        var form_initialized = false;
		        function initialize_form() {
		            if (form_initialized) return;
		            form_initialized = true;

		            //intialize wysiwyg editor
		            $('.message-form .wysiwyg-editor').ace_wysiwyg({
		                toolbar:
						[
							'bold',
							'italic',
							'strikethrough',
							'underline',
							null,
							'justifyleft',
							'justifycenter',
							'justifyright',
							null,
							'createLink',
							'unlink',
							null,
							'undo',
							'redo'
						]
		            }).prev().addClass('wysiwyg-style1');

		            //file input
		            $('.message-form input[type=file]').ace_file_input()
		            //and the wrap it inside .span7 for better display, perhaps
					.closest('.ace-file-input').addClass('width-90 inline').wrap('<div class="row file-input-container"><div class="col-sm-7"></div></div>');

		            //the button to add a new file input
		            $('#id-add-attachment').on('click', function() {
		                var file = $('<input type="file" name="attachment[]" />').appendTo('#form-attachments');
		                file.ace_file_input();
		                file.closest('.ace-file-input').addClass('width-90 inline').wrap('<div class="row file-input-container"><div class="col-sm-7"></div></div>')
						.parent(/*.span7*/).append('<div class="action-buttons pull-right col-xs-1">\
							<a href="#" data-action="delete" class="middle">\
								<i class="icon-trash red bigger-130 middle"></i>\
							</a>\
						</div>').find('a[data-action=delete]').on('click', function(e) {
						    //the button that removes the newly inserted file input
						    e.preventDefault();
						    $(this).closest('.row').hide(300, function() {
						        $(this).remove();
						    });
						});
		            });
		        } //initialize_form


		        //turn the recipient field into a tag input field!
		        /**	
		        var tag_input = $('#form-field-recipient');
		        if(! ( /msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase())) ) 
		        tag_input.tag({placeholder:tag_input.attr('placeholder')});
			
			
				//and add form reset functionality
		        $('.message-form button[type=reset]').on('click', function(){
		        $('.message-form .message-body').empty();
					
					$('.message-form .ace-file-input:not(:first-child)').remove();
		        $('.message-form input[type=file]').ace_file_input('reset_input');
					
					
		        var val = tag_input.data('value');
		        tag_input.parent().find('.tag').remove();
		        $(val.split(',')).each(function(k,v){
		        tag_input.before('<span class="tag">'+v+'<button class="close" type="button">&times;</button></span>');
		        });
		        });
		        */

		    });
		</script>
	
</body>
</html>
