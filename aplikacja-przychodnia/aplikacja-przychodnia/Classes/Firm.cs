using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    [Serializable]
    public class Firm
    {
        private string _NIP;
        public string NIP
        {
            get
            {
                return _NIP;
            }
            set
            {
                _NIP = value;
            }
        }

        private string _FirmName;
        public string FirmName
        {
            get
            {
                return _FirmName;
            }
            set
            {
                _FirmName = value;
            }
        }

        private string _IP;
        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
            }
        }

        private string _Port;
        public string Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        private string _InitialCatalog;
        public string InitialCatalog
        {
            get
            {
                return _InitialCatalog;
            }
            set
            {
                _InitialCatalog = value;
            }
        }

        private string _UserInfo;
        public string UserInfo
        {
            get
            {
                return _UserInfo;
            }
            set
            {
                _UserInfo = value;
            }
        }

        private string _PasswordInfo;
        public string PasswordInfo
        {
            get
            {
                return _PasswordInfo;
            }
            set
            {
                _PasswordInfo = value;
            }
        }

        public string ReturnConnectionInfo()
        {
            return @"Server=" + IP + "," + Port + ";Initial Catalog=" + InitialCatalog + "; Persist Security Info = False; User ID = " + UserInfo + "; Password =" + PasswordInfo + "; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
        }
    }
}
