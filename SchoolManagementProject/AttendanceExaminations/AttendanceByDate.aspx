<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceByDate.aspx.cs" Inherits="AttendanceExaminations_AttendanceByDate" %>


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
                            <i class="icon-th"></i>&nbsp;Attendance Details</h4>
                    </div>
                   
                    
                </div>
            <asp:HiddenField ID="hfAutoId" runat="server" />
            <div class="page-content">
                <asp:HiddenField ID="hfpageid" runat="server" />
                    <!-- Panel starts -->
                <asp:panel   ID="pnlSearch" runat="server" >
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
                                          <div class="row">
                                        <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label12" runat="server" Text="From Date:"></asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtFromDate" placeholder="" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                              <div class="col-md-2">
                                          <div class="row">
                                        <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label1" runat="server" Text="To Date:"></asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtToDate" placeholder="" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                 <div class="col-md-4">
                                   <asp:LinkButton ID="btnprint" runat="server" OnClick="btnprint_Click" CssClass="btn btn-success btn-xs"  Style="font-weight: bold; font-size: 14px; float:left"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                   <asp:LinkButton ID="btnDownloadPDF" OnClick="btnDownloadPDF_Click" runat="server" CssClass="btn btn-primary btn-xs"  ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>
                                   <asp:LinkButton ID="btnExcelDownload" OnClick="btnExportExcel_Click" runat="server"  CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
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
                                          
                                          <asp:TextBox ID="txtSearchBox" OnTextChanged="txtSearchBox_TextChanged"  runat="server" Width="147px"   Height="32px" AutoPostBack="true" Text=""   placeholder="Search..."  CssClass="form-control"></asp:TextBox>
                                        </div> 
                                           </div>
                                     </div>
                        <div style="width: 100%; overflow: auto;" >
                            <asp:GridView ID="gvStudentAttendanceDetail" runat="server" 
                                AutoGenerateColumns="false" PageSize="10"
                                AllowSorting="true" AllowPaging="true"
                                CssClass="table table-striped table-hover"
                                OnSorting="gvStudentAttendanceDetail_Sorting"
                                OnPageIndexChanging="gvStudentAttendanceDetail_PageIndexChanging"
                                border="0" 
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" Width="100%"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                   <Columns>
                                <%--   <asp:TemplateField HeaderText="Picture">
                                      <ItemTemplate>
                                <asp:Image  ID="Image1" runat="server"  Height="20"  />  
                               </ItemTemplate>
                              </asp:TemplateField>--%>
                         
                          <asp:TemplateField HeaderText="Student Name"  >
                            <ItemTemplate>
                             <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                            </ItemTemplate>
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
                               <asp:TemplateField HeaderText="Attendance Date"  >
                            <ItemTemplate>
                                <asp:Label ID="lblAttendanceDate" runat="server" Text='<%#Eval("AttendanceDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Attendance"  >
                            <ItemTemplate>
                                <asp:Label ID="lblAttendance" runat="server" Text='<%#Eval("Attendance")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Note">
                             <ItemTemplate>
                                   <asp:TextBox ID="txtNote" runat="server"  Width="140px" CssClass="form-control"  />
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
             
            </div>
                </div>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnprint" />
             <asp:PostBackTrigger ControlID="btnExcelDownload" />
             <asp:PostBackTrigger ControlID="btnDownloadPDF" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
