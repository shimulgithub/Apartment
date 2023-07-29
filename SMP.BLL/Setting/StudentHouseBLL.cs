using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;


namespace SMP.BLL.Setting
{
   public   class StudentHouseBLL
    {
		public StudentHouseDAL StudentHouseDAL { get; set; }

		public StudentHouseBLL()
		{
			StudentHouseDAL = new StudentHouseDAL();
		}

		public int StudentHouse_Add(StudentHouseBOL _StudentHouse)
		{
			try
			{
				return StudentHouseDAL.Add(_StudentHouse);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int StudentHouse_Update(StudentHouseBOL _StudentHouse)
		{
			try
			{
				return StudentHouseDAL.Update(_StudentHouse);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int StudentHouse_Delete(StudentHouseBOL _StudentHouse)
		{
			try
			{
				return StudentHouseDAL.Delete(_StudentHouse);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public StudentHouseBOL StudentHouse_GetById(StudentHouseBOL _StudentHouse)
		{
			try
			{
				return StudentHouseDAL.StudentHouse_GetById(_StudentHouse);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable StudentHouse_GetDataForGV()
		{
			try
			{
				return StudentHouseDAL.StudentHouse_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
