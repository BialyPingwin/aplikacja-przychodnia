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

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SickLeaveSchemePage.xaml
    /// </summary>
    public partial class SickLeaveSchemePage : Page
    {
        Patient patient;

        public SickLeaveSchemePage(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            DataContext = patient;
            if (patient.Gender == "Male")
            {
                this.Input_PatientGenderList.Text = "Mężczyzna";
            }
            else if ( patient.Gender == "Female")
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
        
        private void PDFbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Input_PatientFirstNameBox.Text == "" || Input_PatientLastNameBox.Text == "" ||
                    Input_SickLeaveTypeList.Text == "" || Input_PatientGenderList.Text == "" || Input_PESELBox.Text == "" || Input_DateFromPicker.Text == "" || Input_DateToPicker.Text == "")
            {
                
                Output_Error.Text = "Pola nie mogą być puste";
                return;

               
            }
            else
            {
                Output_Error.Text = "";
            }

            if (DateTime.Compare(Convert.ToDateTime(Input_DateFromPicker.Text), Convert.ToDateTime(Input_DateToPicker.Text))>=0
                || DateTime.Compare(DateTime.Now.Date, Convert.ToDateTime(Input_DateFromPicker.Text))>0)
            {
                Output_Error.Text = "Podano nieprawidłowy\nzakres czasu";
                return;
            }

            Classes.SickLeave sickLeaveClass = new Classes.SickLeave(this.Input_PatientFirstNameBox.Text, this.Input_PatientLastNameBox.Text,
                    this.Input_SickLeaveTypeList.Text, this.Input_PatientGenderList.Text, this.Input_PESELBox.Text,this.Input_SymptomsBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));

            //Tworzenie dokumenty PDF

            // Create a MigraDoc document
            Document document = Classes.MigraDocF.MigraDocClass.CreateDocument(sickLeaveClass);

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            string filename = "HelloMigraDoc.pdf";
            renderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);


        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorMenu());

        }
    }
}