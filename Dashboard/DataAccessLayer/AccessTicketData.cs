using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class AccessTicketData
    {
        #region Patron Singleton
        private static AccessTicketData access = null;
        private AccessTicketData() { }

        public static AccessTicketData getInstance()
        {
            return access == null ? new AccessTicketData() : access;
        }
        #endregion

        public int insertTicket(Dictionary<object, object> parameters, int id ,List<object> list)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand();
            SqlTransaction transaction = null;
            int x = 0;

            foreach (var item in parameters) command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "insertTicket";

            try
            {
                command.Connection = connection;
                connection.Open();
                transaction = connection.BeginTransaction("Alta Ticket");
                command.Transaction = transaction;
                x = command.ExecuteNonQuery();

                foreach (var item in list)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@idItem", item);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "insertDetail";
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return x;
        }

        public int searchNextNumber() {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("searchNextNumberTicket",connection);
            int x = 0;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();
                x = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                x = 0;
            }            
            finally {
                connection.Close();
            }
            return x;
        }
    }
}
