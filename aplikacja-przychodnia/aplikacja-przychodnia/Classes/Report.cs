using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    [Serializable]
    class Report
    {
        private string _doctor;
        public string Doctor
        {
            get { return _doctor; }
        }

        private string _action;
        public string Action
        {
            get { return _action; }
        }

        private bool _isSent;
        public string isSent
        {
            get { if (_isSent == true) { return "Wysłano"; } else { return "Błąd"; } }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
        }

        private Report(string doctor, string action, bool isSent)
        {
            _doctor = doctor;
            _action = action;
            _isSent = isSent;
            _date = DateTime.Now.ToString(); ;
        }

        static public Report NewReport(string doctor, string action, bool isSent)
        {
            return new Report(doctor, action, isSent);
        }

    }
}
