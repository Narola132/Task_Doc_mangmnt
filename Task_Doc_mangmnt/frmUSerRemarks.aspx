<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="frmUSerRemarks.aspx.cs" Inherits="Task_Doc_mangmnt.frmRemarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <strong>User Remarks</strong>
                </div>
                <div class="card-block">
                    <table border="0" width="100%">

                        <tr>
                            <td class="form-group row" style="vertical-align: top"><b>Task Description :</b><br />
                                <asp:Literal ID="ltrdes" runat="server" ></asp:Literal>
                            </td>
                            <td class=""><b>Status :</b><asp:DropDownList ID="ddlsts" runat="server"  class="form-control" CssClass="form-control input-sm" Width="200px" Style="display: inline;"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ddlstsrequired" runat="server" InitialValue="0" ControlToValidate="ddlsts" ErrorMessage="* Status Required!!!"  ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr>
                            <td class="form-group row"><b>Start Date :</b>&nbsp;&nbsp;<asp:Label ID="lblsttdt" runat="server"></asp:Label><br /><b>End Date :</b>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblenddt" runat="server"></asp:Label></td>
                            <td class="form-group row"><b>Document :</b><br />
                                <asp:Literal ID="ltrdoc" runat="server" ></asp:Literal>
                            </td>


                        </tr>
                    </table>
                   
                    <div class="col-sm-10 col-md-10" style="padding:0px;margin-top:20px;margin-bottom:10px;">
                            <div class="card card-default">
                                <div class="card-header">
                                    See Your Remarks
                                    <div class="card-actions">
                                        <a class="btn-minimize" data-toggle="collapse" href="#collapseExample" aria-expanded="false" aria-controls="collapseExample"><i class="icon-arrow-down"></i></a>
                                        
                                    </div>
                                </div>
                                <div class="card-block collapse in" id="collapseExample" aria-expanded="false">
                                    <asp:Literal ID="ltrremarks" runat="server" ></asp:Literal>
                                </div>
                            </div>
                        </div>

                    <table border="0" width="100%" style="margin-top: 10px">
                        <tr>
                            <td class="form-group row"><b>Remarks :</b><br />
                                <asp:TextBox ID="txtrks" runat="server" class="form-control" Width="350" TextMode="MultiLine" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtrmsValidator1" runat="server" ControlToValidate="txtrks"  ErrorMessage="* Remarks is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </td>

                            <td class="form-group row" style="vertical-align: top"><b>Upload Document :</b>
                                <br />
                                <asp:FileUpload ID="fldupload" runat="server" AllowMultiple="true" /><br />
                                <asp:RequiredFieldValidator ID="fileuploadvalidator" runat="server" ControlToValidate="fldupload"  ErrorMessage="* Upload document is Required" ValidationGroup="reg1" Style="color: red"></asp:RequiredFieldValidator>
                            </td>

                            <%--<td class="col-md-12">


                              
                                <asp:Literal ID="ltrdocs" runat="server"></asp:Literal>
                            </td>--%>
                        </tr>
                        <tr>
                            <td class="card-footer" colspan="2">
                                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click" class="btn btn-sm btn-primary" ValidationGroup="reg1" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;"  />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btncancel" runat="server" Text="CANCEL" OnClick="btncancel_Click" class="btn btn-sm btn-danger" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;"  />
                            </td>
                        </tr>
                    </table>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
