using System;
using BusinessLayer;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace Dashboard.Pages
{
    public partial class Local : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport1();
                loadReport2();
            }
        }

        private void loadReport1()
        {
            DataTable table = null;
            try
            {
                var time = DateTime.Now.ToShortDateString();
                table = InformeBL.getInstance().reportCantItem();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource report = new ReportDataSource("DataSet1", table);
                ReportViewer1.LocalReport.DataSources.Add(report);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void loadReport2()
        {
            DataTable table = null;
            try
            {
                table = InformeBL.getInstance().reportVentasXMozo();
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportDataSource report = new ReportDataSource("DataSet2", table);
                ReportViewer2.LocalReport.DataSources.Add(report);
                ReportViewer2.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}