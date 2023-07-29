using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMP.BOL.Setting;
using SMP.BLL.Setting;
using SMP.Common;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Setting_NewUser : System.Web.UI.Page
{
    #region Variables

    UserBLL oUserBLL = new UserBLL();
    private string userID = "";
    private string userPassword = "";

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                btnsave.Visible = true;
                btnupdate.Visible = false;
                Session["breadcrumb"] = "User's Info";
                Clear();
                LoadUserGroup();
                LoadUserRole();

                if (Request.QueryString["UserId"] != null)
                {
                    hfUserId.Value = Request.QueryString["UserId"].ToString();
                }
                else
                {
                    hfUserId.Value = "0";
                }
                if (Request.QueryString["UserIdCopy"] != null)
                {
                    hfUserIdCopy.Value = Request.QueryString["UserIdCopy"].ToString();
                }
                else
                {
                    hfUserIdCopy.Value = "0";
                }

                btnsave.Visible = true;
                btnupdate.Visible = false;


                if (hfUserId.Value != "0")
                {
                    BindUserIdInfo(hfUserId.Value);
                    btnsave.Visible = false;
                    btnupdate.Visible = true;
                }

                if (hfUserIdCopy.Value != "0")
                {
                    BindUserIdInfoCopy(hfUserIdCopy.Value);
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                }
                //SystemUsageAuditLogInsert("1009");

            }
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }

    }



    //private void SystemUsageAuditLogInsert(string PageId)
    //{
    //    string DefaltGetWayIP = Convert.ToString(GetDefaultGateway());
    //    string DNSServerAddress = Convert.ToString(GetDnsAdress());

    //    // --------Local IP Address----
    //    string HostName = Dns.GetHostName();
    //    IPAddress[] ipaddress = Dns.GetHostAddresses(HostName);

    //    string PCMacAddress = ipaddress[0].ToString();
    //    string IPAddress = ipaddress[1].ToString();
    //    string LoginIPAddress = IPAddress + "-" + PCMacAddress;
    //    // --------Browser Version ----
    //    HttpRequest req = System.Web.HttpContext.Current.Request;
    //    string BrowserVersion = req.Browser.Browser + " " + req.Browser.Version;

    //    Int32 Id = Global.SystemUsageAuditLogInsert(IPAddress, BrowserVersion, PageId, Session["UserID"].ToString(), PCMacAddress);
    //}
    //private static IPAddress GetDnsAdress()
    //{
    //    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

    //    foreach (NetworkInterface networkInterface in networkInterfaces)
    //    {
    //        if (networkInterface.OperationalStatus == OperationalStatus.Up)
    //        {
    //            IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
    //            IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;

    //            foreach (IPAddress dnsAdress in dnsAddresses)
    //            {
    //                return dnsAdress;
    //            }
    //        }
    //    }

    //    throw new InvalidOperationException("Unable to find DNS Address");
    //}
    //public static IPAddress GetDefaultGateway()
    //{
    //    IPAddress result = null;
    //    var cards = NetworkInterface.GetAllNetworkInterfaces().ToList();
    //    if (cards.Any())
    //    {
    //        foreach (var card in cards)
    //        {
    //            var props = card.GetIPProperties();
    //            if (props == null)
    //                continue;

    //            var gateways = props.GatewayAddresses;
    //            if (!gateways.Any())
    //                continue;

    //            var gateway =
    //                gateways.FirstOrDefault(g => g.Address.AddressFamily.ToString() == "InterNetwork");
    //            if (gateway == null)
    //                continue;

    //            result = gateway.Address;
    //            break;
    //        };
    //    }

    //    return result;
    //}

    public string CheckUserName(string useroremail)
    {
        string retval = "";
        string connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;


        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [Id],[UserId],[UserName] FROM [DB_SMP].[dbo].[TB_User] where UserName=@UserName", con);
        cmd.Parameters.AddWithValue("@UserName", useroremail);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            retval = "true";
        }
        else
        {
            retval = "false";
        }

        return retval;
    }


    protected void BindUserIdInfoCopy(string UserAutoID)
    {
        Clear();
        DataTable dt = new DataTable();

        dt = oUserBLL.GetUserInfoByUserID(UserAutoID);

        if (dt.Rows.Count > 0)
        {
            //txtUserName.ReadOnly = true;
            //txtUserId.Text = dt.Rows[0]["UserId"].ToString();
            //txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            //txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();


            //string pass = dt.Rows[0]["Password"].ToString();
            //string ConfirmPa = dt.Rows[0]["ConfirmPassword"].ToString();
            //txtPassword.Attributes.Add("Value", pass);

            //txtConfirmPassword.Attributes.Add("Value", ConfirmPa);


            //txtUserAddress.Text = dt.Rows[0]["UserLocation"].ToString();
            hfUserIdCopy.Value = dt.Rows[0]["UsersAutoID"].ToString();
            //hfPrevuserID.Value = dt.Rows[0]["UserId"].ToString();


            //txtFullName.Text = dt.Rows[0]["UserFullName"].ToString();
            //txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();

            ddlUserRole.SelectedValue = dt.Rows[0]["TURole"].ToString();
            ddlUserGroupName.SelectedValue = dt.Rows[0]["TUUserGroupID"].ToString();

            if (Convert.ToBoolean(dt.Rows[0]["UserIsActive"].ToString()) == true)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            //if (ddlUserGroupName.SelectedValue != "0")
            //{
            //    chkAllColumn.Checked = true;
            //}
            //else
            //{
            //    chkAllColumn.Checked = false;
            //}

        }
        else
        {
            //txtSearch.Focus();
            //btnAdvanceCollection.Visible = false;
        }


    }

    protected void BindUserIdInfo(string UserAutoID)
    {
        Clear();
        DataTable dt = new DataTable();

        dt = oUserBLL.GetUserInfoByUserID(UserAutoID);

        if (dt.Rows.Count > 0)
        {
            txtUserName.ReadOnly = true;
            //chkAllColumn.Enabled = false;

            txtUserId.Text = dt.Rows[0]["UserId"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();


            string pass = dt.Rows[0]["Password"].ToString();
            string ConfirmPa = dt.Rows[0]["ConfirmPassword"].ToString();
            txtPassword.Attributes.Add("Value", pass);

            txtConfirmPassword.Attributes.Add("Value", ConfirmPa);


            txtUserAddress.Text = dt.Rows[0]["UserLocation"].ToString();
            hfUserId.Value = dt.Rows[0]["UsersAutoID"].ToString();
            hfPrevuserID.Value = dt.Rows[0]["UserId"].ToString();


            txtFullName.Text = dt.Rows[0]["UserFullName"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();

            ddlUserRole.SelectedValue = dt.Rows[0]["TURole"].ToString();
            ddlUserGroupName.SelectedValue = dt.Rows[0]["TUUserGroupID"].ToString();

            if (Convert.ToBoolean(dt.Rows[0]["UserIsActive"].ToString()) == true)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;

            }

            //if (ddlUserGroupName.SelectedValue != "0")
            //{
            //    chkAllColumn.Checked = false;
            //}
            //else
            //{
            //    chkAllColumn.Checked = false;
            //}


        }
        else
        {
            //txtSearch.Focus();
            //btnAdvanceCollection.Visible = false;
        }


    }

    private void LoadUserRole()
    {
        DataTable dt = new DataTable();
        string sql = "SP_TB_UserRoleByALLDDL";
        dt = Global.GetData(sql);
        ddlUserRole.DataSource = dt;
        ddlUserRole.DataTextField = "RoleName";
        ddlUserRole.DataValueField = "RoleID";
        ddlUserRole.DataBind();

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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        SaveData();

    }
    private void SaveData()
    {



        GenerateUserCode();
        User entity = new User();

        entity.UserName = txtUserName.Text.Trim();
        entity.EmailID = txtEmailID.Text.ToString();
        entity.Password = txtPassword.Text.ToString();
        entity.ConfirmPassword = txtConfirmPassword.Text.ToString();
        entity.UserFullName = txtFullName.Text;
        try
        {
            entity.MobileNo = txtMobileNo.Text;
        }
        catch
        {
            entity.MobileNo = null;
        }

        try
        {
            entity.UserGroupID = Convert.ToInt32(ddlUserGroupName.SelectedValue);
        }
        catch
        {
            entity.UserGroupID = 0;
        }


        try
        {
            entity.Role = Convert.ToInt32(ddlUserRole.SelectedValue);
        }
        catch
        {
            entity.Role = 0;
        }
        entity.UserLocation = txtUserAddress.Text.ToString();
        try
        {
            entity.CreateDate = DateTime.Now.Date;
        }
        catch { }
        try
        {
            entity.UpdateDate = DateTime.Now.Date;
        }
        catch { }

        if (chkIsActive.Checked == true)
        {
            entity.IsActive = true;
        }
        else
        {
            entity.IsActive = false;
        }


        Int32 Id = 0;
        if (string.IsNullOrEmpty(hfUserId.Value) || hfUserId.Value == "0")
        {

            string str = CheckUserName(txtUserName.Text);

            if (str == "true")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('User Name Already Exists.');", true);
                // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfuly posted.');", true);
                txtUserName.Focus();
                return;
            }

            entity.UserId = txtUserId.Text.ToString();
            //Save record
            Id = oUserBLL.User_Add(entity);
            entity.UserIdCreateBy = Convert.ToInt32(Session["UserID"].ToString());
            entity.TranStatus = 1;
            entity.Ref_Id = Id;
            entity.PageId = 1009;
            if (Id > 0)
            {
                Int32 AuditID = oUserBLL.UserForAudit_Add(entity);
            }

            if (Id > 0)
            {
                //if (chkAllColumn.Checked == true && hfUserIdCopy.Value == "0")
                //{
                //    int uid = oUserBLL.Add_ColumnPermissionALL(Id);
                //}

                //if (chkAllColumn.Checked == true && hfUserIdCopy.Value != "0")
                //{
                //    int uidcopy = oUserBLL.Add_ColumnCopyPermissionALL(Id, Convert.ToInt32(hfUserIdCopy.Value));
                //}

                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.SAVED_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfuly posted.');", true);
                //lblMessage.Text = ContextConstant.SAVED_SUCCESS;
                //lblMessage.ForeColor = Color.Green;
                Clear();
                //BindList();
            }
        }
        else
        {
            //RequisitionBLL objRequisitionBLL = new RequisitionBLL();
            //string InsertUserID = objRequisitionBLL.Requisition_GetInsertUserIDByUserID(hfPrevuserID.Value);
            //if (String.IsNullOrEmpty(InsertUserID))
            //{
            //Update record          
            entity.UserId = hfPrevuserID.Value;
            entity.Id = Convert.ToInt32(hfUserId.Value);

            Id = oUserBLL.User_Update(entity);
            entity.UserIdCreateBy = Convert.ToInt32(Session["UserID"].ToString());
            entity.TranStatus = 2;
            entity.Ref_Id = Convert.ToInt32(hfUserId.Value);
            entity.PageId = 1009;
            if (Id > 0)
            {
                Int32 AuditID = oUserBLL.UserForAudit_Add(entity);
            }
            //}
            //else
            //{
            //    entity.UserId = txtUserId.Text.ToString();
            //    //Save record
            //    Id = oUserBLL.User_Delete(entity.Id);
            //    Id = oUserBLL.User_Add(entity);
            //}
            if (Id > 0)
            {
                //lblMessage.Text = ContextConstant.UPDATE_SUCCESS;
                //lblMessage.ForeColor = Color.Green;

                string myScript123 = "";
                myScript123 = "showInfo('" + ContextConstant.UPDATE_SUCCESS + "');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript123, true);



                Clear();
                //BindList();
            }
        }
    }
    private void Clear()
    {
        txtFullName.Focus();
        txtUserName.ReadOnly = false;
        //chkAllColumn.Enabled = true;

        txtUserId.Text = string.Empty;
        txtUserName.Text = string.Empty;
        txtEmailID.Text = string.Empty;

        txtPassword.Attributes.Add("Value", string.Empty);

        txtConfirmPassword.Attributes.Add("Value", string.Empty);

        //txtPassword.Text = string.Empty;
        //txtConfirmPassword.Text = string.Empty;

        ddlUserGroupName.SelectedValue = "0";
        ddlUserRole.SelectedValue = "0";

        txtUserAddress.Text = string.Empty;
        hfUserId.Value = "0";
        hfPrevuserID.Value = "0";
        ddlUserRole.SelectedIndex = 0;
        txtFullName.Text = "";
        txtMobileNo.Text = "";

        chkIsActive.Checked = false;
        //chkAllColumn.Checked = false;
        btnsave.Visible = true;
        btnupdate.Visible = false;

        hfUserIdCopy.Value = "0";


    }
    private void GenerateUserCode()
    {
        UserBLL objUserBLL = new UserBLL();
        int prevID = objUserBLL.User_GetMaxID();
        string userCode = "";


        if (prevID > 100)
        {
            userCode = (prevID + 1).ToString() + "2PIBD" + DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.DayOfYear.ToString();

        }
        else
        {
            userCode = "101" + "2PIBD" + DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.DayOfYear.ToString();
        }

        txtUserId.Text = userCode;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
    }


    //protected void txtUserName_TextChanged(object sender, EventArgs e)
    //{
    //    string str = CheckUserName(txtUserName.Text);

    //    if (str == "true")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert('User Name Already Exists.');", true);
    //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfuly posted.');", true);
    //        txtUserName.Focus();
    //    }

    //}
}