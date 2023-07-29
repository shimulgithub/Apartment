using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
  public  class DisableReasonDAL
    {
        public DisableReasonDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, DisableReasonBOL oDisableReason)
        {
            oDisableReason.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oDisableReason.DisableReason = Convert.ToString(oDbDataReader["DisableReason"]);
            oDisableReason.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(DisableReasonBOL _DisableReason)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DisableReasonInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@DisableReason", DbType.String, _DisableReason.DisableReason);
                AddParameter(oDbCommand, "@Description", DbType.String, _DisableReason.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(DisableReasonBOL _DisableReason)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DisableReasonUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _DisableReason.Id);
                AddParameter(oDbCommand, "@DisableReason", DbType.String, _DisableReason.DisableReason);
                AddParameter(oDbCommand, "@Description", DbType.String, _DisableReason.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(DisableReasonBOL _DisableReason)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DisableReasonDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _DisableReason.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable DisableReason_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DisableReasonList", CommandType.StoredProcedure);
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

        public DisableReasonBOL DisableReason_GetById(DisableReasonBOL _DisableReason)
        {
            try
            {
                DisableReasonBOL oDisableReason = new DisableReasonBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DisableReasonListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _DisableReason.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oDisableReason);
                }
                oDbDataReader.Close();
                return oDisableReason;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
