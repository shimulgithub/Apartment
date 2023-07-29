using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Data;
using SMP.Common;
using System.Data.SqlClient;

public partial class ExpenseExpense_ExpenseEntry : System.Web.UI.Page
{
    ExpenseBLL oExpenseBLL = new ExpenseBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                Session["Dt"] = null;
                Session["SortedView"] = null;
                btnsave.Visible = true;
                btnSavePrint.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Expense Head";
                Clear();
                BindList();
                LoadExpenseHeadList();
                txtRefNo.Focus();

            }
            // this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }

    private void LoadExpenseHeadList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_ExpenseHeadListDDL";
        dt = Global.CreateDataTable(sql);

        ddlExpenseHead.DataSource = dt;
        ddlExpenseHead.DataTextField = "HeadName";
        ddlExpenseHead.DataValueField = "Id";
        ddlExpenseHead.DataBind();



    }

    private void BindList()
    {
        DataTable dt = oExpenseBLL.Expense_GetDataForGV();
        Session["Dt"] = dt;
        gvExpense.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvExpense.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvExpense.PageSize * (gvExpense.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvExpense.PageSize;

        if (iEndRecord > iTotalRecords)
        {

            iEndRecord = iTotalRecords;

        }

        if (iStartsRecods == 0)
        {

            iStartsRecods = 1;

        }

        if (iEndRecord == 0)
        {

            iEndRecord = iTotalRecords;

        }

        Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";

        if (gvExpense.Rows.Count < 1)
        {
            gvExpense.EmptyDataText = "No Data Found";
        }

        gvExpense.DataBind();


    }

    protected void btnSavePrint_Click(object sender, EventArgs e)
    {
        if (ddlExpenseHead.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Expense Head.');", true);
            ddlExpenseHead.Focus();
            return;
        }
        if (txtExpenseDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Expense Date.');", true);
            txtExpenseDate.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Expense Head Name.');", true);
            txtName.Focus();
            return;
        }
        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Expense Amount.');", true);
            txtAmount.Focus();
            return;
        }
        Save();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        if (ddlExpenseHead.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Expense Head.');", true);
            ddlExpenseHead.Focus();
            return;
        }
        if (txtExpenseDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Expense Date.');", true);
            txtExpenseDate.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Expense Head Name.');", true);
            txtName.Focus();
            return;
        }
        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Expense Amount.');", true);
            txtAmount.Focus();
            return;
        }
        SaveOnly();




    }
    private void Save()
    {

        ExpenseBOL entity = new ExpenseBOL();


        entity.ExpenseHeadId = Convert.ToInt32(ddlExpenseHead.SelectedValue);
        entity.ExpenseName = txtName.Text;
        if (txtExpenseDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtExpenseDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.Date = JoiningDate;
        }
        else
        {
            entity.Date = Convert.ToDateTime("01/01/1991");

        }
        double Amt = Convert.ToDouble(txtAmount.Text);
        entity.Amount = Amt;
        entity.Description = txtDescription.Text.ToString();
        entity.RefNo = txtRefNo.Text;
        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {


            entity.CreateBy = Session["UserID"].ToString();
            //Save record
            Id = oExpenseBLL.Expense_Add(entity);
            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                Clear();
                BindList();


                try
                {
                    string _Id = Id.ToString();
                    string _Amount = entity.Amount.ToString();
                    string redirectPage = "";

                    string param = "ExpensePrint";

                    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount);
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                       "UniqueID", "Popup('" + redirectPage + "');", true);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }
        else
        {
            //Update record
            entity.ChangedBy = Session["UserID"].ToString();
            entity.Id = Convert.ToInt32(hfAutoId.Value);
            entity.InvoiceNo = txtInvoiceNo.Text;

            Id = oExpenseBLL.Expense_Update(entity);

            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                Clear();
                BindList();
            }
        }
    }
    private void SaveOnly()
    {

        ExpenseBOL entity = new ExpenseBOL();


        entity.ExpenseHeadId = Convert.ToInt32(ddlExpenseHead.SelectedValue);
        entity.ExpenseName = txtName.Text;
        if (txtExpenseDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtExpenseDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.Date = JoiningDate;
        }
        else
        {
            entity.Date = Convert.ToDateTime("01/01/1991");

        }
        double Amt = Convert.ToDouble(txtAmount.Text);
        entity.Amount = Amt;
        entity.Description = txtDescription.Text.ToString();
        entity.RefNo = txtRefNo.Text;
        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {


            entity.CreateBy = Session["UserID"].ToString();
            //Save record
            Id = oExpenseBLL.Expense_Add(entity);
            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                Clear();
                BindList();


                //try
                //{
                //    string _Id = Id.ToString();
                //    string _Amount = entity.Amount.ToString();
                //    string redirectPage = "";

                //    string param = "ExpensePrint";

                //    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                //    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount);
                //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                //       "UniqueID", "Popup('" + redirectPage + "');", true);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;

                //}
            }
        }
        else
        {
            //Update record
            entity.ChangedBy = Session["UserID"].ToString();
            entity.Id = Convert.ToInt32(hfAutoId.Value);
            entity.InvoiceNo = txtInvoiceNo.Text;

            Id = oExpenseBLL.Expense_Update(entity);

            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                Clear();
                BindList();
            }
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void gvExpense_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //LinkButton lnk = e.Row.FindControl("likBtnSegmentsName") as LinkButton;
        //AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        //trigger.ControlID = lnk.UniqueID;
        //trigger.EventName = "Click";
        //UpdatePanel2.Triggers.Add(trigger);

        //}
    }
    protected void gvExpense_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        ExpenseBOL entity = new ExpenseBOL();
        Int32 Id = Convert.ToInt32(gvExpense.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oExpenseBLL.Expense_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvExpense_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        ExpenseBOL ExpenseBOL = new ExpenseBOL();
        Int32 Id = Convert.ToInt32(gvExpense.DataKeys[e.NewEditIndex].Value);
        ExpenseBOL.Id = Id;
        ExpenseBOL = oExpenseBLL.Expense_GetById(ExpenseBOL);
        SetDataToControls(ExpenseBOL);
    }
    private void SetDataToControls(ExpenseBOL Expense)
    {

        try
        {
            txtInvoiceNo.Text = Expense.InvoiceNo.ToString();
        }
        catch
        {
            txtInvoiceNo.Text = "";
        }

        try
        {
            txtRefNo.Text = Expense.RefNo.ToString();
        }
        catch
        {
            txtRefNo.Text = "";
        }

        try
        {
            ddlExpenseHead.SelectedValue = Expense.ExpenseHeadId.ToString();
        }
        catch
        {
            ddlExpenseHead.SelectedValue = "0";
        }

        try
        {
            txtExpenseDate.Text = Expense.DateBind.ToString();
        }
        catch
        {
            txtExpenseDate.Text = "";
        }

        try
        {
            txtName.Text = Expense.ExpenseName.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
        try
        {
            txtAmount.Text = Expense.Amount.ToString();
        }
        catch
        {
            txtAmount.Text = "";
        }
        try
        {
            txtDescription.Text = Expense.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = Expense.Id.ToString();
        btnsave.Visible = false;
        btnSavePrint.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtName.Focus();
        txtName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        txtAmount.Text = string.Empty;
        txtExpenseDate.Text = string.Empty;
        txtInvoiceNo.Text = string.Empty;
        txtRefNo.Text = string.Empty;
        ddlExpenseHead.SelectedValue = "0";
        txtAmount.Text = "";
        hfAutoId.Value = "0";
        btnsave.Visible = true;
        btnupdate.Visible = false;
        btnSavePrint.Visible = true;


    }
    public SortDirection dir
    {

        get
        {

            if (ViewState["dirState"] == null)
            {

                ViewState["dirState"] = SortDirection.Ascending;

            }

            return (SortDirection)ViewState["dirState"];

        }

        set
        {

            ViewState["dirState"] = value;

        }



    }
    protected void gvExpense_Sorting(object sender, GridViewSortEventArgs e)
    {

        DataTable dataTable = new DataTable();
        dataTable = (DataTable)Session["Dt"];
        if (dataTable != null)
        {
            string SortDir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                SortDir = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                SortDir = "Asc";
            }
            DataView sortedView = new DataView(dataTable);
            sortedView.Sort = e.SortExpression + " " + SortDir;
            Session["SortedView"] = sortedView;
            gvExpense.DataSource = sortedView;
            gvExpense.DataBind();

        }
    }
    protected void gvExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvExpense.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvExpense.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvExpense.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvExpense.PageSize * (gvExpense.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvExpense.PageSize;

            if (iEndRecord > iTotalRecords)
            {
                iEndRecord = iTotalRecords;
            }

            if (iStartsRecods == 0)
            {
                iStartsRecods = 1;
            }

            if (iEndRecord == 0)
            {
                iEndRecord = iTotalRecords;
            }

            Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
            gvExpense.DataBind();
        }
        else
        {
            BindList();
            gvExpense.DataBind();
        }

    }
    protected void txtSearchBox_TextChanged(object sender, EventArgs e)
    {
        if (txtSearchBox.Text != "")
        {
            LoadSearchList();
        }
        else
        {
            BindList();
        }


    }
    private void LoadSearchList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_ExpenseBySearchBox";
        dt = Global.CreateNo_IncomeSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvExpense.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvExpense.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvExpense.PageSize * (gvExpense.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvExpense.PageSize;

        if (iEndRecord > iTotalRecords)
        {

            iEndRecord = iTotalRecords;

        }

        if (iStartsRecods == 0)
        {

            iStartsRecods = 1;

        }

        if (iEndRecord == 0)
        {

            iEndRecord = iTotalRecords;

        }

        Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";

        if (gvExpense.Rows.Count < 1)
        {
            gvExpense.EmptyDataText = "No Data Found";
        }

        gvExpense.DataBind();


    }
    protected void lnkbtnPrint_Click(object sender, EventArgs e)
    {
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
        Label lblId = (Grow.FindControl("lblId") as Label);
        Label lblExpenseAmount = (Grow.FindControl("lblExpenseAmount") as Label);

        try
        {
            string _Id = lblId.Text.ToString();
            string _Amount = lblExpenseAmount.Text.ToString();
            string redirectPage = "";

            string param = "ExpensePrint";

            string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
            redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount);
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
               "UniqueID", "Popup('" + redirectPage + "');", true);
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            dt = null;
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView1.Columns.Clear();
            string sql = "SP_TB_ExpenseListExportToExcel";
            dt2 = Global.CreateDataTable(sql);

            string FileName = "ExpenseListExport_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "ExpenseListExport");

                var TJan = 0;  //Total Invoice January
                var TJan_co = 0;
                var TJan_ro = 1;


                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    string ColumnName = dt2.Columns[i].ColumnName.ToString();

                    if (ColumnName == "Amount (TK)")
                    {
                        TJan = 1;
                        TJan_co = i + 1;
                    }

                }

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (TJan == 1)
                    {
                        ws.Cell(++TJan_ro, TJan_co).Value = dt2.Rows[i]["Amount (TK)"].ToString();
                        ws.Cell(TJan_ro, TJan_co).Style.NumberFormat.Format = "0.00";
                    }

                }
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=\"" + FileName + "\"");

                using (var ms = new System.IO.MemoryStream())
                {
                    wb.SaveAs(ms);
                    ms.WriteTo(Response.OutputStream);
                    ms.Close();
                }
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {

            }
            finally
            {
                dt = null;
                dt2 = null;
            }



        }

        catch (Exception ex)
        {
            Response.Write("Oops! error occured:" + ex.Message.ToString());
        }
        finally
        {

            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.Response.End();

        }
    }
}