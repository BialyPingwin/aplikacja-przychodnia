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
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using aplikacja_przychodnia.Classes;
using System.Diagnostics;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SickLeaveSendingPage.xaml
    /// </summary>
    public partial class SickLeaveSendingPage : Page
    {
        SickLeave sickLeave;

        public SickLeaveSendingPage(SickLeave sickLeave)
        {
            InitializeComponent();
            this.sickLeave = sickLeave;

            Loaded += Send;

        }

        private void Button_Pdf_Click(object sender, RoutedEventArgs e)
        {

            //Tworzenie dokumentu PDF

            // Create a MigraDoc document
            Document document = Classes.MigraDocF.MigraDoc.CreateDocument(sickLeave);

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

        private void Button_DoctorMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorMenu());
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Logout();
        }

        private void Send(object sender, EventArgs e)
        {
            string connectionString = FirmLocalDataBase.Initialize().FindFirmConnectionByNIP(sickLeave.Patient._NIP.ToString());
            bool outcome = SickLeaveSender.SendToSQLServer(sickLeave, connectionString);
            Reporter.RaportSickLeaveSendingPage(outcome);
            if (!outcome)
            {
                SickLeaveResender.AddToResend(sickLeave);
                MessageBox.Show("Błąd połączenia z bazą");
            }
            else
            {
                MessageBox.Show("Wysłano Poprawnie");
            }
        }

    }
}
