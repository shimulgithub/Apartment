using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using System.Configuration;
using SMP.DAL;
using System.Data.SqlClient;

namespace SMP.Common
{
    public class Global
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString;


        #region Conversion
        public DateTime FirstDayofMonth(DateTime _Date)
        {
            //Written by Shaila
            DateTime dDate = _Date.AddDays(1 - _Date.Day);
            return dDate;
        }	//EndofFirstDayofMonth

        public DateTime LastDayofMonth(DateTime _Date)
        {
            //Written by Shaila
            // Edited by Numery            
            if (_Date.Day == 31)
            {
                DateTime dDate = _Date.AddMonths(1).AddDays(1 - _Date.Day);
                return dDate;
            }
            else
            {
                DateTime dDate = _Date.AddMonths(1).AddDays(-_Date.Day);
                return dDate;
            }
        }	//EndofLastDayofMonth

        public DateTime FirstDayofLastMonth(DateTime _Date)
        {
            //Written by Md. Abdul Hakim
            DateTime Month = new DateTime(_Date.Year, _Date.Month, 1);
            DateTime dDate = Month.AddMonths(-1);
            return dDate;
        }
        public DateTime LastDayofLastMonth(DateTime _Date)
        {
            //Written by Md. Abdul Hakim
            DateTime Month = new DateTime(_Date.Year, _Date.Month, 1);
            DateTime dDate = Month.AddDays(-1);
            return dDate;
        }
        //Added by Arif Khan on 1-Apr-2013 (for Android reporting)
        public DateTime FirstDayOfWeek(DateTime date)
        {
            DateTime candidateDate = date;
            while (candidateDate.DayOfWeek != DayOfWeek.Saturday)
            {
                candidateDate = candidateDate.AddDays(-1);
            }
            return candidateDate;
        }

        public string Left(string _Str, int _Len)
        {
            //Written by Shaila
            string sStr;
            if (_Len < _Str.Length)
            { sStr = _Str.Substring(0, _Len); }
            else { sStr = _Str; }
            return sStr;
        }	//EndofLeft

        public string Right(string _Str, int _Len)
        {
            //Written by Shaila
            string sStr;

            if (_Len < _Str.Length)
            { sStr = _Str.Substring(_Str.Length - _Len, _Len); }
            else { sStr = _Str; }
            return sStr;
        }	//EndofRight

