<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="TemplateFieldmaster.aspx.cs" Inherits="Task_Doc_mangmnt.TemplateFieldmaster" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/jquery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $("#<%=btn_submit.ClientID %>").click(function () {
                if ($("#<%=ddltemp.ClientID %>").val() == "0") {
                    alert("select templatename");
                    return false;
                }

                if ($("#<%=txttempfieldname.ClientID %>").val().trim() == "") {
                    alert("enter the templatefieldnname");

                    $("#<%=txttempfieldname.ClientID %>").focus();
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
                        <strong>Template Field</strong>
                    </div>

                    <div class="card-block">

                        <div class="form-group row">
                            <asp:Label ID="template" runat="server" class="col-md-3 form-control-label" Text="Select Template Name"></asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddltemp" runat="server" CssClass="form-control input-sm" Width="475px" Style="display: inline;" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ddltemplaterequired" runat="server" ControlToValidate="ddltemp" ErrorMessage="* Select Template name is required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator><br />

                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="tempfieldname" runat="server" class="col-md-3 form-control-label" Text="TemplateField Name"></asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txttempfieldname" runat="server" class="form-control" placeholder="Templatefield Name"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="tempfieldsnamerequired" runat="server" ErrorMessage="* Templatefield name is required" ControlToValidate="txttempfieldname" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" OnClick="btn_submit_Click" class="btn btn-sm btn-primary" ValidationGroup="reg1" CssClass="btn btn-sm btn-primary" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
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


                        <div class="col-md-12" style="padding-left: 0px;">
                            <div align="left" class="col-md-2">
                                <asp:Button ID="addtemp" CssClass="btn btn-sm btn-primary" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" runat="server" Text="Add Template Field" OnClick="addtemp_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                
                            </div>
                            <div align="right" class="col-md-10">
                                <span>Select Template Name :</span>&nbsp;<asp:DropDownList ID="ddltempdownload" CssClass="form-control input-sm" runat="server" Width="200px" Style="display: inline;"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddltempdownload" ErrorMessage="Template name is Required" ValidationGroup="reg2" Display="Dynamic" Style="color: red"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btndownload" runat="server" Text="Download Template" CssClass="btn btn-sm btn-primary" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" ValidationGroup="reg2" OnClick="btndownload_Click" />
                            </div>
                        </div>


                        <div class="form-control row" style="border: none; margin-top: 40px;">


                            <asp:GridView ID="gridtempfield" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridtempfield_PageIndexChanging" AllowPaging="true" PageSize="3" OnRowCommand="gridtempfield_RowCommand"  CssClass="table table-striped table-bordered datatable">
                                <Columns>

                                    <asp:TemplateField HeaderText="Template Name">
                                        <ItemTemplate>
                                            <span><%# Eval("TemplateName") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TemplateField Name">
                                        <ItemTemplate>
                                            <span><%# Eval("FieldName") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>




                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedt" runat="server" CommandName="EditMode" CommandArgument='<%# Eval("Template_Id") %>' class="btn btn-info">
                                            <i class="fa fa-edit "></i>
                                               
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btndlt" runat="server" CommandName="DeleteMode" CommandArgument='<%# Eval("TemplateField_ID") %>' OnClientClick="return confirm('Are you sure?');" class="btn btn-danger">
                                            <i class="fa fa-trash-o "></i>
                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>

            </div>

            <!--/col-->
        </div>
    </asp:Panel>
</asp:Content>

