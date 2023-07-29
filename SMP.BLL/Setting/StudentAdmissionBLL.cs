using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SMP.BOL.Setting;
using SMP.DAL.Setting;

namespace SMP.BLL.Setting
{
     public class StudentAdmissionBLL
    {
        public StudentAdmissionDAL StudentAdmissionDAL { get; set; }

        public StudentAdmissionBLL()
        {
            StudentAdmissionDAL = new StudentAdmissionDAL();
        }

        public int StudentAdmission_Add(StudentAdmissionBOL _StudentAdmission)
        {
            try
            {
                return StudentAdmissionDAL.Add(_StudentAdmission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int StudentAdmission_Update(StudentAdmissionBOL _StudentAdmission)
        {
            try
            {
                return StudentAdmissionDAL.Update(_StudentAdmission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int StudentAdmission_Delete(StudentAdmissionBOL _StudentAdmission)
        {
            try
            {
                return StudentAdmissionDAL.Delete(_StudentAdmission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable StudentAdmission_GetById(StudentAdmissionBOL _StudentAdmission)
        {
            try
            {
                return StudentAdmissionDAL.StudentAdmission_GetById(_StudentAdmission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable StudentAdmission_GetDataForGV()
        {
            try
            {
                return StudentAdmissionDAL.StudentAdmission_GetDataForGV();
            }
            catch
            {
                return null;
            }
        }
        public DataTable StudentAdmission_GetDataByReceiptNo(string ReceiptNo)
        {
            try
            {
                return StudentAdmissionDAL.StudentAdmission_GetDataByReceiptNo(ReceiptNo);
            }
            catch
            {
                return null;
            }
        }


    }
}
