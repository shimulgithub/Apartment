using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public  class IncomeDAL
    {
        public IncomeDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, IncomeBOL oIncome)
        {
            oIncome.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oIncome.IncomeHeadId = Convert.ToInt32(oDbDataReader["IncomeHeadId"]);
            oIncome.IncomeName = Convert.ToString(oDbDataReader["IncomeName"]);
            oIncome.InvoiceNo = Convert.ToString(oDbDataReader["InvoiceNo"]);
            oIncome.DateBind = Convert.ToString(oDbDataReader["IncomeDate"]);
            oIncome.Amount = Convert.ToDouble(oDbDataReader["IncomeAmount"]);
            oIncome.Description = Convert.ToString(oDbDataReader["Description"]);
            oIncome.RefNo = Convert.ToString(oDbDataReader["RefNo"]);
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(IncomeBOL _Income)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@IncomeHeadId", DbType.Int32, _Income.IncomeHeadId);
                AddParameter(oDbCommand, "@IncomeName", DbType.String, _Income.IncomeName);
                AddParameter(oDbCommand, "@RefNo", DbType.String, _Income.RefNo);
                AddParameter(oDbCommand, "@Date", DbType.Date, _Income.Date);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _Income.Amount);
                AddParameter(oDbCommand, "@Description", DbType.String, _Income.Description);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _Income.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(IncomeBOL _Income)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Income.Id);
                AddParameter(oDbCommand, "@InvoiceNo", DbType.Int32, _Income.InvoiceNo);
                AddParameter(oDbCommand, "@IncomeHeadId", DbType.Int32, _Income.IncomeHeadId);
                AddParameter(oDbCommand, "@IncomeName", DbType.String, _Income.IncomeName);
                AddParameter(oDbCommand, "@RefNo", DbType.String, _Income.RefNo);
                AddParameter(oDbCommand, "@Date", DbType.Date, _Income.Date);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _Income.Amount);
                AddParameter(oDbCommand, "@Description", DbType.String, _Income.Description);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _Income.ChangedBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(IncomeBOL _Income)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Income.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Income_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeList", CommandType.StoredProcedure);
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

        public IncomeBOL Income_GetById(IncomeBOL _Income)
        {
            try
            {
                IncomeBOL oIncome = new IncomeBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Income.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oIncome);
                }
                oDbDataReader.Close();
                return oIncome;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
