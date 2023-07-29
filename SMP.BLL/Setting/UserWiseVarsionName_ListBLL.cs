using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;


namespace SMP.BLL.Setting
{
    public class UserWiseVarsionName_ListBLL
    {


        public UserWiseVarsionName_ListDAL UserWiseVarsionName_ListDAL { get; set; }

        public UserWiseVarsionName_ListBLL()
        {
            UserWiseVarsionName_ListDAL = new UserWiseVarsionName_ListDAL();
        }

        public int UserWiseVarsionName_List_Add(UserWiseVarsionName_ListBOL _UserWiseVarsionName_ListBOL)
        {
            try
            {
                return UserWiseVarsionName_ListDAL.Add(_UserWiseVarsionName_ListBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UserWiseVarsionName_ListGVEdit(UserWiseVarsionName_ListBOL _UserWiseVarsionName_ListBOL)
        {
            try
            {
                return UserWiseVarsionName_ListDAL.UserWiseVarsionName_ListGVEdit(_UserWiseVarsionName_ListBOL);
            }
            catch
            {
                return null;
            }
        }
        public DataTable UserWiseVarsionName_ListGVList()
        {
            try
            {
                return UserWiseVarsionName_ListDAL.UserWiseVarsionName_ListGVList();
            }
            catch
            {
                return null;
            }
        }
        public DataTable VersionName_ExistByUserID(string UserID, string VersionName)
        {
            try
            {
                return UserWiseVarsionName_ListDAL.VersionName_ExistByUserID(UserID, VersionName);
            }
            catch
            {
                return null;
            }
        }
        public DataTable UserWiseVarsionName_ListGVList(string UserID)
        {
            try
            {
                return UserWiseVarsionName_ListDAL.UserWiseVarsionName_ListGVList(UserID);
            }
            catch
            {
                return null;
            }
        }
        public int UserWiseVarsionName_List_Update(UserWiseVarsionName_ListBOL _UserWiseVarsionName_ListBOL)
        {
            try
            {
                return UserWiseVarsionName_ListDAL.Update(_UserWiseVarsionName_ListBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UserWiseVarsionName_List_Delete(UserWiseVarsionName_ListBOL _UserWiseVarsionName_ListBOL)
        {
            try
            {
                return UserWiseVarsionName_ListDAL.Delete(_UserWiseVarsionName_ListBOL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
