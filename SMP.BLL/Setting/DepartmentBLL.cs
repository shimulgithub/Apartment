using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;


namespace SMP.BLL.Setting
{
    public class DepartmentBLL
    {

		public DepartmentDAL DepartmentDAL { get; set; }

		public DepartmentBLL()
		{
			DepartmentDAL = new DepartmentDAL();
		}

		public int Department_Add(DepartmentBOL _Department)
		{
			try
			{
				return DepartmentDAL.Add(_Department);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Department_Update(DepartmentBOL _Department)
		{
			try
			{
				return DepartmentDAL.Update(_Department);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Department_Delete(DepartmentBOL _Department)
		{
			try
			{
				return DepartmentDAL.Delete(_Department);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DepartmentBOL Department_GetById(DepartmentBOL _Department)
		{
			try
			{
				return DepartmentDAL.Department_GetById(_Department);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable Department_GetDataForGV()
		{
			try
			{
				return DepartmentDAL.Department_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
