using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class LeaveTypeDAL
    {
        public LeaveTypeDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, LeaveTypeBOL oSegmentsMaster)
        {
            oSegmentsMaster.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oSegmentsMaster.Code = Convert.ToString(oDbDataReader["Code"]);
            oSegmentsMaster.LeaveType = Convert.ToString(oDbDataReader["LeaveType"]);
            oSegmentsMaster.CreateBy = Convert.ToString(oDbDataReader["CreateBy"]);
            oSegmentsMaster.ChangedBy = Convert.ToString(oDbDataReader["CreateBy"]);
          
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(LeaveTypeBOL _LeaveType)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_LeaveTypeInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Code", DbType.String, _LeaveType.Code);
                AddParameter(oDbCommand, "@LeaveType", DbType.String, _LeaveType.LeaveType);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _LeaveType.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(LeaveTypeBOL _LeaveType)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_LeaveTypeUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _LeaveType.AutoID);
                AddParameter(oDbCommand, "@Code", DbType.String, _LeaveType.Code);
                AddParameter(oDbCommand, "@LeaveType", DbType.String, _LeaveType.LeaveType);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _LeaveType.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(LeaveTypeBOL _LeaveType)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_LeaveTypeDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _LeaveType.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable LeaveType_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_LeaveTypeList", CommandType.StoredProcedure);
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

        public LeaveTypeBOL LeaveType_GetById(LeaveTypeBOL _LeaveType)
        {
            try
            {
                LeaveTypeBOL oLeaveType = new LeaveTypeBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_LeaveTypeListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _LeaveType.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oLeaveType);
                }
                oDbDataReader.Close();
                return oLeaveType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
