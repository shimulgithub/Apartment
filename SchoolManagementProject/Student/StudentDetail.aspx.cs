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

public partial class Student_StudentDetail : System.Web.UI.Page
{
    string _connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
    public string UploadFolderPath = "~/images/defalt.jpg";
    StudentAdmissionBLL oStudentAdmissionBLL = new StudentAdmissionBLL();
    StudentAdmissionBOL entity = new StudentAdmissionBOL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!Page.IsPostBack)
            {
                Session["SortedView"] = null;
                Session["iTotalRecords"] = 0;
                Session["PageLink"] = "Sage Reports";
                BindTableColumns();

                LoadClassList();
                LoadSectionListList();
                pnlSearch.Visible = true;


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
        //DataTable dt = new DataTable(" StudentAdmissionDetail");
        //DataTable dt2 = new DataTable();

        //try
        //{
        //    GridView GridView1 = new GridView();
        //    dt = null;
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    GridView1.Columns.Clear();
        //    string sql = "SP_Rpt_StudentAdmissionDetail";

        //    dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlDivisionID.SelectedValue, ddlDepartmentID.SelectedValue.ToString(), ddlConsultant.SelectedValue, ddlConsEmployeeRef.SelectedValue, ddlMatchingConsultantDivison.SelectedValue, ddlMatchingConsultantDept.SelectedValue, Session["UserID"].ToString());


        //    foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            BoundField b = new BoundField();
        //            b.DataField = item.Value;
        //            b.HeaderText = item.Text;
        //            GridView1.Columns.Add(b);
        //            dt2.Columns.Add(item.Value);
        //        }
        //    }
        //    for (int k = 0; k < dt.Rows.Count; k++)
        //    {
        //        var row = dt.Rows[k];
        //        dt2.ImportRow(row);

        //    }
        //    for (int j = 0; j < chkFields.Items.Count; j++)
        //    {

        //        for (int i = 0; i < dt2.Columns.Count; i++)
        //        {
        //            string cName = dt2.Columns[i].ColumnName.ToString();
        //            string cnkValue = chkFields.Items[j].Value;   // item.Value;
        //            string cnkName = chkFields.Items[j].Text;

        //            if (cName == cnkValue)
        //            {
        //                dt2.Columns[i].ColumnName = cnkName;
        //                break;
        //            }

        //        }
        //    }
        //    string FileName = " StudentAdmissionDetail(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
        //    try
        //    {
        //        var wb = new ClosedXML.Excel.XLWorkbook();
        //        var ws = wb.Worksheets.Add(dt2, " StudentAdmissionDetail");


        //        Response.Clear();
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;filename=\"" + FileName + "\"");

        //        using (var ms = new System.IO.MemoryStream())
        //        {
        //            wb.SaveAs(ms);
        //            ms.WriteTo(Response.OutputStream);
        //            ms.Close();
        //        }

        //        HttpContext.Current.ApplicationInstance.CompleteRequest();
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    finally
        //    {
        //        dt = null;
        //        dt2 = null;
        //    }
        //}

        //catch (Exception ex)
        //{
        //    Response.Write("Oops! error occured:" + ex.Message.ToString());
        //}
        //finally
        //{
        //    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
        //    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
        //    HttpContext.Current.Response.End();

        //}
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
        try { 
       
            string sql = "SP_TB_StudentAdmissionListDetail";


              DataTable dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue,ddlSection.SelectedValue);

           //  dt = oStudentAdmissionBLL.StudentAdmission_GetDataForGV();

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
            (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
        }


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
            LblClass.Text= dt.Rows[0]["ClassName"].ToString();
            LblSection.Text = dt.Rows[0]["SectionName"].ToString();
            lblBloodGrp.Text = dt.Rows[0]["BloodGroup"].ToString();
            lblMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            lblDOB.Text = dt.Rows[0]["DOB"].ToString();
            lblBirthCertificate.Text = dt.Rows[0]["BirthCertificate"].ToString();
            lblFatherName.Text = dt.Rows[0]["FatherName"].ToString();
            lblFatherPhoneNo.Text = dt.Rows[0]["FatherPhoneNo"].ToString();
            lblFatherOccupation.Text = dt.Rows[0]["FatherOccupation"].ToString();
            lblMotherName.Text = dt.Rows[0]["MotherName"].ToString();
            lblMotherFhone.Text= dt.Rows[0]["MotherPhoneNo"].ToString();
            lblMotherOccupation.Text = dt.Rows[0]["MotherOccupation"].ToString();
            lblGuardianName.Text = dt.Rows[0]["GuardianName"].ToString();
            lblGuardianPhone.Text= dt.Rows[0]["GuardianPhoneNo"].ToString();
            lblGuardianOccupation.Text = dt.Rows[0]["GuardianOccupation"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblPresentAddress.Text= dt.Rows[0]["PresentAddress"].ToString();
            lblPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
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

}