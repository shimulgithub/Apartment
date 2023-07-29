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


public partial class Setting_UserActionPermission : System.Web.UI.Page
{
    MenuHeadBLL objMenuHeadBLL = new MenuHeadBLL();
    MenuPageBLL objMenuPageBLL = new MenuPageBLL();
    MenuPermissionBLL objMenuPermissionBLL = new MenuPermissionBLL();

    UserWiseVarsionName_ListBLL objUserWiseVarsionName_ListBLL = new UserWiseVarsionName_ListBLL();
    UserWiseVarsionName_ListBOL objUserWiseVarsionName_ListBOL = new UserWiseVarsionName_ListBOL();
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
                ddlUser.SelectedValue = "0";
                ddlReportsName.SelectedValue = "0";
                Session["breadcrumb"] = "Settings > Pages > User Avtion Permission";

                if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
                {
                    LoadAllReportsName(Session["UID"].ToString());
                    LoadUserByUser(Session["UID"].ToString());
                }
                else
                {
                    LoadAllReportsName(Session["UID"].ToString());
                    LoadUser();
                }

                if (ddlReportsName.SelectedValue == "1022")
                {
                    BA.Visible = true;
                    AR.Visible = false;
                }
                else
                {
                    BA.Visible = false;
                    AR.Visible = false;
                }
                if (ddlReportsName.SelectedValue == "1026")
                {
                    AR.Visible = true;
                    BA.Visible = false;
                }
                else
                {
                    AR.Visible = false;
                    BA.Visible = false;
                }
                ASDR.Visible = false;
                NetPay.Visible = false;

                hfPageId.Value = "0";
                hfUserID.Value = "0";
                hfVersoinAutoID.Value = "0";
                hfVersoinName.Value = "0";
                //VersoinName
                if (Request.QueryString["PageId"] != null && Request.QueryString["UserID"] != null && Request.QueryString["VersoinAutoID"] != null && Request.QueryString["VersoinName"] != null)
                {
                    hfPageId.Value = Request.QueryString["PageId"].ToString();
                    hfUserID.Value = Request.QueryString["UserID"].ToString();
                    hfVersoinAutoID.Value = Request.QueryString["VersoinAutoID"].ToString();
                    hfVersoinName.Value = Request.QueryString["VersoinName"].ToString();

                    BindVersoinInfo(hfPageId.Value, hfUserID.Value, hfVersoinAutoID.Value, hfVersoinName.Value);
                }
                else
                {
                    hfPageId.Value = "0";
                    hfUserID.Value = "0";
                    hfVersoinAutoID.Value = "0";
                    hfVersoinName.Value = "0";
                }

