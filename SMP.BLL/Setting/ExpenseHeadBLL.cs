using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public class ExpenseHeadBLL
    {
		public ExpenseHeadDAL ExpenseHeadDAL { get; set; }

		public ExpenseHeadBLL()
		{
			ExpenseHeadDAL = new ExpenseHeadDAL();
		}

		public int ExpenseHead_Add(ExpenseHeadBOL _ExpenseHead)
		{
			try
			{
				return ExpenseHeadDAL.Add(_ExpenseHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int ExpenseHead_Update(ExpenseHeadBOL _ExpenseHead)
		{
			try
			{
				return ExpenseHeadDAL.Update(_ExpenseHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int ExpenseHead_Delete(ExpenseHeadBOL _ExpenseHead)
		{
			try
			{
				return ExpenseHeadDAL.Delete(_ExpenseHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public ExpenseHeadBOL ExpenseHead_GetById(ExpenseHeadBOL _ExpenseHead)
		{
			try
			{
				return ExpenseHeadDAL.ExpenseHead_GetById(_ExpenseHead);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable ExpenseHead_GetDataForGV()
		{
			try
			{
				return ExpenseHeadDAL.ExpenseHead_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}

	}
}
