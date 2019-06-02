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
using System.Threading;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SickLeaveSendingPage.xaml
    /// </summary>
    public partial class SickLeaveSendingPage : Page
    {
        SickLeave sickLeave;

        public SickLeaveSendingPage(SickLeave sickLeave, bool send = true)
        {
            InitializeComponent();
            this.sickLeave = sickLeave;


            User user = MainWindow.ReturnCurrentUser();
            if (send)
            {
                new Thread(() => Send(user)).Start();
            }
            else
            {
                Reporter.AddRaport(user.ReturnName(), "Wystawienie zwolnienia bez wysyłania", null);
                createPDF();
            }

        }

        private void Button_Pdf_Click(object sender, RoutedEventArgs e)
        {

            createPDF();
        }

        private void createPDF()
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
            string filename = RandomPdfName() + ".pdf";
            renderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

        public string RandomPdfName()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 9; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return "PDF_" + builder.ToString().ToLower();
            
        }
        private void Button_DoctorMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorMenu());
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Logout();
        }

        private void Send(User user)
        {
                    

            string connectionString = FirmLocalDataBase.Initialize().FindFirmConnectionByNIP(sickLeave.Patient._NIP.ToString());
            bool outcome = SickLeaveSender.SendToSQLServer(sickLeave, connectionString);
            Reporter.RaportSickLeaveSendingPage(user, outcome);
            if (!outcome)
            {
                SickLeaveResender.AddToResend(sickLeave);
                //MessageBox.Show("Błąd połączenia z bazą");
            }
            else
            {
                //MessageBox.Show("Wysłano Poprawnie");
            }
        }

    }
}
