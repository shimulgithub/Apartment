using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
   public class DesignationDAL
    {
        public DesignationDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, DesignationBOL oSegmentsMaster)
        {
            oSegmentsMaster.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oSegmentsMaster.Code = Convert.ToString(oDbDataReader["Code"]);
            oSegmentsMaster.Designation = Convert.ToString(oDbDataReader["Designation"]);
            oSegmentsMaster.CreateBy = Convert.ToString(oDbDataReader["CreateBy"]);
            oSegmentsMaster.ChangedBy = Convert.ToString(oDbDataReader["CreateBy"]);

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(DesignationBOL _Designation)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DesignationInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Code", DbType.String, _Designation.Code);
                AddParameter(oDbCommand, "@Designation", DbType.String, _Designation.Designation);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _Designation.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(DesignationBOL _Designation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DesignationUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _Designation.AutoID);
                AddParameter(oDbCommand, "@Code", DbType.String, _Designation.Code);
                AddParameter(oDbCommand, "@Designation", DbType.String, _Designation.Designation);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _Designation.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(DesignationBOL _Designation)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DesignationDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _Designation.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Designation_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DesignationList", CommandType.StoredProcedure);
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

        public DesignationBOL Designation_GetById(DesignationBOL _Designation)
        {
            try
            {
                DesignationBOL oDesignation = new DesignationBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DesignationListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _Designation.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oDesignation);
                }
                oDbDataReader.Close();
                return oDesignation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
