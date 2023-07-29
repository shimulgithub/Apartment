using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;


namespace SMP.DAL.Setting
{
    public class StudentCategoryDAL
    {
        public StudentCategoryDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, StudentCategoryBOL oStudentCategory)
        {
            oStudentCategory.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oStudentCategory.Category = Convert.ToString(oDbDataReader["Category"]);
            oStudentCategory.Description = Convert.ToString(oDbDataReader["Description"]);
   				


        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(StudentCategoryBOL _StudentCategory)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentCategoryInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@Category", DbType.String, _StudentCategory.Category);
                AddParameter(oDbCommand, "@Description", DbType.String, _StudentCategory.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(StudentCategoryBOL _StudentCategory)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentCategoryUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentCategory.Id);
                AddParameter(oDbCommand, "@Category", DbType.String, _StudentCategory.Category);
                AddParameter(oDbCommand, "@Description", DbType.String, _StudentCategory.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(StudentCategoryBOL _StudentCategory)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentCategoryDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentCategory.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable StudentCategory_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentCategoryList", CommandType.StoredProcedure);
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

        public StudentCategoryBOL StudentCategory_GetById(StudentCategoryBOL _StudentCategory)
        {
            try
            {
                StudentCategoryBOL oStudentCategory = new StudentCategoryBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_StudentCategoryListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _StudentCategory.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oStudentCategory);
                }
                oDbDataReader.Close();
                return oStudentCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
