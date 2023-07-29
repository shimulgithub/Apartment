using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
    public class MenuPermissionDAL
    {

        public MenuPermissionDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, MenuPermission oMenuPermission)
        {
            oMenuPermission.MenuPermissionID = Convert.ToInt32(oDbDataReader["MenuPermissionID"]);
            oMenuPermission.UserGroupID = Convert.ToString(oDbDataReader["UserGroupID"]);
            oMenuPermission.MainModuleMenuHeadID = Convert.ToInt32(oDbDataReader["MainModuleMenuHeadID"]);
            oMenuPermission.PageID = Convert.ToInt32(oDbDataReader["PageID"]);
            oMenuPermission.CanView = Convert.ToBoolean(oDbDataReader["CanView"]);
        }
        public List<MenuPermission> MenuPermission_GetAll()
        {
            try
            {
                List<MenuPermission> lstMenuPermission = new List<MenuPermission>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_GetAll", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPermission oMenuPermission = new MenuPermission();
                    BuildEntity(oDbDataReader, oMenuPermission);
                    lstMenuPermission.Add(oMenuPermission);
                }
                oDbDataReader.Close();
                return lstMenuPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Add_ColumnFromUserGroupWisePagePermission(MenuPermission _MenuPermission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermission_UserGroupWise_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, _MenuPermission.UserGroupID);
                AddParameter(oDbCommand, "@PageId", DbType.String, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@ColumnHeadAutoID", DbType.String, _MenuPermission.ColumnHeadAutoID);
                AddParameter(oDbCommand, "@CanView", DbType.String, _MenuPermission.CanView);
                AddParameter(oDbCommand, "@Order_Priority", DbType.String, _MenuPermission.Order_Priority);



                AddParameter(oDbCommand, "@CreateBy", DbType.String, _MenuPermission.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<MenuPermission> MenuPermission_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            try
            {
                List<MenuPermission> lstMenuPermission = new List<MenuPermission>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPermission oMenuPermission = new MenuPermission();
                    BuildEntity(oDbDataReader, oMenuPermission);
                    lstMenuPermission.Add(oMenuPermission);
                }
                oDbDataReader.Close();
                return lstMenuPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ColumnPermission_DeleteByUserID(string userID, string PageId, int Versionid)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermission_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, userID);
                AddParameter(oDbCommand, "@PageId", DbType.String, PageId);
                AddParameter(oDbCommand, "@VersoinAutoID", DbType.String, Versionid);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public List<MenuPermission> MenuPermission_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder)
        {
            try
            {
                List<MenuPermission> lstMenuPermission = new List<MenuPermission>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_GetPaged", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
                AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
                AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
                AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
                AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuPermission oMenuPermission = new MenuPermission();
                    BuildEntity(oDbDataReader, oMenuPermission);
                    lstMenuPermission.Add(oMenuPermission);
                }
                oDbDataReader.Close();
                return lstMenuPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuPermission MenuPermission_GetById(int GrantID)
        {
            try
            {
                MenuPermission oMenuPermission = new MenuPermission();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@GrantID", DbType.Int32, GrantID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oMenuPermission);
                }
                oDbDataReader.Close();
                return oMenuPermission;
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
        public int Add(MenuPermission _MenuPermission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MenuPermission_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, _MenuPermission.UserGroupID);
                AddParameter(oDbCommand, "@MainModuleMenuHeadID", DbType.Int32, _MenuPermission.MainModuleMenuHeadID);
                AddParameter(oDbCommand, "@SubMenuHeadID", DbType.Int32, _MenuPermission.SubMenuHeadID);
                AddParameter(oDbCommand, "@PageID", DbType.Int32, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@CanView", DbType.Boolean, _MenuPermission.CanView);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(MenuPermission _MenuPermission)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, _MenuPermission.UserID);
                AddParameter(oDbCommand, "@MainModuleMenuHeadID", DbType.Int32, _MenuPermission.MainModuleMenuHeadID);
                AddParameter(oDbCommand, "@PageID", DbType.Int32, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@CanView", DbType.Boolean, _MenuPermission.CanView);
                AddParameter(oDbCommand, "@MenuPermissionID", DbType.Int32, _MenuPermission.MenuPermissionID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(int GrantID)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@GrantID", DbType.Int32, GrantID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int MenuPermission_UpdateUserID(string userID)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_UpdateUserID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int MenuPermission_DeleteByUserID(string userID)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MenuPermission_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, userID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ColumnPermission_DeleteByUserID(string userID, string PageId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermission_DeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, userID);
                AddParameter(oDbCommand, "@PageId", DbType.String, PageId);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int Add_Column(MenuPermission _MenuPermission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermission_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _MenuPermission.UserID);
                AddParameter(oDbCommand, "@PageId", DbType.Int32, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@ColumnHeadAutoID", DbType.Int32, _MenuPermission.ColumnHeadAutoID);
                AddParameter(oDbCommand, "@Order_Priority", DbType.Int32, _MenuPermission.Order_Priority);
                AddParameter(oDbCommand, "@CanView", DbType.Boolean, _MenuPermission.CanView);
                AddParameter(oDbCommand, "@VersoinAutoID", DbType.Int32, _MenuPermission.VersoinAutoID);

                AddParameter(oDbCommand, "@CreateBy", DbType.String, _MenuPermission.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable MenuPermission_IsPageAuthorized(string userID, string requestedURL)
        {

            DataTable dt = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dt = new DataTable();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuPermission_IsPageAuthorizedByUserandUrl", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);
                AddParameter(oDbCommand, "@RequestedURL", DbType.String, requestedURL);

                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dt.Load(oDbDataReader);
                oDbDataReader.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dt.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public DataTable CommonAndInternalPages_IsExist(string requestedURL)
        {
            DataTable dt = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dt = new DataTable();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("CommonAndInternalPages_IsExist", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@RequestedURL", DbType.String, requestedURL);

                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dt.Load(oDbDataReader);
                oDbDataReader.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dt.Dispose();
                oDbDataReader.Dispose();
            }
        }
        public int ForAuditAdd_Column(MenuPermission _MenuPermission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermissionForAudit_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _MenuPermission.UserID);
                AddParameter(oDbCommand, "@PageId", DbType.Int32, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@ColumnHeadAutoID", DbType.Int32, _MenuPermission.ColumnHeadAutoID);
                AddParameter(oDbCommand, "@Order_Priority", DbType.Int32, _MenuPermission.Order_Priority);
                AddParameter(oDbCommand, "@CanView", DbType.Boolean, _MenuPermission.CanView);
                AddParameter(oDbCommand, "@VersoinAutoID", DbType.Int32, _MenuPermission.VersoinAutoID);
                AddParameter(oDbCommand, "@AuditUserId", DbType.String, _MenuPermission.AuditUserId);
                AddParameter(oDbCommand, "@AuditPageId", DbType.String, _MenuPermission.AuditPageId);
                AddParameter(oDbCommand, "@Ref_Id", DbType.String, _MenuPermission.Ref_Id);
                AddParameter(oDbCommand, "@TranStatus", DbType.String, _MenuPermission.TranStatus);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ForAudit_Update(MenuPermission _MenuPermission)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermissionForAuditDelete", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _MenuPermission.UserID);
                AddParameter(oDbCommand, "@PageId", DbType.Int32, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@VersoinAutoID", DbType.Int32, _MenuPermission.VersoinAutoID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ForAudit_Update_ColumnFromUserGroupWisePagePermission(MenuPermission _MenuPermission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermission_UserGroupWiseForAuditDelete", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, _MenuPermission.UserGroupID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ForAuditAdd_ColumnFromUserGroupWisePagePermission(MenuPermission _MenuPermission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermission_UserGroupWiseForAudit_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, _MenuPermission.UserGroupID);
                AddParameter(oDbCommand, "@PageId", DbType.String, _MenuPermission.PageID);
                AddParameter(oDbCommand, "@ColumnHeadAutoID", DbType.String, _MenuPermission.ColumnHeadAutoID);
                AddParameter(oDbCommand, "@CanView", DbType.String, _MenuPermission.CanView);
                AddParameter(oDbCommand, "@Order_Priority", DbType.String, _MenuPermission.Order_Priority);
                AddParameter(oDbCommand, "@AuditUserId", DbType.String, _MenuPermission.AuditUserId);
                AddParameter(oDbCommand, "@AuditPageId", DbType.String, _MenuPermission.AuditPageId);
                AddParameter(oDbCommand, "@Ref_Id", DbType.String, _MenuPermission.Ref_Id);
                AddParameter(oDbCommand, "@TranStatus", DbType.String, _MenuPermission.TranStatus);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
