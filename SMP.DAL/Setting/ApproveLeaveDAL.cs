using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
    public class ApproveLeaveDAL
    {
        public ApproveLeaveDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, ApproveLeaveBOL oApproveLeave)
        {
            oApproveLeave.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oApproveLeave.StudentId = Convert.ToInt32(oDbDataReader["StudentId"]);
            oApproveLeave.ClassId = Convert.ToInt32(oDbDataReader["ClassId"]);
            oApproveLeave.SectionId = Convert.ToInt32(oDbDataReader["SectionId"]);
            oApproveLeave.ApplyDateBind = Convert.ToString(oDbDataReader["ApplyDate"]);
            oApproveLeave.FromDateBind = Convert.ToString(oDbDataReader["FromDate"]);
            oApproveLeave.ToDateBind = Convert.ToString(oDbDataReader["ToDate"]);
            oApproveLeave.Status = Convert.ToInt32(oDbDataReader["Status"]);
            oApproveLeave.ApprovedBy = Convert.ToInt32(oDbDataReader["ApprovedBy"]);
            oApproveLeave.Reason = Convert.ToString(oDbDataReader["Reason"]);
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(ApproveLeaveBOL _ApproveLeave)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ApproveLeaveInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@StudentId", DbType.Int32, _ApproveLeave.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _ApproveLeave.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.Int32, _ApproveLeave.SectionId);
                AddParameter(oDbCommand, "@ApplyDate", DbType.DateTime, _ApproveLeave.ApplyDate);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, _ApproveLeave.FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, _ApproveLeave.ToDate);
                AddParameter(oDbCommand, "@Status", DbType.Int32, _ApproveLeave.Status);
                AddParameter(oDbCommand, "@ApprovedBy", DbType.Int32, _ApproveLeave.ApprovedBy);
                AddParameter(oDbCommand, "@CreateBy", DbType.Int32, _ApproveLeave.CreateBy);
                AddParameter(oDbCommand, "@Reason", DbType.String, _ApproveLeave.Reason);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ApproveLeaveBOL _ApproveLeave)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ApproveLeaveUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ApproveLeave.Id);
                AddParameter(oDbCommand, "@StudentId", DbType.Int32, _ApproveLeave.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _ApproveLeave.ClassId);
                AddParameter(oDbCommand, "@SectionId", DbType.Int32, _ApproveLeave.SectionId);
                AddParameter(oDbCommand, "@ApplyDate", DbType.DateTime, _ApproveLeave.ApplyDate);
                AddParameter(oDbCommand, "@FromDate", DbType.DateTime, _ApproveLeave.FromDate);
                AddParameter(oDbCommand, "@ToDate", DbType.DateTime, _ApproveLeave.ToDate);
                AddParameter(oDbCommand, "@Status", DbType.Int32, _ApproveLeave.Status);
                AddParameter(oDbCommand, "@ApprovedBy", DbType.Int32, _ApproveLeave.ApprovedBy);
                AddParameter(oDbCommand, "@ChangedBy", DbType.Int32, _ApproveLeave.ChangedBy);
                AddParameter(oDbCommand, "@Reason", DbType.String, _ApproveLeave.Reason);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(ApproveLeaveBOL _ApproveLeave)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ApproveLeaveDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ApproveLeave.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ApproveLeave_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ApproveLeaveList", CommandType.StoredProcedure);
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

        public ApproveLeaveBOL ApproveLeave_GetById(ApproveLeaveBOL _ApproveLeave)
        {
            try
            {
                ApproveLeaveBOL oApproveLeave = new ApproveLeaveBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ApproveLeaveListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ApproveLeave.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oApproveLeave);
                }
                oDbDataReader.Close();
                return oApproveLeave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
