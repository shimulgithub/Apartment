﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin_Logout.aspx.cs" Inherits="UserLogin_Logout" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <link rel="Shortcut Icon" href="images/logo.png" />
 
  <title>Login Page - Tulip</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		

		<meta name="description" content="User login page" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />
          <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
		<!-- text fonts -->
		<link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

		<!-- ace styles -->
		<link rel="stylesheet" href="assets/css/ace.min.css" />

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->



         <script type="text/javascript">
             function buttonLogin_click(buttonName, e) {
                 //the purpose of this function is to allow the enter key to 
                 //point to the correct button to click.
                 var key;

                 if (window.event)
                     key = window.event.keyCode;     //IE
                 else
                     key = e.which;     //firefox

                 if (key == 13) {
                     //Get the button the user wants to have clicked
                     var btn = document.getElementById(buttonName);
                     if (btn != null) { //If we find the button click it
                         btn.click();
                         event.keyCode = 0
                     }
                 }
             }
</script>


</head>
<body class="login-layout">
    <form id="form1" runat="server">
  
		<div class="main-container">
			<div class="main-content">
				<div class="row">
					<div class="col-sm-10 col-sm-offset-1">
						<div class="login-container">
							<div class="center">
								<h1>
									<i class="ace-icon fa fa-flag green"></i>
									<span class="red">Tulip Public School</span>
									<%--<span class="white" id="id-text2">Apartment Management System</span>--%>
								</h1>
								<%--<h4 class="blue" id="id-company-text">&copy; Spencer Ogden</h4>--%>
							</div>

							<div class="space-6"></div>

							<div class="position-relative">
								<div id="login-box" class="login-box visible widget-box no-border">
									<div class="widget-body">
										<div class="widget-main">
											<h4 class="header blue lighter bigger">
												<i class="ace-icon fa fa-coffee green"></i>
												Please Enter Your Information
											</h4>

											<div class="space-6"></div>

											<form>
												<fieldset>
													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															   <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
															<i class="ace-icon fa fa-user"></i>
														</span>
													</label>

													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
													    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"
                                                                TextMode="Password" ></asp:TextBox>
                                                             
															<i class="ace-icon fa fa-lock"></i>
														</span>
													</label>
                                                          <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
													<div class="space"></div>

													<div class="clearfix">
														  <asp:LinkButton ID="btnReset" runat="server" class="width-30 pull-left btn btn-sm btn-primary" Font-Bold="True"><i class="icon-refresh"></i>&nbsp;Reset</asp:LinkButton>
													   <asp:LinkButton ID="btnLogin" runat="server" Font-Bold="True" class="width-35 pull-right btn btn-sm btn-primary"
                                                        OnClick="btnLogin_Click"><i class="icon-key"></i>&nbsp;Login</asp:LinkButton>
                                                         
													</div>

													<div class="space-4"></div>
												</fieldset>
											</form>

										 

											<div class="space-6"></div>
 
										</div><!-- /.widget-main -->

									 
									</div><!-- /.widget-body -->
								</div><!-- /.login-box -->

								<div id="forgot-box" class="forgot-box widget-box no-border">
									<div class="widget-body">
										<div class="widget-main">
											<h4 class="header red lighter bigger">
												<i class="ace-icon fa fa-key"></i>
												Retrieve Password
											</h4>

											<div class="space-6"></div>
											<p>
												Enter your email and to receive instructions
											</p>

											<form>
												<fieldset>
													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<input type="email" class="form-control" placeholder="Email" />
															<i class="ace-icon fa fa-envelope"></i>
														</span>
													</label>

													<div class="clearfix">
														<button type="button" class="width-35 pull-right btn btn-sm btn-danger">
															<i class="ace-icon fa fa-lightbulb-o"></i>
															<span class="bigger-110">Send Me!</span>
														</button>
													</div>
												</fieldset>
											</form>
										</div><!-- /.widget-main -->

										<div class="toolbar center">
											<a href="#" data-target="#login-box" class="back-to-login-link">
												Back to login
												<i class="ace-icon fa fa-arrow-right"></i>
											</a>
										</div>
									</div><!-- /.widget-body -->
								</div><!-- /.forgot-box -->

								<div id="signup-box" class="signup-box widget-box no-border">
									<div class="widget-body">
										<div class="widget-main">
											<h4 class="header green lighter bigger">
												<i class="ace-icon fa fa-users blue"></i>
												New User Registration
											</h4>

											<div class="space-6"></div>
											<p> Enter your details to begin: </p>

											<form>
												<fieldset>
													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<input type="email" class="form-control" placeholder="Email" />
															<i class="ace-icon fa fa-envelope"></i>
														</span>
													</label>

													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<input type="text" class="form-control" placeholder="Username" />
															<i class="ace-icon fa fa-user"></i>
														</span>
													</label>

													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<input type="password" class="form-control" placeholder="Password" />
															<i class="ace-icon fa fa-lock"></i>
														</span>
													</label>

													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<input type="password" class="form-control" placeholder="Repeat password" />
															<i class="ace-icon fa fa-retweet"></i>
														</span>
													</label>

													<label class="block">
														<input type="checkbox" class="ace" />
														<span class="lbl">
															I accept the
															<a href="#">User Agreement</a>
														</span>
													</label>

													<div class="space-24"></div>

													<div class="clearfix">
														<button type="reset" class="width-30 pull-left btn btn-sm">
															<i class="ace-icon fa fa-refresh"></i>
															<span class="bigger-110">Reset</span>
														</button>

														<button type="button" class="width-65 pull-right btn btn-sm btn-success">
															<span class="bigger-110">Register</span>

															<i class="ace-icon fa fa-arrow-right icon-on-right"></i>
														</button>
													</div>
												</fieldset>
											</form>
										</div>

										<div class="toolbar center">
											<a href="#" data-target="#login-box" class="back-to-login-link">
												<i class="ace-icon fa fa-arrow-left"></i>
												Back to login
											</a>
										</div>
									</div><!-- /.widget-body -->
								</div><!-- /.signup-box -->
							</div><!-- /.position-relative -->

							<div class="navbar-fixed-top align-right">
								<br />
								&nbsp;
								<a id="btn-login-dark" href="#">Dark</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-blur" href="#">Blur</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-light" href="#">Light</a>
								&nbsp; &nbsp; &nbsp;
							</div>
						</div>
					</div><!-- /.col -->
				</div><!-- /.row -->
			</div><!-- /.main-content -->
		</div><!-- /.main-container -->

		<!-- basic scripts -->

		<!--[if !IE]> -->
		<script src="assets/js/jquery-2.1.4.min.js"></script>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets/js/jquery-1.11.3.min.js"></script>
