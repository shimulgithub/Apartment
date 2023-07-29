using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using SMP.BOL.Setting;
using System.Configuration;

namespace SMP.DAL.Setting
{
    public class MenuPageDAL
    {

        public MenuPageDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, MenuPage oMenuPage)
        {

            if (oDbDataReader["SubMenuHeadID"] != DBNull.Value)
                oMenuPage.SubMenuHeadID = Convert.ToInt32(oDbDataReader["SubMenuHeadID"]);

            if (oDbDataReader["MainModuleMenuHeadID"] != DBNull.Value)
                oMenuPage.MainModuleMenuHeadID = Convert.ToInt32(oDbDataReader["MainModuleMenuHeadID"]);


            if (oDbDataReader["SubMenuHeadName"] != DBNull.Value)
                oMenuPage.SubMenuHeadName = Convert.ToString(oDbDataReader["SubMenuHeadName"]);
            if (oDbDataReader["SubMenuHeadPriority"] != DBNull.Value)
                oMenuPage.SubMenuHeadPriority = Convert.ToInt32(oDbDataReader["SubMenuHeadPriority"]);


            if (oDbDataReader["SubMenuHeadIcone"] != DBNull.Value)
                oMenuPage.SubMenuHeadIcone = Convert.ToString(oDbDataReader["SubMenuHeadIcone"]);
            if (oDbDataReader["SubMenuHeadIsActive"] != DBNull.Value)
                oMenuPage.SubMenuHeadIsActive = Convert.ToInt32(oDbDataReader["SubMenuHeadIsActive"]);




            if (oDbDataReader["PageId"] != DBNull.Value)
                oMenuPage.PageId = Convert.ToInt32(oDbDataReader["PageId"]);
            if (oDbDataReader["MenuHeadID"] != DBNull.Value)
                oMenuPage.MenuHeadID = Convert.ToInt32(oDbDataReader["MenuHeadID"]);
            if (oDbDataReader["PageName"] != DBNull.Value)
                oMenuPage.PageName = Convert.ToString(oDbDataReader["PageName"]);
            if (oDbDataReader["URL"] != DBNull.Value)
                oMenuPage.URL = Convert.ToString(oDbDataReader["URL"]);

            if (oDbDataReader["CreateDate"] != DBNull.Value)
                oMenuPage.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);

