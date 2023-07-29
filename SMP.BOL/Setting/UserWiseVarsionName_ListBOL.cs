using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    [Serializable()]
    public class UserWiseVarsionName_ListBOL
    {
        public int VersoinAutoID { get; set; }
        public string VersoinName { get; set; }
        public int PageId { get; set; }
        public int UserID { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedDateTime { get; set; }
        public string TableName { get; set; }
    }
}
