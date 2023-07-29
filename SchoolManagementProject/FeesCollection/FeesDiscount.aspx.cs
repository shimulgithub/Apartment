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


public partial class FeesCollection_FeesDiscount : System.Web.UI.Page
{
    FeesDiscountBLL oFeesDiscountBLL = new FeesDiscountBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Reminder Type";
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
        DataTable dt = oFeesDiscountBLL.FeesDiscount_GetDataForGV();
       
        Session["Dt"] = dt;
        gvFeesReminderInfoList.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvFeesReminderInfoList.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvFeesReminderInfoList.PageSize * (gvFeesReminderInfoList.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvFeesReminderInfoList.PageSize;

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

        if (gvFeesReminderInfoList.Rows.Count < 1)
        {
            gvFeesReminderInfoList.EmptyDataText = "No Data Found";
        }

        gvFeesReminderInfoList.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

        FeesDiscountBOL entity = new FeesDiscountBOL();

        entity.DisName = txtName.Text.Trim();
        entity.DisAmount = Convert.ToInt32(txtAmount.Text);
        entity.DisCode = txtCode.Text.Trim();
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {

            //Save record
            Id = oFeesDiscountBLL.FeesDiscount_Add(entity);
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

            Id = oFeesDiscountBLL.FeesDiscount_Update(entity);

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
    protected void gvFeesReminderInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvFeesReminderInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        FeesDiscountBOL entity = new FeesDiscountBOL();
        Int32 Id = Convert.ToInt32(gvFeesReminderInfoList.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oFeesDiscountBLL.FeesDiscount_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvFeesReminderInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        FeesDiscountBOL FeesReminderBOL = new FeesDiscountBOL();
        Int32 Id = Convert.ToInt32(gvFeesReminderInfoList.DataKeys[e.NewEditIndex].Value);
        FeesReminderBOL.Id = Id;
        FeesReminderBOL = oFeesDiscountBLL.FeesDiscount_GetById(FeesReminderBOL);
        SetDataToControls(FeesReminderBOL);
    }
    private void SetDataToControls(FeesDiscountBOL FeesDiscount)
    {

        try
        {
            txtName.Text = FeesDiscount.DisName.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
        try
        {
            txtCode.Text = FeesDiscount.DisCode.ToString();
        }
        catch
        {
            txtCode.Text = "";
        }
        try
        {
            txtAmount.Text = FeesDiscount.DisAmount.ToString();
        }
        catch
        {
            txtAmount.Text = "";
        }
        try
        {
            txtDescription.Text = FeesDiscount.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = FeesDiscount.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;


        hfAutoId.Value = FeesDiscount.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtAmount.Text = "";
        txtCode.Text = "";
        txtName.Text = "";
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
    protected void gvFeesReminderInfoList_Sorting(object sender, GridViewSortEventArgs e)
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
            gvFeesReminderInfoList.DataSource = sortedView;
            gvFeesReminderInfoList.DataBind();

        }
    }
    protected void gvFeesReminderInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvFeesReminderInfoList.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvFeesReminderInfoList.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvFeesReminderInfoList.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvFeesReminderInfoList.PageSize * (gvFeesReminderInfoList.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvFeesReminderInfoList.PageSize;

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
            gvFeesReminderInfoList.DataBind();
        }
        else
        {
            BindList();
            gvFeesReminderInfoList.DataBind();
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
            string FileName = "FeesDiscountList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "FeesDiscountList");


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
        string sql = "SP_TB_FeesDiscountListSearchBox";
        dt = Global.CreateNo_FeesTypeSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvFeesReminderInfoList.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvFeesReminderInfoList.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvFeesReminderInfoList.PageSize * (gvFeesReminderInfoList.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvFeesReminderInfoList.PageSize;

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

        if (gvFeesReminderInfoList.Rows.Count < 1)
        {
            gvFeesReminderInfoList.EmptyDataText = "No Data Found";
        }

        gvFeesReminderInfoList.DataBind();
    }
}