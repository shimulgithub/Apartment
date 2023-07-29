using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using SMP.BLL.Setting;
using SMP.BOL.Setting;
using SMP.Common;

public partial class MainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!Page.IsPostBack)
            {

                Session["PageLink"] = "Dashboard";
                Session["breadcrumb"] = "Dashboard";


                Int32 InsertId = 0;
                UserBLL oUserBLL = new UserBLL();
                UserLoginHistoryBOL oUserLoginHistoryBOL = new UserLoginHistoryBOL();
                oUserLoginHistoryBOL.UserId = Convert.ToInt32(Session["UserID"].ToString());
                oUserLoginHistoryBOL.CreateBy = Session["UserID"].ToString();
                InsertId = oUserBLL.UserLoginHistory_Add(oUserLoginHistoryBOL);

                //string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                //Console.WriteLine(hostName);
                //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                // Label1.Text = myIP;

                //Label1.Text = Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName; 


            }
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }
    }
}
