using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public  class StudentHouseDAL
    {
        public StudentHouseDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, StudentHouseBOL oStudentHouse)
        {
            oStudentHouse.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oStudentHouse.Name = Convert.ToString(oDbDataReader["Name"]);
            oStudentHouse.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(StudentHouseBOL _StudentHouse)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentHouseInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Name", DbType.String, _StudentHouse.Name);
                AddParameter(oDbCommand, "@Description", DbType.String, _StudentHouse.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(StudentHouseBOL _StudentHouse)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentHouseUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentHouse.Id);
                AddParameter(oDbCommand, "@Name", DbType.String, _StudentHouse.Name);
                AddParameter(oDbCommand, "@Description", DbType.String, _StudentHouse.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(StudentHouseBOL _StudentHouse)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentHouseDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentHouse.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable StudentHouse_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentHouseList", CommandType.StoredProcedure);
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

        public StudentHouseBOL StudentHouse_GetById(StudentHouseBOL _StudentHouse)
        {
            try
            {
                StudentHouseBOL oStudentHouse = new StudentHouseBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentHouseListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentHouse.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oStudentHouse);
                }
                oDbDataReader.Close();
                return oStudentHouse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
