using System;
using System.Web.Script.Serialization;

namespace aplikacja_przychodnia.Classes
{

    /// <summary>

    /// Klasa SickLeave zawiera informacje o wystawianym zwolnieniu.

    /// </summary>
    [Serializable]
    public class SickLeave
    {

        // <summary>
        /// Właściwość Patient zawiera informacje o pacjencie
        /// </summary>
        public Patient Patient { get; set; }

        // <summary>
        /// Właściwość SickLeaveType zawiera informację o typie zwolnienia lekarskiego
        /// </summary>
        public string SickLeaveType { get; set; }

        /// <summary>
        /// Właściwość StartDate zawiera informację o dacie rozpoczęcia zwolnienia
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Właściwość EndDate zawiera informację o dacie zakończenia zwolnienia
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Właściwość Symptoms zawiera informację o dacie objawach choroby
        /// </summary>
        public string Symptoms { get; set; }

        public SickLeave(Patient patient, string sickLeaveType, string symptoms, DateTime startDate, DateTime endDate)
        {
            Patient = patient;
            SickLeaveType = sickLeaveType;
            StartDate = startDate;
            EndDate = endDate;
            Symptoms = symptoms;
        }

        public SickLeave(string JSONString)
        {
            SickLeave sickLeave = new JavaScriptSerializer().Deserialize(JSONString, typeof(SickLeave)) as SickLeave;
            Patient = sickLeave.Patient;
            SickLeaveType = sickLeave.SickLeaveType;
            StartDate = sickLeave.StartDate;
            EndDate = sickLeave.EndDate;
            Symptoms = sickLeave.Symptoms;
        }

        public string ConvertToJSONString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}
