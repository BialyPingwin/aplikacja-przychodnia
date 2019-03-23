using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia
{
    [Serializable]
    public class UserClass
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
        public UserClass(string name, string surname, string login, string password)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
        }
    }
}
