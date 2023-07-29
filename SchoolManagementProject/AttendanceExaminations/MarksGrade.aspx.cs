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


public partial class AttendanceExaminations_MarksGrade : System.Web.UI.Page
{
    MarkGradeEntryBLL oMarkGradeEntryBLL = new MarkGradeEntryBLL();
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
                Session["breadcrumb"] = "Mark Grade Entry ";
                Clear();
                BindList();
                LoadExamGroupTypeList();

            }
            // this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }

    private void LoadExamGroupTypeList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_GroupNameListDDL";
        dt = Global.CreateDataTable(sql);

        ddlGradeGroupType.DataSource = dt;
        ddlGradeGroupType.DataTextField = "GroupName";
        ddlGradeGroupType.DataValueField = "Id";
        ddlGradeGroupType.DataBind();


    }
    //
    private void BindList()
    {
        DataTable dt = oMarkGradeEntryBLL.MarkGradeEntry_GetDataForGV();
        Session["Dt"] = dt;
        gvMarkGradeEntry.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvMarkGradeEntry.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvMarkGradeEntry.PageSize * (gvMarkGradeEntry.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvMarkGradeEntry.PageSize;

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

        if (gvMarkGradeEntry.Rows.Count < 1)
        {
            gvMarkGradeEntry.EmptyDataText = "No Data Found";
        }

        gvMarkGradeEntry.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

        MarkGradeEntryBOL entity = new MarkGradeEntryBOL();

        entity.ExamGroupId = Convert.ToInt32(ddlGradeGroupType.SelectedValue);
        entity.GradeName= txtName.Text;
        entity.PercentFrom = Convert.ToInt32(txtPercentFrom.Text);
        entity.PercentTo = Convert.ToInt32(txtPercentUpto.Text);
        entity.GradePoint = Convert.ToDouble(txtGradePoint.Text);
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {



            //Save record
            Id = oMarkGradeEntryBLL.MarkGradeEntry_Add(entity);
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

            Id = oMarkGradeEntryBLL.MarkGradeEntry_Update(entity);

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
    protected void gvMarkGradeEntry_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvMarkGradeEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        MarkGradeEntryBOL entity = new MarkGradeEntryBOL();
        Int32 Id = Convert.ToInt32(gvMarkGradeEntry.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oMarkGradeEntryBLL.MarkGradeEntry_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvMarkGradeEntry_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        MarkGradeEntryBOL MarkGradeEntryBOL = new MarkGradeEntryBOL();
        Int32 Id = Convert.ToInt32(gvMarkGradeEntry.DataKeys[e.NewEditIndex].Value);
        MarkGradeEntryBOL.Id = Id;
        MarkGradeEntryBOL = oMarkGradeEntryBLL.MarkGradeEntry_GetById(MarkGradeEntryBOL);
        SetDataToControls(MarkGradeEntryBOL);
    }
    private void SetDataToControls(MarkGradeEntryBOL MarkGradeEntry)
    {
        try
        {
          ddlGradeGroupType.SelectedValue = MarkGradeEntry.ExamGroupId.ToString();
        }
        catch
        {
            ddlGradeGroupType.SelectedValue = "0";
        }


        try
        {
            txtName.Text = MarkGradeEntry.GradeName.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
        try
        {
            txtPercentFrom.Text = MarkGradeEntry.PercentFrom.ToString();
        }
        catch
        {
            txtPercentFrom.Text = "";
        }
        try
        {
            txtPercentUpto.Text = MarkGradeEntry.PercentTo.ToString();
        }
        catch
        {
            txtPercentUpto.Text = "";
        }
        try
        {
            txtDescription.Text = MarkGradeEntry.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }
        try
        {
            txtGradePoint.Text = MarkGradeEntry.GradePoint.ToString();
        }
        catch
        {
            txtGradePoint.Text = "";
        }


        hfAutoId.Value = MarkGradeEntry.Id.ToString();
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
        txtPercentFrom.Text = "";
        txtPercentUpto.Text = "";
        ddlGradeGroupType.SelectedValue = "0";
        txtGradePoint.Text = "";

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
    protected void gvMarkGradeEntry_Sorting(object sender, GridViewSortEventArgs e)
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
            gvMarkGradeEntry.DataSource = sortedView;
            gvMarkGradeEntry.DataBind();

        }
    }
    protected void gvMarkGradeEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvMarkGradeEntry.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvMarkGradeEntry.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvMarkGradeEntry.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvMarkGradeEntry.PageSize * (gvMarkGradeEntry.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvMarkGradeEntry.PageSize;

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
            gvMarkGradeEntry.DataBind();
        }
        else
        {
            BindList();
            gvMarkGradeEntry.DataBind();
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
            string FileName = "MarkGradeEntryList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "MarkGradeEntryList");


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
        string sql = "SP_TB_MarkGradeEntryListBySearchBox";
        dt = Global.CreateNo_FeesTypeSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvMarkGradeEntry.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvMarkGradeEntry.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvMarkGradeEntry.PageSize * (gvMarkGradeEntry.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvMarkGradeEntry.PageSize;

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

        if (gvMarkGradeEntry.Rows.Count < 1)
        {
            gvMarkGradeEntry.EmptyDataText = "No Data Found";
        }

        gvMarkGradeEntry.DataBind();
    }
}