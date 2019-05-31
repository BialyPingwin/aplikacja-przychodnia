using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace aplikacja_przychodnia
{
    /// <summary>
    /// Klasa łącząca z bazą danych
    /// </summary>
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

        /// <summary>
        /// Metoda nawiązująca połączenie z bazą danych
        /// </summary>
        /// <param name="connString">ciąg znaków generowany z bazy firm</param>
        public SQLServerClient(string connString)
        {
            connectionString = new SqlConnectionStringBuilder(connString);
        }

        /// <summary>
        /// Metoda zwracająca informację o pacjencie
        /// </summary>
        /// <param name="PESEL">Pesel pacjenta którego chcemy wyciągnąć z bazy</param>
        /// <returns>Zwraca DataRow z którego wczytujemy dane pacjenta</returns>
        public DataRow GetPersonalData(long PESEL)
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(connectionString.ConnectionString))
            using (var da = new SqlDataAdapter($"select * from Pracownicy where Numer_PESEL = {PESEL}", con))
                da.Fill(table);

            return table.Rows[0];
        }

        /// <summary>
        /// Metoda zwracająca informację o pacjencie
        /// </summary>
        /// <param name="PESEL">Pesel pacjenta, którego chcemy wyciągnąć z bazy</param>
        /// <param name="connectionString">Ciąg znaków do połączenia z bazą</param>
        /// <returns></returns>
        public static Patient GetPatient(long PESEL, string connectionString)
        {
            try
            {
                SQLServerClient client = new SQLServerClient(connectionString);
                return new Patient(client.GetPersonalData(PESEL));
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd");
                return null;
            }
        }
    }
}
