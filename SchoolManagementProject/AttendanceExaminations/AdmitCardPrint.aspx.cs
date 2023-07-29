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

public partial class AttendanceExaminations_AdmitCardPrint : System.Web.UI.Page
{
    string _connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
    public string UploadFolderPath = "~/images/defalt.jpg";
    CollectFeesBLL oCollectFeesBLL = new CollectFeesBLL();
    StudentAdmissionBLL oStudentAdmissionBLL = new StudentAdmissionBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!Page.IsPostBack)
            {
                Session["SortedView"] = null;
                Session["chkdt"] = null;
                Session["StudentFeesDetail"] = null;
                Session["iTotalRecords"] = 0;
                Session["PageLink"] = "Sage Reports";
                Session["breadcrumb"] = "Setting> Admit Card Print ";
                BindTableColumns();
                LoadClassList();
                LoadSectionListList();
               
                LoadExamTypeList();
                LoadYearList();
                LoadStudentListByParam();
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
    private void LoadYearList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_YearListDDL";
        dt = Global.CreateDataTable(sql);

        ddlYear.DataSource = dt;
        ddlYear.DataTextField = "YearTxt";
        ddlYear.DataValueField = "YearVal";
        ddlYear.DataBind();


    }
    private void LoadExamTypeList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_ExamNameListDDL";
        dt = Global.CreateDataTable(sql);

        ddlExamName.DataSource = dt;
        ddlExamName.DataTextField = "Name";
        ddlExamName.DataValueField = "Id";
        ddlExamName.DataBind();


    }
    private void LoadStudentListByParam()
    {
        DataTable dt = new DataTable();
        string sql = "SP_StudentDDLByParam";
        dt = Global.CreateDataTableParameter_GetStudentDataByParam(sql,ddlClass.SelectedValue,ddlSection.SelectedValue,ddlYear.SelectedValue);

        ddlStudent.DataSource = dt;
        ddlStudent.DataTextField = "StudentName";
        ddlStudent.DataValueField = "Id";
        ddlStudent.DataBind();


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
    private void BindTableColumns()
    {

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["ConS2pibd"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = @" SELECT [AutoID],[HeaderValue],[HeaderText] FROM TB_StudentAdmitCardInfo_Header  ORDER BY [Order_Priority] ASC";

                chkFields.Items.Clear();
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    int i = 0;


                    while (sdr.Read())
                    {
                        i++;
                        System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                        item.Text = sdr["HeaderText"].ToString();
                        item.Value = sdr["HeaderValue"].ToString();
                        if (i <= 6)
                        {
                            item.Selected = true; // Convert.ToBoolean(sdr["IsSelected"]);
                        }
                        chkFields.Items.Add(item);
                    }
                }
                conn.Close();
            }
        }
    }
    protected void btnColumns_Click(object sender, EventArgs e)
    {

        mp1.Show();

    }
    public void createPDF(DataTable dataTable)
    {
        //Document document = new Document();
        //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("d://sampleJahidV.pdf", FileMode.OpenOrCreate));
        //document.Open();
        //PdfPTable table = new PdfPTable(dataTable.Columns.Count);
        //table.WidthPercentage = 100;
        //for (int k = 0; k < dataTable.Columns.Count; k++)
        //{
        //    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName));

        //    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
        //    cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

        //    table.AddCell(cell);
        //}
        //for (int i = 0; i < dataTable.Rows.Count; i++)
        //{
        //    for (int j = 0; j < dataTable.Columns.Count; j++)
        //    {
        //        PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));
        //        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
        //        table.AddCell(cell);
        //    }
        //}

        //document.Add(table);
        //document.Close();
    }
    private void ShowPdf(string strS)
    {
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader
        //("Content-Disposition", "attachment; filename=" + strS);
        //Response.TransmitFile(strS);
        //Response.End();
        //Response.Flush();
        //Response.Clear();

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        dvGV.Visible = true;
        BindlistStudentDetail();


    }
    protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkAll.Checked == true)
        {
            foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
            {

                item.Selected = true;


            }
        }
        else
        {
            foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
            {

                item.Selected = false;


            }
        }

    }
    private void BindlistStudentDetail()
    {
        DataTable dt2 = new DataTable();
        string sql = "SP_TB_StudentDetailForAdmitPrint";
        dt2 = Global.CreateDataTableParameter_StudentDetailForAdmitCard(sql,ddlStudent.SelectedValue, ddlClass.SelectedValue, ddlSection.SelectedValue,ddlExamName.SelectedValue,ddlYear.SelectedValue);
    
         gvStudentWiseFeesCollectionDetail.DataSource = dt2;
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

         Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
        if (gvStudentWiseFeesCollectionDetail.Rows.Count < 1)
        {
            gvStudentWiseFeesCollectionDetail.EmptyDataText = "No Data Found";
        }

        foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
        {



            //BoundField b = new BoundField();
            //b.DataField = item.Value;
            //b.HeaderText = item.Text;
            //b.SortExpression = item.Value;
            if (item.Value == "StudentName")
            {
                if (item.Selected)
                {
                    gvStudentWiseFeesCollectionDetail.Columns[1].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[1].Visible = false;
                }

            }




            if (item.Value == "ClassName")
            {
                if (item.Selected)
                {
                    gvStudentWiseFeesCollectionDetail.Columns[2].Visible = true;
                }
                else
                {

                    gvStudentWiseFeesCollectionDetail.Columns[2].Visible = false;
                }
            }

            if (item.Value == "RollNo")
            {
                if (item.Selected)
                {
                    gvStudentWiseFeesCollectionDetail.Columns[3].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[3].Visible = false;
                }
            }

            if (item.Value == "CollectCode")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[4].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[4].Visible = false;
                }
            }


            if (item.Value == "FeesType")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[5].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[5].Visible = false;

                }
            }


            if (item.Value == "Status")
            {
                if (item.Selected)
                {
                    gvStudentWiseFeesCollectionDetail.Columns[6].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[6].Visible = false;

                }
            }


            if (item.Value == "FeesCode")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[7].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[7].Visible = false;
                }
            }



            if (item.Value == "DueDate")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[8].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[8].Visible = false;

                }
            }

            if (item.Value == "PaymentCode")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[9].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[9].Visible = false;

                }
            }


            if (item.Value == "PaymentMode")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[10].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[10].Visible = false;
                }
            }


            if (item.Value == "PaymentDate")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[11].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[11].Visible = false;

                }
            }

            if (item.Value == "Amount")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[12].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[12].Visible = false;

                }
            }

            if (item.Value == "Fine")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[13].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[13].Visible = false;

                }
            }

            if (item.Value == "Discount")
            {
                if (item.Selected)
                {


                    gvStudentWiseFeesCollectionDetail.Columns[14].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[14].Visible = false;
                }
            }

            if (item.Value == "Paid")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[15].Visible = true;
                }
                else

                {
                    gvStudentWiseFeesCollectionDetail.Columns[15].Visible = false;
                }
            }


            if (item.Value == "TotalAmount")
            {
                if (item.Selected)
                {
                    gvStudentWiseFeesCollectionDetail.Columns[16].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[16].Visible = false;

                }
            }

            if (item.Value == "Balance")
            {
                if (item.Selected)
                {
                    gvStudentWiseFeesCollectionDetail.Columns[17].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[17].Visible = false;

                }
            }

            if (item.Value == "Note")
            {
                if (item.Selected)
                {

                    gvStudentWiseFeesCollectionDetail.Columns[18].Visible = true;
                }
                else
                {
                    gvStudentWiseFeesCollectionDetail.Columns[18].Visible = false;
                }
            }
            gvStudentWiseFeesCollectionDetail.Columns[19].Visible = true;
        }


        gvStudentWiseFeesCollectionDetail.DataBind();
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
            Headerchk();

        }
        else
        {
            foreach (GridViewRow row in gvStudentWiseFeesCollectionDetail.Rows)
            {


                CheckBox chkBxSelect = (CheckBox)row.FindControl("chkBxSelect");
                chkBxSelect.Checked = false;


            }
            Session["chkdt"] = null;


        }

       


    }
    protected void btnDownloadPDF_Click(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();
        //DataTable dt2 = new DataTable();

        ////Create a dummy GridView
        //GridView GridView1 = new GridView();
        //dt = null;
        //GridView1.DataSource = null;
        //GridView1.DataBind();
        //GridView1.Columns.Clear();


        //foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
        //{

        //    if (item.Selected)
        //    {

        //        BoundField b = new BoundField();

        //        b.DataField = item.Value;
        //        b.HeaderText = item.Text;
        //        if (item.Value != "Images")
        //        {

        //            dt2.Columns.Add(item.Value);
        //            GridView1.Columns.Add(b);
        //        }

        //    }

        //}

        //string sql = "SP_TB_StudentAdmissionListDetail";
        //dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue);
        //for (int k = 0; k < dt.Rows.Count; k++)
        //{
        //    var row = dt.Rows[k];
        //    dt2.ImportRow(row);

        //}
        //for (int j = 0; j < chkFields.Items.Count; j++)
        //{

        //    for (int i = 0; i < dt2.Columns.Count; i++)
        //    {
        //        string cName = dt2.Columns[i].ColumnName.ToString();
        //        string cnkValue = chkFields.Items[j].Value;   // item.Value;
        //        string cnkName = chkFields.Items[j].Text;

        //        if (cName == cnkValue)
        //        {
        //            dt2.Columns[i].ColumnName = cnkName;
        //            break;
        //        }

        //    }

        //}

        //ExportToPdf(dt2,"Student Information", "StudentInformation");
    }
    public void ExportToPdf(DataTable myDataTable ,string _PDFHeadName,string _FileName)
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
    protected void btnPDFFeesCollect_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        string sql = "SP_TB_StudentWiseFeesCollectionDetailExportToExcel";
        dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStId.Value, "0", "0");

        if (dt2.Rows.Count > 0)
        {
            //ExportToPdf(dt2,lblStudentName.Text,"FeesDetail");

        }
    }
    protected void btnExcelFeesCollect_Click(object sender, EventArgs e)
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

            string sql = "SP_TB_StudentWiseFeesCollectionDetailExportToExcel";
            dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStId.Value, "0", "0");

            string FileName = "FeesDetailExport_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "FeesDetailExport");

               
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
    protected void chkBxSelect_CheckedChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        int i = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
        Label lblIdAuto = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblIdAuto");
        Label lblClassId = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblClassId");
        Label lblFeesCode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFeesCode");
        Label lblStudentName = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblStudentName");
        Label lblFeesType = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFeesType");
        Label lblFeesTypeId = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFeesTypeId");
        Label lblDueDate = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblDueDate");
        Label lblStatus = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblStatus");
        Label lblAmount = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblAmount");
        Label lblPaymentCode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaymentCode");
        Label lblPaymentMode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaymentMode");
        Label lblPaymentDate = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaymentDate");
        Label lblDiscount = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblDiscount");
        Label lblFine = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFine");
        Label lblTotalAmount = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblTotalAmount");
        Label lblPaid = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaid");
        Label lblBalance = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblBalance");
        Label lblCollectCode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblCollectCode");

        
        if (lblDiscount.Text == "")
        {
            lblDiscount.Text = "0.00";
        }
        if (lblFine.Text == "")
        {
            lblFine.Text = "0.00";
        }

        if (lblTotalAmount.Text == "")
        {
            lblTotalAmount.Text = "0.00";
        }

        if (lblPaid.Text == "")
        {
            lblPaid.Text = "0.00";
        }
        if (lblBalance.Text == "")
        {
            lblBalance.Text = "0.00";
        }

        if (Session["chkdt"] == null)
        {
            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("ClassId", typeof(String));
            dt.Columns.Add("StudentName", typeof(String));
            dt.Columns.Add("FeesCode", typeof(String));
            dt.Columns.Add("FeesType", typeof(String));
            dt.Columns.Add("FeesTypeId", typeof(String));
            dt.Columns.Add("DueDate", typeof(String));
            dt.Columns.Add("Status", typeof(String));
            dt.Columns.Add("Amount", typeof(float));
            dt.Columns.Add("PaymentCode", typeof(String));
            dt.Columns.Add("PaymentMode", typeof(String));
            dt.Columns.Add("PaymentDate", typeof(String));
            dt.Columns.Add("Discount", typeof(float));
            dt.Columns.Add("Fine", typeof(float));
            dt.Columns.Add("TotalAmount", typeof(float));
            dt.Columns.Add("Paid", typeof(float));
            dt.Columns.Add("Balance", typeof(float));
            dt.Columns.Add("CollectCode", typeof(String));
            
        }
        else
        {
            dt = (DataTable)Session["chkdt"];
        }
    
        DataRow myRow = dt.NewRow();
        dt.Rows.InsertAt(myRow, dt.Rows.Count);
        if (Convert.ToInt32(dt.Rows.Count) == 1)
        {
            i = 0;
        }
        else
        {
            i = dt.Rows.Count - 1;
        }
        Session["chkdt"] = dt;

        myRow = dt.Rows[i];
        myRow["Id"] = lblIdAuto.Text;
        myRow["StudentName"] = lblStudentName.Text;
        myRow["ClassId"] = lblClassId.Text;
        myRow["FeesCode"] = lblFeesCode.Text;
        myRow["FeesType"] = lblFeesType.Text;
        myRow["FeesTypeId"] = lblFeesTypeId.Text;
        myRow["DueDate"] = lblDueDate.Text;
        myRow["Status"] = lblStatus.Text;
        myRow["Amount"] = lblAmount.Text;
        myRow["PaymentCode"] = lblPaymentCode.Text;
        myRow["PaymentMode"] = lblPaymentMode.Text;
        myRow["PaymentDate"] = lblPaymentMode.Text;
        myRow["Discount"] = (lblDiscount.Text);
        myRow["Fine"] = Convert.ToDouble(lblFine.Text);
        myRow["TotalAmount"] = lblTotalAmount.Text;
        myRow["Paid"] = Convert.ToDouble(lblPaid.Text);
        myRow["Balance"] = Convert.ToDouble(lblBalance.Text);
        myRow["CollectCode"] = lblCollectCode.Text;


    }
    protected void btnPrintSelected_Click(object sender, EventArgs e)
    {
        Session["chkdt"] = null;
        Headerchk();

        if (Session["chkdt"] == null)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Please Select Item .');", true);

            return;
        }
        try
        {
            
            string redirectPage = "";

            string param = "PrintSelected";

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
    private void Headerchk()
    {
        for (int i = 0; i < gvStudentWiseFeesCollectionDetail.Rows.Count; i++)
        {

            CheckBox chkBxSelect = (CheckBox)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("chkBxSelect"); //SelectAll

            if (chkBxSelect.Checked == true)
            {
                DataTable dt = new DataTable();

          
                Label lblIdAuto = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblIdAuto");
                Label lblClassId = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblClassId");
                Label lblFeesCode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFeesCode");
                Label lblStudentName = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblStudentName");
                Label lblFeesType = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFeesType");
                Label lblFeesTypeId = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFeesTypeId");
                Label lblDueDate = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblDueDate");
                Label lblStatus = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblStatus");
                Label lblAmount = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblAmount");
                Label lblPaymentCode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaymentCode");
                Label lblPaymentMode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaymentMode");
                Label lblPaymentDate = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaymentDate");
                Label lblDiscount = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblDiscount");
                Label lblFine = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblFine");
                Label lblTotalAmount = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblTotalAmount");
                Label lblPaid = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblPaid");
                Label lblBalance = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblBalance");
                Label lblCollectCode = (Label)gvStudentWiseFeesCollectionDetail.Rows[i].FindControl("lblCollectCode");


                if (lblDiscount.Text == "")
                {
                    lblDiscount.Text = "0.00";
                }
                if (lblFine.Text == "")
                {
                    lblFine.Text = "0.00";
                }

                if (lblTotalAmount.Text == "")
                {
                    lblTotalAmount.Text = "0.00";
                }

                if (lblPaid.Text == "")
                {
                    lblPaid.Text = "0.00";
                }
                if (lblBalance.Text == "")
                {
                    lblBalance.Text = "0.00";
                }
             

                if (Session["chkdt"] == null)
                {
                    dt.Columns.Add("Id", typeof(String));
                    dt.Columns.Add("ClassId", typeof(String));
                    dt.Columns.Add("StudentName", typeof(String));
                    dt.Columns.Add("FeesCode", typeof(String));
                    dt.Columns.Add("FeesType", typeof(String));
                    dt.Columns.Add("FeesTypeId", typeof(String));
                    dt.Columns.Add("DueDate", typeof(String));
                    dt.Columns.Add("Status", typeof(String));
                    dt.Columns.Add("Amount", typeof(float));
                    dt.Columns.Add("PaymentCode", typeof(String));
                    dt.Columns.Add("PaymentMode", typeof(String));
                    dt.Columns.Add("PaymentDate", typeof(String));
                    dt.Columns.Add("Discount", typeof(float));
                    dt.Columns.Add("Fine", typeof(float));
                    dt.Columns.Add("TotalAmount", typeof(float));
                    dt.Columns.Add("Paid", typeof(float));
                    dt.Columns.Add("Balance", typeof(float));
                    dt.Columns.Add("CollectCode", typeof(String));

                }
                else
                {
                    dt = (DataTable)Session["chkdt"];
                }

                DataRow myRow = dt.NewRow();
                dt.Rows.InsertAt(myRow, dt.Rows.Count);
                if (Convert.ToInt32(dt.Rows.Count) == 1)
                {
                    i = 0;
                }
                else
                {
                    i = dt.Rows.Count - 1;
                }
                Session["chkdt"] = dt;

                myRow = dt.Rows[i];
                myRow["Id"] = lblIdAuto.Text;
                myRow["StudentName"] = lblStudentName.Text;
                myRow["ClassId"] = lblClassId.Text;
                myRow["FeesCode"] = lblFeesCode.Text;
                myRow["FeesType"] = lblFeesType.Text;
                myRow["FeesTypeId"] = lblFeesTypeId.Text;
                myRow["DueDate"] = lblDueDate.Text;
                myRow["Status"] = lblStatus.Text;
                myRow["Amount"] = lblAmount.Text;
                myRow["PaymentCode"] = lblPaymentCode.Text;
                myRow["PaymentMode"] = lblPaymentMode.Text;
                myRow["PaymentDate"] = lblPaymentMode.Text;
                myRow["Discount"] = (lblDiscount.Text);
                myRow["Fine"] = Convert.ToDouble(lblFine.Text);
                myRow["TotalAmount"] = lblTotalAmount.Text;
                myRow["Paid"] = Convert.ToDouble(lblPaid.Text);
                myRow["Balance"] = Convert.ToDouble(lblBalance.Text);
                myRow["CollectCode"] = lblCollectCode.Text;

            }
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedValue != "0")
        {
            LoadStudentListByParam();
        }
        else
        {
            LoadStudentListByParam();
        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSection.SelectedValue != "0")
        {
            LoadStudentListByParam();
        }
        else
        {
            LoadStudentListByParam();
        }
    }
    protected void dddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedValue != "0")
        {
            LoadStudentListByParam();
        }
        else
        {
            LoadStudentListByParam();
        }
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        hfInvoiceNo.Value = "0";
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
        
        Label lblId = (Grow.FindControl("lblId") as Label);
        Label lblClassId = (Grow.FindControl("lblClassId") as Label);
        Label lblFeesTypeId = (Grow.FindControl("lblFeesTypeId") as Label);
       
        try
        {
            string _studentId = lblId.Text.ToString();
            string _classId = lblClassId.Text.ToString();
            string _FeesTypeId = lblFeesTypeId.Text.ToString();
   
            string redirectPage = "";
            string param = "AdmitCardPrint";

            string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
            redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&sId=" + Server.UrlEncode(_studentId) + "&cId=" + Server.UrlEncode(_classId) + "&fId=" + Server.UrlEncode(_FeesTypeId);
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
               "UniqueID", "Popup('" + redirectPage + "');", true);
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }


   }