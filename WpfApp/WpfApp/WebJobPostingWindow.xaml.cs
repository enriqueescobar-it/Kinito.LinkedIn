/**
* WebJobPostingWindow.xaml.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 23-04-2019
* OR 4/23/2019 2:25:44 PM
**/
namespace WpfApp
{
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
    using System.Windows.Shapes;

    using Newtonsoft.Json.Linq;

    using WpfApp.DataAccessLayer.Jobs;

    /// <summary>
    /// Interaction logic for WebJobPostingWindow.xaml
    /// </summary>
    public partial class WebJobPostingWindow : Window
    {
        /// <summary>Gets the web job posting.</summary>
        /// <value>The web job posting.</value>
        public WebJobPosting WebJobPosting { get; internal set; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobPostingWindow"/> class.
        /// </summary>
        /// <param name="webJobPosting">The webJobPosting<see cref="WebJobPosting"/></param>
        /// <param name="mainWindow"></param>
        public WebJobPostingWindow(WebJobPosting webJobPosting, MainWindow mainWindow)
        {
            this.InitializeComponent();
            this.WebJobPosting = webJobPosting;
            this.Initializer(mainWindow);
        }
        #endregion

        #region Initializers
        /// <summary>Initializes the specified main window.</summary>
        /// <param name="mainWindow">The main window.</param>
        private void Initializer(MainWindow mainWindow)
        {
            this.Title = mainWindow.Title.Split('|')[0] + " | " + ToString().Split('.')[1];
            this.Left = mainWindow.Width;
            this.Top = mainWindow.Top;
            this.Height = mainWindow.Height;
            this.Width = 2 * mainWindow.Height / 3;
            this.ResizeMode = mainWindow.ResizeMode;
            this.Icon = mainWindow.Icon;
            this.InitializeImage();
            this.InitializeLabel();
        }

        /// <summary>Initializes the image.</summary>
        private void InitializeImage()
        {
        }

        private void InitializeLabel()
        {
            /*this.WebJobPostingLabelBanner.VerticalAlignment = mainWindow.WpfMainLabelBanner.VerticalAlignment;
            this.WebJobPostingLabelBanner.VerticalContentAlignment = mainWindow.WpfMainLabelBanner.VerticalContentAlignment;
            this.WebJobPostingLabelBanner.HorizontalAlignment = mainWindow.WpfMainLabelBanner.HorizontalAlignment;
            this.WebJobPostingLabelBanner.HorizontalContentAlignment = mainWindow.WpfMainLabelBanner.HorizontalContentAlignment;
            this.WebJobPostingLabelBanner.FontFamily = mainWindow.WpfMainLabelBanner.FontFamily;
            this.WebJobPostingLabelBanner.FontStyle = mainWindow.WpfMainLabelBanner.FontStyle;*/
            this.WebJobPostingPublisherTextBox.Text = this.WebJobPosting.Publisher;
            this.WebJobPostingTitleTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.Title;
            this.WebJobPostingTitleTextBox.IsReadOnly = true;
            this.WebJobPostingCultureTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.CultureInfo.ToString();
            this.WebJobPostingXmlCultureTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.XmlCultureInfo.ToString();
            this.WebJobPostingEncodingTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.Encoding.ToString();
            this.WebJobPostingTextBlock.Text = this.WebJobPosting.WebJobScraper.WebJob.AbstractOffer.ToJson();
            this.WebJobMetaTitleTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.AbstractOffer.MetaTitle;
            this.WebJobMetaCompanyTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.AbstractOffer.MetaCompany;
            this.WebJobMetaLocationTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.AbstractOffer.MetaLocation;
            this.WebJobMetaDateTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.AbstractOffer.MetaDate;
            this.WebJobMetaSourceTextBox.Text = this.WebJobPosting.WebJobScraper.WebJob.AbstractOffer.MetaSource;
        }
        #endregion
    }
}
