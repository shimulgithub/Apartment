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


public partial class IncomeExpense_IncomeHead : System.Web.UI.Page
{
    IncomeHeadBLL oIncomeHeadBLL = new IncomeHeadBLL();
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
                Session["breadcrumb"] = "Income Head";
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
        DataTable dt = oIncomeHeadBLL.IncomeHead_GetDataForGV();
    
        Session["Dt"] = dt;
        gvIncomeHead.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvIncomeHead.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvIncomeHead.PageSize * (gvIncomeHead.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvIncomeHead.PageSize;

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

        if (gvIncomeHead.Rows.Count < 1)
        {
            gvIncomeHead.EmptyDataText = "No Data Found";
        }

        gvIncomeHead.DataBind();
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
    protected void gvIncomeHead_Sorting(object sender, GridViewSortEventArgs e)
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
            gvIncomeHead.DataSource = sortedView;
            gvIncomeHead.DataBind();

        }
    }
    protected void gvIncomeHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvIncomeHead.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvIncomeHead.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvIncomeHead.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvIncomeHead.PageSize * (gvIncomeHead.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvIncomeHead.PageSize;

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
            gvIncomeHead.DataBind();
        }
        else
        {
            BindList();
            gvIncomeHead.DataBind();
        }

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

        IncomeHeadBOL entity = new IncomeHeadBOL();

        entity.HeadName = txtName.Text.Trim();
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {



            //Save record
            Id = oIncomeHeadBLL.IncomeHead_Add(entity);
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

            Id = oIncomeHeadBLL.IncomeHead_Update(entity);

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
    protected void gvIncomeHead_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvIncomeHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        IncomeHeadBOL entity = new IncomeHeadBOL();
        Int32 Id = Convert.ToInt32(gvIncomeHead.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oIncomeHeadBLL.IncomeHead_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvIncomeHead_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        IncomeHeadBOL IncomeHeadBOL = new IncomeHeadBOL();
        Int32 Id = Convert.ToInt32(gvIncomeHead.DataKeys[e.NewEditIndex].Value);
        IncomeHeadBOL.Id = Id;
        IncomeHeadBOL = oIncomeHeadBLL.IncomeHead_GetById(IncomeHeadBOL);
        SetDataToControls(IncomeHeadBOL);
    }
    private void SetDataToControls(IncomeHeadBOL IncomeHead)
    {

        try
        {
            txtName.Text = IncomeHead.HeadName.ToString();
        }
        catch
        {
            txtName.Text = "";
        }

        try
        {
            txtDescription.Text = IncomeHead.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = IncomeHead.Id.ToString();
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
        string sql = "SP_TB_IncomeHeadBySearchBox";
        dt = Global.CreateNo_IncomeSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvIncomeHead.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvIncomeHead.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvIncomeHead.PageSize * (gvIncomeHead.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvIncomeHead.PageSize;

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

        if (gvIncomeHead.Rows.Count < 1)
        {
            gvIncomeHead.EmptyDataText = "No Data Found";
        }

        gvIncomeHead.DataBind();


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
            string sql = "SP_TB_IncomeHeadListExportToExel";
            dt2 = Global.CreateDataTable(sql);

            string FileName = "IncomeHeadListExport_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "IncomeHeadListExport");

                //var TJan = 0;  //Total Invoice January
                //var TJan_co = 0;
                //var TJan_ro = 1;


                //for (int i = 0; i < dt2.Columns.Count; i++)
                //{
                //    string ColumnName = dt2.Columns[i].ColumnName.ToString();

                //    if (ColumnName == "Amount (TK)")
                //    {
                //        TJan = 1;
                //        TJan_co = i + 1;
                //    }

                //}

                //for (int i = 0; i < dt2.Rows.Count; i++)
                //{
                //    if (TJan == 1)
                //    {
                //        ws.Cell(++TJan_ro, TJan_co).Value = dt2.Rows[i]["Amount (TK)"].ToString();
                //        ws.Cell(TJan_ro, TJan_co).Style.NumberFormat.Format = "0.00";
                //    }

                //}
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