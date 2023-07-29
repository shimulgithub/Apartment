using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    [Serializable()]
    public class MenuPage
    {

        public int PageId { get; set; }
        public int MenuHeadID { get; set; }
        public string PageName { get; set; }
        public string URL { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool IsRemoved { get; set; }
        public string LiID { get; set; }


        public int SubMenuHeadID { get; set; }
        public int MainModuleMenuHeadID { get; set; }
        public string SubMenuHeadName { get; set; }
        public int SubMenuHeadPriority { get; set; }

        public string SubMenuHeadIcone { get; set; }
        public int SubMenuHeadIsActive { get; set; }

        public bool? CanViewSubMenuHead { get; set; }

    }
}
