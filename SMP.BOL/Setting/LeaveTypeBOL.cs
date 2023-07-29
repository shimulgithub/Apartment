using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class LeaveTypeBOL
    {
        public int AutoID { get; set; }
        public string Code { get; set; }
        public string LeaveType { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }
    }
}
