using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class FeesMasterBLL
    {
		public FeesMasterDAL FeesMasterDAL { get; set; }

		public FeesMasterBLL()
		{
			FeesMasterDAL = new FeesMasterDAL();
		}

		public int FeesMaster_Add(FeesMasterBOL _FeesMaster)
		{
			try
			{
				return FeesMasterDAL.Add(_FeesMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int FeesMaster_Update(FeesMasterBOL _FeesMaster)
		{
			try
			{
				return FeesMasterDAL.Update(_FeesMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int FeesMaster_Delete(FeesMasterBOL _FeesMaster)
		{
			try
			{
				return FeesMasterDAL.Delete(_FeesMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public FeesMasterBOL FeesMaster_GetById(FeesMasterBOL _FeesMaster)
		{
			try
			{
				return FeesMasterDAL.FeesMaster_GetById(_FeesMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable FeesMaster_GetDataForGV()
		{
			try
			{
				return FeesMasterDAL.FeesMaster_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
