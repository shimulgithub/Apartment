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

public partial class FeesCollection_FeesMaster : System.Web.UI.Page
{
    FeesMasterBLL oFeesMasterBLL = new FeesMasterBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Fees Master";
                Clear();
                BindList();
                LoadClassList();
                LoadFeesTypeList();

            }
            // this.RegisterPostBackControl();
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
    
    //SP_FeesTypeListDDL
    private void BindList()
    {
        DataTable dt = oFeesMasterBLL.FeesMaster_GetDataForGV();
        gvFeesMasterInfoList.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvFeesMasterInfoList.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvFeesMasterInfoList.PageSize * (gvFeesMasterInfoList.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvFeesMasterInfoList.PageSize;

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

        if (gvFeesMasterInfoList.Rows.Count < 1)
        {
            gvFeesMasterInfoList.EmptyDataText = "No Data Found";
        }

        gvFeesMasterInfoList.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        if (ddlClass.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Class.');", true);

            ddlClass.Focus();
            return;
        }
        if (ddlFeesType.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Fees Type.');", true);
            ddlFeesType.Focus();
            return;
        }
        if(txtDueDate.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Select Due Date.');", true);

            txtDueDate.Focus();
            return;
        }
        if (txtTotalAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter Total Amount.');", true);

            txtTotalAmount.Focus();
            return;
        }


        Save();




    }
  
    protected void txtPercentage_TextChanged(object sender, EventArgs e)
    {
        if (txtPercentage.Text == "")
        {
            txtPercentage.Text = "0";


        }
        int TotalAmount = Convert.ToInt32(txtAmount.Text) * Convert.ToInt32(txtPercentage.Text) / 100 + Convert.ToInt32(txtAmount.Text);
        txtTotalAmount.Text = TotalAmount.ToString();


    }
    protected void txtFixedAmount_TextChanged(object sender, EventArgs e)
    {
        int TotalAmount = Convert.ToInt32(txtFixedAmount.Text) + Convert.ToInt32(txtAmount.Text);
        txtTotalAmount.Text = TotalAmount.ToString();
    }
    protected void rdNone_CheckedChanged(object sender, System.EventArgs e)
    {
        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter fees amount.');", true);
       
            txtAmount.Focus();
            rdPercentage.Checked = false;
            rdFixAmount.Checked = false;
            return;
        }
        if (rdNone.Checked == true)
        {
            txtTotalAmount.Text = txtAmount.Text;
            txtPercentage.Enabled = false;
            txtFixedAmount.Enabled = false;
            rdPercentage.Checked = false;
            rdFixAmount.Checked = false;
            txtPercentage.Text = "";
            txtFixedAmount.Text = "";

        }
      
    }
    protected void rdPercentage_CheckedChanged(object sender, System.EventArgs e)
    {
        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter fees amount.');", true);

            txtAmount.Focus();
            rdFixAmount.Checked = false;
            rdNone.Checked = false;
            return;
        }
        if (rdPercentage.Checked == true)
        {
            txtFixedAmount.Enabled = false;
            txtPercentage.Enabled = true;
            rdFixAmount.Checked = false;
            rdNone.Checked = false;
            txtFixedAmount.Text = "";
            txtTotalAmount.Text = txtAmount.Text;

        }

    }
    protected void rdFixAmount_CheckedChanged(object sender, System.EventArgs e)
    {
      

        if (txtAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Enter fees amount.');", true);

            txtAmount.Focus();
            rdNone.Checked = false;
            rdPercentage.Checked = false;
            return;
        }
        if (rdFixAmount.Checked == true)
        {
        
            txtPercentage.Enabled = false;
            txtFixedAmount.Enabled = true;
            rdNone.Checked = false;
            rdPercentage.Checked = false;
            txtPercentage.Text = "";
            txtTotalAmount.Text = txtAmount.Text;
        }
    }
    private void Save()
    {

        FeesMasterBOL entity = new FeesMasterBOL();

         entity.ClassId =Convert.ToInt32(ddlClass.SelectedValue);
         entity.FeesTypeId = Convert.ToInt32(ddlFeesType.SelectedValue);
         
        if (txtDueDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.DueDate = JoiningDate;
        }
        else
        {
            entity.DueDate = Convert.ToDateTime("01/01/1991");

        }
        entity.Amount = Convert.ToInt32(txtAmount.Text);
        if (txtPercentage.Text == "")
        {
            
            entity.FinePercentage = 0;
        }
        else
        {
            entity.FinePercentage = Convert.ToInt32(txtPercentage.Text);
        }
        


        entity.TotalAmount = Convert.ToInt32(txtTotalAmount.Text);
        if (txtFixedAmount.Text == "")
        {
            if (txtPercentage.Text == "")
            {
                txtPercentage.Text = "0";
            }
          int fineAmopunt=  Convert.ToInt32(txtAmount.Text) * Convert.ToInt32(txtPercentage.Text) / 100;
            entity.FineAmount = fineAmopunt;


        }
        else
        {
            entity.FineAmount = Convert.ToInt32(txtFixedAmount.Text);
        }

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {

            entity.CreateBy = Session["UserID"].ToString();

            //Save record
            Id = oFeesMasterBLL.FeesMaster_Add(entity);
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
            entity.ChangedBy = Session["UserID"].ToString();

            Id = oFeesMasterBLL.FeesMaster_Update(entity);

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
    protected void gvFeesMasterInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvFeesMasterInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        FeesMasterBOL entity = new FeesMasterBOL();
        Int32 Id = Convert.ToInt32(gvFeesMasterInfoList.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oFeesMasterBLL.FeesMaster_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvFeesMasterInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        FeesMasterBOL FeesMasterBOL = new FeesMasterBOL();
        Int32 Id = Convert.ToInt32(gvFeesMasterInfoList.DataKeys[e.NewEditIndex].Value);
        FeesMasterBOL.Id = Id;
        FeesMasterBOL = oFeesMasterBLL.FeesMaster_GetById(FeesMasterBOL);
        SetDataToControls(FeesMasterBOL);
    }
    private void SetDataToControls(FeesMasterBOL FeesMaster)
    {

        try
        {
           ddlClass.SelectedValue= FeesMaster.ClassId.ToString();
        }
        catch
        {
            ddlClass.SelectedValue = "0";
        }
        try
        {
            ddlFeesType.SelectedValue = FeesMaster.FeesTypeId.ToString();
        }
        catch
        {
            ddlFeesType.SelectedValue = "";
        }
        try
        {
            txtDueDate.Text = FeesMaster.DueDateBind.ToString();
        }
        catch
        {
            txtDueDate.Text = "";
        }
        try
        {
            txtAmount.Text = FeesMaster.Amount.ToString();
        }
        catch
        {
            txtAmount.Text = "";
        }

        if (FeesMaster.FinePercentage.ToString() != "0")
        {
            txtPercentage.Text = FeesMaster.FinePercentage.ToString();
            txtPercentage.Enabled = true;
            txtFixedAmount.Enabled = false;
            rdPercentage.Checked = true;
        }
        else
        {
            int FixAmount = Convert.ToInt32(FeesMaster.TotalAmount) - Convert.ToInt32(FeesMaster.Amount);
            if (FixAmount > 0)
            {
                txtFixedAmount.Text = FixAmount.ToString();
            }
            else
            {
                txtFixedAmount.Text = "";
                   
                  
            }

            txtPercentage.Enabled = false;
            rdFixAmount.Checked = true;
        }
        if (txtPercentage.Text == "" && txtFixedAmount.Text == "")
        {
            rdPercentage.Checked = false;
            rdFixAmount.Checked = false;
            txtPercentage.Enabled = false;
            txtFixedAmount.Enabled = false;
            rdNone.Checked = true;
        }
        try
        {
            txtTotalAmount.Text = Convert.ToString(FeesMaster.TotalAmount);
        }
        catch
        {
            txtTotalAmount.Text = "";
        }

        hfAutoId.Value = FeesMaster.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {

        txtAmount.Text = string.Empty;
        ddlClass.SelectedValue = "0";
        ddlFeesType.SelectedValue = "0";
        txtDueDate.Text = "";
        txtAmount.Text = "";
        txtPercentage.Text = "";
        txtFixedAmount.Text = "";
        txtTotalAmount.Text = "";
        rdNone.Checked = false;
        rdPercentage.Checked = false;
        rdFixAmount.Checked = false;
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
    protected void gvFeesMasterInfoList_Sorting(object sender, GridViewSortEventArgs e)
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
            gvFeesMasterInfoList.DataSource = sortedView;
            gvFeesMasterInfoList.DataBind();

        }
    }
    protected void gvFeesTypeInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvFeesMasterInfoList.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();

            gvFeesMasterInfoList.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvFeesMasterInfoList.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvFeesMasterInfoList.PageSize * (gvFeesMasterInfoList.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvFeesMasterInfoList.PageSize;

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
            gvFeesMasterInfoList.DataBind();
        }
        else
        {
            BindList();
            gvFeesMasterInfoList.DataBind();
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
            //string sql = "SP_TB_ExpenseHeadListToExcel";
            //dt2 = Global.CreateDataTable(sql);
            dt2 = (DataTable)Session["Dt"];
            string FileName = "FeesMasterList(" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + ").xlsx";

            try
            {
                var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add(dt2, "FeesMasterList");


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
        string sql = "SP_TB_FeesMasterListSearchBox";
        dt = Global.CreateNo_FeesMasterSearchBox(sql, txtSearchBox.Text);

        Session["Dt"] = dt;
        gvFeesMasterInfoList.DataSource = dt;
        Session["Dt"] = dt;
        int iTotalRecords = ((DataTable)(gvFeesMasterInfoList.DataSource)).Rows.Count;
        Session["iTotalRecords"] = iTotalRecords;
        int iEndRecord = gvFeesMasterInfoList.PageSize * (gvFeesMasterInfoList.PageIndex + 1);

        int iStartsRecods = iEndRecord - gvFeesMasterInfoList.PageSize;

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

        if (gvFeesMasterInfoList.Rows.Count < 1)
        {
            gvFeesMasterInfoList.EmptyDataText = "No Data Found";
        }

        gvFeesMasterInfoList.DataBind();
    }
}