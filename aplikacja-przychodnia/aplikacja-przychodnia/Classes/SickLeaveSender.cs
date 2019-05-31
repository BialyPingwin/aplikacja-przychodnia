using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace aplikacja_przychodnia.Classes
{
    /// <summary>
    /// Klasa odpowiedzialna za wysyłanie zwolnienia do bazy danych
    /// </summary>
    static class SickLeaveSender
    {
        /// <summary>
        /// Metoda wysyła zwolnienie do bazy danych w postaci tekstowej (Zwolnienie jest serializowane do JSON'a)
        /// </summary>
        /// <param name="sickLeave">Zwolnienie lekarskie, które ma być wysłane do bazy danych</param>
        /// <param name="connectionString">Connection string, czyli dane z informacjami o bazie danych do której ma zostać wysłane zwolnienie</param>
        /// <returns>'true' -> jeśli zwolnienie zostało poprawnie wysłane
        ///          'false' -> jeśli zwolnienie nie zostało poprawnie wysłane
        ///</returns>
        public static bool SendToSQLServer(SickLeave sickLeave, string connectionString)
        {
            string sickLeaveAsText = sickLeave.ConvertToJSONString();

            string queryString = $@"insert into Zwolnienia (Zwolnienie, Numer_PESEL)
                                    values('{sickLeaveAsText}', {sickLeave.Patient._PESEL})
                                   ";

            int countOfAffectedRows;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    countOfAffectedRows = command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Wystąpił błąd");
                    return false;
                    
                }
                finally
                {
                    connection?.Close();
                }
            }
            return countOfAffectedRows == 1;
        }
    }
}