                // BindMenuHead();
            }



        }
        else
        {
            Response.Redirect("~/frmlogin.aspx");
        }

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        // Response.Redirect(Request.RawUrl);


        //Response.Redirect(Request.Url.ToString());
        hfPageId.Value = "0";
        hfUserID.Value = "0";
        hfVersoinAutoID.Value = "0";
        hfVersoinName.Value = "0";
        LoadAllReportsName(Session["UID"].ToString());
        LoadUser();
        BindMenuHead();
        txtVersionName.Text = "";
        ddlUser.Enabled = true;
        ddlReportsName.Enabled = true;
        txtVersionName.Enabled = true;
        Response.Redirect(String.Format("UserWiseColumnPremission"));

    }

    protected void BindVersoinInfo(string PageId, string UserID, string VersoinAutoID, string VersoinName)
    {
        ddlReportsName.SelectedValue = "0";
        ddlUser.SelectedValue = "0";
        txtVersionName.Text = string.Empty;

        gvAllModule.DataSource = null;
        gvAllModule.DataBind();

        DataTable dt = new DataTable();

        ddlReportsName.SelectedValue = PageId;
        ddlUser.SelectedValue = UserID;
        txtVersionName.Text = VersoinName;

        objUserWiseVarsionName_ListBOL.VersoinAutoID = Convert.ToInt32(VersoinAutoID);
        objUserWiseVarsionName_ListBOL.UserID = Convert.ToInt32(ddlUser.SelectedValue);

        objUserWiseVarsionName_ListBOL.PageId = Convert.ToInt32(ddlReportsName.SelectedValue);

        //objUserWiseVarsionName_ListBOL.CreateBy = Session["UserID"].ToString();
        string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));
        objUserWiseVarsionName_ListBOL.TableName = tableN;

        dt = objUserWiseVarsionName_ListBLL.UserWiseVarsionName_ListGVEdit(objUserWiseVarsionName_ListBOL);
        //dt = oUserBLL.GetUserInfoByUserID(UserAutoID);

        ddlUser.Enabled = false;
        ddlReportsName.Enabled = false;
        txtVersionName.Enabled = false;

        gvAllModule.DataSource = dt;
        gvAllModule.DataBind();
    }
    //private void LoadUserGroup()
    //{
    //    DataTable dt = new DataTable();
    //    string sql = "SP_TB_UserGroup_GetAllDataForDDL";
    //    dt = Global.GetData(sql);
    //    ddlUserGroupName.DataSource = dt;
    //    ddlUserGroupName.DataTextField = "UserGroupName";
    //    ddlUserGroupName.DataValueField = "UserGroupID";
    //    ddlUserGroupName.DataBind();

    //}
    private void LoadUserByUser(string uid)
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_User_GetUserIdForDDL";
        dt = Global.CreateDataTableParameter(sql, uid);
        ddlUser.DataSource = dt;
        ddlUser.DataTextField = "UserFullName";
        ddlUser.DataValueField = "Id";
        ddlUser.DataBind();

    }

    private void LoadUser()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_User_GetAllDataForDDL";
        dt = Global.GetData(sql);
        ddlUser.DataSource = dt;
        ddlUser.DataTextField = "UserFullName";
        ddlUser.DataValueField = "Id";
        ddlUser.DataBind();

    }
    private void LoadAllReportsName(string uid)
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_ReportsColumnHead_GetForDDL";
        dt = Global.CreateDataTableParameter(sql, uid);
        ddlReportsName.DataSource = dt;
        ddlReportsName.DataTextField = "PageName";
        ddlReportsName.DataValueField = "PageId";
        ddlReportsName.DataBind();

    }
    protected void ddlAssignmentRates_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;

        if (ddlUser.SelectedValue == "0" || ddlReportsName.SelectedValue == "0")
        {
            //BindMenuHead();
        }
        else
        {
            string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
,TCPe.[ColumnPermissionID]
      ,TCPe.[UserId]
      ,TCPe.[PageId]
      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
	  
CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView , convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll  FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "') TCPe ON   MrgH.AutoID  =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";


                    //SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // con.Close();
                    gvAllModule.DataSource = ds;
                    gvAllModule.DataBind();


                    LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkUp.CssClass = "buttonlinkud disabled";
                    lnkDown.Enabled = false;
                    lnkDown.CssClass = "buttonlinkud disabled";

                }
            }

            //BindMenuHead();
            // BindMenuHeadByUserID();
        }

        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());


        }
        else
        {

            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();

        }

        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;

        if (ddlReportsName.SelectedValue == "1026")
        {
            AR.Visible = true;
        }
        else
        {
            AR.Visible = false;
        }
    }

    protected void ddlBillingCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;

        if (ddlUser.SelectedValue == "0" || ddlReportsName.SelectedValue == "0")
        {
            //BindMenuHead();
        }
        else
        {
            string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
,TCPe.[ColumnPermissionID]
      ,TCPe.[UserId]
      ,TCPe.[PageId]
      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
	  
CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView , convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll  FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "') TCPe ON   MrgH.AutoID  =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";


                    //SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // con.Close();
                    gvAllModule.DataSource = ds;
                    gvAllModule.DataBind();


                    LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkUp.CssClass = "buttonlinkud disabled";
                    lnkDown.Enabled = false;
                    lnkDown.CssClass = "buttonlinkud disabled";

                }
            }

            //BindMenuHead();
            // BindMenuHeadByUserID();
        }

        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());


        }
        else
        {

            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();

        }

        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;

        if (ddlReportsName.SelectedValue == "1022")
        {
            BA.Visible = true;
        }
        else
        {
            BA.Visible = false;
        }
    }

    protected void ddlReportsName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;

        if (ddlUser.SelectedValue == "0" || ddlReportsName.SelectedValue == "0")
        {
            //BindMenuHead();
        }
        else
        {
            string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
,TCPe.[ColumnPermissionID]
      ,TCPe.[UserId]
      ,TCPe.[PageId]
      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
	  
CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView , convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll  FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ) TCPe ON   MrgH.AutoID  =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";


                    //SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // con.Close();
                    gvAllModule.DataSource = ds;
                    gvAllModule.DataBind();


                    LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkUp.CssClass = "buttonlinkud disabled";
                    lnkDown.Enabled = false;
                    lnkDown.CssClass = "buttonlinkud disabled";

                }
            }

            //BindMenuHead();
            // BindMenuHeadByUserID();
        }

        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());


        }
        else
        {

            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();

        }

        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;

        if (ddlReportsName.SelectedValue == "1022")
        {
            BA.Visible = true;
        }
        else
        {
            BA.Visible = false;
        }

        if (ddlReportsName.SelectedValue == "1026")
        {
            AR.Visible = true;

        }
        else
        {
            AR.Visible = false;

        }
        if (ddlReportsName.SelectedValue == "1047")
        {
            ASDR.Visible = true;

        }
        else
        {
            ASDR.Visible = false;

        }

        if (ddlReportsName.SelectedValue == "1063")
        {
            NetPay.Visible = true;

        }
        else
        {
            NetPay.Visible = false;

        }

    }
    protected void ddlAssignmentLeave_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;

        if (ddlUser.SelectedValue == "0" || ddlReportsName.SelectedValue == "0")
        {
            //BindMenuHead();
        }
        else
        {
            string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;

                string sql = "";
                sql = @" 
        Declare @UserGroupID int
        SET @UserGroupID=(SELECT  [UserGroupID]  FROM [DB_SMP].[dbo].[TB_User] WHERE Id=@UserId)
        SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority--,TCPe.[ColumnPermissionGroupWiseID],TCPe.[UserGroupID],TCPe.[PageId]
        --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,--,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,	  
        --CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority--,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView  
        ,TCPe1.[ColumnPermissionID],TCPe1.[UserID],TCPe1.[PageId]--,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
        ,CASE WHEN TCPe1.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe1.ColumnHeadAutoID END  ColumnHeadAutoID,	  
        CASE WHEN TCPe1.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe1.Order_Priority END  U_Order_Priority
        ,TCPe1.[CanView],ISNULL(TCPe1.CanView,0) CView  
        ,convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  
        WHERE PageId=@PageId AND UserId= @UserId AND ISNULL(VersoinAutoID,0)=@VersoinAutoID ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll 
        FROM DB_SMP.dbo." + tableN + "   MrgH   LEFT OUTER JOIN (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission_UserGroupWise  WHERE PageId=@PageId AND UserGroupID= @UserGroupID ) TCPe ON MrgH.AutoID =TCPe.ColumnHeadAutoID   LEFT OUTER JOIN (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId=@PageId AND UserId =@UserId AND ISNULL(VersoinAutoID,0)=@VersoinAutoID ) TCPe1 ON TCPe.ColumnHeadAutoID =TCPe1.ColumnHeadAutoID    AND TCPe.PageId =TCPe1.PageId   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe1.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    //                using (SqlCommand cmd = new SqlCommand())
                    //                {
                    //                    cmd.CommandText = @"
                    //SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
                    //,TCPe.[ColumnPermissionID]
                    //      ,TCPe.[UserId]
                    //      ,TCPe.[PageId]
                    //      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
                    //,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
                    //	  
                    //CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
                    //      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView , convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll  FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "') TCPe ON   MrgH.AutoID  =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";


                    //SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = ddlUser.SelectedValue;
                    cmd.Parameters.Add("@PageId", SqlDbType.NVarChar).Value = ddlReportsName.SelectedValue;
                    cmd.Parameters.Add("@VersoinAutoID", SqlDbType.NVarChar).Value = hfVersoinAutoID.Value;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // con.Close();
                    gvAllModule.DataSource = ds;
                    gvAllModule.DataBind();

                    LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkUp.CssClass = "buttonlinkud disabled";
                    lnkDown.Enabled = false;
                    lnkDown.CssClass = "buttonlinkud disabled";

                }
            }

            //BindMenuHead();
            // BindMenuHeadByUserID();
        }

        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());


        }
        else
        {

            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();

        }

        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;

        if (ddlReportsName.SelectedValue == "1047")
        {
            ASDR.Visible = true;
        }
        else
        {
            ASDR.Visible = false;
        }
    }
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {

        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;
        if (ddlUser.SelectedValue == "0" || ddlReportsName.SelectedValue == "0")
        {
            //BindMenuHead();
        }
        else
        {
            string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
,TCPe.[ColumnPermissionID]
      ,TCPe.[UserId]
      ,TCPe.[PageId]
      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
	  
CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView 
,  convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ) TCPe ON    MrgH.AutoID =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";


                    //SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // con.Close();
                    gvAllModule.DataSource = ds;
                    gvAllModule.DataBind();


                    LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkUp.CssClass = "buttonlinkud disabled";
                    lnkDown.Enabled = false;
                    lnkDown.CssClass = "buttonlinkud disabled";

                }
            }

            //BindMenuHead();
            // BindMenuHeadByUserID();
        }

        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());


        }
        else
        {

            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();

        }

        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;
    }

    protected void gvAllModule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            // CheckBox chkBoxHeader = ((CheckBox)e.Row.FindControl("ChkAll"));

            //GridView gvAllModule_ = ((GridView)e.Row.FindControl("gvAllModule"));
            Label lblHeader = ((Label)e.Row.FindControl("lblSelectAll"));

            if (lblHeader.Text == "True")
            {

                CheckBox ckall = (CheckBox)gvAllModule.HeaderRow.FindControl("ChkAll");
                ckall.Checked = true;
            }
            else
            {
                CheckBox ckall = (CheckBox)gvAllModule.HeaderRow.FindControl("ChkAll");
                ckall.Checked = false;
            }
        }


        //if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        //{
        //    Label lblMainModuleMenuHeadID = ((Label)e.Row.FindControl("lblPageId"));

        //    Label lblPageName = ((Label)e.Row.FindControl("lblPageName"));

        //   // Label lblHeader = ((Label)e.Row.FindControl("lblHeader"));

        //    CheckBox ChkAll = ((CheckBox)e.Row.FindControl("ChkAll"));

        //    CheckBoxList chkFields = ((CheckBoxList)e.Row.FindControl("chkFields"));
        //    GridView gvUserInfo = ((GridView)e.Row.FindControl("gvUserInfo"));



        //    int headID = Convert.ToInt32(lblMainModuleMenuHeadID.Text);

        //    //DataSet ds = objMenuPageBLL.ColumnNamePage_GetAllByHeadID(headID, ddlUser.SelectedValue);

        //    //DataTable dtop = new DataTable();

        //    //dtop = ds.Tables[0];
        //    //if (dtop.Rows.Count > 0)
        //    //{
        //    //    ((GridView)e.Row.FindControl("gvSubMenuHead")).DataSource = dtop;
        //    //    ((GridView)e.Row.FindControl("gvSubMenuHead")).DataBind();
        //    //}
        //    //else
        //    //{
        //    //    dtop = null;
        //    //    chkBoxHeader.Visible = false;

        //    //    ((GridView)e.Row.FindControl("gvSubMenuHead")).DataSource = dtop;
        //    //    ((GridView)e.Row.FindControl("gvSubMenuHead")).DataBind();
        //    //}

        //    string tableN = BindColumnHead(Convert.ToString(headID));



        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ConfigurationManager
        //                .ConnectionStrings["ConS2pibd"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = @"SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + headID + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
        //            cmd.Connection = conn;
        //            conn.Open();

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //           // con.Close();
        //            gvUserInfo.DataSource = ds;
        //            gvUserInfo.DataBind();


        //            LinkButton lnkUp = (gvUserInfo.Rows[0].FindControl("lnkUp") as LinkButton);
        //            LinkButton lnkDown = (gvUserInfo.Rows[gvUserInfo.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
        //            lnkUp.Enabled = false;
        //            lnkUp.CssClass = "buttonlinkud disabled";
        //            lnkDown.Enabled = false;
        //            lnkDown.CssClass = "buttonlinkud disabled";



        //            //GridViewRow FirstRow = gvUserInfo.Rows[0];
        //            //LinkButton btnUp = (LinkButton)FirstRow.FindControl("btnUp");
        //            //btnUp.Enabled = false;
        //            //GridViewRow LastRow = gvUserInfo.Rows[gvUserInfo.Rows.Count - 1];
        //            //Button btnDown = (Button)LastRow.FindControl("btnDown");
        //            //btnDown.Enabled = false;

        //            //using (SqlDataReader sdr = cmd.ExecuteReader())
        //            //{
        //            //    while (sdr.Read())
        //            //    {
        //            //        System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
        //            //        item.Text = sdr["HeaderText"].ToString();
        //            //        item.Value = sdr["AutoID"].ToString();
        //            //        item.Selected = Convert.ToBoolean(sdr["CView"]);
        //            //        //item.Selected = true; // Convert.ToBoolean(sdr["IsSelected"]);
        //            //        chkFields.Items.Add(item);
        //            //    }
        //            //}
        //            conn.Close();
        //        }
        //    }




        //}
    }

    private void UpdatePreference(int locationId, int preference, int VersoinAutoID)
    {
        string constr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE [DB_SMP].[dbo].[TB_ColumnPermission] SET Order_Priority = @Preference WHERE  ColumnHeadAutoID=@uppreference AND [UserId]=@UserId AND [PageId]=@RptId AND VersoinAutoID=@VersoinAutoID"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserId", ddlUser.SelectedValue);
                    cmd.Parameters.AddWithValue("@RptId", ddlReportsName.SelectedValue);
                    cmd.Parameters.AddWithValue("@Preference", preference);
                    cmd.Parameters.AddWithValue("@uppreference", locationId);
                    cmd.Parameters.AddWithValue("@VersoinAutoID", VersoinAutoID);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }

    protected void ChangePreference(object sender, EventArgs e)
    {

        string commandArgument = (sender as LinkButton).CommandArgument;


        int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
        int locationId = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].Text);
        int preference = Convert.ToInt32(gvAllModule.DataKeys[rowIndex].Value);
        preference = commandArgument == "up" ? preference - 1 : preference + 1;


        this.UpdatePreference(locationId, preference, Convert.ToInt32(hfVersoinAutoID.Value));

        rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
        locationId = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].Text);
        preference = Convert.ToInt32(gvAllModule.DataKeys[rowIndex].Value);
        preference = commandArgument == "up" ? preference + 1 : preference - 1;
        this.UpdatePreference(locationId, preference, Convert.ToInt32(hfVersoinAutoID.Value));

        // LinkButton lnkPatientID = sender as LinkButton;
        // //Button btnEdit = (Button)sender;

        // GridViewRow Grow = (GridViewRow)lnkPatientID.NamingContainer;


        //// GridView GrowR = (GridView)lnkPatientID.NamingContainer;

        // string AutoId = lnkPatientID.CommandArgument;

        //// string chkSelect =  GrowR[iRow].Cells[0].FindControl("chkSelect&");

        // //Response.Redirect(String.Format("EditPatientRegistration?Pautoid={0}",
        // //    Server.UrlEncode(lnkPatientID.CommandArgument)));

        // string CName = lnkPatientID.CommandName;

        // //string commandArgument = (sender as LinkButton).CommandArgument;
        // int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;


        // //string str = gvAllModule.Rows[rowIndex].Cells[0].Text;
        // //string str1 = gvAllModule.Rows[rowIndex].Cells[1].Text;
        // //string str2 = gvAllModule.Rows[rowIndex].Cells[2].Text;
        // //string str3 = gvAllModule.Rows[rowIndex].Cells[3].Text;
        // //string str4 = gvAllModule.Rows[rowIndex].Cells[4].Text;   
        // int AutoID = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].Text); //Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].FindControl("lblAutoID"));   
        // int Order_Priority = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[1].Text); //Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].FindControl("lblAutoID"));   

        // int ColumnPermissionID = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[2].Text); //Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].FindControl("lblAutoID"));   
        // int ColumnHeadAutoID = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[3].Text); //Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].FindControl("lblAutoID"));   


        // //int preference = Convert.ToInt32(gvAllModule.DataKeys[rowIndex].Value  );
        //// int uppreference = Order_Priority;
        // Order_Priority = CName == "up" ? Order_Priority - 1 : Order_Priority + 1;
        // ColumnHeadAutoID = CName == "up" ? ColumnHeadAutoID - 1 : ColumnHeadAutoID + 1;

        // this.UpdatePreference(AutoID, Order_Priority, ColumnPermissionID, ColumnHeadAutoID);

        // rowIndex = CName == "up" ? rowIndex - 1 : rowIndex + 1;
        // AutoID = Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].Text); //Convert.ToInt32(gvAllModule.Rows[rowIndex].Cells[0].FindControl("lblAutoID"));  
        // Order_Priority = Convert.ToInt32(gvAllModule.DataKeys[rowIndex].Value);
        // uppreference = Order_Priority;
        // Order_Priority = CName == "up" ? Order_Priority + 1 : Order_Priority - 1;
        // this.UpdatePreference(AutoID, Order_Priority, uppreference);




        string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["ConS2pibd"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
,TCPe.[ColumnPermissionID]
      ,TCPe.[UserId]
      ,TCPe.[PageId]
      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID,
,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
	  
CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView 
 , convert(bit,  CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ) TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'  order by ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";


                //SELECT MrgH.*,TCPe.*,ISNULL(TCPe.CanView,0) CView FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "') TCPe ON  MrgH.AutoID  =TCPe.ColumnHeadAutoID   order by MrgH.Order_Priority ASC ";
                cmd.Connection = conn;
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                // con.Close();
                gvAllModule.DataSource = ds;
                gvAllModule.DataBind();


                LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                lnkUp.Enabled = false;
                lnkUp.CssClass = "buttonlinkud disabled";
                lnkDown.Enabled = false;
                lnkDown.CssClass = "buttonlinkud disabled";

            }
        }




        //  Response.Redirect(Request.Url.AbsoluteUri);


        // LinkButton lnkPayment = sender as LinkButton;

        // GridViewRow Grow = (GridViewRow)lnkPayment.NamingContainer;

        // //Label lblFirstName = (Label)e.Row.FindControl("lblFirstName");

        // Label lblFirstName = (Label)Grow.FindControl("lblFirstName");


        // LinkButton commandArgument =  sender as LinkButton ;
        // GridView gvLocations = (GridView)commandArgument.NamingContainer;

        // int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
        // int locationId = Convert.ToInt32(gvLocations.Rows[rowIndex].Cells[0].Text);
        // int preference = Convert.ToInt32(gvLocations.DataKeys[rowIndex].Value);

        // preference = commandArgument == "up" ? preference - 1 : preference + 1;
        //// this.UpdatePreference(locationId, preference);

        // rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
        // locationId = Convert.ToInt32(gvLocations.Rows[rowIndex].Cells[0].Text);
        // preference = Convert.ToInt32(gvLocations.DataKeys[rowIndex].Value);
        // preference = commandArgument == "up" ? preference + 1 : preference - 1;
        //// this.UpdatePreference(locationId, preference);

        // Response.Redirect(Request.Url.AbsoluteUri);



        // LinkButton commandArgument = sender as LinkButton ;
        // LinkButton lnkPayment = sender as LinkButton;

        // GridView gvLocations = (GridView)commandArgument.NamingContainer;

        // //Label lblFirstName = (Label)e.Row.FindControl("lblFirstName");

        // //Label lblFirstName = (Label)gvLocations.FindControl("lblFirstName");

        // int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        //CheckBox cb = (CheckBox)sender;
        //GridViewRow row = (GridViewRow)cb.NamingContainer;
        //GridView gv = (GridView)row.NamingContainer;

        //string taskStepID = gv.DataKeys[row.RowIndex].Value.ToString();
        //string taskStepID = gv.Rows[rowIndex].Cells[0].Text;


        //int locationId = Convert.ToInt32(gvLocations.Rows[rowIndex].Cells[0].Text);
        //int preference = Convert.ToInt32(gvLocations.DataKeys[rowIndex].Value);

        //preference = commandArgument == "up" ? preference - 1 : preference + 1;
        //this.UpdatePreference(locationId, preference);

        //rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
        //locationId = Convert.ToInt32(gvLocations.Rows[rowIndex].Cells[0].Text);
        //preference = Convert.ToInt32(gvLocations.DataKeys[rowIndex].Value);
        //preference = commandArgument == "up" ? preference + 1 : preference - 1;
        //this.UpdatePreference(locationId, preference);

        //Response.Redirect(Request.Url.AbsoluteUri);

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
        if (TableNameID == "1022" && ddlBillingCountryID.SelectedValue == "0")
            TableName = "ClientsDetailsWithOutBillingAddress_Header";
        if (TableNameID == "1022" && ddlBillingCountryID.SelectedValue == "1")
            TableName = "ClientsDetailsWithBillingAddress_Header";
        if (TableNameID == "1023")
            TableName = "SuppliersDetails_Header";
        if (TableNameID == "1026" && ddlAssignmentRates.SelectedValue == "0")
            TableName = "AssignmentDetailsList_Header";
        if (TableNameID == "1026" && ddlAssignmentRates.SelectedValue == "1")
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

        if (TableNameID == "1047" && ddlAssignmentLeave.SelectedValue == "0")
            TableName = "AssignmentDetailsWithLeaveInformation_Header";

        if (TableNameID == "1047" && ddlAssignmentLeave.SelectedValue == "1")
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

        if (TableNameID == "1063" && ddlNetPayDetailes.SelectedValue == "0")
            TableName = "NetPayReports_SummaryHeader";

        if (TableNameID == "1063" && ddlNetPayDetailes.SelectedValue == "1")
            TableName = "NetPayReports_DetailsHeader";

        if (TableNameID == "1065")

            TableName = "NominalTransactionsView_Header";


        return TableName;
    }

    protected void gvSubMenuHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {

            //    Label lblSubMenuHeadID = ((Label)e.Row.FindControl("lblSubMenuHeadID"));
            //    CheckBox chkBoxPages = ((CheckBox)e.Row.FindControl("chkBoxPages"));
            //   //Label lblModuleSubMenuHeadID = ((Label)e.Row.FindControl("lblModuleSubMenuHeadID"));
            //   //Label lblHeader = ((Label)e.Row.FindControl("lblHeader"));
            //    int headID = Convert.ToInt32(lblSubMenuHeadID.Text);
            //    DataTable dtPages = new DataTable();
            //    dtPages = objMenuPageBLL.SubMenuPage_GetAllByHeadID(headID, ddlUser.SelectedValue);

            //   if (dtPages.Rows.Count > 0)
            //    {
            //        ((GridView)e.Row.FindControl("gvPagesMain")).DataSource = dtPages;
            //        ((GridView)e.Row.FindControl("gvPagesMain")).DataBind();
            //    }
            //    else
            //    {
            //        dtPages = null;
            //        chkBoxPages.Visible = false;
            //        ((GridView)e.Row.FindControl("gvPagesMain")).DataSource = dtPages;
            //        ((GridView)e.Row.FindControl("gvPagesMain")).DataBind();
            //    }

        }

    }
    protected void gvPagesMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    private void BindMenuHead()
    {
        List<MenuHead> listHeader = objMenuHeadBLL.ColumnHead_GetAll(ddlUser.SelectedValue, ddlReportsName.SelectedValue);
        gvAllModule.DataSource = listHeader;
        gvAllModule.DataBind();

        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;
        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());

        }
        else
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();

        }
        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;
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
    }

    protected void ExpandButton_Click(object sender, EventArgs e)
    {
        GridViewRow myRow = ((Control)sender).NamingContainer as GridViewRow;
        ImageButton expandBtn = sender as ImageButton;
        Panel KeysPanel = ((Panel)myRow.FindControl("KeysPanel"));

        if (expandBtn.ImageUrl == "~/Images/plus.png")
        {
            expandBtn.ImageUrl = "~/Images/minus.png";
            // Panel pnl = myRow.Cells[5].Controls[0].FindControl("KeysPanel") as Panel;
            KeysPanel.Visible = true;
        }
        else
        {
            expandBtn.ImageUrl = "~/Images/plus.png";
            //Panel pnl = myRow.Cells[5].Controls[0].FindControl("KeysPanel") as Panel;
            KeysPanel.Visible = false;
        }
    }

    protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox ChkAll = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkAll.NamingContainer;
        GridView gv = (GridView)row.NamingContainer;

        // string taskStepID = gv.DataKeys[row.RowIndex].Value.ToString();


        // GridView gr = grid.FindControl("gvAllModule") as GridView;



        //CheckBox ChkAll = ((CheckBox)gv.FindControl("ChkAll"));

        if (ChkAll.Checked == true)
        {

            foreach (GridViewRow Row in gv.Rows)
            {
                if (Row.RowType == DataControlRowType.DataRow)
                {


                    (Row.FindControl("chkBoxPagesOP") as CheckBox).Checked = ChkAll.Checked;

                }
            }

        }

        else
        {
            foreach (GridViewRow Row in gv.Rows)
            {
                if (Row.RowType == DataControlRowType.DataRow)
                {


                    (Row.FindControl("chkBoxPagesOP") as CheckBox).Checked = false;

                }
            }

        }




        //CheckBox cb = (CheckBox)sender;
        //GridViewRow row = (GridViewRow)cb.NamingContainer;
        //GridView gv = (GridView)row.NamingContainer;

        //string taskStepID = gv.DataKeys[row.RowIndex].Value.ToString();


        //GridView gr = grid.FindControl("gvAllModule") as GridView;

        //foreach (GridViewRow grid in gvAllModule.Rows)
        //{
        //    GridView gr = grid.FindControl("gvUserInfo") as GridView;
        //    //CheckBox chk = gr.FindControl("ChkAll") as CheckBox;
        //    CheckBox ChkAll = ((CheckBox)gr.FindControl("ChkAll"));

        //    if (ChkAll.Checked == true)
        //    {
        //        //    (gr.FindControl("chkBoxPagesOP") as CheckBox).Checked = ChkAll.Checked;
        //        //}
        //        foreach (GridViewRow gvRow in gr.Rows)
        //        {
        //            (gvRow.FindControl("chkBoxPagesOP") as CheckBox).Checked = ChkAll.Checked;
        //        }
        //    }

        //}

        //CheckBox chkAll = (sender as CheckBox);
        //GridViewRow row = chkAll.NamingContainer as GridViewRow;

        //GridView gv = row.FindControl("gvUserInfo") as GridView;

        //CheckBox ChkAll = ((CheckBox)row.FindControl("ChkAll"));

        //CheckBoxList chkFields = ((CheckBoxList)row.FindControl("chkFields"));

        //ImageButton imgShowHide = (sender as ImageButton);
        ////GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);

        //foreach (GridViewRow gvRow in gv.Rows)
        //{
        //         (gvRow.FindControl("chkBoxPagesOP") as CheckBox).Checked = chkAll.Checked;
        //     //(gvRow.FindControl("chkBoxPages") as CheckBox).CheckedChanged += new EventHandler(chkBoxPages_CheckedChanged);
        //    // chkBoxPages_CheckedChanged(sender, e);

        //    //GridView gv1 = gvRow.FindControl("gvPagesMain") as GridView;

        //    //foreach (GridViewRow gvRow1 in gv1.Rows)
        //    //{
        //    //    (gvRow1.FindControl("chkBoxPagesOP") as CheckBox).Checked = chkAll.Checked;
        //    //}

        //    //(gvRow.FindControl("chkBoxPages") as CheckBox).CheckedChanged += new EventHandler(chkBoxPages_CheckedChanged);
        //}
        //if (ChkAll.Checked == true)
        //{
        //    foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
        //    {
        //        item.Selected = true;

        //    }
        //}
        //else
        //{
        //    foreach (System.Web.UI.WebControls.ListItem item in chkFields.Items)
        //    {

        //        item.Selected = false;


        //    }
        //}

        //GridView gvsE = row.FindControl("gvPagesSetup") as GridView;
        //foreach (GridViewRow gvRow in gvsE.Rows)
        //{
        //    //(gvRow.FindControl("chkBoxPages") as CheckBox).Checked = chkAll.Checked;
        //    (gvRow.FindControl("chkBoxPagesSe") as CheckBox).Checked = chkAll.Checked;

        //    GridView gv1 = gvRow.FindControl("gvPagesMainSe") as GridView;

        //    foreach (GridViewRow gvRow1 in gv1.Rows)
        //    {
        //        (gvRow1.FindControl("chkBoxPagesSet") as CheckBox).Checked = chkAll.Checked;

        //    }

        //    //(gvRow.FindControl("chkRowDelete") as CheckBox).Checked = chkAll.Checked;
        //}

        //GridView gvrE = row.FindControl("gvPagesRe") as GridView;
        //foreach (GridViewRow gvRow in gvrE.Rows)
        //{
        //    (gvRow.FindControl("chkBoxPagesRe") as CheckBox).Checked = chkAll.Checked;
        //    // (gvRow.FindControl("chkBoxPagesSe") as CheckBox).Checked = chkAll.Checked;
        //    //(gvRow.FindControl("chkRowDelete") as CheckBox).Checked = chkAll.Checked;

        //    GridView gv1 = gvRow.FindControl("gvPagesMainRe") as GridView;

        //    foreach (GridViewRow gvRow1 in gv1.Rows)
        //    {
        //        (gvRow1.FindControl("chkBoxPagesRep") as CheckBox).Checked = chkAll.Checked;

        //    }

        //}



    }



    protected void btnPermission_Click(object sender, EventArgs e)
    {

        if (ddlUser.SelectedIndex == 0)
        {
            lblMessage.Text = "Sorry! Please Select User.";
            //lblMessage.ForeColor = Color.Red;
            return;
        }

        if (ddlReportsName.SelectedIndex == 0)
        {
            lblMessage.Text = "Sorry! Please Select Reports Name.";
            //lblMessage.ForeColor = Color.Red;
            return;
        }


        //if (gvAllModule.Rows.Count > 0)
        //{
        //    for (int i = 0; i < gvAllModule.Rows.Count; i++)
        //    {
        //        if (((CheckBox)gvAllModule.Rows[i].FindControl("chkBoxHeader")).Checked)
        //        {
        //            for (int j = 0; j < ((GridView)gvAllModule.Rows[i].FindControl("gvPages")).Rows.Count; j++)
        //            {
        //                if (((CheckBox)((GridView)gvAllModule.Rows[i].FindControl("gvPages")).Rows[j].FindControl("chkBoxPages")).Checked)
        //                {
        //                    checke = 1;
        //                    break;
        //                }
        //            }
        //            if (checke > 0)
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    if (checke <= 0)
        //    {
        //        lblMessage.Text = "Sorry! Please select menu";
        //        lblMessage.ForeColor = Color.Red;
        //        return;
        //    }

        Save();
        ddlUser.Enabled = true;
        ddlReportsName.Enabled = true;
        txtVersionName.Enabled = true;
        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());
        }
        else
        {

            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();
        }

        if (hfVersoinAutoID.Value != "0")
        {
            Response.Redirect(String.Format("UserWiseColumnPremission"));
        }


        //}

        // Save();
    }

    int pagesuccess = 0;

    private void Save()
    {
        int success = -1;

        int Versionid = 0;

        DataTable dtForNameAndRole = new DataTable();

        string userid = ddlUser.SelectedValue;
        string ReportsNameid = ddlReportsName.SelectedValue;

        if (hfVersoinAutoID.Value == "0")
        {
            dtForNameAndRole = objUserWiseVarsionName_ListBLL.VersionName_ExistByUserID(ddlUser.SelectedValue, txtVersionName.Text);
        }
        else
        {
            //dtForNameAndRole = null;
        }
        int ik = dtForNameAndRole.Rows.Count;

        if (dtForNameAndRole.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('Please Try Again, Version Name Already Exist For This User');", true);
            txtVersionName.Focus();
            ddlUser.SelectedValue = userid;
            ddlReportsName.SelectedValue = ReportsNameid;


            return;
        }
        else
        {
            if (hfVersoinAutoID.Value == "0")
            {
                if (txtVersionName.Text == "" || string.IsNullOrEmpty(txtVersionName.Text) || string.IsNullOrWhiteSpace(txtVersionName.Text))
                {
                    txtVersionName.Text = "0";
                    Versionid = 0;
                }
                else
                {
                    // txtVersionName.Text = "0";
                    objUserWiseVarsionName_ListBOL.VersoinName = txtVersionName.Text;
                    objUserWiseVarsionName_ListBOL.UserID = Convert.ToInt32(ddlUser.SelectedValue);
                    objUserWiseVarsionName_ListBOL.PageId = Convert.ToInt32(ddlReportsName.SelectedValue);
                    objUserWiseVarsionName_ListBOL.CreateBy = Session["UserID"].ToString();
                    Versionid = objUserWiseVarsionName_ListBLL.UserWiseVarsionName_List_Add(objUserWiseVarsionName_ListBOL);
                }


            }
            else
            {
                Versionid = Convert.ToInt32(hfVersoinAutoID.Value);
            }


            success = objMenuPermissionBLL.ColumnPermission_DeleteByUserID(ddlUser.SelectedValue, ddlReportsName.SelectedValue, Versionid);

            if (success >= 0)
            {
                success = 0;

                //     Boolean ch = (gvAllModule.HeaderRow.FindControl("ChkAll") as CheckBox).Checked;

                //     ViewState["Checked"] = (gvAllModule.HeaderRow.FindControl("ChkAll") as CheckBox).Checked;



                //if (ViewState["Checked"] != null)
                //{
                //    (gvAllModule.HeaderRow.FindControl("chkSelectAll") as CheckBox).Checked = (bool)ViewState["Checked"];
                //}



                int i = 0;

                MenuPermission objMenuPermission1 = new MenuPermission();

                objMenuPermission1.UserID = Convert.ToString(ddlUser.SelectedValue);
                objMenuPermission1.PageID = Convert.ToInt32(ddlReportsName.SelectedValue);
                objMenuPermission1.VersoinAutoID = Convert.ToInt32(Versionid);
                int AuditIdDel = objMenuPermissionBLL.MenuPermissionForAudit_Update(objMenuPermission1);


                foreach (GridViewRow gvAllP in gvAllModule.Rows)
                {
                    //GridView gr = gvAllP.FindControl("gvAllModule") as GridView;

                    //CheckBox ChkAll = ((CheckBox)gr.FindControl("ChkAll"));

                    //   Boolean ch = ChkAll.Checked;

                    //if ((gvAllModule.HeaderRow.FindControl("ChkAll") as CheckBox).Checked)
                    //{



                    //int[] LocationIdAutoID = (from p in Request.Form["LocationIdAutoID"].Split(',')
                    //                     select int.Parse(p)).ToArray();

                    //int[] LocationIdU_Order_Priority = (from p in Request.Form["LocationIdU_Order_Priority"].Split(',')
                    //                                    select int.Parse(p)).ToArray(); ;

                    //Int32 i1 = LocationIdAutoID[i];
                    //Int32 i2 = LocationIdU_Order_Priority[i];


                    Label lblAutoID = ((Label)gvAllP.FindControl("lblAutoID"));
                    Label lblOrder_Priority = ((Label)gvAllP.FindControl("lblOrder_Priority"));

                    Label lblU_Order_Priority = ((Label)gvAllP.FindControl("lblU_Order_Priority"));

                    TextBox txtU_Order_Priority = ((TextBox)gvAllP.FindControl("txtU_Order_Priority"));

                    //int PageId = Convert.ToInt32(lblPageId.Text);
                    CheckBox chkBoxPagesOP = ((CheckBox)gvAllP.FindControl("chkBoxPagesOP"));

                    if (lblU_Order_Priority.Text == "")
                    {
                        lblU_Order_Priority.Text = lblOrder_Priority.Text;
                    }
                    else
                    {
                        lblU_Order_Priority.Text = lblU_Order_Priority.Text;
                    }


                    if (txtU_Order_Priority.Text == "")
                    {
                        txtU_Order_Priority.Text = "0";
                    }
                    else
                    {
                        txtU_Order_Priority.Text = txtU_Order_Priority.Text;
                    }



                    if (chkBoxPagesOP.Checked)
                    {
                        MenuPermission objMenuPermission = new MenuPermission();
                        objMenuPermission.CanView = true;
                        objMenuPermission.UserID = Convert.ToString(ddlUser.SelectedValue);
                        objMenuPermission.PageID = Convert.ToInt32(ddlReportsName.SelectedValue);
                        objMenuPermission.ColumnHeadAutoID = Convert.ToInt32(lblAutoID.Text);
                        objMenuPermission.Order_Priority = Convert.ToInt32(txtU_Order_Priority.Text);


                        objMenuPermission.VersoinAutoID = Convert.ToInt32(Versionid);
                        objMenuPermission.CreateBy = Session["UserID"].ToString();

                        //objMenuPermission.ColumnHeadAutoID = Convert.ToInt32(i1);
                        //objMenuPermission.Order_Priority = Convert.ToInt32(i2);

                        success = objMenuPermissionBLL.MenuPermission_Add_Column(objMenuPermission);

                        objMenuPermission.AuditUserId = Convert.ToInt32(Session["UserID"].ToString());
                        objMenuPermission.TranStatus = 1;
                        objMenuPermission.Ref_Id = success;
                        objMenuPermission.AuditPageId = 1017;

                        int AuditId = objMenuPermissionBLL.MenuPermissionForAudit_Add_Column(objMenuPermission);
                    }
                    i++;

                    // }
                }
            }

            if (success > 0)
            {
                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);

                LoadAllReportsName(Session["UID"].ToString());
                LoadUser();
                BindMenuHead();
                txtVersionName.Text = "";

            }
            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();
            BindMenuHead();
            txtVersionName.Text = "";
        }
    }


    protected void ddlNetPayDetailes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlu = ddlUser.SelectedValue;
        string ddlRN = ddlReportsName.SelectedValue;

        if (ddlUser.SelectedValue == "0" || ddlReportsName.SelectedValue == "0")
        {
            //BindMenuHead();
        }
        else
        {
            string tableN = BindColumnHead(Convert.ToString(ddlReportsName.SelectedValue));

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConS2pibd"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"
SELECT MrgH.AutoID, MrgH.HeaderValue, MrgH.HeaderText, MrgH.Order_Priority
,TCPe.[ColumnPermissionID]
      ,TCPe.[UserId]
      ,TCPe.[PageId]
      --,ISNULL(TCPe.[ColumnHeadAutoID],'9999') AS ColumnHeadAutoID ,
,CASE WHEN TCPe.ColumnHeadAutoID IS NULL THEN  MrgH.AutoID ELSE TCPe.ColumnHeadAutoID END  ColumnHeadAutoID,
	  
CASE WHEN TCPe.Order_Priority IS NULL THEN  MrgH.Order_Priority ELSE TCPe.Order_Priority END  U_Order_Priority
      ,TCPe.[CanView],ISNULL(TCPe.CanView,0) CView , convert(bit, CASE WHEN  (ISNULL((SELECT count(*) FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "' ),0)) <> 0 THEN 1 ELSE 0 END) SelectAll  FROM DB_SMP.dbo." + tableN + " MrgH   LEFT OUTER JOIN  (SELECT * FROM DB_SMP.dbo.TB_ColumnPermission  WHERE PageId='" + ddlReportsName.SelectedValue + "' AND UserId= '" + ddlUser.SelectedValue + "' AND VersoinAutoID='" + hfVersoinAutoID.Value + "') TCPe ON   MrgH.AutoID  =TCPe.ColumnHeadAutoID   WHERE MrgH.HeaderValue <>'SelectAll'   order by   ISNULL(TCPe.[Order_Priority],'9999')  ASC , MrgH.Order_Priority ASC ";

                    cmd.Connection = conn;
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    // con.Close();
                    gvAllModule.DataSource = ds;
                    gvAllModule.DataBind();

                    LinkButton lnkUp = (gvAllModule.Rows[0].FindControl("lnkUp") as LinkButton);
                    LinkButton lnkDown = (gvAllModule.Rows[gvAllModule.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                    lnkUp.Enabled = false;
                    lnkUp.CssClass = "buttonlinkud disabled";
                    lnkDown.Enabled = false;
                    lnkDown.CssClass = "buttonlinkud disabled";

                }
            }
        }

        if (Session["UserRole"].ToString() == "1" || Session["UserRole"].ToString() == "2")
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUserByUser(Session["UID"].ToString());
        }
        else
        {
            LoadAllReportsName(Session["UID"].ToString());
            LoadUser();
        }

        ddlUser.SelectedValue = ddlu;
        ddlReportsName.SelectedValue = ddlRN;

        if (ddlReportsName.SelectedValue == "1063")
        {
            NetPay.Visible = true;
        }
        else
        {
            NetPay.Visible = false;
        }
    }
}