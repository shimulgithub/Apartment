using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class IncomeHeadDAL
    {
        public IncomeHeadDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, IncomeHeadBOL oIncomeHead)
        {
            oIncomeHead.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oIncomeHead.HeadName = Convert.ToString(oDbDataReader["HeadName"]);
            oIncomeHead.Description = Convert.ToString(oDbDataReader["Description"]);

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(IncomeHeadBOL _IncomeHead)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeHeadInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@HeadName", DbType.String, _IncomeHead.HeadName);
                AddParameter(oDbCommand, "@Description", DbType.String, _IncomeHead.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(IncomeHeadBOL _IncomeHead)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeHeadUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _IncomeHead.Id);
                AddParameter(oDbCommand, "@HeadName", DbType.String, _IncomeHead.HeadName);
                AddParameter(oDbCommand, "@Description", DbType.String, _IncomeHead.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(IncomeHeadBOL _IncomeHead)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeHeadDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _IncomeHead.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable IncomeHead_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeHeadList", CommandType.StoredProcedure);
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

        public IncomeHeadBOL IncomeHead_GetById(IncomeHeadBOL _IncomeHead)
        {
            try
            {
                IncomeHeadBOL oIncomeHead = new IncomeHeadBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_IncomeHeadById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _IncomeHead.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oIncomeHead);
                }
                oDbDataReader.Close();
                return oIncomeHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
