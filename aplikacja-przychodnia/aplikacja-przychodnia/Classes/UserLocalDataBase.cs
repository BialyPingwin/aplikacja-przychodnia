using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia
{
    /// <summary>
    /// Klasa UserLocalDatabase przechowująca lokalnych użytkowników
    /// </summary>
    [Serializable]
    public class UserLocalDataBase
    {
        /// <summary>
        /// lista przechowywanych użytkoników 
        /// </summary>
        private List<User> listOfUsers = new List<User>();

        /// <summary>
        /// Metoda dodająca użytkownika 
        /// </summary>
        /// <param name="user">Użytkownik, który powninien zostać dodany</param>
        public void Add(User user)
        {
            listOfUsers.Add(user);
        }

        /// <summary>
        /// Metoda usuwająca użytkownika
        /// </summary>
        /// <param name="user">Użytkownik do usunięcia</param>
        public void Remove(User user)
        {
            listOfUsers.Remove(user);
        }
        // metoda do sprawdzenia czy można sie zalogowac


        /// <summary>
        /// Metoda zwracająca użytkownika jeśli udało mu się zalogować
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">hasło</param>
        /// <returns>Zwraca użytkownika po zalogowaniu</returns>
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
        
        /// <summary>
        /// Metoda zmieniająca hasło konkretnemu użytkownikowi wyszukiwanemu po loginie
        /// </summary>
        /// <param name="login">login uzytkownika do zmiany</param>
        /// <param name="newPassword">nowe hasło</param>
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

        /// <summary>
        /// Funkcja sprawdzająca czy nie ma już takiego loginu
        /// </summary>
        /// <param name="login">login do sprawdzenia</param>
        /// <returns>Zwraca prawda fałsz</returns>
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

        /// <summary>
        /// Statyczna metoda wczytująca bazę danych z pliku
        /// </summary>
        /// <returns>Zwraca nową wczytaną z pliku klasę</returns>
        public static UserLocalDataBase Initialize()
        {
            return (UserLocalDataBase)BinarySerializerWithCipher.Deserialize<UserLocalDataBase>("UsersLocal.dat");        
        }
        
        /// <summary>
        /// Metoda zapisująca tą klasę do pliku
        /// </summary>
        public void Save()
        {
            BinarySerializerWithCipher.Serialize("UsersLocal.dat", this);
        }

        /// <summary>
        /// metoda zwracjąca aktualną listę użytkowników 
        /// </summary>
        /// <returns>Zwraca listę</returns>
        public List<User> ReturnList()
        {
            return listOfUsers;
        }

        /// <summary>
        /// Metoda ustawia reset hasła dla konkretnego użytkownika
        /// </summary>
        /// <param name="login">login użytkownika któremu należy zresetować hasło</param>
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
