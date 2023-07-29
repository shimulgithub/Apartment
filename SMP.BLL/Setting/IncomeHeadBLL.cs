using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class IncomeHeadBLL
    {
		public IncomeHeadDAL IncomeHeadDAL { get; set; }

		public IncomeHeadBLL()
		{
			IncomeHeadDAL = new IncomeHeadDAL();
		}

		public int IncomeHead_Add(IncomeHeadBOL _IncomeHead)
		{
			try
			{
				return IncomeHeadDAL.Add(_IncomeHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int IncomeHead_Update(IncomeHeadBOL _IncomeHead)
		{
			try
			{
				return IncomeHeadDAL.Update(_IncomeHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int IncomeHead_Delete(IncomeHeadBOL _IncomeHead)
		{
			try
			{
				return IncomeHeadDAL.Delete(_IncomeHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public IncomeHeadBOL IncomeHead_GetById(IncomeHeadBOL _IncomeHead)
		{
			try
			{
				return IncomeHeadDAL.IncomeHead_GetById(_IncomeHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable IncomeHead_GetDataForGV()
		{
			try
			{
				return IncomeHeadDAL.IncomeHead_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}

	}
}
