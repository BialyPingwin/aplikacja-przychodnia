using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia
{
    [Serializable]
    public class LocalDataBase
    {
        private List<UserClass> listOfDoctors = new List<UserClass>();

        public void Add(UserClass doctor)
        {
            listOfDoctors.Add(doctor);
        }
        public void Remove(UserClass doctor)
        {
            listOfDoctors.Remove(doctor);
        }
        // metoda do sprawdzenia czy można sie zalogowac
        public bool login(string login, string password)
        {
            foreach (UserClass item in listOfDoctors)
            {
                if (login == item.login)
                {
                    if (password == item.password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ChangePassword(string login, string newPassword)
        {
            foreach (UserClass item in listOfDoctors)
            {
                if (login == item.login)
                {
                    item.password = newPassword;
                }
            }
           
        }

        public bool IsLoginFree(string login)
        {
            foreach (UserClass item in listOfDoctors)
            {
                if (login == item.login)
                {
                    return false;
                }
            }
            return true;
        }

        public static LocalDataBase Initialize()
        {
            LocalDataBase db = new LocalDataBase();
            
            db = BinarySerializer<LocalDataBase>.Deserialize("UsersLocal.dat"); // deserializacja bazy lekarzy

            return db;
        }

        public void Save()
        {
            BinarySerializer<LocalDataBase>.Serialize("UsersLocal.dat", this);
        }

        public List<UserClass> ReturnList()
        {
            return listOfDoctors;
        }
    }
}
