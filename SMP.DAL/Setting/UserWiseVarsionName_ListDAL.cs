using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;

namespace SMP.DAL.Setting
{
    public class UserWiseVarsionName_ListDAL
    {

        public UserWiseVarsionName_ListDAL()
        {
            DbProviderHelper.GetConnection();
        }
        private static void BuildEntity(DbDataReader oDbDataReader, UserWiseVarsionName_ListBOL oUserWiseVarsionName_ListBOL)
        {
            //oUserWiseVarsionName_ListBOL.SegmentsCombinationAutoID = Convert.ToInt32(oDbDataReader["SegmentsAllocationAutoID"]);
            //oUserWiseVarsionName_ListBOL.SegmentsCombinationCode = Convert.ToString(oDbDataReader["SegmentsCombinationCode"]);
            //oUserWiseVarsionName_ListBOL.StructureCode = Convert.ToString(oDbDataReader["StructureCode"]);
            //oUserWiseVarsionName_ListBOL.Segment1 = Convert.ToString(oDbDataReader["Segment1"]);
            //oUserWiseVarsionName_ListBOL.Segment2 = Convert.ToString(oDbDataReader["Segment2"]);
            //oUserWiseVarsionName_ListBOL.Segment3 = Convert.ToString(oDbDataReader["Segment3"]);
            //oUserWiseVarsionName_ListBOL.Segment4 = Convert.ToString(oDbDataReader["Segment4"]);
            //oUserWiseVarsionName_ListBOL.Segment5 = Convert.ToString(oDbDataReader["Segment5"]);
            //oUserWiseVarsionName_ListBOL.Segment6 = Convert.ToString(oDbDataReader["Segment6"]);
            //oUserWiseVarsionName_ListBOL.Segment7 = Convert.ToString(oDbDataReader["Segment7"]);
            //oUserWiseVarsionName_ListBOL.Segment8 = Convert.ToString(oDbDataReader["Segment8"]);
            //oUserWiseVarsionName_ListBOL.Segment9 = Convert.ToString(oDbDataReader["Segment9"]);
            //oUserWiseVarsionName_ListBOL.Segment10 = Convert.ToString(oDbDataReader["Segment10"]);
            //oUserWiseVarsionName_ListBOL.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
            //oUserWiseVarsionName_ListBOL.CreateBy = Convert.ToString(oDbDataReader["CreateBy"]);
            //oUserWiseVarsionName_ListBOL.CreatedDateTime = Convert.ToDateTime(oDbDataReader["CreatedDateTime"]);
            //oUserWiseVarsionName_ListBOL.ChangedBy = Convert.ToString(oDbDataReader["CreateBy"]);
            //oUserWiseVarsionName_ListBOL.ChangedDateTime = Convert.ToDateTime(oDbDataReader["CreatedDateTime"]);					


        }
        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }
        public DataTable UserWiseVarsionName_ListGVEdit(UserWiseVarsionName_ListBOL _UserWiseVarsionName_List)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;

            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_Reports_Column_VersionName_SelectAll", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@PageId", DbType.String, _UserWiseVarsionName_List.PageId);
                AddParameter(oDbCommand, "@UserID", DbType.String, _UserWiseVarsionName_List.UserID);
                AddParameter(oDbCommand, "@VersoinAutoID", DbType.String, Convert.ToString(_UserWiseVarsionName_List.VersoinAutoID));
                AddParameter(oDbCommand, "@TableName", DbType.String, _UserWiseVarsionName_List.TableName);
                //AddParameter(oDbCommand, "@SegmentsCombinationCode", DbType.String, _oUserWiseVarsionName_ListBOL.SegmentsCombinationCode);
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
        public DataTable UserWiseVarsionName_ListGVList()
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            string UserID = "0";
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_Reports_Column_VersionName_GetAll", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, UserID);
                //AddParameter(oDbCommand, "@SegmentsCombinationCode", DbType.String, _oUserWiseVarsionName_ListBOL.SegmentsCombinationCode);
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
        public DataTable UserWiseVarsionName_ListGVList(string UserID)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_Reports_Column_VersionName_GetAll", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, UserID);
                //AddParameter(oDbCommand, "@SegmentsCombinationCode", DbType.String, _oUserWiseVarsionName_ListBOL.SegmentsCombinationCode);
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

        public DataTable VersionName_ExistByUserID(string UserID, string VersionName)
        {
            DataTable dtUser = null;
            DbDataReader oDbDataReader = null;
            try
            {
                dtUser = new DataTable();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_Reports_Column_VersionName_ExistByUserID", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@UserID", DbType.String, UserID);
                AddParameter(oDbCommand, "@VersoinName", DbType.String, VersionName);

                //AddParameter(oDbCommand, "@SegmentsCombinationCode", DbType.String, _oUserWiseVarsionName_ListBOL.SegmentsCombinationCode);
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


        public int Add(UserWiseVarsionName_ListBOL _UserWiseVarsionName_List)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_Reports_Column_VersionNameInsertRow", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@VersoinName", DbType.String, _UserWiseVarsionName_List.VersoinName);
                AddParameter(oDbCommand, "@PageId", DbType.String, _UserWiseVarsionName_List.PageId);
                AddParameter(oDbCommand, "@UserID", DbType.String, _UserWiseVarsionName_List.UserID);

                //AddParameter(oDbCommand, "@Segment2", DbType.String, _UserWiseVarsionName_List.Segment2);
                //AddParameter(oDbCommand, "@Segment3", DbType.String, _UserWiseVarsionName_List.Segment3);
                //AddParameter(oDbCommand, "@Segment4", DbType.String, _UserWiseVarsionName_List.Segment4);
                //AddParameter(oDbCommand, "@Segment5", DbType.String, _UserWiseVarsionName_List.Segment5);
                //AddParameter(oDbCommand, "@Segment6", DbType.String, _UserWiseVarsionName_List.Segment6);
                //AddParameter(oDbCommand, "@Segment7", DbType.String, _UserWiseVarsionName_List.Segment7);
                //AddParameter(oDbCommand, "@Segment8", DbType.String, _UserWiseVarsionName_List.Segment8);
                //AddParameter(oDbCommand, "@Segment9", DbType.String, _UserWiseVarsionName_List.Segment9);
                //AddParameter(oDbCommand, "@Segment10", DbType.String, _UserWiseVarsionName_List.Segment10);
                //AddParameter(oDbCommand, "@StartDate", DbType.DateTime, _UserWiseVarsionName_List.StartDate);
                //AddParameter(oDbCommand, "@EndDate", DbType.DateTime, _UserWiseVarsionName_List.EndDate);
                //if (_UserWiseVarsionName_List.IsActiveHouse.HasValue)
                //{ AddParameter(oDbCommand, "@IsHouse ", DbType.Boolean, _UserWiseVarsionName_List.IsActiveHouse); }
                //else { AddParameter(oDbCommand, "@IsHouse ", DbType.Boolean, DBNull.Value);}
                //if (_UserWiseVarsionName_List.IsActive.HasValue)
                //{ AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _UserWiseVarsionName_List.IsActive); }
                //else { AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value);}
                AddParameter(oDbCommand, "@CreateBy", DbType.String, _UserWiseVarsionName_List.CreateBy);
                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(UserWiseVarsionName_ListBOL _UserWiseVarsionName_List)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_Reports_Column_VersionNameUpdateRow", CommandType.StoredProcedure);
                //AddParameter(oDbCommand, "@SegmentsCombinationCode", DbType.String, _UserWiseVarsionName_List.SegmentsCombinationCode);
                //AddParameter(oDbCommand, "@SegmentsCombinationAutoID", DbType.String, _UserWiseVarsionName_List.SegmentsCombinationAutoID);
                //AddParameter(oDbCommand, "@StructureCode", DbType.String, _UserWiseVarsionName_List.StructureCode);
                //AddParameter(oDbCommand, "@Segment1", DbType.String, _UserWiseVarsionName_List.Segment1);
                //AddParameter(oDbCommand, "@Segment2", DbType.String, _UserWiseVarsionName_List.Segment2);
                //AddParameter(oDbCommand, "@Segment3", DbType.String, _UserWiseVarsionName_List.Segment3);
                //AddParameter(oDbCommand, "@Segment4", DbType.String, _UserWiseVarsionName_List.Segment4);
                //AddParameter(oDbCommand, "@Segment5", DbType.String, _UserWiseVarsionName_List.Segment5);
                //AddParameter(oDbCommand, "@Segment6", DbType.String, _UserWiseVarsionName_List.Segment6);
                //AddParameter(oDbCommand, "@Segment7", DbType.String, _UserWiseVarsionName_List.Segment7);
                //AddParameter(oDbCommand, "@Segment8", DbType.String, _UserWiseVarsionName_List.Segment8);
                //AddParameter(oDbCommand, "@Segment9", DbType.String, _UserWiseVarsionName_List.Segment9);
                //AddParameter(oDbCommand, "@Segment10", DbType.String, _UserWiseVarsionName_List.Segment10);
                //AddParameter(oDbCommand, "@StartDate", DbType.DateTime, _UserWiseVarsionName_List.StartDate);
                //AddParameter(oDbCommand, "@EndDate", DbType.DateTime, _UserWiseVarsionName_List.EndDate);
                //if (_UserWiseVarsionName_List.IsActiveHouse.HasValue)
                //{ AddParameter(oDbCommand, "@IsHouse ", DbType.Boolean, _UserWiseVarsionName_List.IsActiveHouse); }
                //else { AddParameter(oDbCommand, "@IsHouse ", DbType.Boolean, DBNull.Value); }
                //if (_UserWiseVarsionName_List.IsActive.HasValue)
                //{ AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _UserWiseVarsionName_List.IsActive); }
                //else { AddParameter(oDbCommand, "@IsActive", DbType.Boolean, DBNull.Value); }
                //AddParameter(oDbCommand, "@CreateBy", DbType.String, _UserWiseVarsionName_List.CreateBy);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(UserWiseVarsionName_ListBOL _UserWiseVarsionName_List)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SP_TB_UserWiseVarsionName_ListDeleteRow", CommandType.StoredProcedure);
                // AddParameter(oDbCommand, "@SegmentsCombinationCode", DbType.String, _UserWiseVarsionName_List.SegmentsCombinationCode);
                AddParameter(oDbCommand, "@VersoinAutoID", DbType.String, Convert.ToSingle(_UserWiseVarsionName_List.VersoinAutoID));


                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
