using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    
    [Serializable]
    public class SickLeave
    {
        private string _firstName;
        private string _lastName;
        private string _sickLeaveType;
        private string _gender;
        private string _pESEL;
        private string _Syptoms;
        private DateTime _dateFrom;
        private DateTime _dateTo;
        

        public SickLeave(string firstName, string lastName, string sickLeaveType, string gender, string pESEL,string Symptoms, DateTime dateFrom, DateTime dateTo)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sickLeaveType = sickLeaveType;
            this.gender = gender;
            this.pESEL = pESEL;
            this.Symptoms = Symptoms;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
        }

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string sickLeaveType
        {
            get { return _sickLeaveType; }
            set { _sickLeaveType = value; }
        }

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string pESEL
        {
            get { return _pESEL; }
            set { _pESEL = value; }
        }

        public string Symptoms
        {
            get { return _Syptoms; }
            set { _Syptoms = value; }
        }

        public DateTime dateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        public DateTime dateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }
    }
}
