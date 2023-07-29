<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentDetail.aspx.cs" Inherits="Student_StudentDetail" %>
  
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        
      
    </style>
 
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
            <div class="table-header">
                <div class="row">
                    <div class="col-sm-8" style="text-align: left;">
                        <i class="icon-th"></i>&nbsp;Student Details
                    </div>
                     <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
                   
                </div>
            </div>
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
                                 
                                   <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-xs" OnClick="btnprint_Click" ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>
                                    
                         
                                   <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary btn-xs" OnClick="btnprint_Click" ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                                
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
                               <asp:Label ID="lblAutoID_Auto" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                               </ItemTemplate>
                                  </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name"  Visible="false">
                            <ItemTemplate>
                             <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
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
                                       <asp:LinkButton ID="lnkDownload" runat="server" CssClass="icon-list bigger-130 green" Text=""  OnClick="lnkDownload_Click" ToolTip="Detail"  CommandArgument='<%# Eval("Id") %>'></asp:LinkButton> &nbsp;&nbsp;
                                      
                              
                                    </ContentTemplate>
                                         <Triggers>
                                           <asp:PostBackTrigger ControlID="lnkDownload"  />
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
                 <div class="row" >
                 
                  <div class="col-md-3" style="background: #EFF3F8 none repeat scroll 0 0;"> 
                    <div class="row" >
                  <asp:Image  ID="ProfileImage1" runat="server"  style="margin-left:50px;"   Height="150" Width="60%"  /> 
                    </div>
                    <div class="row"  style="font-weight: bold; text-align: center; margin-top:12px; margin-bottom:10px; font-size:16px;">
                   <asp:Label ID="lblStudentName" runat="server"   Text=""></asp:Label>
                   </div>


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
                            <asp:Label ID="Label5" runat="server" Text="Roll Number:"></asp:Label>
                        </div>
                     <div class="col-md-6"  style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblRollNo" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>
                    <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6" >
                            <asp:Label ID="Label3" runat="server" Text="Class:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; "  >
                    <asp:Label ID="LblClass" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                     <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label7" runat="server" Text="Section:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="LblSection" runat="server"   Text=""></asp:Label>
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
                      
                        <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label4" runat="server" Text="Religion:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lbllReligion" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                      
                             <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label6" runat="server" Text="B.Certificate:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblBirthCertificate" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

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
                            <asp:Label ID="Label15" runat="server" Text="F.Occupation:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                       <asp:Label ID="lblFatherOccupation" runat="server"   Text=""></asp:Label>
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

                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label17" runat="server" Text="M.Occupation:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                       <asp:Label ID="lblMotherOccupation" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>


                        <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label12" runat="server" Text="Guardian Name:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblGuardianName" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label18" runat="server" Text="G.Phone No:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblGuardianPhone" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label20" runat="server" Text="G.Occupation:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                       <asp:Label ID="lblGuardianOccupation" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>


                         <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-2">
                            <asp:Label ID="Label16" runat="server" Text="Email:"></asp:Label>
                        </div>
                     <div class="col-md-10" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblEmail" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label21" runat="server" Text="Pre.Address:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                    <asp:Label ID="lblPresentAddress" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                      <div class="row"  style="font-weight: bold; text-align: left; margin-top:12px; margin-bottom:10px; font-size:12px;">
                        
                        <div class="col-md-6">
                            <asp:Label ID="Label24" runat="server" Text="Per.Address:"></asp:Label>
                        </div>
                     <div class="col-md-6" style="font-weight: bold; text-align: right; font-size:12px;color:blueviolet; " >
                       <asp:Label ID="lblPermanentAddress" runat="server"   Text=""></asp:Label>
                    </div>
                   </div>

                  </div>
                   
                    <div class="col-md-9" >
                          <div class="row" >
                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-white btn-xs" OnClick="btnColumns_Click" ToolTip="Fees Collection"  Style="font-weight: bold; font-size: 14px;margin-right:6px; border:none;">&nbsp;Fees Collection</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-white btn-xs" OnClick="btnColumns_Click" ToolTip="Exam Detail"  Style="font-weight: bold; font-size: 14px;margin-right:6px; border:none;">&nbsp;Exam</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btn btn-white btn-xs" OnClick="btnColumns_Click" ToolTip="Attendance"  Style="font-weight: bold; font-size: 14px;margin-right:6px; border:none;">&nbsp;Attendance</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="btn btn-white btn-xs" OnClick="btnColumns_Click" ToolTip="Timeline"  Style="font-weight: bold; font-size: 14px;margin-right:6px; border:none;">&nbsp;Timeline</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton8" runat="server" CssClass="btn btn-white btn-xs" OnClick="btnColumns_Click" ToolTip="Documents"  Style="font-weight: bold; font-size: 14px;margin-right:6px; border:none;">&nbsp;Documents</asp:LinkButton>
                            
                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-success btn-xs" OnClick="btnBack_Click" ToolTip="Column View"  Style="font-weight: bold; font-size: 14px;margin-right:6px; float:right"><span class="ace-icon fa fa-arrow-left icon-on-right bigger-110"></span>&nbsp;Back</asp:LinkButton>
                         
                          </div>
                  </div>

                </div>
          <%--------------------- The End-----------------------%>
             </asp:panel>
            </div>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnprint" />
           <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDataBound" />
 <%--           <asp:PostBackTrigger ControlID="btnExportExcel" />
            <asp:AsyncPostBackTrigger ControlID="btnExportToPDF" EventName="Click" />--%>
             <asp:AsyncPostBackTrigger ControlID="btnColumns" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
            
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

