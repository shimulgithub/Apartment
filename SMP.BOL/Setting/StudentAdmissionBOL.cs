using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    [Serializable()]
    public class StudentAdmissionBOL
    {
        public int Id { get; set; }
        public string ClassId { get; set; }
        public string SectionId { get; set; }
        public string RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Images { get; set; }
        public string GenderId { get; set; }
        public DateTime DOB { get; set; }
        public string CategoryId { get; set; }
        public string ReligionId { get; set; }
        public string MobileNo { get; set; }
        public string BloodGroupId { get; set; }
        public string IdCardNo { get; set; }
        public string BirthCertificate { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string FatherName { get; set; }
        public string FatherPhoneNo { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherPhoneNo { get; set; }
        public string MotherOccupation { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhoneNo { get; set; }
        public string GuardianOccupation { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangedDateTime { get; set; }

        public string CreateByBind { get; set; }
        public string ChangedByBind { get; set; }
        public string AdmissionDateBind { get; set; }
        public string DOBBind { get; set; }
        public string Year { get; set; }
    }
}
