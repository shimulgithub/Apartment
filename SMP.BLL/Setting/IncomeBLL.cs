using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public  class IncomeBLL
    {
		public IncomeDAL IncomeDAL { get; set; }

		public IncomeBLL()
		{
			IncomeDAL = new IncomeDAL();
		}

		public int Income_Add(IncomeBOL _Income)
		{
			try
			{
				return IncomeDAL.Add(_Income);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Income_Update(IncomeBOL _Income)
		{
			try
			{
				return IncomeDAL.Update(_Income);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Income_Delete(IncomeBOL _Income)
		{
			try
			{
				return IncomeDAL.Delete(_Income);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public IncomeBOL Income_GetById(IncomeBOL _Income)
		{
			try
			{
				return IncomeDAL.Income_GetById(_Income);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable Income_GetDataForGV()
		{
			try
			{
				return IncomeDAL.Income_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
