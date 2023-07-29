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

public partial class Setting_NewUser_List : System.Web.UI.Page
{
    UserBLL oUserBLL = new UserBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                Session["breadcrumb"] = "";
                //btnsave.Visible = true;
                //btnupdate.Visible = false;
                Session["breadcrumb"] = "Search User";

                BindList();

            }
        }
        else
        {
            Response.Redirect("~/UserLogin_Logout.aspx");
        }

    }



    private void BindList()
    {
        //List<User> userList = oUserBLL.User_GetAll();
        DataTable dtUser = oUserBLL.User_GetDataForGV();

        gvUserInfoList.DataSource = dtUser;
        gvUserInfoList.DataBind();
    }

    protected void likBtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;

        Response.Redirect(String.Format("CreateUser?UserId={0}", Server.UrlEncode(lnkUserID.CommandArgument)));

    }

    protected void likBtnCopy_Click(object sender, EventArgs e)
    {
        LinkButton lnkUserID = sender as LinkButton;
        GridViewRow Grow = (GridViewRow)lnkUserID.NamingContainer;

        Response.Redirect(String.Format("CreateUser?UserIdCopy={0}",
            Server.UrlEncode(lnkUserID.CommandArgument)));

    }
    protected void gvUserInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvUserInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Int32 Id = Convert.ToInt32(gvUserInfoList.DataKeys[e.RowIndex].Value);
        int success = oUserBLL.User_Delete(Id);
        if (success > 0)
        {
            BindList();
        }
    }
}