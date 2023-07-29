<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewUserGroup.aspx.cs" Inherits="Setting_NewUserGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents); </script>
            <div class="widget-box">
                <div class="widget-header">
                 <div class="col-md-5">
                    <h4 class="widget-title"> <i class="icon-th"></i>&nbsp;Group Information</h4>
                        </div>
                        <div class="col-md-7" style="text-align: right;">

                          <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btnNew_Click"   Style="font-weight: bold; font-size: 16px;  height: 38px;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New </asp:LinkButton>
                         
                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click"  ValidationGroup="UserForm" Style="font-weight: bold; font-size: 16px;  height: 38px;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save </asp:LinkButton>
                         
                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnsave_Click"  Style="font-weight: bold; font-size: 16px;  height: 38px;">  <i class="icon-edit bigger-100"  ></i>&nbsp;Update </asp:LinkButton>
                      
                    </div>
                         
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <div class="space-4">
                        </div>
                        <!-- <legend>Form</legend> -->
                        <div class="row">
                            <div class="col-md-12" style="text-align: left;">
                                <div class="row">
                                    <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupFullName" runat="server" Text="Full Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGroupFullName"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtGroupFullName" runat="server" Text="" placeholder="Group Full Name"
                                            CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
                                    </div>
                                    <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupShortName" runat="server" Text="Short Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtGroupShortName"
                                            ErrorMessage="Sorry! User Group Short name required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblMsgUserNameRange" runat="server" Text="" EnableViewState="false"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtGroupShortName" runat="server" placeholder="Group Short Name"
                                            CssClass="form-control" MaxLength="4" Text="" />
                                        &nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupRemarks" runat="server" Text="Remarks :"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtGroupRemarks" runat="server" placeholder="Remarks" CssClass="form-control"
                                            TextMode="MultiLine" />
                                        &nbsp;<br />
                                    </div>
                                    <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblIsActive" runat="server" Text="IsActive :"></asp:Label>
                                    </div>
                                    <div class="col-md-3" style="text-align: left;">
                                        <asp:CheckBox ID="chkIsActive" runat="server" />
                                    </div>
                                </div>
                             
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hfUserId" runat="server" />
                                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="UserForm" ShowMessageBox="true"
                                    ForeColor="Red" DisplayMode="BulletList" Font-Overline="true" ShowSummary="false" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: left;">
                                <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
                                    <asp:GridView ID="gvUserGroupInfoList" runat="server" AutoGenerateColumns="False"
                                        CssClass="gvv table table-striped table-bordered table-hover" OnRowDeleting="gvUserGroupInfoList_RowDeleting"
                                        OnRowEditing="gvUserGroupInfoList_RowEditing" OnRowDataBound="gvUserGroupInfoList_RowDataBound"
                                        EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="UserGroupID"
                                        AlternatingRowStyle-CssClass="gridviewaltrow">
                                        <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                                        <HeaderStyle Wrap="false" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="User Group Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserGroupID" Visible="false" runat="server" Text='<%#Eval("UserGroupID")%>'></asp:Label>
                                                    <asp:Label ID="lblIsActive" Visible="false" runat="server" Text='<%#Eval("IsActive")%>'></asp:Label>
                                                    <asp:Label ID="lblUserFullName" runat="server" Text='<%#Eval("UserGroupName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="25%" />
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="25%" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserGroupID_Auto" runat="server" Text='<%#Eval("UserGroupID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Group Short Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserGroupShortName" runat="server" Text='<%#Eval("UserGroupShortName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="20%" />
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserGroupName" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
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
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 green"
                                                        CommandName="Edit" ToolTip="Edit" CausesValidation="false" />
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
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvUserGroupInfoList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvUserGroupInfoList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>


