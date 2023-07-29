using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public  class FeesMasterBOL
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int FeesTypeId { get; set; }
        public DateTime DueDate { get; set; }
        public string  DueDateBind { get; set; }
        public int Amount { get; set; }
        public int FinePercentage { get; set; }
        public int FineAmount { get; set; }
        public int TotalAmount { get; set; }
        public string  CreateBy { get; set; }
        public string  ChangedBy { get; set; }
     
    }
}
