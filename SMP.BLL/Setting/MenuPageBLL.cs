using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class MenuPageBLL
    {
        public MenuPageDAL MenuPageDAL { get; set; }

        public MenuPageBLL()
        {
            MenuPageDAL = new MenuPageDAL();
        }

        public List<MenuPage> MenuPage_GetAll()
        {
            try
            {
                return MenuPageDAL.MenuPage_GetAll();
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
                return MenuPageDAL.MenuPage_GetDynamic(WhereCondition, OrderByExpression);
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
                return MenuPageDAL.MenuPage_GetPaged(StartRowIndex, RowPerPage, WhereClause, SortColumn, SortOrder);
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
                return MenuPageDAL.MenuPage_GetById(PageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuPage_Add(MenuPage _MenuPage)
        {
            try
            {
                return MenuPageDAL.Add(_MenuPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuPage_Update(MenuPage _MenuPage)
        {
            try
            {
                return MenuPageDAL.Update(_MenuPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int MenuPage_Delete(int PageId)
        {
            try
            {
                return MenuPageDAL.Delete(PageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<MenuPage> DeserializeMenuPages(string Path)
        //{
        //    try
        //    {
        //        return GenericXmlSerializer<List<MenuPage>>.Deserialize(Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void SerializeMenuPages(string Path, List<MenuPage> MenuPages)
        //{
        //    try
        //    {
        //        GenericXmlSerializer<List<MenuPage>>.Serialize(MenuPages, Path);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<MenuPage> MenuPage_GetAllByHeadUser(int headID, string userID, bool permission)
        {
            try
            {
                return MenuPageDAL.MenuPage_GetAllByHeadUser(headID, userID, permission);
            }
            catch
            {
                return null;
            }
        }


        public DataSet ColumnNamePage_GetAllByHeadID(int headID, string UserGroupID)
        {
            try
            {
                return MenuPageDAL.ColumnNamePage_GetAllByHeadID(headID, UserGroupID);
            }
            catch
            {
                return null;
            }
        }
        public DataSet MenuPage_GetAllByHeadID(int headID, string UserGroupID)
        {
            try
            {
                return MenuPageDAL.MenuPage_GetAllByHeadID(headID, UserGroupID);
            }
            catch
            {
                return null;
            }
        }

        public DataTable SubMenuPage_GetAllByHeadID(int headID, string UserGroupID)
        {
            try
            {
                return MenuPageDAL.SubMenuPage_GetAllByHeadID(headID, UserGroupID);
            }
            catch
            {
                return null;
            }
        }
    }
}
