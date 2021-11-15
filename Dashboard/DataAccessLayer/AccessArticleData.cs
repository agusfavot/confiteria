using System;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class AccessArticleData
    {
        #region Patron Singleton
        private static AccessArticleData access = null;
        private AccessArticleData() { }

        public static AccessArticleData getInstance() {
            return access == null ? new AccessArticleData() : access;
        }
        #endregion

        public int insertArticle(Dictionary<object, object> parameters)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("inserItem", connection);

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

        public int updateArticle(Dictionary<object, object> parameters)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("updateItem", connection);

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

        public int deleteArticle(Dictionary<object, object> parameters)
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("deleteItem", connection);

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

        public List<Item> searAllArticles()
        {
            SqlConnection connection = Connection.getInstance().connectionDB();
            SqlCommand command = new SqlCommand("allItem", connection);
            DataTable table = new DataTable();
            SqlDataReader reader = null;
            var list = new List<Item>();

            
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    var item = new Item();
                    item.Id = int.Parse(reader["id"].ToString());
                    item.Name = reader["name"].ToString();
                    item.Description = reader["description"].ToString();
                    item.Price = float.Parse(reader["price"].ToString());
                    item.IdSector = int.Parse(reader["idSector"].ToString());
                    list.Add(item);
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
