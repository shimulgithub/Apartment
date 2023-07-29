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


public partial class HumanResource_DepartmentEntry : System.Web.UI.Page
{
    DepartmentBLL oDepartmentBLL = new DepartmentBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Accounts > Department";
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
        DataTable dt = oDepartmentBLL.Department_GetDataForGV();

        gvDepartmentList.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvDepartmentList.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvDepartmentList.PageSize * (gvDepartmentList.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvDepartmentList.PageSize;

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

        if (gvDepartmentList.Rows.Count < 1)
        {
            gvDepartmentList.EmptyDataText = "No Data Found";
        }

        gvDepartmentList.DataBind();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        //string SegmentsNameExist = CheckSegmentsName(txtCode.Text.Trim());
        //if (SegmentsNameExist == "true")
        //{
        //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Segment Name Already Exist.');", true);
        //    txtCode.Focus();
        //    return;
        //}
        //else
        //{
        Save();

        //}


    }
    private void Save()
    {

        DepartmentBOL entity = new DepartmentBOL();

        entity.Code = txtCode.Text.Trim();
        entity.Department = txtDepartment.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {

            entity.CreateBy = Session["UserID"].ToString();


            //Save record
            Id = oDepartmentBLL.Department_Add(entity);
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
            entity.AutoID = Convert.ToInt32(hfAutoId.Value);
            entity.ChangedBy = Session["UserID"].ToString();

            Id = oDepartmentBLL.Department_Update(entity);

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
    protected void gvDepartmentList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvDepartmentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DepartmentBOL entity = new DepartmentBOL();
        Int32 Id = Convert.ToInt32(gvDepartmentList.DataKeys[e.RowIndex].Value);
        entity.AutoID = Id;
        int success = oDepartmentBLL.Department_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvDepartmentList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DepartmentBOL DepartmentBOL = new DepartmentBOL();
        Int32 Id = Convert.ToInt32(gvDepartmentList.DataKeys[e.NewEditIndex].Value);
        DepartmentBOL.AutoID = Id;
        DepartmentBOL = oDepartmentBLL.Department_GetById(DepartmentBOL);
        SetDataToControls(DepartmentBOL);
    }
    private void SetDataToControls(DepartmentBOL Department)
    {

        try
        {
            txtCode.Text = Department.Code.ToString();
        }
        catch
        {
            txtCode.Text = "";
        }
        try
        {
            txtDepartment.Text = Department.Department.ToString();
        }
        catch
        {
            txtDepartment.Text = "";
        }


        hfAutoId.Value = Department.AutoID.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtCode.Focus();
        txtCode.Text = string.Empty;
        txtDepartment.Text = string.Empty;
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
    protected void gvDepartmentList_Sorting(object sender, GridViewSortEventArgs e)
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
            gvDepartmentList.DataSource = sortedView;
            gvDepartmentList.DataBind();

        }
    }
    protected void gvDepartmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvDepartmentList.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvDepartmentList.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvDepartmentList.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvDepartmentList.PageSize * (gvDepartmentList.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvDepartmentList.PageSize;

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
            gvDepartmentList.DataBind();
        }
        else
        {
            BindList();
            gvDepartmentList.DataBind();
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
            string sql = "SP_TB_DepartmentListExcel";
            dt2 = Global.CreateDataTable(sql);
            string FileName = "DepartmentList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "DepartmentList");


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
        string sql = "SP_TB_DepartmentListSearchBox";
        dt = Global.CreateNo_FeesMasterSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvDepartmentList.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvDepartmentList.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvDepartmentList.PageSize * (gvDepartmentList.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvDepartmentList.PageSize;

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

        if (gvDepartmentList.Rows.Count < 1)
        {
            gvDepartmentList.EmptyDataText = "No Data Found";
        }

        gvDepartmentList.DataBind();
    }

    //* SP_TB_DepartmentListSearchBox
}