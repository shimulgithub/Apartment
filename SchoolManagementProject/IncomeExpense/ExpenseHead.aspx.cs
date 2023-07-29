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


public partial class IncomeExpense_ExpenseHead : System.Web.UI.Page
{
   ExpenseHeadBLL oExpenseHeadBLL = new ExpenseHeadBLL();
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
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Fees Type";
                Clear();
                BindList();

            }
            // this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }

    private void BindList()
    {
        DataTable dt = oExpenseHeadBLL.ExpenseHead_GetDataForGV();
        Session["Dt"] = dt;
        gvExpenseHead.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvExpenseHead.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvExpenseHead.PageSize * (gvExpenseHead.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvExpenseHead.PageSize;

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

        if (gvExpenseHead.Rows.Count < 1)
        {
            gvExpenseHead.EmptyDataText = "No Data Found";
        }

        gvExpenseHead.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

       ExpenseHeadBOL entity = new ExpenseHeadBOL();

        entity.HeadName = txtName.Text.Trim();
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {



            //Save record
            Id = oExpenseHeadBLL.ExpenseHead_Add(entity);
            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                Clear();
                BindList();
            }
        }
        else
        {
            //Update record          
            entity.Id = Convert.ToInt32(hfAutoId.Value);

            Id = oExpenseHeadBLL.ExpenseHead_Update(entity);

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
    protected void gvExpenseHead_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvExpenseHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

       ExpenseHeadBOL entity = new ExpenseHeadBOL();
        Int32 Id = Convert.ToInt32(gvExpenseHead.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oExpenseHeadBLL.ExpenseHead_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvExpenseHead_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
       ExpenseHeadBOL ExpenseHeadBOL = new ExpenseHeadBOL();
        Int32 Id = Convert.ToInt32(gvExpenseHead.DataKeys[e.NewEditIndex].Value);
       ExpenseHeadBOL.Id = Id;
       ExpenseHeadBOL = oExpenseHeadBLL.ExpenseHead_GetById(ExpenseHeadBOL);
        SetDataToControls(ExpenseHeadBOL);
    }
    private void SetDataToControls(ExpenseHeadBOL ExpenseHead)
    {

        try
        {
            txtName.Text =ExpenseHead.HeadName.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
     
        try
        {
            txtDescription.Text =ExpenseHead.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value =ExpenseHead.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtName.Focus();
        txtName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        hfAutoId.Value = "0";
        btnsave.Visible = true;
        btnupdate.Visible = false;
       

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
    protected void gvExpenseHead_Sorting(object sender, GridViewSortEventArgs e)
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
            gvExpenseHead.DataSource = sortedView;
            gvExpenseHead.DataBind();

        }
    }
    protected void gvExpenseHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvExpenseHead.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvExpenseHead.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvExpenseHead.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvExpenseHead.PageSize * (gvExpenseHead.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvExpenseHead.PageSize;

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
            gvExpenseHead.DataBind();
        }
        else
        {
            BindList();
            gvExpenseHead.DataBind();
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
            //string sql = "SP_TB_ExpenseHeadListToExcel";
            //dt2 = Global.CreateDataTable(sql);
            dt2 = (DataTable)Session["Dt"];
            string FileName = "ExpenseHeadList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "ExpenseHeadList");

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
        string sql = "SP_TB_ExpenseHeadBySearchBox";
        dt = Global.CreateNo_IncomeSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvExpenseHead.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvExpenseHead.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvExpenseHead.PageSize * (gvExpenseHead.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvExpenseHead.PageSize;

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

        if (gvExpenseHead.Rows.Count < 1)
        {
            gvExpenseHead.EmptyDataText = "No Data Found";
        }

        gvExpenseHead.DataBind();


    }
}