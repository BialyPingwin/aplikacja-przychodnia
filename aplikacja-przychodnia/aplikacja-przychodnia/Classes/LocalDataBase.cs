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
        public UserClass login(string login, string password)
        {
            foreach (UserClass item in listOfUsers)
            {
                if (login == item.login)
                {
                    if (password == item.password)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        

        public void ChangePassword(string login, string newPassword)
        {
            foreach (UserClass item in listOfUsers)
            {
                if (login == item.login)
                {
                    item.password = newPassword;
                    item.pendingPasswordChage = false;
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
            return BinarySerializerWithCipher.Deserialize<LocalDataBase>("LocalDataBase.dat");
        }

        public void Save()
        {
            BinarySerializerWithCipher.Serialize("LocalDataBase.dat", this);
        }

        public List<UserClass> ReturnList()
        {
            return listOfUsers;
        }

        public void ResetUserPassword(string login)
        {
            foreach (UserClass item in listOfUsers)
            {
                if (login == item.login)
                {
                    item.password = "hasło";
                    item.ResetPassword(); 
                }
            }
        }
    }
}
