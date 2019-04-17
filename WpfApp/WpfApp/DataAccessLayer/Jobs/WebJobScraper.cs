/**
* WebJobScraper.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 16-04-2019
* OR 4/16/2019 12:39:14 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using System;

    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="WebJobScraper" />
    /// </summary>
    public class WebJobScraper
    {
        /// <summary>Gets the web job.</summary>
        /// <value>The web job.</value>
        public WebJob WebJob { get; internal set; }

        /// <summary>Gets the HTML document.</summary>
        /// <value>The HTML document.</value>
        public HtmlDocument HtmlDocument { get; internal set; }

        /// <summary>Gets the head HTML node.</summary>
        /// <value>The head HTML node.</value>
        public HtmlNode HeadHtmlNode { get; internal set; }

        /// <summary>Gets the meta HTML node collection.</summary>
        /// <value>The meta HTML node collection.</value>
        public HtmlNodeCollection MetaHtmlNodeCollection { get; internal set; }

        /// <summary>Gets the language.</summary>
        /// <value>The language.</value>
        public string Lang { get; internal set; }

        /// <summary>Gets the XML language.</summary>
        /// <value>The XML language.</value>
        public string XmlLang { get; internal set; }

        /// <summary>Initializes a new instance of the <see cref="WebJobScraper"/> class.</summary>
        /// <param name="htmlDocument">The HTML document.</param>
        /// <exception cref="HtmlParseError"></exception>
        public WebJobScraper(HtmlDocument htmlDocument)
        {
            this.HtmlDocument = htmlDocument;
            this.Lang = this.SetTagFromNode("html", "lang");
            this.XmlLang = this.SetTagFromNode("html", "xml:lang");
            this.HeadHtmlNode = htmlDocument.DocumentNode.SelectSingleNode("//head");

            if (!String.IsNullOrWhiteSpace(this.Lang) ||
                !String.IsNullOrWhiteSpace(this.XmlLang)) this.WebJob = new WebJob(this.Lang, this.XmlLang);

            this.WebJob.SetTitle(htmlDocument.DocumentNode.SelectSingleNode("//html/head/title").InnerText);
            this.MetaHtmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//html/head/meta");
        }

        /// <summary>Sets the tag from node.</summary>
        /// <param name="node">The node.</param>
        /// <param name="tag">The tag.</param>
        /// <returns>A string from TAG in NODE</returns>
        private string SetTagFromNode(string node, string tag)
        {
            node = "//" + node;
            string s = String.Empty;

            try
            {
                s = this.HtmlDocument.DocumentNode.SelectSingleNode(node).Attributes[tag].Value;
            }
            catch (Exception exp)
            {
                return String.Empty;
            }

            return s ?? String.Empty;
        }
    }
}
