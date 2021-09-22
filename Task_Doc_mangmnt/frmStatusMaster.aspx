<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmStatusMaster.aspx.cs" Inherits="Task_Doc_mangmnt.frmStatusMaster_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("#<%=btn_submit.ClientID %>").click(function () {
                if ($("#<%=txtstsname.ClientID %>").val().trim() == "") {
                    alert("enter the status name");

                    $("#<%=txtstsname.ClientID %>").focus();
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
                        <strong>User Status Form</strong>
                    </div>
                    
                    <div class="card-block">


                        <div class="form-group row">
                            <asp:Label ID="Stsname" runat="server" class="col-md-3 form-control-label" Text="Status Name"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtstsname" runat="server" class="form-control" placeholder="Status Name"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="Statusnamerequired" runat="server" ErrorMessage="* Status name is required" ControlToValidate="txtstsname" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>



                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" ValidationGroup="reg1" OnClick="btn_submit_Click" CssClass="btn btn-sm btn-primary" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                        <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" class="btn btn-sm btn-danger" OnClick="btn_cancel_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />


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
                        <strong>User Status</strong>
                    </div>
                    <div class="card-block">
                        <asp:Button ID="addstatus" CssClass="btn btn-sm btn-primary" runat="server" Text="Add Status" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" OnClick="addstatus_Click" /><br />
                        <br />
                        <asp:GridView ID="gridstatus" runat="server" AutoGenerateColumns="false" OnRowCommand="gridrole_RowCommand" PagerStyle-BackColor="#1985ac" PagerStyle-ForeColor="green"
                            AllowPaging="true" PageSize="3" PagerStyle-Height="20px" PagerStyle-HorizontalAlign="center" OnPageIndexChanging="gridstatus_PageIndexChanging" CssClass="table table-striped table-bordered datatable">
                            <Columns>

                                <asp:TemplateField HeaderText="UserStatus">
                                    <ItemTemplate>
                                        <span><%# Eval("StatusName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("Status_Id") %>' class="btn btn-info">
                        <i class="fa fa-edit ">

                        </i></asp:LinkButton>
                                        <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("Status_Id") %>' OnClientClick="return confirm('Are you sure?');"  class="btn btn-danger"> 
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

