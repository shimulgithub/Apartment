using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class FeesTypeBLL
    {
		public FeesTypeDAL FeesTypeDAL { get; set; }

		public FeesTypeBLL()
		{
			FeesTypeDAL = new FeesTypeDAL();
		}

		public int FeesType_Add(FeesTypeBOL _FeesType)
		{
			try
			{
				return FeesTypeDAL.Add(_FeesType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int FeesType_Update(FeesTypeBOL _FeesType)
		{
			try
			{
				return FeesTypeDAL.Update(_FeesType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int FeesType_Delete(FeesTypeBOL _FeesType)
		{
			try
			{
				return FeesTypeDAL.Delete(_FeesType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public FeesTypeBOL FeesType_GetById(FeesTypeBOL _FeesType)
		{
			try
			{
				return FeesTypeDAL.FeesType_GetById(_FeesType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable FeesType_GetDataForGV()
		{
			try
			{
				return FeesTypeDAL.FeesType_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
