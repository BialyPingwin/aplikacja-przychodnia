using System.Data;
using System;


namespace aplikacja_przychodnia
{
    [Serializable]
    public class Patient: BaseNotifyPropertyChanged
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

        public string Name          { get => name; set => SetField(ref name, value); }
        public string Surname       { get => surname; set => SetField(ref surname, value); }
        public long _PESEL          { get => PESEL; set => SetField(ref PESEL, value); }
        public string DateOfBirth   { get => dateOfBirth; set => SetField(ref dateOfBirth, value); }
        public string Gender        { get => gender; set => SetField(ref gender, value); }
        public long _NIP            { get => NIP; set => SetField(ref NIP, value); }
        public string PostCode      { get => postCode; set => SetField(ref postCode, value); }
        public string City          { get => city; set => SetField(ref city, value); }
        public string Street        { get => street; set => SetField(ref street, value); }
        public int HouseNumber      { get => houseNumber; set => SetField(ref houseNumber, value); }


        /// <summary>
        /// Konstruktor klasy SickLeave zawierający parametr datarow
        /// </summary>
        /// <param name="datarow">Parametr przechowujący wiersz danych z bazy danych którego dane odpowiadają danym pacjenta.</param>
        /// 
        public Patient(DataRow datarow)
        {
            name = datarow["Imie"].ToString();
            surname = datarow["Nazwisko"].ToString();
            PESEL = (long)datarow["Numer_PESEL"];
            string PESELAsString = PESEL.ToString();
            dateOfBirth = $"{PESELAsString[4]}{PESELAsString[5]}-{PESELAsString[2]}{PESELAsString[3]}-19{PESELAsString[0]}{PESELAsString[1]}";
            gender = datarow["Plec"].ToString();
            NIP = (long)datarow["NIP"];
            city = datarow["Miejsce_Zamieszkania"].ToString();
            street = datarow["Ulica"].ToString();
            houseNumber = (int)datarow["Numer_Domu"];
        }
    }
}
