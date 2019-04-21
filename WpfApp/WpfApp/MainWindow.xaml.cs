/**
* MainWindow.xaml.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 10-04-2019
* OR 4/10/2019 6:35:18 PM
**/

namespace WpfApp
{
    using DataAccessLayer.Files;
    using DataAccessLayer.URLs;
    using Microsoft.Win32;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using WpfApp.DataAccessLayer.Jobs;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region PrivateAttributes
        /// <summary>The thickness</summary>
        private readonly double _thickness = 10.0;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the CsvFile
        /// </summary>
        public CsvFile CsvFile { get; internal set; }

        /// <summary>
        /// Gets or sets the OpenFileDialog
        /// </summary>
        public OpenFileDialog OpenFileDialog { get; internal set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Title = "Amaris Consulting: International consulting company | " + ToString().Split('.')[1];
            this.Left = this._thickness;
            this.Top = this._thickness;
            this.Height = this._thickness * 60.0;
            this.Width = this._thickness * 80.0;
            this.CsvFile = new CsvFile();
            this.InitializeComponent();
            this.WpfAppMainStatusBarProgressBar.Value = this._thickness * 2.5;
            this.InitializeImage();
            this.InitializeLabelBanner();
            this.InitializeDockPanelUp();
            this.InitializeDockPanelBottom();
            this.InitializeWpfAppMainListBox();
        }

        /// <summary>Initializes the image.</summary>
        private void InitializeImage()
        {
            this.WpfMainImage.Height = this._thickness * 2.0;
            this.WpfMainImage.Margin = new Thickness(this._thickness, this._thickness, 0.0, 0.0);
        }

        /// <summary>Initializes the label banner.</summary>
        private void InitializeLabelBanner()
        {
            this.WpfMainLabelBanner.Height = this._thickness * 2.5;
            this.WpfMainLabelBanner.Width = this._thickness * 60.0;
            this.WpfMainLabelBanner.Margin = new Thickness(this._thickness * 15.0, this._thickness, 0.0, 0.0);
            this.WpfMainLabelBanner.FontSize = this._thickness * 1.2;
        }

        /// <summary>Initializes the dock panel up.</summary>
        private void InitializeDockPanelUp()
        {
            this.WpfMainDockPanelUp.Height = this._thickness * 2.0;
            this.WpfMainDockPanelUp.Margin =
                new Thickness(this._thickness, this._thickness * 5.0, this._thickness, this._thickness * 20.0);
            this.WpfAppMainOpen.Width = this._thickness * 14.0;
            this.WpfAppMainSave.Width = this._thickness * 14.0;
            this.WpfAppMainExit.Width = this._thickness * 14.0;
            this.WpfAppMainAbout.Width = this._thickness * 14.0;
        }

        /// <summary>Initializes the dock panel bottom.</summary>
        private void InitializeDockPanelBottom()
        {
            this.WpfAppMainStatusBarTextBlockLeft.Text = "Byte size: ";
            this.WpfAppMainStatusBarTextBlockCenter.Text = "File path: ";
            this.WpfAppMainStatusBarProgressBar.Height = this._thickness * 2.0;
            this.WpfAppMainStatusBarProgressBar.Width = this._thickness * 9.0;
        }

        /// <summary>Initializes the WPF application main ListBox.</summary>
        private void InitializeWpfAppMainListBox()
        {
            this.WpfAppMainListBox.SelectionMode = SelectionMode.Single;
            this.WpfAppMainListBox.DisplayMemberPath = "Url";
            this.WpfAppMainListBox.MouseDoubleClick += WpfAppMainListBox_OnMouseDoubleClick;
            double d = this._thickness / 4.0;
            this.WpfAppMainListBox.BorderThickness = new Thickness(d, d, d, d);
            this.WpfAppMainListBox.Height = this._thickness * 44.5;
            this.WpfAppMainListBox.Width = this._thickness * 76.5;
            this.WpfAppMainListBox.Margin = new Thickness(this._thickness, this._thickness * 8.0, 0.0, 0.0);
        }
        #endregion

