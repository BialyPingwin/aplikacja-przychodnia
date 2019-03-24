using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    enum SLType { L4, L10};
    enum Gender { male, female};

    [Serializable]
    class SickLeaveClass
    {
        private string _firstName;
        private string _lastName;
        private SLType _sickLeaveType;
        private Gender _gender;
        private int _pESEL;
        private DateTime _dateFrom;
        private DateTime _dateTo;

        public SickLeaveClass(string firstName, string lastName, SLType sickLeaveType, Gender gender, int pESEL, DateTime dateFrom, DateTime dateTo)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sickLeaveType = sickLeaveType;
            this.gender = gender;
            this.pESEL = pESEL;
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

        public SLType sickLeaveType
        {
            get { return _sickLeaveType; }
            set { _sickLeaveType = value; }
        }

        public Gender gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int pESEL
        {
            get { return _pESEL; }
            set { _pESEL = value; }
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
