using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;


namespace SMP.BLL.Setting
{
    public class DisableReasonBLL
    {
		public DisableReasonDAL DisableReasonDAL { get; set; }

		public DisableReasonBLL()
		{
			DisableReasonDAL = new DisableReasonDAL();
		}

		public int DisableReason_Add(DisableReasonBOL _DisableReason)
		{
			try
			{
				return DisableReasonDAL.Add(_DisableReason);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int DisableReason_Update(DisableReasonBOL _DisableReason)
		{
			try
			{
				return DisableReasonDAL.Update(_DisableReason);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int DisableReason_Delete(DisableReasonBOL _DisableReason)
		{
			try
			{
				return DisableReasonDAL.Delete(_DisableReason);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DisableReasonBOL DisableReason_GetById(DisableReasonBOL _DisableReason)
		{
			try
			{
				return DisableReasonDAL.DisableReason_GetById(_DisableReason);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable DisableReason_GetDataForGV()
		{
			try
			{
				return DisableReasonDAL.DisableReason_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
