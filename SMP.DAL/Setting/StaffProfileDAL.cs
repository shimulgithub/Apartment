using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
   public  class StaffProfileDAL
    {

        public StaffProfileDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, StaffProfileBOL oStaffProfile)
        {
            oStaffProfile.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oStaffProfile.StaffId = Convert.ToInt32(oDbDataReader["StaffId"]);
            oStaffProfile.Name = Convert.ToString(oDbDataReader["Name"]);
            oStaffProfile.FatherName = Convert.ToString(oDbDataReader["FatherName"]);
            oStaffProfile.MotherName = Convert.ToString(oDbDataReader["MotherName"]);
            oStaffProfile.Phone = Convert.ToString(oDbDataReader["Phone"]);
            oStaffProfile.EmargencyNo = Convert.ToString(oDbDataReader["EmargencyNo"]);
            oStaffProfile.Email = Convert.ToString(oDbDataReader["Email"]);
            oStaffProfile.DOBBind = Convert.ToString(oDbDataReader["DOB"]);
            oStaffProfile.Gender = Convert.ToInt32(oDbDataReader["GenderId"]);
            oStaffProfile.MaritalStatus = Convert.ToInt32(oDbDataReader["MaritalId"]);
            oStaffProfile.PresentAddress = Convert.ToString(oDbDataReader["PresentAddress"]);
            oStaffProfile.PermanentAddress = Convert.ToString(oDbDataReader["PermanentAddress"]);
            oStaffProfile.NID = Convert.ToString(oDbDataReader["NID"]);
            oStaffProfile.DepartmentId = Convert.ToInt32(oDbDataReader["DepartmentId"]);
            oStaffProfile.DesignationId = Convert.ToInt32(oDbDataReader["DesignationId"]);
            oStaffProfile.ReligionId = Convert.ToInt32(oDbDataReader["ReligionId"]);
            oStaffProfile.BloodGroupId = Convert.ToInt32(oDbDataReader["BloodGroupId"]);
            oStaffProfile.JoiningDateBind = Convert.ToString(oDbDataReader["JoiningDate"]);
            oStaffProfile.BankAccountTitle = Convert.ToString(oDbDataReader["BankAccountTitle"]);
            oStaffProfile.BankId = Convert.ToInt32(oDbDataReader["BankId"]);
            oStaffProfile.BankAccountTitle = Convert.ToString(oDbDataReader["BankAccountTitle"]);
            oStaffProfile.BankBranchName = Convert.ToString(oDbDataReader["BankBranchName"]);
            oStaffProfile.BankAccountNo = Convert.ToString(oDbDataReader["BankAccountNo"]);
            oStaffProfile.BankAddress = Convert.ToString(oDbDataReader["BankAddress"]);
            oStaffProfile.BasicSalary = Convert.ToDouble(oDbDataReader["BasicSalary"]);
         


  
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(StaffProfileBOL _StaffProfile)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StaffProfileInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StaffProfile.Id);
                AddParameter(oDbCommand, "@Name", DbType.String, _StaffProfile.Name);
                AddParameter(oDbCommand, "@FatherName", DbType.String, _StaffProfile.FatherName);
                AddParameter(oDbCommand, "@MotherName", DbType.String, _StaffProfile.MotherName);
                AddParameter(oDbCommand, "@Phone", DbType.String, _StaffProfile.Phone);
                AddParameter(oDbCommand, "@EmargencyNo", DbType.String, _StaffProfile.EmargencyNo);
                AddParameter(oDbCommand, "@Email", DbType.String, _StaffProfile.Email);
                AddParameter(oDbCommand, "@DOB", DbType.Date, _StaffProfile.DOB);
                AddParameter(oDbCommand, "@Gender", DbType.Int32, _StaffProfile.Gender);
                AddParameter(oDbCommand, "@MaritalStatus", DbType.Int32, _StaffProfile.MaritalStatus);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, _StaffProfile.PresentAddress);
                AddParameter(oDbCommand, "@PermanentAddress", DbType.String, _StaffProfile.PermanentAddress);
                AddParameter(oDbCommand, "@NID", DbType.String, _StaffProfile.NID);
                AddParameter(oDbCommand, "@DepartmentId", DbType.Int32, _StaffProfile.DepartmentId);
                AddParameter(oDbCommand, "@DesignationId", DbType.Int32, _StaffProfile.DesignationId);
                AddParameter(oDbCommand, "@ReligionId", DbType.Int32, _StaffProfile.ReligionId);
                AddParameter(oDbCommand, "@BloodGroupId", DbType.Int32, _StaffProfile.BloodGroupId);
                AddParameter(oDbCommand, "@JoiningDate", DbType.Date, _StaffProfile.JoiningDate);
                AddParameter(oDbCommand, "@BankAccountTitle", DbType.String, _StaffProfile.BankAccountTitle);
                AddParameter(oDbCommand, "@BankId", DbType.Int32, _StaffProfile.BankId);
                AddParameter(oDbCommand, "@BankBranchName", DbType.String, _StaffProfile.BankBranchName);
                AddParameter(oDbCommand, "@BankAccountNo", DbType.String, _StaffProfile.BankAccountNo);
                AddParameter(oDbCommand, "@BankAddress", DbType.String, _StaffProfile.BankBranchName);
                AddParameter(oDbCommand, "@BasicSalary", DbType.Double, _StaffProfile.BasicSalary);
                AddParameter(oDbCommand, "@CreatedBy", DbType.String, _StaffProfile.CreatedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(StaffProfileBOL _StaffProfile)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StaffProfileUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StaffProfile.Id);
                AddParameter(oDbCommand, "@StaffId", DbType.String, _StaffProfile.StaffId);
                AddParameter(oDbCommand, "@Name", DbType.String, _StaffProfile.Name);
                AddParameter(oDbCommand, "@FatherName", DbType.String, _StaffProfile.FatherName);
                AddParameter(oDbCommand, "@MotherName", DbType.String, _StaffProfile.MotherName);
                AddParameter(oDbCommand, "@Phone", DbType.String, _StaffProfile.Phone);
                AddParameter(oDbCommand, "@EmargencyNo", DbType.String, _StaffProfile.EmargencyNo);
                AddParameter(oDbCommand, "@Email", DbType.String, _StaffProfile.Email);
                AddParameter(oDbCommand, "@DOB", DbType.Date, _StaffProfile.DOB);
                AddParameter(oDbCommand, "@Gender", DbType.Int32, _StaffProfile.Gender);
                AddParameter(oDbCommand, "@MaritalStatus", DbType.Int32, _StaffProfile.MaritalStatus);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, _StaffProfile.PresentAddress);
                AddParameter(oDbCommand, "@PermanentAddress", DbType.String, _StaffProfile.PermanentAddress);
                AddParameter(oDbCommand, "@NID", DbType.String, _StaffProfile.NID);
                AddParameter(oDbCommand, "@DepartmentId", DbType.Int32, _StaffProfile.DepartmentId);
                AddParameter(oDbCommand, "@DesignationId", DbType.Int32, _StaffProfile.DesignationId);
                AddParameter(oDbCommand, "@ReligionId", DbType.Int32, _StaffProfile.ReligionId);
                AddParameter(oDbCommand, "@BloodGroupId", DbType.Int32, _StaffProfile.BloodGroupId);
                AddParameter(oDbCommand, "@JoiningDate", DbType.Date, _StaffProfile.JoiningDate);
                AddParameter(oDbCommand, "@BankAccountTitle", DbType.String, _StaffProfile.BankAccountTitle);
                AddParameter(oDbCommand, "@BankId", DbType.Int32, _StaffProfile.BankId);
                AddParameter(oDbCommand, "@BankBranchName", DbType.String, _StaffProfile.BankBranchName);
                AddParameter(oDbCommand, "@BankAccountNo", DbType.String, _StaffProfile.BankAccountNo);
                AddParameter(oDbCommand, "@BankAddress", DbType.String, _StaffProfile.BankBranchName);
                AddParameter(oDbCommand, "@BasicSalary", DbType.Double, _StaffProfile.BasicSalary);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _StaffProfile.ChangedBy);     //AddParameter(oDbCommand, "@ChangedBy", DbType.String, _StaffProfile.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(StaffProfileBOL _StaffProfile)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StaffProfileDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StaffProfile.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable StaffProfile_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StaffProfileList", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                dtUser.Load(oDbDataReader);
                oDbDataReader.Close();
                return dtUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                dtUser.Dispose();
                oDbDataReader.Dispose();
            }
        }

        public StaffProfileBOL StaffProfile_GetById(StaffProfileBOL _StaffProfile)
        {
            try
            {
                StaffProfileBOL oStaffProfile = new StaffProfileBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StaffProfileListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StaffProfile.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                  BuildEntity(oDbDataReader, oStaffProfile);
                }
                oDbDataReader.Close();
                return oStaffProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
