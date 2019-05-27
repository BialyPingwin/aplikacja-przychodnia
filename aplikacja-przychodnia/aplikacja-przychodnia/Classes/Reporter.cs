using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    /// <summary>
    /// Klasa przechowująca raporty
    /// </summary>
    [Serializable]
    class Reporter
    {
        /// <summary>
        /// Lista raportów
        /// </summary>
        private List<Report> lisOfReports = new List<Report>();

        /// <summary>
        /// Metoda dodająca raport z logowania użytkownika
        /// </summary>
        /// <param name="user">Użytkownik, który się zalogował</param>
        public static void RaportLogin(User user)
        {
            AddRaport(user.ReturnName(), "Logowanie", null);
        }

        /// <summary>
        /// Metoda dodająca raport z wylogowania użytkownika
        /// </summary>
        /// <param name="user">Użytkownik, który się wylogowuje</param>
        public static void RaportLogout(User user)
        {
            if (user != null)
            {
                AddRaport(user.ReturnName(), "Wylogowanie", null);
            }
        }

        /// <summary>
        /// Metdoa dodająca raport informujący o włączeniu aplikacji
        /// </summary>
        public static void RaportAppStart()
        {
            AddRaport("Aplikacja", "Start", null);

        }

        /// <summary>
        /// Metoda dodająca raport z zamknięcia aplikacji
        /// </summary>
        public static void RaportAppClose()
        {
            AddRaport("Aplikacja", "Zamknięcie", null);
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isSent"></param>
        public static void RaportSickLeaveSendingPage(User user, bool? isSent)
        {
            AddRaport(user.ReturnName(),"Wysyłanie Zwolnienia", isSent);
        }

        public static void RaportSickLeaveResending(bool? isSent)
        {
            AddRaport("Aplikacja","Ponowne wysyłanie Zwolnienia", isSent);
        }

        private static void AddRaport(string doctor, string action, bool? isSent)
        {
            Reporter tmpRepo = Reporter.Load();
            tmpRepo.lisOfReports.Add(Report.NewReport(doctor, action, isSent));
            tmpRepo.Save();
        }

        private void Save()
        {
            BinarySerializerWithCipher.Serialize("AppData1.dat", this);
        }

        public static Reporter Load()
        {
            Reporter tmp = (Reporter)BinarySerializerWithCipher.Deserialize<Reporter>("AppData1.dat");
            if (tmp!= null)
            {
                return tmp;
            }
            else
            {
                return new Reporter();
            }
        }

        public List<Report> ReturnList()
        {
            return lisOfReports;
        }

    }
}