<![endif]-->
		<script type="text/javascript">
		    if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>

		<!-- inline scripts related to this page -->
		<script type="text/javascript">
		    jQuery(function ($) {
		        $(document).on('click', '.toolbar a[data-target]', function (e) {
		            e.preventDefault();
		            var target = $(this).data('target');
		            $('.widget-box.visible').removeClass('visible'); //hide others
		            $(target).addClass('visible'); //show target
		        });
		    });



		    //you don't need this, just used for changing background
		    jQuery(function ($) {
		        $('#btn-login-dark').on('click', function (e) {
		            $('body').attr('class', 'login-layout');
		            $('#id-text2').attr('class', 'white');
		            $('#id-company-text').attr('class', 'blue');

		            e.preventDefault();
		        });
		        $('#btn-login-light').on('click', function (e) {
		            $('body').attr('class', 'login-layout light-login');
		            $('#id-text2').attr('class', 'grey');
		            $('#id-company-text').attr('class', 'blue');

		            e.preventDefault();
		        });
		        $('#btn-login-blur').on('click', function (e) {
		            $('body').attr('class', 'login-layout blur-login');
		            $('#id-text2').attr('class', 'white');
		            $('#id-company-text').attr('class', 'light-blue');

		            e.preventDefault();
		        });

		    });
        </script>
	 
    </form>
</body>
</html>
