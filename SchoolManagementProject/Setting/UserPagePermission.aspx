<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserPagePermission.aspx.cs" Inherits="Setting_UserPagePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .required
        {
            color: #e31937;
            font-family: Verdana;
            margin: 0 5px;
        }
        
        .field-validation-error
        {
            color: #e31937;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HidAccounts_VoucherMst_AutoID" runat="server" />
            <asp:HiddenField ID="hfVersoinAutoID" runat="server" />
            <div class="table-header">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp;User Group Permission
                    </div>
                    <div class="col-sm-2" style="text-align: right;">
                    </div>
                </div>
            </div>
            <div class="page-content">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-6">
                                <label class="col-md-5 control-label text-right" for="txtBOD">
                                    <b>User Group Name : <span class="required">*</span></b>
                                </label>
                                <div class="col-md-7 text-left">
                                    <asp:DropDownList ID="ddlUserGroupName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUserGroupName_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnPermission" runat="server" Text="Permission" ValidationGroup="UserPageAuthorizationForm"
                                    CssClass="btn btn-sm btn-primary" OnClick="btnPermission_Click" Font-Bold="True" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
                                    <br />
                                    <asp:GridView ID="gvAllModule" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                        DataKeyNames="MainModuleMenuHeadID" EmptyDataText="No Data Found" OnRowDataBound="gvAllModule_RowDataBound"
                                        Width="100%" ShowHeader="false">
                                        <RowStyle ForeColor="#000" Font-Size="12px"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ExpandButton" runat="server" OnClick="ExpandButton_Click" ImageUrl="~/Images/plus.png" />
                                                    <asp:CheckBox ID="chkBoxHeader" runat="server" AutoPostBack="true" Checked='<%#Bind("CanView") %>'
                                                        OnCheckedChanged="chkAll_CheckedChanged" />
                                                    <asp:Label ID="lblMainModuleMenuHeadName" runat="server" Text='<%#Bind("MainModuleMenuHeadName") %>'
                                                        Font-Bold="true" CssClass="alphabetic"></asp:Label>
                                                    <asp:Panel ID="KeysPanel" runat="server" Visible="false">
                                                        <asp:Label ID="lblMainModuleMenuHeadID" Visible="false" runat="server" Text='<%#Bind("MainModuleMenuHeadID") %>'></asp:Label>
                                                        <div class="row">
                                                            <div class="col-md-4" style="text-align: left;">
                                                                <asp:GridView ID="gvSubMenuHead" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                                                    DataKeyNames="SubMenuHeadID" EmptyDataText="No Data Found" OnRowDataBound="gvSubMenuHead_RowDataBound"
                                                                    Width="100%" ShowHeader="false">
                                                                    <RowStyle ForeColor="#000" Font-Size="12px"></RowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemStyle HorizontalAlign="Left" Width="0px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkBoxPages" runat="server" AutoPostBack="true" Checked='<%#Bind("CanView") %>'
                                                                                    OnCheckedChanged="chkBoxPages_CheckedChanged" />
                                                                                <asp:Label ID="lblSubMenuHeadName" runat="server" Font-Bold="true" Text='<%#Bind("SubMenuHeadName") %>'></asp:Label>
                                                                                <asp:Label ID="lblSubMenuHeadID" Visible="false" runat="server" Text='<%#Bind("SubMenuHeadID") %>'></asp:Label>
                                                                                <%-- <asp:Label ID="lblModuleSubMenuHeadID" Visible="false" runat="server" Text='<%#Bind("ModuleSubMenuHeadID") %>'></asp:Label>--%>
                                                                                <asp:GridView ID="gvPagesMain" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                                                                    DataKeyNames="PageId" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="false"
                                                                                    EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-HorizontalAlign="Center"
                                                                                    OnRowDataBound="gvPagesMain_RowDataBound" Width="100%" ShowHeader="false">
                                                                                    <RowStyle ForeColor="#000" Font-Size="12px"></RowStyle>
                                                                                    <Columns>
                                                                                        <asp:TemplateField>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="ExpandColumn" runat="server" OnClick="ExpandButtonForColumn_Click"
                                                                                                    ImageUrl="~/Images/plus.png" />
                                                                                                <asp:CheckBox ID="chkBoxPagesOP" OnCheckedChanged="chkBoxColumn_CheckedChanged" AutoPostBack="true"
                                                                                                    runat="server" Checked='<%#Bind("CanView") %>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemStyle CssClass="alphabetic" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPages" runat="server" Text='<%#Bind("PageName") %>'></asp:Label>
                                                                                                <asp:Label ID="lblPagesID" Visible="false" runat="server" Text='<%#Bind("PageId") %>'></asp:Label>
                                                                                                <asp:Panel ID="ColumnPanel" runat="server" Visible="false">
                                                                                                    <asp:GridView ID="gvColumnDetails" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                                                                                        CssClass="table table-striped table-bordered table-hover" PagerSettings-Mode="NumericFirstLast"
                                                                                                        EmptyDataText="No Data Show" Width="100%" AlternatingRowStyle-CssClass="gridviewaltrow">
                                                                                                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                                                                                        <RowStyle Wrap="false" />
                                                                                                        <HeaderStyle Wrap="false" />
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField>
                                                                                                                <HeaderStyle VerticalAlign="Middle" />
                                                                                                                <%--<HeaderTemplate>
                                                                                                    <asp:CheckBox ID="ChkAllColumn"   OnCheckedChanged="chkBoxColumn_CheckedChanged" runat="server" AutoPostBack="true"/>
                                                                                                </HeaderTemplate>--%>
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:CheckBox ID="chkBoxPagesColumn"    runat="server" Checked='<%#Bind("CView") %>' />
                                                                                                                    <asp:Label ID="lblColumnAutoID" runat="server" Visible="false" Text='<%#Bind("AutoID") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Column Header Name" HeaderStyle-Font-Bold="true">
                                                                                                                <ItemTemplate> 
                                                                                                                    <asp:Label ID="lblHeaderText" runat="server" Text='<%#Bind("HeaderText") %>' Font-Bold="true"
                                                                                                                        CssClass="alphabetic"></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Column Order" HeaderStyle-Font-Bold="true">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:TextBox ID="lblOrderPriority" Width="100px" Font-Bold="true" CssClass="form-control"
                                                                                                                        runat="server" Text='<%#Bind("Order_Priority") %>'> </asp:TextBox>
                                                                                                                </ItemTemplate>
                                                                                                                <HeaderStyle Width="130px" />
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </asp:Panel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                </asp:GridView>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="99%" />
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="99%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" Width="100%" ForeColor="Black" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="space-4">
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPermission" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlUserGroupName" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>