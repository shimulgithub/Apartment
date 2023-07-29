using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class IncomeBOL
    {
        public int Id { get; set; }
        public int IncomeHeadId { get; set; }
        public string IncomeName { get; set; }
        public string  InvoiceNo { get; set; }
        public string RefNo { get; set; }
        
        public DateTime Date { get; set; }
        public string DateBind { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public string ChangedBy { get; set; }
      
    }
}
