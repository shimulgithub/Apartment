using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{

    public class MenuHeadBLL
    {

        public MenuHeadDAL MenuHeadDAL { get; set; }

        public MenuHeadBLL()
        {
            MenuHeadDAL = new MenuHeadDAL();
        }

        public List<MenuHead> MenuHead_GetAll()
        {
            try
            {
                return MenuHeadDAL.MenuHead_GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuHead> ColumnHead_GetAll(string UserId, string PageId)
        {
            try
            {
                return MenuHeadDAL.ColumnHead_GetAll(UserId, PageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuHead> MenuHead_GetAll(string UserGroupID)
        {
            try
            {
                return MenuHeadDAL.MenuHead_GetAll(UserGroupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuHead> MenuHead_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            try
            {
                return MenuHeadDAL.MenuHead_GetDynamic(WhereCondition, OrderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MenuHead> MenuHead_GetPaged(int StartRowIndex, int RowPerPage, string WhereClause, string SortColumn, string SortOrder)
        {
            try
            {
                return MenuHeadDAL.MenuHead_GetPaged(StartRowIndex, RowPerPage, WhereClause, SortColumn, SortOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuHead MenuHead_GetById(int MenuHeadID)
        {
            try
            {
                return MenuHeadDAL.MenuHead_GetById(MenuHeadID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuHead_Add(MenuHead _MenuHead)
        {
            try
            {
                return MenuHeadDAL.Add(_MenuHead);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuHead_Update(MenuHead _MenuHead)
        {
            try
            {
                return MenuHeadDAL.Update(_MenuHead);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuHead_Delete(int MenuHeadID)
        {
            try
            {
                return MenuHeadDAL.Delete(MenuHeadID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<MenuHead> DeserializeMenuHeads(string Path)
        //{
        //    try
        //    {
        //        return GenericXmlSerializer<List<MenuHead>>.Deserialize(Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void SerializeMenuHeads(string Path, List<MenuHead> MenuHeads)
        //{
        //    try
        //    {
        //        GenericXmlSerializer<List<MenuHead>>.Serialize(MenuHeads, Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<MenuHead> MenuHead_GetAllByUserPermission(string userID, bool permission)
        {
            try
            {
                return MenuHeadDAL.MenuHead_GetAllByUserPermission(userID, permission);
            }
            catch
            {
                return null;
            }
        }
    }
}
