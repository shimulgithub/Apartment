using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
     public class CollectFeesBLL
    {

		public CollectFeesDAL CollectFeesDAL { get; set; }

		public CollectFeesBLL()
		{
			CollectFeesDAL = new CollectFeesDAL();
		}

		public int CollectFees_Add(CollectFeesBOL _CollectFees)
		{
			try
			{
				return CollectFeesDAL.Add(_CollectFees);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int CollectFees_Update(CollectFeesBOL _CollectFees)
		{
			try
			{
				return CollectFeesDAL.Update(_CollectFees);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int CollectFees_Delete(CollectFeesBOL _CollectFees)
		{
			try
			{
				return CollectFeesDAL.Delete(_CollectFees);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public CollectFeesBOL CollectFees_GetById(CollectFeesBOL _CollectFees)
		{
			try
			{
				return CollectFeesDAL.CollectFees_GetById(_CollectFees);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable CollectFees_GetDataForGV()
		{
			try
			{
				return CollectFeesDAL.CollectFees_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}

		public int CollectFees_FeesCarryForward(CollectFeesBOL _CollectFees)
		{
			try
			{
				return CollectFeesDAL.FeesCarryForward_Add(_CollectFees);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
