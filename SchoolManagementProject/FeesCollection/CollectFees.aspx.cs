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

public partial class FeesCollection_CollectFees : System.Web.UI.Page
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
                Session["breadcrumb"] = "Accounts>Collect Fees ";
                BindTableColumns();
                LoadClassList();
                LoadSectionListList();
                pnlSearch.Visible = true;
                LoadPaymodeList();
                LoadDiscountList();


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
    private void LoadPaymodeList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_PayModeListDDL";
        dt = Global.CreateDataTable(sql);

        ddlPayMode.DataSource = dt;
        ddlPayMode.DataTextField = "PayMode";
        ddlPayMode.DataValueField = "Id";
        ddlPayMode.DataBind();


    }
    private void LoadDiscountList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_FeesDiscountListDDL";
        dt = Global.CreateDataTable(sql);

        ddlDiscount.DataSource = dt;
        ddlDiscount.DataTextField = "DisName";
        ddlDiscount.DataValueField = "Id";
        ddlDiscount.DataBind();


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

                cmd.CommandText = @" SELECT  [AutoID] ,[HeaderValue] ,[HeaderText] ,[Order_Priority]FROM [DB_SMP].[dbo].[TB_StudentAdmission_Header] order by Order_Priority ASC";

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
                        if (i < 10)
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

        //int pnl1_ = 0;
        //if (pnl1Columns.Visible == true)
        //{
        //    pnl1Columns.Visible = false;

        //    pnl1_ = 1;
        //}

        //if (pnl1Columns.Visible == false && pnl1_ == 0)
        //{
        //    pnl1Columns.Visible = true;

        //}
        mp1.Show();

    }
    protected void gvStudentAdmissionDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvStudentAdmissionDetailDetail.PageIndex = e.NewPageIndex;

        //if (Session["SortedView"] != null)
        //{
        //    DataTable dataTable = new DataTable();
        //    gvStudentAdmissionDetailDetail.DataSource = (DataView)Session["SortedView"];

        //    int iTotalRecords = ((DataView)(gvStudentAdmissionDetailDetail.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
        //    int iEndRecord = gvStudentAdmissionDetailDetail.PageSize * (gvStudentAdmissionDetailDetail.PageIndex + 1);
        //    int iStartsRecods = iEndRecord - gvStudentAdmissionDetailDetail.PageSize;

        //    if (iEndRecord > iTotalRecords)
        //    {
        //        iEndRecord = iTotalRecords;
        //    }

        //    if (iStartsRecods == 0)
        //    {
        //        iStartsRecods = 1;
        //    }

        //    if (iEndRecord == 0)
        //    {
        //        iEndRecord = iTotalRecords;
        //    }

        //    Label7.Text = "Showing " + iStartsRecods + " to " + iEndRecord.ToString() + " of " + iTotalRecords.ToString() + " entries";
        //    if (gvStudentAdmissionDetailDetail.Rows.Count < 1)
        //    {
        //        gvStudentAdmissionDetailDetail.EmptyDataText = "No Data Found";
        //    }
        //    gvStudentAdmissionDetailDetail.DataBind();
        //}
        //else
        //{
        //    BindStudentAdmissionDetailList_Selected();
        //    if (gvStudentAdmissionDetailDetail.Rows.Count < 1)
        //    {
        //        gvStudentAdmissionDetailDetail.EmptyDataText = "No Data Found";
        //    }
        //    gvStudentAdmissionDetailDetail.DataBind();
        //}

    }
    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridViewRow gvRow = e.Row;
        //if (gvRow.RowType == DataControlRowType.Header)
        //{
        //    GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


        //    TableCell cell0 = new TableCell();
        //    cell0.Text = "Consultants";
        //    cell0.Font.Bold = true;

        //    cell0.HorizontalAlign = HorizontalAlign.Center;
        //    cell0.ColumnSpan = 5;


        //    TableCell cell1 = new TableCell();
        //    cell1.Text = "Nominal_Links (NL)";
        //    //cell0.Font.Size   =  14;
        //    cell1.Font.Bold = true;

        //    cell1.HorizontalAlign = HorizontalAlign.Center;
        //    cell1.ColumnSpan = 7;

        //    TableCell cell2 = new TableCell();
        //    cell2.Text = "Department_Nominal_Links (DNL)";
        //    cell2.Font.Bold = true;

        //    cell2.HorizontalAlign = HorizontalAlign.Center;
        //    cell2.ColumnSpan = 3;



        //    TableCell cell3 = new TableCell();
        //    cell3.Text = "Calculated";
        //    cell3.Font.Bold = true;
        //    cell3.HorizontalAlign = HorizontalAlign.Center;
        //    cell3.ColumnSpan = 2;





        //    gvrow.Cells.Add(cell0);
        //    gvrow.Cells.Add(cell1);
        //    gvrow.Cells.Add(cell2);
        //    gvrow.Cells.Add(cell3);

        //    gvStudentAdmissionDetailDetail.Controls[0].Controls.AddAt(0, gvrow);
        //}
    }
    protected void gvStudentAdmissionDetailDetail_Sorting(object sender, GridViewSortEventArgs e)
    {

        //DataTable dataTable = new DataTable();
        //string sql = "SP_Rpt_StudentAdmissionDetail";
        //dataTable = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlDivisionID.SelectedValue, ddlDepartmentID.SelectedValue.ToString(), ddlConsultant.SelectedValue, ddlConsEmployeeRef.SelectedValue, ddlMatchingConsultantDivison.SelectedValue, ddlMatchingConsultantDept.SelectedValue, Session["UserID"].ToString());


        //if (dataTable != null)
        //{
        //    string SortDir = string.Empty;
        //    if (dir == SortDirection.Ascending)
        //    {
        //        dir = SortDirection.Descending;
        //        SortDir = "Desc";
        //    }
        //    else
        //    {
        //        dir = SortDirection.Ascending;
        //        SortDir = "Asc";
        //    }
        //    DataView sortedView = new DataView(dataTable);
        //    sortedView.Sort = e.SortExpression + " " + SortDir;
        //    Session["SortedView"] = sortedView;
        //    gvStudentAdmissionDetailDetail.DataSource = sortedView;
        //    if (gvStudentAdmissionDetailDetail.Rows.Count < 1)
        //    {
        //        gvStudentAdmissionDetailDetail.EmptyDataText = "No Data Found";
        //    }
        //    gvStudentAdmissionDetailDetail.DataBind();
        //}
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
    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "SP_Rpt_StudentAdmissionDetail";
        //    dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlDivisionID.SelectedValue, ddlDepartmentID.SelectedValue.ToString(), ddlConsultant.SelectedValue, ddlConsEmployeeRef.SelectedValue, ddlMatchingConsultantDivison.SelectedValue, ddlMatchingConsultantDept.SelectedValue, Session["UserID"].ToString());


        //}

        //catch (Exception ex)
        //{
        //    Response.Write("Oops! error occured:" + ex.Message.ToString());
        //}
        //finally
        //{

        //}
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
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        try
        {
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            dt = null;
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView1.Columns.Clear();


            foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
            {

                if (item.Selected)
                {

                    BoundField b = new BoundField();

                    b.DataField = item.Value;
                    b.HeaderText = item.Text;
                    if (item.Value != "Images")
                    {
                        dt2.Columns.Add(item.Value);
                        GridView1.Columns.Add(b);
                    }

                }

            }

            string sql = "SP_TB_StudentAdmissionListDetail";
            dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue);
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                var row = dt.Rows[k];
                dt2.ImportRow(row);

            }
            for (int j = 0; j < chkFields.Items.Count; j++)
            {

                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    string cName = dt2.Columns[i].ColumnName.ToString();
                    string cnkValue = chkFields.Items[j].Value;   // item.Value;
                    string cnkName = chkFields.Items[j].Text;

                    if (cName == cnkValue)
                    {
                        dt2.Columns[i].ColumnName = cnkName;
                        break;
                    }

                }

            }

            string FileName = "Studentlist_(" + DateTime.Now.ToString("MM-dd-yyyy-HH:mm:ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();

                var ws = wb.Worksheets.Add(dt2, "Studentlist");

                var CNN = 0; //Credit Note Net 

                var CNN_co = 0;
                var CNN_ro = 1;

                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    string Credit_Note_Net = dt2.Columns[i].ColumnName.ToString();
                    if (Credit_Note_Net == "Credit Note Net")
                    {
                        CNN = 1;
                        CNN_co = i + 1;
                    }

                }

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (CNN == 1)
                    {
                        ws.Cell(++CNN_ro, CNN_co).Value = dt2.Rows[i]["Credit Note Net"].ToString();
                        ws.Cell(CNN_ro, CNN_co).Style.NumberFormat.Format = "0.00";
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

                //Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception Ex)
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
    protected void btnprint_Click(object sender, EventArgs e)
    {
        BindList();


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
    private void BindList()
    {
        try
        {

            string sql = "SP_TB_StudentAdmissionListDetail";

            DataTable dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue);
            gvStudentAdmissionDetail.DataSource = dt;
            int iTotalRecords = ((DataTable)(gvStudentAdmissionDetail.DataSource)).Rows.Count;
            Session["iTotalRecords"] = iTotalRecords;
            int iEndRecord = gvStudentAdmissionDetail.PageSize * (gvStudentAdmissionDetail.PageIndex + 1);

            int iStartsRecods = iEndRecord - gvStudentAdmissionDetail.PageSize;

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
            if (gvStudentAdmissionDetail.Rows.Count < 1)
            {
                gvStudentAdmissionDetail.EmptyDataText = "No Data Found";
            }

            foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
            {



                //BoundField b = new BoundField();
                //b.DataField = item.Value;
                //b.HeaderText = item.Text;
                //b.SortExpression = item.Value;
                if (item.Value == "FirstName")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[2].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[2].Visible = false;
                    }

                }




                if (item.Value == "LastName")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[3].Visible = true;
                    }
                    else
                    {

                        gvStudentAdmissionDetail.Columns[3].Visible = false;
                    }
                }

                if (item.Value == "Gender")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[4].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[4].Visible = false;
                    }
                }

                if (item.Value == "DOB")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[5].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[5].Visible = false;
                    }
                }


                if (item.Value == "BirthCertificate")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[6].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[6].Visible = false;

                    }
                }


                if (item.Value == "Religion")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[7].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[7].Visible = false;

                    }
                }


                if (item.Value == "BloodGroup")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[8].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[8].Visible = false;
                    }
                }


                if (item.Value == "Category")
                {

                    gvStudentAdmissionDetail.Columns[9].Visible = true;
                }
                if (item.Value == "IdCardNo")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[10].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[10].Visible = false;

                    }
                }

                if (item.Value == "ClassName")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[11].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[11].Visible = false;

                    }
                }


                if (item.Value == "SectionName")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[12].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[12].Visible = false;
                    }
                }


                if (item.Value == "RollNo")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[13].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[13].Visible = false;

                    }
                }

                if (item.Value == "Email")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[14].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[14].Visible = false;

                    }
                }

                if (item.Value == "PresentAddress")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[15].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[15].Visible = false;

                    }
                }

                if (item.Value == "PermanentAddress")
                {
                    if (item.Selected)
                    {


                        gvStudentAdmissionDetail.Columns[16].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[16].Visible = false;
                    }
                }

                if (item.Value == "MobileNo")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[17].Visible = true;
                    }
                    else

                    {
                        gvStudentAdmissionDetail.Columns[17].Visible = false;
                    }
                }


                if (item.Value == "FatherName")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[18].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[18].Visible = false;

                    }
                }

                if (item.Value == "FatherPhoneNo")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[19].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[19].Visible = false;

                    }
                }

                if (item.Value == "FatherOccupation")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[20].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[20].Visible = false;
                    }
                }


                if (item.Value == "MotherName")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[21].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[21].Visible = false;

                    }
                }

                if (item.Value == "MotherPhoneNo")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[22].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[22].Visible = false;
                    }
                }

                if (item.Value == "MotherOccupation")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[23].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[23].Visible = false;
                    }
                }
                if (item.Value == "GuardianName")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[24].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[24].Visible = false;
                    }
                }
                if (item.Value == "GuardianPhoneNo")
                {
                    if (item.Selected)
                    {
                        gvStudentAdmissionDetail.Columns[25].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[25].Visible = false;

                    }
                }
                if (item.Value == "GuardianOccupation")
                {
                    if (item.Selected)
                    {

                        gvStudentAdmissionDetail.Columns[26].Visible = true;
                    }
                    else
                    {
                        gvStudentAdmissionDetail.Columns[26].Visible = false;

                    }
                }

            }




            gvStudentAdmissionDetail.DataBind();

        }

        catch (Exception ex)
        {
            Response.Write("Oops! error occured:" + ex.Message.ToString());
        }
        finally
        {


        }



    }
    protected void gvStudentAdmissionDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Images"]);
            (e.Row.FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;
        }


    }
    protected void gvStudentWiseFeesCollectionDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }
    protected void gvStudentAdmissionDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //string Id = gvStudentAdmissionDetail.DataKeys[e.RowIndex].Value.ToString();
        //entity.Id = Convert.ToInt32(Id);
        ////int success = oUserBLL.User_Delete(Id);
        //int success = oStudentAdmissionBLL.StudentAdmission_Delete(entity);

        //if (success > 0)
        //{
        //    BindList();
        //}
    }
    protected void gvStudentAdmissionDetail_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //e.Cancel = true;
        //Clear();
        //GetSelectedData(e);
        //tContUser.ActiveTabIndex = 1;
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        Session["StudentFeesDetail"] = null;
        int pnl1_ = 0;
        if (pnlProfileView.Visible == true)
        {
            pnlProfileView.Visible = false;
            pnlSearch.Visible = false;

            pnl1_ = 1;
        }

        if (pnlProfileView.Visible == false && pnl1_ == 0)
        {
            pnlProfileView.Visible = true;
            pnlSearch.Visible = false;

        }

        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;

        byte[] bytes = (byte[])GetData("SELECT [Id],[Images] FROM TB_StudentAdmission WHERE Id =" + lnkUserID.CommandArgument).Rows[0]["Images"];

        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        ProfileImage1.ImageUrl = "data:image/png;base64," + base64String;
        DataTable dt = new DataTable();
        StudentAdmissionBOL oStudentAdmissionBOL = new StudentAdmissionBOL();

        oStudentAdmissionBOL.Id = Convert.ToInt32(lnkUserID.CommandArgument);

        dt = oStudentAdmissionBLL.StudentAdmission_GetById(oStudentAdmissionBOL);
        if (dt.Rows.Count > 0)
        {
            lblStudentName.Text = dt.Rows[0]["FullName"].ToString();
            lblICardNo.Text = dt.Rows[0]["IdCardNo"].ToString();
            lblRollNo.Text = dt.Rows[0]["RollNo"].ToString();
            LblClass.Text = dt.Rows[0]["ClassName"].ToString() + "(" + dt.Rows[0]["SectionName"].ToString() + ")";
            LblCategory.Text = dt.Rows[0]["Category"].ToString();
            lblBloodGrp.Text = dt.Rows[0]["BloodGroup"].ToString();
            lblMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            lblDOB.Text = dt.Rows[0]["DOB"].ToString();
            //lblBirthCertificate.Text = dt.Rows[0]["BirthCertificate"].ToString();
            lblFatherName.Text = dt.Rows[0]["FatherName"].ToString();
            lblFatherPhoneNo.Text = dt.Rows[0]["FatherPhoneNo"].ToString();
            //lblFatherOccupation.Text = dt.Rows[0]["FatherOccupation"].ToString();
            lblMotherName.Text = dt.Rows[0]["MotherName"].ToString();
            lblMotherFhone.Text = dt.Rows[0]["MotherPhoneNo"].ToString();
            hfStId.Value = dt.Rows[0]["Id"].ToString();
            //lblMotherOccupation.Text = dt.Rows[0]["MotherOccupation"].ToString();
            //lblGuardianName.Text = dt.Rows[0]["GuardianName"].ToString();
            //lblGuardianPhone.Text = dt.Rows[0]["GuardianPhoneNo"].ToString();
            //lblGuardianOccupation.Text = dt.Rows[0]["GuardianOccupation"].ToString();
            //lblEmail.Text = dt.Rows[0]["Email"].ToString();
            //lblPresentAddress.Text = dt.Rows[0]["PresentAddress"].ToString();
            //lblPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
        }

        DataTable dt2 = new DataTable();
        string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
        dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, lnkUserID.CommandArgument, "0", "0");
        if (dt2.Rows.Count > 0)
        {
            gvStudentWiseFeesCollectionDetail.DataSource = dt2;
            gvStudentWiseFeesCollectionDetail.DataBind();
            Session["StudentFeesDetail"] = dt2;
            Session["chkdt"] = dt2;
        }
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
    protected void btnBack_Click(object sender, EventArgs e)
    {

        if (pnlProfileView.Visible == true)
        {
            pnlProfileView.Visible = false;
            pnlSearch.Visible = true;


        }


    }
    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
    protected void lnkFeesCollect_Click(object sender, EventArgs e)
    {


        lblFeesCollection.Text = "";
        txtAmount.Text = "";
        txtFine.Text = "";
        txtTotal.Text = "";
        txtPaid.Text = "";
        ddlDiscount.SelectedValue = "0";
        ddlDiscount.Enabled = false;
        ddlPayMode.SelectedValue = "0";
        txtNote.Text = "";
        txtPaid.Enabled = true ;
        txtTotal.Enabled = true;
        txtFine.Enabled = true;
        txtAmount.Enabled = true;
        hfInvoiceNo.Value = "0";
       
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
        Label lblClassId = (Grow.FindControl("lblClassId") as Label);
        Label lblFeesTypeId = (Grow.FindControl("lblFeesTypeId") as Label);
        Label lblStudentId = (Grow.FindControl("Id") as Label);
        mpFeesCollect.Show();
        DataTable dt2 = new DataTable();
       
            string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
            dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, lnkUserID.CommandArgument, lblClassId.Text, lblFeesTypeId.Text);


            if (dt2.Rows.Count > 0)
            {
                lblFeesCollection.Text = dt2.Rows[0]["CollectCode"].ToString();
                txtAmount.Text = dt2.Rows[0]["Amount"].ToString();
                txtFine.Text = dt2.Rows[0]["Fine"].ToString();
                hfStudentId.Value = dt2.Rows[0]["Id"].ToString();
                hfClassId.Value = dt2.Rows[0]["ClassId"].ToString();
                hfFeesTypeId.Value = dt2.Rows[0]["FeesTypeId"].ToString();
                double _amt = Convert.ToDouble(dt2.Rows[0]["Amount"].ToString()) + Convert.ToDouble(dt2.Rows[0]["Fine"].ToString());
                txtTotal.Text = Convert.ToString(_amt);
                txtPaid.Text = dt2.Rows[0]["Paid"].ToString();
                txtDate.Text = dt2.Rows[0]["PaymentDate"].ToString();

                hfInvoiceNo.Value = dt2.Rows[0]["PaymentCode"].ToString();
                if (dt2.Rows[0]["PayModeId"].ToString() == "")
                {
                    ddlPayMode.SelectedValue = "0";

                }
                else
                {
                    ddlPayMode.SelectedValue = dt2.Rows[0]["PayModeId"].ToString();
                }
                txtNote.Text = dt2.Rows[0]["Note"].ToString();
                hfAutoId.Value = dt2.Rows[0]["PayAutoId"].ToString();


            }
        
        
       
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        hfInvoiceNo.Value = "0";
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;
        Label lblClassId = (Grow.FindControl("lblClassId") as Label);
        Label lblFeesTypeId = (Grow.FindControl("lblFeesTypeId") as Label);
       
        DataTable dt2 = new DataTable();
        string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
        dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, lnkUserID.CommandArgument, lblClassId.Text, lblFeesTypeId.Text);
        if (dt2.Rows.Count > 0)
        {
            lblFeesCollection.Text = dt2.Rows[0]["CollectCode"].ToString();
            txtAmount.Text = dt2.Rows[0]["Amount"].ToString();
            txtFine.Text = dt2.Rows[0]["Fine"].ToString();
            hfStudentId.Value = dt2.Rows[0]["Id"].ToString();
            hfClassId.Value = dt2.Rows[0]["ClassId"].ToString();
            hfFeesTypeId.Value = dt2.Rows[0]["FeesTypeId"].ToString();
            double _amt = Convert.ToDouble(dt2.Rows[0]["Amount"].ToString()) + Convert.ToDouble(dt2.Rows[0]["Fine"].ToString());
            txtTotal.Text = Convert.ToString(_amt);
            txtPaid.Text = dt2.Rows[0]["Paid"].ToString();
            txtDate.Text = dt2.Rows[0]["PaymentDate"].ToString();

            hfInvoiceNo.Value = dt2.Rows[0]["PaymentCode"].ToString();
            if (dt2.Rows[0]["PayModeId"].ToString() == "")
            {
                ddlPayMode.SelectedValue = "0";

            }
            else
            {
                ddlPayMode.SelectedValue = dt2.Rows[0]["PayModeId"].ToString();
            }
            txtNote.Text = dt2.Rows[0]["Note"].ToString();
            hfAutoId.Value = dt2.Rows[0]["PayAutoId"].ToString();

            try
            {
                string _Id = dt2.Rows[0]["Id"].ToString();
                double _Amt = Convert.ToDouble(dt2.Rows[0]["Paid"].ToString());
                string _Amount = _Amt.ToString();
                string _ClassId = dt2.Rows[0]["ClassId"].ToString();
                string _FeesTypeId = dt2.Rows[0]["FeesTypeId"].ToString();
                string _PaymentCode = dt2.Rows[0]["PaymentCode"].ToString();
                string redirectPage = "";

                string param = "FeesCollectPrint";

                string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount) + "&CId=" + Server.UrlEncode(_ClassId) + "&FTId=" + Server.UrlEncode(_FeesTypeId) + "&PC=" + Server.UrlEncode(_PaymentCode);
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                   "UniqueID", "Popup('" + redirectPage + "');", true);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
    protected void txtSearchBox_TextChanged(object sender, EventArgs e)
    {
        txtAmount.Text = "500";
        mpFeesCollect.Show();

    }
    protected void btnFeesCollect_Click(object sender, EventArgs e)
    {
        Session["chkdt"] = null;
        Headerchk();

        if (txtFine.Text == "")
        {

            txtFine.Text = "0.00";
        }
        if (txtDiscount.Text == "")
        {
            txtDiscount.Text = "0.00";
        }

        if (Session["chkdt"] == null)
        {
           
            SaveOnly();
        }
        else 
        {
            SelectedSave();
        }
        
        
    }
    private void SaveSavePrint()
    {

        CollectFeesBOL entity = new CollectFeesBOL();

        entity.InvoiceNo = "10002";

        if (txtDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.Date = JoiningDate;
        }
        else
        {
            entity.Date = Convert.ToDateTime("01/01/1991");

        }
        if (txtDiscount.Text == "")
        {
            txtDiscount.Text = "0.00";
        }
        double Amt = Convert.ToDouble(txtPaid.Text);
        entity.Amount = Amt;
        entity.DisCountId = Convert.ToInt32(ddlDiscount.SelectedValue);
        entity.PayModeId = Convert.ToInt32(ddlPayMode.SelectedValue);

        entity.DisCount = Convert.ToDouble(txtDiscount.Text);
        double Fine = Convert.ToDouble(txtFine.Text);
        entity.Fine = Fine;
        double DisCount = Convert.ToDouble(txtDiscount.Text);
        double Total = Convert.ToDouble(Amt) + Convert.ToDouble(DisCount);
        entity.Total = Total;
        entity.Note = txtNote.Text;
        entity.StudentId = Convert.ToInt32(hfStudentId.Value);
        entity.ClassId = Convert.ToInt32(hfClassId.Value);
        entity.FeesTypeId = Convert.ToInt32(hfFeesTypeId.Value);
        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfInvoiceNo.Value) || hfInvoiceNo.Value == "0")
        {



            //Save record
            Id = oCollectFeesBLL.CollectFees_Add(entity);
            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                DataTable dt2 = new DataTable();
                string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
                dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStudentId.Value, "0", "0");
                if (dt2.Rows.Count > 0)
                {
                    gvStudentWiseFeesCollectionDetail.DataSource = dt2;
                    gvStudentWiseFeesCollectionDetail.DataBind();
                    txtDate.Text = "";
                    txtAmount.Text = "";
                    txtDiscount.Text = "";
                    txtNote.Text = "";
                    txtFine.Text = "";
                    ddlDiscount.SelectedValue = "0";
                    ddlPayMode.SelectedValue = "0";
                    hfInvoiceNo.Value = "0";
                }


                try
                {
                    string _Id = dt2.Rows[0]["Id"].ToString();
                    double _Amt = Convert.ToDouble(dt2.Rows[0]["Paid"].ToString());
                    string _Amount = _Amt.ToString();
                    string _ClassId = dt2.Rows[0]["ClassId"].ToString();
                    string _FeesTypeId = dt2.Rows[0]["FeesTypeId"].ToString();
                    string  _PaymentCode = dt2.Rows[0]["PaymentCode"].ToString();
                    string redirectPage = "";

                    string param = "FeesCollectPrint";

                    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount) + "&CId=" + Server.UrlEncode(_ClassId) + "&FTId=" + Server.UrlEncode(_FeesTypeId) + "&PC=" + Server.UrlEncode(_PaymentCode);
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                       "UniqueID", "Popup('" + redirectPage + "');", true);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }
        else
        {
            //Update record          
            entity.Id = Convert.ToInt32(hfAutoId.Value);
            entity.InvoiceNo = hfInvoiceNo.Value;
            Id = oCollectFeesBLL.CollectFees_Update(entity);

            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                DataTable dt2 = new DataTable();
                string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
                dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStudentId.Value, "0", "0");
                if (dt2.Rows.Count > 0)
                {
                    gvStudentWiseFeesCollectionDetail.DataSource = dt2;
                    gvStudentWiseFeesCollectionDetail.DataBind();
                    txtDate.Text = "";
                    txtAmount.Text = "";
                    txtDiscount.Text = "";
                    txtNote.Text = "";
                    txtFine.Text = "";
                    ddlDiscount.SelectedValue = "0";
                    ddlPayMode.SelectedValue = "0";
                    hfInvoiceNo.Value = "0";
                    hfAutoId.Value = "0";
                }
                try
                {
                    string _Id = dt2.Rows[0]["Id"].ToString();
                    double _Amt = Convert.ToDouble(dt2.Rows[0]["Paid"].ToString());
                    string _Amount = _Amt.ToString();
                   
                    string _ClassId = dt2.Rows[0]["ClassId"].ToString();
                    string _FeesTypeId = dt2.Rows[0]["FeesTypeId"].ToString();
                    string _PaymentCode = dt2.Rows[0]["PaymentCode"].ToString();
                    string redirectPage = "";

                    string param = "FeesCollectPrint";

                    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount) + "&CId=" + Server.UrlEncode(_ClassId) + "&FTId=" + Server.UrlEncode(_FeesTypeId) + "&PC=" + Server.UrlEncode(_PaymentCode);
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                       "UniqueID", "Popup('" + redirectPage + "');", true);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }
    }
    private void SaveOnly()
    {

        CollectFeesBOL entity = new CollectFeesBOL();

        entity.InvoiceNo = "10002";

        if (txtDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.Date = JoiningDate;
        }
        else
        {
            entity.Date = Convert.ToDateTime("01/01/1991");

        }
        double Amt = Convert.ToDouble(txtPaid.Text);
        entity.Amount = Amt;
        entity.DisCountId = Convert.ToInt32(ddlDiscount.SelectedValue);
        entity.PayModeId = Convert.ToInt32(ddlPayMode.SelectedValue);

        if (txtDiscount.Text == "")
        {
            txtDiscount.Text = "0.00";
        }
        entity.DisCount = Convert.ToDouble(txtDiscount.Text);
        double Fine = Convert.ToDouble(txtFine.Text);
        entity.Fine = Fine;
        double DisCount = Convert.ToDouble(txtDiscount.Text);
        double Total = Convert.ToDouble(Amt) + Convert.ToDouble(DisCount);
        entity.Total = Total;
        entity.Note = txtNote.Text;
        entity.StudentId = Convert.ToInt32(hfStudentId.Value);
        entity.ClassId = Convert.ToInt32(hfClassId.Value);
        entity.FeesTypeId = Convert.ToInt32(hfFeesTypeId.Value);
        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfInvoiceNo.Value) || hfInvoiceNo.Value == "0")
        {



            //Save record
            Id = oCollectFeesBLL.CollectFees_Add(entity);
            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                DataTable dt2 = new DataTable();
                string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
                dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStudentId.Value, "0", "0");
                if (dt2.Rows.Count > 0)
                {
                    gvStudentWiseFeesCollectionDetail.DataSource = dt2;
                    gvStudentWiseFeesCollectionDetail.DataBind();
                    txtDate.Text = "";
                    txtAmount.Text = "";
                    txtDiscount.Text = "";
                    txtNote.Text = "";
                    txtFine.Text = "";
                    ddlDiscount.SelectedValue = "0";
                    ddlPayMode.SelectedValue = "0";
                    hfInvoiceNo.Value = "0";
                }


                //try
                //{
                //    string _Id = dt2.Rows[0]["Id"].ToString();
                //    double _Amt = Convert.ToDouble(dt2.Rows[0]["Paid"].ToString());
                //    string _Amount = _Amt.ToString();
                //    string _ClassId = dt2.Rows[0]["ClassId"].ToString();
                //    string _FeesTypeId = dt2.Rows[0]["FeesTypeId"].ToString();
                //    string _PaymentCode = dt2.Rows[0]["PaymentCode"].ToString();
                //    string redirectPage = "";

                //    string param = "FeesCollectPrint";

                //    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                //    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount) + "&CId=" + Server.UrlEncode(_ClassId) + "&FTId=" + Server.UrlEncode(_FeesTypeId) + "&PC=" + Server.UrlEncode(_PaymentCode);
                //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                //       "UniqueID", "Popup('" + redirectPage + "');", true);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;

                //}
            }
        }
        else
        {
            //Update record          
            entity.Id = Convert.ToInt32(hfAutoId.Value);
            entity.InvoiceNo = hfInvoiceNo.Value;
            Id = oCollectFeesBLL.CollectFees_Update(entity);

            if (Id > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                DataTable dt2 = new DataTable();
                string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
                dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStudentId.Value, "0", "0");
                if (dt2.Rows.Count > 0)
                {
                    gvStudentWiseFeesCollectionDetail.DataSource = dt2;
                    gvStudentWiseFeesCollectionDetail.DataBind();
                    txtDate.Text = "";
                    txtAmount.Text = "";
                    txtDiscount.Text = "";
                    txtNote.Text = "";
                    txtFine.Text = "";
                    ddlDiscount.SelectedValue = "0";
                    ddlPayMode.SelectedValue = "0";
                    hfInvoiceNo.Value = "0";
                    hfAutoId.Value = "0";
                }
                //try
                //{
                //    string _Id = dt2.Rows[0]["Id"].ToString();
                //    double _Amt = Convert.ToDouble(dt2.Rows[0]["Paid"].ToString());
                //    string _Amount = _Amt.ToString();

                //    string _ClassId = dt2.Rows[0]["ClassId"].ToString();
                //    string _FeesTypeId = dt2.Rows[0]["FeesTypeId"].ToString();
                //    string _PaymentCode = dt2.Rows[0]["PaymentCode"].ToString();
                //    string redirectPage = "";

                //    string param = "FeesCollectPrint";

                //    string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
                //    redirectPage = getpath + "ExcelfileReportViewer.aspx?param=" + param + "&Id=" + Server.UrlEncode(_Id) + "&amt=" + Server.UrlEncode(_Amount) + "&CId=" + Server.UrlEncode(_ClassId) + "&FTId=" + Server.UrlEncode(_FeesTypeId) + "&PC=" + Server.UrlEncode(_PaymentCode);
                //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page),
                //       "UniqueID", "Popup('" + redirectPage + "');", true);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;

                //}
            }
        }
    }
    protected void btnCollectPrint_Click(object sender, EventArgs e)
    {
        if (txtFine.Text == "")
        {

            txtFine.Text = "0.00";
        }
        if (txtDiscount.Text == "")
        {
            txtDiscount.Text = "0.00";
        }
        SaveSavePrint();
    }
    protected void btnDownloadPDF_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        //Create a dummy GridView
        GridView GridView1 = new GridView();
        dt = null;
        GridView1.DataSource = null;
        GridView1.DataBind();
        GridView1.Columns.Clear();


        foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
        {

            if (item.Selected)
            {

                BoundField b = new BoundField();

                b.DataField = item.Value;
                b.HeaderText = item.Text;
                if (item.Value != "Images")
                {

                    dt2.Columns.Add(item.Value);
                    GridView1.Columns.Add(b);
                }

            }

        }

        string sql = "SP_TB_StudentAdmissionListDetail";
        dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue);
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            var row = dt.Rows[k];
            dt2.ImportRow(row);

        }
        for (int j = 0; j < chkFields.Items.Count; j++)
        {

            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                string cName = dt2.Columns[i].ColumnName.ToString();
                string cnkValue = chkFields.Items[j].Value;   // item.Value;
                string cnkName = chkFields.Items[j].Text;

                if (cName == cnkValue)
                {
                    dt2.Columns[i].ColumnName = cnkName;
                    break;
                }

            }

        }

        ExportToPdf(dt2,"Student Information", "StudentInformation");
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
            ExportToPdf(dt2,lblStudentName.Text,"FeesDetail");

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
    protected void btnCollectSelected_Click(object sender, EventArgs e)
    {

        Session["chkdt"] = null;
        Headerchk();
        if (Session["chkdt"] == null)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Please Select Item .');", true);
            
            return;
        }
        else
        {
            if (txtFine.Text == "")
            {

                txtFine.Text = "0.00";
            }
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0.00";
            }

            double _tAmount = 0.00;
            double _tTotalAmount = 0.00;
            double _tDisCount = 0.00;
            double _tFine = 0.00;
            DataTable dt = (DataTable)Session["chkdt"];
            foreach (DataRow row in dt.Rows)
            {

                double _Amount = Convert.ToDouble(row["Amount"].ToString());
                _tAmount = _tAmount + _Amount;
                double _Balance = Convert.ToDouble(row["Balance"].ToString());
                double _TotalAmount = Convert.ToDouble(row["TotalAmount"].ToString());

                if (_Balance > 0)
                {
                    _tTotalAmount = _tTotalAmount + _Balance;
                }
                else
                {
                    _tTotalAmount = _tTotalAmount + _TotalAmount;
                }

                double _DisCount = Convert.ToDouble(row["Discount"].ToString());
                _tDisCount = _tDisCount + _DisCount;
                double _Fine = Convert.ToDouble(row["Fine"].ToString());

                _tFine = _tFine + _Fine;



            }


            lblFeesCollection.Text = "Selected Fess Payment";
            txtAmount.Text = _tAmount.ToString();
            txtFine.Text = _tFine.ToString();
            txtTotal.Text = _tTotalAmount.ToString();
            txtPaid.Text= _tTotalAmount.ToString();

            ddlDiscount.SelectedValue = "0";
            ddlPayMode.SelectedValue = "0";
            txtNote.Text = "";
            txtPaid.Enabled = false;
            txtTotal.Enabled = false;
            txtPaid.Font.Bold = true;
            txtFine.Enabled = false;
            txtFine.Font.Bold = true;
            txtAmount.Enabled = false;
            txtAmount.Font.Bold = true;
            mpFeesCollect.Show();
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
    private void SelectedSave()
    {
        CollectFeesBOL entity = new CollectFeesBOL();

        DataTable dt = new DataTable();
        dt = (DataTable)Session["chkdt"];
        Int32 Id = 0;
        foreach (DataRow row in dt.Rows)
        {
            if (txtDate.Text != "")
            {
                DateTime dtpJoiningDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
                entity.Date = JoiningDate;
            }
            else
            {
                entity.Date = Convert.ToDateTime("01/01/1991");

            }
            entity.InvoiceNo = row["PaymentCode"].ToString();
            entity.Amount = Convert.ToDouble(row["Amount"].ToString());
            entity.Total =Convert.ToDouble( row["TotalAmount"].ToString());
            entity.DisCountId = Convert.ToInt32(ddlDiscount.SelectedValue);
            entity.PayModeId = Convert.ToInt32(ddlPayMode.SelectedValue);
            entity.DisCount = Convert.ToDouble(row["Discount"].ToString());
            entity.Fine = Convert.ToDouble(row["Fine"].ToString());
            entity.Note = txtNote.Text;
            entity.StudentId = Convert.ToInt32(row["Id"].ToString());
            entity.ClassId = Convert.ToInt32(row["ClassId"].ToString());
            entity.FeesTypeId = Convert.ToInt32(row["FeesTypeId"].ToString());
            hfInvoiceNo.Value= row["PaymentCode"].ToString();
            if (string.IsNullOrEmpty(hfInvoiceNo.Value) || hfInvoiceNo.Value == "0")
            {
                //Save record
                Id = oCollectFeesBLL.CollectFees_Add(entity);
               
            }
            else
            {
                //Update record          
              // entity.Id = Convert.ToInt32(hfAutoId.Value);
                entity.InvoiceNo = hfInvoiceNo.Value;
                Id = oCollectFeesBLL.CollectFees_Update(entity);

            }
        }
        if (Id > 0)
        {
            string myScript123 = "";
            myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

            DataTable dt2 = new DataTable();
            string sql = "SP_TB_StudentWiseFeesCollectionDetailById";
            dt2 = Global.CreateDataTableParameter_StudentWiseFeesCollectionDetail(sql, hfStudentId.Value, "0", "0");
            if (dt2.Rows.Count > 0)
            {
                gvStudentWiseFeesCollectionDetail.DataSource = dt2;
                gvStudentWiseFeesCollectionDetail.DataBind();
                txtDate.Text = "";
                txtAmount.Text = "";
                txtDiscount.Text = "";
                txtNote.Text = "";
                txtFine.Text = "";
                ddlDiscount.SelectedValue = "0";
                ddlPayMode.SelectedValue = "0";
                hfInvoiceNo.Value = "0";
            }

        }
    }

}


