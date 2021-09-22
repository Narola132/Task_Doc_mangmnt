<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmRoleMaster.aspx.cs" Inherits="Task_Doc_mangmnt.frmRollMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("#<%=btn_submit.ClientID %>").click(function () {
                if ($("#<%=txtrolename.ClientID %>").val().trim() == "") {
                    alert("enter the role name");

                    $("#<%=txtrolename.ClientID %>").focus();
                   return false;
               }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlhdn" runat="server" Visible="false">


        <!--/.row-->
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>User Role</strong>
                    </div>

                    <div class="card-block">


                        <div class="form-group row">
                            <asp:Label ID="lblrole" runat="server" class="col-md-3 form-control-label" Text="User Role"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtrolename" runat="server" class="form-control" placeholder="User Role"></asp:TextBox>
                                <label class="valMessage">*</label><label id="ValName" class="valMessage"></label><br />
                                <asp:RequiredFieldValidator ID="rolenamerequired" runat="server" ErrorMessage="* User Role is required" ControlToValidate="txtrolename" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" class="btn btn-sm btn-primary" ValidationGroup="reg1" OnClick="btn_submit_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="CANCEL" class="btn btn-sm btn-danger" OnClick="btn_Cancel_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />


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
                        <asp:Button ID="addrole" CssClass="btn btn-sm btn-primary" runat="server" Text="Add Role" OnClick="addrole_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" /><br />
                        <br />
                        <asp:GridView ID="gridrole" runat="server" AutoGenerateColumns="false" OnRowCommand="gridrole_RowCommand" PagerStyle-BackColor="#1985ac" PagerStyle-ForeColor="green"
                            AllowPaging="true" PageSize="3" PagerStyle-Height="20px" PagerStyle-HorizontalAlign="center" OnPageIndexChanging="gridrole_PageIndexChanging" CssClass="table table-striped table-bordered datatable">
                            <Columns>

                                <asp:TemplateField HeaderText="UserRole">
                                    <ItemTemplate>
                                        <span><%# Eval("RoleName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("Role_Id") %>' class="btn btn-info">
                       <i class="fa fa-edit "></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("Role_Id") %>' OnClientClick="return confirm('Are you sure?');"  class="btn btn-danger"> 
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




