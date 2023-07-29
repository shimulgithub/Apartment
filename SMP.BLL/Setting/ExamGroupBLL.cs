using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class ExamGroupBLL
    {
		public ExamGroupDAL ExamGroupDAL { get; set; }

		public ExamGroupBLL()
		{
			ExamGroupDAL = new ExamGroupDAL();
		}

		public int ExamGroup_Add(ExamGroupBOL _ExamGroup)
		{
			try
			{
				return ExamGroupDAL.Add(_ExamGroup);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int ExamGroup_Update(ExamGroupBOL _ExamGroup)
		{
			try
			{
				return ExamGroupDAL.Update(_ExamGroup);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int ExamGroup_Delete(ExamGroupBOL _ExamGroup)
		{
			try
			{
				return ExamGroupDAL.Delete(_ExamGroup);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public ExamGroupBOL ExamGroup_GetById(ExamGroupBOL _ExamGroup)
		{
			try
			{
				return ExamGroupDAL.ExamGroup_GetById(_ExamGroup);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable ExamGroup_GetDataForGV()
		{
			try
			{
				return ExamGroupDAL.ExamGroup_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
