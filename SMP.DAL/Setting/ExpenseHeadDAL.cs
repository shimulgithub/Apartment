using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
     public class ExpenseHeadDAL
    {
        public ExpenseHeadDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, ExpenseHeadBOL oExpenseHead)
        {
            oExpenseHead.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oExpenseHead.HeadName = Convert.ToString(oDbDataReader["HeadName"]);
            oExpenseHead.Description = Convert.ToString(oDbDataReader["Description"]);

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(ExpenseHeadBOL _ExpenseHead)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseHeadInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@HeadName", DbType.String, _ExpenseHead.HeadName);
                AddParameter(oDbCommand, "@Description", DbType.String, _ExpenseHead.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ExpenseHeadBOL _ExpenseHead)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseHeadUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ExpenseHead.Id);
                AddParameter(oDbCommand, "@HeadName", DbType.String, _ExpenseHead.HeadName);
                AddParameter(oDbCommand, "@Description", DbType.String, _ExpenseHead.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(ExpenseHeadBOL _ExpenseHead)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseHeadDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ExpenseHead.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExpenseHead_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseHeadList", CommandType.StoredProcedure);
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

        public ExpenseHeadBOL ExpenseHead_GetById(ExpenseHeadBOL _ExpenseHead)
        {
            try
            {
                ExpenseHeadBOL oExpenseHead = new ExpenseHeadBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExpenseHeadById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ExpenseHead.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oExpenseHead);
                }
                oDbDataReader.Close();
                return oExpenseHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
