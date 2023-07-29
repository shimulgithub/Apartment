using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
    public  class ExpenseBLL
    {
		public ExpenseDAL ExpenseDAL { get; set; }

		public ExpenseBLL()
		{
			ExpenseDAL = new ExpenseDAL();
		}

		public int Expense_Add(ExpenseBOL _Expense)
		{
			try
			{
				return ExpenseDAL.Add(_Expense);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Expense_Update(ExpenseBOL _Expense)
		{
			try
			{
				return ExpenseDAL.Update(_Expense);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Expense_Delete(ExpenseBOL _Expense)
		{
			try
			{
				return ExpenseDAL.Delete(_Expense);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public ExpenseBOL Expense_GetById(ExpenseBOL _Expense)
		{
			try
			{
				return ExpenseDAL.Expense_GetById(_Expense);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DataTable Expense_GetDataForGV()
		{
			try
			{
				return ExpenseDAL.Expense_GetDataForGV();
			}
			catch
			{
				return null;
			}
		}
	}
}
