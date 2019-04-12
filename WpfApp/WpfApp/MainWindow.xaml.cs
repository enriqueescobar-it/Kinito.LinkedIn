/**
* MainWindow.xaml.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 10-04-2019
* OR 4/10/2019 6:35:18 PM
**/

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
    using System.Net.Http;
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

        /// <summary>Gets the CSV file.</summary>
        /// <value>The CSV file.</value>
        public CsvFile CsvFile { get; internal set; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Title = "Amaris Consulting: International consulting company | " + this.ToString().Split('.')[1];
            this.CsvFile = new CsvFile();
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
                Filter = this.CsvFile.Filter
            };
            bool? result = this.OpenFileDialog.ShowDialog(this);

            if (result != null && result == true)
            {
                this.CsvFile.SetFileInfo(new FileInfo(this.OpenFileDialog.FileName));
                this.WpfAppMainStatusBarTextBlockCenter.Text = this.CsvFile.FileInfo.FullName;
                this.WpfAppMainStatusBarProgressBar.Value = 30;

                if (this.CsvFile.Read())
                {
                    this.WpfAppMainStatusBarProgressBar.Value = 80;
                    this.WpfAppMainStatusBarTextBlockLeft.Text = this.CsvFile.FileInfo.Length + " bytes file.";
                    this.WpfAppMainStatusBarTextBlockCenter.Text += " ".PadRight(12,'.');
                    this.WpfAppMainStatusBarTextBlockCenter.Text += (this.CsvFile.IsReadable) ? " is " : " is not ";
                    this.WpfAppMainStatusBarTextBlockCenter.Text += "readable with " + this.CsvFile.URLs.Count + " lines loaded.";
                    this.WpfAppMainStatusBarProgressBar.Value = 100;

                    foreach (UrlLink csvFileUrl in this.CsvFile.URLs)
                        this.WpfAppMainListBox.Items.Add(csvFileUrl.Url.AbsoluteUri);

                    HttpClient httpClient = new HttpClient();
                    UrlLink f = this.CsvFile.URLs[10];
                    Task<string> html = httpClient.GetStringAsync(f.Url.AbsoluteUri);
                    string v = html.Result;
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
