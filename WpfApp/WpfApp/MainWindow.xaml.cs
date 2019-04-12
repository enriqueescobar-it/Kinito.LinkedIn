/**
* MainWindow.xaml.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 10-04-2019
* OR 4/10/2019 6:35:18 PM
**/

using DocumentFormat.OpenXml;

namespace WpfApp
{
    using DataAccessLayer;
    using Microsoft.Win32;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    using System.IO;
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>Gets the open file dialog.</summary>
        /// <value>The open file dialog.</value>
        public OpenFileDialog OpenFileDialog { get; internal set; }

        /// <summary>Gets the excel file.</summary>
        /// <value>The excel file.</value>
        public ExcelFile ExcelFile { get; internal set; }

        public int WorkBookSheetListCount { get; internal set; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Title = "Amaris Consulting: International consulting company | " + this.ToString().Split('.')[1];
            this.ExcelFile = new ExcelFile();
            InitializeComponent();
        }
        #endregion

        /// <summary>Handles the OnClick event of the WpfAppMainExit control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainExit_OnClick(object sender, RoutedEventArgs e) => this.Close();

        /// <summary>Handles the OnClick event of the WpfAppMainOpen control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainOpen_OnClick(object sender, RoutedEventArgs e)
        {
            this.OpenFileDialog = new OpenFileDialog
            {
                AddExtension = true,
                InitialDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Root.FullName,
                Filter = this.ExcelFile.ExcelFilter
            };
            bool? result = this.OpenFileDialog.ShowDialog(this);

            if (result != null && result == true)
            {
                this.ExcelFile.SetFileInfo(new FileInfo(this.OpenFileDialog.FileName));
                this.WpfAppMainStatusBarTextBlockCenter.Text = this.ExcelFile.FileInfo.FullName;

                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(this.ExcelFile.FileInfo.FullName, false))
                {
                    WorkbookPart workBookPart = spreadsheetDocument.WorkbookPart;
                    SharedStringTablePart sharedStringTablePart = workBookPart.SharedStringTablePart;
                    Workbook workBook = workBookPart.Workbook;
                    Sheets workBookSheetList = workBook.Sheets;

                    /*if (workBookSheetList == null || workBookSheetList.Count() != 1)
                        throw new FileFormatException(new Uri(this.ExcelFile.FileInfo.FullName), "workBookSheetList");*/

                    this.WorkBookSheetListCount = workBookSheetList.Count();
                    this.WpfAppMainStatusBarTextBlockLeft.Text += this.WorkBookSheetListCount + ">";
                    OpenXmlElementList workBookSheetListChildElements = workBookSheetList.ChildElements;

                    /*if (workBookSheetListChildElements == null)
                        throw new FileFormatException(new Uri(this.ExcelFile.FileInfo.FullName), "workBookSheetListChildElements");*/

                    int workBookSheetListChildElementsCount = workBookSheetListChildElements.Count;
                    this.WpfAppMainStatusBarTextBlockLeft.Text += workBookSheetListChildElementsCount + ")";
                    Sheet sheet = (Sheet)workBookSheetListChildElements.GetItem(0);
                    Worksheet workSheet = ((WorksheetPart)workBookPart.GetPartById(sheet.Id)).Worksheet;
                    IEnumerable<Row> rows = workSheet.Descendants<Row>();
                    int c = rows.Count();
                    this.WpfAppMainStatusBarTextBlockLeft.Text += c + "|";
                    foreach (Row row in rows)
                    {
                        var v = row.ChildElements.FirstOrDefault();
                    }
                    /*if (workSheet.ChildElements == null || workSheet.ChildElements.Count !=1)
                        throw new FileFormatException(new Uri(this.ExcelFile.FileInfo.FullName));*/

                        /*int workSheetChildElementsCount = workSheet.ChildElements.Count;
                        SheetData sheetData = (SheetData) workSheet.ChildElements.GetItem(0);
                        Row firstRow = (Row) sheetData.ChildElements.GetItem(0);
                        Cell cell = (Cell) firstRow.ChildElements.GetItem(0);
                        string stringCell = cell.InnerText;*/
                    }
            }
        }

        /// <summary>Handles the OnClick event of the WpfAppMainAbout control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainAbout_OnClick(object sender, RoutedEventArgs e) => this.WpfAppMainExit_OnClick(sender, e);

        /// <summary>Handles the OnClick event of the WpfAppMainSave control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainSave_OnClick(object sender, RoutedEventArgs e) => this.WpfAppMainExit_OnClick(sender, e);
    }
}
