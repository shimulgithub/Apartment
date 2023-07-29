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

public partial class IncomeExpense_IncomeSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                Session["Dt"] = null;
                Session["SortedView"] = null;
              
                Session["breadcrumb"] = "Income Search";
               
                LoadIncomeHeadList();
                BindList();

            }
            // this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }

    }
    IncomeBLL oIncomeBLL = new IncomeBLL();
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
        DateTime _FromDate = new DateTime();
        DateTime _ToDate = new DateTime();

        if (txtFromDate.Text!= "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            _FromDate = JoiningDate;
        }
        else
        {
            _FromDate = Convert.ToDateTime("01/01/1991");

        }
        if (txtToDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            _ToDate = JoiningDate;
        }
        else
        {
            _ToDate = Convert.ToDateTime("01/01/1991");

        }

        string _SearchText = "";
        if (txtSearchBox.Text == "")
        {
            _SearchText = "0";
        }

        DataTable dt = new DataTable();
           string sql = "SP_TB_IncomeListSearch";
            dt = Global.CreateDataTableParameter_IncomeSearch(sql,ddlIncomeHead.SelectedValue, _FromDate,_ToDate, _SearchText);




        Session["Dt"] = dt;
        gvIncomeSearch.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvIncomeSearch.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvIncomeSearch.PageSize * (gvIncomeSearch.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvIncomeSearch.PageSize;

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

        if (gvIncomeSearch.Rows.Count < 1)
        {
            gvIncomeSearch.EmptyDataText = "No Data Found";
        }

        gvIncomeSearch.DataBind();


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = string.Empty;
        txtToDate.Text = string.Empty;
        ddlIncomeHead.SelectedValue = "0";
        txtSearchBox.Text = "";
        BindList();

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
            //string sql = "SP_TB_IncomeSearchListToExcel";
            //dt2 = Global.CreateDataTable(sql);
            dt2 = (DataTable)Session["Dt"];
            string FileName = "IncomeSearchList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "IncomeSearchList");

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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //LinkButton lnkUserID = sender as LinkButton;
        //GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
        //Label lblId = (Grow.FindControl("lblId") as Label);
        //Label lblIncomeAmount = (Grow.FindControl("lblIncomeAmount") as Label);

        try
        {
            //string _Id = lblId.Text.ToString();
            //string _Amount = lblIncomeAmount.Text.ToString();
            string redirectPage = "";

            string param = "IncomePrintSearch";

            string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
            redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param ;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
               "UniqueID", "Popup('" + redirectPage + "');", true);
        }
        catch (Exception ex)
        {
            throw ex;

        }
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
    protected void gvIncomeSearch_Sorting(object sender, GridViewSortEventArgs e)
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
            gvIncomeSearch.DataSource = sortedView;
            gvIncomeSearch.DataBind();

        }
    }
    protected void gvIncomeSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvIncomeSearch.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvIncomeSearch.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvIncomeSearch.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvIncomeSearch.PageSize * (gvIncomeSearch.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvIncomeSearch.PageSize;

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
            gvIncomeSearch.DataBind();
        }
        else
        {
            BindList();
            gvIncomeSearch.DataBind();
        }

    }
}