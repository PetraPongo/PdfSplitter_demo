using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;
using System;
using Microsoft.Win32;
using PDFSplitter.Classes;
using System.Collections.ObjectModel;

namespace PDFSplitter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Automatikusan értesítést küld a felhasználói felületnek, ha frissítés történik az elemek között
        ObservableCollection<PdfFile> documents;

        public MainWindow()
        {
            InitializeComponent();

            // UI frissítéseket kezeli majd a ListBox-ban ha sorrend módosítás, törlés vagy hozzáadás történik
            documents = new ObservableCollection<PdfFile>();

            // Adatkötés a XAML fájlhoz
            listPdfFiles.ItemsSource = documents;


        }

        //---------------------------------------------------------------        DARABOLÁS FUNKCIÓK       ---------------------------------------------------------------------------------
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF fájlok (*.pdf)|*.pdf";

            if (ofd.ShowDialog() == true)
            {
                txtFilePath.Text = ofd.FileName; // Fájlelérési út megjelenítése a szövegdobozban
            }
        }

        private void btnSplit_Click(object sender, RoutedEventArgs e)
        {
            string inputFilePath = txtFilePath.Text;

            if (string.IsNullOrWhiteSpace(inputFilePath) || !File.Exists(inputFilePath))
            {
                MessageBox.Show("Kérlek, válassz ki egy PDF fájlt!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {

                /*int pagesProcssed = 0;
                pagesProcssed++;*/





                SimplePDFSplitter splitter = new SimplePDFSplitter(inputFilePath);
                splitter.ProcessPDF();

                processedLabel.Content = $"{splitter.pageCount}/{splitter.pagesProcessed} oldal sikeresen feldolgozva";

                MessageBox.Show("A PDF fájl sikeresen feldarabolva!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                txtFilePath.Text = "";

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); // Ha nem elég oldalas a PDF
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSplitbyName_Click(object sender, RoutedEventArgs e)
        {
            string inputFilePath = txtFilePath.Text;

            if (string.IsNullOrWhiteSpace(inputFilePath) || !File.Exists(inputFilePath))
            {
                MessageBox.Show("Kérlek, válassz ki egy PDF fájlt!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                PDFSplitByName splitter = new PDFSplitByName(inputFilePath);
                splitter.ProcessPDF();

                processedLabel.Content = $"{splitter.pageCount}/{splitter.pagesProcessed} oldal sikeresen feldolgozva";

                MessageBox.Show("A PDF fájl sikeresen darabolva!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                txtFilePath.Text = "";
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error); // Ha nem elég oldalas a PDF
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------           MERGE FUNKCIÓ         -----------------------------------------------------------------------------


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF fájlok (*.pdf)|*.pdf";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    PdfFile pdf = new PdfFile
                        (
                            System.IO.Path.GetFileName(file),
                            file
                        );

                    documents.Add(pdf);
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listPdfFiles.SelectedItem is PdfFile selectedPdf)
            {
                documents.Remove(selectedPdf);
            }
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            int selected = listPdfFiles.SelectedIndex;
            if (selected > 0)
            {
                /*// Elem csere
                PdfFile item = documents[selected];
                documents[selected] = documents[selected - 1];
                documents[selected - 1] = temp;

                // Adatkötést újra kell frissíteni, mert nem érzékeli megfelelően a cserét
                listPdfFiles.ItemsSource = null;
                listPdfFiles.ItemsSource = documents;

                listPdfFiles.SelectedIndex = selected - 1;*/

                // A "Move" metódussal megoldható a frissítés -> ObservableCollection tartalmazza
                // kifejezettten UI frissítésekre
                // Azért -1, mert fentebb kell vinni az indexének az értékét 
                PdfFile item = documents[selected];
                documents.Move(selected, selected - 1);
                listPdfFiles.SelectedIndex = selected - 1;

            }
        }
        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            int selected = listPdfFiles.SelectedIndex;

            // Azért kell, hogy az utolsó elem indexe ne legyen túllépve
            if (selected >= 0 && selected < documents.Count - 1)
            {
                // A "Move" metódussal megoldható a frissítés -> ObservableCollection tartalmazza
                // kifejezettten UI frissítésekre
                // Azért +1, mert lentebb kell vinni az indexének az értékét 
                PdfFile item = documents[selected];
                documents.Move(selected, selected + 1);
                listPdfFiles.SelectedIndex = selected + 1;

            }
        }

        private void btnMergePdf_Click(object sender, RoutedEventArgs e)
        {
            if (documents.Count == 0 || documents.Count == 1)
            {
                MessageBox.Show("Nincs megfelelő mennyiségű kiválasztott fájl az egyesítéshez!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Ne fusson tovább a kód
            }
            

            // Párbeszédablak -> hová akarom menteni a fájlt
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF fájlok (*pdf)|*.pdf";
            saveFileDialog.FileName = "Egyesítés.pdf";

            if(saveFileDialog.ShowDialog() == true )
            {
                try
                {
                    // using-al hsaználat után megfelelően felszabadul az erőforrás és nem kell külön Dispose() metódust hívni
                    using (PdfDocument newdocument = new PdfDocument())
                    {
                        // Végigmegyek a pdf fileokon, hogy ellenőrizzem őket egyesítés előtt
                        foreach (PdfFile file in documents)
                        {
                            // Ha a fájl törlésre került(már nem létezik) jelezni kell
                            if (!File.Exists(file.FilePath))
                            {
                                MessageBox.Show($"A fájl nem található: {file.FilePath}", "", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            // Ha minden okés, akkor megnyitom a fájlokat, hogy átmásolhassam az új dokumetumba
                            PdfDocument merging = PdfReader.Open(file.FilePath, PdfDocumentOpenMode.Import);

                            // Oldalakat másolom az új pdf dokumentumbq
                            foreach(PdfPage page in merging.Pages)
                            {
                                newdocument.Pages.Add(page);
                            }

                            // Ha kész vagyok megszabadulok a régi dokumentumoktól
                            merging.Dispose();
                        }

                        newdocument.Save(saveFileDialog.FileName);
                        MessageBox.Show("PDF fájlok sikeresen egyesítve!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    documents.Clear();
                }
                catch(FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Hiba történt: {ex.Message}", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}