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
using System;

public partial class Setting_NewUserGroup : System.Web.UI.Page
{
    
        UserBLL oUserBLL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    Session["breadcrumb"] = "";
                    btnsave.Visible = true;
                    btnupdate.Visible = false;
                    Session["breadcrumb"] = "User's Group";
                    Clear();
                    BindList();
                    // SystemUsageAuditLogInsert("1008");
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
        private void BindList()
        {
            //List<User> userList = oUserBLL.User_GetAll();
            DataTable dtUser = oUserBLL.UserGroup_GetDataForGV();

            gvUserGroupInfoList.DataSource = dtUser;
            gvUserGroupInfoList.DataBind();
        }
        public int MaxId()
        {
            int UserGroupID = 0;
            string connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX([UserGroupID]) AS UserGroupID   FROM [DB_AMS].[dbo].[TB_UserGroup]", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                UserGroupID = Convert.ToInt32(dt.Rows[0]["UserGroupID"].ToString());



            }

            return UserGroupID;

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void Save()
        {

            UserGroup entity = new UserGroup();

            entity.UserGroupName = txtGroupFullName.Text.Trim();
            entity.UserGroupShortName = txtGroupShortName.Text.ToString();
            entity.Remarks = txtGroupRemarks.Text.ToString();

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

                //Save record
                Id = oUserBLL.UserGroup_Add(entity);
                entity.UserId = Convert.ToInt32(Session["UserID"].ToString());
                entity.TranStatus = 1;
                entity.Ref_Id = MaxId();
                entity.PageId = 1008;
                Id = oUserBLL.UserGroupForAudit_Add(entity);
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

                entity.UserGroupID = Convert.ToInt32(hfUserId.Value);

                Id = oUserBLL.UserGroup_Update(entity);

                entity.UserId = Convert.ToInt32(Session["UserID"].ToString());
                entity.TranStatus = 2;
                entity.Ref_Id = Convert.ToInt32(hfUserId.Value);
                entity.PageId = 1008;
                Id = oUserBLL.UserGroupForAudit_Add(entity);

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
        protected void likBtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnkUserID = sender as LinkButton;
            GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;

            Response.Redirect(String.Format("CreateUser?UserId={0}",
                Server.UrlEncode(lnkUserID.CommandArgument)));

        }


        protected void gvUserGroupInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void gvUserGroupInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 Id = Convert.ToInt32(gvUserGroupInfoList.DataKeys[e.RowIndex].Value);
            int success = oUserBLL.UserGroup_Delete(Id);
            if (success > 0)
            {
                BindList();
            }
        }
        protected void gvUserGroupInfoList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            e.Cancel = true;
            Clear();
            GetSelectedData(e);
            //tContUser.ActiveTabIndex = 1;
        }
        private void GetSelectedData(System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            UserGroup user = new UserGroup();
            Int32 Id = Convert.ToInt32(gvUserGroupInfoList.DataKeys[e.NewEditIndex].Value);
            user = oUserBLL.User_GetById(Id);
            SetDataToControls(user);
        }

        private void SetDataToControls(UserGroup userGroup)
        {

            try
            {
                txtGroupFullName.Text = userGroup.UserGroupName.ToString();
            }
            catch
            {
                txtGroupFullName.Text = "";
            }
            try
            {
                txtGroupShortName.Text = userGroup.UserGroupShortName.ToString();
            }
            catch
            {
                txtGroupShortName.Text = "";
            }
            try
            {
                txtGroupRemarks.Text = userGroup.Remarks.ToString();
            }
            catch
            {
                txtGroupRemarks.Text = "";
            }

            if (userGroup.IsActive == true)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            hfUserId.Value = userGroup.UserGroupID.ToString();
            btnsave.Visible = false;
            btnupdate.Visible = true;
        }

        private void Clear()
        {
            txtGroupFullName.Focus();
            txtGroupFullName.Text = string.Empty;
            txtGroupShortName.Text = string.Empty;
            txtGroupRemarks.Text = string.Empty;

            hfUserId.Value = "0";
            chkIsActive.Checked = false;
            btnsave.Visible = true;
            btnupdate.Visible = false;

        }

    }
