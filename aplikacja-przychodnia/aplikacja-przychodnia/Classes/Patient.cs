using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    class Patient: INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private long PESEL;
        private string dateOfBirth;
        private string gender;
        private long NIP;
        private string postCode;
        private string city;
        private string street;
        private int houseNumber;

        public long _PESEL;
        public string DateOfBirth;
        public string Gender;
        public long _NIP;
        public string PostCode;
        public string City;
        public string Street;
        public int HouseNumber;



        public Patient(DataRow dr)
        {
            name = dr["NAME"].ToString();
            surname = dr["SURNAME"].ToString();
            PESEL = (long)dr["PESEL"];
            dateOfBirth = dr["DATE_OF_BIRTH"].ToString();
            gender = dr["GENDER"].ToString();
            NIP = (long)dr["NIP"];
            city = dr["CITY"].ToString();
            street = dr["STREET"].ToString();
            houseNumber = (int)dr["HOUSE_NUMBER"];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetValue<T>(T field, T value, T property)
        {
            field = value;
            OnPropertyChanged(nameof(property));
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
