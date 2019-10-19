using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia
{

    /// <summary>
    /// Klasa User przechowująca użytkownika aplikacji
    /// </summary>
    [Serializable]
    public class User
    {


        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _surname;
        public string surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        private string _login;
        public string login {
            get {
                return _login; }
            set {
                _login = value;
                }
        }
        private string _password;
        public string password {
            get {
                return _password;
            }
            set {
                _password = value;
            }
        }
        private bool _pendingPasswordChage;
        public bool pendingPasswordChage
        {
            get
            {
                return _pendingPasswordChage;
            }
            set
            {
                _pendingPasswordChage = value;
            }
        }

        /// <summary>
        /// Prosty konstruktor aplikacji
        /// </summary>
        /// <param name="name">imie</param>
        /// <param name="surname">nazwisko</param>
        /// <param name="login">login</param>
        /// <param name="password">hasło</param>
        public User(string name, string surname, string login, string password)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
            this.pendingPasswordChage = false;
        }

        /// <summary>
        /// Metoda ustawiająca zmianę hasła przy najbliższym zalogowaniu do aplikacji
        /// </summary>
        public void ResetPassword()
        {
            this.pendingPasswordChage = true;
        }

        /// <summary>
        /// Metoda sprawdzająca czy należy zmienić hasło po zalogowaniu
        /// </summary>
        /// <returns>Zwraca informację w postacji prawda fałsz</returns>
        public bool IsPendingPasswordChange()
        {
            return this.pendingPasswordChage;
        }

        /// <summary>
        /// Metoda zwracjąca imię i nazwisko użytkownika
        /// </summary>
        /// <returns>Zwraca ciąg znaków złożony z imienia i nazwiska oddzielonych spacją</returns>
        public string ReturnName()
        {
            return this.name + " " + this.surname;
        }
    }
}