        /// <summary>Initializes the WPF application main ListBox.</summary>
        /// <param name="urlLinks">The URL links.</param>
        private void PopulateListBox(List<UrlLink> urlLinks)
        {
            foreach (UrlLink urlLink in urlLinks)
                this.WpfAppMainListBox.Items.Add(urlLink);
            /*object selectedItem = this.WpfAppMainListBox.SelectedItem;
            if (selectedItem != null)
            {
                ListBoxItem item = (ListBoxItem)selectedItem;
                ListBox listView = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
                object index = listView.ItemContainerGenerator.ItemFromContainer(item);
                item.IsEnabled = ((UrlLink)index).IsValid;
            }*/
        }

        /// <summary>Handles the OnMouseDoubleClick event of the WpfAppMainListBox control.
        /// int selectedIndex = this.WpfAppMainListBox.SelectedIndex
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UrlLink urlLink = (UrlLink)this.WpfAppMainListBox.SelectedItem;

            if (this.WpfAppMainListBox.SelectedItem != null)
                if(!urlLink.IsValid)
                {
                    string showTitle = "Amaris Consulting: International consulting company | URL link message";
                    string showMessage = urlLink.IsValid ? urlLink.Query + "is valid" : urlLink.AbsolutePath + " is invalid " + urlLink.HttpStatusCode;
                    MessageBoxButton showBoxButton = urlLink.IsValid ? MessageBoxButton.OKCancel : MessageBoxButton.OK;
                    MessageBoxImage showBoxImage = urlLink.IsValid ? MessageBoxImage.Question : MessageBoxImage.Error;
                    MessageBoxResult showBoxResultDefault = urlLink.IsValid ? MessageBoxResult.Cancel : MessageBoxResult.OK;
                    MessageBox.Show(
                        this
                        , showMessage
                        , showTitle
                        , showBoxButton
                        , showBoxImage
                        , showBoxResultDefault);
                }
                else
                {
                    System.Net.HttpStatusCode v = urlLink.HttpStatusCode;
                    Clipboard.SetText(urlLink.Link);
                    // System.Diagnostics.Process.Start("iexplore.exe", "http://www.msn.com");Process.Start(urlLink.Link);
                    WebJobPosting webJobPosting = new WebJobPosting(urlLink.Url);
                    var l = webJobPosting.WebJobScraper.WebJob.CultureInfo;
                    var x = webJobPosting.WebJobScraper.WebJob.XmlCultureInfo;
                    var s = webJobPosting.WebJobScraper.WebJob.AbstractOffer.ToJson();
                }
        }

        #region Methods
        /// <summary>
        /// The WpfAppMainOpen_OnClick
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainOpen_OnClick(object sender, RoutedEventArgs e)
        {
            this.OpenFileDialog = new OpenFileDialog
            {
                AddExtension = true,
                InitialDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Root.FullName,
                Filter = CsvFile.Filter
            };
            bool? result = this.OpenFileDialog.ShowDialog(this);

            if (result != null && result == true)
            {
                this.CsvFile.SetFileInfo(new FileInfo(this.OpenFileDialog.FileName));
                this.WpfAppMainStatusBarTextBlockCenter.Text +=
                    this.CsvFile.FileInfo.FullName + " ".PadRight(15, '.') + " Readable: ";
                this.WpfAppMainStatusBarProgressBar.Value = 30.0;

                if (this.CsvFile.Read())
                {
                    this.WpfAppMainStatusBarProgressBar.Value = 80.0;
                    this.WpfAppMainStatusBarTextBlockLeft.Text += this.CsvFile.FileInfo.Length;
                    this.WpfAppMainStatusBarTextBlockCenter.Text += this.CsvFile.IsReadable ? "Yes" : "No";
                    this.WpfAppMainStatusBarTextBlockCenter.Text += " Rows: " + this.CsvFile.Rows;
                    this.WpfAppMainStatusBarTextBlockCenter.Text += " Results: " + this.CsvFile.URLs.Count;
                    this.WpfAppMainStatusBarProgressBar.Value = 100.0;
                    this.PopulateListBox(this.CsvFile.URLs);
                }
            }
        }

        /// <summary>
        /// The WpfAppMainSave_OnClick
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainSave_OnClick(object sender, RoutedEventArgs e) => this.WpfAppMainExit_OnClick(sender, e);

        /// <summary>
        /// The WpfAppMainExit_OnClick
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainExit_OnClick(object sender, RoutedEventArgs e) => this.Close();

        /// <summary>
        /// The WpfAppMainAbout_OnClick
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WpfAppMainAbout_OnClick(object sender, RoutedEventArgs e) => this.WpfAppMainExit_OnClick(sender, e);
        #endregion
    }
}
