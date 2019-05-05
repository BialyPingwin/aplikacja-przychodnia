using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Collections;

namespace aplikacja_przychodnia 
{
    class BinarySerializerWithCipher 
    {
        public static void Serialize<T>(string filePath, T obj)
        {
            if (obj != null)
            {
                byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; //probowalam dodac opcje z mozliwoscia 
                                                         //zmiany hasla ale mi sie nie udalo wiec chwilowo zostawiam
                                                         //w takiej formie (strzelam ze i tak nam to wystarczy)
                byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using (var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(cryptoStream, obj);
                }
            }
        }

        public static T Deserialize<T>(string filePath) 
        {
            T temp = default(T);
            if (File.Exists(filePath))
            {
                byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 };
                byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        return (T)formatter.Deserialize(cryptoStream);
                    }
                    catch
                    {
                        return default(T);
                    }
                }
            }
            return temp;
        }      
    }
}
