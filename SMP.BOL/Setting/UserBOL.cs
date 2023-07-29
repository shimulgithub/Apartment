using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMP.BOL.Setting
{

    [Serializable()]
    public class User
    {
        public int Id { get; set; }

        public int UsersAutoID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public string UserLocation { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
        public int? Role { get; set; }
        public int? CompanyId { get; set; }
        public int? UserGroupID { get; set; }

        public int UserIdCreateBy { get; set; }
        public int PageId { get; set; }
        public int Ref_Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TranStatus { get; set; }


        public User()
        { }

        public User(int Id, string UserId, string UserName, string UserFullName, string Password, string ConfirmPassword, string EmailID, string MobileNo, string UserLocation,
            Nullable<DateTime> CreateDate, Nullable<DateTime> UpdateDate, Nullable<bool> IsActive, int Role, int CompanyId, int UserGroupID)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserFullName = UserFullName;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
            this.EmailID = EmailID;
            this.MobileNo = MobileNo;
            this.UserLocation = UserLocation;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.IsActive = IsActive;
            this.Role = Role;

            this.CompanyId = CompanyId;
            this.UserGroupID = UserGroupID;



        }

        public override string ToString()
        {
            return "Id = " + Id.ToString() + ",UserId = " + UserId + ",UserName = " + UserName + ", UserFullName=" + UserFullName + ",Password = " + Password + ",ConfirmPassword = " + ConfirmPassword + ",EmailID = " + EmailID + ", MobileNo=" + MobileNo + ",UserLocation = " + UserLocation + ",CreateDate = " + CreateDate.ToString() + ",UpdateDate = " + UpdateDate.ToString() + ",IsActive = " + IsActive.ToString() + ", Role = " + Role + ", CompanyId=" + CompanyId + ",UserGroupID=" + UserGroupID;
        }

    }

    public class UserGroup
    {
        public int UserGroupID { get; set; }


        public string UserGroupName { get; set; }
        public string UserGroupShortName { get; set; }
        public string Remarks { get; set; }

        public bool? IsActive { get; set; }
        public int UserId { get; set; }
        public int PageId { get; set; }
        public int Ref_Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TranStatus { get; set; }

    }
}
