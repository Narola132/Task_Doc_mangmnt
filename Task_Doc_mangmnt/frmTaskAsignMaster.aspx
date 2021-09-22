<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmTaskAsignMaster.aspx.cs" Inherits="Task_Doc_mangmnt.frmTaskAsignMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
           

            $("#<%=btn_submit.ClientID %>").click(function () {
                if ($("#<%=ddltask.ClientID %>").val() == "0") {
                    alert("select task");
                    return false;
                }

                if ($("#<%=ddlstatus.ClientID %>").val() == "0") {
                    alert("select Status");
                    return false;
                }
                if ($("#<%=ddlcmp.ClientID %>").val() == "0") {
                    alert("select companyname");
                    return false;
                }
                if ($("#<%=ddluser.ClientID %>").val() == "0") {
                    alert("select username");
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
                        <strong>User TaskAssign Form</strong>
                    </div>
                    <div id="m1"></div>
                    <div class="card-block">

                        <div class="form-group row">
                            <asp:Label ID="task" runat="server" class="col-md-3 form-control-label" Text="Select Task"></asp:Label>
                            
                                
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddltask" runat="server" class="form-control" CssClass="form-control input-sm" Width="475px" Style="display: inline;"></asp:DropDownList>
                                <span style="color: red">*</span>
                                <asp:RequiredFieldValidator ID="ddltaskrequired" runat="server" ControlToValidate="ddltask" ErrorMessage="Task selection is required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="status" runat="server" class="col-md-3 form-control-label" Text="Select Status"></asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlstatus" runat="server" class="form-control" CssClass="form-control input-sm" Width="475px" Style="display: inline;"></asp:DropDownList>
                                <span style="color: red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlstatus" ErrorMessage="Status selection is required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="comapany" runat="server" class="col-md-3 form-control-label" Text="Select Company"></asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlcmp" runat="server" class="form-control" CssClass="form-control input-sm" Width="475px" Style="display: inline;"></asp:DropDownList>
                                <span style="color: red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlcmp" ErrorMessage="Company selection is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="user" runat="server" class="col-md-3 form-control-label" Text="Select User"></asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddluser" runat="server" class="form-control" CssClass="form-control input-sm" Width="475px" Style="display: inline; border-radius:10px;"></asp:DropDownList>
                                <span style="color: red">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddluser" ErrorMessage="Username selection is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                              <div class="form-group row">
                                <asp:Label ID="lblstartdate" runat="server" class="col-md-3 form-control-label" Text="StartDate"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtstartdate" runat="server" class="form-control" TextMode="Date" style="height:35px; display: inline;  width:475px;" placeholder="Startdate"></asp:TextBox>
                                    <span style="color: red">*</span>

                                    <asp:RequiredFieldValidator ID="startdaterequired" runat="server" ErrorMessage="Startdate is Required" ControlToValidate="txtstartdate" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lblenddate" runat="server" class="col-md-3 form-control-label" Text="EndDate"></asp:Label> 
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtenddate" runat="server"  style="height:35px; display: inline;  width:475px;"  class="form-control" TextMode="Date" placeholder="Enddate"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <asp:RequiredFieldValidator ID="enddaterequired" runat="server" ErrorMessage="Endtdate is required" ControlToValidate="txtenddate" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" OnClick="btn_submit_Click" class="btn btn-sm btn-primary" ValidationGroup="reg1" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                        <asp:Button ID="btn_reset" runat="server" Text="RESET" OnClick="btn_reset_Click" class="btn btn-sm btn-danger" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                        <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" OnClick="btn_cancel_Click" class="btn btn-sm btn-danger" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />


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
                        <asp:Button ID="adddetails" CssClass="btn btn-sm btn-primary" runat="server" Text="Add User TaskAssign Details" OnClick="adddetails_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" /><br />
                        <br />
                        <asp:GridView ID="griddetails" runat="server" AutoGenerateColumns="false" OnRowCommand="griddetails_RowCommand" AllowPaging="true" PageSize="3" OnPageIndexChanging="griddetails_PageIndexChanging" CssClass="table table-striped table-bordered datatable">
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

                                         <asp:TemplateField HeaderText="Startdate" ItemStyle-Width="125px">
                                    <ItemTemplate>
                                        <span><%# Eval("StartDate") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enddate" ItemStyle-Width="125px">
                                    <ItemTemplate>
                                        <span><%# Eval("EndDate") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField> 




                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("TaskAssign_Id") %>' class="btn btn-info">
                     <i class="fa fa-edit "></i>
                                               
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("TaskAssign_Id") %>' OnClientClick="return confirm('Are you sure?');"  class="btn btn-danger">
                     <i class="fa fa-trash-o "></i>
                                        </asp:LinkButton>

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

