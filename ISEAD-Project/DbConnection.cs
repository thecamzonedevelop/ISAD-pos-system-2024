using System;
using System.Data.SqlClient;

namespace ISEAD_Project
{
    internal class DbConnection
    {
        private readonly string connectionString;
        private SqlConnection connection;

        public DbConnection()
        {
            // Initialize the connection string (adjust with your actual database details)
            connectionString = "Data Source=.;Initial Catalog=ISAD;Integrated Security=true;";
        }
        public SqlConnection Connection
        {
            get
            {
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    connection = new SqlConnection(connectionString);
                }
                return connection;
            }
        }

        public void OpenConnection()
        {
            try
            {
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
            }
        }


        public void CloseConnection()
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Connection closed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing connection: {ex.Message}");
            }
        }

        public void InsertData(string query)
        {
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        public void ReadData(string query)
        {
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the table has a column named 'ColumnName'
                            Console.WriteLine(reader["ColumnName"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
