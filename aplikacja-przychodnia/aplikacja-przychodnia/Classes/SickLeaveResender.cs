using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{
    [Serializable]
    public class SickLeaveResender
    {
        private Queue<SickLeave> toResend = new Queue<SickLeave>();

        public void TrySending()
        {


            int numberToTry = toResend.Count;
            for (int i = 0; i < numberToTry; i++)
            {

                
                SickLeave toSend = toResend.Dequeue();
                string connectionString = FirmLocalDataBase.Initialize().FindFirmConnectionByNIP(toSend.Patient._NIP.ToString());

                bool outcome = SickLeaveSender.SendToSQLServer(toSend, connectionString);
                if (!outcome)
                {
                    toResend.Enqueue(toSend);
                }

                Reporter.RaportSickLeaveResending(outcome);

            }

            Save();
        }

        public static SickLeaveResender Load()
        {
            SickLeaveResender tmp = (SickLeaveResender)BinarySerializerWithCipher.Deserialize<SickLeaveResender>("AppData2.dat");
            if (tmp != null)
            {
                return tmp;
            }
            else
            {
                return new SickLeaveResender();
            }
        }

        private void Save()
        {
            BinarySerializerWithCipher.Serialize<SickLeaveResender>("AppData2.dat", this);
        }

        public static void AddToResend(SickLeave sickLeave)
        {
            SickLeaveResender tmp = SickLeaveResender.Load();

            tmp.toResend.Enqueue(sickLeave);
            tmp.Save();
        }
    }
}
