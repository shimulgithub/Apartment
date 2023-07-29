using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
     public class FeesMasterDAL
    {
        public FeesMasterDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, FeesMasterBOL oFeesMaster)
        {
            oFeesMaster.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oFeesMaster.ClassId = Convert.ToInt32(oDbDataReader["ClassId"]);
            oFeesMaster.FeesTypeId = Convert.ToInt32(oDbDataReader["FeesTypeId"]);
            oFeesMaster.DueDateBind = Convert.ToString(oDbDataReader["DueDate"]);
            oFeesMaster.Amount = Convert.ToInt32(oDbDataReader["Amount"]);
            oFeesMaster.FinePercentage = Convert.ToInt32(oDbDataReader["FinePercentage"]);
            oFeesMaster.FineAmount = Convert.ToInt32(oDbDataReader["FineAmount"]);
            oFeesMaster.TotalAmount = Convert.ToInt32(oDbDataReader["TotalAmount"]);
            

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(FeesMasterBOL _FeesMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesMasterInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@ClassId", DbType.String, _FeesMaster.ClassId);
                AddParameter(oDbCommand, "@FeesTypeId", DbType.Int32 , _FeesMaster.FeesTypeId);
                AddParameter(oDbCommand, "@DueDate", DbType.DateTime, _FeesMaster.DueDate);
                AddParameter(oDbCommand, "@Amount", DbType.Int32, _FeesMaster.Amount);
                AddParameter(oDbCommand, "@FinePercentage", DbType.Int32, _FeesMaster.FinePercentage);
                AddParameter(oDbCommand, "@FineAmount", DbType.Int32, _FeesMaster.FineAmount);
                AddParameter(oDbCommand, "@TotalAmount", DbType.Int32, _FeesMaster.TotalAmount);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(FeesMasterBOL _FeesMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesMasterUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesMaster.Id);
                AddParameter(oDbCommand, "@ClassId", DbType.String, _FeesMaster.ClassId);
                AddParameter(oDbCommand, "@FeesTypeId", DbType.Int32, _FeesMaster.FeesTypeId);
                AddParameter(oDbCommand, "@DueDate", DbType.DateTime, _FeesMaster.DueDate);
                AddParameter(oDbCommand, "@Amount", DbType.Int32, _FeesMaster.Amount);
                AddParameter(oDbCommand, "@FinePercentage", DbType.Int32, _FeesMaster.FinePercentage);
                AddParameter(oDbCommand, "@FineAmount", DbType.Int32, _FeesMaster.FineAmount);
                AddParameter(oDbCommand, "@TotalAmount", DbType.Int32, _FeesMaster.TotalAmount);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(FeesMasterBOL _FeesMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesMasterDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesMaster.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FeesMaster_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesMasterList", CommandType.StoredProcedure);
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

        public FeesMasterBOL FeesMaster_GetById(FeesMasterBOL _FeesMaster)
        {
            try
            {
                FeesMasterBOL oFeesMaster = new FeesMasterBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesMasterListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesMaster.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oFeesMaster);
                }
                oDbDataReader.Close();
                return oFeesMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
