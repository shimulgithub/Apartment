using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public  class StaffProfileBLL
    {

		public StaffProfileDAL StaffProfileDAL { get; set; }

		public StaffProfileBLL()
		{
			StaffProfileDAL = new StaffProfileDAL();
		}

		public int StaffProfile_Add(StaffProfileBOL _StaffProfile)
		{
			try
			{
				return StaffProfileDAL.Add(_StaffProfile);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int StaffProfile_Update(StaffProfileBOL _StaffProfile)
		{
			try
			{
				return StaffProfileDAL.Update(_StaffProfile);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int StaffProfile_Delete(StaffProfileBOL _StaffProfile)
		{
			try
			{
				return StaffProfileDAL.Delete(_StaffProfile);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public StaffProfileBOL StaffProfile_GetById(StaffProfileBOL _StaffProfile)
		{
			try
			{
				return StaffProfileDAL.StaffProfile_GetById(_StaffProfile);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable StaffProfile_GetDataForGV()
		{
			try
			{
				return StaffProfileDAL.StaffProfile_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
