<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserActionPermission.aspx.cs" Inherits="Setting_UserActionPermission" %>

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
    <style type="text/css">
        .buttonlinkud
        {
            text-decoration: none;
            color: #3AC0F2;
            font-size: 15pt;
        }
        .disabled
        {
            color: #737373;
        }
        a:hover
        {
            text-decoration: none;
        }
        .hideGC
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message) {
            alert(message);
        }
    </script>

    <script type="text/javascript">

        function BindEvents() {
            $(document).ready(function () {
                $("[id*=gvAllModule_Test]").sortable({
                    items: 'tr:not(tr:first-child)',
                    cursor: 'pointer',
                    axis: 'y',
                    dropOnEmpty: false,
                    start: function (e, ui) {
                        ui.item.addClass("selected");
                    },
                    stop: function (e, ui) {
                        ui.item.removeClass("selected");
                    },
                    receive: function (e, ui) {
                        $(this).find("tbody").append(ui.item);
                    }

                });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents);
            </script>
            <asp:HiddenField ID="HidAccounts_VoucherMst_AutoID" runat="server" />
            <div class="table-header">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp;User Avtion Permission
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
                                <b>All Reports Name : <span class="required">*</span></b>
                                <asp:DropDownList ID="ddlReportsName" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlReportsName_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <b>User Name : <span class="required">*</span></b>
                                <asp:DropDownList ID="ddlUser" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <b>Version Name :</b>
                                <asp:TextBox ID="txtVersionName" runat="server" Text="" placeholder="Version Name"
                                    CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnPermission" runat="server" Text="Permission" ValidationGroup="UserPageAuthorizationForm"
                                    CssClass="btn btn-sm btn-primary" OnClick="btnPermission_Click" Font-Bold="True" />
                                      <asp:LinkButton ID="btnNew" runat="server"  CssClass="btn btn-sm btn-primary" OnClick="btnNew_Click"
                                        Style="font-weight: bold;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New</asp:LinkButton>
                           
                            <a class="btn btn-sm btn-purple" style="font-weight: bold; font-size: 14px;" href="<% = ResolveUrl("~/UserWiseVarsionName_List") %>">
                                    <i class="icon-list"></i>&nbsp;Version List&nbsp; </a>
                            </div>
                          
                        </div>
                        <div class="space-4">
                        </div>
                        <div class="row" id="BA" runat="server">
                            <div class="col-md-3">
                                <b>Billing Address :<span class="required">*</span></b>
                                <asp:DropDownList ID="ddlBillingCountryID" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlBillingCountryID_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Selected="True" Text="Not Included" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Included" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                   
                    <div class="row" id="AR" runat="server">
                        <div class="col-md-3">
                            <b>Assignment Rates :<span class="required">*</span></b>
                            <asp:DropDownList ID="ddlAssignmentRates" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlAssignmentRates_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Selected="True" Text="Not Included" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Included" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                       <div class="row" id="ASDR" runat="server">
                            <div class="col-md-3">
                                <b>Assignment Leave :<span class="required">*</span></b>
                                <asp:DropDownList ID="ddlAssignmentLeave" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlAssignmentLeave_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0" Selected="True">Leave Details</asp:ListItem>
                                    <asp:ListItem Value="1">Leave Summary</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" id="NetPay" runat="server">
                            <div class="col-md-3">
                                <b>Details Label :<span class="required">*</span></b>
                                <asp:DropDownList ID="ddlNetPayDetailes" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlNetPayDetailes_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Selected="True" Text="Summary" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Details" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div>
                                <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
                                <br />
                                <asp:GridView ID="gvAllModule" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                    DataKeyNames="U_Order_Priority" EmptyDataText="No Data Found" OnRowDataBound="gvAllModule_RowDataBound"
                                    Width="50%">
                                    <RowStyle ForeColor="#000" Font-Size="12px"></RowStyle>
                                    <Columns>
                                        <asp:BoundField DataField="ColumnHeadAutoID" HeaderStyle-CssClass="hideGC" ItemStyle-CssClass="hideGC"
                                            ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="U_Order_Priority" HeaderText="Order" HeaderStyle-CssClass="hideGC"
                                            ItemStyle-CssClass="hideGC" />
                                       
                                        <asp:TemplateField HeaderStyle-Width="10px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" Checked='<%#Bind("SelectAll") %>'
                                                    OnCheckedChanged="ChkAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPageId" Visible="false" runat="server" Text='<%#Bind("PageId") %>'></asp:Label>
                                                <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Bind("AutoID") %>'></asp:Label>
                                                <asp:Label ID="lblU_Order_Priority" Visible="false" runat="server" Text='<%#Bind("U_Order_Priority") %>'></asp:Label>
                                                <asp:Label ID="lblOrder_Priority" Visible="false" runat="server" Text='<%#Bind("Order_Priority") %>'></asp:Label>
                                                <asp:Label ID="lblSelectAll" Visible="false" runat="server" Text='<%#Bind("SelectAll") %>'></asp:Label>
                                                <asp:CheckBox ID="chkBoxPagesOP" runat="server" Checked='<%#Bind("CView") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Column Header Name" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHeaderText" runat="server" Text='<%#Bind("HeaderText") %>' Font-Bold="true"
                                                    CssClass="alphabetic"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderStyle-Width="60px" Visible="false" >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkUp" runat="server" CssClass="buttonlinkud" Text="&#x25B2;"
                                                    OnClick="ChangePreference" CommandArgument="up" ToolTip="Up" />
                                                <asp:LinkButton ID="lnkDown" runat="server" CssClass="buttonlinkud" Text="&#x25BC;"
                                                    OnClick="ChangePreference" CommandArgument="down" ToolTip="Down" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Column Order" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="txtU_Order_Priority"   Width="100px" Font-Bold="true"   CssClass="form-control"   runat="server" Text='<%#Bind("U_Order_Priority") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="130px" /> 
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" Width="100%" ForeColor="Black" />
                                </asp:GridView>
                                <asp:GridView ID="gvAllModule_Test" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                                    Visible="false" DataKeyNames="PageId" EmptyDataText="No Data Found" OnRowDataBound="gvAllModule_RowDataBound"
                                    Width="100%" ShowHeader="false">
                                    <RowStyle ForeColor="#000" Font-Size="12px"></RowStyle>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle HorizontalAlign="Center" Width="0px" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ExpandButton" runat="server" OnClick="ExpandButton_Click" ImageUrl="~/Images/plus.png" />
                                                <asp:Label ID="lblPageName" runat="server" Text='<%#Bind("PageName") %>' Font-Bold="true"
                                                    CssClass="alphabetic"></asp:Label>
                                                <asp:Panel ID="KeysPanel" runat="server" Visible="false">
                                                    <asp:Label ID="lblPageId" Visible="false" runat="server" Text='<%#Bind("PageId") %>'></asp:Label>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <asp:GridView ID="gvUserInfo" runat="server" AutoGenerateColumns="false" Width="50%"
                                                                CssClass="table table-bordered">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" Checked='<%#Bind("CanViewIsActive") %>'
                                                                                OnCheckedChanged="ChkAll_CheckedChanged" />
                                                                        </HeaderTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkBoxPagesOP" runat="server" Checked='<%#Bind("CView") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Column Header Name" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblHeaderText" runat="server" Text='<%#Bind("HeaderText") %>' Font-Bold="true"
                                                                                CssClass="alphabetic"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-Width="60px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkUp" CssClass="buttonlinkud" CommandArgument="up" runat="server"
                                                                                Text="&#x25B2;" OnClick="ChangePreference" />
                                                                            <asp:LinkButton ID="lnkDown" CssClass="buttonlinkud" CommandArgument="down" runat="server"
                                                                                Text="&#x25BC;" OnClick="ChangePreference" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div class="widget-box">
                                                                <div class="widget-header widget-header-flat">
                                                                    <h5 class="widget-title" style="color: #000000; font-weight: bold;">
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div class="widget-main">
                                                                        <asp:CheckBoxList runat="server" ID="chkFields" DataTextField="Column_name" RepeatDirection="Vertical"
                                                                            RepeatColumns="5" Style="padding: 5px; margin: 5px" DataValueField="Column_name"
                                                                            RepeatLayout="Table" Width="100%" />
                                                                    </div>
                                                                </div>
                                                            </div>
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
                            <asp:HiddenField ID="hfPageId" runat="server" />
                            <asp:HiddenField ID="hfUserID" runat="server" />
                            <asp:HiddenField ID="hfVersoinAutoID" runat="server" />
                            <asp:HiddenField ID="hfVersoinName" runat="server" />
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPermission" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlUser" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>