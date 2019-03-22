﻿using System;
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
        public List<DoctorClass> listOfDoctors = new List<DoctorClass>();

        public void Add(DoctorClass doctor)
        {
            listOfDoctors.Add(doctor);
        }
        public void Remove(DoctorClass doctor)
        {
            listOfDoctors.Remove(doctor);
        }
        // metoda do sprawdzenia czy można sie zalogowac
        public bool login(string login, string password)
        {
            foreach (DoctorClass item in listOfDoctors)
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
    }
}
