using System;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace DataAccessLayer
{
    public class AccessUserData
    {
        #region Patron Singleton
        private static AccessUserData data = null;
        private AccessUserData() { }
        public static AccessUserData getInstance() {
            return data == null ? new AccessUserData() : data;
        }
        #endregion

        public User readerUser(Dictionary<object, object> parameters) {
           
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("searchUser", connection);
            DataTable table = new DataTable();
            var user = new User();

            command.Parameters.Clear();
            foreach (var item in parameters) command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.Name = reader["name"].ToString();
                    user.Password = (byte[])reader["password"];
                    user.Seed = (byte[])reader["seed"];
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                connection.Close();
            }
        }
    }
}
