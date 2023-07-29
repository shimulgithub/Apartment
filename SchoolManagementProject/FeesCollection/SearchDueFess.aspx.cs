using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Data.SqlClient;
using System.IO;

using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMP.Common;
public partial class FeesCollection_SearchDueFess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!Page.IsPostBack)
            {
                Session["SortedView"] = null;
                Session["iTotalRecords"] = 0;
                Session["Dt"] = null;
                Session["SortedView"] = null;
                Session["PageLink"] = "Sage Reports";
                Session["breadcrumb"] = "Accounts>Fees Search(Due) ";
                LoadClassList();
                LoadSectionListList();
                LoadFeesTypeList();
                LoadBindList();
            }

        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }

    }
    private void LoadFeesTypeList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_FeesTypeListDDL";
        dt = Global.CreateDataTable(sql);

        ddlFeesType.DataSource = dt;
        ddlFeesType.DataTextField = "Name";
        ddlFeesType.DataValueField = "Id";
        ddlFeesType.DataBind();


    }
    private void LoadClassList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_ClassNameListDDL";
        dt = Global.CreateDataTable(sql);

        ddlClass.DataSource = dt;
        ddlClass.DataTextField = "ClassName";
        ddlClass.DataValueField = "Id";
        ddlClass.DataBind();


    }
    private void LoadSectionListList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_SectionNameListDDL";
        dt = Global.CreateDataTable(sql);

        ddlSection.DataSource = dt;
        ddlSection.DataTextField = "SectionName";
        ddlSection.DataValueField = "Id";
        ddlSection.DataBind();


    }
    private void LoadBindList()
    {
        try
        {
            DataTable dt = new DataTable();
            string sql = "SP_TB_FeesSearchDue";
            string _SearchBox = "";
            if (txtSearchBox.Text == "")
            {
                _SearchBox = "0";
            }
            else
            {
                _SearchBox = txtSearchBox.Text;
            }
            dt = Global.CreateDataTableParameter_FeesSearchDue(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, ddlFeesType.SelectedValue, _SearchBox);
            Session["Dt"] = dt;
            gvStudentWiseFeesCollectionDetail.DataSource = dt;
            int iTotalRecords = ((DataTable)(gvStudentWiseFeesCollectionDetail.DataSource)).Rows.Count;
            Session["iTotalRecords"] = iTotalRecords;
            int iEndRecord = gvStudentWiseFeesCollectionDetail.PageSize * (gvStudentWiseFeesCollectionDetail.PageIndex + 1);

            int iStartsRecods = iEndRecord - gvStudentWiseFeesCollectionDetail.PageSize;

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

            Label22.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
            if (gvStudentWiseFeesCollectionDetail.Rows.Count < 1)
            {
                gvStudentWiseFeesCollectionDetail.EmptyDataText = "No Data Found";
            }






            gvStudentWiseFeesCollectionDetail.DataBind();
        }



        catch (Exception ex)
        {
            Response.Write("Oops! error occured:" + ex.Message.ToString());
        }
        finally
        {


        }

    }
    protected void gvStudentWiseFeesCollectionDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }
    protected void HeaderChkAll_CheckedChanged(object sender, EventArgs e)
    {



        if (((CheckBox)gvStudentWiseFeesCollectionDetail.HeaderRow.Cells[0].FindControl("chkBxHeader")).Checked == true)
        {
            foreach (GridViewRow row in gvStudentWiseFeesCollectionDetail.Rows)
            {


                CheckBox chkBxSelect = (CheckBox)row.FindControl("chkBxSelect");
                chkBxSelect.Checked = true;


            }
        }
        else
        {
            foreach (GridViewRow row in gvStudentWiseFeesCollectionDetail.Rows)
            {


                CheckBox chkBxSelect = (CheckBox)row.FindControl("chkBxSelect");
                chkBxSelect.Checked = false;


            }



        }





    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        LoadBindList();
    }
    protected void gvStudentWiseFeesCollectionDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentWiseFeesCollectionDetail.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvStudentWiseFeesCollectionDetail.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvStudentWiseFeesCollectionDetail.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvStudentWiseFeesCollectionDetail.PageSize * (gvStudentWiseFeesCollectionDetail.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvStudentWiseFeesCollectionDetail.PageSize;

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

            Label22.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
            gvStudentWiseFeesCollectionDetail.DataBind();
        }
        else
        {
            //BindSuppliersDetails();
            LoadBindList();
            gvStudentWiseFeesCollectionDetail.DataBind();
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
    protected void gvStudentWiseFeesCollectionDetail_Sorting(object sender, GridViewSortEventArgs e)
    {

        DataTable dataTable = new DataTable();
        string sql = "SP_TB_FeesSearchPayment";

        dataTable = Global.CreateDataTableParameter_FeesSearchPayment(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, ddlFeesType.SelectedValue);

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
            //dataTable.DefaultView.Sort = e.SortExpression + " " + e.SortDirection ;
            Session["SortedView"] = sortedView;
            gvStudentWiseFeesCollectionDetail.DataSource = sortedView;
            gvStudentWiseFeesCollectionDetail.DataBind();
            //SortDireaction = asc_desc;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlClass.SelectedValue = "0";
        ddlFeesType.SelectedValue = "0";
        ddlSection.SelectedValue = "0";
        txtSearchBox.Text = string.Empty;
        LoadBindList();

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
            string sql = "SP_TB_FeesSearchDueExportToExcel";
            string _SearchBox = "";
            if (txtSearchBox.Text == "")
            {
                _SearchBox = "0";
            }
            else
            {
                _SearchBox = txtSearchBox.Text;
            }
            dt2 = Global.CreateDataTableParameter_FeesSearchDue(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, ddlFeesType.SelectedValue,_SearchBox);

            // dt2 = (DataTable)Session["Dt"];
            string FileName = "DueFeesList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "DueFeesList");

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
            LoadBindList();
        }
        else
        {
            LoadBindList();
        }


    }
    protected void btnDuePrint_Click(object sender, EventArgs e)
    {
      
        string _SearchBox = "";
        if (txtSearchBox.Text == "")
        {
            _SearchBox = "0";
        }
        else
        {
            _SearchBox = txtSearchBox.Text;
        }
        string ClassId = ddlClass.SelectedValue;
        string SectionId = ddlSection.SelectedValue;
        string TypeId = ddlFeesType.SelectedValue;
        try
        {
           
            string redirectPage = "";

            string param = "FeesDueSearch";

            string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
            redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&CId=" + Server.UrlEncode(ClassId) + "&SId=" + Server.UrlEncode(SectionId) + "&TId=" + Server.UrlEncode(TypeId) + "&sBoxtxt=" + Server.UrlEncode(_SearchBox);
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
               "UniqueID", "Popup('" + redirectPage + "');", true);
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }

}