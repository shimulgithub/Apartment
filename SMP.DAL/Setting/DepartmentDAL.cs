using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
   public class DepartmentDAL
    {
        public DepartmentDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, DepartmentBOL oSegmentsMaster)
        {
            oSegmentsMaster.AutoID = Convert.ToInt32(oDbDataReader["AutoID"]);
            oSegmentsMaster.Code = Convert.ToString(oDbDataReader["Code"]);
            oSegmentsMaster.Department = Convert.ToString(oDbDataReader["Department"]);
            oSegmentsMaster.CreateBy = Convert.ToString(oDbDataReader["CreateBy"]);
            oSegmentsMaster.ChangedBy = Convert.ToString(oDbDataReader["CreateBy"]);

        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(DepartmentBOL _Department)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DepartmentInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Code", DbType.String, _Department.Code);
                AddParameter(oDbCommand, "@Department", DbType.String, _Department.Department);
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _Department.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(DepartmentBOL _Department)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DepartmentUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _Department.AutoID);
                AddParameter(oDbCommand, "@Code", DbType.String, _Department.Code);
                AddParameter(oDbCommand, "@Department", DbType.String, _Department.Department);
                AddParameter(oDbCommand, "@ChangedBy", DbType.String, _Department.ChangedBy);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(DepartmentBOL _Department)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DepartmentDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _Department.AutoID);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Department_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DepartmentList", CommandType.StoredProcedure);
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

        public DepartmentBOL Department_GetById(DepartmentBOL _Department)
        {
            try
            {
                DepartmentBOL oDepartment = new DepartmentBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_DepartmentListByID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@AutoID", DbType.String, _Department.AutoID);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oDepartment);
                }
                oDbDataReader.Close();
                return oDepartment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
