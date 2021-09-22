<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmUserStatusReport.aspx.cs" Inherits="Task_Doc_mangmnt.frmUserStatusReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<i class="ace-icon fa fa-hand-o-right icon-animated-hand-pointer blue"></i>
        <a href="#modal-table" role="button" class="blue" data-toggle="modal">User Status</a>
 

   
    <div class="widget-main">
        <div class="form-search">
            <div class="row">


                <div class="col-xs-12 col-sm-8" style="margin-left: 150px; width: 600px;">
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="ace-icon fa fa-check"></i>
                        </span>

                        <asp:TextBox ID="txtrsdnt" runat="server" class="form-control search-query" placeholder="Search Your Tasks" Width="500px" Height="35px">

                        </asp:TextBox>

                        <span class="input-group-btn">
                            <asp:LinkButton ID="btnsrsdnt" runat="server" OnClick="btnsrsdnt_Click" class="btn btn-purple btn-sm " style="margin-right:30px; height:35px;">
                                                                        	<span class="ace-icon fa fa-search icon-on-right bigger-110"></span>
																			Search
                            </asp:LinkButton>
                      

                        <asp:LinkButton ID="lnkbtnall" runat="server" class="btn btn-sm btn-warning" OnClick="lnkbtnall_Click" Style="border-radius: 10px;">
												<i class="ace-icon fa fa-fire bigger-110"></i>
												<span class="bigger-110 no-text-shadow">All</span>
											</asp:LinkButton>
                          </span>

                        <asp:Panel ID="pnlbtndwnrsdt" runat="server" Visible="false">
                            <asp:LinkButton ID="btndwnrsdnt" runat="server" OnClick="btndwnrsdnt_Click" class="btn btn-primary" Style="border-radius: 10px; height: 35px; padding-top:4px; color: #438EB9; float: left; margin-left: 30px;">
                     							<i class="ace-icon fa fa-cloud-download align-left bigger-125"></i>
                                                    Download
                            </asp:LinkButton>

                        </asp:Panel>

                      </div>

                        <asp:label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:label>
                  

                </div>
            </div>
        </div>
    </div>









       <asp:GridView ID="gridreg" runat="server" AutoGenerateColumns="false" EmptyDataRowStyle-CssClass="emptydatatext" EmptyDataText="DATA NOT FOUND" BorderColor="White" AlternatingRowStyle-BorderColor="WhiteSmoke"
        HeaderStyle-Font-Size="16px" HeaderStyle-ForeColor="White" HeaderStyle-Height="37px" AlternatingRowStyle-BackColor="WhiteSmoke" HeaderStyle-Font-Names="Helvetica" 
        PagerStyle-BackColor="#66a5f2" PagerStyle-Height="37px" PagerStyle-HorizontalAlign="Center" PagerStyle-ForeColor="White" OnPageIndexChanging="gridreg_PageIndexChanging" AllowPaging="true" PageSize="10">

        <Columns>

            <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="detail-col" ItemStyle-Width="400px" ItemStyle-Font-Size="14px" ItemStyle-ForeColor="#818494" HeaderStyle-Font-Bold="false" ItemStyle-Height="36px" ItemStyle-CssClass="align-center">

                <ItemTemplate>
                    <span><%# Eval("Name") %></span>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-CssClass="detail-col" HeaderText="Email Address" ItemStyle-Width="280px" ItemStyle-Font-Size="14px" ItemStyle-Font-Bold="false" HeaderStyle-Font-Bold="false" ItemStyle-ForeColor="#818494" ItemStyle-CssClass="align-center">
                <ItemTemplate>
                    <span><%# Eval("Address") %></span>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderStyle-CssClass="detail-col" HeaderText="Contact No." ItemStyle-Width="150px" ItemStyle-Font-Size="14px" ItemStyle-Font-Bold="false" HeaderStyle-Font-Bold="false" ItemStyle-ForeColor="#818494" ItemStyle-CssClass="align-center">
                <ItemTemplate>
                    <span><%# Eval("Phone") %></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-CssClass="detail-col" HeaderText="House No" ItemStyle-Width="120px" ItemStyle-Font-Size="14px" ItemStyle-Font-Bold="false" HeaderStyle-Font-Bold="false" ItemStyle-ForeColor="#818494" ItemStyle-CssClass="align-center">
                <ItemTemplate>
                   <span class="detail-col"><%# Eval("Username") %></span>
                </ItemTemplate>
            </asp:TemplateField>





        </Columns>

    </asp:GridView>