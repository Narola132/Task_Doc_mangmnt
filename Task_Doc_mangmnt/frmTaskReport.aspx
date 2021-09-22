

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmTaskReport.aspx.cs" Inherits="Task_Doc_mangmnt.frmTaskReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    

   

    
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                    <strong>Task Detail</strong>
                    </div>
                   

                    <div class="card-block">



                               
                  <span class="input-group-btn">
                        <asp:LinkButton ID="btnsrch" runat="server" OnClick="btnsrch_Click" class="btn btn-purple btn-sm " style="margin-left:680px; height:35px;">
                           	<span class="ace-icon fa fa-search icon-on-right bigger-110"></span>
			         		Search
                            </asp:LinkButton>
                      

                        <asp:LinkButton ID="btnclear" runat="server" OnClick="btnclear_Click" class="btn btn-sm btn-primary"  Style="border-radius: 10px;" BackColor="#3a9d5d" BorderColor="#379558">
												<i class="ace-icon fa fa-fire bigger-110"></i>
												<span class="bigger-110 no-text-shadow">Clear</span>
											</asp:LinkButton>
                      
                        <asp:LinkButton ID="btndownload" runat="server" OnClick="btndownload_Click" class="btn btn-sm btn-primary" Style="border-radius: 10px; height: 30px; padding-top:4px; color: #fff; margin-left: 30px;">
                     							<i class="ace-icon fa fa-cloud-download align-left bigger-125"></i>
                                                    Download
                            </asp:LinkButton>
                    
                  </span>
                      
                      <table style="margin-top:30px; margin-left:120px;">
        <tr>
            <td>
                <asp:DropDownList ID="ddluser" runat="server" class="form-control"  CssClass="form-control input-sm" Width="175px"></asp:DropDownList>
            </td>
            <td >

                <asp:DropDownList ID="ddlcmp" runat="server" class="form-control" style="margin-left:20px;" CssClass="form-control input-sm" Width="175px"></asp:DropDownList>

            </td>

            <td  style="margin-left:80px;">
                <asp:DropDownList ID="ddltask" runat="server" class="form-control" style="margin-left:20px;" CssClass="form-control input-sm" Width="175px"></asp:DropDownList>
            </td>

            <td>
                <asp:DropDownList ID="ddlstatus" runat="server" class="form-control" style="margin-left:20px;" CssClass="form-control input-sm" Width="175px"></asp:DropDownList>
            </td>


            

            
        </tr>
                          </table>

                      <table style="margin-top:40px; margin-left:120px;">
         <tr>
             <td>
                 <asp:Label ID="lbltxtstrtdate" runat="server" Text="Start Date :" style=" margin-right:5px;"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="txtstartdate" runat="server" TextMode="Date" Width="275px" style="margin-left:20px;" Height="35px"></asp:TextBox>
             </td>

              <td>
                 <asp:Label ID="lblenddate" runat="server" Text="End Date :" style=" margin-right:5px; margin-left:24px;"></asp:Label>
             </td>
              <td>
                 <asp:TextBox ID="txtenddate" runat="server" TextMode="Date" Width="275px" style="margin-left:20px;" Height="35px"></asp:TextBox>
             </td>

             <td>
                  <asp:label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:label>
             </td>
         </tr>

     </table>
   
                   <br />   <asp:GridView ID="griddetails" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered datatable" >
                          <Columns>
                            <asp:TemplateField HeaderText="Username">
                                <ItemTemplate>
                                    <span><%# Eval("Name") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Companyname">
                                <ItemTemplate>
                                    <span><%# Eval("ComponyName") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Taskname">
                                <ItemTemplate>
                                    <span><%# Eval("TaskName") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Statusname">
                                <ItemTemplate>
                                    <span><%# Eval("StatusName") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <span><%# Eval("StartDate") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="End Date">
                                <ItemTemplate>
                                    <span><%# Eval("EndDate") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>



             

                        </Columns>
                  
                    </asp:GridView>


         
                </div>

                </div>

             </div>
                   
        </div>

       



</asp:Content>
