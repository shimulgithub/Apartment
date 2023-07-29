using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Globalization;
using SMP.Common;
using System.Runtime.InteropServices;

public partial class ExcelfileReportViewer : System.Web.UI.Page
{
    private IList<Stream> m_streams;
    String myScript = null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConS2pibd"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            HidParam.Value = Request.QueryString["param"].ToString();
            DataTable dt = new DataTable();

            rptViewer.DataBind();

        }

    }

    protected void rptViewer_DataBinding(object sender, EventArgs e)
    {
      
        DataTable dt = null;
        dt = new DataTable();

        #region FeesCollect
        if (HidParam.Value == "FeesCollect")
        {


            string StudentId = Request.QueryString["StudentId"].ToString();
            string ClassId = Request.QueryString["ClassId"].ToString();
            string FeesTypeId = Request.QueryString["FeesTypeId"].ToString();


            SqlCommand cmd = new SqlCommand("SP_TB_StudentWiseFeesCollectionDetailById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["StudentId"].ToString());
            cmd.Parameters.AddWithValue("@ClassId", Request.QueryString["ClassId"].ToString());
            cmd.Parameters.AddWithValue("@FeesTypeId", Request.QueryString["FeesTypeId"].ToString());

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("FeesInvoice", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/FeesInvoice.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region IncomeEntry
        if (HidParam.Value == "IncomePrint")
        {
            Global oTakaWords = new Global();
            string InwordTaka= oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));
            string StudentId = Request.QueryString["Id"].ToString();
            string paramAmt = InwordTaka + " " + "Taka Only";
            SqlCommand cmd = new SqlCommand("SP_TB_IncomeByIdWithInwordTaka", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"].ToString());
            cmd.Parameters.AddWithValue("@InwordTaka", paramAmt);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("IncomePrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/IncomePrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }

        if (HidParam.Value == "IncomePrintSearch")
        {
            //Global oTakaWords = new Global();
            //string InwordTaka = oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));
            //string StudentId = Request.QueryString["Id"].ToString();
            //string paramAmt = InwordTaka + " " + "Taka Only";
            SqlCommand cmd = new SqlCommand("SP_TB_IncomeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"].ToString());
           /// cmd.Parameters.AddWithValue("@InwordTaka", paramAmt);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("IncomeSearchPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/IncomeSearchPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region ExpenseEntry
        if (HidParam.Value == "ExpensePrint")
        {
            Global oTakaWords = new Global();
            string InwordTaka = oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));
            string StudentId = Request.QueryString["Id"].ToString();
            string paramAmt = InwordTaka + " " + "Taka Only";
            SqlCommand cmd = new SqlCommand("SP_TB_ExpenseByIdWithInwordTaka", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"].ToString());
            cmd.Parameters.AddWithValue("@InwordTaka", paramAmt);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ExpensePrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/ExpensePrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }

        if (HidParam.Value == "ExpensePrintSearch")
        {
            //Global oTakaWords = new Global();
            //string InwordTaka = oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));
            //string StudentId = Request.QueryString["Id"].ToString();
            //string paramAmt = InwordTaka + " " + "Taka Only";
            SqlCommand cmd = new SqlCommand("SP_TB_ExpenseList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"].ToString());
            /// cmd.Parameters.AddWithValue("@InwordTaka", paramAmt);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ExpenseSearchPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/ExpenseSearchPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region FeesDue
        if (HidParam.Value == "FeesDueSearch")
        {
            //Global oTakaWords = new Global();
            //string InwordTaka = oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));
           
            
            string ClassId = Request.QueryString["CId"].ToString();
            string SectionId = Request.QueryString["SId"].ToString();
            string TypeId = Request.QueryString["TId"].ToString();
            string sBoxtxt = Request.QueryString["sBoxtxt"].ToString();

            SqlCommand cmd = new SqlCommand("SP_TB_FeesSearchDue", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClassId", ClassId);
            cmd.Parameters.AddWithValue("@SectionId", SectionId);
            cmd.Parameters.AddWithValue("@FeesTypeId", TypeId);
            cmd.Parameters.AddWithValue("@SearchBox", sBoxtxt);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("FeesDueSearchPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/FeesDueSearchPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region FeesPayment
        if (HidParam.Value == "FeesPaymentSearch")
        {
            //Global oTakaWords = new Global();
            //string InwordTaka = oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));

            string ClassId = Request.QueryString["CId"].ToString();
            string SectionId = Request.QueryString["SId"].ToString();
            string TypeId = Request.QueryString["TId"].ToString();
            string sBoxtxt = Request.QueryString["sBoxtxt"].ToString();

            SqlCommand cmd = new SqlCommand("SP_TB_FeesSearchPaymentSearchBox", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClassId", ClassId);
            cmd.Parameters.AddWithValue("@SectionId", SectionId);
            cmd.Parameters.AddWithValue("@FeesTypeId", TypeId);
            cmd.Parameters.AddWithValue("@SearchBox", sBoxtxt);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("FeesPaymentSearchPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/FeesPaymentSearchPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region FeesCollectSelectedPrint
        if (HidParam.Value == "FeesCollectPrint")
        {
            Global oTakaWords = new Global();
            string InwordTaka = oTakaWords.TakaWords(Convert.ToDouble(Request.QueryString["amt"].ToString()));
            string StudentId = Request.QueryString["Id"].ToString();
            string paramAmt = InwordTaka + " " + "Taka Only";


            string _Id = Request.QueryString["Id"].ToString();
            string _ClassId = Request.QueryString["CId"].ToString();
            string _FeesTypeId = Request.QueryString["FTId"].ToString();
            string _PaymentCode = Request.QueryString["PC"].ToString();

            SqlCommand cmd = new SqlCommand("SP_TB_StudentWiseFeesCollectionDetailPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _Id);
            cmd.Parameters.AddWithValue("@ClassId", _ClassId);
            cmd.Parameters.AddWithValue("@FeesTypeId", _FeesTypeId);
            cmd.Parameters.AddWithValue("@InvoiceNo", _PaymentCode);
            cmd.Parameters.AddWithValue("@FeesAmtInword", paramAmt);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("FeesCollectPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/FeesCollectPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region FeesCollectPrint
        if (HidParam.Value == "PrintSelected")
        {

            dt = (DataTable)Session["chkdt"];
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("FeesSelectedPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/FeesSelectedPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

        #region AdmitCardPrint
        if (HidParam.Value == "AdmitCardPrint")
        {
            Global oTakaWords = new Global();
         

            string _Id = Request.QueryString["sId"].ToString();
            string _ClassId = Request.QueryString["cId"].ToString();
            string _FeesTypeId = Request.QueryString["fId"].ToString();
          
            SqlCommand cmd = new SqlCommand("SP_TB_StudentAdmitPrint", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _Id);
            cmd.Parameters.AddWithValue("@ClassId", _ClassId);
            cmd.Parameters.AddWithValue("@FeesTypeId", _FeesTypeId);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }

            cmd.Dispose();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("AdmitCardPrint", dt));
            rptViewer.LocalReport.ReportPath = Server.MapPath("Reports/AdmitCardPrint.rdlc");
            rptViewer.LocalReport.EnableHyperlinks = true;

        }
        #endregion

    }


    private void saveRptAs(String s_rptType, string deviceInfo)
    {
        String path = HttpContext.Current.Request.PhysicalApplicationPath;
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;
        m_streams = new List<Stream>();
        //string strReportType = Request.QueryString["ReportType"].ToString();
        byte[] bytes;

        bytes = rptViewer.LocalReport.Render(s_rptType, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

        File.Delete(path + @"\TempReport." + extension);

        if (s_rptType == "word")
        {
            //FileStream stream = File.OpenWrite(@"C:\Inetpub\wwwroot\cims\samplep." + extension);
            FileStream stream = File.OpenWrite(path + @"\TempReport." + extension);
            stream.Write(bytes, 0, bytes.Length);
            m_streams.Add(stream);
            stream.Close();

            // string getpath = HttpContext.Current.Request.Url.AbsoluteUri.ToString().Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.ToString().LastIndexOf('/') + 1);
            Response.Redirect("~/ReportPrint.aspx");
        }
        else
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            //Response.AddHeader("content-disposition", "inline; filename=printable." + extension);

            Response.AddHeader("content-disposition", "attachment; filename=ContractPropossedCommissionBreakdown-" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss") + "." + extension);
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}