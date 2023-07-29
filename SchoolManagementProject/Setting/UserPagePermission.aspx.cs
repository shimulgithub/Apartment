using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SMP.Common;


public partial class Setting_UserPagePermission : System.Web.UI.Page
{
    MenuHeadBLL objMenuHeadBLL = new MenuHeadBLL();
    MenuPageBLL objMenuPageBLL = new MenuPageBLL();
    MenuPermissionBLL objMenuPermissionBLL = new MenuPermissionBLL();
    private string userID = "";
    private string userPassword = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null || Session["UserID"].ToString() != "0")
        {
            try
            {
                userID = Session["UserID"].ToString();
                userPassword = Session["Password"].ToString();

            }
            catch
            {
                Response.Redirect("~/Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                Session["breadcrumb"] = "Settings > Pages > User Page Permission";
                LoadUserGroup();
                BindMenuHead();
            }
        }
        else
        {
            Response.Redirect("~/frmlogin.aspx");
        }

    }
    private void LoadUserGroup()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_UserGroup_GetAllDataForDDL";
        dt = Global.GetData(sql);
        ddlUserGroupName.DataSource = dt;
        ddlUserGroupName.DataTextField = "UserGroupName";
        ddlUserGroupName.DataValueField = "UserGroupID";
        ddlUserGroupName.DataBind();
    }

    protected void ddlUserGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserGroupName.SelectedIndex == 0)
        {
            BindMenuHead();
        }
        else
        {
            BindMenuHeadByUserID();
        }
    }

    protected void gvAllModule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            Label lblMainModuleMenuHeadID = ((Label)e.Row.FindControl("lblMainModuleMenuHeadID"));
            Label lblSubMenuHeadID = ((Label)e.Row.FindControl("lblSubMenuHeadID"));
            Label lblHeader = ((Label)e.Row.FindControl("lblHeader"));
            CheckBox chkBoxHeader = ((CheckBox)e.Row.FindControl("chkBoxHeader"));
            int headID = Convert.ToInt32(lblMainModuleMenuHeadID.Text);

            DataSet ds = objMenuPageBLL.MenuPage_GetAllByHeadID(headID, ddlUserGroupName.SelectedValue);

            DataTable dtop = new DataTable();

            dtop = ds.Tables[0];
            if (dtop.Rows.Count > 0)
            {
                ((GridView)e.Row.FindControl("gvSubMenuHead")).DataSource = dtop;
                ((GridView)e.Row.FindControl("gvSubMenuHead")).DataBind();
            }
            else
            {
                dtop = null;
                chkBoxHeader.Visible = false;
                ((GridView)e.Row.FindControl("gvSubMenuHead")).DataSource = dtop;
                ((GridView)e.Row.FindControl("gvSubMenuHead")).DataBind();
            }
        }
    }
    protected void gvSubMenuHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            Label lblSubMenuHeadID = ((Label)e.Row.FindControl("lblSubMenuHeadID"));
            CheckBox chkBoxPages = ((CheckBox)e.Row.FindControl("chkBoxPages"));
            int headID = Convert.ToInt32(lblSubMenuHeadID.Text);

            DataTable dtPages = new DataTable();
            dtPages = objMenuPageBLL.SubMenuPage_GetAllByHeadID(headID, ddlUserGroupName.SelectedValue);
            if (dtPages.Rows.Count > 0)
            {
                ((GridView)e.Row.FindControl("gvPagesMain")).DataSource = dtPages;
                ((GridView)e.Row.FindControl("gvPagesMain")).DataBind();
            }
            else
            {
                dtPages = null;
                chkBoxPages.Visible = false;
                ((GridView)e.Row.FindControl("gvPagesMain")).DataSource = dtPages;
                ((GridView)e.Row.FindControl("gvPagesMain")).DataBind();
            }
        }
    }
    protected void gvPagesMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            DataTable dtPages = new DataTable();

            Label lblPagesID = ((Label)e.Row.FindControl("lblPagesID"));
            //CheckBox chkBoxPages = ((CheckBox)e.Row.FindControl("chkBoxPages"));
            int headID = Convert.ToInt32(lblPagesID.Text);
            // Label lblPageId = ((Label)myRow.FindControl("lblPagesID"));


            string tableN = BindColumnHead(Convert.ToString(lblPagesID.Text));


            //if (tableN != "")
            //{
            //    //dtPages = objMenuPageBLL.SubMenuPage_GetAllByHeadID(headID, ddlUserGroupName.SelectedValue);
            //    SqlConnection conn = new SqlConnection();
            //    conn.ConnectionString = ConfigurationManager
            //            .ConnectionStrings["ConS2pibd"].ConnectionString;
            //    SqlCommand cmd = new SqlCommand();

            //    cmd.CommandText = @"SELECT AutoID,HeaderValue,HeaderText,Order_Priority ,convert(bit,ISNULL('0',0)) CView FROM SAS04Tempest_RP_TEST.dbo." + tableN + " MrgH  WHERE MrgH.HeaderValue <>'SelectAll'  order by   ISNULL(MrgH.Order_Priority,'9999')";
            //    cmd.Connection = conn;
            //    conn.Open();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);

            //    da.Fill(dtPages);
            //}
            //else
            //{
            //    //dtPages = null;
            //}


            if (dtPages.Rows.Count > 0)
            {

                ((GridView)e.Row.FindControl("gvColumnDetails")).DataSource = dtPages;
                ((GridView)e.Row.FindControl("gvColumnDetails")).DataBind();

                //GridView gv12 = (GridView)e.Row.FindControl("gvSubMenuHead") as GridView;

                //CheckBox chkBoxPages = ((CheckBox)gv12.FindControl("chkBoxPages"));


                ////foreach (GridViewRow NewgvRow in gv12.Rows)
                ////{
                ////    (NewgvRow.FindControl("chkBoxPages") as CheckBox).Checked = true;

                ////}

                GridView gv1 = (GridView)e.Row.FindControl("gvColumnDetails") as GridView;
                foreach (GridViewRow NewgvRow in gv1.Rows)
                {
                    (NewgvRow.FindControl("chkBoxPagesColumn") as CheckBox).Checked = true;
                }


            }
            else
            {
                dtPages = null;
                //chkBoxPages.Visible = false;
                ((GridView)e.Row.FindControl("gvColumnDetails")).DataSource = dtPages;
                ((GridView)e.Row.FindControl("gvColumnDetails")).DataBind();
            }
        }
    }

    private void BindMenuHead()
    {
        List<MenuHead> listHeader = objMenuHeadBLL.MenuHead_GetAll();
        gvAllModule.DataSource = listHeader;
        gvAllModule.DataBind();
    }

    private void BindMenuHeadByUserID()
    {
        List<MenuHead> listHeader = objMenuHeadBLL.MenuHead_GetAll(ddlUserGroupName.SelectedValue);
        gvAllModule.DataSource = listHeader;
        gvAllModule.DataBind();
    }
    protected void chkBoxPages_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkBoxPages = (sender as CheckBox);
        GridViewRow row = chkBoxPages.NamingContainer as GridViewRow;
        GridView gv = row.FindControl("gvPagesMain") as GridView;
        foreach (GridViewRow gvRow in gv.Rows)
        {
            (gvRow.FindControl("chkBoxPagesOP") as CheckBox).Checked = chkBoxPages.Checked;


        }
        foreach (GridViewRow gvRow in gv.Rows)
        {
            if ((gvRow.FindControl("chkBoxPagesOP") as CheckBox).Checked == true)
            {


                GridViewRow row1 = gvRow.FindControl("chkBoxPagesOP").NamingContainer as GridViewRow;
                GridView gv1 = row1.FindControl("gvColumnDetails") as GridView;
                foreach (GridViewRow NewgvRow in gv1.Rows)
                {
                    (NewgvRow.FindControl("chkBoxPagesColumn") as CheckBox).Checked = chkBoxPages.Checked;

                }


            }
            else
            {
                GridViewRow row1 = gvRow.FindControl("chkBoxPagesOP").NamingContainer as GridViewRow;
                GridView gv1 = row1.FindControl("gvColumnDetails") as GridView;
                foreach (GridViewRow NewgvRow in gv1.Rows)
                {
                    (NewgvRow.FindControl("chkBoxPagesColumn") as CheckBox).Checked = false;

                }

            }

        }



    }
    protected void chkBoxColumn_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox chkBoxPages = (sender as CheckBox);
        GridViewRow row = chkBoxPages.NamingContainer as GridViewRow;
        GridView gv = row.FindControl("gvColumnDetails") as GridView;
        foreach (GridViewRow gvRow in gv.Rows)
        {
            (gvRow.FindControl("chkBoxPagesColumn") as CheckBox).Checked = chkBoxPages.Checked;

        }

    }
    protected void ExpandButton_Click(object sender, EventArgs e)
    {
        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        ImageButton expandBtn = sender as ImageButton;
        Panel KeysPanel = ((Panel)myRow.FindControl("KeysPanel"));

        if (expandBtn.ImageUrl == "~/Images/plus.png")
        {
            expandBtn.ImageUrl = "~/Images/minus.png";
            KeysPanel.Visible = true;
        }
        else
        {
            expandBtn.ImageUrl = "~/Images/plus.png";
            KeysPanel.Visible = false;
        }
    }
    public string BindColumnHead(string TableNameID)
    {

        string TableName = "";

        //PageId	PageName
        //1004	Assg. Details-Consultant Splits
        //1003	Credit Notes Details
        //1002	Margin Reports (Details)
        //1006	Perm Placement
        //1016	Purchase Day Book
        //1015	Sales Day Book
        //1001	Valid Timesheet (Summary)
        //1007	Worker Details
        //1005	Worker Suppliers

        if (TableNameID == "1004")
            TableName = "AssignementDetailswithconsultantsplits_Header";

        if (TableNameID == "1003")
            TableName = "CreditNotesDetails_Header";

        if (TableNameID == "1002")
            TableName = "MarginReportsbyEmployerswithdetails_Header";

        if (TableNameID == "1006")
            TableName = "PermPlacementReports_Header";

        if (TableNameID == "1016")
            TableName = "PurchaseDayBookReport_Header";

        if (TableNameID == "1015")
            TableName = "SalesDayBookReport_Header";

        if (TableNameID == "1001")
            TableName = "Valid_Timesheets_with_Suppliers_Header";

        if (TableNameID == "1007")
            TableName = "WorkerDetails_Header";

        if (TableNameID == "1005")
            TableName = "Workersuppliers_Header";

        if (TableNameID == "1018")
            TableName = "US_Payroll_Spread_Sheet_Header";

        if (TableNameID == "1020")
            TableName = "ConsultantsListDetails_Header";

        if (TableNameID == "1022")
            TableName = "ClientsDetailsWithOutBillingAddress_Header";

        if (TableNameID == "1022")
            TableName = "ClientsDetailsWithBillingAddress_Header";

        if (TableNameID == "1023")
            TableName = "SuppliersDetails_Header";

        if (TableNameID == "1026")
            TableName = "AssignmentDetailsList_Header";

        if (TableNameID == "1026")
            TableName = "AssignmentDetailsWithRates_Header";

        if (TableNameID == "1028")
            TableName = "TempestSupplier_Header";

        if (TableNameID == "1030")
            TableName = "TempestPurchaseInvoice_Header";

        if (TableNameID == "1031")
            TableName = "MissingTimesheet_Header";

        if (TableNameID == "1032")
            TableName = "TempestPayments_Header";

        if (TableNameID == "1035")
            TableName = "ExchangeRates_Header";

        if (TableNameID == "1036")
            TableName = "ER_Period_Details_Header";

        if (TableNameID == "1037")
            TableName = "ManualPaymentAdjustments_Header";

        if (TableNameID == "1038")
            TableName = "ConsultantListComparison_Header";

        if (TableNameID == "1040")
            TableName = "TB_Margin_Adjustment_Entry_Header";

        if (TableNameID == "1041")
            TableName = "TB_Rpt_MarginReports_Fin_Team_Header";

        if (TableNameID == "1042")
            TableName = "TB_Margin_Adjustment_Finance_Combine_Header";

        if (TableNameID == "1043")
            TableName = "EmailLogs_Header";


        if (TableNameID == "1044")
            TableName = "TempestAuditReport_Header";

        if (TableNameID == "1047")
            TableName = "AssignmentDetailsWithLeaveInformation_Header";

        if (TableNameID == "1047")
            TableName = "AssignmentDetailsListWithLeaveSummary_Header";

        if (TableNameID == "1049")
            TableName = "PO_WithPurchaseOrderAudit_Header";

        if (TableNameID == "1050")
            TableName = "PurchaseOrder_Header";

        if (TableNameID == "1051")
            TableName = "MarginReportsbyEmployerswithdetails_Header";

        if (TableNameID == "1052")
            TableName = "TB_Margin_Adjustment_Finance_Combine_Header";

        if (TableNameID == "1053")
            TableName = "BillAmountWithPurchaseOrder_Header";


        if (TableNameID == "1058")
            TableName = "CommissionCalculationReport_Header";


        if (TableNameID == "1061")
            TableName = "NominalAccountMast_Header";

        if (TableNameID == "1062")
            TableName = "TPDocuments_Header";

        if (TableNameID == "1063")
            TableName = "NetPayReports_SummaryHeader";

        if (TableNameID == "1063")
            TableName = "NetPayReports_DetailsHeader";

        if (TableNameID == "1065")
            TableName = "NominalTransactionsView_Header";


        return TableName;
    }
    protected void ExpandButtonForColumn_Click(object sender, EventArgs e)
    {

        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        ImageButton expandBtn = sender as ImageButton;
        Panel KeysPanel = ((Panel)myRow.FindControl("ColumnPanel"));

        if (expandBtn.ImageUrl == "~/Images/plus.png")
        {
            expandBtn.ImageUrl = "~/Images/minus.png";
            KeysPanel.Visible = true;
        }
        else
        {
            expandBtn.ImageUrl = "~/Images/plus.png";
            KeysPanel.Visible = false;
        }

        //GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        //ImageButton expandBtn = sender as ImageButton;
        //Panel KeysPanel = ((Panel)myRow.FindControl("ColumnPanel"));

        //Label lblPageId = ((Label)myRow.FindControl("lblPagesID"));

        //hfVersoinAutoID.Value = "0";
        //string tableN = BindColumnHead(Convert.ToString(lblPageId.Text));
        //GridView gv = myRow.FindControl("gvColumnDetails") as GridView;

        //if (expandBtn.ImageUrl == "~/Images/plus.png")
        //{


        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ConfigurationManager
        //                .ConnectionStrings["ConS2pibd"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = @"SELECT AutoID,HeaderValue,HeaderText,Order_Priority ,convert(bit,ISNULL('0',0)) CView FROM DB_SMP.dbo." + tableN + " MrgH  WHERE MrgH.HeaderValue <>'SelectAll'  order by   ISNULL(MrgH.Order_Priority,'9999')";
        //            cmd.Connection = conn;
        //            conn.Open();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            gv.DataSource = ds;
        //            gv.DataBind();
        //        }
        //    }
        //    expandBtn.ImageUrl = "~/Images/minus.png";
        //    KeysPanel.Visible = true;
        //}
        //else
        //{
        //    expandBtn.ImageUrl = "~/Images/plus.png";
        //    KeysPanel.Visible = false;
        //}
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (sender as CheckBox);
        GridViewRow row = chkAll.NamingContainer as GridViewRow;

        GridView gv = row.FindControl("gvSubMenuHead") as GridView;

        ImageButton imgShowHide = (sender as ImageButton);
        foreach (GridViewRow gvRow in gv.Rows)
        {
            (gvRow.FindControl("chkBoxPages") as CheckBox).Checked = chkAll.Checked;

            GridView gv1 = gvRow.FindControl("gvPagesMain") as GridView;

            foreach (GridViewRow gvRow1 in gv1.Rows)
            {
                (gvRow1.FindControl("chkBoxPagesOP") as CheckBox).Checked = chkAll.Checked;
            }
        }

    }

    protected void btnPermission_Click(object sender, EventArgs e)
    {
        Save();
    }

    private void Save()
    {
        int success1 = 0;
        int success = -1;
        int succMain = 0;
        success = objMenuPermissionBLL.MenuPermission_DeleteByUserID(ddlUserGroupName.SelectedValue);
        //-------audit table update-----------------
        MenuPermissionBLL objColumnPermissionBLL1 = new MenuPermissionBLL();
        MenuPermission objColumnPermission1 = new MenuPermission();
        objColumnPermission1.UserGroupID = ddlUserGroupName.SelectedValue;
        Int32 IDupdate = objColumnPermissionBLL1.MenuPermissionForAudit_Update_ColumnFromUserGroupWisePagePermission(objColumnPermission1);
        //-------------------------------
        if (success >= 0)
        {
            success = 0;
            foreach (GridViewRow gvAllP in gvAllModule.Rows)
            {
                if (((CheckBox)gvAllP.FindControl("chkBoxHeader")).Checked)
                {
                    Label lblMainModuleMenuHeadName = ((Label)gvAllP.FindControl("lblMainModuleMenuHeadName"));
                    Label lblMainModuleMenuHeadID = ((Label)gvAllP.FindControl("lblMainModuleMenuHeadID"));
                    int MenuHeadID = Convert.ToInt32(lblMainModuleMenuHeadID.Text);
                    GridView gvPages = gvAllP.FindControl("gvSubMenuHead") as GridView;
                    foreach (GridViewRow gvPagesAll in gvPages.Rows)
                    {
                        if (((CheckBox)gvPagesAll.FindControl("chkBoxPages")).Checked)
                        {
                            Label lblSubMenuHeadID = ((Label)gvPagesAll.FindControl("lblSubMenuHeadID"));

                            int SubMenuHeadID = Convert.ToInt32(lblSubMenuHeadID.Text);
                            GridView gvPagesMain = gvPagesAll.FindControl("gvPagesMain") as GridView;
                            succMain = 1;

                            foreach (GridViewRow gvPagesMainAll in gvPagesMain.Rows)
                            {
                                succMain = 2;
                                if (((CheckBox)gvPagesMainAll.FindControl("chkBoxPagesOP")).Checked)
                                {
                                    Label lblPagesID = ((Label)gvPagesMainAll.FindControl("lblPagesID"));

                                    int pagesID = Convert.ToInt32(lblPagesID.Text);
                                    succMain = 3;
                                    MenuPermission objMenuPermission = new MenuPermission();

                                    objMenuPermission.CanView = true;
                                    objMenuPermission.MainModuleMenuHeadID = MenuHeadID;
                                    objMenuPermission.SubMenuHeadID = SubMenuHeadID;
                                    objMenuPermission.UserGroupID = ddlUserGroupName.SelectedValue;
                                    objMenuPermission.PageID = pagesID;
                                    success = objMenuPermissionBLL.MenuPermission_Add(objMenuPermission);

                                    /*-----------------Column Insert----------------------------*/

                                    GridViewRow row1 = gvPagesMainAll.FindControl("chkBoxPagesOP").NamingContainer as GridViewRow;
                                    GridView gv1 = row1.FindControl("gvColumnDetails") as GridView;
                                    foreach (GridViewRow NewgvRow in gv1.Rows)
                                    {
                                        MenuPermissionBLL objColumnPermissionBLL = new MenuPermissionBLL();
                                        MenuPermission objColumnPermission = new MenuPermission();

                                        CheckBox canView = (NewgvRow.FindControl("chkBoxPagesColumn") as CheckBox);
                                        Label ColumnAutoID = (NewgvRow.FindControl("lblColumnAutoID") as Label);
                                        TextBox OrderPriority = (NewgvRow.FindControl("lblOrderPriority") as TextBox);

                                        //objColumnPermission.CanView = canView.Checked;
                                        //objColumnPermission.ColumnHeadAutoID = Convert.ToInt32(ColumnAutoID.Text);
                                        //objColumnPermission.Order_Priority = Convert.ToInt32(OrderPriority.Text);
                                        if (canView.Checked)
                                        {
                                            objColumnPermission.PageID = pagesID;
                                            //objColumnPermission.HearedTableName = BindColumnHead(Convert.ToString(pagesID));
                                            objColumnPermission.UserGroupID = ddlUserGroupName.SelectedValue;
                                            objColumnPermission.CanView = canView.Checked;
                                            objColumnPermission.ColumnHeadAutoID = Convert.ToInt32(ColumnAutoID.Text);
                                            objColumnPermission.Order_Priority = Convert.ToInt32(OrderPriority.Text);
                                            objColumnPermission.CreateBy = Session["UserID"].ToString();

                                            //success1 = objColumnPermissionBLL.MenuPermission_Add_ColumnFromUserWisePagePermission(objColumnPermission);
                                            success1 = objColumnPermissionBLL.MenuPermission_Add_ColumnFromUserGroupWisePagePermission(objColumnPermission);

                                            objColumnPermission.AuditUserId = Convert.ToInt32(Session["UserID"].ToString());
                                            objColumnPermission.TranStatus = 1;
                                            objColumnPermission.Ref_Id = success1;
                                            objColumnPermission.AuditPageId = 1014;

                                            Int32 AuditID = objColumnPermissionBLL.MenuPermissionForAudit_Add_ColumnFromUserGroupWisePagePermission(objColumnPermission);

                                        }
                                    }

                                }
                            }
                        }
                    }
                    if (succMain < 3)
                    {
                        MenuPermission objMenuPermission = new MenuPermission();

                        objMenuPermission.CanView = true;
                        objMenuPermission.MainModuleMenuHeadID = MenuHeadID;
                        objMenuPermission.SubMenuHeadID = 0;
                        objMenuPermission.UserGroupID = ddlUserGroupName.SelectedValue;
                        objMenuPermission.PageID = 0;
                        success = objMenuPermissionBLL.MenuPermission_Add(objMenuPermission);
                    }

                }
            }
        }

        if (success > 0)
        {

            string myScript123 = "";
            myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
            LoadUserGroup();
            BindMenuHead();

        }
    }
}