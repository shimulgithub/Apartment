using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public  class FeesDiscountDAL
    {
        public FeesDiscountDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, FeesDiscountBOL oFeesDiscount)
        {
            oFeesDiscount.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oFeesDiscount.DisCode = Convert.ToString(oDbDataReader["DisCode"]);
            oFeesDiscount.DisName = Convert.ToString(oDbDataReader["DisName"]);
            oFeesDiscount.DisAmount = Convert.ToInt32(oDbDataReader["DisAmount"]);
            oFeesDiscount.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(FeesDiscountBOL _FeesDiscount)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesDiscountInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@DisCode", DbType.String, _FeesDiscount.DisCode);
                AddParameter(oDbCommand, "@DisName", DbType.String, _FeesDiscount.DisName);
                AddParameter(oDbCommand, "@DisAmount", DbType.String, _FeesDiscount.DisAmount);
                AddParameter(oDbCommand, "@Description", DbType.String, _FeesDiscount.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(FeesDiscountBOL _FeesDiscount)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesDiscountUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesDiscount.Id);
                AddParameter(oDbCommand, "@DisName", DbType.String, _FeesDiscount.DisName);
                AddParameter(oDbCommand, "@DisAmount", DbType.String, _FeesDiscount.DisAmount);
                AddParameter(oDbCommand, "@DisCode", DbType.String, _FeesDiscount.DisCode);
                AddParameter(oDbCommand, "@Description", DbType.String, _FeesDiscount.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(FeesDiscountBOL _FeesDiscount)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesDiscountDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesDiscount.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FeesDiscount_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesDiscountList", CommandType.StoredProcedure);
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

        public FeesDiscountBOL FeesDiscount_GetById(FeesDiscountBOL _FeesDiscount)
        {
            try
            {
                FeesDiscountBOL oFeesDiscount = new FeesDiscountBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesDiscountListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesDiscount.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oFeesDiscount);
                }
                oDbDataReader.Close();
                return oFeesDiscount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
