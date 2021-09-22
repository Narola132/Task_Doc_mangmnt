<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Showadmin.aspx.cs" Inherits="Task_Doc_mangmnt.Showadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="pnlshw" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>Admin Details</strong>
                    </div>
                    <div class="card-block">
                       
                        <br />
                        <asp:GridView ID="gridadmin" runat="server" OnPageIndexChanging="gridadmin_PageIndexChanging" AllowPaging="true" PageSize="3" PagerStyle-BackColor="#1985ac" PagerStyle-ForeColor="green" PagerStyle-Height="20px" PagerStyle-HorizontalAlign="center" AutoGenerateColumns="false" DataKeyNames="Role_Id" OnRowCommand="gridadmin_RowCommand" CssClass="table table-striped table-bordered datatable">
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
