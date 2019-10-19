using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    /// <summary>
    /// Klasa przechowująca dane o firmie 
    /// </summary>
    [Serializable]
    public class Firm
    {
        /// <summary>
        /// Zmienna przechowująca NIP
        /// </summary>
        private string _NIP;
        public string NIP
        {
            get
            {
                return _NIP;
            }
            set
            {
                _NIP = value;
            }
        }

        /// <summary>
        /// Zmienna przechowująca nazwę firmy
        /// </summary>
        private string _FirmName;
        public string FirmName
        {
            get
            {
                return _FirmName;
            }
            set
            {
                _FirmName = value;
            }
        }

        /// <summary>
        /// Zmienna przechowująca adres ip serwera na którym znajduje się baza danych firmy
        /// </summary>
        private string _IP;
        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
            }
        }

        /// <summary>
        /// port przez który należy się połączyć z bazą danych firmy
        /// </summary>
        private string _Port;
        public string Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        /// <summary>
        /// Katalog początkowy w bazie danych
        /// </summary>
        private string _InitialCatalog;
        public string InitialCatalog
        {
            get
            {
                return _InitialCatalog;
            }
            set
            {
                _InitialCatalog = value;
            }
        }

        /// <summary>
        /// Login do bazy danch
        /// </summary>
        private string _UserInfo;
        public string UserInfo
        {
            get
            {
                return _UserInfo;
            }
            set
            {
                _UserInfo = value;
            }
        }


        /// <summary>
        /// Hasło do bazy danych 
        /// </summary>
        private string _PasswordInfo;
        private string PasswordInfo
        {
            get
            {
                return _PasswordInfo;
            }
            set
            {
                _PasswordInfo = value;
            }
        }


        /// <summary>
        /// Metoda zmieniająca hasło dla danej firmy
        /// </summary>
        /// <param name="password"></param>
        public void SetFirmPassword(string password)
        {
            PasswordInfo = password;
        }


        /// <summary>
        /// Funkcja zwracająca tekst złożony ze wszystkich części klasy, który zostanie wykorzystany do połączenia z bazą
        /// </summary>
        /// <returns>Zwraca ciąg znaków który zostannie wykorzystany do połączenia z bazą danych</returns>
        public string ReturnConnectionInfo()
        {
            return @"Server=" + IP + "," + Port + ";Initial Catalog=" + InitialCatalog + "; Persist Security Info = False; User ID = " + UserInfo + "; Password =" + PasswordInfo + "; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
        }
    }
}
