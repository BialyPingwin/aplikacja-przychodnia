using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{

    /// <summary>
    /// Lokalna baza danych podłączonych firm
    /// </summary>
    [Serializable]
    public class FirmLocalDataBase
    {
        /// <summary>
        /// Lista zapisanych firm
        /// </summary>
        private List<Firm> listOfFirms = new List<Firm>();

        /// <summary>
        /// Funkcja dodająca nową firmę
        /// </summary>
        /// <param name="firm">Firma, która powinna zostać dodana</param>
        public void Add(Firm firm)
        {
            listOfFirms.Add(firm);
        }

        /// <summary>
        /// Firma do usunięca
        /// </summary>
        /// <param name="firm">Firma, która ma zostać usunię</param>
        public void Remove(Firm firm)
        {
            listOfFirms.Remove(firm);
        }
        // metoda do sprawdzenia czy można sie zalogowac

        
        /// <summary>
        /// Metoda statyczna wczytująca bazę danych z pliku
        /// </summary>
        /// <returns>Zwraca bazę wczytaną z plików</returns>
        public static FirmLocalDataBase Initialize()
        {
            FirmLocalDataBase dataBase= (FirmLocalDataBase)BinarySerializerWithCipher.Deserialize<FirmLocalDataBase>("FrimsLocal.dat");
            if (dataBase == null)
            {
                return new FirmLocalDataBase();
            }
            else
            {
                return dataBase;
            }
        }

        /// <summary>
        /// Metoda zapisująca klasę do pliku 
        /// </summary>
        public void Save()
        {
            BinarySerializerWithCipher.Serialize("FrimsLocal.dat", this);
        }

        /// <summary>
        /// Metoda zwracająca listę firm
        /// </summary>
        /// <returns>zwraca listę firm</returns>
        public List<Firm> ReturnList()
        {
            return listOfFirms;
        }

        /// <summary>
        /// Metoda szkająca informacji o połączeniu z konkretną firmą po Nipie
        /// </summary>
        /// <param name="NIP">Nip firmy którą chcemy znaleźć</param>
        /// <returns>Zwraca ciąg znaków służacy do połączenia</returns>
        public string FindFirmConnectionByNIP(string NIP)
        {
            foreach(Firm f in listOfFirms)
            {
                if (f.NIP == NIP)
                {
                    return f.ReturnConnectionInfo();
                }
            }

            return null;
        }


        /// <summary>
        /// Metoda szkająca informacji o połączeniu z konkretną firmą po Nipie
        /// </summary>
        /// <param name="name">Nazwa firmy, którą chcemy znaleźć</param>
        /// <returns>Zwraca ciąg znaków służacy do połączenia</returns>
        public string FindFirmConnectionByName(string name)
        {
            foreach (Firm f in listOfFirms)
            {
                if (f.FirmName == name)
                {
                    return f.ReturnConnectionInfo();
                }
            }

            return null;
        }


        /// <summary>
        /// Metoda sprawdzająca czy nie ma już zarejestrowanej firmy o podanym numerze nip
        /// </summary>
        /// <param name="nip">nip który chcemy sprawdzić</param>
        /// <returns>informację w postaci true lub false</returns>
        public bool IsNipAvailable(string nip)
        {
            foreach( Firm f in listOfFirms)
            {
                if (f.NIP == nip)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Metoda sprawdzająca czy nie ma już zarejestrowanej firmy o podanej nazwie
        /// </summary>
        /// <param name="nip">nazwa którą chcemy sprawdzić</param>
        /// <returns>informację w postaci true lub false</returns>
        public bool IsNameAvailable(string name)
        {
            if (name != "")
            {
                foreach (Firm f in listOfFirms)
                {
                    if (f.FirmName == name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
