using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using aplikacja_przychodnia;
using aplikacja_przychodnia.Classes;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SickLeaveSchemePage.xaml
    /// </summary>
    public partial class SickLeaveSchemePage : Page
    {
        Patient patient;
        SickLeave sickLeaveClass = null;
        //bool sickLeaveWasSent = false;

        public SickLeaveSchemePage(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            if (patient._PESEL != 0 && patient._NIP != 0)
            {
                DataContext = patient;

                Input_AddressBox.Text = patient.PostCode + " " + patient.City + " " + patient.Street + " " + patient.HouseNumber.ToString();
            }
            


            if (patient.Gender == "Mężczyzna")
            {
                this.Input_PatientGenderList.Text = "Mężczyzna";
            }
            else if (patient.Gender == "Kobieta")
            {
                this.Input_PatientGenderList.Text = "Kobieta";
            }

            if (Input_PESELBox.Text != "")
            {
                Input_PESELBox.IsEnabled = false;
            }
            if (Input_NIPBox.Text != "")
            {
                Input_NIPBox.IsEnabled = false;
            }
            if (Input_PatientFirstNameBox.Text != "")
            {
                Input_PatientFirstNameBox.IsEnabled = false;
            }
            if (Input_PatientLastNameBox.Text != "")
            {
                Input_PatientLastNameBox.IsEnabled = false;
            }
            if (Input_PatientGenderList.Text != "")
            {
                Input_PatientGenderList.IsEnabled = false;
            }
            if (Input_AddressBox.Text != "")
            {
                Input_AddressBox.IsEnabled = false;
            }
        }

        
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorMenu());
        }

       
        /// <summary>
        /// Metoda sprawdząjaca poprawność wprowadzonych przez użytkownika danych
        /// </summary>
        /// <returns>
        /// Metoda zwraca 'true' jeśli dane zostały wprowadzone poprawnie lub 'false' jeśli wystapiły błędy.
        /// Dodatkowo w przypadku błędnych danych, metoda oknie interfejsu graficznego wyświetla stosowne komunikaty.
        /// </returns>

        private bool CheckDataCorrectness()
        {
            if (Input_PatientFirstNameBox.Text == "" || Input_PatientLastNameBox.Text == "" ||
            Input_SickLeaveTypeList.Text == "" || Input_PatientGenderList.Text == "" || Input_PESELBox.Text == "" || Input_DateFromPicker.Text == "" || Input_DateToPicker.Text == "" || Input_SymptomsBox.Text == "")
            {
                Output_Error.Text = "Pola nie mogą być puste";
                return false;
            }
            else
            {
                Output_Error.Text = "";
            }

            if (!RegClass.CheckPESEL(Input_PESELBox.Text) && !RegClass.CheckNIP(Input_NIPBox.Text))
            {
                Output_Error.Text = "Błędnie wpisany numer NIP lub Pesel";
                return false;
            }
            else
            {
                Output_Error.Text = "";
            }

            if (DateTime.Compare(Convert.ToDateTime(Input_DateFromPicker.Text), Convert.ToDateTime(Input_DateToPicker.Text)) > 0 )
            {
                Output_Error.Text = "Podano nieprawidłowy\nzakres czasu";
                return false;
            }


            
            if ((Convert.ToDateTime(Input_DateFromPicker.Text).Date - DateTime.Now.Date).TotalDays < -3 || (Convert.ToDateTime(Input_DateFromPicker.Text).Date - DateTime.Now.Date).TotalDays > 4)
            {
                Output_Error.Text = "Podano nieprawidłowy\nzakres czasu";
                return false;
            }

            if (DateTime.Compare(Convert.ToDateTime(Input_DateFromPicker.Text), DateTime.Now) < 0)
            {
                if ((Convert.ToDateTime(Input_DateToPicker.Text).Date - DateTime.Now.Date).TotalDays < 0)
                {
                    Output_Error.Text = "Podano nieprawidłowy\nzakres czasu";
                    return false;
                }
            }

            return true;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {

            
            if (CheckDataCorrectness())
            {
                if (patient._PESEL == 0)
                {
                    patient._PESEL = Convert.ToInt64(Input_PESELBox.Text);
                    patient._NIP = Convert.ToInt64(Input_NIPBox.Text);
                    patient.Street = Input_AddressBox.Text;
                    patient.Name = Input_PatientFirstNameBox.Text;
                    patient.Surname = Input_PatientLastNameBox.Text;
                    patient.Gender = Input_PatientGenderList.Text;
                    if (sickLeaveClass == null)
                    {
                        sickLeaveClass = new Classes.SickLeave(patient, this.Input_SickLeaveTypeList.Text, this.Input_SymptomsBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));
                    }

                    NavigationService.Navigate(new SickLeaveSendingPage(sickLeaveClass, false));

                }
                else
                {
                    if (sickLeaveClass == null)
                    {
                        sickLeaveClass = new Classes.SickLeave(patient, this.Input_SickLeaveTypeList.Text, this.Input_SymptomsBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));
                    }

                    NavigationService.Navigate(new SickLeaveSendingPage(sickLeaveClass, true));
                }

            }
        }
    }
}