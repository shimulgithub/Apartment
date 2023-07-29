using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    [Serializable()]
    public   class DisableReasonBOL
    {
        public int Id { get; set; }
        public string DisableReason { get; set; }
        public string Description { get; set; }

    }
}
