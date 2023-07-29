using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class StudentAdmissionDAL
    {
        public StudentAdmissionDAL()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, StudentAdmissionBOL oStudentAdmissionBOL)
        {
            oStudentAdmissionBOL.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oStudentAdmissionBOL.ClassId = Convert.ToString(oDbDataReader["ClassId"]);
            oStudentAdmissionBOL.SectionId = Convert.ToString(oDbDataReader["SectionId"]);
            oStudentAdmissionBOL.RollNo = Convert.ToString(oDbDataReader["RollNo"]);
            oStudentAdmissionBOL.FirstName = Convert.ToString(oDbDataReader["FirstName"]);
            oStudentAdmissionBOL.LastName = Convert.ToString(oDbDataReader["LastName"]);
            oStudentAdmissionBOL.GenderId = Convert.ToString(oDbDataReader["GenderId"]);
            oStudentAdmissionBOL.DOBBind = Convert.ToString(oDbDataReader["DOB"]);
            oStudentAdmissionBOL.CategoryId = Convert.ToString(oDbDataReader["CategoryId"]);
            oStudentAdmissionBOL.ReligionId = Convert.ToString(oDbDataReader["ReligionId"]);
            oStudentAdmissionBOL.MobileNo = Convert.ToString(oDbDataReader["MobileNo"]);
            oStudentAdmissionBOL.BloodGroupId = Convert.ToString(oDbDataReader["BloodGroupId"]);
            oStudentAdmissionBOL.IdCardNo = Convert.ToString(oDbDataReader["IdCardNo"]);
            oStudentAdmissionBOL.BirthCertificate = Convert.ToString(oDbDataReader["BirthCertificate"]);
            oStudentAdmissionBOL.Email = Convert.ToString(oDbDataReader["Email"]);
            oStudentAdmissionBOL.PresentAddress = Convert.ToString(oDbDataReader["PresentAddress"]);
            oStudentAdmissionBOL.PermanentAddress = Convert.ToString(oDbDataReader["PermanentAddress"]);
            oStudentAdmissionBOL.AdmissionDateBind = Convert.ToString(oDbDataReader["AdmissionDate"]);
            oStudentAdmissionBOL.FatherName = Convert.ToString(oDbDataReader["FatherName"]);
            oStudentAdmissionBOL.FatherPhoneNo = Convert.ToString(oDbDataReader["FatherPhoneNo"]);
            oStudentAdmissionBOL.FatherOccupation = Convert.ToString(oDbDataReader["FatherOccupation"]);
            oStudentAdmissionBOL.MotherName = Convert.ToString(oDbDataReader["MotherName"]);
            oStudentAdmissionBOL.MotherPhoneNo = Convert.ToString(oDbDataReader["MotherPhoneNo"]);
            oStudentAdmissionBOL.MotherOccupation = Convert.ToString(oDbDataReader["MotherOccupation"]);
            oStudentAdmissionBOL.GuardianName = Convert.ToString(oDbDataReader["GuardianName"]);
            oStudentAdmissionBOL.GuardianPhoneNo = Convert.ToString(oDbDataReader["GuardianPhoneNo"]);
            oStudentAdmissionBOL.GuardianOccupation = Convert.ToString(oDbDataReader["GuardianOccupation"]);
            oStudentAdmissionBOL.Year = Convert.ToString(oDbDataReader["Year"]);
        }

        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(StudentAdmissionBOL _StudentAdmission)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentAdmissionInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentAdmission.Id);
                AddParameter(oDbCommand, "@ClassId", DbType.String, _StudentAdmission.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.String, _StudentAdmission.SectionId);
                AddParameter(oDbCommand, "@RollNo", DbType.String, _StudentAdmission.RollNo);
                AddParameter(oDbCommand, "@FirstName", DbType.String, _StudentAdmission.FirstName);
                AddParameter(oDbCommand, "@LastName", DbType.String, _StudentAdmission.LastName);
                AddParameter(oDbCommand, "@GenderId", DbType.String, _StudentAdmission.GenderId);
                AddParameter(oDbCommand, "@DOB", DbType.DateTime, _StudentAdmission.DOB);
                AddParameter(oDbCommand, "@CategoryId", DbType.String, _StudentAdmission.CategoryId);
                AddParameter(oDbCommand, "@ReligionId", DbType.String, _StudentAdmission.ReligionId);
                AddParameter(oDbCommand, "@MobileNo", DbType.String, _StudentAdmission.MobileNo);
                AddParameter(oDbCommand, "@BloodGroupId", DbType.String, _StudentAdmission.BloodGroupId);
                AddParameter(oDbCommand, "@IdCardNo", DbType.String, _StudentAdmission.IdCardNo);
                AddParameter(oDbCommand, "@BirthCertificate", DbType.String, _StudentAdmission.BirthCertificate);
                AddParameter(oDbCommand, "@Email", DbType.String, _StudentAdmission.Email);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, _StudentAdmission.PresentAddress);
                AddParameter(oDbCommand, "@PermanentAddress", DbType.String, _StudentAdmission.PermanentAddress);
                AddParameter(oDbCommand, "@AdmissionDate", DbType.DateTime, _StudentAdmission.AdmissionDate);
                AddParameter(oDbCommand, "@FatherName", DbType.String, _StudentAdmission.FatherName);
                AddParameter(oDbCommand, "@FatherPhoneNo", DbType.String, _StudentAdmission.FatherPhoneNo);
                AddParameter(oDbCommand, "@FatherOccupation", DbType.String, _StudentAdmission.FatherOccupation);
                AddParameter(oDbCommand, "@MotherName", DbType.String, _StudentAdmission.MotherName);
                AddParameter(oDbCommand, "@MotherPhoneNo", DbType.String, _StudentAdmission.MotherPhoneNo);
                AddParameter(oDbCommand, "@MotherOccupation", DbType.String, _StudentAdmission.MotherOccupation);
                AddParameter(oDbCommand, "@GuardianName", DbType.String, _StudentAdmission.GuardianName);
                AddParameter(oDbCommand, "@GuardianPhoneNo", DbType.String, _StudentAdmission.GuardianPhoneNo);
                AddParameter(oDbCommand, "@GuardianOccupation", DbType.String, _StudentAdmission.GuardianOccupation);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _StudentAdmission.CreateBy);
                AddParameter(oDbCommand, "@Year", DbType.String, _StudentAdmission.Year);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(StudentAdmissionBOL _StudentAdmission)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentAdmissionUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentAdmission.Id);
                AddParameter(oDbCommand, "@ClassId", DbType.String, _StudentAdmission.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.String, _StudentAdmission.SectionId);
                AddParameter(oDbCommand, "@RollNo", DbType.String, _StudentAdmission.RollNo);
                AddParameter(oDbCommand, "@FirstName", DbType.String, _StudentAdmission.FirstName);
                AddParameter(oDbCommand, "@LastName", DbType.String, _StudentAdmission.LastName);
                AddParameter(oDbCommand, "@GenderId", DbType.String, _StudentAdmission.GenderId);
                AddParameter(oDbCommand, "@DOB", DbType.DateTime, _StudentAdmission.DOB);
                AddParameter(oDbCommand, "@CategoryId", DbType.String, _StudentAdmission.CategoryId);
                AddParameter(oDbCommand, "@ReligionId", DbType.String, _StudentAdmission.ReligionId);
                AddParameter(oDbCommand, "@MobileNo", DbType.String, _StudentAdmission.MobileNo);
                AddParameter(oDbCommand, "@BloodGroupId", DbType.String, _StudentAdmission.BloodGroupId);
                AddParameter(oDbCommand, "@IdCardNo", DbType.String, _StudentAdmission.IdCardNo);
                AddParameter(oDbCommand, "@BirthCertificate", DbType.String, _StudentAdmission.BirthCertificate);
                AddParameter(oDbCommand, "@Email", DbType.String, _StudentAdmission.Email);
                AddParameter(oDbCommand, "@PresentAddress", DbType.String, _StudentAdmission.PresentAddress);
                AddParameter(oDbCommand, "@PermanentAddress", DbType.String, _StudentAdmission.PermanentAddress);
                AddParameter(oDbCommand, "@AdmissionDate", DbType.DateTime, _StudentAdmission.AdmissionDate);
                AddParameter(oDbCommand, "@FatherName", DbType.String, _StudentAdmission.FatherName);
                AddParameter(oDbCommand, "@FatherPhoneNo", DbType.String, _StudentAdmission.FatherPhoneNo);
                AddParameter(oDbCommand, "@FatherOccupation", DbType.String, _StudentAdmission.FatherOccupation);
                AddParameter(oDbCommand, "@MotherName", DbType.String, _StudentAdmission.MotherName);
                AddParameter(oDbCommand, "@MotherPhoneNo", DbType.String, _StudentAdmission.MotherPhoneNo);
                AddParameter(oDbCommand, "@MotherOccupation", DbType.String, _StudentAdmission.MotherOccupation);
                AddParameter(oDbCommand, "@GuardianName", DbType.String, _StudentAdmission.GuardianName);
                AddParameter(oDbCommand, "@GuardianPhoneNo", DbType.String, _StudentAdmission.GuardianPhoneNo);
                AddParameter(oDbCommand, "@GuardianOccupation", DbType.String, _StudentAdmission.GuardianOccupation);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _StudentAdmission.ChangedBy);
                AddParameter(oDbCommand, "@Year", DbType.String, _StudentAdmission.Year);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(StudentAdmissionBOL _StudentAdmission)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentAdmissionDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentAdmission.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable StudentAdmission_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentAdmissionList", CommandType.StoredProcedure);
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
        public static DataTable StudentAdmission_GetDataByReceiptNo(string Id)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand("SP_TB_AMS_StudentAdmissionListByreceiptNo", CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Id", DbType.String, Id));

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public DataTable StudentAdmission_GetById(StudentAdmissionBOL _StudentAdmission)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand("SP_TB_StudentAdmissionListById", CommandType.StoredProcedure);

                AddParameter(command, "@Id", DbType.String, _StudentAdmission.Id);

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

    }
}
