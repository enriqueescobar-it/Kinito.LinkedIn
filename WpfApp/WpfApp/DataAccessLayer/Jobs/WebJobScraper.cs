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
        public ObservableCollection<WebJob> WebJob { get; internal set; }

        public void ScrapeData(string page)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = htmlWeb.Load(page);
        }
    }
}
