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

        /// <summary>
        /// Konstruktor strony wypełnienia zwolnienia lekarskiego.
        /// </summary>
        /// <param name="patient">Pacjent dla którego ma zostać wypisane zwolnienie.</param>
        public SickLeaveSchemePage(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            DataContext = patient;
            if (patient.Gender == "Mężczyzna")
            {
                this.Input_PatientGenderList.Text = "Mężczyzna";
            }
            else if (patient.Gender == "Kobieta")
            {
                this.Input_PatientGenderList.Text = "Kobieta";
            }

            if (Input_PESELBox != null)
            {
                Input_PESELBox.IsEnabled = false;
            }
            if (Input_NIPBox != null)
            {
                Input_NIPBox.IsEnabled = false;
            }
            if (Input_PatientFirstNameBox != null)
            {
                Input_PatientFirstNameBox.IsEnabled = false;
            }
            if (Input_PatientLastNameBox != null)
            {
                Input_PatientLastNameBox.IsEnabled = false;
            }
            if (Input_PatientGenderList != null)
            {
                Input_PatientGenderList.IsEnabled = false;
            }
            if (Input_AddressBox != null)
            {
                Input_AddressBox.IsEnabled = false;
            }
        }

        //private void PDFbutton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (CheckDataCorrectness())
        //    {
        //        if (sickLeaveClass == null)
        //            sickLeaveClass = new Classes.SickLeave(patient, this.Input_SickLeaveTypeList.Text, this.Input_SymptomsBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));

        //        //Tworzenie dokumentu PDF

        //        // Create a MigraDoc document
        //        Document document = Classes.MigraDocF.MigraDoc.CreateDocument(sickLeaveClass);

        //        //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
        //        MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

        //        PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
        //        renderer.Document = document;

        //        renderer.RenderDocument();

        //        // Save the document...
        //        string filename = "HelloMigraDoc.pdf";
        //        renderer.PdfDocument.Save(filename);
        //        // ...and start a viewer.
        //        Process.Start(filename);
        //    }
        //}

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorMenu());
        }

        //private void SendToDataBase(object sender, RoutedEventArgs e)
        //{
        //    if (CheckDataCorrectness())
        //    {
        //        if (!sickLeaveWasSent)
        //        {
        //            if (sickLeaveClass == null)
        //                sickLeaveClass = new Classes.SickLeave(patient, this.Input_SickLeaveTypeList.Text, this.Input_SymptomsBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));

        //            string connectionString = FirmLocalDataBase.Initialize().FindFirmConnectionByNIP(patient._NIP.ToString());
        //            if (SickLeaveSender.SendToSQLServer(sickLeaveClass, connectionString))
        //                MessageBox.Show("Zwolnienie zostało poprawnie wysłane");
        //            sickLeaveWasSent = true;
        //        }
        //        else
        //        {
        //            Output_Error.Text = "Zwolnienie już zostało wysłane";
        //        }
        //    }
        //}

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
            Input_SickLeaveTypeList.Text == "" || Input_PatientGenderList.Text == "" || Input_PESELBox.Text == "" || Input_DateFromPicker.Text == "" || Input_DateToPicker.Text == "")
            {
                Output_Error.Text = "Pola nie mogą być puste";
                return false;
            }
            else
            {
                Output_Error.Text = "";
            }

            if (DateTime.Compare(Convert.ToDateTime(Input_DateFromPicker.Text), Convert.ToDateTime(Input_DateToPicker.Text)) >= 0
                || DateTime.Compare(DateTime.Now.Date, Convert.ToDateTime(Input_DateFromPicker.Text)) > 0)
            {
                Output_Error.Text = "Podano nieprawidłowy\nzakres czasu";
                return false;
            }
            return true;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDataCorrectness())
            {
                if (sickLeaveClass == null)
                {
                    sickLeaveClass = new Classes.SickLeave(patient, this.Input_SickLeaveTypeList.Text, this.Input_SymptomsBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));
                }

                NavigationService.Navigate(new SickLeaveSendingPage(sickLeaveClass));

            }
        }
    }
}