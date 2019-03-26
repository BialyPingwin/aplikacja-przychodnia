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





namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SickLeaveSchemePage.xaml
    /// </summary>
    public partial class SickLeaveSchemePage : Page
    {
        public SickLeaveSchemePage()
        {
            InitializeComponent();
        }

        private void PDFbutton_Click(object sender, RoutedEventArgs e)
        {
            Classes.SickLeaveClass sickLeaveClass = new Classes.SickLeaveClass(this.Input_PatientFirstNameBox.Text, this.Input_PatientLastNameBox.Text,
                    this.Input_SickLeaveTypeList.Text, this.Input_PatientGenderList.Text, this.PESELBox.Text, Convert.ToDateTime(this.Input_DateFromPicker.Text), Convert.ToDateTime(this.Input_DateToPicker.Text));

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";
            

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.Center);

            // Save the document...
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

    }
}
