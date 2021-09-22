<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Task_Doc_mangmnt.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="ROOT Admin - UI Admin Kit Powered by Bootstrap 4" />
        <meta name="author" content="Lukasz Holeczek" />
        <meta name="keyword" content="ROOT Admin - UI Admin Kit Powered by Bootstrap 4" />
         <link rel="icon" href="img/favicon.ico" /> 
        <title>Task & Document Management</title>
        <!-- Main styles for this application -->
        <link href="css/style.css" rel="stylesheet" />
    <script src="source/jquery-2.1.3.min.js"></script>
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("txtusername").value == "" & document.getElementById("txtpassword").value == "") {
                alert("Name Field and Password Field cannot be blank");
                document.getElementById("txtusername").focus();
                return false;
            }
            if (document.getElementById("txtusername").value == "") {
                alert("Name Field cannot be blank");
                document.getElementById("txtusername").focus();
                return false;
            }
            else if (document.getElementById("txtpassword").value == "") {
                alert("Password Field cannot be blank");
                document.getElementById("txtpassword").focus();
                return false;
            }
            else {
                return true;
            }
        }
</script>


</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div class="card-group vamiddle">
                        <div class="card  p-a-2">
                            <div class="card-block">
                                <h1>Login</h1>
                                <p class="text-muted">Sign In to your account</p>
                                <div class="form-group input-group m-b-2">
                                    <span class="input-group-addon"><i class="icon-user"></i></span>
                                  <%--  <input type="text" class="form-control" placeholder="Username">--%>
                                    <asp:TextBox ID="txtusername" runat="server" placeholder="Username"  Class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"  ErrorMessage="Username is Required!!!" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="input-group m-b-2">
                                    <span class="input-group-addon"><i class="icon-lock"></i></span>
                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="password" placeholder="Password" Class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="txtpasswdreq" runat="server" ControlToValidate="txtpassword"  ErrorMessage="Password is Required!!!" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="row">
                                    <div class="col-xs-6">
                                        
                                        <asp:Button ID="btnlogin" Text="Login" runat="server" class="btn btn-primary p-x-2" Height="33px" OnClick="btnlogin_Click" OnClientClick="return validate();"/>
                                    </div>
                                    <div class="col-xs-6 text-xs-right">
                                        <asp:Button ID="btnforgot"  Text="Forgot password?" runat="server" class="btn btn-link p-x-0" Onclick="btnforgot_Click" Style=" padding-bottom: 6px;
                                            border-bottom-width: 2px; padding-top: 2px;"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                       <%-- <div class="card card-inverse card-primary p-y-3" style="width:44%">
                            <div class="card-block text-xs-center">
                                <div>
                                    <h2>Sign up</h2>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                                    <button type="button" class="btn btn-primary active m-t-1">Register Now!</button>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        
    </form>
    <!-- Bootstrap and necessary plugins -->
        <script src="js/libs/jquery.min.js"></script>
        <script src="js/libs/tether.min.js"></script>
        <script src="js/libs/bootstrap.min.js"></script>
        <script>
            function verticalAlignMiddle() {
                var bodyHeight = $(window).height();
                var formHeight = $('.vamiddle').height();
                var marginTop = (bodyHeight / 2) - (formHeight / 2);
                if (marginTop > 0) {
                    $('.vamiddle').css('margin-top', marginTop);
                }
            }
            $(document).ready(function () {
                verticalAlignMiddle();
            });
            $(window).bind('resize', verticalAlignMiddle);
        </script>
        
</body>
</html>
