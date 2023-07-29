using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Data;

public partial class Student_StudentCategories : System.Web.UI.Page
{
    StudentCategoryBLL oStudentCategoryBLL = new StudentCategoryBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Student Category";
                Clear();
                BindList();
             
            }
            // this.RegisterPostBackControl();
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }

    private void BindList()
    {
        DataTable dtStudentCategory = oStudentCategoryBLL.StudentCategory_GetDataForGV();
        gvStudentCategoryInfoList.DataSource = dtStudentCategory;
        gvStudentCategoryInfoList.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        Save();

       


    }
    private void Save()
    {

        StudentCategoryBOL entity = new StudentCategoryBOL();

        entity.Category = txtCategory.Text.Trim();
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {

           

            //Save record
            Id = oStudentCategoryBLL.StudentCategory_Add(entity);
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
           
            Id = oStudentCategoryBLL.StudentCategory_Update(entity);

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
    protected void gvStudentCategoryInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvStudentCategoryInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        StudentCategoryBOL entity = new StudentCategoryBOL();
        Int32 Id = Convert.ToInt32(gvStudentCategoryInfoList.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oStudentCategoryBLL.StudentCategory_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvStudentCategoryInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        StudentCategoryBOL StudentCategoryBOL = new StudentCategoryBOL();
        Int32 Id = Convert.ToInt32(gvStudentCategoryInfoList.DataKeys[e.NewEditIndex].Value);
        StudentCategoryBOL.Id = Id;
        StudentCategoryBOL = oStudentCategoryBLL.StudentCategory_GetById(StudentCategoryBOL);
        SetDataToControls(StudentCategoryBOL);
    }
    private void SetDataToControls(StudentCategoryBOL StudentCategory)
    {

        try
        {
            txtCategory.Text = StudentCategory.Category.ToString();
        }
        catch
        {
            txtCategory.Text = "";
        }
        try
        {
            txtDescription.Text = StudentCategory.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = StudentCategory.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtCategory.Focus();
        txtCategory.Text = string.Empty;
        txtDescription.Text = string.Empty;
        hfAutoId.Value = "0";
        btnsave.Visible = true;
        btnupdate.Visible = false;

    }
}