using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Data;

public partial class Student_DisableReason : System.Web.UI.Page
{
    DisableReasonBLL oDisableReasonBLL = new DisableReasonBLL();
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
        DataTable dtDisableReason = oDisableReasonBLL.DisableReason_GetDataForGV();
        gvDisableReasonInfoList.DataSource = dtDisableReason;
        gvDisableReasonInfoList.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        Save();




    }
    private void Save()
    {

        DisableReasonBOL entity = new DisableReasonBOL();

        entity.DisableReason = txtDisableReason.Text.Trim();
        entity.Description = txtDescription.Text.ToString();

        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfAutoId.Value) || hfAutoId.Value == "0")
        {



            //Save record
            Id = oDisableReasonBLL.DisableReason_Add(entity);
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

            Id = oDisableReasonBLL.DisableReason_Update(entity);

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
    protected void gvDisableReasonInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvDisableReasonInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DisableReasonBOL entity = new DisableReasonBOL();
        Int32 Id = Convert.ToInt32(gvDisableReasonInfoList.DataKeys[e.RowIndex].Value);
        entity.Id = Id;
        int success = oDisableReasonBLL.DisableReason_Delete(entity);
        if (success > 0)
        {
            BindList();
        }

    }
    protected void gvDisableReasonInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        e.Cancel = true;
        Clear();
        GetSelectedData(e);

    }
    private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        DisableReasonBOL DisableReasonBOL = new DisableReasonBOL();
        Int32 Id = Convert.ToInt32(gvDisableReasonInfoList.DataKeys[e.NewEditIndex].Value);
        DisableReasonBOL.Id = Id;
        DisableReasonBOL = oDisableReasonBLL.DisableReason_GetById(DisableReasonBOL);
        SetDataToControls(DisableReasonBOL);
    }
    private void SetDataToControls(DisableReasonBOL DisableReason)
    {

        try
        {
            txtDisableReason.Text = DisableReason.DisableReason.ToString();
        }
        catch
        {
            txtDisableReason.Text = "";
        }
        try
        {
            txtDescription.Text = DisableReason.Description.ToString();
        }
        catch
        {
            txtDescription.Text = "";
        }


        hfAutoId.Value = DisableReason.Id.ToString();
        btnsave.Visible = false;
        btnupdate.Visible = true;
    }
    private void Clear()
    {
        txtDisableReason.Focus();
        txtDisableReason.Text = string.Empty;
        txtDescription.Text = string.Empty;
        hfAutoId.Value = "0";
        btnsave.Visible = true;
        btnupdate.Visible = false;

    }
}