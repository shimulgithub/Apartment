using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
   public class DesignationBLL
    {
		public DesignationDAL DesignationDAL { get; set; }

		public DesignationBLL()
		{
			DesignationDAL = new DesignationDAL();
		}

		public int Designation_Add(DesignationBOL _Designation)
		{
			try
			{
				return DesignationDAL.Add(_Designation);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Designation_Update(DesignationBOL _Designation)
		{
			try
			{
				return DesignationDAL.Update(_Designation);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Designation_Delete(DesignationBOL _Designation)
		{
			try
			{
				return DesignationDAL.Delete(_Designation);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DesignationBOL Designation_GetById(DesignationBOL _Designation)
		{
			try
			{
				return DesignationDAL.Designation_GetById(_Designation);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable Designation_GetDataForGV()
		{
			try
			{
				return DesignationDAL.Designation_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
