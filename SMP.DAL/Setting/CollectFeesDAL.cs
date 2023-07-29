using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class CollectFeesDAL
    {
        public CollectFeesDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, CollectFeesBOL oCollectFees)
        {
            oCollectFees.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oCollectFees.InvoiceNo = Convert.ToString(oDbDataReader["InvoiceNo"]);
            oCollectFees.DateBind = Convert.ToString(oDbDataReader["DateBind"]);
            oCollectFees.Amount = Convert.ToDouble(oDbDataReader["Amount"]);
            oCollectFees.DisCountId = Convert.ToInt32(oDbDataReader["DisCountId"]);
            oCollectFees.PayModeId = Convert.ToInt32(oDbDataReader["PayModeId"]);
            oCollectFees.DisCount = Convert.ToDouble(oDbDataReader["DisCount"]);
            oCollectFees.Fine = Convert.ToDouble(oDbDataReader["Fine"]);
            oCollectFees.Total = Convert.ToDouble(oDbDataReader["Total"]);
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(CollectFeesBOL _CollectFees)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesCollectionMasterInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@InvoiceNo", DbType.String, _CollectFees.InvoiceNo);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _CollectFees.Date);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _CollectFees.Amount);
                AddParameter(oDbCommand, "@DisCountId", DbType.Int32, _CollectFees.DisCountId);
                AddParameter(oDbCommand, "@PayModeId", DbType.Int32, _CollectFees.PayModeId);
                AddParameter(oDbCommand, "@DisCount", DbType.Double, _CollectFees.DisCount);
                AddParameter(oDbCommand, "@Fine", DbType.Double, _CollectFees.Fine);
                AddParameter(oDbCommand, "@Total", DbType.Double, _CollectFees.Total);
                AddParameter(oDbCommand, "@StudentId", DbType.Int32, _CollectFees.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _CollectFees.ClassId);
                AddParameter(oDbCommand, "@FeesTypeId", DbType.Int32, _CollectFees.FeesTypeId);
                AddParameter(oDbCommand, "@Note", DbType.String, _CollectFees.Note);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _CollectFees.CreateBy);
                
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int FeesCarryForward_Add(CollectFeesBOL _CollectFees)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesCarryForwardInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Id", DbType.String, _CollectFees.Id);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _CollectFees.Amount);
                AddParameter(oDbCommand, "@StudentId", DbType.Double, _CollectFees.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Double, _CollectFees.ClassId);
                AddParameter(oDbCommand, "@CreateBy", DbType.Double, _CollectFees.CreateBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Update(CollectFeesBOL _CollectFees)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesCollectionMasterUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.Int32, _CollectFees.Id);
                AddParameter(oDbCommand, "@InvoiceNo", DbType.String, _CollectFees.InvoiceNo);
                AddParameter(oDbCommand, "@Date", DbType.DateTime, _CollectFees.Date);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _CollectFees.Amount);
                AddParameter(oDbCommand, "@DisCountId", DbType.Int32, _CollectFees.DisCountId);
                AddParameter(oDbCommand, "@PayModeId", DbType.Int32, _CollectFees.PayModeId);
                AddParameter(oDbCommand, "@DisCount", DbType.Double, _CollectFees.DisCount);
                AddParameter(oDbCommand, "@Fine", DbType.Double, _CollectFees.Fine);
                AddParameter(oDbCommand, "@Total", DbType.Double, _CollectFees.Total);
                AddParameter(oDbCommand, "@StudentId", DbType.Int32, _CollectFees.StudentId);
                AddParameter(oDbCommand, "@ClassId", DbType.Int32, _CollectFees.ClassId);
                AddParameter(oDbCommand, "@FeesTypeId", DbType.Int32, _CollectFees.FeesTypeId);
                AddParameter(oDbCommand, "@Note", DbType.String, _CollectFees.Note);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _CollectFees.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(CollectFeesBOL _CollectFees)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_CollectFeesDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _CollectFees.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable CollectFees_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_CollectFeesList", CommandType.StoredProcedure);
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

        public CollectFeesBOL CollectFees_GetById(CollectFeesBOL _CollectFees)
        {
            try
            {
                CollectFeesBOL oCollectFees = new CollectFeesBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_CollectFeesListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _CollectFees.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oCollectFees);
                }
                oDbDataReader.Close();
                return oCollectFees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
