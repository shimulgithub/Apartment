using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public  class AttendanceBLL
    {
		public AttendanceDAL AttendanceDAL { get; set; }

		public AttendanceBLL()
		{
			AttendanceDAL = new AttendanceDAL();
		}

		public int Attendance_Add(AttendanceBOL _Attendance)
		{
			try
			{
				return AttendanceDAL.Add(_Attendance);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Attendance_Update(AttendanceBOL _Attendance)
		{
			try
			{
				return AttendanceDAL.Update(_Attendance);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Attendance_Delete(AttendanceBOL _Attendance)
		{
			try
			{
				return AttendanceDAL.Delete(_Attendance);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public AttendanceBOL Attendance_GetById(AttendanceBOL _Attendance)
		{
			try
			{
				return AttendanceDAL.Attendance_GetById(_Attendance);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable Attendance_GetDataForGV()
		{
			try
			{
				return AttendanceDAL.Attendance_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
