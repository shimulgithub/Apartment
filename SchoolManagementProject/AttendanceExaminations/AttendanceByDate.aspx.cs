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

public partial class AttendanceExaminations_AttendanceByDate : System.Web.UI.Page
{
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
                Session["breadcrumb"] = "Setting > Attendance Details";
                LoadClassList();
                LoadSectionListList();
                LoadBindList();
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
            string sql = "SP_TB_AttendanceList";
            string _SearchBox = "";
            if (txtSearchBox.Text == "")
            {
                _SearchBox = "0";
            }
            else
            {
                _SearchBox = txtSearchBox.Text;
            }

            DateTime _FromDatee = new DateTime();
            if (txtFromDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                _FromDatee = JoiningDate;
            }
            else
            {
                _FromDatee = Convert.ToDateTime("01/01/1991");
            }

            DateTime _ToDate = new DateTime();

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

            dt = Global.CreateDataTableParameter_StudentAttendanceDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, _FromDatee, _ToDate, _SearchBox);
            Session["Dt"] = dt;
            gvStudentAttendanceDetail.DataSource = dt;
            int iTotalRecords = ((DataTable)(gvStudentAttendanceDetail.DataSource)).Rows.Count;
            Session["iTotalRecords"] = iTotalRecords;
            int iEndRecord = gvStudentAttendanceDetail.PageSize * (gvStudentAttendanceDetail.PageIndex + 1);

            int iStartsRecods = iEndRecord - gvStudentAttendanceDetail.PageSize;

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
            if (gvStudentAttendanceDetail.Rows.Count < 1)
            {
                gvStudentAttendanceDetail.EmptyDataText = "No Data Found";
            }


            gvStudentAttendanceDetail.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("Oops! error occured:" + ex.Message.ToString());
        }
        finally
        {


        }

    }

    protected void txtSearchBox_TextChanged(object sender, EventArgs e)
    {
        if (txtSearchBox.Text != "")
        {
            LoadBindList();

        }

     }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        LoadBindList();
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt2 = new DataTable();
           
           
             dt2 = (DataTable)Session["Dt"];
            string FileName = "AttendanceDetail_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "AttendanceDetail");

              

               
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
       
        DataTable dt2 = new DataTable();
        dt2 = (DataTable)Session["Dt"];
        ExportToPdf(dt2, "Attendance Details", "AttendanceDetails");
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
    protected void gvStudentAttendanceDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentAttendanceDetail.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvStudentAttendanceDetail.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvStudentAttendanceDetail.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvStudentAttendanceDetail.PageSize * (gvStudentAttendanceDetail.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvStudentAttendanceDetail.PageSize;

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
            gvStudentAttendanceDetail.DataBind();
        }
        else
        {
            //BindSuppliersDetails();
            LoadBindList();
            gvStudentAttendanceDetail.DataBind();
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
    protected void gvStudentAttendanceDetail_Sorting(object sender, GridViewSortEventArgs e)
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
            //dataTable.DefaultView.Sort = e.SortExpression + " " + e.SortDirection ;
            Session["SortedView"] = sortedView;
            gvStudentAttendanceDetail.DataSource = sortedView;
            gvStudentAttendanceDetail.DataBind();
            //SortDireaction = asc_desc;
        }
    }

}