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

public partial class IncomeExpense_IncomeEntry : System.Web.UI.Page
{
    IncomeBLL oIncomeBLL = new IncomeBLL();
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
                Session["breadcrumb"] = "Income Head";
                Clear();
                BindList();
                LoadIncomeHeadList();
                txtRefNo.Focus();

            }
            // this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }
    
    private void LoadIncomeHeadList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_IncomeHeadListDDL";
        dt = Global.CreateDataTable(sql);

        ddlIncomeHead.DataSource = dt;
        ddlIncomeHead.DataTextField = "HeadName";
        ddlIncomeHead.DataValueField = "Id";
        ddlIncomeHead.DataBind();



    }
   
    private void BindList()
    {
        DataTable dt = oIncomeBLL.Income_GetDataForGV();
        Session["Dt"] = dt;
        gvIncome.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvIncome.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvIncome.PageSize * (gvIncome.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvIncome.PageSize;

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

        if (gvIncome.Rows.Count < 1)
        {
            gvIncome.EmptyDataText = "No Data Found";
        }

        gvIncome.DataBind();


    }
    
    protected void btnSavePrint_Click(object sender, EventArgs e)
    {
        if (ddlIncomeHead.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Income Head.');", true);
            ddlIncomeHead.Focus();
            return;
        }
        if (txtIncomeDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Income Date.');", true);
            txtIncomeDate.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Income Head Name.');", true);
            txtName.Focus();
            return;
        }
        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Income Amount.');", true);
            txtAmount.Focus();
            return;
        }
        Save();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        if (ddlIncomeHead.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Income Head.');", true);
            ddlIncomeHead.Focus();
            return;
        }
        if (txtIncomeDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Income Date.');", true);
            txtIncomeDate.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Income Head Name.');", true);
            txtName.Focus();
            return;
        }
        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Income Amount.');", true);
            txtAmount.Focus();
            return;
        }
        SaveOnly();




    }
    private void Save()
    {

        IncomeBOL entity = new IncomeBOL();

       
        entity.IncomeHeadId = Convert.ToInt32(ddlIncomeHead.SelectedValue);
        entity.IncomeName = txtName.Text;
        if (txtIncomeDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtIncomeDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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
            Id = oIncomeBLL.Income_Add(entity);
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
                    string param = "IncomePrint";
                    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id)+"&amt="+ Server.UrlEncode(_Amount);
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

            Id = oIncomeBLL.Income_Update(entity);

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

        IncomeBOL entity = new IncomeBOL();


        entity.IncomeHeadId = Convert.ToInt32(ddlIncomeHead.SelectedValue);
        entity.IncomeName = txtName.Text;
        if (txtIncomeDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtIncomeDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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
            Id = oIncomeBLL.Income_Add(entity);
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

                //    string param = "IncomePrint";

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

            Id = oIncomeBLL.Income_Update(entity);

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
    protected void gvIncome_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvIncome_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        IncomeBOL entity = new IncomeBOL();
        Int32 Id = Convert.ToInt32(gvIncome.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oIncomeBLL.Income_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvIncome_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        IncomeBOL IncomeBOL = new IncomeBOL();
        Int32 Id = Convert.ToInt32(gvIncome.DataKeys[e.NewEditIndex].Value);
        IncomeBOL.Id = Id;
        IncomeBOL = oIncomeBLL.Income_GetById(IncomeBOL);
        SetDataToControls(IncomeBOL);
    }
    private void SetDataToControls(IncomeBOL Income)
    {

        try
        {
            txtInvoiceNo.Text = Income.InvoiceNo.ToString();
        }
        catch
        {
            txtInvoiceNo.Text = "";
        }

        try
        {
            txtRefNo.Text = Income.RefNo.ToString();
        }
        catch
        {
            txtRefNo.Text = "";
        }

        try
        {
           ddlIncomeHead.SelectedValue= Income.IncomeHeadId.ToString();
        }
        catch
        {
            ddlIncomeHead.SelectedValue = "0";
        }

        try
        {
            txtIncomeDate.Text = Income.DateBind.ToString();
        }
        catch
        {
            txtIncomeDate.Text = "";
        }

        try
        {
            txtName.Text = Income.IncomeName.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
        try
        {
           txtAmount.Text = Income.Amount.ToString();
        }
        catch
        {
            txtAmount.Text = "";
        }
        try
        {
            txtDescription.Text = Income.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = Income.Id.ToString();
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
        txtIncomeDate.Text = string.Empty;
        txtInvoiceNo.Text = string.Empty;
        txtRefNo.Text = string.Empty;
        ddlIncomeHead.SelectedValue = "0";
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
    protected void gvIncome_Sorting(object sender, GridViewSortEventArgs e)
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
            gvIncome.DataSource = sortedView;
            gvIncome.DataBind();
           
        }
    }
    protected void gvIncome_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
        gvIncome.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();
         
            gvIncome.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvIncome.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvIncome.PageSize * (gvIncome.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvIncome.PageSize;

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
            gvIncome.DataBind();
        }
        else
        {
            BindList();
            gvIncome.DataBind();
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
        string sql = "SP_TB_IncomeBySearchBox";
        dt = Global.CreateNo_IncomeSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvIncome.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvIncome.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvIncome.PageSize * (gvIncome.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvIncome.PageSize;

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

        if (gvIncome.Rows.Count < 1)
        {
            gvIncome.EmptyDataText = "No Data Found";
        }

        gvIncome.DataBind();


    }
    protected void lnkbtnPrint_Click(object sender, EventArgs e)
    {
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
        Label lblId = (Grow.FindControl("lblId") as Label);
        Label lblIncomeAmount = (Grow.FindControl("lblIncomeAmount") as Label);

        try
        {
            string _Id = lblId.Text.ToString();
            string _Amount = lblIncomeAmount.Text.ToString();
            string redirectPage = "";

            string param = "IncomePrint";

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
            string sql = "SP_TB_IncomeListExportToExcel";
            dt2 = Global.CreateDataTable(sql);

            string FileName = "IncomeListExport_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "IncomeListExport");

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