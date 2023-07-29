<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewUser_List.aspx.cs" Inherits="Setting_NewUser_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents); </script>
            <div class="table-header" style="background: #579EC8 none repeat scroll 0 0;">
                <div class="row">
                    <div class="col-sm-6" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp;Search User
                    </div>
                    <div class="col-sm-6" style="text-align: right;">
                        <a id="ANew" class="btn btn-primary btn-sm" style="font-weight: bold; font-size: 14px;
                            height: 38px; padding-top: 6px;" href="<% = ResolveUrl("~/CreateUser") %>"><i class="icon-plus bigger-100">
                            </i>New Create User</a>
                    </div>
                </div>
            </div>
            <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                <asp:GridView ID="gvUserInfoList" runat="server"
                    AutoGenerateColumns="False" 
                    CssClass="gvv table table-striped table-bordered table-hover"
                    OnRowDeleting="gvUserInfoList_RowDeleting" 
                    OnRowDataBound="gvUserInfoList_RowDataBound"
                    EmptyDataText="No Data Found" Width="100%" 
                    ShowHeader="true" 
                    DataKeyNames="UsersAutoID"
                    AlternatingRowStyle-CssClass="gridviewaltrow">
                    <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                    <HeaderStyle Wrap="false" />
                    <Columns>
                        <asp:TemplateField HeaderText="User Full Name">
                            <ItemTemplate>
                                <asp:Label ID="lblUsersAutoID" Visible="false" runat="server" Text='<%#Eval("UsersAutoID")%>'></asp:Label>
                                <asp:Label ID="lblUserId" Visible="false" runat="server" Text='<%#Eval("UserId")%>'></asp:Label>
                                <asp:Label ID="lblUserIsActive" Visible="false" runat="server" Text='<%#Eval("UserIsActive")%>'></asp:Label>
                                <asp:Label ID="lblPassword" Visible="false" runat="server" Text='<%#Eval("Password")%>'></asp:Label>
                                <asp:Label ID="lblConfirmPassword" Visible="false" runat="server" Text='<%#Eval("ConfirmPassword")%>'></asp:Label>
                                <asp:Label ID="lblUserFullName" runat="server" Text='<%#Eval("UserFullName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="15%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="15%" Wrap="false" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblUsersAutoID_Auto" runat="server" Text='<%#Eval("UsersAutoID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="20%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Password"  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblPasswordShow" runat="server" Text='<%#Eval("Password")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="User Group Name">
                            <ItemTemplate>
                                <asp:Label ID="lblUserGroupName" runat="server" Text='<%#Eval("UserGroupName")%>'></asp:Label>
                                <asp:Label ID="lblTUUserGroupID" Visible="false" runat="server" Text='<%#Eval("TUUserGroupID")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Role Name">
                            <ItemTemplate>
                                <asp:Label ID="lblRoleName" runat="server" Text='<%#Eval("RoleName")%>'></asp:Label>
                                <asp:Label ID="lblTURole" Visible="false" runat="server" Text='<%#Eval("TURole")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email ID">
                            <ItemTemplate>
                                <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No.">
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Active">
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkisActive" runat="server" Enabled="false" Checked='<%# Bind("IsAct") %>' />
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="5%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                             <asp:LinkButton ID="likBtnCopy" runat="server" CssClass="fa fa-copy bigger-130 Blue"
                                    OnClick="likBtnCopy_Click" CommandArgument='<%#Eval("UsersAutoID") %>' ToolTip="Copy"
                                    CommandName="Copy" CausesValidation="false" />
                                      &nbsp;&nbsp;
                                <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 green"
                                    OnClick="likBtnEdit_Click" CommandArgument='<%#Eval("UsersAutoID") %>' ToolTip="Edit"
                                    CommandName="Update" CausesValidation="false" />
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 red"
                                    ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
            <asp:HiddenField ID="HidUnit_Auto_Code" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvUserInfoList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvUserInfoList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

