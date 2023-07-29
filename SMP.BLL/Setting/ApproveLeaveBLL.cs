using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class ApproveLeaveBLL
    {
		public ApproveLeaveDAL ApproveLeaveDAL { get; set; }

		public ApproveLeaveBLL()
		{
			ApproveLeaveDAL = new ApproveLeaveDAL();
		}

		public int ApproveLeave_Add(ApproveLeaveBOL _ApproveLeave)
		{
			try
			{
				return ApproveLeaveDAL.Add(_ApproveLeave);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int ApproveLeave_Update(ApproveLeaveBOL _ApproveLeave)
		{
			try
			{
				return ApproveLeaveDAL.Update(_ApproveLeave);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int ApproveLeave_Delete(ApproveLeaveBOL _ApproveLeave)
		{
			try
			{
				return ApproveLeaveDAL.Delete(_ApproveLeave);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public ApproveLeaveBOL ApproveLeave_GetById(ApproveLeaveBOL _ApproveLeave)
		{
			try
			{
				return ApproveLeaveDAL.ApproveLeave_GetById(_ApproveLeave);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable ApproveLeave_GetDataForGV()
		{
			try
			{
				return ApproveLeaveDAL.ApproveLeave_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
