using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    /// <summary>
    /// Klasa Report jest raportem z wysyłania, który może przeczytać admiistrator aplikacji
    /// </summary>
    [Serializable]
    class Report
    {
        private string _doctor;
        public string Doctor
        {
            get { return _doctor; }
        }

        private string _action;
        public string Action
        {
            get { return _action; }
        }

        private bool? _isSent;
        public string isSent
        {
            get { if (_isSent == true) { return "Wysłano"; } else if (_isSent == false) { return "Błąd"; } else { return ""; } }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
        }

        /// <summary>
        /// Prosty konstruktor klasy
        /// </summary>
        /// <param name="doctor">Instancja, która powinna byc zapisana w raporcie jako wystawiająca raport(Doktor albo Aplikacja)</param>
        /// <param name="action">Akcja która była powodem raportu</param>
        /// <param name="isSent">Status wysłania, czy się udało czy nie</param>
        private Report(string doctor, string action, bool? isSent)
        {
            _doctor = doctor;
            _action = action;
            _isSent = isSent;
            _date = DateTime.Now.ToString(); ;
        }


        /// <summary>
        /// Metoda statyczna zwracająca nową klasę Report
        /// </summary>
        /// <param name="doctor">Instancja, która pownna byc zapisana w raporcie jako wystawiająca zwolnienie(Doktor albo Aplikacja)</param>
        /// <param name="action">Akcja która była powodem raportu</param>
        /// <param name="isSent">Status wysłania, czy się udało czy nie</param>
        /// <returns>Zwraca nową klasę report</returns>
        static public Report NewReport(string doctor, string action, bool? isSent)
        {
            return new Report(doctor, action, isSent);
        }

    }
}
