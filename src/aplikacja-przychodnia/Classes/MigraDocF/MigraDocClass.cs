﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;

namespace aplikacja_przychodnia.Classes.MigraDocF
{
    public class MigraDoc
    {
        /// <summary>
        /// Tworzy dokument 
        /// </summary>
        /// <param name="sickLeave">Klasa SickLeave przechowująca aktualnie wystawiane zwolnienie</param>
        /// <returns>Zwraca dokument</returns>
        public static Document CreateDocument(SickLeave sickLeave)
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "Zwolnienie lekarskie";
            document.Info.Author = MainWindow.ReturnCurrentUser().ReturnName();

            DefineStyles(document);

            DefineContentSection(document);

            DefineTables(document, sickLeave);

            return document;
        }
        /// <summary>
        /// Defines the styles used in the document.
        /// </summary>
        public static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Roboto";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;


            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);
        }

        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        static void DefineContentSection(Document document)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;
            header.AddParagraph("\tStrona 1");

            header = section.Headers.EvenPage;
            header.AddParagraph("Even Page Header");

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }


        /// <summary>
        /// Defines the table
        /// </summary>
        public static void DefineTables(Document document, SickLeave sickLeaveClass)
        {
            //document.LastSection.AddParagraph("Zwolnienie lekarskie", "Heading2");
            Paragraph paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddFormattedText("Zwolnienie lekarskie", "Heading2");
            CreateTable(document, sickLeaveClass);
        }


        /// <summary>
        /// Tworzy tabelki
        /// </summary>
        /// <param name="document"></param>
        /// <param name="sickLeaveClass"></param>
        public static void CreateTable(Document document, SickLeave sickLeaveClass)
        {
            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(5));
            //column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(10));

            Row row = table.AddRow();

            Cell cell = row.Cells[0];
            cell = row.Cells[0];
            cell.AddParagraph("Imię");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.Patient.Name);

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Nazwisko");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.Patient.Surname);

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Pesel");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.Patient._PESEL.ToString());

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Płeć");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.Patient.Gender);

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("NIP");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.Patient._NIP.ToString());

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Miejsce zameldowania");
            cell = row.Cells[1];
            string hauseNumberToAdd = "";
            if (sickLeaveClass.Patient.HouseNumber != 0)
            {
                hauseNumberToAdd = sickLeaveClass.Patient.HouseNumber.ToString();
            }
            cell.AddParagraph($"{sickLeaveClass.Patient.Street} {hauseNumberToAdd} \n{sickLeaveClass.Patient.PostCode} {sickLeaveClass.Patient.City}");

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Typ zwolnienia");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.SickLeaveType);

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Powód zwolnienia (Objawy)");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.Symptoms);

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Zwolniony od");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.StartDate.ToShortDateString());

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Zwolniony do");
            cell = row.Cells[1];
            cell.AddParagraph(sickLeaveClass.EndDate.ToShortDateString());

            document.LastSection.Add(table);
        }

    }
}

