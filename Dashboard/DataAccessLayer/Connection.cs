using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Connection
    {

        #region Patron Singleton
        private static Connection connection = null;
        private Connection() { }

        public static Connection getInstance() {
            return connection == null ? new Connection() : connection;
        }
        #endregion

        public SqlConnection connectionDB() {
            return new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connectionString"]);
        } 
    }
}
