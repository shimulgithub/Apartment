using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    public class StaffProfileBOL
    {

        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Phone { get; set; }
        public string EmargencyNo { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string DOBBind { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NID { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int ReligionId { get; set; }
        public int BloodGroupId { get; set; }
        public DateTime JoiningDate { get; set; }
        public string JoiningDateBind { get; set; }
        public string BankAccountTitle { get; set; }
        public int BankId { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAddress { get; set; }
        public double BasicSalary { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }


    }
}
