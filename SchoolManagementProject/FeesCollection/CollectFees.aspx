<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CollectFees.aspx.cs" Inherits="FeesCollection_CollectFees" %>

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
            padding-left: 10px;
            width: 328px;
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
                            <i class="icon-th"></i>&nbsp;Collect Fees</h4>
                    </div>
                   
                   <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   <asp:Button ID="btnDemoFees"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   
                </div>
            <asp:HiddenField ID="hfAutoId" runat="server" />
            <div class="page-content">
                <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
                <asp:panel   ID="pnlSearch" runat="server" visible="false" >

               
                     
                   <asp:HiddenField ID="hfTab" runat="server" />
                            <!-- Navigation Tabs starts -->
                   <div class="row">
                                    <div class="col-md-3">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlSection" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                 <div class="col-md-6">
                    
                                   <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-success btn-xs" OnClick="btnprint_Click" Style="font-weight: bold; font-size: 14px; float:left"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                 
                                   <asp:LinkButton ID="btnDownloadPDf" OnClick="btnDownloadPDF_Click" runat="server" CssClass="btn btn-primary btn-xs"  ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>
                                    
                         
                                   <asp:LinkButton ID="btnExportExcel" runat="server"  CssClass="btn btn-primary btn-xs" OnClick="btnExportExcel_Click" ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                                
                                   <asp:LinkButton ID="btnColumns" runat="server" CssClass="btn btn-success btn-xs" OnClick="btnColumns_Click" ToolTip="Column View"  Style="font-weight: bold; font-size: 14px;margin-right:6px; float:right"><span class="ace-icon fa fa-list icon-on-right bigger-110"></span>&nbsp;Column</asp:LinkButton>
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

                   <div class="row">
                    <div class="col-md-12">
                        <div class="row" >
                             <div class="col-md-10" style="float:left;  ">
                            <asp:Label ID="Label22" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="#307ECC">

                            </asp:Label>
                                 </div>
                                 
                        </div>
                        <div style="width: 100%; overflow: auto;" >
                            <asp:GridView ID="gvStudentAdmissionDetail" runat="server" AutoGenerateColumns="false" PageSize="10"
                                AllowSorting="true" AllowPaging="true" CssClass="table table-striped table-hover"
                                OnRowDeleting="gvStudentAdmissionDetail_RowDeleting"
                                OnRowDataBound="gvStudentAdmissionDetail_RowDataBound"
                                 OnRowEditing="gvStudentAdmissionDetail_RowEditing"
                                border="0" DataKeyNames="Id"
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" Width="100%"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                   <Columns>
                                   <asp:TemplateField HeaderText="Picture">
                                      <ItemTemplate>
                                <asp:Image  ID="Image1" runat="server"  Height="20"  />  
                               </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                              <ItemTemplate>
                               <asp:Label ID="lblAutoID" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                               </ItemTemplate>
                                  </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name"  Visible="false">
                            <ItemTemplate>
                             <asp:Label ID="lblAutoID_Auto" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                             <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                            </ItemTemplate>
                              </asp:TemplateField>
                         <asp:TemplateField HeaderText="Last Name"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                      
                         <asp:TemplateField HeaderText="Date Of Birth"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="B.Certificate"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblBirthCertificate" runat="server" Text='<%#Eval("BirthCertificate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                           <asp:TemplateField HeaderText="Religion"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblReligion" runat="server" Text='<%#Eval("Religion")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Blood Group"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblBloodGroup" runat="server" Text='<%#Eval("BloodGroup")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Category"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                 <asp:TemplateField HeaderText="ID Card No"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdCardNo" runat="server" Text='<%#Eval("IdCardNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Class"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Section"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSection" runat="server" Text='<%#Eval("SectionName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>  
                          <asp:TemplateField HeaderText="Roll No"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Present Address"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Eval("PresentAddress")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permanent Address"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPermanentAddress" runat="server" Text='<%#Eval("PermanentAddress")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Mobile No"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Father Name"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFatherName" runat="server" Text='<%#Eval("FatherName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="F.Phone No"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFatherPhoneNo" runat="server" Text='<%#Eval("FatherPhoneNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="F.Occupation"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFatherOccupation" runat="server" Text='<%#Eval("FatherOccupation")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>     
                             <asp:TemplateField HeaderText="Mother Name"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMotherName" runat="server" Text='<%#Eval("MotherName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="M.Phone No"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMotherPhoneNo" runat="server" Text='<%#Eval("MotherPhoneNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="M.Occupation"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMotherOccupation" runat="server" Text='<%#Eval("MotherOccupation")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Guardian Name"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblGuardianName" runat="server" Text='<%#Eval("GuardianName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="G.Phone No"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblGuardianPhoneNo" runat="server" Text='<%#Eval("GuardianPhoneNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="G.Occupation"  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblGuardianOccupation" runat="server" Text='<%#Eval("GuardianOccupation")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField> 
                          <asp:TemplateField HeaderText="Action">
                             
                             <ItemTemplate>
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                      <ContentTemplate>
                                    <%--   <asp:LinkButton ID="lnkDownload" runat="server" CssClass="icon-list bigger-130 green" Text=""  OnClick="lnkDownload_Click" ToolTip="Detail"  CommandArgument='<%# Eval("Id") %>'></asp:LinkButton> &nbsp;&nbsp;
                                     --%>  
                                          
                                          
                                          <asp:LinkButton ID="lnkPayment"   runat="server" CssClass="btn btn-success btn-xs"  OnClick="lnkDownload_Click" ToolTip="Collect Fees" CommandArgument='<%# Eval("Id") %>'  Style="font-weight: bold; font-size: 14px;margin-right:6px; background-color:green; border:none;"><span class="icon-dollar bigger-80"></span>&nbsp; Fees Collect</asp:LinkButton>
                           
                              
                                    </ContentTemplate>
                                         <Triggers>
                                           <asp:PostBackTrigger ControlID="lnkPayment"  />
                                          </Triggers>
                                  </asp:UpdatePanel>
                                     </ItemTemplate>
                             <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                             <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                         </asp:TemplateField>
                       
                    </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                     </asp:panel>
               <asp:panel   ID="pnlProfileView" runat="server" visible="false" >
          <%-------------------- Profile View-------------------%>
                  <div class="page-content" style="background: #EFF3F8 ">
                   <div class="row" >
                 
                     <div class="col-md-2" > 
                    <div class="row" >
                     <asp:Image  ID="ProfileImage1" runat="server"  style="margin-left:10px; margin-right:10px; margin-bottom:10px; height:100px; width:90px;  margin-top:10px;"    Height="100" Width="100"  /> 
                    </div>
                  </div>
                      
                                  
                     <div class="col-md-3" style="text-align: left; font-size:12px;  " > 
                         <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label24" runat="server" Text="Name:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                     <asp:Label ID="lblStudentName" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                       <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6" >
                            <asp:Label ID="Label3" runat="server" Text="Class Section:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; "  >
                    <asp:Label ID="LblClass" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>  
                       <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label7" runat="server" Text="Category:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="LblCategory" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                        <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label5" runat="server" Text="Roll Number:"></asp:Label>
                        </div>
                     <div class="col-md-6"  style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblRollNo" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                       </div>
                     <div class="col-md-3" style="text-align: left; font-size:12px;  " > 
                            <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label1" runat="server" Text="ID Card Number:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; "  >
                    <asp:Label ID="lblICardNo" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                           <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label2" runat="server" Text="BloodGroup:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblBloodGrp" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label8" runat="server" Text="Mobile No:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblMobileNo" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                        <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label10" runat="server" Text="Date Of Birth:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblDOB" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                         </div>
                     <div class="col-md-3" style="text-align: left; font-size:12px;  " > 


                          <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label11" runat="server" Text="Father Name:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblFatherName" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label13" runat="server" Text="F.Phone No:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblFatherPhoneNo" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                         <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label9" runat="server" Text="Mother Name:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblMotherName" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label14" runat="server" Text="M.Phone No:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblMotherFhone" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                     </div>
                        
                   
                   <div class="col-md-1" >
                          <div class="row" >
                       
                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-success btn-xs" OnClick="btnBack_Click" ToolTip="Go To Previous"  Style="font-weight: bold; font-size: 14px;margin-right:6px; float:right"><span class="ace-icon fa fa-arrow-left icon-on-right bigger-110"></span>&nbsp;Back</asp:LinkButton>
                         
                          </div>
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
                      <asp:LinkButton ID="btnCollectSelected"  OnClick="btnCollectSelected_Click" runat="server" CssClass="btn  btn-success btn-xs"  ToolTip="Selected Item Collect"  Style="font-weight: bold; font-size: 14px; float:left; margin-left:10px; "><span class="icon-edit icon-on-right bigger-100"> </span>&nbsp;Collect Selected</asp:LinkButton>
                      
                           </div>
                        <div class="col-md-6" >
                       <asp:LinkButton ID="btnPDFFeesCollect"  OnClick="btnPDFFeesCollect_Click" runat="server" CssClass="btn btn-primary btn-xs"  ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>
                         <asp:LinkButton ID="btnExcelFeesCollect" OnClick="btnExcelFeesCollect_Click" runat="server"  CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                         </div>
                            </div>
                          <cc1:ModalPopupExtender ID="mpFeesCollect" runat="server" PopupControlID="pnlFessCollect" TargetControlID="btnDemoFees" CancelControlID="btnFeesClose" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                   <asp:Panel ID="pnlFessCollect" runat="server" CssClass="PopupFees" align="center" style = "display:none">
                         <div class="widget-header" style="color: #000000; width:95%; ">
                            <h5 class="widget-title" style="color: #000000; width:100%; text-align:center; font-weight: bold;">
                              <asp:Label ID="lblFeesCollection" runat="server" Text="Fees Collection" ></asp:Label>
                           </div>
                              <div class="row">
                                  <div class="space-4">
                                 </div>
                                   <div class="col-md-12">
                                     <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label12" runat="server" Text="Date:"></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtDate" placeholder="" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                   <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblName" runat="server" Text="Amount:"></asp:Label>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmount"
                                            ErrorMessage="Sorry! Amount required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-8" style="margin-right:10px;">
                                        <asp:TextBox ID="txtAmount" runat="server" Text="" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="space-4">
                                   </div>
                                         <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label4" runat="server" Text="Discount Group:"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align: left;">
                                        <asp:DropDownList ID="ddlDiscount" Enabled="false"  runat="server"  Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                     <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label6" runat="server" Text="Discount:"></asp:Label>
                                         
                                    </div>
                                    <div class="col-md-3" >
                                        <asp:TextBox ID="txtDiscount" Enabled="false"  runat="server"  OnTextChanged="txtSearchBox_TextChanged" Text="" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label15" runat="server" Text="Fine:"></asp:Label>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFine"
                                            ErrorMessage="Sorry! Discount required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3" style="margin-right:10px;">
                                        <asp:TextBox ID="txtFine" runat="server" Text="" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                     <div class="space-4">
                                   </div>
                                     <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label16" runat="server" Text="Pay Mode:"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align: left; ">
                                        <asp:DropDownList ID="ddlPayMode" Width="100%" runat="server" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label18" runat="server" Text="Total Amt(TK):"></asp:Label>
                                         
                                    </div>
                                    <div class="col-md-3" >
                                        <asp:TextBox ID="txtTotal" runat="server" Text="" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label19" runat="server" Text="Paid:"></asp:Label>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFine"
                                            ErrorMessage="Sorry! Discount required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3" style="margin-right:10px;">
                                        <asp:TextBox ID="txtPaid" runat="server" Text="" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                   <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label17" runat="server" Text="Note:"></asp:Label>
                                
                                    </div>
                                    <div class="col-md-8" style="margin-right:10px;">
                                        <asp:TextBox ID="txtNote" runat="server" Text="" TextMode="MultiLine" Height="100px" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                </div>
                               </div>
                              <div class="row">
                              <div class="col-md-3">
                                </div>
                                <div class="col-md-8" style="font-weight: bold; text-align: right;">
                                        <asp:Button ID="btnFeesClose" runat="server"  Text="Cancel"   CssClass="btn btn-xs btn-white" Style="font-weight: bold;
                                                font-size: 14px; margin-top:10px; margin-bottom:10px;  float:left;  " />
                                         <asp:LinkButton ID="btnFeesCollect" runat="server" CssClass="btn btn-xs  btn-success"  OnClick="btnFeesCollect_Click"  Style="font-weight: bold; margin-top:10px; margin-bottom:10px; "> <i class="icon-dollar bigger-100"  ></i>&nbsp;Collect Fees</asp:LinkButton>
                                          <asp:LinkButton ID="btnCollectPrint" runat="server" CssClass="btn btn-xs  btn-success" OnClick="btnCollectPrint_Click"  Style="font-weight: bold; margin-top:10px; margin-bottom:10px; "> <i class="icon-print  bigger-100"  ></i>&nbsp;Collect & Print</asp:LinkButton>
                              
                                  </div>
                                  
                               </div>
                       </asp:Panel>
                   <asp:HiddenField ID="hfStId" runat="server" />
                 <div style="width: 100%; overflow: auto;" >
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
                                 <asp:Label ID="lblStudentName" Visible="false"  runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                                 <asp:Label ID="lblCollectCode" Visible="false"  runat="server" Text='<%#Eval("CollectCode")%>'></asp:Label>
                               
                               </ItemTemplate>
                                   <HeaderTemplate>
                                            <asp:CheckBox ID="chkBxHeader"  OnCheckedChanged="HeaderChkAll_CheckedChanged" AutoPostBack="true" runat="server" />
                                   </HeaderTemplate>
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
                          <asp:TemplateField HeaderText="Due Balance"  >
                            <ItemTemplate>
                                <asp:Label ID="lblBalance" runat="server" Text='<%#Eval("Balance")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Action">
                             
                             <ItemTemplate>
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                      <ContentTemplate>
                                             <asp:LinkButton ID="lnkFeesCollect" runat="server" OnClick="lnkFeesCollect_Click" CssClass="icon-plus  bigger-100 black"   CommandArgument='<%# Eval("Id") %>'  ToolTip="Fees Entry" CausesValidation="false" />
                                            &nbsp;&nbsp;
                                              <asp:LinkButton ID="lnkPrint" OnClick="lnkPrint_Click" runat="server" CssClass="icon-print  bigger-100 black"   CommandArgument='<%# Eval("Id") %>'  ToolTip="Print" CausesValidation="false" />
                                        
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
            <asp:PostBackTrigger ControlID="btnprint" />
            <asp:PostBackTrigger ControlID="btnFeesCollect" />
            <asp:PostBackTrigger ControlID="btnCollectPrint" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            <asp:PostBackTrigger ControlID="btnDownloadPDf" />
            <asp:PostBackTrigger ControlID="btnExcelFeesCollect" />
            <asp:PostBackTrigger ControlID="btnPDFFeesCollect" />
            <asp:PostBackTrigger ControlID="btnPrintSelected" />
            <asp:PostBackTrigger ControlID="btnCollectSelected" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="btnColumns" EventName="Click" />
           <asp:AsyncPostBackTrigger ControlID="gvStudentWiseFeesCollectionDetail" EventName="RowDataBound" />
            
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

