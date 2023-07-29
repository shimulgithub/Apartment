using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class UserLoginHistoryBOL
    {
        public int? AutoID { get; set; }
        public string AssignmentRef { get; set; }
        public string LeaveYear { get; set; }
        public string LeaveType { get; set; }
        public string AllowancesStartDateBind { get; set; }
        public string AllowancesEndDateBind { get; set; }
        public DateTime? AllowancesStartDate { get; set; }
        public DateTime? AllowancesEndDate { get; set; }
        public int? Allowances { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? ChangedDateTime { get; set; }
        public int LeaveMasterAutoId { get; set; }
        public string AsssignmentRef { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string Taken { get; set; }
        public string Remaining { get; set; }
        public string Units { get; set; }
        public string AsignmentStart { get; set; }
        public string AsignmentActual_End { get; set; }
        public string AsignmentExpected_End { get; set; }
        public string Comments { get; set; }
        public string CommentsTypeID { get; set; }

        //--------Audit----------
        public int UserId { get; set; }
        public int PageId { get; set; }
        public int Ref_Id { get; set; }
        public int TranStatus { get; set; }
        public DateTime DateTime { get; set; }



    }
}