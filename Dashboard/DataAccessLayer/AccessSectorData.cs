using System;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class AccessSectorData
    {
        #region Patron Singleton
        private static AccessSectorData access = null;
        private AccessSectorData() { }
        public static AccessSectorData getInstance() {
            return access == null ? new AccessSectorData() : access;
        }
        #endregion

        public int insertSector(Dictionary<object, object> parameters)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("insertSector", connection);

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

        public int updateSector(Dictionary<object, object> parameters)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("updateSector", connection);

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

        public int deleteSector(Dictionary<object, object> parameters)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("deleteSector", connection);

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

        public List<Sector> searchAllSector()
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("allSector", connection);
            DataTable table = new DataTable();
            SqlDataReader reader = null;
            var list = new List<Sector>();

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var sector = new Sector();
                    sector.Id = int.Parse(reader["id"].ToString());
                    sector.Name = reader["name"].ToString();
                    list.Add(sector);
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
