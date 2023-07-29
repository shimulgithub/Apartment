using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class FeesDiscountBLL
    {
		public FeesDiscountDAL FeesDiscountDAL { get; set; }

		public FeesDiscountBLL()
		{
			FeesDiscountDAL = new FeesDiscountDAL();
		}

		public int FeesDiscount_Add(FeesDiscountBOL _FeesDiscount)
		{
			try
			{
				return FeesDiscountDAL.Add(_FeesDiscount);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int FeesDiscount_Update(FeesDiscountBOL _FeesDiscount)
		{
			try
			{
				return FeesDiscountDAL.Update(_FeesDiscount);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int FeesDiscount_Delete(FeesDiscountBOL _FeesDiscount)
		{
			try
			{
				return FeesDiscountDAL.Delete(_FeesDiscount);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public FeesDiscountBOL FeesDiscount_GetById(FeesDiscountBOL _FeesDiscount)
		{
			try
			{
				return FeesDiscountDAL.FeesDiscount_GetById(_FeesDiscount);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable FeesDiscount_GetDataForGV()
		{
			try
			{
				return FeesDiscountDAL.FeesDiscount_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
