using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;


namespace SMP.BLL.Setting
{
    public  class FeesReminderBLL
    {
		public FeesReminderDAL FeesReminderDAL { get; set; }

		public FeesReminderBLL()
		{
			FeesReminderDAL = new FeesReminderDAL();
		}

		public int FeesReminder_Add(FeesReminderBOL _FeesReminder)
		{
			try
			{
				return FeesReminderDAL.Add(_FeesReminder);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int FeesReminder_Update(FeesReminderBOL _FeesReminder)
		{
			try
			{
				return FeesReminderDAL.Update(_FeesReminder);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int FeesReminder_Delete(FeesReminderBOL _FeesReminder)
		{
			try
			{
				return FeesReminderDAL.Delete(_FeesReminder);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public FeesReminderBOL FeesReminder_GetById(FeesReminderBOL _FeesReminder)
		{
			try
			{
				return FeesReminderDAL.FeesReminder_GetById(_FeesReminder);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable FeesReminder_GetDataForGV()
		{
			try
			{
				return FeesReminderDAL.FeesReminder_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
