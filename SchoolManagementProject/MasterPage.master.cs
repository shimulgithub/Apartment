using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
 
        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder breadcrumbSTB = new StringBuilder();
            //ToolkitScriptManager objScriptManager = (ToolkitScriptManager)this.Master.FindControl("ScriptManager1");
            //objScriptManager.AsyncPostBackTimeout = 36000;

            if (!IsPostBack)
            {
                //Session["breadcrumb"] = "";

                //Label1.Text = (string)Session["PageLink"];

                //Session["breadcrumb"] = "Category";

                //breadcrumbSTB.Append("<i class='icon-home home-icon'></i> Home > ");
                //tempHtmlbreadcrumb.Text = breadcrumbSTB.ToString() + Session["breadcrumb"].ToString();
                UserFName.Text = Session["UserFullName"].ToString();
                GetMenuData1();
            }



        }

        string connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;

        private void GetMenuData1()
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            //Create Stringbuilder, so we can append the iterated results from our DataTable.
            StringBuilder tableOutput = new StringBuilder();
            StringBuilder tableOutputbreadcrumb = new StringBuilder();


            // get the connection 
            //string htmlrow = string.Empty;
            tableOutput.Append("<ul class='nav navbar-nav'>");

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                string sql1 = " SELECT DISTINCT   TB_MenuPermission.UserId ,TB_MainModuleMenuHead.[MainModuleMenuHeadID],TB_MenuPermission.UserGroupID  ";
                sql1 = sql1 + " ,[MainModuleMenuHeadName] ,[MainModuleMenuHeadPriority] ,[MainModuleMenuHeadIcone] ,[MainModuleMenuHeadIsActive]  ";
                sql1 = sql1 + " FROM [DB_SMP].[dbo].[TB_MainModuleMenuHead]    AS TB_MainModuleMenuHead INNER JOIN   ";
                sql1 = sql1 + " [DB_SMP].[dbo].[TB_MenuPermission]  AS TB_MenuPermission ON TB_MainModuleMenuHead.[MainModuleMenuHeadID] = TB_MenuPermission.[MainModuleMenuHeadID]  ";
                sql1 = sql1 + " WHERE  (TB_MenuPermission.UserGroupID = '" + Session["UserGroupID"].ToString() + "' AND TB_MainModuleMenuHead.MainModuleMenuHeadIsActive=1 )  order by [MainModuleMenuHeadPriority] ASC   ";
                //sql1 = sql1 + " dbo.TB_MenuPermission ON dbo.TB_ModuleMenuHead.MenuHeadID = dbo.TB_MenuPermission.MenuHeadID  ";

                //sql1 = sql1 + " WHERE  (dbo.TB_MenuPermission.UserID = '102MREL12280' AND TB_ModuleMenuHead.IsActive=1 ) order by dbo.TB_ModuleMenuHead.Priority ASC  ";


                SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];


                // write the sql statement to execute




                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    table.Clear();

                    string sql = @"SELECT DISTINCT TB_SubMenuHead.*,TB_MenuPermission.UserGroupID FROM DB_SMP.dbo.TB_SubMenuHead AS TB_SubMenuHead
                                INNER JOIN DB_SMP.dbo.TB_MenuPermission AS TB_MenuPermission ON TB_SubMenuHead.SubMenuHeadID = TB_MenuPermission.SubMenuHeadID 
                               
                               WHERE  (TB_MenuPermission.UserGroupID = '" + dt1.Rows[i]["UserGroupID"].ToString() + @"'
                               AND TB_SubMenuHead.MainModuleMenuHeadID='" + dt1.Rows[i]["MainModuleMenuHeadID"].ToString() + @"') 
                                    order by TB_SubMenuHead.SubMenuHeadPriority ASC  ";



                    // instantiate the command object to fire

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        // get the adapter object and attach the command object to it

                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {

                            // fire Fill method to fetch the data and fill into DataTable

                            ad.Fill(table);

                        }

                    }

                    if (table.Rows.Count == 0)
                    {

                        DataSet ds2 = new DataSet();
                        DataTable dt2 = new DataTable();

                        string sql2 = @"SELECT DISTINCT TB_MainModuleMenuHead.*,TB_MenuPage.*,TB_MenuPermission.UserGroupID
                                    FROM DB_SMP.dbo.TB_MainModuleMenuHead AS TB_MainModuleMenuHead
                                    INNER JOIN DB_SMP.dbo.TB_MenuPage AS TB_MenuPage ON 
                                    TB_MainModuleMenuHead.MainModuleMenuHeadID =TB_MenuPage.ModuleSubMenuHeadID  
                                    INNER JOIN TB_MenuPermission ON 
                                    TB_MainModuleMenuHead.MainModuleMenuHeadID = dbo.TB_MenuPermission.MainModuleMenuHeadID
                                    WHERE  (dbo.TB_MenuPermission.UserGroupID ='" + dt1.Rows[i]["UserGroupID"].ToString() + @"'
                                     AND TB_MainModuleMenuHead.MainModuleMenuHeadID='" + dt1.Rows[i]["MainModuleMenuHeadID"].ToString() + @"') 
                                    order by TB_MainModuleMenuHead.MainModuleMenuHeadPriority ,TB_MenuPage.Priority ASC  ";

                        SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn);
                        da2.Fill(ds2);
                        dt2 = ds2.Tables[0];

                        //if (dt2.Rows.Count == 0)
                        //{

                        //}
                        //else
                        //{
                        tableOutput.Append(String.Format(" <li><a  href={0}> <i class={2}></i><span> {1}</span></a></li>", ResolveUrl("~/" + dt2.Rows[0]["Url"].ToString()), dt2.Rows[0]["MainModuleMenuHeadName"].ToString(), dt2.Rows[0]["MainModuleMenuHeadIcone"].ToString()));
                        //}
                    }
                    else
                    {
                        DataSet ds3 = new DataSet();
                        DataTable dt3 = new DataTable();

                        string sql2 = @" SELECT DISTINCT TB_SubMenuHead.*,TB_MenuPermission.UserGroupID
                                    FROM DB_SMP.dbo.TB_SubMenuHead AS TB_SubMenuHead
                                    INNER JOIN DB_SMP.dbo.TB_MenuPermission AS TB_MenuPermission ON 
                                    TB_SubMenuHead.SubMenuHeadID = TB_MenuPermission.SubMenuHeadID 
                                    WHERE  (TB_MenuPermission.UserGroupID  =  '" + dt1.Rows[i]["UserGroupID"].ToString() + @"'
                                    AND TB_SubMenuHead.MainModuleMenuHeadID='" + dt1.Rows[i]["MainModuleMenuHeadID"].ToString() + @"') 
                                    order by TB_SubMenuHead.SubMenuHeadPriority ASC   ";


                        SqlDataAdapter da3 = new SqlDataAdapter(sql2, conn);
                        da3.Fill(ds3);
                        dt3 = ds3.Tables[0];


                        //Auto Menu Open
                        //tableOutput.Append(String.Format("<li class='dropdown mega-dropdown'><a href='#' class='dropdown-toggle' data-toggle='dropdown'  ><i class=" + dt1.Rows[i]["MainModuleMenuHeadIcone"].ToString() + "></i><span class='menu-text'> {0} </span><b class='caret'></b></a>", dt1.Rows[i]["MainModuleMenuHeadName"].ToString()));
                        tableOutput.Append(String.Format("<li class='mega-dropdown'><a href='#' class='dropdown-toggle' data-toggle='dropdown'  ><i class=" + dt1.Rows[i]["MainModuleMenuHeadIcone"].ToString() + "></i><span class='menu-text'> {0} </span><b class='caret'></b></a>", dt1.Rows[i]["MainModuleMenuHeadName"].ToString()));
                        //tableOutput.Append(String.Format("<li class='mega-dropdown'><a href='#' class='dropdown-toggle' data-toggle='dropdown'  ><i class=" + dt1.Rows[i]["ModuleHeadIcone"].ToString() + "></i><span class='menu-text'> {0}</span><b class='caret'></b></a>", dt1.Rows[i]["MenuHeadName"].ToString()));

                        tableOutput.Append("<ul class='dropdown-menu mega-dropdown-menu'>");


                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            tableOutput.Append("<li class='col-md-3'>");
                            tableOutput.Append("<ul class='mega-dropdown-menu'>");
                            tableOutput.Append("<li class='dropdown-header'>" + dt3.Rows[j]["SubMenuHeadName"].ToString() + "</li>");
                            tableOutput.Append("<li class='divider'></li>");


                            DataSet ds4 = new DataSet();
                            DataTable dt4 = new DataTable();

                            string sql4 = @"  SELECT DISTINCT TB_MenuPage.*,TB_MenuPermission.* 
                                           FROM DB_SMP.dbo.TB_MenuPage AS TB_MenuPage
                                           LEFT OUTER JOIN DB_SMP.dbo.TB_MenuPermission AS TB_MenuPermission ON 
                                           TB_MenuPage.PageId  = TB_MenuPermission.PageId AND TB_MenuPage.ModuleSubMenuHeadID   =TB_MenuPermission.SubMenuHeadID
                                           WHERE   (TB_MenuPermission.UserGroupID  =  '" + dt1.Rows[i]["UserGroupID"].ToString() + @"'
                                           AND TB_MenuPage.ModuleSubMenuHeadID ='" + dt3.Rows[j]["SubMenuHeadID"].ToString() + @"')
                                           order by  TB_MenuPage.PageName  ASC
                                    ";


                            SqlDataAdapter da4 = new SqlDataAdapter(sql4, conn);
                            da4.Fill(ds4);
                            dt4 = ds4.Tables[0];



                            tableOutput.Append(" <li class='col-md-12'> <ul class='mega-dropdown-menu'>");

                            for (int j4 = 0; j4 < dt4.Rows.Count; j4++)
                            {


                                tableOutput.Append(String.Format("<li><a  href={0}>{1}</a></li>", ResolveUrl("~/" + dt4.Rows[j4]["Url"].ToString()), dt4.Rows[j4]["PageName"].ToString()));
                                if (j4 == dt4.Rows.Count - 1)
                                {
                                    tableOutput.Append(" </ul> </li>");
                                }


                            }


                            tableOutput.Append("</ul> </li>");
                        }

                        tableOutput.Append("</ul> </li>");
                    }

                }

            }

            tableOutput.Append("</ul> ");
            Literal1.Text = tableOutput.ToString();

            Session["Menu"] = "Jahid";

            Session["MenuLiteral1"] = Literal1.Text;

        }
    }

