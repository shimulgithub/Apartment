using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
   public class MarkGradeEntryDAL
    {
        public MarkGradeEntryDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, MarkGradeEntryBOL oMarkGradeEntry)
        {
            oMarkGradeEntry.Id = Convert.ToInt32(oDbDataReader["Id"]);
            oMarkGradeEntry.ExamGroupId = Convert.ToInt32(oDbDataReader["ExamGroupId"]);
            oMarkGradeEntry.GradeName = Convert.ToString(oDbDataReader["GradeName"]);
            oMarkGradeEntry.PercentFrom = Convert.ToInt32(oDbDataReader["PercentFrom"]);
            oMarkGradeEntry.PercentTo = Convert.ToInt32(oDbDataReader["PercentTo"]);
            oMarkGradeEntry.GradePoint = Convert.ToDouble(oDbDataReader["PercentTo"]);
            oMarkGradeEntry.Description = Convert.ToString(oDbDataReader["Description"]);



        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public int Add(MarkGradeEntryBOL _MarkGradeEntry)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MarkGradeEntryInsertRow", CommandType.StoredProcedure);

                AddParameter(oDbCommand, "@ExamGroupId", DbType.Int32, _MarkGradeEntry.ExamGroupId);
                AddParameter(oDbCommand, "@GradeName", DbType.String, _MarkGradeEntry.GradeName);
                AddParameter(oDbCommand, "@PercentFrom", DbType.Int32, _MarkGradeEntry.PercentFrom);
                AddParameter(oDbCommand, "@PercentTo", DbType.Int32, _MarkGradeEntry.PercentTo);
                AddParameter(oDbCommand, "@GradePoint", DbType.Int32, _MarkGradeEntry.GradePoint);
                AddParameter(oDbCommand, "@Description", DbType.String, _MarkGradeEntry.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(MarkGradeEntryBOL _MarkGradeEntry)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MarkGradeEntryUpdateRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _MarkGradeEntry.Id);
                AddParameter(oDbCommand, "@ExamGroupId", DbType.Int32, _MarkGradeEntry.ExamGroupId);
                AddParameter(oDbCommand, "@GradeName", DbType.String, _MarkGradeEntry.GradeName);
                AddParameter(oDbCommand, "@PercentFrom", DbType.Int32, _MarkGradeEntry.PercentFrom);
                AddParameter(oDbCommand, "@PercentTo", DbType.Int32, _MarkGradeEntry.PercentTo);
                AddParameter(oDbCommand, "@GradePoint", DbType.Int32, _MarkGradeEntry.GradePoint);
                AddParameter(oDbCommand, "@Description", DbType.String, _MarkGradeEntry.Description);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(MarkGradeEntryBOL _MarkGradeEntry)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MarkGradeEntryDeleteRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _MarkGradeEntry.Id);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable MarkGradeEntry_GetDataForGV()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MarkGradeEntryList", CommandType.StoredProcedure);
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

        public MarkGradeEntryBOL MarkGradeEntry_GetById(MarkGradeEntryBOL _MarkGradeEntry)
        {
            try
            {
                MarkGradeEntryBOL oMarkGradeEntry = new MarkGradeEntryBOL();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_MarkGradeEntryListById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@Id", DbType.String, _MarkGradeEntry.Id);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    BuildEntity(oDbDataReader, oMarkGradeEntry);
                }
                oDbDataReader.Close();
                return oMarkGradeEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
