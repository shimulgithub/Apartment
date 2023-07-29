using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Data;

public partial class Student_StudentHouse : System.Web.UI.Page
{
    StudentHouseBLL oStudentHouseBLL = new StudentHouseBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Disable Reason";
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
        DataTable dtStudentHouse = oStudentHouseBLL.StudentHouse_GetDataForGV();
        gvStudentHouseInfoList.DataSource = dtStudentHouse;
        gvStudentHouseInfoList.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

        StudentHouseBOL entity = new StudentHouseBOL();

        entity.Name = txtName.Text.Trim();
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {



            //Save record
            Id = oStudentHouseBLL.StudentHouse_Add(entity);
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

            Id = oStudentHouseBLL.StudentHouse_Update(entity);

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
    protected void gvStudentHouseInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvStudentHouseInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        StudentHouseBOL entity = new StudentHouseBOL();
        Int32 Id = Convert.ToInt32(gvStudentHouseInfoList.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oStudentHouseBLL.StudentHouse_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvStudentHouseInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        StudentHouseBOL StudentHouseBOL = new StudentHouseBOL();
        Int32 Id = Convert.ToInt32(gvStudentHouseInfoList.DataKeys[e.NewEditIndex].Value);
        StudentHouseBOL.Id = Id;
        StudentHouseBOL = oStudentHouseBLL.StudentHouse_GetById(StudentHouseBOL);
        SetDataToControls(StudentHouseBOL);
    }
    private void SetDataToControls(StudentHouseBOL StudentHouse)
    {

        try
        {
            txtName.Text = StudentHouse.Name.ToString();
        }
        catch
        {
            txtName.Text = "";
        }
        try
        {
            txtDescription.Text = StudentHouse.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = StudentHouse.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtName.Focus();
        txtName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        hfAutoId.Value = "0";
        btnsave.Visible = true;
        btnupdate.Visible = false;

    }
}