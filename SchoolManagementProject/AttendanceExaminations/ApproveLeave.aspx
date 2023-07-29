<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveLeave.aspx.cs" Inherits="AttendanceExaminations_ApproveLeave" %>
 
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
       
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        .Popup
        {
            background-color: #FFFFFF;
        
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 600px;
            height: 440px;
            margin-bottom:10px;
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
                            <i class="icon-th"></i>&nbsp;Approve Leave</h4>
                    </div>
                     <asp:Button ID="Button1"  Enabled="false"  runat="server"  BackColor="White" BorderStyle="None" Text="" style=" float:right; margin-right:12px"  />
               
                    
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
                                        <asp:DropDownList ID="ddlClass"  OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                <div class="col-md-2">
                                        <b style="display: none;">Employee Ref/ID :</b>
                                        <asp:DropDownList ID="ddlSection"  OnSelectedIndexChanged="ddlSection_SelectedIndexChanged"  AutoPostBack="true" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-md-2">
                                        <b style="display: none;">Division ID :</b>
                                        <asp:DropDownList ID="ddlStudent" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                 <div class="col-md-6">
                                   <asp:LinkButton ID="btnprint" runat="server"  CssClass="btn btn-success btn-xs"  Style="font-weight: bold; font-size: 14px; float:left"><span class="ace-icon fa fa-search icon-on-right bigger-110"></span>&nbsp;Search</asp:LinkButton>
                                    <asp:LinkButton ID="btnAddLeave"  OnClick="btnAddLeave_Click" runat="server" CssClass="btn btn-danger btn-xs"  ToolTip="Add Leave" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="icon-plus icon-on-right bigger-110"></span>&nbsp;Add</asp:LinkButton>
                                    <asp:LinkButton ID="btnDownloadPDF"  OnClick="btnDownloadPDF_Click"  runat="server" CssClass="btn btn-primary btn-xs"  ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>
                                   <asp:LinkButton ID="btnExportExcel"  OnClick="btnExportExcel_Click" runat="server"  CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
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
                                          
                                          <asp:TextBox ID="txtSearchBox"   runat="server" Width="147px"   Height="32px" AutoPostBack="true" Text=""   placeholder="Search..."  CssClass="form-control"></asp:TextBox>
                                        </div> 
                                           </div>
                                     </div>
                      <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background"> </cc1:ModalPopupExtender>
                   <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
                        <div class="row">
                                   
                                    <div class="widget-header" style="color: #000000; width:95%; ">
                            <h5 class="widget-title" style="color: #000000; width:100%; text-align:center; font-weight: bold;">
                              <asp:Label ID="lblFeesCollection" runat="server" Text="Add Leave" ></asp:Label>
                           </div>
                              <div class="row">
                                  <div class="space-4">
                                 </div>
                                   <div class="col-md-12">
                                     <div class="space-4">
                                    </div>
                                        <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label16" runat="server" Text="Class:"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align: left; ">
                                        <asp:DropDownList ID="ddlClassForLeave" Width="100%" runat="server" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    <div class="space-4">
                                   </div>
                                         <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label4" runat="server" Text="Section:"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align: left;">
                                        <asp:DropDownList ID="ddlSectionForLeave"   runat="server"  Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    <div class="space-4">
                                   </div>
                                         <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Student:"></asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align: left;">
                                        <asp:DropDownList ID="ddlStudentForLeave"   runat="server"  Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    <div class="space-4">
                                   </div>
                                    <div class="row">
                                        <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label12" runat="server" Text="Apply Date:"></asp:Label>
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
                               
                                  
                                     <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label6" runat="server" Text="From Date:"></asp:Label>
                                         
                                    </div>
                                    <div class="col-md-3" >
                                      <div class="input-group">
                                                <asp:TextBox ID="txtFromDate" placeholder="" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>                          

                                    </div>
                                     <div class="col-md-2" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label15" runat="server" Text="To Date:"></asp:Label>
                                
                                    </div>
                                    <div class="col-md-3" >
                                         <div class="input-group">
                                                <asp:TextBox ID="txtToDate" placeholder="" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div> 
                                    </div>
                                    </div>
                                     <div class="space-4">
                                   </div>
                                    
                                 <div class="space-4">
                                   </div>
                               
                                   <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label17" runat="server" Text="Reason:"></asp:Label>
                                
                                    </div>
                                    <div class="col-md-8" style="margin-right:10px;">
                                        <asp:TextBox ID="txtReason" runat="server" Text="" TextMode="MultiLine" Height="80px" placeholder="" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                </div>
                               </div>
                              <div class="row">
                              <div class="col-md-3">
                                </div>
                                <div class="col-md-8" style="font-weight: bold; text-align: right;">
                                        <asp:Button ID="Button2" runat="server"  Text="Cancel"   CssClass="btn btn-xs btn-white" Style="font-weight: bold;
                                                font-size: 14px; margin-top:10px; margin-bottom:10px;  float:left;  " />
                             <asp:LinkButton ID="btnsaveLeave" OnClick="btnsaveLeave_Click" runat="server" CssClass="btn btn-xs  btn-danger"   Style="font-weight: bold; margin-top:10px; margin-bottom:10px; "> <i class="icon-save bigger-90"  ></i>&nbsp;Save</asp:LinkButton>
                              <asp:LinkButton ID="btnupdate" OnClick="btnsaveLeave_Click" runat="server" CssClass="btn btn-xs  btn-danger"   Style="font-weight: bold; margin-top:10px; margin-bottom:10px; "> <i class="icon-edit bigger-90"  ></i>&nbsp;Update</asp:LinkButton>
                             
                              
                                  </div>
                                  
                               </div>
                                </div>
                                    </asp:Panel>  

                        <div style="width: 100%; overflow: auto;" >
                            <asp:GridView ID="gvApproveLeaveDetail" runat="server" 
                                AutoGenerateColumns="false" PageSize="10"
                                AllowSorting="true" AllowPaging="true"
                                OnPageIndexChanging="gvApproveLeaveDetail_PageIndexChanging"
                                OnSorting="gvApproveLeaveDetail_Sorting"
                                CssClass="table table-striped table-hover"
                                OnRowDeleting="gvApproveLeaveDetail_RowDeleting"
                                OnRowEditing="gvApproveLeaveDetail_RowEditing" 
                                OnRowDataBound="gvApproveLeaveDetail_RowDataBound"
                                
                                border="0" 
                                PagerSettings-Mode="NumericFirstLast" EmptyDataText="No Data Show" Width="100%" ShowHeader="true" DataKeyNames="Id"
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
                          <asp:TemplateField HeaderText="Apply Date"  >
                            <ItemTemplate>
                                <asp:Label ID="lblApplyDate" runat="server" Text='<%#Eval("ApplyDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="From Date"  >
                            <ItemTemplate>
                                <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="To Date"  >
                            <ItemTemplate>
                                <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Reason">
                             <ItemTemplate>
                                  <asp:Label ID="lblReason" runat="server" Text='<%#Eval("Reason")%>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                             <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                         </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave Status">
                             <ItemTemplate>
                                  <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                             <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                         </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approved By">
                             <ItemTemplate>
                                  <asp:Label ID="lblApprovedByName" runat="server" Text='<%#Eval("ApprovedByName")%>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                             <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                         </asp:TemplateField>
                                       
                         <asp:TemplateField HeaderText="Action">
                             
                             <ItemTemplate>
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                      <ContentTemplate>
                                    
                               <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 green" CommandName="Edit" ToolTip="Edit" CausesValidation="false" />  &nbsp;&nbsp;
                             
                                 <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 red"  ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                               </ContentTemplate>
                                         <Triggers>
                                          
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
             
            </div>
                </div>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btnprint" />
            
             <asp:PostBackTrigger ControlID="btnDownloadPDF" />
             <asp:PostBackTrigger ControlID="btnAddLeave" />
             <asp:PostBackTrigger ControlID="btnsaveLeave" />
             <asp:PostBackTrigger ControlID="btnupdate" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

