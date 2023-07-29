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
using iTextSharp.text.xml.simpleparser;

public partial class HumanResource_StaffProfileCreate : System.Web.UI.Page
{
    public string UploadFolderPath = "~/images/defalt.jpg";
    StaffProfileBLL oStaffProfileBLL = new StaffProfileBLL();
    StaffProfileBOL entity = new StaffProfileBOL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["SortedView"] = null;
                Session["dt"] = null;
                Session["iTotalRecords"] = 0;
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Accounts>Staff Profile ";
                LoadDesignationList();
                LoadMaritalStatusList();
                LoadGenderList();
                LoadDepartmentList();
                LoadReligionList();
                LoadBloodGroupList();
                LoadBankList();
                BindList();
            }
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }

    }

    private void LoadDesignationList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_DesignationListDDL";
        dt = Global.CreateDataTable(sql);

        ddlDesignation.DataSource = dt;
        ddlDesignation.DataTextField = "Designation";
        ddlDesignation.DataValueField = "AutoID";
        ddlDesignation.DataBind();


    }
    private void LoadDepartmentList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_DepartmentListDDL";
        dt = Global.CreateDataTable(sql);

        ddlDepartment.DataSource = dt;
        ddlDepartment.DataTextField = "Department";
        ddlDepartment.DataValueField = "AutoID";
        ddlDepartment.DataBind();


    }
    //SP_MaritalStatusListDDL
    private void LoadMaritalStatusList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_MaritalStatusListDDL";
        dt = Global.CreateDataTable(sql);
        ddlMaritalStatus.DataSource = dt;
        ddlMaritalStatus.DataTextField = "MaritalStatus";
        ddlMaritalStatus.DataValueField = "Id";
        ddlMaritalStatus.DataBind();
    }

    private void LoadReligionList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_ReligionListDDL";
        dt = Global.CreateDataTable(sql);

        ddlReligion.DataSource = dt;
        ddlReligion.DataTextField = "Religion";
        ddlReligion.DataValueField = "Id";
        ddlReligion.DataBind();


    }
    private void LoadBloodGroupList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_BloodGroupListDDL";
        dt = Global.CreateDataTable(sql);

        ddlBloodGroup.DataSource = dt;
        ddlBloodGroup.DataTextField = "BloodGroup";
        ddlBloodGroup.DataValueField = "Id";
        ddlBloodGroup.DataBind();


    }
    private void LoadBankList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_BankListDDL";
        dt = Global.CreateDataTable(sql);

        ddlBankName.DataSource = dt;
        ddlBankName.DataTextField = "BankName";
        ddlBankName.DataValueField = "BankCode";
        ddlBankName.DataBind();


    }

    //
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();

    }
    private void LoadGenderList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_GenderListDDL";
        dt = Global.CreateDataTable(sql);

        ddlGender.DataSource = dt;
        ddlGender.DataTextField = "Gender";
        ddlGender.DataValueField = "Id";
        ddlGender.DataBind();


    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Save();

    }

    SqlConnection connection = null;
    private void Save()
    {

        entity.Name = txtName.Text;
        entity.FatherName = txtFName.Text;
        entity.MotherName = txtMName.Text.Trim();
        entity.Phone = txtPhoneNo.Text;
        entity.EmargencyNo = txtEmergencyNo.Text;
        entity.Email = txtEmailID.Text;
        entity.Gender = Convert.ToInt32(ddlGender.SelectedValue);
        entity.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
        entity.BloodGroupId = Convert.ToInt32(ddlBloodGroup.SelectedValue);
        entity.PresentAddress = txtPresentAddress.Text;
        entity.PermanentAddress = txtPermanentAddress.Text;
        entity.ReligionId = Convert.ToInt32(ddlReligion.SelectedValue);
        entity.NID = txtIdCardNo.Text;
        entity.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
        entity.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
        entity.BankAccountTitle = txtBankAccountTitle.Text;
        entity.BankId = Convert.ToInt32(ddlBankName.SelectedValue);
        entity.BankBranchName = txtBankBranchName.Text;
        entity.BankAccountNo = txtBankAccountNo.Text;
        entity.BankAddress = txtBankAddress.Text;
        if(txtBasicSalary.Text=="")
        {
            txtBasicSalary.Text = "0.0";
        }
        entity.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);

        if (txtDoB.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtDoB.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.DOB = JoiningDate;
        }
        else
        {
            entity.DOB = Convert.ToDateTime("01/01/1991");

        }
      


        if (txtJoiningDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtJoiningDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.JoiningDate = JoiningDate;
        }
        else
        {
            entity.JoiningDate = Convert.ToDateTime("01/01/1991");

        }
      
        entity.CreatedBy = Session["UserID"].ToString();
        string filePath = fuProfilePic.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename);
        string contenttype = String.Empty;
        switch (ext)
        {
            case ".doc":
                contenttype = "application/vnd.ms-word";
                break;
            case ".docx":
                contenttype = "application/vnd.ms-word";
                break;
            case ".xls":
                contenttype = "application/vnd.ms-excel";
                break;
            case ".xlsx":
                contenttype = "application/vnd.ms-excel";
                break;
            case ".jpg":
                contenttype = "image/jpg";
                break;
            case ".png":
                contenttype = "image/png";
                break;
            case ".gif":
                contenttype = "image/gif";
                break;
            case ".pdf":
                contenttype = "application/pdf";
                break;
        }


        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
        {

            //Save record

            if (contenttype != String.Empty)
            {



                FileUpload img = (FileUpload)fuProfilePic;
                Byte[] imgByte = null;

                if (img.HasFile && img.PostedFile != null)
                {

                    HttpPostedFile File = fuProfilePic.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                    connection = new SqlConnection(conn);
                    connection.Open();
                    string sql = "INSERT INTO TB_StaffProfile(Images) VALUES(@eimg) SELECT @@IDENTITY";
                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@eimg", imgByte);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    entity.Id = id;
                }
            }

            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised. Upload Image/Word/PDF/Excel formats";
            }




            Id = oStaffProfileBLL.StaffProfile_Add(entity);

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

            entity.Id = Convert.ToInt32(hfUserId.Value);
            entity.StaffId = Convert.ToInt32(hfStaffId.Value);
            entity.ChangedBy = Session["UserID"].ToString();
            string filePathUpdate = fuProfilePic.PostedFile.FileName;
            string filenameUpdate = Path.GetFileName(filePathUpdate);
            string extUpdate = Path.GetExtension(filenameUpdate);
            string contenttypeUpdate = String.Empty;
            switch (extUpdate)
            {
                case ".doc":
                    contenttypeUpdate = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttypeUpdate = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttypeUpdate = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttypeUpdate = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttypeUpdate = "image/jpg";
                    break;
                case ".png":
                    contenttypeUpdate = "image/png";
                    break;
                case ".gif":
                    contenttypeUpdate = "image/gif";
                    break;
                case ".pdf":
                    contenttypeUpdate = "application/pdf";
                    break;
            }

            if (contenttypeUpdate != String.Empty)
            {


                FileUpload img = (FileUpload)fuProfilePic;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {

                    HttpPostedFile File = fuProfilePic.PostedFile;

                    imgByte = new Byte[File.ContentLength];

                    File.InputStream.Read(imgByte, 0, File.ContentLength);

                    string conn = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
                    connection = new SqlConnection(conn);

                    connection.Open();

                    string sql1 = " UPDATE TB_StaffProfile SET Images=@Images WHERE Id='" + hfUserId.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, connection);

                    cmd1.Parameters.AddWithValue("@Images", imgByte);
                    Int32 id1 = Convert.ToInt32(cmd1.ExecuteScalar());

                }
            }


            Id = oStaffProfileBLL.StaffProfile_Update(entity);
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
    private void Clear()
    {
            hfUserId.Value = "0";
            hfStaffId.Value = "0";
            txtName.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtPhoneNo.Text = "";
            txtEmergencyNo.Text = "";
            txtEmailID.Text = "";
            txtDoB.Text = "";
            ddlGender.SelectedValue = "0";
            ddlMaritalStatus.SelectedValue = "0";
            txtPresentAddress.Text = "";
            txtPermanentAddress.Text = "";
            txtIdCardNo.Text = "";
            ddlDepartment.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            ddlBloodGroup.SelectedValue = "0";
            txtJoiningDate.Text = "";
            txtBankAccountTitle.Text = "";
            ddlBankName.SelectedValue = "0";
            txtBankBranchName.Text = "";
            txtBankAccountNo.Text = "";
            txtBankAddress.Text = "";
            txtBasicSalary.Text = "";
            Image1.ImageUrl = UploadFolderPath;
            btnsave.Visible = true;
            btnupdate.Visible = false;

    }

    protected void gvStaffProfile_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Images"]);
            (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
        }
    }
    protected void gvStaffProfile_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvStaffProfile.DataKeys[e.RowIndex].Value.ToString();
        entity.Id = Convert.ToInt32(Id);
        //int success = oUserBLL.User_Delete(Id);
        int success = oStaffProfileBLL.StaffProfile_Delete(entity);

        if (success > 0)
        {
            BindList();
        }
    }
    protected void gvStaffProfile_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);
        //tContUser.ActiveTabIndex = 1;
    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        DataTable dt = new DataTable();
        StaffProfileBOL oStaffProfileBOL = new StaffProfileBOL();
        Int32 Id = Convert.ToInt32(gvStaffProfile.DataKeys[e.NewEditIndex].Value);
        oStaffProfileBOL.Id = Id;

        oStaffProfileBOL = oStaffProfileBLL.StaffProfile_GetById(oStaffProfileBOL);
     

        

         SetDataToControls(oStaffProfileBOL);
    }

    private void SetDataToControls(StaffProfileBOL oStaffProfileBOL)
{

         try
         {
            hfStaffId.Value = oStaffProfileBOL.StaffId.ToString();
         }
         catch
         {
            hfStaffId.Value = "0";
         }

        try
        {
            txtName.Text = oStaffProfileBOL.Name.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
        try
        {
            txtFName.Text = oStaffProfileBOL.FatherName.ToString();
        }
        catch
        {
            txtFName.Text = "";
        }
        try
        {
            txtFName.Text = oStaffProfileBOL.FatherName.ToString();
        }
        catch
        {
            txtFName.Text = "";
        }
        try
        {
            txtMName.Text = oStaffProfileBOL.MotherName.ToString();
        }
        catch
        {
            txtMName.Text = "";
        }
        try
        {
            txtPhoneNo.Text = oStaffProfileBOL.Phone.ToString();
        }
        catch
        {
            txtPhoneNo.Text = "";
        }
        try
        {
            txtEmergencyNo.Text = oStaffProfileBOL.EmargencyNo.ToString();
        }
        catch
        {
            txtEmergencyNo.Text = "";
        }
        try
        {
            txtEmailID.Text = oStaffProfileBOL.Email.ToString();
        }
        catch
        {
            txtEmailID.Text = "";
        }
        try
        {
            txtDoB.Text= oStaffProfileBOL.DOBBind.ToString();
        }
        catch
        {
            txtDoB.Text = "";
        }
        try
        {
            ddlGender.SelectedValue = oStaffProfileBOL.Gender.ToString();
        }
        catch
        {
            ddlGender.SelectedValue = "0";
        }
        try
        {
            ddlMaritalStatus.SelectedValue = oStaffProfileBOL.MaritalStatus.ToString();
        }
        catch
        {
            ddlMaritalStatus.SelectedValue = "0";
        }

        try
        {
            txtPresentAddress.Text = oStaffProfileBOL.PresentAddress.ToString();
        }
        catch
        {
            txtPresentAddress.Text = "";
        }
        try
        {
            txtPermanentAddress.Text = oStaffProfileBOL.PermanentAddress.ToString();
        }
        catch
        {
            txtPermanentAddress.Text = "";
        }
        try
        {
            txtIdCardNo.Text = oStaffProfileBOL.NID.ToString();
        }
        catch
        {
            txtIdCardNo.Text = "";
        }
       

        try
        {
           ddlDepartment.SelectedValue= oStaffProfileBOL.DepartmentId.ToString();
        }
        catch
        {
            ddlDepartment.SelectedValue = "0";
        }

        try
        {
            ddlDesignation.SelectedValue = oStaffProfileBOL.DesignationId.ToString();
        }
        catch
        {
            ddlDesignation.SelectedValue = "0";
        }

        try
        {
            ddlBloodGroup.SelectedValue = oStaffProfileBOL.BloodGroupId.ToString();
        }
        catch
        {
            ddlBloodGroup.SelectedValue = "0";
        }

        try
        {
           txtJoiningDate.Text  = oStaffProfileBOL.JoiningDateBind.ToString();
        }
        catch
        {
            txtJoiningDate.Text = "";
        }
        try
        {
            txtBankAccountTitle.Text = oStaffProfileBOL.BankAccountTitle.ToString();
        }
        catch
        {
            txtBankAccountTitle.Text = "";
        }
        try
        {
            ddlBankName.SelectedValue = oStaffProfileBOL.BankId.ToString();
        }
        catch
        {
            ddlBankName.SelectedValue = "0";
        }

        try
        {
            txtBankBranchName.Text = oStaffProfileBOL.BankBranchName.ToString();
        }
        catch
        {
            txtBankBranchName.Text = "";
        }

        try
        {
            txtBankAccountNo.Text = oStaffProfileBOL.BankAccountNo.ToString();
        }
        catch
        {
            txtBankAccountNo.Text = "";
        }
        try
        {
            txtBankAddress.Text = oStaffProfileBOL.BankAddress.ToString();
        }
        catch
        {
            txtBankAddress.Text = "";
        }

        try
        {
            txtBasicSalary.Text = oStaffProfileBOL.BasicSalary.ToString();
        }
        catch
        {
            txtBasicSalary.Text = "";
        }
        
        byte[] bytes = (byte[])GetData("SELECT [Id],[Images] FROM TB_StaffProfile WHERE Id =" + oStaffProfileBOL.Id.ToString()).Rows[0]["Images"];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        Image1.Visible = false;
        Image1.Visible = true;
        Image1.ImageUrl = "data:image/png;base64," + base64String;
        btnsave.Visible = false;
        btnupdate.Visible = true;
        hfUserId.Value = oStaffProfileBOL.Id.ToString();
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

    private void BindList()
    {
        try
        {
            DataTable dt = oStaffProfileBLL.StaffProfile_GetDataForGV();

            gvStaffProfile.DataSource = dt;
            int iTotalRecords = ((DataTable)(gvStaffProfile.DataSource)).Rows.Count;
            Session["iTotalRecords"] = iTotalRecords;
            int iEndRecord = gvStaffProfile.PageSize * (gvStaffProfile.PageIndex + 1);

            int iStartsRecods = iEndRecord - gvStaffProfile.PageSize;

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
            if (gvStaffProfile.Rows.Count < 1)
            {
                gvStaffProfile.EmptyDataText = "No Data Found";
            }

            gvStaffProfile.DataBind();

        }

        catch (Exception ex)
        {
            Response.Write("Oops! error occured:" + ex.Message.ToString());
        }
        finally
        {


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
    protected void gvStaffProfile_Sorting(object sender, GridViewSortEventArgs e)
    {

        DataTable dataTable = new DataTable();

        dataTable = (DataTable)(Session["dt"]);
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
            gvStaffProfile.DataSource = sortedView;
            if (gvStaffProfile.Rows.Count < 1)
            {
                gvStaffProfile.EmptyDataText = "No Data Found";
            }
            gvStaffProfile.DataBind();
        }
    }
    protected void gvStaffProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStaffProfile.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();
            gvStaffProfile.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvStaffProfile.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvStaffProfile.PageSize * (gvStaffProfile.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvStaffProfile.PageSize;

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
            if (gvStaffProfile.Rows.Count < 1)
            {
                gvStaffProfile.EmptyDataText = "No Data Found";
            }
            gvStaffProfile.DataBind();
        }
        else
        {
            BindList();
            if (gvStaffProfile.Rows.Count < 1)
            {
                gvStaffProfile.EmptyDataText = "No Data Found";
            }
            gvStaffProfile.DataBind();
        }

    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {


    }

}