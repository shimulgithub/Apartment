<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdmitCardPrint.aspx.cs" Inherits="AttendanceExaminations_AdmitCardPrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <script type="text/javascript">

      function Popup(url) {
          window.open(url, "myWindow", "status = 1, height = 600, width = 800, resizable = 0")
      }

  </script>
      <script type="text/javascript">
          function thickBoxPopup(purl) {
              tb_show('', purl, 'null');

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
        <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
        
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left:25px;
            width: 300px;
            height: auto;
            margin-bottom:10px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        .PopupFees
        {
            background-color: #FFFFFF;
        
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 550px;
            height: 480px;
            margin-bottom:10px;
        }
        
      
    </style>
    <script type="text/javascript">

     $(document).ready(function () {
        $("txtFirstNamet").on('change', function () {
            Alert(12122);
        });
        $("txtLastNamet").on('change', function () {
           Alert(12122);;
        });
     });

    </script>

<%--       <script type="text/javascript">
           $(document).ready(function () {
               $('#ddlDiscount').on('change', function () {
                   var ddlvalue = $(this).val();
                   if (ddlvalue != '1') {
                       alert('ExactEstateLocation');
                   }
                   else {
                       alert('FExactEstateLocation');
                   }
               });
        });
       </script>--%>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
      <div class="LoaderBackground_">
        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="~/assets/images/loading.gif" />
      </div>
    </ProgressTemplate>
  </asp:UpdateProgress>--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="widget-box">
              <div class="widget-header">
                    <div class="col-md-5">
                        <h4 class="widget-title">
                            <i class="icon-th"></i>&nbsp;Admit Card Print</h4>
                    </div>
                   
                   <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   <asp:Button ID="btnDemoFees"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   
                </div>
            <asp:HiddenField ID="hfAutoId" runat="server" />
            <div class="page-content">
                <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
               
               <asp:panel   ID="pnlProfileView" runat="server" >
          <%-------------------- Profile View-------------------%>
                  <div class="page-content" style="background: #EFF3F8 ">
                     <div class="row">
                                    <div class="col-md-2">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlSection" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlExamName" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                  <div class="col-md-2">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlYear" OnSelectedIndexChanged="dddlYear_SelectedIndexChanged" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                   <div class="col-md-2">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlStudent" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                 <div class="col-md-2">
                                   
                                       <asp:LinkButton ID="btnColumns" OnClick="btnColumns_Click"  runat="server" CssClass="btn btn-success btn-xs" ToolTip="Column View"  Style="font-weight: bold; font-size: 14px;margin-left:6px; float:right"><span class="ace-icon fa fa-list icon-on-right bigger-110"></span>&nbsp;Column</asp:LinkButton>
                                       <asp:LinkButton ID="btnprint" OnClick="btnprint_Click" runat="server" CssClass="btn btn-primary btn-xs"  Style="font-weight: bold; font-size: 14px; float:right"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                  
                                  </div>
                                </div>
                </div>
                        <asp:HiddenField ID="hfStudentId" runat="server" />
                        <asp:HiddenField ID="hfClassId" runat="server" />
                        <asp:HiddenField ID="hfFeesTypeId" runat="server" />
                        <asp:HiddenField ID="hfInvoiceNo" runat="server" />
                 <div class="row" >
                       <div class="col-md-6" >
                      <asp:LinkButton ID="btnPrintSelected"  OnClick="btnPrintSelected_Click" runat="server" CssClass="btn btn-primary btn-xs "  ToolTip="Selected Item Print"  Style="font-weight: bold; font-size: 14px; float:left; "><span class="icon-print icon-on-right bigger-100"> </span>&nbsp;Print Selected</asp:LinkButton> &nbsp;&nbsp;
                        </div>
                        <div class="col-md-6" >
                       <asp:LinkButton ID="btnPDFFeesCollect"  OnClick="btnPDFFeesCollect_Click" runat="server" CssClass="btn btn-primary btn-xs"  ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>
                         <asp:LinkButton ID="btnExcelFeesCollect" OnClick="btnExcelFeesCollect_Click" runat="server"  CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                         </div>
                            </div>
                  <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                   <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
                        <div class="row">
                                   
                                    <div class="col-md-12">
                                        <div class="widget-box" style=" background-color:brown;  float:left;  ">
                                            <div class="widget-header widget-header-flat">
                                                <h5 class="widget-title" style="color: #000000; font-weight: bold;">
                                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true"  Checked="true" OnCheckedChanged="ChkAll_CheckedChanged" />&nbsp;Column List</h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main"> 
                                                    <asp:CheckBoxList runat="server" ID="chkFields" DataTextField="Column_name" RepeatDirection="Vertical"
                                                        RepeatColumns="2" Style="padding: 5px;" DataValueField="Column_name" 
                                                        RepeatLayout="Table" Width="100%" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        <asp:Button ID="Button2" runat="server"  Text="Close"   CssClass="btn btn-xs btn-white" Style="font-weight: bold;
                                                font-size: 14px; margin-top:10px; margin-bottom:10px;   " />
                       </asp:Panel>

                   <asp:HiddenField ID="hfStId" runat="server" />
                    <div style="width: 100%; overflow: auto;" id="dvGV" visible="false" runat="server"  >
                         <div class="row">
                                         <div class="col-md-9" style="font-weight: bold; text-align: right;">
                                          <div style="text-align: left; padding-left: 5px;">
                            <asp:Label ID="Label7" runat="server" Text="" Font-Bold="True" Font-Size="Large"
                                ForeColor="#307ECC"></asp:Label></div>
                                         </div>
                                
                                     </div>
                            <asp:GridView ID="gvStudentWiseFeesCollectionDetail" runat="server" AutoGenerateColumns="false" PageSize="10"
                                AllowSorting="true" AllowPaging="true" CssClass="table table-striped table-hover"
                                border="0" DataKeyNames="Id"
                                OnRowDataBound="gvStudentWiseFeesCollectionDetail_RowDataBound"
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" Width="100%"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                <Columns>
                              <asp:TemplateField  >
                                 <ItemTemplate> 
                                  <asp:CheckBox ID="chkBxSelect" runat="server"  OnCheckedChanged="chkBxSelect_CheckedChanged" AutoPostBack="true"    />
                                               &nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lblId" Visible="false"  runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                  <asp:Label ID="lblClassId" Visible="false"  runat="server" Text='<%#Eval("ClassId")%>'></asp:Label>
                                  
                                   </ItemTemplate>
                                   <HeaderTemplate>
                                            <asp:CheckBox ID="chkBxHeader"  OnCheckedChanged="HeaderChkAll_CheckedChanged" AutoPostBack="true" runat="server" />
                                   </HeaderTemplate>
                               </asp:TemplateField>
                              <asp:TemplateField HeaderText="Student Name" Visible="false"  >
                                 <ItemTemplate>
                                 <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Class Name" Visible="false"  >
                                 <ItemTemplate>
                                 <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName")%>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Roll Number" Visible="false"  >
                                 <ItemTemplate>
                                 <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="Collection Code" Visible="false"  >
                                 <ItemTemplate>
                                 <asp:Label ID="lblCollectCode" runat="server" Text='<%#Eval("CollectCode")%>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                                    
                           
                         <asp:TemplateField HeaderText="Fees Type" Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblFeesType" runat="server" Text='<%#Eval("FeesType")%>'></asp:Label>
                                <asp:Label ID="lblFeesTypeId" Visible="false" runat="server" Text='<%#Eval("FeesTypeId")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Status" Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="Fees Code" Visible="false"  >
                            <ItemTemplate>
                             <asp:Label ID="lblIdAuto" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                             <asp:Label ID="lblFeesCode" runat="server" Text='<%#Eval("FeesCode")%>'></asp:Label>
                            </ItemTemplate>
                             </asp:TemplateField>
                       
                         <asp:TemplateField HeaderText="Due Date" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblDueDate" runat="server" Text='<%#Eval("DueDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Pay Id" Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentCode" runat="server" Text='<%#Eval("PaymentCode")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pay Mode"  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentMode" runat="server" Text='<%#Eval("PaymentMode")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Pay Date" Visible="false"   >
                            <ItemTemplate>
                                <asp:Label ID="lblPaymentDate" runat="server" Text='<%#Eval("PaymentDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Amount" Visible="false"   >
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                       
                          <asp:TemplateField HeaderText="Fine" Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblFine" runat="server" Text='<%#Eval("Fine")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Discount"  Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Paid" Visible="false"   >
                            <ItemTemplate>
                                <asp:Label ID="lblPaid" runat="server" Text='<%#Eval("Paid")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>  
                         <asp:TemplateField HeaderText="Payable" Visible="false"   >
                            <ItemTemplate>
                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>   
                         
                          <asp:TemplateField HeaderText="Due Balance" Visible="false"   >
                            <ItemTemplate>
                                <asp:Label ID="lblBalance" runat="server" Text='<%#Eval("Balance")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
              
                          <asp:TemplateField HeaderText="Note"  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblNote" runat="server" Text='<%#Eval("Note")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>   

                          <asp:TemplateField HeaderText="Action">
                             
                             <ItemTemplate>
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                      <ContentTemplate>
                                             <asp:LinkButton ID="lnkFeesCollect" runat="server"  CssClass="icon-plus  bigger-100 black"   CommandArgument='<%# Eval("Id") %>'  ToolTip="Fees Entry" CausesValidation="false" />
                                            &nbsp;&nbsp;
                                              <asp:LinkButton ID="lnkPrint" OnClick="lnkPrint_Click"  runat="server" CssClass="icon-print  bigger-100 black"   CommandArgument='<%# Eval("Id") %>'  ToolTip="Print" CausesValidation="false" />
                                        
                                    </ContentTemplate>
                                         <Triggers>
                                           <asp:PostBackTrigger ControlID="lnkPrint"  />
                                            <asp:PostBackTrigger ControlID="lnkFeesCollect"  />
                                          </Triggers>
                                  </asp:UpdatePanel>
                                     </ItemTemplate>
                             <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                             <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                         </asp:TemplateField>
                       
                    </Columns>
                            </asp:GridView>
                        </div>
                 
          <%--------------------- The End-----------------------%>
             </asp:panel>
            </div>
                </div>
        </ContentTemplate>
        <Triggers>
          <%--  <asp:PostBackTrigger ControlID="btnprint" />
            <asp:PostBackTrigger ControlID="btnFeesCollect" />
            <asp:PostBackTrigger ControlID="btnCollectPrint" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            <asp:PostBackTrigger ControlID="btnDownloadPDf" />--%>
            <asp:PostBackTrigger ControlID="btnExcelFeesCollect" />
            <asp:PostBackTrigger ControlID="btnPDFFeesCollect" />
            <asp:PostBackTrigger ControlID="btnPrintSelected" />
           
         <%--   <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="btnColumns" EventName="Click" />
     --%>    
            <asp:AsyncPostBackTrigger ControlID="gvStudentWiseFeesCollectionDetail" EventName="RowDataBound" />
            
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
