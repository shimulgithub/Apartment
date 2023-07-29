using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class MarkGradeEntryBLL
    {
		public MarkGradeEntryDAL MarkGradeEntryDAL { get; set; }

		public MarkGradeEntryBLL()
		{
			MarkGradeEntryDAL = new MarkGradeEntryDAL();
		}

		public int MarkGradeEntry_Add(MarkGradeEntryBOL _MarkGradeEntry)
		{
			try
			{
				return MarkGradeEntryDAL.Add(_MarkGradeEntry);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int MarkGradeEntry_Update(MarkGradeEntryBOL _MarkGradeEntry)
		{
			try
			{
				return MarkGradeEntryDAL.Update(_MarkGradeEntry);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int MarkGradeEntry_Delete(MarkGradeEntryBOL _MarkGradeEntry)
		{
			try
			{
				return MarkGradeEntryDAL.Delete(_MarkGradeEntry);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public MarkGradeEntryBOL MarkGradeEntry_GetById(MarkGradeEntryBOL _MarkGradeEntry)
		{
			try
			{
				return MarkGradeEntryDAL.MarkGradeEntry_GetById(_MarkGradeEntry);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable MarkGradeEntry_GetDataForGV()
		{
			try
			{
				return MarkGradeEntryDAL.MarkGradeEntry_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
