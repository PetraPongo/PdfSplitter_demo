using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using PdfSharp.Pdf.IO;

namespace PDFSplitter.Classes
{
    class PDFSplitterBase
    {
        protected string InputFilePath;
        protected string OutputDirectory { get; set; }
        protected PdfDocument PdfDocument { get; set; }
        public int pageCount { get; set; }

        public int pagesProcessed {  get; set; }

        public PDFSplitterBase(string inputfilepath)
        {
            InputFilePath = inputfilepath;
            OutputDirectory = CreateOutputDirectory();
            PdfDocument = PdfReader.Open(inputfilepath, PdfDocumentOpenMode.Import);
            pageCount = PdfDocument.PageCount;
            pagesProcessed = 0;
        }

        private string CreateOutputDirectory()
        {
            //Külön mappa létrehozása a feldolgozott PDF fileoknak

            string folderName = DateTime.Now.ToString("yyyy.MM.dd") + " darabolas";
            string newdirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(InputFilePath) ?? string.Empty, folderName);

            // Ha a mappa nem létezik, akkor létrehozom
            if (!Directory.Exists(newdirectory))
            {
                Directory.CreateDirectory(newdirectory);
            }

            //Almappa létrehozása
            int subindex = 1;
            string newsubdirectory = System.IO.Path.Combine(newdirectory, $"{subindex}");

            // Ellenőrizzük, hogy létezik-e már a számozott mappa, és növeljük az indexet, ha kell
            while (Directory.Exists(newsubdirectory))
            {
                subindex++;
                newsubdirectory = System.IO.Path.Combine(newdirectory, $"{subindex}");
            }

            // Létrehozzuk az új mappát, ha nem létezik
            Directory.CreateDirectory(newsubdirectory);
            return newsubdirectory;
        }

        public void ProcessPDF()
        {
            if (pageCount  <= 1)
            {
                throw new InvalidOperationException("A PDF fájl nem tartalmaz elég oldalt a feldaraboláshoz. Kérem, válasszon egy legalább 2 oldalas fájlt.");
            }

            for(int i = 0; i < pageCount; i++)
            {
                string fileName = GetFileNameForPage(i);
                SavePageAsPDF(i, fileName);

                pagesProcessed++;

            }

        }

        private void SavePageAsPDF(int pageIndex, string fileName)
        {
            PdfDocument newPdfDocument = new PdfDocument();
            newPdfDocument.AddPage(PdfDocument.Pages[pageIndex]);
            string outputFilePath = Path.Combine(OutputDirectory, fileName);
            newPdfDocument.Save(outputFilePath);
            newPdfDocument.Close();
        }

        // absztarkt metódus konkrét megvalósítást a gyerekosztályoknak kell megvalósítani
        //fájlnevek megadásához kell
        protected virtual string GetFileNameForPage(int pageIndex)
        {
            return $"{pageIndex + 1}_oldal.pdf";
        }

    }
}
