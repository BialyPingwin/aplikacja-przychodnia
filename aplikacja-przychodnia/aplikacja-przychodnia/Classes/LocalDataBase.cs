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
        private List<UserClass> listOfUsers = new List<UserClass>();

        public void Add(UserClass user)
        {
            listOfUsers.Add(user);
        }
        public void Remove(UserClass user)
        {
            listOfUsers.Remove(user);
        }
        // metoda do sprawdzenia czy można sie zalogowac
        public bool Login(string login, string password)
        {
            foreach (UserClass item in listOfUsers)
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
            foreach (UserClass item in listOfUsers)
            {
                if (login == item.login)
                {
                    item.password = newPassword;
                }
            }
           
        }

        public bool IsLoginFree(string login)
        {
            foreach (UserClass item in listOfUsers)
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
            return (LocalDataBase)BinarySerializerWithCipher.Deserialize<LocalDataBase>("UsersLocal.dat");        
        }
        
        public void Save()
        {
            BinarySerializer<LocalDataBase>.Serialize("UsersLocal.dat", this);
        }

        public List<UserClass> ReturnList()
        {
            return listOfUsers;
        }
    }
}
