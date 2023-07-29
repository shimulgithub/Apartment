using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class MarkGradeEntryBOL
    {
        public int Id { get; set; }
        public int ExamGroupId { get; set; }
        public string  GradeName { get; set; }
        public int PercentFrom { get; set; }
        public int PercentTo { get; set; }
        public double GradePoint { get; set; }
        public string Description { get; set; }
    }
}