            if (oDbDataReader["LastUpdateDate"] != DBNull.Value)
                oMenuPage.LastUpdateDate = Convert.ToDateTime(oDbDataReader["LastUpdateDate"]);
            if (oDbDataReader["IsRemoved"] != DBNull.Value)
                oMenuPage.IsRemoved = Convert.ToBoolean(oDbDataReader["IsRemoved"]);
            if (oDbDataReader["LiID"] != DBNull.Value)
                oMenuPage.LiID = Convert.ToString(oDbDataReader["LiID"]);
        }
        public List<MenuPage> MenuPage_GetAll()
        {
            try
            {
                List<MenuPage> lstMenuPage = new List<MenuPage>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_GetAll", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPage oMenuPage = new MenuPage();
                    BuildEntity(oDbDataReader, oMenuPage);
                    lstMenuPage.Add(oMenuPage);
                }
                oDbDataReader.Close();
                return lstMenuPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuPage> MenuPage_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            try
            {
                List<MenuPage> lstMenuPage = new List<MenuPage>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPage oMenuPage = new MenuPage();
                    BuildEntity(oDbDataReader, oMenuPage);
                    lstMenuPage.Add(oMenuPage);
                }
                oDbDataReader.Close();
                return lstMenuPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuPage> MenuPage_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder)
        {
            try
            {
                List<MenuPage> lstMenuPage = new List<MenuPage>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_GetPaged", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
                AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
                AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
                AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
                AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPage oMenuPage = new MenuPage();
                    BuildEntity(oDbDataReader, oMenuPage);
                    lstMenuPage.Add(oMenuPage);
                }
                oDbDataReader.Close();
                return lstMenuPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuPage MenuPage_GetById(int PageId)
        {
            try
            {
                MenuPage oMenuPage = new MenuPage();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@PageId", DbType.Int32, PageId);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oMenuPage);
                }
                oDbDataReader.Close();
                return oMenuPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public int Add(MenuPage _MenuPage)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@MenuHeadID", DbType.Int32, _MenuPage.MenuHeadID);
                AddParameter(oDbCommand, "@PageName", DbType.String, _MenuPage.PageName);
                AddParameter(oDbCommand, "@URL", DbType.String, _MenuPage.URL);
                if (_MenuPage.CreateDate.HasValue)
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _MenuPage.CreateDate);
                else
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, DBNull.Value);
                if (_MenuPage.LastUpdateDate.HasValue)
                    AddParameter(oDbCommand, "@LastUpdateDate", DbType.DateTime, _MenuPage.LastUpdateDate);
                else
                    AddParameter(oDbCommand, "@LastUpdateDate", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@IsRemoved", DbType.Int32, _MenuPage.IsRemoved);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(MenuPage _MenuPage)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@MenuHeadID", DbType.Int32, _MenuPage.MenuHeadID);
                AddParameter(oDbCommand, "@PageName", DbType.String, _MenuPage.PageName);
                AddParameter(oDbCommand, "@URL", DbType.String, _MenuPage.URL);
                if (_MenuPage.CreateDate.HasValue)
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _MenuPage.CreateDate);
                else
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, DBNull.Value);
                if (_MenuPage.LastUpdateDate.HasValue)
                    AddParameter(oDbCommand, "@LastUpdateDate", DbType.DateTime, _MenuPage.LastUpdateDate);
                else
                    AddParameter(oDbCommand, "@LastUpdateDate", DbType.DateTime, DBNull.Value);
                AddParameter(oDbCommand, "@IsRemoved", DbType.Int32, _MenuPage.IsRemoved);
                AddParameter(oDbCommand, "@PageId", DbType.Int32, _MenuPage.PageId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(int PageId)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@PageId", DbType.Int32, PageId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuPage> MenuPage_GetAllByHeadUser(int headID, string userID, bool permission)
        {
            try
            {
                List<MenuPage> lstMenuPage = new List<MenuPage>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPage_GetAllByHeadUser", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@HeadID", DbType.Int32, headID);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);
                AddParameter(oDbCommand, "@Permission", DbType.Boolean, permission);

                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPage oMenuPage = new MenuPage();
                    BuildEntity(oDbDataReader, oMenuPage);
                    lstMenuPage.Add(oMenuPage);
                }
                oDbDataReader.Close();
                return lstMenuPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString);

        public DataSet MenuPage_GetAllByHeadID(int headID, string UserGroupID)
        {

            //DataSet dtPages = null;
            //DbDataAdapter oDbDataReader = null;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_TB_ModuleSubMenuHead_GetAllByHeadID", con);
                cmd.Parameters.Add(new SqlParameter("@HeadID", headID));
                cmd.Parameters.Add(new SqlParameter("@UserGroupID", UserGroupID));
                //cmd.Parameters.Add("@HeadID", SqlDbType.Int , headID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(ds);

                return ds;
            }
            //try
            //{
            //    dtPages = new DataSet();
            //   // oDbDataReader = new DbDataAdapter();

            //    DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ModuleSubMenuHead_GetAllByHeadID", CommandType.StoredProcedure);

            //    AddParameter(oDbCommand, "@HeadID", DbType.Int32, headID);

            //    oDbDataReader.SelectCommand = oDbCommand;

            //    //DbDataAdapter oDbDataReader12 = new DbDataAdapter(oDbCommand);

            //     oDbDataReader.Fill(dtPages);

            //    //oDbCommand.Fill(dtPages); 
            //    //dtPages = DbProviderHelper.FillDataSet(oDbDataReader);
            //    oDbDataReader = DbProviderHelper.FillDataSet(oDbCommand);



            //   // dtPages.Tables[0].Load(oDbDataReader); 

            //   // oDbDataReader.Close();
            //    return dtPages;
            //}
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                ds.Dispose();
                //oDbDataReader.Dispose();
            }
        }

        public DataSet ColumnNamePage_GetAllByHeadID(int headID, string UserGroupID)
        {

            //DataSet dtPages = null;
            //DbDataAdapter oDbDataReader = null;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_TB_ModuleColumnHead_GetAllByPageID", con);
                cmd.Parameters.Add(new SqlParameter("@HeadID", headID));
                cmd.Parameters.Add(new SqlParameter("@UserID", UserGroupID));
                //cmd.Parameters.Add("@HeadID", SqlDbType.Int , headID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(ds);

                return ds;
            }
            //try
            //{
            //    dtPages = new DataSet();
            //   // oDbDataReader = new DbDataAdapter();

            //    DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ModuleSubMenuHead_GetAllByHeadID", CommandType.StoredProcedure);

            //    AddParameter(oDbCommand, "@HeadID", DbType.Int32, headID);

            //    oDbDataReader.SelectCommand = oDbCommand;

            //    //DbDataAdapter oDbDataReader12 = new DbDataAdapter(oDbCommand);

            //     oDbDataReader.Fill(dtPages);

            //    //oDbCommand.Fill(dtPages); 
            //    //dtPages = DbProviderHelper.FillDataSet(oDbDataReader);
            //    oDbDataReader = DbProviderHelper.FillDataSet(oDbCommand);



            //   // dtPages.Tables[0].Load(oDbDataReader); 

            //   // oDbDataReader.Close();
            //    return dtPages;
            //}
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                ds.Dispose();
                //oDbDataReader.Dispose();
            }
        }



        public DataTable SubMenuPage_GetAllByHeadID(int headID, string UserGroupID)
        {

            DataTable dtPages = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtPages = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_SubMenuPage_GetAllByHeadID", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@HeadID", DbType.Int32, headID);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, UserGroupID);


                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtPages.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtPages;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtPages.Dispose();
                oDbDataReader.Dispose();
            }
        }
    }
}
