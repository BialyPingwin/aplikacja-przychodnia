using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    
    [Serializable]
    class Reporter
    {
        
        private List<Report> lisOfReports = new List<Report>();

        public static void RaportSickLeaveSendingPage(User user, bool isSent)
        {
            AddRaport(user.ReturnName(),"Wysyłanie Zwolnienia", isSent);
        }

        public static void RaportSickLeaveResending(bool isSent)
        {
            AddRaport("Aplikacja","Ponowne wysyłanie Zwolnienia", isSent);
        }

        private static void AddRaport(string doctor, string action, bool isSent)
        {
            Reporter tmpRepo = Reporter.Load();
            tmpRepo.lisOfReports.Add(Report.NewReport(doctor, action, isSent));
            tmpRepo.Save();
        }

        private void Save()
        {
            BinarySerializerWithCipher.Serialize("AppData1.dat", this);
        }

        public static Reporter Load()
        {
            Reporter tmp = (Reporter)BinarySerializerWithCipher.Deserialize<Reporter>("AppData1.dat");
            if (tmp!= null)
            {
                return tmp;
            }
            else
            {
                return new Reporter();
            }
        }

        public List<Report> ReturnList()
        {
            return lisOfReports;
        }

    }
}
