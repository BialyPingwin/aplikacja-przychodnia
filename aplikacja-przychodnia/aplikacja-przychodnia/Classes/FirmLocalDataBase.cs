using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    [Serializable]
    public class FirmLocalDataBase
    {
        private List<Firm> listOfFirms = new List<Firm>();

        public void Add(Firm firm)
        {
            listOfFirms.Add(firm);
        }
        public void Remove(Firm firm)
        {
            listOfFirms.Remove(firm);
        }
        // metoda do sprawdzenia czy można sie zalogowac

        

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

        public void Save()
        {
            BinarySerializerWithCipher.Serialize("FrimsLocal.dat", this);
        }

        public List<Firm> ReturnList()
        {
            return listOfFirms;
        }

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
       
    }
}
