using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
    public  class ExpenseDAL
    {
        public ExpenseDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, ExpenseBOL oExpense)
        {
            oExpense.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oExpense.ExpenseHeadId = Convert.ToInt32(oDbDataReader["ExpenseHeadId"]);
            oExpense.ExpenseName = Convert.ToString(oDbDataReader["ExpenseName"]);
            oExpense.InvoiceNo = Convert.ToString(oDbDataReader["InvoiceNo"]);
            oExpense.DateBind = Convert.ToString(oDbDataReader["ExpenseDate"]);
            oExpense.Amount = Convert.ToDouble(oDbDataReader["ExpenseAmount"]);
            oExpense.Description = Convert.ToString(oDbDataReader["Description"]);
            oExpense.RefNo = Convert.ToString(oDbDataReader["RefNo"]);
        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(ExpenseBOL _Expense)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@ExpenseHeadId", DbType.Int32, _Expense.ExpenseHeadId);
                AddParameter(oDbCommand, "@ExpenseName", DbType.String, _Expense.ExpenseName);
                AddParameter(oDbCommand, "@RefNo", DbType.String, _Expense.RefNo);
                AddParameter(oDbCommand, "@Date", DbType.Date, _Expense.Date);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _Expense.Amount);
                AddParameter(oDbCommand, "@Description", DbType.String, _Expense.Description);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _Expense.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ExpenseBOL _Expense)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Expense.Id);
                AddParameter(oDbCommand, "@InvoiceNo", DbType.Int32, _Expense.InvoiceNo);
                AddParameter(oDbCommand, "@ExpenseHeadId", DbType.Int32, _Expense.ExpenseHeadId);
                AddParameter(oDbCommand, "@ExpenseName", DbType.String, _Expense.ExpenseName);
                AddParameter(oDbCommand, "@RefNo", DbType.String, _Expense.RefNo);
                AddParameter(oDbCommand, "@Date", DbType.Date, _Expense.Date);
                AddParameter(oDbCommand, "@Amount", DbType.Double, _Expense.Amount);
                AddParameter(oDbCommand, "@Description", DbType.String, _Expense.Description);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _Expense.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(ExpenseBOL _Expense)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Expense.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Expense_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseList", CommandType.StoredProcedure);
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

        public ExpenseBOL Expense_GetById(ExpenseBOL _Expense)
        {
            try
            {
                ExpenseBOL oExpense = new ExpenseBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _Expense.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oExpense);
                }
                oDbDataReader.Close();
                return oExpense;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
