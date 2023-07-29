<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeesReminder.aspx.cs" Inherits="FeesCollection_FeesReminder" %>

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
                                          <i class="icon-th"></i>&nbsp;Reminder Type</h4>
  
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
                                                 <asp:Label ID="lblCode" runat="server" Text="Reminder Type :"></asp:Label>
                                          </div>
                                          <div class="col-md-8"> 
                                              <asp:DropDownList ID="ddlReminderType" runat="server" CssClass="select2">
                                                  <asp:ListItem Enabled="true" Text="Select Reminder Type" Value="0"></asp:ListItem>
                                                  <asp:ListItem Text="Before" Value="1"></asp:ListItem>
                                                  <asp:ListItem Text="After" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="space-4">
                                      </div>
                                     <div class="space-4">
                                      </div>
                                     <div class="row">
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDays" ErrorMessage="Sorry! Type Of Leave required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label2" runat="server" Text="Days :"></asp:Label>
                                           </div>
                                           <div class="col-md-8">
                                             <asp:TextBox ID="txtDays" runat="server"   placeholder="Days" CssClass="form-control" />
                                           </div>
                                      </div>
                                  <div class="space-4">
                                      </div>
                                     <div class="row">
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtDescription" ErrorMessage="Sorry! Type Of Leave required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
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
                                     <div class="row">
                                           <div class="col-md-4" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label3" runat="server" Text="Is Active :"></asp:Label>
                                           </div>
                                            <div class="col-md-8" style="text-align: left;">
                                             <asp:CheckBox ID="chkIsActive" runat="server" />
                                                &nbsp; &nbsp;
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
                            <asp:GridView ID="gvFeesReminderInfoList" runat="server" AutoGenerateColumns="False"
                                CssClass="gvv table table-striped table-hover"
                                OnRowDeleting="gvFeesReminderInfoList_RowDeleting"
                                OnRowEditing="gvFeesReminderInfoList_RowEditing" 
                                OnRowDataBound="gvFeesReminderInfoList_RowDataBound"
                                EmptyDataText="No Data Found" Width="100%" ShowHeader="true" DataKeyNames="Id" Border="0"
                                AlternatingRowStyle-CssClass="gridviewaltrow">
                                <RowStyle ForeColor="#000" Font-Size="12px" Wrap="false"></RowStyle>
                                <HeaderStyle Wrap="false" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAutoID" runat="server" Text='<%#Eval("SLNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Is Active">
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkisActive" runat="server"  Checked='<%# Bind("IsAct") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reminder Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReminderType" runat="server" Text='<%#Eval("ReminderType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Days">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDays" runat="server" Text='<%#Eval("Days")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
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
          <%--------------------- The End-----------------------%>
             </asp:panel>
            </div>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnupdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvFeesReminderInfoList" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvFeesReminderInfoList" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>


