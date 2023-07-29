using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class UserDAL
    {
        public UserDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, User oUser)
        {
            oUser.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oUser.UserId = Convert.ToString(oDbDataReader["UserId"]);
            oUser.UserName = Convert.ToString(oDbDataReader["UserName"]);
            oUser.EmailID = Convert.ToString(oDbDataReader["EmailID"]);
            oUser.Password = Convert.ToString(oDbDataReader["Password"]);
            oUser.ConfirmPassword = Convert.ToString(oDbDataReader["ConfirmPassword"]);

            if (oDbDataReader["UserLocation"] != DBNull.Value)
                oUser.UserLocation = Convert.ToString(oDbDataReader["UserLocation"]);

            if (oDbDataReader["CreateDate"] != DBNull.Value)
                oUser.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);

            if (oDbDataReader["UpdateDate"] != DBNull.Value)
                oUser.UpdateDate = Convert.ToDateTime(oDbDataReader["UpdateDate"]);

            if (oDbDataReader["IsActive"] != DBNull.Value)
                oUser.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
            if (oDbDataReader["Role"] != DBNull.Value)
                oUser.Role = Convert.ToInt32(oDbDataReader["Role"]);
            if (oDbDataReader["UserFullName"] != DBNull.Value)
                oUser.UserFullName = Convert.ToString(oDbDataReader["UserFullName"]);
            if (oDbDataReader["MobileNo"] != DBNull.Value)
                oUser.MobileNo = Convert.ToString(oDbDataReader["MobileNo"]);
        }
        private static void BuildEntity_UserGroup(DbDataReader oDbDataReader, UserGroup oUser)
        {
            oUser.UserGroupID = Convert.ToInt32(oDbDataReader["UserGroupID"]);
            oUser.UserGroupName = Convert.ToString(oDbDataReader["UserGroupName"]);
            oUser.UserGroupShortName = Convert.ToString(oDbDataReader["UserGroupShortName"]);
            oUser.Remarks = Convert.ToString(oDbDataReader["Remarks"]);


            if (oDbDataReader["IsActive"] != DBNull.Value)
                oUser.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);

        }

        public List<User> User_GetAll()
        {
            try
            {
                List<User> lstUser = new List<User>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetAll", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    User oUser = new User();
                    BuildEntity(oDbDataReader, oUser);
                    lstUser.Add(oUser);
                }
                oDbDataReader.Close();
                return lstUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> User_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            try
            {
                List<User> lstUser = new List<User>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    User oUser = new User();
                    BuildEntity(oDbDataReader, oUser);
                    lstUser.Add(oUser);
                }
                oDbDataReader.Close();
                return lstUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> User_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder)
        {
            try
            {
                List<User> lstUser = new List<User>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetPaged", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@StartRowIndex", DbType.Int32, StartRowIndex);
                AddParameter(oDbCommand, "@RowPerPage", DbType.Int32, RowPerPage);
                AddParameter(oDbCommand, "@WhereClause", DbType.String, WhereClause);
                AddParameter(oDbCommand, "@SortColumn", DbType.String, SortColumn);
                AddParameter(oDbCommand, "@SortOrder", DbType.String, SortOrder);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    User oUser = new User();
                    BuildEntity(oDbDataReader, oUser);
                    lstUser.Add(oUser);
                }
                oDbDataReader.Close();
                return lstUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserGroup User_GetById(int Id)
        {
            try
            {
                UserGroup oUser = new UserGroup();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserGroupListByUserGroupID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity_UserGroup(oDbDataReader, oUser);
                }
                oDbDataReader.Close();
                return oUser;
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
        public int AddGroup(UserGroup _User)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserGroupInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupName", DbType.String, _User.UserGroupName);
                AddParameter(oDbCommand, "@UserGroupShortName", DbType.String, _User.UserGroupShortName);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _User.Remarks);

                if (_User.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _User.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Add(User _User)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _User.UserId);
                AddParameter(oDbCommand, "@UserName", DbType.String, _User.UserName);
                AddParameter(oDbCommand, "@EmailID", DbType.String, _User.EmailID);
                AddParameter(oDbCommand, "@Password", DbType.String, _User.Password);
                AddParameter(oDbCommand, "@ConfirmPassword", DbType.String, _User.ConfirmPassword);
                if (_User.UserLocation != null)
                    AddParameter(oDbCommand, "@UserLocation", DbType.String, _User.UserLocation);
                else
                    AddParameter(oDbCommand, "@UserLocation", DbType.String, DBNull.Value);
                if (_User.CreateDate.HasValue)
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _User.CreateDate);
                else
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, DBNull.Value);
                if (_User.UpdateDate.HasValue)
                    AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, _User.UpdateDate);
                else
                    AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, DBNull.Value);
                if (_User.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _User.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);
                if (_User.Role.HasValue)
                    AddParameter(oDbCommand, "@Role", DbType.Int32, _User.Role);
                else
                    AddParameter(oDbCommand, "@Role", DbType.Int32, DBNull.Value);

                if (_User.UserGroupID.HasValue)
                    AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, _User.UserGroupID);
                else
                    AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, DBNull.Value);



                AddParameter(oDbCommand, "@MobileNo", DbType.String, _User.MobileNo);

                AddParameter(oDbCommand, "@UserFullName", DbType.String, _User.UserFullName);

                //return DbProviderHelper.ExecuteNonQuery(oDbCommand);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateChange(User _User)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserUpdateChangeRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Password", DbType.String, _User.Password);
                AddParameter(oDbCommand, "@ConfirmPassword", DbType.String, _User.ConfirmPassword);


                AddParameter(oDbCommand, "@Id", DbType.Int32, _User.Id);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(User _User)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _User.UserId);
                AddParameter(oDbCommand, "@UserName", DbType.String, _User.UserName);
                AddParameter(oDbCommand, "@EmailID", DbType.String, _User.EmailID);
                AddParameter(oDbCommand, "@Password", DbType.String, _User.Password);
                AddParameter(oDbCommand, "@ConfirmPassword", DbType.String, _User.ConfirmPassword);
                if (_User.UserLocation != null)
                    AddParameter(oDbCommand, "@UserLocation", DbType.String, _User.UserLocation);
                else
                    AddParameter(oDbCommand, "@UserLocation", DbType.String, DBNull.Value);
                if (_User.CreateDate.HasValue)
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _User.CreateDate);
                else
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, DBNull.Value);
                if (_User.UpdateDate.HasValue)
                    AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, _User.UpdateDate);
                else
                    AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, DBNull.Value);
                if (_User.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _User.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);
                if (_User.Role.HasValue)
                    AddParameter(oDbCommand, "@Role", DbType.Int32, _User.Role);
                else
                    AddParameter(oDbCommand, "@Role", DbType.Int32, DBNull.Value);

                if (_User.UserGroupID.HasValue)
                    AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, _User.UserGroupID);
                else
                    AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, DBNull.Value);



                AddParameter(oDbCommand, "@MobileNo", DbType.String, _User.MobileNo);

                AddParameter(oDbCommand, "@UserFullName", DbType.String, _User.UserFullName);


                AddParameter(oDbCommand, "@Id", DbType.Int32, _User.Id);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateGroup(UserGroup _User)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserGroupUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupName", DbType.String, _User.UserGroupName);
                AddParameter(oDbCommand, "@UserGroupShortName", DbType.String, _User.UserGroupShortName);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _User.Remarks);

                if (_User.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _User.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);

                AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, _User.UserGroupID);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Add_ColumnCopyPermissionALL(int UserNewId, int CopyUserId)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnCopyPermissionALL_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserNewId", DbType.Int32, UserNewId);
                AddParameter(oDbCommand, "@CopyUserId", DbType.Int32, CopyUserId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add_ColumnPermissionALL(int UserId)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ColumnPermissionALL_InsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.Int32, UserId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int Id)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.Int32, Id);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserLoginHistory_Add(UserLoginHistoryBOL _UserLoginHistoryBOL)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserLoginHistoryInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _UserLoginHistoryBOL.UserId);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _UserLoginHistoryBOL.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserLoginHistory_Update(UserLoginHistoryBOL _UserLoginHistoryBOL)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserLoginHistoryUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _UserLoginHistoryBOL.UserId);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_UserGroup(int Id)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserGroupDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, Id);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 User_GetUserIDByUserNamePassword(string userName, string userPassword)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetUserIDByUserNamePassword", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserName", DbType.String, userName);
                AddParameter(oDbCommand, "@Password", DbType.String, userPassword);


                return (Int32)DbProviderHelper.ExecuteScalar(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int User_GetMaxID()
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetMaxID", CommandType.StoredProcedure);
                return (int)DbProviderHelper.ExecuteScalar(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable User_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_GetAllUserList", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }
        public static DataTable UserGroup_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserGroupList", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }
        public DataTable User_GetRoleByUserID(string userID)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetNameAndRoleByUserID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public static DataTable User_GetAllForDDL()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetAllDataForDDL", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public DataTable GetUserInfoByUserID(string userID)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_GetUserInfoByUserID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public DataTable User_GetAllForDDLByRole(int userRole)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_GetAllForDDLByRole", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserRole", DbType.Int32, userRole);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public string GetUserNameByUserID(string userID)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("GetUserNameByUserID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);

                return (string)DbProviderHelper.ExecuteScalar(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int User_UpdatePasswordUserName(string userName, string password, string confirmPassword, string userID)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("User_UpdatePasswordUserName", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserName", DbType.String, userName);
                AddParameter(oDbCommand, "@Password", DbType.String, password);
                AddParameter(oDbCommand, "@ConfirmPassword", DbType.String, confirmPassword);
                AddParameter(oDbCommand, "@UserID", DbType.String, userID);

                return (int)DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ForAudit_Add(User _User)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserForAuditInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserId", DbType.String, _User.UserId);
                AddParameter(oDbCommand, "@UserName", DbType.String, _User.UserName);
                AddParameter(oDbCommand, "@EmailID", DbType.String, _User.EmailID);
                AddParameter(oDbCommand, "@Password", DbType.String, _User.Password);
                AddParameter(oDbCommand, "@ConfirmPassword", DbType.String, _User.ConfirmPassword);
                if (_User.UserLocation != null)
                    AddParameter(oDbCommand, "@UserLocation", DbType.String, _User.UserLocation);
                else
                    AddParameter(oDbCommand, "@UserLocation", DbType.String, DBNull.Value);
                if (_User.CreateDate.HasValue)
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, _User.CreateDate);
                else
                    AddParameter(oDbCommand, "@CreateDate", DbType.DateTime, DBNull.Value);
                if (_User.UpdateDate.HasValue)
                    AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, _User.UpdateDate);
                else
                    AddParameter(oDbCommand, "@UpdateDate", DbType.DateTime, DBNull.Value);
                if (_User.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _User.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);
                if (_User.Role.HasValue)
                    AddParameter(oDbCommand, "@Role", DbType.Int32, _User.Role);
                else
                    AddParameter(oDbCommand, "@Role", DbType.Int32, DBNull.Value);

                if (_User.UserGroupID.HasValue)
                    AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, _User.UserGroupID);
                else
                    AddParameter(oDbCommand, "@UserGroupID", DbType.Int32, DBNull.Value);



                AddParameter(oDbCommand, "@MobileNo", DbType.String, _User.MobileNo);

                AddParameter(oDbCommand, "@UserFullName", DbType.String, _User.UserFullName);

                AddParameter(oDbCommand, "@UserIdCreateBy", DbType.String, _User.UserIdCreateBy);
                AddParameter(oDbCommand, "@PageId", DbType.String, _User.PageId);
                AddParameter(oDbCommand, "@Ref_Id", DbType.String, _User.Ref_Id);
                AddParameter(oDbCommand, "@TranStatus", DbType.String, _User.TranStatus);

                //return DbProviderHelper.ExecuteNonQuery(oDbCommand);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ForAudit_AddGroup(UserGroup _User)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserGroupForAuditInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserGroupName", DbType.String, _User.UserGroupName);
                AddParameter(oDbCommand, "@UserGroupShortName", DbType.String, _User.UserGroupShortName);
                AddParameter(oDbCommand, "@Remarks", DbType.String, _User.Remarks);

                if (_User.IsActive.HasValue)
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _User.IsActive);
                else
                    AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);
                AddParameter(oDbCommand, "@UserId", DbType.String, _User.UserId);
                AddParameter(oDbCommand, "@PageId", DbType.String, _User.PageId);
                AddParameter(oDbCommand, "@Ref_Id", DbType.String, _User.Ref_Id);
                AddParameter(oDbCommand, "@TranStatus", DbType.String, _User.TranStatus);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
