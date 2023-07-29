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

public partial class FeesCollection_FeesCarryForward : System.Web.UI.Page
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
                Session["iTotalRecords"] = 0;
                Session["PageLink"] = "Sage Reports";
                Session["breadcrumb"] = "Accounts > Fees Carry Forward";
              
                LoadClassList();
                LoadSectionListList();
                pnlSearch.Visible = true;
                btnSave.Visible = false;


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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    private void Save()
    {

        CollectFeesBOL entity = new CollectFeesBOL();

        foreach (GridViewRow row in gvStudentAdmissionDetail.Rows)
        {
         
            Label  lblstudentId = (Label)row.FindControl("lblAutoID");
            Label lblClassId = (Label)row.FindControl("lblClassId");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            entity.Id = Convert.ToInt32(lblstudentId.Text);
            entity.StudentId = Convert.ToInt32(lblstudentId.Text);
            entity.ClassId = Convert.ToInt32(lblClassId.Text);
            entity.Amount = Convert.ToDouble(txtAmount.Text);

            Int32 Id = 0;
          
                //Save record
                Id = oCollectFeesBLL.CollectFees_FeesCarryForward(entity);
                if (Id > 0)
                {
                    string myScript123 = "";
                    myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                BindList();
            }
          
        }
      
    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        BindList();


    }
    private void BindList()
    {

        btnSave.Visible = true;
        try
        {

            string sql = "SP_TB_StudentAdmissionListDetail";


            DataTable dt = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue);

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

            string sql = "SP_TB_StudentFeesCaryForwardExportToExcel";
             dt2 = Global.CreateDataTableParameterStudentAdmissionDetail(sql, ddlClass.SelectedValue, ddlSection.SelectedValue);

            // dt2 = (DataTable)Session["Dt"];
            string FileName = "FeesCarryForwardList_(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";
            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "FeesCarryForwardList");

                var TJan = 0;  //Total Invoice January
                var TJan_co = 0;
                var TJan_ro = 1;


                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    string ColumnName = dt2.Columns[i].ColumnName.ToString();

                    if (ColumnName == "Amount")
                    {
                        TJan = 1;
                        TJan_co = i + 1;
                    }

                }

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (TJan == 1)
                    {
                        ws.Cell(++TJan_ro, TJan_co).Value = dt2.Rows[i]["Amount"].ToString();
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


}