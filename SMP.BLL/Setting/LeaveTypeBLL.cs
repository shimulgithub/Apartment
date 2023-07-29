using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
   public class LeaveTypeBLL
    {

		public LeaveTypeDAL LeaveTypeDAL { get; set; }

		public LeaveTypeBLL()
		{
			LeaveTypeDAL = new LeaveTypeDAL();
		}

		public int LeaveType_Add(LeaveTypeBOL _LeaveType)
		{
			try
			{
				return LeaveTypeDAL.Add(_LeaveType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int LeaveType_Update(LeaveTypeBOL _LeaveType)
		{
			try
			{
				return LeaveTypeDAL.Update(_LeaveType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int LeaveType_Delete(LeaveTypeBOL _LeaveType)
		{
			try
			{
				return LeaveTypeDAL.Delete(_LeaveType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public LeaveTypeBOL LeaveType_GetById(LeaveTypeBOL _LeaveType)
		{
			try
			{
				return LeaveTypeDAL.LeaveType_GetById(_LeaveType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable LeaveType_GetDataForGV()
		{
			try
			{
				return LeaveTypeDAL.LeaveType_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}

}
