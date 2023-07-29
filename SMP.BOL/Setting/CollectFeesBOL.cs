using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class CollectFeesBOL
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? Date { get; set; }
        public string   DateBind  { get; set; }
        public double Amount { get; set; }
        public double DisCountId { get; set; }
        public int PayModeId { get; set; }
        public double DisCount { get; set; }
        public double  Fine { get; set; }
        public double Total { get; set; }
        public string  Note { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int FeesTypeId { get; set; }
        public string  CreateBy { get; set; }
        public string  ChangedBy { get; set; }
    }
}
