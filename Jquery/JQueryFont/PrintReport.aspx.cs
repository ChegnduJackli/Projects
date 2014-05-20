using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.Data;

public partial class PrintReport : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet1 dsOrder = new DataSet1();
        DataTable dtOrder = dsOrder.Tables[0];
        dtOrder.Rows.Add("lideng", "125", "M", "1");
        dtOrder.Rows.Add("lideng1", "13", "M", "1");
        dtOrder.Rows.Add("lideng2", "14", "M", "2");
        dtOrder.Rows.Add("lideng3", "15", "M", "2");


        DataSetLine dsOrderLine = new DataSetLine();
        DataTable dtOrderLine = dsOrderLine.Tables[0];
        dtOrderLine.Rows.Add("11", "Desc", "33", "GST1", "1");
        dtOrderLine.Rows.Add("11", "Desc", "33", "GST1", "1");
        dtOrderLine.Rows.Add("22", "Desc", "44", "GST2", "2");
        dtOrderLine.Rows.Add("22", "Desc", "44", "GST2", "2");


        ReportDataSource rds = new ReportDataSource("DataSet1", dtOrder);

        ReportDataSource reportDataSource = new ReportDataSource("DataSet2", dtOrderLine);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
        ReportViewer1.LocalReport.Refresh();
    }
    
    protected void btnPrintReport_Click(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable();
        //dt.Columns.Add(new DataColumn("Name"));
        //dt.Columns.Add(new DataColumn("Age"));
        //dt.Columns.Add(new DataColumn("Sex"));
        //dt.Rows.Add("lideng", "12", "M");
        //dt.Rows.Add("lideng1", "13", "M");
        //dt.Rows.Add("lideng2", "14", "M");
        //dt.Rows.Add("lideng3", "15", "M");
        DataSet1 dsOrder = new DataSet1();
        DataTable dtOrder = dsOrder.Tables[0];
        dtOrder.Rows.Add("lideng", "125", "M","1");
        dtOrder.Rows.Add("lideng1", "13", "M","1");
        dtOrder.Rows.Add("lideng2", "14", "M","2");
        dtOrder.Rows.Add("lideng3", "15", "M","2");


        DataSetLine dsOrderLine = new DataSetLine();
        DataTable dtOrderLine = dsOrderLine.Tables[0];
        dtOrderLine.Rows.Add("11", "Desc", "33","GST1","1");
        dtOrderLine.Rows.Add("11", "Desc", "33", "GST1", "1");
        dtOrderLine.Rows.Add("22", "Desc", "44", "GST2", "2");
        dtOrderLine.Rows.Add("22", "Desc", "44", "GST2", "2");

        LocalReport localReport = new LocalReport();
        localReport.ReportPath = Server.MapPath("Report.rdlc");
        ReportDataSource reportDataSource;
        reportDataSource = new ReportDataSource("DataSet1", dtOrder);
        localReport.DataSources.Add(reportDataSource);

        reportDataSource = new ReportDataSource("DataSet2", dtOrderLine);
        localReport.DataSources.Add(reportDataSource);


        string reportType = "PDF";
        string mimeType;
        string encoding;
        string fileNameExtension;

        string deviceInfo =
        "<DeviceInfo>" +
        "  <OutputFormat>PDF</OutputFormat>" +
        "  <PageWidth>21cm</PageWidth>" +
        "  <PageHeight>29.5cm</PageHeight>" +
        "  <MarginTop>0.5in</MarginTop>" +
            //"  <MarginLeft>1in</MarginLeft>" +
            //"  <MarginRight>1in</MarginRight>" +
        "  <MarginBottom>0.5in</MarginBottom>" +
        "</DeviceInfo>";

        Warning[] warnings;
        string[] streams;
        byte[] renderedBytes;

        //Render the report
        renderedBytes = localReport.Render(
        reportType,
        deviceInfo,
        out mimeType,
        out encoding,
        out fileNameExtension,
        out streams,
        out warnings);

        Response.Clear();
        Response.ContentType = mimeType;
        Response.AddHeader("content-disposition", "attachment; filename=TRANSACTIONDETAILS." + fileNameExtension);
        Response.BinaryWrite(renderedBytes);
        Response.End();

    }
}