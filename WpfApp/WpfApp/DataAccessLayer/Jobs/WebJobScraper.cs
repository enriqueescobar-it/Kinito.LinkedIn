/**
* WebJobScraper.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 16-04-2019
* OR 4/16/2019 12:39:14 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using System.Collections.ObjectModel;

    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="WebJobScraper" />
    /// </summary>
    public class WebJobScraper
    {
        /// <summary>Gets the web job.</summary>
        /// <value>The web job.</value>
        public ObservableCollection<WebJob> WebJob { get; internal set; }

        /// <summary>Gets the HTML document.</summary>
        /// <value>The HTML document.</value>
        public HtmlDocument HtmlDocument { get; internal set; }

        /// <summary>Initializes a new instance of the <see cref="WebJobScraper"/> class.</summary>
        /// <param name="htmlDocument">The HTML document.</param>
        public WebJobScraper(HtmlDocument htmlDocument)
        {
            this.HtmlDocument = htmlDocument;
        }

        /// <summary>Scrapes the data.</summary>
        /// <param name="page">The page.</param>
        public void ScrapeData(string page)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = htmlWeb.Load(page);
        }
    }
}
