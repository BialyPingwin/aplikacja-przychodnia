using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia
{
    class SQLServerClient
    {
        SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

        public SQLServerClient(string IPAdressCommaPort, string DatabaseName, string UserID, string Password)
        {
            connectionString.DataSource = IPAdressCommaPort;
            connectionString.InitialCatalog = DatabaseName;
            connectionString.UserID = UserID;
            connectionString.Password = Password;
        }

        public SQLServerClient(string connString)
        {
            connectionString = new SqlConnectionStringBuilder(connString);
        }

        public void ExecuteQuery(string SQLQuery)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            connection = new SqlConnection(connectionString.ConnectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                command.ExecuteNonQuery();              
                command.Dispose();
            }
            catch (Exception ex) { throw; }
            finally { connection?.Close(); }
        }
    }
}
