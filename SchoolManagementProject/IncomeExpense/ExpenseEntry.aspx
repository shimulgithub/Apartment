<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExpenseEntry.aspx.cs" Inherits="ExpenseExpense_ExpenseEntry" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          
           <div class="widget-box">
                             <div class="widget-header">
                                    <div class="row">
                                         <div class="col-md-5">
                                          <h4 class="widget-title">
                                          <i class="icon-th"></i>&nbsp;Expense Entry</h4>
  
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
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                             <asp:Label ID="Label5" runat="server" Text="Ref No :"></asp:Label>
                                           </div>
                                           <div class="col-md-2">
                                             <asp:TextBox ID="txtRefNo" runat="server"     placeholder="Ref No" CssClass="form-control" />
                                           </div>
                                              <div class="col-md-3" style="font-weight: bold; text-align: right;">
                                             <asp:Label ID="Label6" runat="server" Text="Invoice No:"></asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                             <asp:TextBox ID="txtInvoiceNo" runat="server"  Enabled="false"  placeholder="Invoice No" CssClass="form-control" />
                                           </div>
                                      </div>
                                       <div class="space-4">
                                      </div>
                                     <div class="row">
                                         <div class="space-4">
                                         </div>
                                         <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"  ErrorMessage="Sorry! Code required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label3" runat="server" Text="Expense Date :"></asp:Label>
                                          </div>
                                          <div class="col-md-8">
                                         <div class="input-group">
                                                <asp:TextBox ID="txtExpenseDate" placeholder="Expense Date"   runat="server" CssClass="form-control date-picker"
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
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"  ErrorMessage="Sorry! Code required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label2" runat="server" Text="Expense Head Name :"></asp:Label>
                                          </div>
                                          <div class="col-md-8">
                                        <asp:DropDownList ID="ddlExpenseHead"   runat="server" CssClass="select2">
                                        </asp:DropDownList>  

                                          </div>
                                     </div>
                                     <div class="space-4">
                                      </div>
                                    
                                     <div class="row">
                                         <div class="space-4">
                                         </div>
                                         <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"  ErrorMessage="Sorry! Code required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblCode" runat="server" Text="Expense Name :"></asp:Label>
                                          </div>
                                          <div class="col-md-8">
                                          <asp:TextBox ID="txtName" runat="server" Text=""  placeholder="Expense  Name"  CssClass="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                                     <div class="space-4">
                                      </div>
                                      
                                  <div class="space-4">
                                      </div>
                                                <div class="row">
                                         <div class="space-4">
                                         </div>
                                         <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName"  ErrorMessage="Sorry! Code required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label4" runat="server" Text="Expense Amount(TK) :"></asp:Label>
                                          </div>
                                          <div class="col-md-8">
                                          <asp:TextBox ID="txtAmount"   runat="server" Text=""  placeholder=""  CssClass="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                                     <div class="space-4">
                                      </div>
                                     <div class="space-4">
                                      </div>
                                     <div class="row">
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                         
                                            <asp:Label ID="Label1" runat="server" Text="Description :"></asp:Label>
                                           </div>
                                           <div class="col-md-8">
                                             <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"   placeholder="Description" CssClass="form-control" />
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
                                          <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-xs btn-primary" OnClick="btnNew_Click" ToolTip="Clear Data" Style="font-weight: bold;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New</asp:LinkButton>&nbsp;
                                          <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-xs  btn-success" OnClick="btnsave_Click" ValidationGroup="UserForm" ToolTip="Save only" Style="font-weight: bold;"> <i class="icon-save bigger-100"  ></i>&nbsp;Save</asp:LinkButton>
                                          <asp:LinkButton ID="btnSavePrint" runat="server" CssClass="btn btn-xs  btn-success" OnClick="btnSavePrint_Click"  ToolTip="Save & Print" Style="font-weight: bold; margin-top:10px; margin-bottom:10px; "> <i class="icon-print  bigger-100"  ></i>&nbsp;S & P</asp:LinkButton>
                                          <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-xs  btn-success" OnClick="btnsave_Click"  ToolTip="Update" Style="font-weight: bold;"> <i class="icon-edit bigger-100"  ></i>&nbsp;Update</asp:LinkButton>
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
                                          <asp:LinkButton ID="btnExportExcel" runat="server"   OnClick="btnExportExcel_Click"   CssClass="btn btn-primary btn-xs"  ToolTip="Download Excel"  Style="font-weight: bold; font-size: 14px; float:right;"><span class="ace-icon fa fa-download icon-on-right bigger-110"></span>&nbsp;Excel</asp:LinkButton>
                                
                                          <asp:TextBox ID="txtSearchBox" runat="server" Width="100px"  Height="32px" AutoPostBack="true" Text="" OnTextChanged="txtSearchBox_TextChanged"  placeholder="Search..."  CssClass="form-control"></asp:TextBox>
                                         </div>
                                     </div>
                            <asp:GridView ID="gvExpense" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" AllowSorting="true"
                                CssClass="table table-striped table-hover"
                                OnSorting="gvExpense_Sorting" OnRowDeleting="gvExpense_RowDeleting"
                                OnRowEditing="gvExpense_RowEditing"
                                 OnPageIndexChanging="gvExpense_PageIndexChanging"
                                OnRowDataBound="gvExpense_RowDataBound"
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
                                     <asp:TemplateField HeaderText="Expense Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpenseDate" runat="server" Text='<%#Eval("ExpenseDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Head Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Eval("HeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Amount(TK)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpenseAmount" runat="server" Text='<%#Eval("ExpenseAmount")%>'></asp:Label>
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
                                
                                            <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 black"
                                                CommandName="Edit" ToolTip="Edit" CausesValidation="false" />
                                            &nbsp;&nbsp;
                                            <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 black"
                                                ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                                            &nbsp;&nbsp;
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

                </div>
          <%--------------------- The End-----------------------%>
             </asp:panel>
            </div>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnExportExcel" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvExpense" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvExpense" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

