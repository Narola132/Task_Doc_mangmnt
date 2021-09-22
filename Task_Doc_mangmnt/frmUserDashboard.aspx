<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="frmUserDashboard.aspx.cs" Inherits="Task_Doc_mangmnt.frmUserDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <strong>User Detail</strong>
                                </div>
                                <div class="card-block">
        
    <asp:GridView ID="griddetails" runat="server" AutoGenerateColumns="false" OnRowCommand="griddetails_RowCommand" AllowPaging="true" PageSize="3"  OnPageIndexChanging="griddetails_PageIndexChanging" CssClass="table table-striped table-bordered datatable" >
        <Columns>
            
            <asp:TemplateField HeaderText="Usertask" >
                <ItemTemplate>
                    <span ><%# Eval("TaskName") %></span>
                    <span class='<%# Eval("IsNew").ToString() == "True" ? "label label-danger" : "label label-danger1" %>'><%# Eval("IsNew").ToString() == "True" ? "Unreadable" : "Readable" %></span>
                 
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
