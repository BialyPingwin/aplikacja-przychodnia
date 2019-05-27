using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    /// <summary>
    /// Klasa SickLeaveResender służy do kolejkowania i ponownego wysyłania zwolnień przy najbliższej możliwej okazji
    /// </summary>
    [Serializable]
    public class SickLeaveResender
    {
        /// <summary>
        /// Kolejka przechowująca zwolnienia
        /// </summary>
        private Queue<SickLeave> toResend = new Queue<SickLeave>();

        /// <summary>
        /// Funkcja wykonująca próbę wysłania dla każdego zwolnienia w kolejce 
        /// </summary>
        public void TrySending()
        {


            int numberToTry = toResend.Count;
            for (int i = 0; i < numberToTry; i++)
            {

                
                SickLeave toSend = toResend.Dequeue();
                string connectionString = FirmLocalDataBase.Initialize().FindFirmConnectionByNIP(toSend.Patient._NIP.ToString());

                bool outcome = SickLeaveSender.SendToSQLServer(toSend, connectionString);
                if (!outcome)
                {
                    toResend.Enqueue(toSend);
                }

                Reporter.RaportSickLeaveResending(outcome);

            }

            Save();
        }

        /// <summary>
        /// Statyczna funkcja ładująca kolejkę z pliku
        /// </summary>
        /// <returns>Zwraca nowy SickLeave Resender wczytany z pliku</returns>
        public static SickLeaveResender Load()
        {
            SickLeaveResender tmp = (SickLeaveResender)BinarySerializerWithCipher.Deserialize<SickLeaveResender>("AppData2.dat");
            if (tmp != null)
            {
                return tmp;
            }
            else
            {
                return new SickLeaveResender();
            }
        }

        /// <summary>
        /// Funkcja zapisująca tą klasę do pliku
        /// </summary>
        private void Save()
        {
            BinarySerializerWithCipher.Serialize<SickLeaveResender>("AppData2.dat", this);
        }


        /// <summary>
        /// Funkcja dodająca do kolejki nowe zwolnienie 
        /// </summary>
        /// <param name="sickLeave">Zwolnieniem, które nie zostało poprawnie wysłane i ma być dodane do kolejki</param>
        public static void AddToResend(SickLeave sickLeave)
        {
            SickLeaveResender tmp = SickLeaveResender.Load();

            tmp.toResend.Enqueue(sickLeave);
            tmp.Save();
        }
    }
}
