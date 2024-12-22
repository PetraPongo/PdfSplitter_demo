using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace PDFSplitter.Classes
{
    class PDFSplitByName : PDFSplitterBase
    {
        // Kulcs-érték párosítás miatt használom ezt, gyorsabban keres ami nagy mennyiségű fájl esetében szükségszerű
        private Dictionary<string, int> nameCount = new Dictionary<string, int>();
        public PDFSplitByName(string inputFilePath) : base(inputFilePath) { }

        protected override string GetFileNameForPage(int pageIndex)
        {
            string pageText = GetPageText(pageIndex);
            string name = ExtractName(pageText);

            //Ha sikertelen volna a név kinyerése muszáj valahogy mégis elmenteni a filet
            if (string.IsNullOrEmpty(name))
            {
                return $"{pageIndex + 1}_oldal.pdf";
            }


            // Ha van név, akkor számozást el kell menteni
            int count = IncrementNameCount(name);
            return $"{name}_{count}.pdf";
        }

        private string GetPageText(int pageIndex)
        {
            // PdfPig -> file megnyitása
            using UglyToad.PdfPig.PdfDocument pdfDocument = UglyToad.PdfPig.PdfDocument.Open(InputFilePath);

            // A PdfPig indexelése 1-től kezdődik -> a pageIndex + 1-et használjuk.
            // Azért használok var típust, mert a Visual Studio felfogja ismerni milyen típusú lesz a page
            var page = pdfDocument.GetPage(pageIndex + 1);

            // Szöveg kinyerése a PDF oldalról.
            return page.Text;
        }
        private string ExtractName(string text)
        {
            Regex regex = new Regex(@"NÉV:\s*([\w\.\-]+(?:[\s\w\.\-]+)*)", RegexOptions.IgnoreCase);
            Match match = regex.Match(text);

            /*// Ha van találat, akkor a nevet tisztítjuk, és a szóközöket "_" karakterekre cseréljük.
            return match.Success ? match.Groups[1].Value.Replace(" ", "_") : string.Empty;*/

            // Ha találunk érvényes nevet, az extra szavakat töröljük és csak a tényleges névet használjuk
            if (match.Success)
            {
                string name = match.Groups[1].Value.Trim();

                // Ha a név tartalmazza a "Munkavállaló" vagy "Munkáltató" szót, távolítsuk el
                // Valamiért ezt a 2 szót állandóan beletette a fájl nevébe
                // Másképp nem tudtam megoldani csak, ha így szedem le
                string[] excludedWords = new string[] { "Munkavállaló", "Munkáltató" };
                foreach (string word in excludedWords)
                {
                    if (name.Contains(word))
                    {
                        name = name.Replace(word, "").Trim();
                    }
                }

                // A nevet aláhúzással elválasztjuk, ha szóköz van benne
                return name.Replace(" ", "_");
            }

            return string.Empty;
        }

        private int IncrementNameCount(string name)
        {
            // Ha a név nem szerepelt még akkor 1-es értéket kap
            if(!nameCount.ContainsKey(name))
            {
                nameCount[name] = 1;
            }
            else
            {
                // Ha már előfordult, akkor növelem a számlálót
                nameCount[name]++;
            }

            // Visszaadom a következő számozást
            return nameCount[name];
        }


    }
}
