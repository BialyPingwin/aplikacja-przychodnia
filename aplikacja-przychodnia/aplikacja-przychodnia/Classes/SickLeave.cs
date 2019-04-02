using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    /// <summary>
    /// Klasa SickLeave zawiera informacje o wystawianym zwolnieniu.
    /// </summary>
    [Serializable]
    public class SickLeave
    {
        private string _firstName;
        private string _lastName;
        private string _sickLeaveType;
        private string _gender;
        private string _pESEL;
        private DateTime _dateFrom;
        private DateTime _dateTo;

        /// <summary>
        /// Konstruktor klasy SickLeave zawierający parametry firstName, lastName, sickLeaveType, gender, pESEL, dateFrom, dateTo.
        /// </summary>
        /// <param name="firstName">Parametr przechowujący imię pacjenta.</param>
        /// <param name="lastName">Parametr przechowujący nazwisko pacjenta.</param>
        /// <param name="sickLeaveType">Parametr przechowujący typ wystawianego zwolnienia.</param>
        /// <param name="gender">Parametr przechowujący płeć pacjenta.</param>
        /// <param name="pESEL">Parametr przechowujący numer PESEL pacjenta.</param>
        /// <param name="dateFrom">Parametr przechowujący datę, od której obowiązuje zwolnienie.</param>
        /// <param name="dateTo">Parametr przechowujący datę, do której obowiązuje zwolnienie.</param>  
        public SickLeave(string firstName, string lastName, string sickLeaveType, string gender, string pESEL, DateTime dateFrom, DateTime dateTo)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sickLeaveType = sickLeaveType;
            this.gender = gender;
            this.pESEL = pESEL;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _firstName oraz zmiany tej wartości.
        /// </summary>
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _lastName oraz zmiany tej wartości.
        /// </summary>
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _sickLeaveType oraz zmiany tej wartości.
        /// </summary>
        public string sickLeaveType
        {
            get { return _sickLeaveType; }
            set { _sickLeaveType = value; }
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _gender oraz zmiany tej wartości.
        /// </summary>
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _pESEL oraz zmiany tej wartości.
        /// </summary>
        public string pESEL
        {
            get { return _pESEL; }
            set { _pESEL = value; }
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _dateFrom oraz zmiany tej wartości.
        /// </summary>
        public DateTime dateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        /// <summary>
        /// Właściwość firstName pozwalająca na pobranie wartości parametru _dateTo oraz zmiany tej wartości.
        /// </summary>
        public DateTime dateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }
    }
}
