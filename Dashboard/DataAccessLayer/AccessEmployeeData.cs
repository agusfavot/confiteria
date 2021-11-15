using System;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class AccessEmployeeData
    {
        #region Patron Singleton
        private static AccessEmployeeData access = null;
        private AccessEmployeeData() { }
        public static AccessEmployeeData getInstance() {
            return access == null ? new AccessEmployeeData() : access;
        }
        #endregion

        public int insertEmployee(Dictionary<object, object> parameters) 
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("insertEmployee",connection);

            foreach (var item in parameters) command.Parameters.AddWithValue(item.Key.ToString(),item.Value);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();
                return command.ExecuteNonQuery();
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

        public int updateEmployee(Dictionary<object, object> parameters) 
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("updateEmployee", connection);

            foreach (var item in parameters) command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                return command.ExecuteNonQuery();                
            }
            catch (Exception) 
            {
                throw;
            }
            finally {
                connection.Close();
            }            
        }

        public int deleteEmployee(Dictionary<object, object> parameters) {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("deleteEmployee", connection);

            foreach (var item in parameters) command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();
                return command.ExecuteNonQuery();
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

        public List<Employee> searchAllEmployee() {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("allEmployee", connection);
            SqlDataReader reader = null;
            var list = new List<Employee>();

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read()) {
                    Employee employee = new Employee();
                    employee.Id = int.Parse(reader["id"].ToString());
                    employee.Name = reader["name"].ToString();
                    employee.LastName = reader["lastName"].ToString();
                    employee.Commission = float.Parse(reader["commission"].ToString());
                    list.Add(employee);
                }               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}
