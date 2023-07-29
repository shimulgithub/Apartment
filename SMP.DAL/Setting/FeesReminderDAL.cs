using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
    public  class FeesReminderDAL
    {

        public FeesReminderDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, FeesReminderBOL oFeesReminder)
        {
            oFeesReminder.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oFeesReminder.IsActive = Convert.ToInt32(oDbDataReader["IsActive"]);
            oFeesReminder.ReminderType = Convert.ToString(oDbDataReader["ReminderType"]);
            oFeesReminder.Days = Convert.ToInt32(oDbDataReader["Days"]);
            oFeesReminder.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(FeesReminderBOL _FeesReminder)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesReminderInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@IsActive", DbType.Int32, _FeesReminder.IsActive);
                AddParameter(oDbCommand, "@ReminderType", DbType.String, _FeesReminder.ReminderType);
                AddParameter(oDbCommand, "@Description", DbType.String, _FeesReminder.Description);
                AddParameter(oDbCommand, "@Days", DbType.Int32, _FeesReminder.Days);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(FeesReminderBOL _FeesReminder)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesReminderUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesReminder.Id);
                AddParameter(oDbCommand, "@IsActive", DbType.Int32, _FeesReminder.IsActive);
                AddParameter(oDbCommand, "@ReminderType", DbType.String, _FeesReminder.ReminderType);
                AddParameter(oDbCommand, "@Days", DbType.Int32, _FeesReminder.Days);
                AddParameter(oDbCommand, "@Description", DbType.String, _FeesReminder.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(FeesReminderBOL _FeesReminder)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesReminderDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesReminder.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FeesReminder_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesReminderList", CommandType.StoredProcedure);
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

        public FeesReminderBOL FeesReminder_GetById(FeesReminderBOL _FeesReminder)
        {
            try
            {
                FeesReminderBOL oFeesReminder = new FeesReminderBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesReminderListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesReminder.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oFeesReminder);
                }
                oDbDataReader.Close();
                return oFeesReminder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
