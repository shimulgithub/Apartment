using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{

    [Serializable()]
    public class MenuPermission
    {


        public int MenuPermissionID { get; set; }
        public string UserID { get; set; }
        public int MainModuleMenuHeadID { get; set; }
        public int SubMenuHeadID { get; set; }
        public int PageID { get; set; }
        public bool CanView { get; set; }
        public string UserGroupID { get; set; }
        public int ColumnPermissionID { get; set; }
        public int ColumnHeadAutoID { get; set; }
        public int Order_Priority { get; set; }
        public int VersoinAutoID { get; set; }

        public string CreateBy { get; set; }
        public string CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public string ChangedDateTime { get; set; }


        //-----------For audit-----------

        public int AuditUserId { get; set; }
        public int AuditPageId { get; set; }
        public int Ref_Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TranStatus { get; set; }

        public MenuPermission()
        { }

        public MenuPermission(int MenuPermissionID, string UserID, int MainModuleMenuHeadID, int SubMenuHeadID, int PageID, bool CanView, string UserGroupID)
        {
            this.MenuPermissionID = MenuPermissionID;
            this.UserID = UserID;
            this.MainModuleMenuHeadID = MainModuleMenuHeadID;
            this.SubMenuHeadID = SubMenuHeadID;
            this.PageID = PageID;
            this.CanView = CanView;
            this.UserGroupID = UserGroupID;
        }

        public override string ToString()
        {
            return "MenuPermissionID = " + MenuPermissionID.ToString() + ",UserID = " + UserID + ",MainModuleMenuHeadID = " + MainModuleMenuHeadID.ToString() + ",SubMenuHeadID = " + SubMenuHeadID.ToString() + ",PageID = " + PageID.ToString() + ",CanView = " + CanView.ToString() + ",UserGroupID = " + UserGroupID.ToString();
        }
    }
}
