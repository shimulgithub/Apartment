<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchFeesCollection.aspx.cs" Inherits="FeesCollection_SearchFeesCollection" %>

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
                            <i class="icon-th"></i>&nbsp;Fees Search(Payment)</h4>
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
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlSection" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                          <div class="col-md-2">
                           <asp:DropDownList ID="ddlFeesType" runat="server" CssClass="select2">
                             </asp:DropDownList>
                              </div>
                                 <div class="col-md-6">
                    
                                    <asp:LinkButton ID="btnprint" runat="server" OnClick="btnprint_Click" CssClass="btn btn-success btn-xs"  Style="font-weight: bold; font-size: 14px; float:left"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                   <asp:LinkButton ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-primary btn-xs" ToolTip="Print File" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:Left;"><span class="icon-refresh icon-on-right bigger-110"></span>&nbsp;Clear</asp:LinkButton>
                                   <asp:LinkButton ID="btnPaymentPrint" OnClick="btnPaymentPrint_Click" runat="server" CssClass="btn btn-primary btn-xs" ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="icon-print e icon-on-right bigger-110"></span>&nbsp;Print</asp:LinkButton>
                                   <asp:LinkButton ID="btnExportExcel" OnClick="btnExportExcel_Click" runat="server"  CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                                
                                    
                                     </div>
                                </div>
                     <div class="row">
                    <div class="col-md-12">
                            <div class="space-4">
                                      </div>
                                     <div class="row">
                                         <div class="col-md-9" style="font-weight: bold; text-align: right;">
                                          <div style="text-align: left; padding-left: 5px;">
                                         <asp:Label ID="Label22" runat="server" Text="" Font-Bold="True" Font-Size="Large"
                                          ForeColor="#307ECC"></asp:Label></div>
                                         </div>
                                          <div style="text-align: left; padding-left: 5px; float:right; ">
                                          <div class="col-md-3" style="text-align: left; padding-left: 5px; ">
                                          
                                          <asp:TextBox ID="txtSearchBox" OnTextChanged="txtSearchBox_TextChanged" runat="server" Width="147px"   Height="32px" AutoPostBack="true" Text=""   placeholder="Search..."  CssClass="form-control"></asp:TextBox>
                                        </div> 
                                           </div>
                                     </div>
                            <div style="width: 100%; overflow: auto;" >
                            <asp:GridView ID="gvStudentWiseFeesCollectionDetail" runat="server" AutoGenerateColumns="false" PageSize="10"
                                AllowSorting="true" AllowPaging="true" CssClass="table table-striped table-hover"
                                border="0" DataKeyNames="Id"
                                OnRowDataBound="gvStudentWiseFeesCollectionDetail_RowDataBound" 
                                OnSorting="gvStudentWiseFeesCollectionDetail_Sorting"
                                 OnPageIndexChanging="gvStudentWiseFeesCollectionDetail_PageIndexChanging"
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" Width="100%"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                <Columns>
                              <asp:TemplateField Visible="false"  >
                              <ItemTemplate> 
                                  <asp:CheckBox ID="chkBxSelect" runat="server"  AutoPostBack="true"    />
                                               &nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Label ID="lblId" Visible="false"  runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                   <asp:Label ID="lblClassId" Visible="false"  runat="server" Text='<%#Eval("ClassId")%>'></asp:Label>
                                  
                               </ItemTemplate>
                                   <HeaderTemplate>
                                            <asp:CheckBox ID="chkBxHeader"  OnCheckedChanged="HeaderChkAll_CheckedChanged" AutoPostBack="true" runat="server" />
                                   </HeaderTemplate>
                                </asp:TemplateField>
                                    
                            <asp:TemplateField HeaderText="Student Name"  >
                            <ItemTemplate>
                             <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                            </ItemTemplate>
                             </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fees Code"  >
                            <ItemTemplate>
                             <asp:Label ID="lblIdAuto" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                             <asp:Label ID="lblFeesCode" runat="server" Text='<%#Eval("FeesCode")%>'></asp:Label>
                            </ItemTemplate>
                             </asp:TemplateField>
                         <asp:TemplateField HeaderText="Fees Type"  >
                            <ItemTemplate>
                                <asp:Label ID="lblFeesType" runat="server" Text='<%#Eval("FeesType")%>'></asp:Label>
                                <asp:Label ID="lblFeesTypeId" Visible="false" runat="server" Text='<%#Eval("FeesTypeId")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Due Date" >
                            <ItemTemplate>
                                <asp:Label ID="lblDueDate" runat="server" Text='<%#Eval("DueDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                      
                         <asp:TemplateField HeaderText="Status"  >
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Amount"  >
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pay Id"  >
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentCode" runat="server" Text='<%#Eval("PaymentCode")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                           <asp:TemplateField HeaderText="Pay Mode"  >
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentMode" runat="server" Text='<%#Eval("PaymentMode")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Pay Date"  >
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentDate" runat="server" Text='<%#Eval("PaymentDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Discount"  >
                            <ItemTemplate>
                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Fine" >
                            <ItemTemplate>
                                <asp:Label ID="lblFine" runat="server" Text='<%#Eval("Fine")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Payable"  >
                            <ItemTemplate>
                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Paid"  >
                            <ItemTemplate>
                                <asp:Label ID="lblPaid" runat="server" Text='<%#Eval("Paid")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>  
                          <asp:TemplateField HeaderText="Balance"  >
                            <ItemTemplate>
                                <asp:Label ID="lblBalance" runat="server" Text='<%#Eval("Balance")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
          
                       
                    </Columns>
                            </asp:GridView>
                        </div>
                        </div>
                         </div>
      
                     </asp:panel>
    
            </div>
                </div>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnprint" />
              <asp:AsyncPostBackTrigger ControlID="gvStudentWiseFeesCollectionDetail" EventName="Sorting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentWiseFeesCollectionDetail" EventName="PageIndexChanging" />
          <asp:PostBackTrigger ControlID="btnExportExcel" />
           <asp:PostBackTrigger ControlID="btnPaymentPrint" />
         
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

