using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Data;


public partial class FeesCollection_FeesReminder : System.Web.UI.Page
{
    FeesReminderBLL oFeesReminderBLL = new FeesReminderBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "Reminder Type";
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
        DataTable dtFeesReminder = oFeesReminderBLL.FeesReminder_GetDataForGV();
        gvFeesReminderInfoList.DataSource = dtFeesReminder;
        gvFeesReminderInfoList.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

        FeesReminderBOL entity = new FeesReminderBOL();

        entity.ReminderType = ddlReminderType.SelectedValue;
        if (chkIsActive.Checked == true)
        {
            entity.IsActive = 1;

        }
        else
        {
            entity.IsActive = 0;

        }

        entity.Days =Convert.ToInt32( txtDays.Text.Trim());
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {



            //Save record
            Id = oFeesReminderBLL.FeesReminder_Add(entity);
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

            Id = oFeesReminderBLL.FeesReminder_Update(entity);

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
    protected void gvFeesReminderInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvFeesReminderInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        FeesReminderBOL entity = new FeesReminderBOL();
        Int32 Id = Convert.ToInt32(gvFeesReminderInfoList.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oFeesReminderBLL.FeesReminder_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvFeesReminderInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        FeesReminderBOL FeesReminderBOL = new FeesReminderBOL();
        Int32 Id = Convert.ToInt32(gvFeesReminderInfoList.DataKeys[e.NewEditIndex].Value);
        FeesReminderBOL.Id = Id;
        FeesReminderBOL = oFeesReminderBLL.FeesReminder_GetById(FeesReminderBOL);
        SetDataToControls(FeesReminderBOL);
    }
    private void SetDataToControls(FeesReminderBOL FeesReminder)
    {

        if (Convert.ToInt32(FeesReminder.IsActive.ToString()) == 1)
        {
            chkIsActive.Checked = true;
        }
        else
        {
            chkIsActive.Checked = false;
        }

        try
        {
            ddlReminderType.SelectedValue = FeesReminder.ReminderType.ToString();
        }
        catch
        {
            ddlReminderType.SelectedValue = "0";
        }
        try
        {
            txtDays.Text = FeesReminder.Days.ToString();
        }
        catch
        {
            txtDays.Text = "";
        }
        try
        {
            txtDescription.Text = FeesReminder.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = FeesReminder.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        ddlReminderType.Focus();
        ddlReminderType.SelectedValue = "0";
        txtDescription.Text = string.Empty;
        hfAutoId.Value = "0";
        chkIsActive.Checked = false;
        btnsave.Visible = true;
        btnupdate.Visible = false;
        txtDays.Text = "";

    }
}