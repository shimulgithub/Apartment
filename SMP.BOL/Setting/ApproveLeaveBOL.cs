using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public  class ApproveLeaveBOL
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ApplyDateBind { get; set; }
        public string FromDateBind { get; set; }
        public string ToDateBind { get; set; }
        public int Status { get; set; }
        public int ApprovedBy { get; set; }
        public string Reason { get; set; }
        public string  CreateBy { get; set; }
        public string ChangedBy { get; set; }

    }
}
