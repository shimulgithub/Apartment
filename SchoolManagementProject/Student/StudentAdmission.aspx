<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAdmission.aspx.cs" Inherits="Student_StudentAdmission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script type="text/javascript">

        function readURL(input) {
          
            var vFileExt = input.value.split('.').pop();
           
            document.getElementById('dvMsg').style.display = "none";
          
            if (vFileExt.toUpperCase() == "JPEG" || vFileExt.toUpperCase() == "JPG" || vFileExt.toUpperCase() == "PNG" || vFileExt.toUpperCase() == "GIF" || vFileExt.toUpperCase() == "BMP") {


                var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>')
        
                if (uploadControl.files[0].size > 30760) {
                    document.getElementById('dvMsg').style.display = "block";
        
                    document.getElementById('<%= fuProfilePic.ClientID %>').value = '';
                    document.getElementById('<%= Image1.ClientID %>').src = "../assets/css/img/user(3).png";
                }
                else {
                    document.getElementById('dvMsg').style.display = "none";
                   
                    var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
                  
                    if (input.files && input.files[0]) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                           
                        }
                        reader.readAsDataURL(input.files[0]);
                       
                    }

                    var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
             
                }


                var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
           
            }
            else {
                alert("Please upload a valid image file.");
                document.getElementById('<%= fuProfilePic.ClientID %>').value = '';
                document.getElementById('<%= Image1.ClientID %>').src = "";
                document.getElementById('<%= Image1.ClientID %>').src = "../assets/css/img/user(3).png";
         
            }


            var uploadControl = document.getElementById('<%= fuProfilePic.ClientID %>');
           

        }

        $("#fuProfilePic").change(function () {
            readURL(this);
         
        });
 
            
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
         
            <div class="widget-box">
                <div class="widget-header">
                    <div class="col-md-5">
                        <h4 class="widget-title">
                            <i class="icon-th"></i>&nbsp;Student Admission</h4>
                    </div>
                    <div class="col-md-7" style="text-align: right;">
                        <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-xs  btn-primary"   OnClick="btnNew_Click" Style="font-weight: bold; font-size: 16px; height: 38px;"> <i class="icon-pencil align-center bigger-100"></i>&nbsp;New </asp:LinkButton>
                        <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-xs  btn-success"  OnClick="btnsave_Click"     ValidationGroup="UserForm" Style="font-weight: bold; font-size: 16px; height: 38px;">  <i class="icon-save bigger-100"  ></i>&nbsp;Save </asp:LinkButton>
                        <asp:LinkButton ID="btnupdate" runat="server" CssClass="btn btn-xs  btn-success"  OnClick="btnsave_Click"  Style="font-weight: bold; font-size: 16px; height: 38px;">  <i class="icon-edit bigger-100"  ></i>&nbsp;Update </asp:LinkButton>
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <div class="space-4">
                        </div>
                        <!-- <legend>Form</legend> -->
                        <asp:HiddenField ID="hfClassPrefix" runat="server" />
                        <div class="row">
                              <div class="col-md-4" style="text-align: left;">
                                 <div class="space-4">
                                </div>
                                     <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label23" runat="server" Text="Year :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                         <asp:DropDownList ID="ddlYear" runat="server" CssClass="select2" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="space-4">
                                </div>
                                     <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="Class :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true" >
                                        </asp:DropDownList>
                                    </div>
                                </div>

                             
                                   <div class="space-4">
                                </div>
                                   <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label6" runat="server" Text="Section :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                        <asp:DropDownList ID="ddlSection" runat="server" CssClass="select2" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" AutoPostBack="true">

                                        </asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="space-4">
                                </div>
                                   <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupShortName" runat="server" Text="Roll No :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtRollNo" runat="server" Enabled="false" placeholder="Roll No" CssClass="form-control" Text="" />
                                      
                                    </div>
                                   </div>
                                   
                                    <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblName" runat="server" Text="First Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtFirstName" runat="server" Text="" placeholder="First Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                      <div class="space-4">
                                   </div>
                                <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label10" runat="server" Text="Last Name :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName"
                                            ErrorMessage="Sorry! User Group Full name required" Text="*" ForeColor="Red"
                                            ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtLastName" runat="server" Text="" placeholder="Last Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                  <div class="space-4">
                                   </div>
                               
                                <div class="row">
                                <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                     &nbsp;<asp:Label ID="Label4" runat="server" Text=" Images :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                    <asp:FileUpload ID="fuProfilePic" runat="server"   onchange="readURL(this)" />
                                   </div>
                                  
                                </div>
                                   <div class="row">
                                   <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                  
                                    </div>
                                     <div class="space-4">
                                    </div>
                                      <div  class="col-md-7"  style=" float:right">
                                      <asp:Image ID="Image1" ImageUrl="~/images/defalt.jpg" runat="server" Width="70px"  Height="70px"   CssClass="circle" />
                                     
                                     </div>

                                    <div id="dvMsg" style="background-color: Red; color: White; padding: 3px; display: none;">
                                        Maximum size allowed is 15 KB.
                                    </div>
                                 </div>
                                  
                                   
                                
                            
                            </div>
                              <div class="col-md-4" style="text-align: left;">
                                   <div class="space-4">
                                </div>
                                   <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label11" runat="server" Text="Gender :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                     <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label12" runat="server" Text="Date Of Birth :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtDoB" placeholder="Date Of Birth" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                </div>
                                   <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label13" runat="server" Text="Student Category :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                        <asp:DropDownList ID="ddlStudentCategory" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    <div class="space-4">
                                </div>
                                   <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label14" runat="server" Text="Religion :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                        <asp:DropDownList ID="ddlReligion" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                  <div class="space-4">
                                </div>
                             <div class="row">
                                <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Mobile No :"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo"
                                            ErrorMessage="Sorry! Contact no required" Text="*" ForeColor="Red" ValidationGroup="UserForm"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtMobileNo" runat="server" Text="" placeholder="Mobile No" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    </div>
                                      <div class="space-4">
                                </div>
                                   <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label2" runat="server" Text="Blood Group :"></asp:Label>
                                    </div>
                                    <div class="col-md-7" style="text-align: left;">
                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="select2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                          

                              
                             </div>
                              <div class="col-md-4" style="text-align: left;">
                                   
                                     <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label7" runat="server" Text="ID Card No :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtIdCardNo" Enabled="false" runat="server" placeholder="ID Card No"  CssClass="form-control" Text="" />
                                     
                                    </div>
                                   </div>
                                  <div class="space-4">
                                   </div>
                                     <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label9" runat="server" Text="Birth Certificate No :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtBirthCerNo" runat="server" placeholder="Birth Certificate No"  CssClass="form-control" Text="" />
                                     
                                    </div>
                                   </div>
                             <div class="space-4">
                                   </div>
                                 <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblEmailID" runat="server" Text="E-mail :"></asp:Label><asp:RegularExpressionValidator
                                            ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="txtEmailID" ValidationGroup="UserForm" Text="*" ForeColor="red"
                                            ErrorMessage="Please Type like-'example@domain.com'"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtEmailID" runat="server" placeholder="E-mail" CssClass="form-control" />
                                       
                                    </div>
                                 
                                </div>
                                   <div class="space-4">
                                   </div>
                                       <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="lblGroupRemarks" runat="server" Text="Present Address :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtPresentAddress" runat="server" Height="35" placeholder="Present Address" CssClass="form-control"
                                            TextMode="MultiLine" />
                                       
                                    </div>
                                    </div>
                                   <div class="space-4">
                                   </div>
                                     <div class="row">
                                    <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text="Permanent Address :"></asp:Label>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtPermanentAddress" runat="server" Height="35" placeholder="Permanent Address" CssClass="form-control"
                                            TextMode="MultiLine" />
                                   
                                    </div>
                                    </div>
                                  <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label8" runat="server" Text="Admission Date :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtAdmissionDate" placeholder="Admission Date" runat="server" CssClass="form-control date-picker"
                                                    onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <span class="input-group-addon"><i class="icon-calendar bigger-110"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                  
                              </div>
                        </div>
                                
                    
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
                                <asp:HiddenField ID="hfUserId" runat="server" />
                                <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="UserForm" ShowMessageBox="true"
                                    ForeColor="Red" DisplayMode="BulletList" Font-Overline="true" ShowSummary="false" />
                     




                    </div>

                    <asp:Panel ID="pnl1PayrollDetails" runat="server"  Style="margin: 0px ; background-color:cadetblue" >
                        <div>
                              <asp:Label ID="Label21" runat="server" Font-Bold="true" Font-Size="Large" Text="Parent Guardian Detail"></asp:Label>
                            
                        </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label15" runat="server" Text="Father Name :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                           
                                            <asp:TextBox ID="txtFatherName" runat="server" Text="" placeholder="Father Name"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label18" runat="server" Text="Mother Name :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            
                                             <b style="display: none;">House Worker Contact no :</b>
                                            <asp:TextBox ID="txtMotherName" runat="server" Text="" placeholder="Mother Name "
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label25" runat="server" Text="Guardian Name:"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                             <asp:TextBox ID="txtGuardianName" runat="server" Text="" placeholder="Guardian Name "
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label16" runat="server" Text="Father Phone No :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                             <asp:TextBox ID="txtFatherPhoneNo" runat="server" Text="" placeholder="Father Phone No"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label17" runat="server" Text="Mother Phone No :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                          <asp:TextBox ID="txtMotherPhoneNo"   runat="server" Text="" placeholder="Mother Phone No"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label26" runat="server" Text="Guardian Phone No :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                             <asp:TextBox ID="txtGuardianPhoneNo" runat="server" Text="" placeholder="Guardian Phone No"
                                            CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="space-4">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label19" runat="server" Text="Father Occupation :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtFatherOccupation"  placeholder="Father Occupation" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                     <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label20" runat="server" Text="Mother Occupation :"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:TextBox ID="txtMotherOccupation"  placeholder="Mother Occupation" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                       <div class="row">
                                        <div class="col-md-5" style="font-weight: bold; text-align: right;">
                                            <asp:Label ID="Label27" runat="server" Text="Guardian Occupation:"></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:TextBox ID="txtGuardianOccupation"   placeholder="Guardian Occupation" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="space-4">
                                    </div>
                                </div>

                              
                            </div>
                        </asp:Panel>
                </div>
                 <div class="page-content" style="background: #EFF3F8 none repeat scroll 0 0;">
           
            </div>
               
                     <div class="row">
                    <div class="col-md-12">
                        <div class="row" >
                             <div class="col-md-10" style="float:left; margin-left:30px; ">
                            <asp:Label ID="Label22" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="#307ECC">

                            </asp:Label>
                                 </div>
                                  <div class="col-md-2" style="float:right;  margin-right:30px; ">
                                       <asp:TextBox ID="txtSearch"  placeholder="Search Here" runat="server" CssClass="form-control"></asp:TextBox>
                                   </div>
                        </div>
                        <div style="width: 100%; overflow: auto;" >
                            <asp:GridView ID="gvStudentAdmission" runat="server" AutoGenerateColumns="false" PageSize="10"
                                AllowSorting="true" AllowPaging="true" CssClass="table table-striped table-hover"
                                OnRowDeleting="gvStudentAdmission_RowDeleting"
                                OnRowDataBound="gvStudentAdmission_RowDataBound"
                                 OnRowEditing="gvStudentAdmission_RowEditing"
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
                            <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                             <asp:Label ID="lblAutoID" Visible="false" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                             <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                            </ItemTemplate>
                              </asp:TemplateField>
                         <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Roll No">
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="Present Address">
                            <ItemTemplate>
                                <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Eval("PresentAddress")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Mobile No">
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Action">
                             
                             <ItemTemplate>
                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                      <ContentTemplate>
                                     <%--  <asp:LinkButton ID="lnkDownload" runat="server" CssClass="icon-list bigger-130 green" Text="" OnClick="lnkDownload_Click"  ToolTip="Detail"  CommandArgument='<%# Eval("Id") %>'></asp:LinkButton> &nbsp;&nbsp;
                                      --%>
                              
                               <asp:LinkButton ID="likBtnEdit" runat="server" CssClass="icon-edit bigger-130 green" CommandName="Edit" ToolTip="Edit" CausesValidation="false" />  &nbsp;&nbsp;
                             
                                 <asp:LinkButton ID="btnRemove" runat="server" CssClass="icon-trash bigger-130 red"  ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" />
                               </ContentTemplate>
                                         <Triggers>
                               <%--            <asp:PostBackTrigger ControlID="lnkDownload"  />--%>
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
                     
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNew" EventName="Click" />
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnupdate"  />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmission" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvStudentAdmission" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

