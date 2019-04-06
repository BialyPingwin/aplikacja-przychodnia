using System.Data;


namespace aplikacja_przychodnia
{
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
            name = datarow["NAME"].ToString();
            surname = datarow["SURNAME"].ToString();
            PESEL = (long)datarow["PESEL"];
            dateOfBirth = datarow["DATE_OF_BIRTH"].ToString();
            gender = datarow["GENDER"].ToString();
            NIP = (long)datarow["NIP"];
            city = datarow["CITY"].ToString();
            street = datarow["STREET"].ToString();
            houseNumber = (int)datarow["HOUSE_NUMBER"];
        }
    }
}
