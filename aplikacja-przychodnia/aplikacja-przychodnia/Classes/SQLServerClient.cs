using System.Data;
using System.Data.SqlClient;


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

        public DataRow GetPersonalData(long PESEL)
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(connectionString.ConnectionString))
            using (var da = new SqlDataAdapter($"select * from myTable where PESEL = {PESEL}", con))
                da.Fill(table);

            return table.Rows[0];
        }

        public static Patient GetPatient(long PESEL)
        {
            SQLServerClient client = new SQLServerClient(@"Server=tcp:io-2019.database.windows.net,1433;Initial Catalog=IO_patientsList;
                                                        Persist Security Info=False;User ID=przychodnia; Password=zwolnienie_123;
                                                        MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new Patient(client.GetPersonalData(PESEL));
        }
    }
}
