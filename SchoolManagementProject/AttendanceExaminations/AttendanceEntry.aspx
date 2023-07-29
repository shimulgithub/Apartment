<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceEntry.aspx.cs" Inherits="AttendanceExaminations_AttendanceEntry" %>

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
                            <i class="icon-th"></i>&nbsp;Attendance Entry</h4>
                    </div>
                   
                    
                </div>
            <asp:HiddenField ID="hfAutoId" runat="server" />
            <div class="page-content">
                <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
                <asp:panel   ID="pnlSearch" runat="server" visible="false" >

               
                     
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
                                    <div class="col-md-3">
                                          <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label12" runat="server" Text="Attendance Date:"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtDate" placeholder="" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                 <div class="col-md-5">
                                   <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-success btn-xs" OnClick="btnprint_Click" Style="font-weight: bold; font-size: 14px; float:left"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                 
                                    <asp:LinkButton ID="btnDownloadTemplate" runat="server" CssClass="btn btn-purple"   Style="font-weight: bold; height:38px ;float:right; "> 
                          
                               <i class="ace-icon fa fa-reply icon-only"></i>&nbsp; Template </asp:LinkButton>

                                <asp:Button ID="Button1" Text="Upload" Style="font-weight: bold; margin-right:5px; margin-left:5px;  float:right; height:38px" CssClass="btn btn-sm  btn-success" runat="server"/> 
                                   
                                 <asp:FileUpload ID="FileUpload1" Style="font-weight: bold ;float:right ; width:100px; height:38px" CssClass="btn btn-sm btn-primary" runat="server" />
                              

                                 </div>
                       </div>
                     <div class="space-4">
                      </div>
                     <div class="space-4">
                     </div>
               <div class="row">
                    <div class="col-md-12">
                              
                                     
                        </div>
                   </div>

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
                               <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                <asp:Label ID="lblClassId" Visible="false" runat="server" Text='<%#Eval("ClassId")%>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                          <asp:TemplateField HeaderText="FullName"  >
                            <ItemTemplate>
                             <asp:Label ID="lblAutoID_Auto" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                             <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FullName")%>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender"  >
                            <ItemTemplate>
                                <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Class"  >
                            <ItemTemplate>
                                <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>   
                       <asp:TemplateField HeaderText="Section"  >
                            <ItemTemplate>
                                <asp:Label ID="lblSectionId" Visible="false" runat="server" Text='<%#Eval("SectionId")%>'></asp:Label>
                                <asp:Label ID="lblSection" runat="server" Text='<%#Eval("SectionName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>  
                          <asp:TemplateField HeaderText="Roll No"  >
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Active">
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPresent" OnCheckedChanged="chkBxSelect_CheckedChanged" AutoPostBack="true"  runat="server" Text="Present"  />
                                    </ItemTemplate>
                                  <HeaderTemplate>
                                  <asp:CheckBox ID="chkPresentHeader" Text=""  Font-Bold="true" OnCheckedChanged="chkPresentHeader_CheckedChanged"    AutoPostBack="true" runat="server" />
                                  </HeaderTemplate>
                           </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Active">
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                    <asp:CheckBox ID="chkAbsence" OnCheckedChanged="chkAbsence_CheckedChanged" AutoPostBack="true"  runat="server" Text="Absence"  />
                                    </ItemTemplate>
                                  <HeaderTemplate>
                                  <asp:CheckBox ID="chkAbsenceHeader" Text=""  Font-Bold="true" OnCheckedChanged="chkAbsenceHeader_CheckedChanged"    AutoPostBack="true" runat="server" />
                                  </HeaderTemplate>
                           </asp:TemplateField>
                          <asp:TemplateField HeaderText="Is Active">
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkHalfDay"  OnCheckedChanged="chkHalfDay_CheckedChanged" AutoPostBack="true" runat="server" Text="Half Day"  />
                                    </ItemTemplate>
                                  <HeaderTemplate>
                                   <asp:CheckBox ID="chkHalfDayHeader" Text=""  Font-Bold="true"  OnCheckedChanged="chkHalfDayHeader_CheckedChanged"   AutoPostBack="true" runat="server" />
                                  </HeaderTemplate>
                           </asp:TemplateField>
                          <asp:TemplateField HeaderText="Note">
                             <ItemTemplate>
                                   <asp:TextBox ID="txtNote" runat="server"  Width="150px" CssClass="form-control"  />
                             </ItemTemplate>
                             <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                             <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                         </asp:TemplateField>
                       
                    </Columns>
                            </asp:GridView>
                        </div>

                           <div class="row">
                               
                                 <div class="col-md-12">
                                        <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" runat="server" Visible="false"  CssClass="btn btn-success btn-xs" ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-save icon-on-right bigger-110"></span>&nbsp;Save</asp:LinkButton>
                                 </div>
                       </div>
             
                    </div>
                </div>
                     </asp:panel>
             
            </div>
                </div>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnprint" />
             <asp:PostBackTrigger ControlID="btnDownloadTemplate" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDataBound" />
        
            
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>



