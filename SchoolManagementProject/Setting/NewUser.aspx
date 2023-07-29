<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="Setting_NewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="widget-box">
                <div class="widget-header">
                      <div class="col-md-5">
                          <h4 class="widget-title">
                          <i class="icon-th"></i>&nbsp;User's Information</h4>
                       </div>
                         <div class="col-md-7" style="text-align: right;">
                           <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnNew_Click" Style="font-weight: bold; font-size: 16px;  height: 38px;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New</asp:LinkButton>
                           <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click" ValidationGroup="UserForm" Style="font-weight: bold;  font-size: 16px;  height: 38px;">  <i class="icon-save bigger-100"  ></i>&nbsp;Save </asp:LinkButton>
                           <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click" Style="font-weight: bold;"><i class="icon-edit bigger-100"  ></i>&nbsp;Update </asp:LinkButton>
                           <a class="btn btn-sm btn-purple" style="font-weight: bold; font-size: 16px; height: 38px; padding: 5px;" href="<% = ResolveUrl("~/UserInfo") %>"><i class="icon-list"></i> &nbsp; List </a>
                          </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main">
                        <div class="space-4">
                        </div>
                        <!-- <legend>Form</legend> -->
                        <div class="row">
                            <div class="col-md-5" style="text-align: left;">
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblFullName" runat="server" Text="Full Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                                            ErrorMessage="Sorry! User Full name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtFullName" runat="server" Text="" placeholder="Full Name" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblUserName" runat="server" Text="User Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                            ErrorMessage="Sorry! User name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblMsgUserNameRange" runat="server" Text="" EnableViewState="false"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name"  AutoCompleteType="Disabled"
                                            CssClass="form-control"  AutoPostBack="true"   
                                            Text=""  />
                                        &nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="Sorry! Password required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control"
                                            TextMode="Password" />
                                        <asp:Label ID="lblMsgpassword" runat="server" Text="" EnableViewState="false"></asp:Label>
                                        &nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                            ErrorMessage="Sorry! Confirm Password required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password"
                                            CssClass="form-control" TextMode="Password" />
                                        &nbsp;
                                        <asp:CompareValidator ID="cvConfirmPassword" ControlToValidate="txtConfirmPassword"
                                            ValidationGroup="UserForm" ControlToCompare="txtPassword" Operator="Equal" ErrorMessage="Passwords do not match!"
                                            Text="*" runat="Server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="lblUserGroupName" runat="server" Text="User Group Name :"></asp:Label>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="UserForm"
                                            ErrorMessage="Sorry! Select one of the User Group" ControlToValidate="ddlUserGroupName"
                                            Display="Dynamic" ValueToCompare="0" Text="*" ForeColor="Red" Operator="GreaterThan"></asp:CompareValidator>&nbsp;
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlUserGroupName" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                          <%--      <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        <asp:Label ID="lblAllColumn" runat="server" Text="For All Column :"></asp:Label>
                                        &nbsp;
                                    </div>
                                    <div class="col-md-8" style="text-align: left;">
                                        <asp:CheckBox ID="chkAllColumn" runat="server" />
                                        &nbsp; &nbsp;
                                    </div>
                                </div>--%>
                            </div>
                            <div class="col-md-5" style="text-align: left;">
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblUserRole" runat="server" Text="User Role :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlUserRole" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        &nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblEmailID" runat="server" Text="E-mail :"></asp:Label><asp:RegularExpressionValidator
                                            ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="txtEmailID" ValidationGroup="UserForm" Text="*" ForeColor="red"
                                            ErrorMessage="Please Type like-'example@domain.com'"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtEmailID" runat="server" placeholder="E-mail" CssClass="form-control" />
                                        &nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblPhoneNo" runat="server" Text="Mobile No :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMobileNo" runat="server" Text="" placeholder="Mobile No" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblUserLocation" runat="server" Text="Address :"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtUserAddress" runat="server" placeholder="Address" CssClass="form-control"
                                            TextMode="MultiLine" />
                                        &nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblIsActive" runat="server" Text="IsActive :"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align: left;">
                                        <asp:TextBox ID="txtUserId" runat="server" CssClass="TextBox" ReadOnly="true" Visible="false" />
                                        <asp:CheckBox ID="chkIsActive" runat="server" />
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2" style="text-align: left;">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                               
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hfUserId" runat="server" />
                                 <asp:HiddenField ID="hfUserIdCopy" runat="server" />
                                <asp:HiddenField ID="hfPrevuserID" runat="server" />
                                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="UserForm" ShowMessageBox="true"
                                    ForeColor="Red" DisplayMode="BulletList" Font-Overline="true" ShowSummary="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
