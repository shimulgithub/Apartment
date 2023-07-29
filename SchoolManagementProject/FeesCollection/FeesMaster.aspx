<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeesMaster.aspx.cs" Inherits="FeesCollection_FeesMaster" %>

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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          
           <div class="widget-box">
                             <div class="widget-header">
                                    <div class="row">
                                         <div class="col-md-5">
                                          <h4 class="widget-title">
                                          <i class="icon-th"></i>&nbsp;Fees Master</h4>
  
                                         </div> 
                         
                                           
                                     </div>
                              </div>
          
           
                 <div class="page-content">
            <asp:HiddenField ID="hfAutoId" runat="server" />
               
               <asp:panel   ID="pnlProfileView" runat="server"  >
          <%-------------------- Profile View-------------------%>
                 <div class="row" >

                  <div class="col-md-5" style="background: #EFF3F8 none repeat scroll 0 0;"> 
                    <div class="space-4">
                                    </div>
                                    <div class="space-4">
                                      </div>
                                    <div class="space-4">
                                      </div>
                                    <div class="space-4">
                                      </div>
                                    <div class="space-4">
                                      </div>
                                       <div class="row">
                                         <div class="space-4">
                                         </div>
                                          <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                                <asp:Label ID="Label3" runat="server" Text="Class Name :"></asp:Label>
                                              </div>  
                                           <div class="col-md-8">
                                           <asp:DropDownList ID="ddlClass" runat="server" CssClass="select2">
                                                
                                          </asp:DropDownList>
                                             </div>
                                     </div>
                                    <div class="space-4">
                                      </div>
                                       <div class="row">
                                         <div class="space-4">
                                         </div>
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                             <asp:Label ID="Label4" runat="server" Text="Fees Type :"></asp:Label>
                                           </div>  
                                           <div class="col-md-8">
                                           <asp:DropDownList ID="ddlFeesType" runat="server" CssClass="select2">
                                          </asp:DropDownList>
                                             </div>
                                     </div>
                                     <div class="space-4">
                                      </div>
                                       <div class="row">
                                         <div class="space-4">
                                         </div>
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                             <asp:Label ID="Label5" runat="server" Text="Due Date :"></asp:Label>
                                           </div>  
                                           <div class="col-md-8">
                                              <div class="input-group">
                                             <asp:TextBox ID="txtDueDate" placeholder="Due Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                             </div>
                                     </div>
                                     <div class="space-4">
                                      </div>

                                     <div class="row">
                                         <div class="space-4">
                                         </div>
                                         <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"  ErrorMessage="Sorry! Code required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblCode" runat="server" Text="Amonut :"></asp:Label>
                                          </div>
                                          <div class="col-md-8">
                                          <asp:TextBox ID="txtAmount" runat="server" Text=""  placeholder="Amount"  CssClass="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                                     <div class="space-4">
                                      </div>
                                     <div class="space-4">
                                      </div>
                                     <div class="row">
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Text="Fine Type :"></asp:Label>
                                           </div>
                                           <div class="col-md-8"  style="font-weight: bold;" >
                                             <asp:RadioButton ID="rdNone" AutoPostBack="true"   OnCheckedChanged="rdNone_CheckedChanged"  Text="None" runat="server" />
                                               &nbsp; &nbsp;
                                               <asp:RadioButton ID="rdPercentage" Text="Percentage" AutoPostBack="true" OnCheckedChanged="rdPercentage_CheckedChanged" runat="server" />
                                               &nbsp; &nbsp;
                                               <asp:RadioButton ID="rdFixAmount"  Text ="Fixed Amount" AutoPostBack="true" OnCheckedChanged="rdFixAmount_CheckedChanged"  runat="server" />
                                               
                                           </div>
                                      </div>
                                    
                                  <div class="space-4">
                                      </div>
                                     <div class="row">
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                              
                                           </div>
                                           <div class="col-md-4" style="font-weight: bold; text-align: Left;">
                                              <asp:Label ID="lblPercentage" runat="server" Text="Percentage"></asp:Label>
                                             <asp:TextBox ID="txtPercentage" runat="server" AutoPostBack="true" OnTextChanged="txtPercentage_TextChanged"   placeholder="" CssClass="form-control" />
                                           </div>
                                         <div class="col-md-4" style="font-weight: bold; text-align: Left;">
                                              <asp:Label ID="Label6" runat="server" Text="Fixed Amount"></asp:Label>
                                             <asp:TextBox ID="txtFixedAmount" runat="server" AutoPostBack="true"  OnTextChanged="txtFixedAmount_TextChanged"  placeholder="" CssClass="form-control" />
                                           </div>
                                      </div>
                                       <div class="space-4">
                                      </div>

                                     <div class="row">
                                         <div class="space-4">
                                         </div>
                                         <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                             <asp:Label ID="Label1" runat="server" Text="Total Amonut :"></asp:Label>
                                          </div>
                                          <div class="col-md-8">
                                          <asp:TextBox ID="txtTotalAmount" runat="server" Text=""  placeholder=""  CssClass="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                                       <div class="space-4">
                                      </div>
                                     <div class="space-4">
                                      </div>
                                   
                                     <div class="space-4">
                                      </div>
                                   
                                     <div class="space-4">
                                      </div>
                                   
                                     <div class="space-4">
                                      </div>
                                   <div class="space-4">
                                      </div>
                                     <div class="row">
                                         <div class="col-md-4">
                                         </div>
                                       <div class="col-md-8" style="text-align: right;">
                                          <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-xs btn-primary" OnClick="btnNew_Click" Style="font-weight: bold;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New</asp:LinkButton>&nbsp;&nbsp;
                                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-xs  btn-success" OnClick="btnsave_Click" ValidationGroup="UserForm" Style="font-weight: bold;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>
                                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-xs  btn-success" OnClick="btnsave_Click"  Style="font-weight: bold;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>
                                       </div>

                                       
                                      </div>
                                   <div class="space-4">
                                      </div>
                                   <div class="space-4">
                                      </div>
                                   <div class="space-4">
                                      </div>
                                     

                  </div>
                   
                    <div class="col-md-7" >
                          <div class="row" >
                                   <div class="row">
                                         <div class="col-md-9" style="font-weight: bold; text-align: right;">
                                          <div style="text-align: left; padding-left: 5px;">
                            <asp:Label ID="Label7" runat="server" Text="" Font-Bold="True" Font-Size="Large"
                                ForeColor="#307ECC"></asp:Label></div>
                                         </div>
                                          <div class="col-md-3">
                                          <asp:LinkButton ID="btnExportExcel" runat="server"  OnClick="btnExportExcel_Click"    CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                                
                                          <asp:TextBox ID="txtSearchBox" OnTextChanged="txtSearchBox_TextChanged" runat="server" Width="100px"  Height="32px" AutoPostBack="true" Text=""  placeholder="Search..."  CssClass="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                              <div style="width: 100%; overflow: auto;">
                            <asp:GridView ID="gvFeesMasterInfoList" runat="server" AutoGenerateColumns="False"
                                AllowPaging="true" PageSize="10" AllowSorting="true" OnSorting="gvFeesMasterInfoList_Sorting"
                                OnPageIndexChanging="gvFeesTypeInfoList_PageIndexChanging"
                                CssClass="gvv table table-striped table-hover" OnRowDeleting="gvFeesMasterInfoList_RowDeleting"
                                OnRowEditing="gvFeesMasterInfoList_RowEditing" OnRowDataBound="gvFeesMasterInfoList_RowDataBound"
                                EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="Id" Border="0"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Left" />
                                <RowStyle Wrap="false" />
                                <HeaderStyle Wrap="false" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAutoID" runat="server" Text='<%#Eval("SLNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Class Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeType" runat="server" Text='<%#Eval("FeeType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Due Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDueDate" runat="server" Text='<%#Eval("DueDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Width="50px" Text='<%#Eval("Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Fine ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFineAmount" runat="server" Width="50px" Text='<%#Eval("FineAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Total Amt"  >
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server"  Text='<%#Eval("TotalAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    

                                 <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 green"
                                                CommandName="Edit" ToolTip="Edit" CausesValidation="false" />
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 red"
                                                ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                  </div>
                  </div>

                </div>
          <%--------------------- The End-----------------------%>
             </asp:panel>
            </div>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            
              <asp:AsyncPostBackTrigger ControlID="gvFeesMasterInfoList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvFeesMasterInfoList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
