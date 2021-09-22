<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmforgotpswd.aspx.cs" Inherits="Task_Doc_mangmnt.frmforgotpswd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div class="card-group vamiddle">
                        <div class="card  p-a-2" style="height:300px;">
                            <div class="card-block">
                                <h4>Forgot password</h4><br />

                                <div class="form-group input-group m-b-2">
                                    <span class="input-group-addon"><i class="icon-user"></i></span>
                                    <%--  <input type="text" class="form-control" placeholder="Username">--%>
                                    <asp:TextBox ID="txtusername" runat="server" placeholder="Username" Class="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername"  ErrorMessage="Username is Required!!!" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>--%>
                                </div><br /><br />
                                <div class="row">

                                   

                                        <asp:Button ID="btncancel" Text="Cancel" runat="server" class="col-sm-4 col-sm-offset-1  btn btn-primary p-x-2" OnClick="btncancel_Click" Height="33px" />
                                   

                                    

                                        <asp:Button ID="btnlogin" Text="Send Mail" runat="server" class="col-sm-4 col-sm-offset-2 btn btn-primary p-x-2" OnClick="btnlogin_Click" Height="33px"/>
                                    
                                    
                                    

                                </div>
                                <asp:Label ID="lblmsg" runat="server" Font-Size="16px" text=""></asp:Label>
                            </>
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
