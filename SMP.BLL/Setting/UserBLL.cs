using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class UserBLL
    {
        public UserDAL UserDAL { get; set; }

        public UserBLL()
        {
            UserDAL = new UserDAL();
        }

        public List<User> User_GetAll()
        {
            try
            {
                return UserDAL.User_GetAll();
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
                return UserDAL.User_GetDynamic(WhereCondition, OrderByExpression);
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
                return UserDAL.User_GetPaged(StartRowIndex, RowPerPage, WhereClause, SortColumn, SortOrder);
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
                return UserDAL.User_GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int User_Add(User _User)
        {
            try
            {
                return UserDAL.Add(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserGroup_Add(UserGroup _User)
        {
            try
            {
                return UserDAL.AddGroup(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int User_Update(User _User)
        {
            try
            {
                return UserDAL.Update(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int User_UpdateChange(User _User)
        {
            try
            {
                return UserDAL.UpdateChange(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserGroup_Update(UserGroup _User)
        {
            try
            {
                return UserDAL.UpdateGroup(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add_ColumnCopyPermissionALL(int UserId, int CopyUserId)
        {
            try
            {
                return UserDAL.Add_ColumnCopyPermissionALL(UserId, CopyUserId);
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
                return UserDAL.Add_ColumnPermissionALL(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int User_Delete(int Id)
        {
            try
            {
                return UserDAL.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserGroup_Delete(int Id)
        {
            try
            {
                return UserDAL.Delete_UserGroup(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<User> DeserializeUsers(string Path)
        //{
        //    try
        //    {
        //        return GenericXmlSerializer<List<User>>.Deserialize(Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void SerializeUsers(string Path, List<User> Users)
        //{
        //    try
        //    {
        //        GenericXmlSerializer<List<User>>.Serialize(Users, Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public int UserLoginHistory_Add(UserLoginHistoryBOL _UserLoginHistoryBOL)
        {
            try
            {
                return UserDAL.UserLoginHistory_Add(_UserLoginHistoryBOL);
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
                return UserDAL.UserLoginHistory_Update(_UserLoginHistoryBOL);
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
                return UserDAL.User_GetUserIDByUserNamePassword(userName, userPassword);
            }
            catch
            {
                return 0;
            }
        }

        public int User_GetMaxID()
        {
            try
            {
                return UserDAL.User_GetMaxID();
            }
            catch
            {
                return 0;
            }
        }

        public DataTable User_GetDataForGV()
        {
            try
            {
                return UserDAL.User_GetDataForGV();
            }
            catch
            {
                return null;
            }
        }
        public DataTable UserGroup_GetDataForGV()
        {
            try
            {
                return UserDAL.UserGroup_GetDataForGV();
            }
            catch
            {
                return null;
            }
        }
        public DataTable User_GetRoleByUserID(string userID)
        {
            try
            {
                return UserDAL.User_GetRoleByUserID(userID);
            }
            catch
            {
                return null;
            }
        }



        public DataTable User_GetAllForDDL()
        {
            try
            {
                return UserDAL.User_GetAllForDDL();
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetUserInfoByUserID(string userID)
        {
            try
            {
                return UserDAL.GetUserInfoByUserID(userID);
            }
            catch
            {
                return null;
            }
        }

        public DataTable User_GetAllForDDLByRole(int userRole)
        {
            try
            {
                return UserDAL.User_GetAllForDDLByRole(userRole);
            }
            catch
            {
                return null;
            }
        }

        public string GetUserNameByUserID(string userID)
        {
            try
            {
                return UserDAL.GetUserNameByUserID(userID);
            }
            catch
            {
                return "";
            }
        }

        public int User_UpdatePasswordUserName(string userName, string password, string confirmPassword, string userID)
        {
            try
            {
                return UserDAL.User_UpdatePasswordUserName(userName, password, confirmPassword, userID);
            }
            catch
            {
                return 0;
            }
        }
        public int UserForAudit_Add(User _User)
        {
            try
            {
                return UserDAL.ForAudit_Add(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserGroupForAudit_Add(UserGroup _User)
        {
            try
            {
                return UserDAL.ForAudit_AddGroup(_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
