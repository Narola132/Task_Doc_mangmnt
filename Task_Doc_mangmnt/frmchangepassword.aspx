<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmchangepassword.aspx.cs" Inherits="Task_Doc_mangmnt.frmchangepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        function validate() {
            var password = document.getElementById("<%=txtpassword.ClientID %>").value;
            var confirmPassword = document.getElementById("t<%=txtcnfpswd.ClientID %>").value;
            if (password != confirmPassword) {
                alert("Passwords do not match.");
                return false;
            }
            return true;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    
                    <!--/.row-->
                    <div class="row">
                        <div class="col-md-8">
                            <div class="card">
                                <div class="card-header">
                                    <strong>Change Password</strong>
                                </div>
                                <div class="card-block">
                                   
                                       
                                        <div class="form-group row">
                                            <asp:Label ID="lblpswd" runat="server" class="col-md-3 form-control-label" text="New Password"></asp:Label>
                                                <div class="col-md-6">
                                                <asp:TextBox ID="txtpassword" runat="server" class="form-control" placeholder="New Password" Width="400px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="passworderequired" runat="server" ErrorMessage="* Password is required" Display="Dynamic" ControlToValidate="txtpassword"  ValidationGroup="reg1" style="color:red"></asp:RequiredFieldValidator> 
                                            </div>
                                        </div>
                                        
                                        <div class="form-group row">
                                           <asp:Label ID="lblcnfpswd" runat="server" class="col-md-3 form-control-label" text="Conform Password"></asp:Label>
                                            <div class="col-md-6">
                                            <asp:TextBox ID="txtcnfpswd" runat="server" class="form-control" placeholder="Conform Password"  Width="400px" TextMode="Password"></asp:TextBox>   
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" controltovalidate="txtpassword" controltocompare="txtcnfpswd" ErrorMessage ="Passwords do not match." />
                                             <asp:RequiredFieldValidator ID="passwordrequired" runat="server" ControlToValidate="txtcnfpswd" Display="Dynamic" ErrorMessage="* Conform Password is required"  ValidationGroup="reg1" style="color:red" ></asp:RequiredFieldValidator>   
                                            </div>
                                        </div>
                                        <div class="card-footer">
                                    <asp:Button ID="btn_save" runat="server" Text="SAVE"  class="btn btn-sm btn-primary" ValidationGroup="reg1" OnClick="btn_save_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" OnClientClick="return validate();" />
                                    <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" class="btn btn-sm btn-danger" OnClick="btn_cancel_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;"  />
                                    <br /><br />
                                            <asp:label ID="lblmsg" runat="server" Text=""></asp:label> 

                                        </div>                
                                        </div>
                                </div>
                            </div>
                        </div>  
</center>
</asp:Content>
  
