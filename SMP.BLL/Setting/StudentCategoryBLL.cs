using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
   public class StudentCategoryBLL
    {

		public StudentCategoryDAL StudentCategoryDAL { get; set; }

		public StudentCategoryBLL()
		{
			StudentCategoryDAL = new StudentCategoryDAL();
		}

		public int StudentCategory_Add(StudentCategoryBOL _StudentCategory)
		{
			try
			{
				return StudentCategoryDAL.Add(_StudentCategory);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int StudentCategory_Update(StudentCategoryBOL _StudentCategory)
		{
			try
			{
				return StudentCategoryDAL.Update(_StudentCategory);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int StudentCategory_Delete(StudentCategoryBOL _StudentCategory)
		{
			try
			{
				return StudentCategoryDAL.Delete(_StudentCategory);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public StudentCategoryBOL StudentCategory_GetById(StudentCategoryBOL _StudentCategory)
		{
			try
			{
				return StudentCategoryDAL.StudentCategory_GetById(_StudentCategory);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable StudentCategory_GetDataForGV()
		{
			try
			{
				return StudentCategoryDAL.StudentCategory_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
