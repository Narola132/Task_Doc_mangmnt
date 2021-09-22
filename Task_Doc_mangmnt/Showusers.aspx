<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Showusers.aspx.cs" Inherits="Task_Doc_mangmnt.Showusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="pnlshw" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Users Details</strong>
                    </div>
                    <div class="card-block">
                       
                        <br />
                        <asp:GridView ID="griduser" runat="server" OnPageIndexChanging="griduser_PageIndexChanging" AllowPaging="true" PageSize="3" AutoGenerateColumns="false" DataKeyNames="Role_Id" OnRowCommand="griduser_RowCommand" CssClass="table table-striped table-bordered datatable">
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

                                


                            </Columns>
                        </asp:GridView>

                    </div>

                </div>

            </div>

            <!--/col-->
        </div>
    </asp:Panel>
</asp:Content>
