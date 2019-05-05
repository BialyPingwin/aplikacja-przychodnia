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
    public class UserLocalDataBase
    {
        private List<User> listOfUsers = new List<User>();

        public void Add(User user)
        {
            listOfUsers.Add(user);
        }
        public void Remove(User user)
        {
            listOfUsers.Remove(user);
        }
        // metoda do sprawdzenia czy można sie zalogowac

        public User login(string login, string password)
        {
            foreach (User item in listOfUsers)
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
            foreach (User item in listOfUsers)
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
            foreach (User item in listOfUsers)
            {
                if (login == item.login)
                {
                    return false;
                }
            }
            return true;
        }

        public static UserLocalDataBase Initialize()
        {
            return (UserLocalDataBase)BinarySerializerWithCipher.Deserialize<UserLocalDataBase>("UsersLocal.dat");        
        }
        
        public void Save()
        {
            BinarySerializerWithCipher.Serialize("UsersLocal.dat", this);
        }

        public List<User> ReturnList()
        {
            return listOfUsers;
        }

        public void ResetUserPassword(string login)
        {
            foreach (User item in listOfUsers)
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
