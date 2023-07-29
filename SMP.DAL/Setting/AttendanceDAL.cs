using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class AttendanceDAL
    {
        public AttendanceDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, AttendanceBOL oAttendance)
        {
            oAttendance.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oAttendance.StudentId = Convert.ToInt32(oDbDataReader["StudentId"]);
            oAttendance.ClassId = Convert.ToInt32(oDbDataReader["ClassId"]);
            oAttendance.AttendanceDateBind = Convert.ToString(oDbDataReader["AttendanceDate"]);
            oAttendance.IsPresent = Convert.ToInt32(oDbDataReader["IsPresent"]);
            oAttendance.IsAbsence = Convert.ToInt32(oDbDataReader["IsAbsence"]);
            oAttendance.IsHalfDay = Convert.ToInt32(oDbDataReader["IsHalfDay"]);
            oAttendance.Note = Convert.ToString(oDbDataReader["Note"]);
           

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(AttendanceBOL _Attendance)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AttendanceInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@StudentId", DbType.Int32, _Attendance.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _Attendance.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.Int32, _Attendance.SectionId);
                AddParameter(oDbCommand, "@AttendanceDate", DbType.DateTime, _Attendance.AttendanceDate);
                AddParameter(oDbCommand, "@IsPresent", DbType.Int32, _Attendance.IsPresent);
                AddParameter(oDbCommand, "@IsAbsence", DbType.Int32, _Attendance.IsAbsence);
                AddParameter(oDbCommand, "@IsHalfDay", DbType.Int32, _Attendance.IsHalfDay);
                AddParameter(oDbCommand, "@Note", DbType.String, _Attendance.Note);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _Attendance.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(AttendanceBOL _Attendance)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AttendanceUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Attendance.Id);
                AddParameter(oDbCommand, "@StudentId", DbType.Int32, _Attendance.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _Attendance.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.Int32, _Attendance.SectionId);
                AddParameter(oDbCommand, "@AttendanceDate", DbType.DateTime, _Attendance.AttendanceDate);
                AddParameter(oDbCommand, "@IsPresent", DbType.Int32, _Attendance.IsPresent);
                AddParameter(oDbCommand, "@IsAbsence", DbType.Int32, _Attendance.IsAbsence);
                AddParameter(oDbCommand, "@IsHalfDay", DbType.Int32, _Attendance.IsHalfDay);
                AddParameter(oDbCommand, "@Note", DbType.String, _Attendance.Note);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _Attendance.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(AttendanceBOL _Attendance)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AttendanceDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _Attendance.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.Int32, _Attendance.SectionId);
                AddParameter(oDbCommand, "@AttendanceDate", DbType.DateTime, _Attendance.AttendanceDate);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Attendance_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AttendanceList", CommandType.StoredProcedure);
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

        public AttendanceBOL Attendance_GetById(AttendanceBOL _Attendance)
        {
            try
            {
                AttendanceBOL oAttendance = new AttendanceBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_AttendanceListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Attendance.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oAttendance);
                }
                oDbDataReader.Close();
                return oAttendance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
