using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class FeesTypeDAL
    {
        public FeesTypeDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, FeesTypeBOL oFeesType)
        {
            oFeesType.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oFeesType.Name = Convert.ToString(oDbDataReader["Name"]);
            oFeesType.Code = Convert.ToString(oDbDataReader["Code"]);
            oFeesType.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(FeesTypeBOL _FeesType)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesTypeInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Name", DbType.String, _FeesType.Name);
                AddParameter(oDbCommand, "@Code", DbType.String, _FeesType.Code);
                AddParameter(oDbCommand, "@Description", DbType.String, _FeesType.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(FeesTypeBOL _FeesType)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesTypeUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesType.Id);
                AddParameter(oDbCommand, "@Name", DbType.String, _FeesType.Name);
                AddParameter(oDbCommand, "@Code", DbType.String, _FeesType.Code);
                AddParameter(oDbCommand, "@Description", DbType.String, _FeesType.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(FeesTypeBOL _FeesType)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesTypeDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesType.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FeesType_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesTypeList", CommandType.StoredProcedure);
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

        public FeesTypeBOL FeesType_GetById(FeesTypeBOL _FeesType)
        {
            try
            {
                FeesTypeBOL oFeesType = new FeesTypeBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_FeesTypeListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _FeesType.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oFeesType);
                }
                oDbDataReader.Close();
                return oFeesType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
