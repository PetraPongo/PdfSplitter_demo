using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFSplitter.Classes
{
    class PdfFile
    {
        private string fileName;
        private string filePath;

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Fájl nevét kötelező megadni!");
                }

                fileName = value;
            }
        }
        public string FilePath
        {
            get { return filePath; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Fájl elérési útvonala, nem lehet null!");
                }

                filePath = value;
            }
        }

        public PdfFile(string fileName, string filePath)
        {
            this.FileName = fileName;
            this.FilePath = filePath;
        }
    }
}
