using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class MenuPermissionBLL
    {
        public MenuPermissionDAL MenuPermissionDAL { get; set; }

        public MenuPermissionBLL()
        {
            MenuPermissionDAL = new MenuPermissionDAL();
        }

        public List<MenuPermission> MenuPermission_GetAll()
        {
            try
            {
                return MenuPermissionDAL.MenuPermission_GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int MenuPermission_Add_ColumnFromUserGroupWisePagePermission(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.Add_ColumnFromUserGroupWisePagePermission(_MenuPermission);
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
                return MenuPermissionDAL.MenuPermission_GetDynamic(WhereCondition, OrderByExpression);
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
                return MenuPermissionDAL.MenuPermission_GetPaged(StartRowIndex, RowPerPage, WhereClause, SortColumn, SortOrder);
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
                return MenuPermissionDAL.MenuPermission_GetById(GrantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuPermission_Add(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.Add(_MenuPermission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int MenuPermission_Add_Column(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.Add_Column(_MenuPermission);
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
                return MenuPermissionDAL.ColumnPermission_DeleteByUserID(userID, PageId, Versionid);
            }
            catch
            {
                return 0;
            }
        }


        public int MenuPermission_Update(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.Update(_MenuPermission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuPermission_Delete(int GrantID)
        {
            try
            {
                return MenuPermissionDAL.Delete(GrantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<MenuPermission> DeserializeMenuPermissions(string Path)
        //{
        //    try
        //    {
        //        return GenericXmlSerializer<List<MenuPermission>>.Deserialize(Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void SerializeMenuPermissions(string Path, List<MenuPermission> MenuPermissions)
        //{
        //    try
        //    {
        //        GenericXmlSerializer<List<MenuPermission>>.Serialize(MenuPermissions, Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public int MenuPermission_UpdateUserID(string userID)
        {
            try
            {
                return MenuPermissionDAL.MenuPermission_UpdateUserID(userID);
            }
            catch
            {
                return 0;
            }
        }

        public int MenuPermission_DeleteByUserID(string userID)
        {
            try
            {
                return MenuPermissionDAL.MenuPermission_DeleteByUserID(userID);
            }
            catch
            {
                return 0;
            }
        }
        public int ColumnPermission_DeleteByUserID(string userID, string PageId)
        {
            try
            {
                return MenuPermissionDAL.ColumnPermission_DeleteByUserID(userID, PageId);
            }
            catch
            {
                return 0;
            }
        }


        public DataTable MenuPermission_IsPageAuthorized(string userID, string requestedURL)
        {
            try
            {
                return MenuPermissionDAL.MenuPermission_IsPageAuthorized(userID, requestedURL);
            }
            catch
            {
                return null;
            }
        }

        public DataTable CommonAndInternalPages_IsExist(string requestedURL)
        {
            try
            {
                return MenuPermissionDAL.CommonAndInternalPages_IsExist(requestedURL);
            }
            catch
            {
                return null;
            }
        }


        public int MenuPermissionForAudit_Add_Column(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.ForAuditAdd_Column(_MenuPermission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int MenuPermissionForAudit_Update(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.ForAudit_Update(_MenuPermission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int MenuPermissionForAudit_Update_ColumnFromUserGroupWisePagePermission(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.ForAudit_Update_ColumnFromUserGroupWisePagePermission(_MenuPermission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int MenuPermissionForAudit_Add_ColumnFromUserGroupWisePagePermission(MenuPermission _MenuPermission)
        {
            try
            {
                return MenuPermissionDAL.ForAuditAdd_ColumnFromUserGroupWisePagePermission(_MenuPermission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
