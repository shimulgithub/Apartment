using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class ExamGroupDAL
    {
        public ExamGroupDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, ExamGroupBOL oExamGroup)
        {
            oExamGroup.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oExamGroup.GroupName = Convert.ToString(oDbDataReader["GroupName"]);
            oExamGroup.ExamType = Convert.ToString(oDbDataReader["ExamType"]);
            oExamGroup.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(ExamGroupBOL _ExamGroup)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExamGroupInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@GroupName", DbType.String, _ExamGroup.GroupName);
                AddParameter(oDbCommand, "@ExamType", DbType.String, _ExamGroup.ExamType);
                AddParameter(oDbCommand, "@Description", DbType.String, _ExamGroup.Description);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ExamGroupBOL _ExamGroup)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExamGroupUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ExamGroup.Id);
                AddParameter(oDbCommand, "@GroupName", DbType.String, _ExamGroup.GroupName);
                AddParameter(oDbCommand, "@ExamType", DbType.String, _ExamGroup.ExamType);
                AddParameter(oDbCommand, "@Description", DbType.String, _ExamGroup.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(ExamGroupBOL _ExamGroup)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExamGroupDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ExamGroup.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExamGroup_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExamGroupList", CommandType.StoredProcedure);
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

        public ExamGroupBOL ExamGroup_GetById(ExamGroupBOL _ExamGroup)
        {
            try
            {
                ExamGroupBOL oExamGroup = new ExamGroupBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_ExamGroupListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _ExamGroup.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oExamGroup);
                }
                oDbDataReader.Close();
                return oExamGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
