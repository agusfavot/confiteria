using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccessReportData
    {
        private static AccessReportData access = null;
        private AccessReportData() { }
        public static AccessReportData getInstance() {
            return access == null ? new AccessReportData() : access;
        }

        public DataTable reportCantItem( ) {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("reportCantItem", connection);
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally {
                connection.Close();
            }
            return table;
        }

        public DataTable reportVentasXMozo() {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("reportVentXMozo", connection);
            DataTable table = new DataTable();            

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
    }
}
