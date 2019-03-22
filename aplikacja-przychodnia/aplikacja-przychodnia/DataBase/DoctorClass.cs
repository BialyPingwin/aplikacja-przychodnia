using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia
{
    [Serializable]
    public class DoctorClass
    {
        string name;
        string surname;
        

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
        public DoctorClass(string name, string surname, string login, string password)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
        }
    }
}
