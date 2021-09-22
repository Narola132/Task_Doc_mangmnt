<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmRegistration.aspx.cs" Inherits="Task_Doc_mangmnt.frmRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("#<%=btn_submit.ClientID %>").click(function () {
                if ($("#<%=txtphone.ClientID %>").val().trim() != "") {

                    if (!parseInt($("#<%=txtphone.ClientID %>").val())) {
                        alert("enter only numberic number");
                        return false;
                    }
                    if ($("#<%=txtphone.ClientID %>").val().length != 10) {
                        alert("enter valid number");
                        return false;
                    }
                }
                if ($("#<%=txtusername.ClientID %>").val().trim() != "") {

                    if (!fnEmailIdValidation($("#<%=txtusername.ClientID %>").val())) {
                        alert("enter valid Username");
                        $("#<%=txtusername.ClientID %>").focus();
                        return false;
                    }
                }


            });


            $("#txtphone").keypress(function (e) {
                if ((e.keyCode > 47 && e.keyCode < 58) || (e.charCode > 47 && e.charCode < 58)) {
                    return true;
                }
                else {
                    return false;
                }

            });
        });

        function fnEmailIdValidation(emailaddress) {
            var email = emailaddress;
            var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            if (re.test(email) == true) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlhdn" runat="server" Visible="false">

        <!--/.row-->
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>User Registration Form</strong>
                    </div>


                    <div class="card-block">


                        <div class="form-group row">

                            <asp:Label ID="name" runat="server" class="col-md-3 form-control-label" Text="Name"></asp:Label>

                             
                            <div class="col-md-6">
                                <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                <span style="color:red">*</span>
                                <asp:RequiredFieldValidator ID="namerequired" runat="server" ControlToValidate="txtname" ErrorMessage="Name is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="address" runat="server" class="col-md-3 form-control-label" Text="Address"></asp:Label>
                            

                            <div class="col-md-6">
                                <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Content.." TextMode="MultiLine"></asp:TextBox>
                                <span style="color: red">*</span>
                                <asp:RequiredFieldValidator ID="addressrequired" runat="server" ErrorMessage="Address is Required" ControlToValidate="txtaddress" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="phone" runat="server" class="col-md-3 form-control-label" Text="Phone"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtphone" runat="server" class="form-control" placeholder="Phone No"></asp:TextBox>
                                <span style="color: red">*</span>

                                <asp:RequiredFieldValidator ID="phonerequired" runat="server" ControlToValidate="txtphone" ErrorMessage="Phone is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="username" runat="server" class="col-md-3 form-control-label" Text="Username"></asp:Label>
                           
                            <div class="col-md-6">
                                <asp:TextBox ID="txtusername" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
                                 <span style="color: red">*</span>

                                <asp:RequiredFieldValidator ID="txtusernamerquired" runat="server" ControlToValidate="txtusername" ErrorMessage="UserName is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="password" runat="server" class="col-md-3 form-control-label" Text="Password"></asp:Label>
                            
                            <div class="col-md-6">
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" class="form-control" placeholder="Password"></asp:TextBox>
                                <span style="color: red">*</span>

                                <asp:RequiredFieldValidator ID="txtpasswordrequired" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="form-group row">
                            <asp:Label ID="role" runat="server" class="col-md-3 form-control-label" Text="User Role"></asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlrole" runat="server" class="form-control"></asp:DropDownList>
                                <span style="color: red">*</span>

                                <asp:RequiredFieldValidator ID="ddlrolerequired" runat="server" ControlToValidate="ddlrole" ErrorMessage="Role is required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <!--        <asp:Label ID="Label1" runat="server" class="col-md-3 form-control-label" text="Upload Document"></asp:Label>
                                     -->
                            <div class="col-md-6">
                                <asp:FileUpload ID="file" runat="server" />
                            </div>
                        </div>
                        <img id="userImage" runat="server" height="50" width="50" />

                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" OnClick="btn_submit_Click" class="btn btn-sm btn-primary" ValidationGroup="reg1" OnClientClick="return validation();" />
                        <asp:Button ID="btn_reset" runat="server" Text="RESET" OnClick="btn_reset_Click" class="btn btn-sm btn-danger" />
                        <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" OnClick="btn_cancel_Click" class="btn btn-sm btn-danger" />


                    </div>
                </div>

            </div>

            <!--/col-->
        </div>




    </asp:Panel>

    <asp:Panel ID="pnlshw" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>User Detail</strong>
                    </div>
                    <div class="card-block">
                        <asp:Button ID="adduser" CssClass="btn btn-sm btn-primary" runat="server" Text="Add User" OnClick="adduser_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" /><br />
                        <br />
                        <asp:GridView ID="gridreg" runat="server" OnPageIndexChanging="gridreg_PageIndexChanging" AllowPaging="true" PageSize="3" AutoGenerateColumns="false" DataKeyNames="Role_Id" OnRowCommand="gridreg_RowCommand" CssClass="table table-striped table-bordered datatable">
                            <Columns>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <span><%# Eval("Name") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <span><%# Eval("Address") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Phone Number">
                                    <ItemTemplate>
                                        <span><%# Eval("Phone") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Username">
                                    <ItemTemplate>
                                        <span><%# Eval("Username") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Role Type">
                                    <ItemTemplate>
                                        <span><%# Eval("Role") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("ID") %>' class="btn btn-info">
                                        <i class="fa fa-edit "></i>
                                               
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure?');" class="btn btn-danger">
                                         <i class="fa fa-trash-o "></i>
                                        </asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>

                    </div>

                </div>

            </div>

            <!--/col-->
        </div>
    </asp:Panel>
</asp:Content>

