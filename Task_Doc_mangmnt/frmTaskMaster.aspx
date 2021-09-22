<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmTaskMaster.aspx.cs" Inherits="Task_Doc_mangmnt.frmTaskMaster_aspx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("#<%=btn_submit.ClientID %>").click(function () {
                if ($("#<%=txttskname.ClientID %>").val().trim() == "") {
                    alert("enter the taskname");

                    $("#<%=txttskname.ClientID %>").focus();
                    return false;
                }
                if ($$("#<%=txtDescription.ClientID %>").val().trim() == "") {

                    alert("Enter the task description");
                    $("#<%=txtDescription.ClientID %>").focus();
                    return false;
                }

                if ($("#<%=txtstartdate.ClientID %>").val().trim == "") {
                    alert("enter start date");
                    $("#<%=txtstartdate.ClientID %>").focus();
                    return false;
                }
                if ($("#<%=txtenddate.ClientID %>").val().trim == "") {
                    alert("enter End date");
                    $("#<%=txtenddate.ClientID %>").focus();
                    return false;
                }

                if ($("#<%=fldupload.ClientID %>").val() == "") {
                    alert("choose the file");
                    $("#<%=fldupload.ClientID %>").focus();
                    return false;
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlhdn" runat="server" Visible="false">
        <!--/col-->
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <strong>User task Form</strong>
                    </div>
                    <div id="m1"></div>
                    <div class="card-block">
                        <form action="" method="post" enctype="multipart/form-data" class="form-horizontal ">


                            <div class="form-group row">
                                <asp:Label ID="lbltaskname" runat="server" class="col-md-3 form-control-label" Text="Task Name"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txttskname" runat="server" class="form-control" placeholder="Task Name"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="taskNamerequired" runat="server" ErrorMessage="* Taskname is required" ControlToValidate="txttskname" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lbldscr" runat="server" class="col-md-3 form-control-label" Text="Description"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Description" TextMode="MultiLine"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="Descriptionrequired" runat="server" ErrorMessage="* Task Description is Required" ControlToValidate="txtDescription" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="lblstartdate" runat="server" class="col-md-3 form-control-label" Text="StartDate"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtstartdate" runat="server" class="form-control" TextMode="Date" placeholder="Startdate"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="startdaterequired" runat="server" ErrorMessage="* Startdate is Required" ControlToValidate="txtstartdate" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lblenddate" runat="server" class="col-md-3 form-control-label" Text="EndDate"></asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtenddate" runat="server" class="form-control" TextMode="Date" placeholder="Enddate"></asp:TextBox>
                                    <asp:Label ID="lblenddt" runat="server" Text="" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="enddaterequired" runat="server" ErrorMessage="* Endtdate is required" ControlToValidate="txtenddate" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label1" runat="server" class="col-md-3 form-control-label" Text="Upload Document"></asp:Label>
                                <div class="col-md-6">
                                    <asp:FileUpload ID="fldupload" runat="server" AllowMultiple="true" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Literal ID="ltrdoc" runat="server"></asp:Literal>
                            </div>

                            <div class="card-footer">
                                <asp:Button ID="btn_submit" runat="server" Text="Submit" class="btn btn-sm btn-primary" OnClick="btn_submit_Click" ValidationGroup="reg1" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" class="btn btn-sm btn-danger" OnClick="btn_Cancel_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
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
                        <asp:Button ID="addtask" CssClass="btn btn-sm btn-primary" runat="server" Text="Add User Task" OnClick="addtask_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" /><br />
                        <br />
                        <asp:GridView ID="gridtask" runat="server" AutoGenerateColumns="false" OnRowCommand="gridtask_RowCommand" AllowPaging="true" PageSize="3" OnPageIndexChanging="gridtask_PageIndexChanging" CssClass="table table-striped table-bordered datatable">
                            <Columns>

                                <asp:TemplateField HeaderText="User Task" ItemStyle-Width="75px">
                                    <ItemTemplate>
                                        <span><%# Eval("TaskName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Width="175px">
                                    <ItemTemplate>
                                        <span><%# Eval("Description") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="75px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("Task_Id") %>' class="btn btn-info">
                       
                                        <i class="fa fa-edit "></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("Task_Id") %>' OnClientClick="return confirm('Are you sure?');"  class="btn btn-danger">
            

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

