/**
* WebJobPosting.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 16-04-2019
* OR 4/16/2019 11:22:24 AM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using System;
    using System.Net.Http;
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="WebJobPosting" />
    /// </summary>
    public class WebJobPosting : AbstractJobPosting
    {
        #region Properties
        /// <summary>Gets or sets the Uri</summary>
        /// <value>The Uri.</value>
        public Uri Uri { get; internal set; }

        /// <summary>Gets the HTML.</summary>
        /// <value>The HTML.</value>
        public string Html { get; internal set; }

        /// <summary>Gets the publisher.</summary>
        /// <value>The publisher.</value>
        public string Publisher { get; internal set; }

        /// <summary>Gets the provider.</summary>
        /// <value>The provider.</value>
        public string Provider { get; internal set; }

        /// <summary>Gets the web job scraper.</summary>
        /// <value>The web job scraper.</value>
        public WebJobScraper WebJobScraper { get; internal set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WebJobPosting"/> class.
        /// </summary>
        /// <param name="uri">The Uri<see cref="Uri"/></param>
        public WebJobPosting(Uri uri)
        {
            this.Uri = uri;
            HttpClient httpClient = new HttpClient();
            this.Html = httpClient.GetStringAsync(this.Uri).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(this.Html);
            this.WebJobScraper = new WebJobScraper(htmlDocument);
        }
        #endregion
    }
}
