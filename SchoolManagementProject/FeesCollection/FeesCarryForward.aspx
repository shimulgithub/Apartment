<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeesCarryForward.aspx.cs" Inherits="FeesCollection_FeesCarryForward" %>

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
                            <i class="icon-th"></i>&nbsp; Fees Carry Forward</h4>
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
                                   <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-xs" OnClick="btnprint_Click" ToolTip="Download PDF" Style="font-weight: bold; font-size: 14px; margin-left:5px; float:right;"><span class="ace-icon fa fa-file icon-on-right bigger-110"></span>&nbsp;PDF</asp:LinkButton>--%>
                                   <asp:LinkButton ID="btnExcelDownload" o runat="server"  CssClass="btn btn-primary btn-xs" OnClick="btnExportExcel_Click" ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
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
                            <asp:TemplateField HeaderText="Email"  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                                       
                             <asp:TemplateField HeaderText="Present Address"  >
                            <ItemTemplate>
                                <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Eval("PresentAddress")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Mobile No"  >
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Father Name"  >
                            <ItemTemplate>
                                <asp:Label ID="lblFatherName" runat="server" Text='<%#Eval("FatherName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="F.Phone No" >
                            <ItemTemplate>
                                <asp:Label ID="lblFatherPhoneNo" runat="server" Text='<%#Eval("FatherPhoneNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="Amount(TK)">
                             
                             <ItemTemplate>
                                   <asp:TextBox ID="txtAmount" runat="server"  Text='<%#Eval("Amount")%>'  Width="80px" CssClass="form-control"  />
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
             <asp:PostBackTrigger ControlID="btnExcelDownload" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmissionDetail" EventName="RowDataBound" />
        
            
              
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

