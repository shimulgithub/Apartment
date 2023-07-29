using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class AttendanceBOL
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string AttendanceDateBind { get; set; }
        public int IsPresent { get; set; }
        public int IsAbsence { get; set; }
        public int IsHalfDay { get; set; }
        public string Note { get; set; }
        public string CreateBy { get; set; }
        public string ChangedBy { get; set; }

    }
}
