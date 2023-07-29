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

public partial class Student_StudentAdmission : System.Web.UI.Page
{
  public   string UploadFolderPath = "~/images/defalt.jpg";
    StudentAdmissionBLL oStudentAdmissionBLL = new StudentAdmissionBLL();
    StudentAdmissionBOL entity = new StudentAdmissionBOL();
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
                Session["breadcrumb"] = "Settings>Student Admission ";
                LoadYearList();
                LoadClassList();
                LoadSectionListList();
                LoadGenderList();
                LoadStudentCategoryList();
                LoadReligionList();
                LoadBloodGroupList();
                BindList();

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
    private void LoadStudentCategoryList()
    {
        DataTable dt = new DataTable();
        string sql = "SP_CategoryListDDL";
        dt = Global.CreateDataTable(sql);

        ddlStudentCategory.DataSource = dt;
        ddlStudentCategory.DataTextField = "Category";
        ddlStudentCategory.DataValueField = "Id";
        ddlStudentCategory.DataBind();


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

       

        entity.ClassId = ddlClass.SelectedValue;
        entity.SectionId = ddlSection.SelectedValue;
        entity.RollNo = txtRollNo.Text.Trim();
        entity.FirstName = txtFirstName.Text;
        entity.LastName = txtLastName.Text;
        entity.GenderId = ddlGender.SelectedValue;
        entity.Year = ddlYear.SelectedValue;

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
        entity.CategoryId = ddlStudentCategory.SelectedValue;

        entity.Email = txtEmailID.Text;
        entity.ReligionId = ddlReligion.SelectedValue;
        entity.MobileNo = txtMobileNo.Text;
        entity.BloodGroupId = ddlBloodGroup.SelectedValue;
        entity.IdCardNo = txtIdCardNo.Text;
        entity.BirthCertificate = txtBirthCerNo.Text.Trim();
        entity.PresentAddress = txtPresentAddress.Text;
        entity.PermanentAddress = txtPermanentAddress.Text;
        
        if (txtAdmissionDate.Text != "")
        {
            DateTime dtpJoiningDate = DateTime.ParseExact(txtAdmissionDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime JoiningDate = Convert.ToDateTime(dtpJoiningDate.ToString("yyyy-MM-dd"));
            entity.AdmissionDate = JoiningDate;
        }
        else
        {
            entity.AdmissionDate = Convert.ToDateTime("01/01/1991");

        }

        entity.FatherName = txtFatherName.Text;
        entity.FatherOccupation = txtFatherOccupation.Text;
        entity.FatherPhoneNo = txtFatherPhoneNo.Text;
        entity.MotherName = txtMotherName.Text;
        entity.MotherOccupation = txtMotherOccupation.Text;
        entity.MotherPhoneNo = txtMotherPhoneNo.Text;
        entity.GuardianName = txtGuardianName.Text;
        entity.GuardianOccupation = txtGuardianOccupation.Text;
        entity.GuardianPhoneNo = txtGuardianPhoneNo.Text;
        entity.CreateBy = Session["UserID"].ToString();
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
                    string sql = "INSERT INTO TB_StudentAdmission(Images) VALUES(@eimg) SELECT @@IDENTITY";
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




            Id = oStudentAdmissionBLL.StudentAdmission_Add(entity);

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

                    string sql1 = " UPDATE TB_StudentAdmission SET Images=@Images WHERE Id='" + hfUserId.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, connection);

                    cmd1.Parameters.AddWithValue("@Images", imgByte);
                    Int32 id1 = Convert.ToInt32(cmd1.ExecuteScalar());

                }
            }


            Id = oStudentAdmissionBLL.StudentAdmission_Update(entity);
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
        ddlYear.SelectedValue = "0";
        hfClassPrefix.Value = "";
        hfUserId.Value = "0";
        ddlClass.SelectedValue = "0";
        ddlSection.SelectedValue = "0";
        txtRollNo.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        ddlGender.SelectedValue = "0";
        txtDoB.Text = string.Empty;
        ddlStudentCategory.SelectedValue = "0";
        ddlReligion.SelectedValue = "0";
        txtMobileNo.Text = string.Empty;
        ddlBloodGroup.SelectedValue = "0";
        txtIdCardNo.Text = string.Empty;
        txtBirthCerNo.Text = string.Empty;
        txtEmailID.Text = string.Empty;
        txtPresentAddress.Text = string.Empty;
        txtPermanentAddress.Text = string.Empty;
        txtAdmissionDate.Text = string.Empty;
        txtFatherName.Text = string.Empty;
        txtFatherOccupation.Text = string.Empty;
        txtFatherPhoneNo.Text = string.Empty;
        txtMotherName.Text = string.Empty;
        txtMotherOccupation.Text = string.Empty;
        txtMotherPhoneNo.Text = string.Empty;
        txtGuardianName.Text = string.Empty;
        txtGuardianOccupation.Text = string.Empty;
        txtGuardianPhoneNo.Text = string.Empty;
        Image1.ImageUrl = UploadFolderPath;

        btnsave.Visible = true;
        btnupdate.Visible = false ;

    }

    protected void gvStudentAdmission_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Images"]);
            (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
        }
    }
    protected void gvStudentAdmission_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = gvStudentAdmission.DataKeys[e.RowIndex].Value.ToString();
        entity.Id = Convert.ToInt32(Id);
        //int success = oUserBLL.User_Delete(Id);
        int success = oStudentAdmissionBLL.StudentAdmission_Delete(entity);

        if (success > 0)
        {
            BindList();
        }
    }
    protected void gvStudentAdmission_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);
        //tContUser.ActiveTabIndex = 1;
    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        DataTable dt = new DataTable();
        StudentAdmissionBOL oStudentAdmissionBOL = new StudentAdmissionBOL();
        Int32 Id = Convert.ToInt32(gvStudentAdmission.DataKeys[e.NewEditIndex].Value);
        oStudentAdmissionBOL.Id = Id;
        
        dt = oStudentAdmissionBLL.StudentAdmission_GetById(oStudentAdmissionBOL);
        if (dt.Rows.Count > 0)
        {

            ddlClass.SelectedValue = dt.Rows[0]["ClassId"].ToString();
            ddlSection.SelectedValue= dt.Rows[0]["SectionId"].ToString();
            txtRollNo.Text= dt.Rows[0]["RollNo"].ToString();
            txtEmailID.Text = dt.Rows[0]["Email"].ToString();
            txtFirstName.Text= dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();

            if (dt.Rows[0]["GenderId"].ToString() == "")
            {
                ddlGender.SelectedValue = "0";
            }
            else
            {
                ddlGender.SelectedValue = dt.Rows[0]["GenderId"].ToString();
            }

            ddlStudentCategory.SelectedValue= dt.Rows[0]["CategoryId"].ToString();
            ddlReligion.SelectedValue= dt.Rows[0]["CategoryId"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            ddlBloodGroup.SelectedValue= dt.Rows[0]["BloodGroupId"].ToString();
            txtIdCardNo.Text= dt.Rows[0]["IdCardNo"].ToString();
            txtDoB.Text = dt.Rows[0]["DOB"].ToString();
            txtBirthCerNo.Text= dt.Rows[0]["BirthCertificate"].ToString();
            txtPresentAddress.Text = dt.Rows[0]["PresentAddress"].ToString();
            txtPermanentAddress.Text= dt.Rows[0]["PermanentAddress"].ToString();
            txtAdmissionDate.Text = dt.Rows[0]["AdmissionDate"].ToString();
            txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
            txtFatherPhoneNo.Text= dt.Rows[0]["FatherPhoneNo"].ToString();
            txtFatherOccupation.Text = dt.Rows[0]["FatherOccupation"].ToString();
            txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
            txtMotherPhoneNo.Text = dt.Rows[0]["MotherPhoneNo"].ToString();
            txtMotherOccupation.Text = dt.Rows[0]["MotherOccupation"].ToString();
            txtGuardianName.Text = dt.Rows[0]["GuardianName"].ToString();
            txtGuardianPhoneNo.Text = dt.Rows[0]["GuardianPhoneNo"].ToString();
            txtGuardianOccupation.Text = dt.Rows[0]["GuardianOccupation"].ToString();
            ddlYear.SelectedValue = dt.Rows[0]["Year"].ToString();


            hfUserId.Value = dt.Rows[0]["Id"].ToString();

            byte[] bytes = (byte[])GetData("SELECT [Id],[Images] FROM TB_StudentAdmission WHERE Id =" + Id).Rows[0]["Images"];

            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.Visible = false;
            Image1.Visible = true;
            Image1.ImageUrl = "data:image/png;base64," + base64String;

        }
        btnsave.Visible = false;
        btnupdate.Visible = true;
        hfUserId.Value = dt.Rows[0]["Id"].ToString();
        //  SetDataToControls(oStudentAdmissionBOL);
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
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedValue!="0")
        {
            DataTable dt = new DataTable();
            string sql = "SP_ClassNameListByClassId";
            dt = Global.CreateDataTableParameter(sql,ddlClass.SelectedValue);
            if (dt.Rows.Count > 0)
            {

                hfClassPrefix.Value = dt.Rows[0]["Prefix"].ToString();
             }

        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYear.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Please Select Admission Year');", true);
            return;
        }
        if (ddlClass.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Please Select Admission Year');", true);
            return;
        }
        DataTable dt = new DataTable();
        string sql = "SP_StudentMaxRollNo";
        dt = Global.CreateDataTableParameter_GetStudentDataByParam(sql, ddlClass.SelectedValue, ddlSection.SelectedValue, ddlYear.SelectedValue);

        if (dt.Rows.Count > 0)
        {
            txtRollNo.Text = dt.Rows[0]["MaxRoll"].ToString();

        }
        else
        {
            txtRollNo.Text = "1";
        }
        string val = "";
        if (txtRollNo.Text.Length == 1)
        {
            val = "0000";
        }
        else
        {
            val = "000";
        }
        txtIdCardNo.Text = hfClassPrefix.Value + "-" + ddlSection.SelectedItem  + ddlYear.SelectedItem+ val + txtRollNo.Text;

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

    private void BindList()
    {
        try
        {
            DataTable dt = oStudentAdmissionBLL.StudentAdmission_GetDataForGV();

            gvStudentAdmission.DataSource = dt;
            int iTotalRecords = ((DataTable)(gvStudentAdmission.DataSource)).Rows.Count;
            Session["iTotalRecords"] = iTotalRecords;
            int iEndRecord = gvStudentAdmission.PageSize * (gvStudentAdmission.PageIndex + 1);

            int iStartsRecods = iEndRecord - gvStudentAdmission.PageSize;

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
            if (gvStudentAdmission.Rows.Count < 1)
            {
                gvStudentAdmission.EmptyDataText = "No Data Found";
            }

            gvStudentAdmission.DataBind();

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
    protected void gvStudentAdmission_Sorting(object sender, GridViewSortEventArgs e)
    {

        DataTable dataTable = new DataTable();

        dataTable =( DataTable)(Session["dt"]);
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
            gvStudentAdmission.DataSource = sortedView;
            if (gvStudentAdmission.Rows.Count < 1)
            {
                gvStudentAdmission.EmptyDataText = "No Data Found";
            }
            gvStudentAdmission.DataBind();
        }
    }
    protected void gvStudentAdmission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentAdmission.PageIndex = e.NewPageIndex;

        if (Session["SortedView"] != null)
        {
            DataTable dataTable = new DataTable();
            gvStudentAdmission.DataSource = (DataView)Session["SortedView"];

            int iTotalRecords = ((DataView)(gvStudentAdmission.DataSource)).Count;     //Convert.ToInt32(Session["iTotalRecords"].ToString());  //
            int iEndRecord = gvStudentAdmission.PageSize * (gvStudentAdmission.PageIndex + 1);
            int iStartsRecods = iEndRecord - gvStudentAdmission.PageSize;

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
            if (gvStudentAdmission.Rows.Count < 1)
            {
                gvStudentAdmission.EmptyDataText = "No Data Found";
            }
            gvStudentAdmission.DataBind();
        }
        else
        {
            BindList();
            if (gvStudentAdmission.Rows.Count < 1)
            {
                gvStudentAdmission.EmptyDataText = "No Data Found";
            }
            gvStudentAdmission.DataBind();
        }

    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {


    }
   }
