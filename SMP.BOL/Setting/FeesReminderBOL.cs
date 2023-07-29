using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
   public  class FeesReminderBOL
    {
        public int Id { get; set; }
        public int IsActive { get; set; }
        public string ReminderType { get; set; }
        public int Days { get; set; }
        public string Description { get; set; }
    }
}
