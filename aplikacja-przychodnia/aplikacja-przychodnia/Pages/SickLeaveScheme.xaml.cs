using System;
using System.Windows;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Interaction logic for SickLeaveScheme.xaml
    /// </summary>
    public partial class SickLeaveScheme : Window
    {
        public SickLeaveScheme()
        {
            InitializeComponent();
        }


        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow.Logout();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (PESELBox.Text.Length == 11)
                DataContext = SQLServerClient.GetPatient(Convert.ToInt64(PESELBox.Text));
        }

        private void ExportToPDF_Button_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(StartDate.Text), Convert.ToDateTime(EndDate.Text)) >= 0
                   || DateTime.Compare(DateTime.Now.Date, Convert.ToDateTime(EndDate.Text)) > 0)
            {
                MessageBox.Show("Podano nieprawidłowy\nzakres czasu");
                return;
            }

            Classes.SickLeave sickLeaveClass = new Classes.SickLeave((Patient)DataContext, SickLeaveType.Text,
                                                                     Symptoms.Text, Convert.ToDateTime(StartDate.Text), Convert.ToDateTime(StartDate.Text));

            //Tworzenie dokumenty PDF

            // Create a MigraDoc document
            Document document = Classes.MigraDocF.MigraDoc.CreateDocument(sickLeaveClass);

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
    }
}
