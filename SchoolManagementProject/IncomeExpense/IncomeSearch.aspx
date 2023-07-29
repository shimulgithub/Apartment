<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IncomeSearch.aspx.cs" Inherits="IncomeExpense_IncomeSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript">

       function Popup(url) {
         window.open(url, "myWindow", "status = 1, height = 600, width = 800, resizable = 0")
         }
         
        </script>
    

    <style type="text/css">
  td, tr ,th
 {
  border:0; 
 
 }
     
     .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
    padding: 8px;
    
    vertical-align: top;
    border-top: 0px solid #ddd;
}

 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="widget-box">
              <div class="widget-header">
                    <div class="col-md-5">
                        <h4 class="widget-title">
                            <i class="icon-th"></i>&nbsp;Income Search</h4>
                    </div>
                   
                     <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   <asp:Button ID="btnDemoFees"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   
                </div>
            <asp:HiddenField ID="hfAutoId" runat="server" />
            <div class="page-content">
                <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
                <asp:panel   ID="pnlSearch" runat="server"  >

               
                     
                   <asp:HiddenField ID="hfTab" runat="server" />
                         <!-- Navigation Tabs starts -->
                        <div class="row">
                                    <div class="col-md-2">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                        <asp:DropDownList ID="ddlIncomeHead" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                               <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                      <asp:Label ID="lblFromDate" runat="server" Text="From Date :"></asp:Label>
                                        
                                </div>
                              
                                    <div class="col-md-2">
                                         <div class="input-group">
                                                <asp:TextBox Enabled="false" ID="txtFromDate" placeholder="From Date"   runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div> 
                                    </div>
                            <div class="col-md-1" style="font-weight: bold; text-align: right;">
                                      <asp:Label ID="Label1" runat="server" Text="To Date :"></asp:Label>
                                        
                                </div>
                          <div class="col-md-2">
                               <div class="input-group">
                                                <asp:TextBox ID="txtToDate" Enabled="false" placeholder="To Date"   runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div> 
                              </div>
                                 <div class="col-md-4">
                    
                                   <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click"  CssClass="btn btn-success btn-xs"  Style="font-weight: bold; font-size: 14px; float:left"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                  
                                    <asp:LinkButton ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-primary btn-xs" ToolTip="Print File" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:Left;"><span class="icon-refresh icon-on-right bigger-110"></span>&nbsp;Clear</asp:LinkButton>
                                
                                   <asp:LinkButton ID="btnPrint" runat="server" OnClick="btnPrint_Click" CssClass="btn btn-primary btn-xs" ToolTip="Print File" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="icon-print icon-on-right bigger-110"></span>&nbsp;Print</asp:LinkButton>

                                   <asp:LinkButton ID="btnDownloadExcel" runat="server"  OnClick="btnExportExcel_Click" CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                                
                                    
                                     </div>
                                </div>
                        <div class="row" >
                            <div class="space-4">
                                      </div>
                                     <div class="row">
                                         <div class="col-md-9" style="font-weight: bold; text-align: right;">
                                          <div style="text-align: left; padding-left: 5px;">
                                <asp:Label ID="Label7" runat="server" Text="" Font-Bold="True" Font-Size="Large"
                                ForeColor="#307ECC"></asp:Label></div>
                                         </div>
                                          <div style="text-align: left; padding-left: 5px; float:right; ">
                                          <div class="col-md-3" style="text-align: left; padding-left: 5px;margin-right:10px; ">
                                          
                                          <asp:TextBox ID="txtSearchBox" runat="server" Width="147px"   Height="32px" AutoPostBack="true" Text=""   placeholder="Search..."  CssClass="form-control"></asp:TextBox>
                                        </div> 
                                              </div>
                                     </div>
                            <asp:GridView ID="gvIncomeSearch" runat="server" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="10" AllowSorting="true"
                                CssClass="table table-striped table-hover"
                                OnSorting="gvIncomeSearch_Sorting"
                                OnPageIndexChanging="gvIncomeSearch_PageIndexChanging"
                                EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="Id" Border="0" PagerSettings-Mode="NumericFirstLast" 
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Invoice No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo")%>'></asp:Label>
                                              <asp:Label ID="lblId" runat="server" Visible="false"  Text='<%#Eval("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Reference No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReferenceNo" runat="server" Text='<%#Eval("RefNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Income Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIncomeDate" runat="server" Text='<%#Eval("IncomeDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Head Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Eval("HeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Amount(TK)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIncomeAmount" runat="server" Text='<%#Eval("IncomeAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="Action">
                                      
                                        <ItemTemplate>
                                       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                      <ContentTemplate>
                                
                                            <asp:LinkButton ID="lnkbtnPrint" runat="server" OnClick="lnkbtnPrint_Click"   CommandArgument='<%# Eval("Id") %>'  ToolTip="Print" CssClass="icon-print bigger-130 black"
                                                  CausesValidation="false" />
                                            &nbsp;&nbsp;  
                                          </ContentTemplate>
                                            <Triggers>
                                           <asp:PostBackTrigger ControlID="lnkbtnPrint"  />
                                          </Triggers>
                                          </asp:UpdatePanel>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                     
                                          </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                  </div>
      
                     </asp:panel>
    
            </div>
                </div>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnprint" />
             <asp:PostBackTrigger ControlID="btnDownloadExcel" />
          
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>


