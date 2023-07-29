<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);

    }
    void Session_End(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/UserLogin_Logout.aspx");

    }
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Home", "Home", "~/UnderConstruction.aspx");

        routes.MapPageRoute("Dashboard", "Dashboard", "~/UnderConstruction.aspx");
        
        //routes.MapPageRoute("Tempest", "Tempest", "~/SMS_MainDashboard.aspx");
        
        routes.MapPageRoute("Finance", "Finance", "~/UnderConstruction.aspx");
        
       // routes.MapPageRoute("System Admin", "System Admin", "~/SMS_MainDashboard.aspx");

        routes.MapPageRoute("Valid Timesheet (Summary)", "ValidTimesheetswithSuppliers", "~/Reports/ValidTimeSheetsWithSuppliers.aspx");

        routes.MapPageRoute("Margin Reports (Details)-Tempest", "MarginReportsbyEmployerswithdetails", "~/Reports/MarginReportsbyEmployerswithdetails.aspx");

        routes.MapPageRoute("Margin Reports (Details-old)-Tempest", "MarginReportsbyEmployerswithdetailsPrevoius", "~/Reports/MarginReportsbyEmployerswithdetailsPrevoius.aspx");
    
        routes.MapPageRoute("Credit Notes Details", "CreditNotesDetails", "~/Reports/CreditNotesDetails.aspx");

        routes.MapPageRoute("Assg. Details-Consultant Splits", "AssignementDetailswithconsultantsplits", "~/Reports/AssignementDetailswithconsultantsplits.aspx");
        
        routes.MapPageRoute("Worker Suppliers", "WorkerSuppliers", "~/Reports/WorkerSuppliers.aspx");
        
        routes.MapPageRoute("Perm Placement", "PermPlacementReports", "~/Reports/PermPlacementReports.aspx");
        
        routes.MapPageRoute("Worker Details", "WorkerDetails", "~/Reports/WorkerDetails.aspx");

     
        routes.MapPageRoute("Purchase Day Book", "PurchaseDayBook", "~/Reports/PurchaseDayBookReport.aspx");
        
        routes.MapPageRoute("US Payroll Spread Sheet", "USPayrollSpreadSheet", "~/Reports/USPayrollSpreadSheet.aspx");
       
        
        //routes.MapPageRoute("User's Group", "UsersGroup", "~/SMS_MainDashboard.aspx");
        
        //routes.MapPageRoute("Create User", "CreateUser", "~/SMS_MainDashboard.aspx");
        
        routes.MapPageRoute("User Wise Page Premission", "UserPagePremission", "~/Setting/UserPagePermission.aspx");

        routes.MapPageRoute("User Action Permission", "UserActionPermission", "~/Setting/UserActionPermission.aspx");

        routes.MapPageRoute("User's Group Entry", "UsersGroup", "~/Setting/NewUserGroup.aspx");

        routes.MapPageRoute("User Information Entry", "CreateUser", "~/Setting/NewUser.aspx");
        
        routes.MapPageRoute("Search User", "UserInfo", "~/Setting/NewUser_List.aspx");
        
        routes.MapPageRoute("Segments Master", "SegmentsMaster", "~/Configuration/SegmentsMaster.aspx");

        routes.MapPageRoute("Monthly Service Charges Entry", "MonthlyServiceCharge", "~/Configuration/MonthlyServiceChargeEntry.aspx");

        routes.MapPageRoute("Duty Information", "DutyInfoReports", "~/Reports/DutyInfoReports.aspx");
        
        routes.MapPageRoute("Email /SMS Logs", "EmailLogsReports", "~/Reports/EmailLogsReports.aspx");

        routes.MapPageRoute("Salary Information", "SalaryInfoReports", "~/Reports/SalaryInfoReports.aspx");
        
        routes.MapPageRoute("Leave Information", "LeaveInfoReports", "~/Reports/LeaveInfoReports.aspx");
        
        routes.MapPageRoute("Employee Information", "EmployeeReports", "~/Reports/EmployeeReports.aspx");
        
         routes.MapPageRoute("Unit Information View", "UnitInfoReports", "~/Reports/UnitInfoReports.aspx");
       
        
        routes.MapPageRoute("Floor Information", "FloorReports", "~/Reports/FloorReports.aspx");
        
        routes.MapPageRoute("Staff Profile Entry", "StaffProfileCreate", "~/HumanResource/StaffProfileCreate.aspx");

        routes.MapPageRoute("Tenant Information", "TenantInfoReports", "~/Reports/TenantInfoReports.aspx");
        
        routes.MapPageRoute("Leave Type Entry", "LeaveType", "~/HumanResource/LeaveType.aspx");
        
        routes.MapPageRoute("Department Entry", "DepartmentEntry", "~/HumanResource/DepartmentEntry.aspx");
        
        routes.MapPageRoute("Designation Entry", "DesignationEntry", "~/HumanResource/DesignationEntry.aspx");
        
        routes.MapPageRoute("Expense Head", "ExpenseHead", "~/IncomeExpense/ExpenseHead.aspx");

        routes.MapPageRoute("Expense Entry", "ExpenseEntry", "~/IncomeExpense/ExpenseEntry.aspx");

        routes.MapPageRoute("Expense Search", "ExpenseSearch", "~/IncomeExpense/ExpenseSearch.aspx");

        routes.MapPageRoute("Income Head Entry", "IncomeHead", "~/IncomeExpense/IncomeHead.aspx");

        routes.MapPageRoute("Income Entry", "IncomeEntry", "~/IncomeExpense/IncomeEntry.aspx");

        routes.MapPageRoute("Income Search", "IncomeSearch", "~/IncomeExpense/IncomeSearch.aspx");

        routes.MapPageRoute("Tenant Notice Entry", "TenantNoticeEntry", "~/Configuration/TenantNoticeEntry.aspx");

        routes.MapPageRoute("Bill Deposit Entry", "BillEntry", "~/Configuration/BillEntry.aspx");
        
        routes.MapPageRoute("Owner Utility Entry", "OwnerUtilityEntry", "~/Configuration/OwnerUtilityEntry.aspx");
        
        routes.MapPageRoute("Rent Collection Entry", "RentCollectionEntry", "~/Configuration/RentCollectionEntry.aspx");
        
        routes.MapPageRoute("Admit Card Print", "AdmitCardPrint", "~/AttendanceExaminations/AdmitCardPrint.aspx");
        
        routes.MapPageRoute("Marks Grade", "MarksGrade", "~/AttendanceExaminations/MarksGrade.aspx");
        
        routes.MapPageRoute("Exam Group", "ExamGroup", "~/AttendanceExaminations/ExamGroup.aspx");
        
        routes.MapPageRoute("Approve Leave", "ApproveLeave", "~/AttendanceExaminations/ApproveLeave.aspx");
        
        routes.MapPageRoute("Attendance Dtail", "AttendanceByDate", "~/AttendanceExaminations/AttendanceByDate.aspx");
        
        routes.MapPageRoute("Attendance Entry", "AttendanceEntry", "~/AttendanceExaminations/AttendanceEntry.aspx");
        
        routes.MapPageRoute("Student House", "StudentHouse", "~/Student/StudentHouse.aspx");

        routes.MapPageRoute("Student Admission", "StudentAdmission", "~/Student/StudentAdmission.aspx");

        routes.MapPageRoute("Student Details", "StudentDetail", "~/Student/StudentDetail.aspx");
        
        routes.MapPageRoute("Student Category", "StudentCategories", "~/Student/StudentCategories.aspx");

        routes.MapPageRoute("Disable Reason", "DisableReason", "~/Student/DisableReason.aspx");

        routes.MapPageRoute("Fee Type", "FeeType", "~/FeesCollection/FeeType.aspx");

        routes.MapPageRoute("Fees Reminder", "FeesReminder", "~/FeesCollection/FeesReminder.aspx");

         routes.MapPageRoute("Fees Master Entry", "FeesMaster", "~/FeesCollection/FeesMaster.aspx");

         routes.MapPageRoute("Collect Fees", "CollectFees", "~/FeesCollection/CollectFees.aspx");

         routes.MapPageRoute("Fees Discount Entry", "FeesDiscount", "~/FeesCollection/FeesDiscount.aspx");

         routes.MapPageRoute("Fees Carry Forward", "FeesCarryForward", "~/FeesCollection/FeesCarryForward.aspx");

         routes.MapPageRoute("Fees Search (Due)", "SearchDueFess", "~/FeesCollection/SearchDueFess.aspx");

         routes.MapPageRoute("Fees Search (Payment)", "SearchFeesCollection", "~/FeesCollection/SearchFeesCollection.aspx");
        
      
    }

    
</script>

