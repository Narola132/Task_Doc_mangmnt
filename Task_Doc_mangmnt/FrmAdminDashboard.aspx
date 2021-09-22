<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FrmAdminDashboard.aspx.cs" Inherits="Task_Doc_mangmnt.FrmAdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <strong>User Details</strong>
                                </div>
                                <div class="card-block">
        
    <asp:GridView ID="gridadmveiw" runat="server" AutoGenerateColumns="false" OnRowCommand="gridadmveiw_RowCommand" 
                               AllowPaging="true" PageSize="3" PagerStyle-Height="20px" OnPageIndexChanging="gridadmveiw_PageIndexChanging" CssClass="table table-striped table-bordered datatable" >
        <Columns>
            <asp:TemplateField HeaderText="Username" >
                <ItemTemplate>
                    <span><%# Eval("Name") %></span>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Usertask" >
                <ItemTemplate>
                    <span><%# Eval("TaskName") %></span>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Userstatus" >
                <ItemTemplate>
                    <span><%# Eval("StatusName") %></span>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Companyname" >
                <ItemTemplate>
                    <span><%# Eval("ComponyName") %></span>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                 <asp:LinkButton ID="btnview" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("TaskAssign_Id") %>' >ViewDetails</asp:LinkButton>  
                    
                      
               </ItemTemplate>
            </asp:TemplateField>

            </Columns>
             </asp:GridView>
                            </div>
                       </div>
                </div>
        </div>
        
</asp:Content>
