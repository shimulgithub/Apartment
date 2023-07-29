using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class MenuHeadDAL
    {

        public MenuHeadDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, MenuHead oMenuHead)
        {
            if (oDbDataReader["MainModuleMenuHeadID"] != DBNull.Value)
                oMenuHead.MainModuleMenuHeadID = Convert.ToInt32(oDbDataReader["MainModuleMenuHeadID"]);
            if (oDbDataReader["MainModuleMenuHeadName"] != DBNull.Value)
                oMenuHead.MainModuleMenuHeadName = Convert.ToString(oDbDataReader["MainModuleMenuHeadName"]);
            if (oDbDataReader["MainModuleMenuHeadPriority"] != DBNull.Value)
                oMenuHead.MainModuleMenuHeadPriority = Convert.ToInt32(oDbDataReader["MainModuleMenuHeadPriority"]);
            if (oDbDataReader["MainModuleMenuHeadIcone"] != DBNull.Value)
                oMenuHead.MainModuleMenuHeadIcone = Convert.ToString(oDbDataReader["MainModuleMenuHeadIcone"]);

            if (oDbDataReader["MainModuleMenuHeadIsActive"] != DBNull.Value)
                oMenuHead.MainModuleMenuHeadIsActive = Convert.ToInt32(oDbDataReader["MainModuleMenuHeadIsActive"]);

            if (oDbDataReader["CanView"] != DBNull.Value)
                oMenuHead.CanView = Convert.ToBoolean(oDbDataReader["CanView"]);



        }
        private static void BuildEntity_Column(DbDataReader oDbDataReader, MenuHead oMenuHead)
        {


            if (oDbDataReader["PageId"] != DBNull.Value)
                oMenuHead.PageId = Convert.ToInt32(oDbDataReader["PageId"]);
            if (oDbDataReader["PageName"] != DBNull.Value)
                oMenuHead.PageName = Convert.ToString(oDbDataReader["PageName"]);
            if (oDbDataReader["IsActive"] != DBNull.Value)
                oMenuHead.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
            if (oDbDataReader["Priority"] != DBNull.Value)
                oMenuHead.Priority = Convert.ToInt32(oDbDataReader["Priority"]);
            if (oDbDataReader["CanViewIsActive"] != DBNull.Value)
                oMenuHead.CanViewIsActive = Convert.ToBoolean(oDbDataReader["CanViewIsActive"]);



        }
        public List<MenuHead> MenuHead_GetAll(string UserGroupID)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<MenuHead> lstMenuHead = new List<MenuHead>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ModuleMenuHead_GetAllByUserID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.String, UserGroupID);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuHead oMenuHead = new MenuHead();
                    BuildEntity(oDbDataReader, oMenuHead);
                    lstMenuHead.Add(oMenuHead);
                }
                oDbDataReader.Close();
                return lstMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }

        public List<MenuHead> MenuHead_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<MenuHead> lstMenuHead = new List<MenuHead>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ModuleMenuHead_GetAll", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuHead oMenuHead = new MenuHead();
                    BuildEntity(oDbDataReader, oMenuHead);
                    lstMenuHead.Add(oMenuHead);
                }
                oDbDataReader.Close();
                return lstMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }
        public List<MenuHead> ColumnHead_GetAll(string UserId, string PageId)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<MenuHead> lstMenuHead = new List<MenuHead>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ReportsColumnHead_GetAll", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, UserId);
                AddParameter(oDbCommand, "@PageId", DbType.String, PageId);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuHead oMenuHead = new MenuHead();
                    BuildEntity_Column(oDbDataReader, oMenuHead);
                    lstMenuHead.Add(oMenuHead);
                }
                oDbDataReader.Close();
                return lstMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }
        public List<MenuHead> MenuHead_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<MenuHead> lstMenuHead = new List<MenuHead>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuHead_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuHead oMenuHead = new MenuHead();
                    BuildEntity(oDbDataReader, oMenuHead);
                    lstMenuHead.Add(oMenuHead);
                }
                oDbDataReader.Close();
                return lstMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }
        public List<MenuHead> MenuHead_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<MenuHead> lstMenuHead = new List<MenuHead>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuHead_GetPaged", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
                AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
                AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
                AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
                AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuHead oMenuHead = new MenuHead();
                    BuildEntity(oDbDataReader, oMenuHead);
                    lstMenuHead.Add(oMenuHead);
                }
                oDbDataReader.Close();
                return lstMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }
        public MenuHead MenuHead_GetById(int MenuHeadID)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                MenuHead oMenuHead = new MenuHead();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuHead_GetById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@MenuHeadID", DbType.Int32, MenuHeadID);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oMenuHead);
                }
                oDbDataReader.Close();
                return oMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public int Add(MenuHead _MenuHead)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuHead_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@MainModuleMenuHeadName", DbType.String, _MenuHead.MainModuleMenuHeadName);
                AddParameter(oDbCommand, "@MainModuleMenuHeadPriority", DbType.Int32, _MenuHead.MainModuleMenuHeadPriority);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(MenuHead _MenuHead)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuHead_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@MainModuleMenuHeadName", DbType.String, _MenuHead.MainModuleMenuHeadName);
                AddParameter(oDbCommand, "@MainModuleMenuHeadPriority", DbType.Int32, _MenuHead.MainModuleMenuHeadPriority);
                AddParameter(oDbCommand, "@MainModuleMenuHeadID", DbType.Int32, _MenuHead.MainModuleMenuHeadID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(int MenuHeadID)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("MenuHead_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@MenuHeadID", DbType.Int32, MenuHeadID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuHead> MenuHead_GetAllByUserPermission(string userID, bool permission)
        {
            DbDataReader oDbDataReader = null;
            try
            {

                List<MenuHead> lstMenuHead = new List<MenuHead>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ModuleMenuHead_GetAllByUserPermission", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);
                AddParameter(oDbCommand, "@Permission", DbType.Boolean, permission);

                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    MenuHead oMenuHead = new MenuHead();
                    BuildEntity(oDbDataReader, oMenuHead);
                    lstMenuHead.Add(oMenuHead);
                }
                oDbDataReader.Close();
                return lstMenuHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDbDataReader.Dispose();
            }
        }
    }
}