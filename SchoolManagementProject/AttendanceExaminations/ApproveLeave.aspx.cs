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
using iTextSharp.text;
using iTextSharp.text.pdf;
using DocumentFormat.OpenXml.Office2010.Excel;

public partial class AttendanceExaminations_ApproveLeave : System.Web.UI.Page
{
    ApproveLeaveBLL oApproveLeaveBLL = new ApproveLeaveBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!Page.IsPostBack)
            {
                Session["SortedView"] = null;
                Session["Dt"] = null;
                Session["iTotalRecords"] = 0;
                Session["PageLink"] = "Sage Reports";
                Session["breadcrumb"] = "Setting > Approve Leave";
                LoadClassList();
                LoadSectionListList();
                LoadSectionForLeaveList();
                LoadGetStudentData("0", "0", "0");
                LoadClassForLeaveList();
                LoadGetStudenForleavetData("0", "0", "0");
                BindList();
                btnsaveLeave.Visible = true;
                btnupdate.Visible = false;
            }

        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
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
    // 
    private void LoadClassForLeaveList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_ClassNameListDDL";
        dt = Global.CreateDataTable(sql);

        ddlClassForLeave.DataSource = dt;
        ddlClassForLeave.DataTextField = "ClassName";
        ddlClassForLeave.DataValueField = "Id";
        ddlClassForLeave.DataBind();


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
    private void LoadSectionForLeaveList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_SectionNameListDDL";
        dt = Global.CreateDataTable(sql);

        ddlSectionForLeave.DataSource = dt;
        ddlSectionForLeave.DataTextField = "SectionName";
        ddlSectionForLeave.DataValueField = "Id";
        ddlSectionForLeave.DataBind();


    }
    private void LoadGetStudentData(string ClassId, string SectionId, string StudentId)
    {
        DataTable dt = new DataTable();
        string sql = "SP_StudentAdmissionDDL";
        dt = Global.CreateDataTableParameter_GetStudentData(sql, ClassId, SectionId, StudentId);

        ddlStudent.DataSource = dt;
        ddlStudent.DataTextField = "StudentName";
        ddlStudent.DataValueField = "Id";
        ddlStudent.DataBind();


    }
    private void LoadGetStudenForleavetData(string ClassId, string SectionId, string StudentId)
    {
        DataTable dt = new DataTable();
        string sql = "SP_StudentAdmissionDDL";
        dt = Global.CreateDataTableParameter_GetStudentData(sql, ClassId, SectionId, StudentId);

        ddlStudentForLeave.DataSource = dt;
        ddlStudentForLeave.DataTextField = "StudentName";
        ddlStudentForLeave.DataValueField = "Id";
        ddlStudentForLeave.DataBind();


    }

    protected void btnAddLeave_Click(object sender, EventArgs e)
    {
        if (ddlClass.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Leave Class.');", true);
            ddlClass.Focus();
            return;
        }
        if (ddlSection.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Leave Section.');", true);
            ddlSection.Focus();
            return;
        }
        if (ddlStudent.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Leave Student.');", true);
            ddlStudent.Focus();
            return;
        }

        ddlClassForLeave.SelectedValue = ddlClass.SelectedValue;
        ddlClassForLeave.Enabled = false;
        ddlSectionForLeave.SelectedValue = ddlSection.SelectedValue;
        ddlSectionForLeave.Enabled = false;
        ddlStudentForLeave.SelectedValue = ddlStudent.SelectedValue;
        ddlStudentForLeave.Enabled = false;

        mp1.Show();
    }
    protected void btnsaveLeave_Click(object sender, EventArgs e)
    {
        Save();


    }

    private void Save()
    {

        ApproveLeaveBOL entity = new ApproveLeaveBOL();
        entity.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
        entity.SectionId = Convert.ToInt32(ddlSection.SelectedValue);
        entity.StudentId = Convert.ToInt32(ddlStudent.SelectedValue);

        if (txtDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.ApplyDate = JoiningDate;
        }
        else
        {
            entity.ApplyDate = Convert.ToDateTime("01/01/1991");

        }

        if (txtFromDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.FromDate = JoiningDate;
        }
        else
        {
            entity.FromDate = Convert.ToDateTime("01/01/1991");

        }
        if (txtToDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.ToDate = JoiningDate;
        }
        else
        {
            entity.ToDate = Convert.ToDateTime("01/01/1991");

        }

        entity.ApprovedBy = Convert.ToInt32(Session["UserID"].ToString());

        entity.Reason = txtReason.Text;

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {

            entity.CreateBy = Session["UserID"].ToString();

            //Save record
            Id = oApproveLeaveBLL.ApproveLeave_Add(entity);
            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                BindList();
            }
        }
        else
        {
            //Update record          
            entity.Id = Convert.ToInt32(hfAutoId.Value);
            entity.ChangedBy = Session["UserID"].ToString();
            entity.ClassId = Convert.ToInt32(ddlClassForLeave.SelectedValue);
            entity.SectionId = Convert.ToInt32(ddlSectionForLeave.SelectedValue);
            entity.StudentId = Convert.ToInt32(ddlStudentForLeave.SelectedValue);
            Id = oApproveLeaveBLL.ApproveLeave_Update(entity);

            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                BindList();
            }
        }
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedValue != "0")
        {
            LoadGetStudentData(ddlClass.SelectedValue, ddlSection.SelectedValue, ddlStudent.SelectedValue);
        }
        else
        {
            LoadGetStudentData("0", "0", "0");
        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSection.SelectedValue != "0")
        {
            LoadGetStudentData(ddlClass.SelectedValue, ddlSection.SelectedValue, ddlStudent.SelectedValue);
        }
        else
        {
            LoadGetStudentData("0", "0", "0");
        }
    }

    private void BindList()
    {
        DataTable dt = oApproveLeaveBLL.ApproveLeave_GetDataForGV();

        Session["Dt"] = dt;
        gvApproveLeaveDetail.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvApproveLeaveDetail.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvApproveLeaveDetail.PageSize * (gvApproveLeaveDetail.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvApproveLeaveDetail.PageSize;

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

        if (gvApproveLeaveDetail.Rows.Count < 1)
        {
            gvApproveLeaveDetail.EmptyDataText = "No Data Found";
        }

        gvApproveLeaveDetail.DataBind();
    }

    protected void gvApproveLeaveDetail_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvApproveLeaveDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        ApproveLeaveBOL entity = new ApproveLeaveBOL();
        Int32 Id = Convert.ToInt32(gvApproveLeaveDetail.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oApproveLeaveBLL.ApproveLeave_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvApproveLeaveDetail_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        //Clear();
        GetSelectedData(e);

    }

    protected void gvApproveLeaveDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvApproveLeaveDetail.PageIndex = e.NewPageIndex;
        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvApproveLeaveDetail.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvApproveLeaveDetail.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvApproveLeaveDetail.PageSize * (gvApproveLeaveDetail.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvApproveLeaveDetail.PageSize;

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
            gvApproveLeaveDetail.DataBind();
        }
        else
        {
            //BindSuppliersDetails();
            BindList();
            gvApproveLeaveDetail.DataBind();
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
    protected void gvApproveLeaveDetail_Sorting(object sender, GridViewSortEventArgs e)
    {

        DataTable dataTable = new DataTable();

        dataTable = oApproveLeaveBLL.ApproveLeave_GetDataForGV();

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
            gvApproveLeaveDetail.DataSource = sortedView;
            gvApproveLeaveDetail.DataBind();
            //SortDireaction = asc_desc;
        }
    }

    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        ApproveLeaveBOL entity = new ApproveLeaveBOL();
        Int32 Id = Convert.ToInt32(gvApproveLeaveDetail.DataKeys[e.NewEditIndex].Value);
        entity.Id = Id;
        entity = oApproveLeaveBLL.ApproveLeave_GetById(entity);
        SetDataToControls(entity);
    }
    private void SetDataToControls(ApproveLeaveBOL oApproveLeave)
    {


        try
        {
            ddlStudentForLeave.SelectedValue = oApproveLeave.StudentId.ToString();
        }
        catch
        {
            ddlStudentForLeave.SelectedValue = "0";
        }
        try
        {
            ddlClassForLeave.SelectedValue = oApproveLeave.ClassId.ToString();
        }
        catch
        {
            ddlClassForLeave.SelectedValue = "0";
        }
        try
        {
            ddlSectionForLeave.SelectedValue = oApproveLeave.SectionId.ToString();
        }
        catch
        {
            ddlSectionForLeave.SelectedValue = "0";
        }
        try
        {
            txtDate.Text = oApproveLeave.ApplyDateBind.ToString();
        }
        catch
        {
            txtDate.Text = "";
        }
        try
        {
            txtFromDate.Text = oApproveLeave.FromDateBind.ToString();
        }
        catch
        {
            txtFromDate.Text = "";
        }
        try
        {
            txtToDate.Text = oApproveLeave.ToDateBind.ToString();
        }
        catch
        {
            txtToDate.Text = "";
        }

        try
        {
            txtReason.Text = oApproveLeave.Reason.ToString();
        }
        catch
        {
            txtReason.Text = "";
        }

        ddlClassForLeave.Enabled = false;

        ddlSectionForLeave.Enabled = false;

        ddlStudentForLeave.Enabled = false;
        mp1.Show();
        hfAutoId.Value = oApproveLeave.Id.ToString();
        btnsaveLeave.Visible = false;
        btnupdate.Visible = true;
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            string _SearchBox = "";
            if (txtSearchBox.Text == "")
            {
                _SearchBox = "0";
            }
            else
            {
                _SearchBox = txtSearchBox.Text;
            }
            string sql = "SP_TB_ApproveLeaveListSearch";

            dt2 = Global.CreateDataTableParameter_ApproveleaveSearch(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, ddlStudent.SelectedValue, _SearchBox);

            // dt2 = (DataTable)Session["Dt"];
            string FileName = "LeaveList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "LeaveList");




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

    protected void btnDownloadPDF_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        string _SearchBox = "";
        if (txtSearchBox.Text == "")
        {
            _SearchBox = "0";
        }
        else
        {
            _SearchBox = txtSearchBox.Text;
        }
        string sql = "SP_TB_ApproveLeaveListSearch";

        dt2 = Global.CreateDataTableParameter_ApproveleaveSearch(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, ddlStudent.SelectedValue, _SearchBox);


        ExportToPdf(dt2, "Leave List", "Leave_List");
    }
    public void ExportToPdf(DataTable myDataTable, string _PDFHeadName, string _FileName)
    {
        DataTable dt = myDataTable;
        Document pdfDoc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
        Font font13 = FontFactory.GetFont("ARIAL", 12);
        Font font18 = FontFactory.GetFont("ARIAL", 12);

        try
        {
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
            pdfDoc.Open();

            if (dt.Rows.Count > 0)
            {
                PdfPTable PdfTable = new PdfPTable(1);
                PdfTable.TotalWidth = 200f;
                PdfTable.LockedWidth = true;

                PdfPCell PdfPCell = new PdfPCell(new Phrase(new Chunk(_PDFHeadName, font18)));
                PdfPCell.Border = Rectangle.NO_BORDER;
                PdfTable.AddCell(PdfPCell);
                DrawLine(writer, 25f, pdfDoc.Top - 30f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 30f, new BaseColor(System.Drawing.Color.Red));
                pdfDoc.Add(PdfTable);

                PdfTable = new PdfPTable(dt.Columns.Count);
                PdfTable.SpacingBefore = 20f;
                for (int columns = 0; columns <= dt.Columns.Count - 1; columns++)
                {
                    PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Columns[columns].ColumnName, font18)));
                    PdfTable.AddCell(PdfPCell);
                }

                for (int rows = 0; rows <= dt.Rows.Count - 1; rows++)
                {
                    for (int column = 0; column <= dt.Columns.Count - 1; column++)
                    {
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font13)));
                        PdfTable.AddCell(PdfPCell);
                    }
                }
                pdfDoc.Add(PdfTable);
            }
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            /// Response.AddHeader("content-disposition", "attachment; filename=\"" + _FileName + "\"") + "(" + DateTime.Now.ToString("MM-dd-yyyy-HH:mm:ss") + ")" + ".pdf");

            Response.AddHeader("content-disposition", "attachment;filename=\"" + _FileName + "\"+(" + DateTime.Now.ToString("MM - dd - yyyy - HH:mm: ss") + ")" + ".pdf");

            System.Web.HttpContext.Current.Response.Write(pdfDoc);
            Response.Flush();
            Response.End();
        }
        catch (DocumentException de)
        {
        }
        // System.Web.HttpContext.Current.Response.Write(de.Message)
        catch (IOException ioEx)
        {
        }
        // System.Web.HttpContext.Current.Response.Write(ioEx.Message)
        catch (Exception ex)
        {
        }
    }
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }

}




