<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmUserReport.aspx.cs" Inherits="Task_Doc_mangmnt.frmCmpReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
        <i class="ace-icon fa fa-hand-o-right icon-animated-hand-pointer blue"></i>
        <a href="#modal-table" role="button" class="blue" data-toggle="modal">Users </a>
 
    <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                    <strong>User Detail</strong>
                    </div>
                   

                    <div class="card-block">
   
    <div class="widget-main">
        <div class="form-search">
            <div class="row">


                <div class="col-xs-12 col-sm-8" style="margin-left: 150px; width: 600px;">
                    <asp:Panel ID="pnl" runat="server" DefaultButton="btnsrsdnt">

                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="ace-icon fa fa-check"></i>
                        </span>

                        <asp:TextBox ID="txtrsdnt" runat="server" class="form-control search-query" placeholder="Search Your Users" Width="500px" Height="35px">

                        </asp:TextBox>

                        <span class="input-group-btn">
                            <asp:LinkButton ID="btnsrsdnt" runat="server" OnClick="btnsrsdnt_Click"  class="btn btn-purple btn-sm " style="margin-right:10px; height:35px;">
                                                                        	<span class="ace-icon fa fa-search icon-on-right bigger-110"></span>
																			Search
                            </asp:LinkButton>
                      

                        <asp:LinkButton ID="lnkbtnall" runat="server" class="btn btn-sm btn-primary" OnClick="lnkbtnall_Click" Style="border-radius: 10px;" BackColor="#3a9d5d" BorderColor="#379558">
												<i class="ace-icon fa fa-fire bigger-110"></i>
												<span class="bigger-110 no-text-shadow">Clear</span>
											</asp:LinkButton>
                          </span>

                        <asp:Panel ID="pnlbtndwnrsdt" runat="server" Visible="false">
                            <asp:LinkButton ID="btndwnrsdnt" runat="server" OnClick="btndwnrsdnt_Click" class="btn btn-sm btn-primary" Style="border-radius: 10px; height: 30px; padding-top:4px; color: #fff; float: left; margin-left: 10px;">
                     							<i class="ace-icon fa fa-cloud-download align-left bigger-125"></i>
                                                    Download
                            </asp:LinkButton>

                        </asp:Panel>

                      </div>

                        <asp:label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:label>
                  
    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
                        
                </div>
            </div>
        </div>
    </div>

    
    <br />   <asp:GridView ID="gridreg" runat="server" AutoGenerateColumns="false"  OnPageIndexChanging="gridreg_PageIndexChanging" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered datatable" >

        <Columns>

            <asp:TemplateField HeaderText="Name">

                <ItemTemplate>
                    <span><%# Eval("Name") %></span>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Address">
                <ItemTemplate>
                    <span><%# Eval("Address") %></span>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField  HeaderText="Contact No.">
                <ItemTemplate>
                    <span><%# Eval("Phone") %></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Email">
                <ItemTemplate>
                   <span class="detail-col"><%# Eval("Username") %></span>
                </ItemTemplate>
            </asp:TemplateField>





        </Columns>

    </asp:GridView>





</asp:Content>
