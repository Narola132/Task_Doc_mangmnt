<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="frmprofile.aspx.cs" Inherits="Task_Doc_mangmnt.frmprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
                <div class="animated fadeIn">
                 
                    <!--/.row-->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <strong>Admin Profile</strong>
                                </div>
                                <div class="card-block">
                                    <form action="" method="post" enctype="multipart/form-data" class="form-horizontal ">
                                       
                                        <div class="form-group row">
                                            <asp:Label ID="name" runat="server" class="col-md-3 form-control-label" text="Name"></asp:Label>
                                                <div class="col-md-6">
                                                <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="namerequired" runat="server" ErrorMessage="Name is Required"  ControlToValidate="txtname" ValidationGroup="reg1" style="color:red"></asp:RequiredFieldValidator> 
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <asp:Label ID="address" runat="server" class="col-md-3 form-control-label" text="Address"></asp:Label>
                                            <div class="col-md-6">
                                            <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Content.." TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="addressrequired" runat="server" ErrorMessage="Address is Required"  ControlToValidate="txtaddress" ValidationGroup="reg1" style="color:red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                           <asp:Label ID="phone" runat="server" class="col-md-3 form-control-label" text="Phone"></asp:Label>
                                            <div class="col-md-6">
                                            <asp:TextBox ID="txtphone" runat="server" class="form-control" placeholder="Phone No"></asp:TextBox>    
                                             <asp:RequiredFieldValidator ID="phonerequired" runat="server" ControlToValidate="txtphone" ErrorMessage="Phone is Required" ValidationGroup="reg1" style="color:red" ></asp:RequiredFieldValidator>   
                                            </div>
                                        </div>
                                        
                                       
                                          <div class="form-group row">
                                    <!--        <asp:Label ID="Label1" runat="server" class="col-md-3 form-control-label" text="Upload Document"></asp:Label>
                                     -->       <div class="col-md-6">
                                               <asp:FileUpload ID="file" runat="server" />
                                           <!--      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="file" ErrorMessage="Role is Required" ValidationGroup="reg1" style="color:red" ></asp:RequiredFieldValidator>
                                         -->  
                                         <img id="userImage" runat="server" height="50" width="50" />
                                               </div>
                                        </div>        
                                        
                                                                      
                                    </form>
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="btn_Upadatedetails" runat="server" Text="UPDATE DETAILS"  class="btn btn-sm btn-primary" OnClick="btn_Upadatedetails_Click"  ValidationGroup="reg1" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;"  />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="CANCEL"  class="btn btn-sm btn-danger" OnClick="btn_Cancel_Click" Style="text-align: center; padding-top: 5px; padding-bottom: 25px;" />
                                    
                                    
                                </div>
                            </div>
                        
                        </div> 
                    
                        <!--/col-->
                    </div>
                   
                </div>
            </div>

       
</asp:Content>
