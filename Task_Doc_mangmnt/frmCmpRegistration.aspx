<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmCmpRegistration.aspx.cs" Inherits="Task_Doc_mangmnt.frmCmpRegistration" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title></title>

    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#<%=btn_submit.ClientID %>").click(function () {

                //alert("on click");
               
                //if ($("#<%=txtcmpname.ClientID %>").val().trim() == "") {
                  //  $("#Valcmpname").html("Enter company Name");
                   // $("#<%=txtcmpname.ClientID %>").focus();
                   // return false;
                //}
                 
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

                if ($("#<%=txtemail.ClientID %>").val().trim() != "") {
                   
                    if (!fnEmailIdValidation($("#<%=txtemail.ClientID %>").val())) {
                       alert("enter valid Username");
                       $("#<%=txtemail.ClientID %>").focus();
                        return false;
                    }
                }
                if ($("#<%=txtusername.ClientID %>").val().trim() == "") {
                    alert("enter the name");
                    $("#<%=txtusername.ClientID %>").focus();
                    return false;
                }

                if ($("#<%=txtuserphone.ClientID %>").val().trim != "") {
                   
                    if (!parseInt($("#<%=txtuserphone.ClientID %>").val())) {
                        alert("enter only numberic number");
                        return false;
                    }
                    if ($("#<%=txtuserphone.ClientID %>").val().length != 10) {
                        alert("enter valid number");
                        return false;
                    }
                }

                if ($("#<%=txtuseremail.ClientID %>").val().trim() != "") {
                    
                    if (!fnEmailIdValidation($("#<%=txtuseremail.ClientID %>").val())) {
                        alert("enter valid Username");
                        $("#<%=txtuseremail.ClientID %>").focus();
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
            $("#txtuserphone").keypress(function (e) {
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
        <!--/col-->
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Company Registration Form</strong>
                    </div>
            
                    <div class="card-block">

                            <div class="form-group row">
                                <asp:Label ID="cmpname" runat="server" class="col-md-3 form-control-label" Text="Company Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtcmpname" runat="server" class="form-control" placeholder="Company Name"></asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="CompanyNamerequired" runat="server" ErrorMessage="* Companyname is required" ControlToValidate="txtcmpname" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="address" runat="server" class="col-md-3 form-control-label" Text="Address"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Adress" TextMode="MultiLine"></asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="addressrequired" runat="server" ErrorMessage="* Address is required" ControlToValidate="txtaddress" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="phone" runat="server" class="col-md-3 form-control-label" Text="Phone No"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtphone" runat="server" class="form-control" placeholder="Phone No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="phonerequired" runat="server" ControlToValidate="txtphone" ErrorMessage="* Phoneno is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lblemail" runat="server" class="col-md-3 form-control-label" Text="Email"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="CompanyEmail"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredemail" runat="server" ControlToValidate="txtemail" ErrorMessage="* Company Email is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="username" runat="server" class="col-md-3 form-control-label" Text="Contact Person Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtusername" runat="server" class="form-control" placeholder="ContactPerson_Name"></asp:TextBox>
                                     
                                    <asp:RequiredFieldValidator ID="txtusernamerquired" runat="server" ControlToValidate="txtusername" ErrorMessage="* ContactPerson Name is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="userphone" runat="server" class="col-md-3 form-control-label" Text="Contact Person Phoneno"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtuserphone" runat="server" class="form-control" placeholder="ContactPersonPhoneNO"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtuserphonenorquired" runat="server" ControlToValidate="txtuserphone" ErrorMessage="* ContactPerson Phone NO is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="useremail" runat="server" class="col-md-3 form-control-label" Text="Contact Person Email"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtuseremail" runat="server" class="form-control" placeholder="ContactPersonEmail"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="txtuseremailrquired" runat="server" ControlToValidate="txtuseremail" ErrorMessage="* ContactPerson Email is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label1" runat="server" class="col-md-3 form-control-label" Text="Upload Document"></asp:Label>
                                <div class="col-md-6">
                                    <asp:FileUpload ID="fldupload" runat="server" AllowMultiple="true" />

                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Literal ID="ltrdoc" runat="server"></asp:Literal>
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" OnClick="btn_submit_Click" class="btn btn-sm btn-primary" ValidationGroup="reg1" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                                <asp:Button ID="btn_reset" runat="server" Text="RESET" OnClick="btn_reset_Click" class="btn btn-sm btn-danger" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                                <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" OnClick="btn_cancel_Click" class="btn btn-sm btn-danger" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />



                            </div>

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
                        <asp:Button ID="addcompany" CssClass="btn btn-sm btn-primary" runat="server" Text="Add Comapny" OnClick="addcompany_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" /><br />
                        <br />
                        <asp:GridView ID="gridcomp" runat="server" AutoGenerateColumns="false" OnRowCommand="gridcomp_RowCommand" AllowPaging="true" PageSize="3" OnPageIndexChanging="gridcomp_PageIndexChanging" CssClass="table table-striped table-bordered datatable">
                            <Columns>

                                <asp:TemplateField HeaderText="Company Name">
                                    <ItemTemplate>
                                        <span><%# Eval("ComponyName") %></span>
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

                                <asp:TemplateField HeaderText="Company Email">
                                    <ItemTemplate>
                                        <span><%# Eval("Email") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <span><%# Eval("ContactPersonName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <ItemTemplate>
                                        <span><%# Eval("ContactPhone") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <span><%# Eval("ContactEmail") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("Compony_Id") %>' class="btn btn-info">
                        <i class="fa fa-edit "></i>

                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("Compony_Id") %>' OnClientClick="return confirm('Are you sure?');" class="btn btn-danger"> 
                     <i class="fa fa-trash-o ">

                     </i></asp:LinkButton>

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