        private string HundredWords(int _Number)
        {
            //Written by Shaila
            string _HundredWords;

            string[] _Digits = new string[10] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] _Teens = new string[10] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] _Tens = new string[10] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string _NumStr;
            string sPos1;
            string sPos2;
            string sPos3;

            _NumStr = this.Right(_Number.ToString("000"), 3);

            if (this.Left(_NumStr, 1) != "0")
            { sPos1 = _Digits.GetValue(Convert.ToInt32(this.Left(_NumStr, 1))) + " Hundred"; }
            else
            { sPos1 = ""; }

            _NumStr = this.Right(_NumStr, 2);

            if (this.Left(_NumStr, 1) == "1")
            {
                sPos2 = Convert.ToString(_Teens.GetValue(Convert.ToInt32(this.Right(_NumStr, 1))));
                sPos3 = "";
            }
            else
            {
                sPos2 = Convert.ToString(_Tens.GetValue(Convert.ToInt32(this.Left(_NumStr, 1))));
                sPos3 = Convert.ToString(_Digits.GetValue(Convert.ToInt32(this.Right(_NumStr, 1))));
            }
            _HundredWords = sPos1;
            if (_HundredWords != "")
            {
                if (sPos2 != "")
                {
                    _HundredWords = _HundredWords + " ";
                }
            }
            _HundredWords = _HundredWords + sPos2;

            if (_HundredWords != "")
            {
                if (sPos3 != "")
                {
                    _HundredWords = _HundredWords + " ";
                }
            }
            _HundredWords = _HundredWords + sPos3;
            return _HundredWords;
        }	//EndofHundredWords

        public string TakaWords(double _Number)
        {
            //Written by Shaila
            string _Sign = "";
            string _TakaWords;
            string _NumStr;
            string _sTaka;
            string _sPaisa;

            string[] sPows = new string[3] { "Crore", "Thousand", "Lac" };

            if (_Number < 0)
            {
                _Sign = "Minus";
                _Number = Math.Abs(_Number);
            }

            _NumStr = _Number.ToString("0.00");
            _sPaisa = HundredWords(Convert.ToInt32(this.Right(_NumStr, 2)));

            if (_sPaisa != "") { _sPaisa = " Paisa " + _sPaisa; }

            _NumStr = this.Left(_NumStr, _NumStr.Length - 3);
            _sTaka = HundredWords(Convert.ToInt32(this.Right(_NumStr, 3)));

            if (_NumStr.Length <= 3)
            { _NumStr = ""; }
            else
            { _NumStr = this.Left(_NumStr, _NumStr.Length - 3); }

            int _nCommaCount;
            int _nDigitCount;
            string _sPow;

            _nCommaCount = 1;

            if (_NumStr != "")
            {
                do
                {
                    if (_nCommaCount % 3 == 0)
                        _nDigitCount = 3;
                    else
                        _nDigitCount = 2;


                    _sPow = HundredWords(Convert.ToInt32(this.Right(_NumStr, _nDigitCount)));

                    if (_sPow != "")
                    {
                        if (Convert.ToString(_Number).Length > 10)
                        {
                            _sPow = _sPow + " " + sPows.GetValue(_nCommaCount % 3) + " Crore ";
                        }
                        else
                            _sPow = _sPow + " " + sPows.GetValue(_nCommaCount % 3);
                    }

                    if (_sTaka != "")
                    {
                        if (_sPow != "")
                            _sPow = _sPow + " ";
                    }

                    _sTaka = _sPow + _sTaka;

                    if (_NumStr.Length <= _nDigitCount)
                        _NumStr = "";
                    else
                        _NumStr = this.Left(_NumStr, _NumStr.Length - _nDigitCount);

                    _nCommaCount = _nCommaCount + 1;

                } //EndDo
                while (_NumStr != "");
            }

            if (_sTaka != "")
            {
                _sTaka = _sTaka;
            }
            _TakaWords = _sTaka;

            if (_TakaWords != "")
            {
                if (_sPaisa != "")
                    _TakaWords = _TakaWords + " And";
            }
            _TakaWords = _TakaWords + _sPaisa;

            if (_TakaWords == "")
                _TakaWords = "Zero";

            _TakaWords = _Sign + _TakaWords;
            return _TakaWords;

        } //EndofTakaWords 

        public string TakaFormat(double _Number)
        {
            //Written by Shaila
            string _sign = "";
            string _NumStr;
            string _TakaFormat;

            if (_Number < 0)
            {
                _sign = "-";
                _Number = (-_Number);
            }

            _NumStr = _Number.ToString("0.00");
            _TakaFormat = this.Right(_NumStr, 6);
            if ((_NumStr.Length) <= 6)
            { _NumStr = ""; }
            else
            { _NumStr = this.Left(_NumStr, _NumStr.Length - 6); }

            if (_NumStr == "")
            {
                _TakaFormat = _TakaFormat;
                return _TakaFormat;
            }

            int _CommaCount = 1;
            int _DigitCount = 0;

            do
            {
                if (_CommaCount % 3 == 0)
                { _DigitCount = 3; }
                else { _DigitCount = 2; }

                _TakaFormat = this.Right(_NumStr, _DigitCount) + "," + _TakaFormat;

                if (_NumStr.Length <= _DigitCount)
                {
                    _NumStr = "";
                }
                else
                    _NumStr = this.Left(_NumStr, _NumStr.Length - _DigitCount);

                _CommaCount = _CommaCount + 1;
            }	//end do
            while (_NumStr != "");
            _TakaFormat = _sign + _TakaFormat;
            return _TakaFormat;
        }	//End of TakaFormat

        public string TakaFormat(decimal _Number)
        {
            //Written by Shaila
            string _sign = "";
            string _NumStr;
            string _TakaFormat;

            if (_Number < 0)
            {
                _sign = "-";
                _Number = (-_Number);
            }

            _NumStr = _Number.ToString("0.00");
            _TakaFormat = this.Right(_NumStr, 6);
            if ((_NumStr.Length) <= 6)
            { _NumStr = ""; }
            else
            { _NumStr = this.Left(_NumStr, _NumStr.Length - 6); }

            if (_NumStr == "")
            {
                _TakaFormat = _TakaFormat;
                return _sign + _TakaFormat;
            }

            int _CommaCount = 1;
            int _DigitCount = 0;

            do
            {
                if (_CommaCount % 3 == 0)
                { _DigitCount = 3; }
                else { _DigitCount = 2; }

                _TakaFormat = this.Right(_NumStr, _DigitCount) + "," + _TakaFormat;

                if (_NumStr.Length <= _DigitCount)
                {
                    _NumStr = "";
                }
                else
                    _NumStr = this.Left(_NumStr, _NumStr.Length - _DigitCount);

                _CommaCount = _CommaCount + 1;
            }	//end do
            while (_NumStr != "");
            _TakaFormat = _sign + _TakaFormat;
            return _TakaFormat;
        }	//End of TakaFormat

        public string MillionFormat(double _Number)
        {
            //Written by Shaila
            string _sign = "";
            string _NumStr;
            string _MilFormat;

            if (_Number < 0)
            {
                _sign = "-";
                _Number = (-_Number);
            }

            _NumStr = _Number.ToString("0.00");
            _MilFormat = this.Right(_NumStr, 6);
            if ((_NumStr.Length) <= 6)
            {
                _NumStr = "";
            }
            else
                _NumStr = this.Left(_NumStr, _NumStr.Length - 6);

            if (_NumStr == "")
            {
                _MilFormat = _MilFormat;
                return _MilFormat;
            }

            int _CommaCount = 1;
            int _DigitCount = 3;

            do
            {
                _MilFormat = this.Right(_NumStr, _DigitCount) + "," + _MilFormat;

                if (_NumStr.Length <= _DigitCount)
                {
                    _NumStr = "";
                }
                else
                    _NumStr = this.Left(_NumStr, _NumStr.Length - _DigitCount);

                _CommaCount = _CommaCount + 1;
            }	//end do
            while (_NumStr != "");
            _MilFormat = _sign + _MilFormat;
            return _MilFormat;
        }	//End of MilFormat

        public string MillionFormat(decimal _Number)
        {
            //Written by Shaila
            string _sign = "";
            string _NumStr;
            string _MilFormat;

            if (_Number < 0)
            {
                _sign = "-";
                _Number = (-_Number);
            }

            _NumStr = _Number.ToString("0.00");
            _MilFormat = this.Right(_NumStr, 6);
            if ((_NumStr.Length) <= 6)
            {
                _NumStr = "";
            }
            else
                _NumStr = this.Left(_NumStr, _NumStr.Length - 6);

            if (_NumStr == "")
            {
                _MilFormat = _MilFormat;
                return _MilFormat;
            }

            int _CommaCount = 1;
            int _DigitCount = 3;

            do
            {
                _MilFormat = this.Right(_NumStr, _DigitCount) + "," + _MilFormat;

                if (_NumStr.Length <= _DigitCount)
                {
                    _NumStr = "";
                }
                else
                    _NumStr = this.Left(_NumStr, _NumStr.Length - _DigitCount);

                _CommaCount = _CommaCount + 1;
            }	//end do
            while (_NumStr != "");
            _MilFormat = _sign + _MilFormat;
            return _MilFormat;
        }	//End of MilFormat

        public string MakeItSentence(string sString)
        {
            //Written by Arif Khan
            char a;
            int i = 0;

            for (i = 0; i < sString.Length; i++)
            {
                a = Convert.ToChar(sString.Substring(i, 1));
                if (Char.IsUpper(a))
                {
                    if (i != 0 && sString.Substring(i - 1, 1) != " ")
                        sString = sString.Insert(i, " ");
                }
            }
            return sString;
        } //End of MakeItSentence

        public string[] StringSplit(char Separator, string Text)
        {
            //Written by NUMERY ZABER
            char[] delimiterChars = { Separator };
            string text = Text.Trim();
            string[] words = text.Split(delimiterChars);
            return words;
        } //End of Split String



        public String changeNumericToWords(double numb)
        {
            String num = numb.ToString();
            return changeToWords(num, false);
        }
        public String changeCurrencyToWords(String numb)
        {
            return changeToWords(numb, true);
        }
        public String changeNumericToWords(String numb)
        {
            return changeToWords(numb, false);
        }
        public String changeCurrencyToWords(double numb)
        {
            return changeToWords(numb.ToString(), true);
        }
        private String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Cents " + endStr) : ("");
                        pointStr = translateCents(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch {; }
            return val;
        }
        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");

                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch {; }
            return word.Trim();
        }
        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private String translateCents(String cents)
        {
            String cts = "", digit = "", engOne = "";
            for (int i = 0; i < cents.Length; i++)
            {
                digit = cents[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }
        #endregion
        public static Int32 _Companyid;

        public static Int32 Companyid
        {
            get { return _Companyid; }
            set { _Companyid = value; }
        }

        public static Int32 _userID;

        public static Int32 userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public static string _userNameID = String.Empty;

        public static string userNameID
        {
            get { return _userNameID; }
            set { _userNameID = value; }
        }

        public static string _userName = String.Empty;

        public static string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public static Int32 _userRole = 0;

        public static Int32 userRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }

        public static string _userPassword = String.Empty;

        public static string userPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public static Int32 _User_Branch = 0;

        public static Int32 User_Branch
        {
            get { return _User_Branch; }
            set { _User_Branch = value; }
        }


        public Global()
        {
            DbProviderHelper.GetConnection();
        }

        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public static DataTable CreateDataTable(string pStoreProcedure)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateNo_Parameter(string pStoreProcedure, string ParamNo)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ParamNo", DbType.String, ParamNo));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateDataTableParameter(string pStoreProcedure, string param)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param", DbType.String, param));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
    

        public static DataTable CreateDataTableParameter(string pStoreProcedure, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param0", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param1", DbType.String, param1));
                //command.Parameters.Add(DbProviderHelper.CreateParameter("@param2", DbType.Int32, param2));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }


        public static DataTable CreateDataTableParameter(string pStoreProcedure, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@param0", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param1", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@param2", DbType.String, param2));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateDataTableParameterStudentAdmissionDetail(string pStoreProcedure, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param1));

                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateDataTableParameter_StudentWiseFeesCollectionDetail(string pStoreProcedure, string param, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Id", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FeesTypeId", DbType.String, param1));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
       
        public static DataTable CreateDataTableParameter_FeesSearchPayment(string pStoreProcedure, string param, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FeesTypeId", DbType.String, param1));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
      
        public static DataTable CreateDataTableParameter_FeesSearchDue(string pStoreProcedure, string param, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FeesTypeId", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param2));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
      
        public static DataTable CreateDataTableParameter_FeesSearchPayment(string pStoreProcedure, string param, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FeesTypeId", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param2));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateNo_IncomeSearchBox(string pStoreProcedure, string ParamNo)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@searchText", DbType.String, ParamNo));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateDataTableParameter_IncomeSearch(string pStoreProcedure, string param, DateTime  param0, DateTime param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@IncomeHeadId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.DateTime, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.DateTime, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param2));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
        
        public static DataTable CreateDataTableParameter_ExpenseSearch(string pStoreProcedure, string param, DateTime param0, DateTime param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ExpenseHeadId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.DateTime, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.DateTime, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param2));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
       
        public static DataTable CreateNo_FeesTypeSearchBox(string pStoreProcedure, string ParamNo)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, ParamNo));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateNo_FeesMasterSearchBox(string pStoreProcedure, string ParamNo)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, ParamNo));
                //AddParameter(command, "@param", DbType.Int32, param);
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

        public static DataTable CreateDataTableParameter_StudentAttendanceDetail(string pStoreProcedure, string param, string param0, DateTime param1, DateTime param2, string param3)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.DateTime, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.DateTime, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param3));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
       
        public static DataTable CreateDataTableParameter_GetStudentData(string pStoreProcedure, string param, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@StudentId", DbType.String, param1));

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
       
        public static DataTable CreateDataTableParameter_GetStudentDataByParam(string pStoreProcedure, string param, string param0, string param1)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Year", DbType.String, param1));

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
       
        public static DataTable CreateDataTableParameter_ApproveleaveSearch(string pStoreProcedure, string param, string param0, string param1, string param2)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId",   DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@StudentId", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SearchBox", DbType.String, param2));
                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
       
        public static DataTable CreateDataTableParameter_StudentDetailForAdmitCard(string pStoreProcedure, string param, string param0, string param1, string param2, string param3)
        {
            DbProviderHelper.GetConnection();
            DataTable table = new DataTable();
            try
            {
                DbCommand command = DbProviderHelper.CreateCommand(pStoreProcedure, CommandType.StoredProcedure);

                command.Parameters.Add(DbProviderHelper.CreateParameter("@Id", DbType.String, param));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@ClassId", DbType.String, param0));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@SectionId", DbType.String, param1));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@FeesTypeId", DbType.String, param2));
                command.Parameters.Add(DbProviderHelper.CreateParameter("@Year", DbType.String, param3));

                DbDataAdapter adapter = DbProviderHelper.CreateDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }

    }
}

