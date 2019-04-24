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
    using WpfApp.DataAccessLayer.Offers;

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

        /// <summary>Gets the body HTML node.</summary>
        /// <value>The body HTML node.</value>
        public HtmlNode BodyHtmlNode { get; internal set; }

        /// <summary>Gets the meta HTML node collection.</summary>
        /// <value>The meta HTML node collection.</value>
        public HtmlNodeCollection HeadMetaHtmlNodes { get; internal set; }

        /// <summary>Gets the language.</summary>
        /// <value>The language.</value>
        public string Lang { get; internal set; }

        /// <summary>Gets the XML language.</summary>
        /// <value>The XML language.</value>
        public string XmlLang { get; internal set; }

        /// <summary>Initializes a new instance of the <see cref="WebJobScraper"/> class.</summary>
        /// <param name="htmlDocument">The HTML document.</param>
        /// <param name="host"></param>
        /// <exception cref="HtmlParseError"></exception>
        public WebJobScraper(HtmlDocument htmlDocument, string host)
        {
            this.HtmlDocument = htmlDocument;
            this.HeadHtmlNode = htmlDocument.DocumentNode.SelectSingleNode("//head");
            this.HeadMetaHtmlNodes = htmlDocument.DocumentNode.SelectNodes("//html/head/meta");
            this.BodyHtmlNode = htmlDocument.DocumentNode.SelectSingleNode("//body");
            this.Lang = this.SetTagFromNode("html", "lang");
            this.XmlLang = this.SetTagFromNode("html", "xml:lang");

            this.WebJob = new WebJob(this.Lang, this.XmlLang);
            this.WebJob.SetTitle(this.GetHtmlHeadNodeInnerText(nodeName:"title"));
            this.WebJob.SetEncoding(this.GetTagValueInHeadMetaHtmlNodeFromIndex(tagValue:"charset="));
            AbstractOffer abstractOffer = new AbstractOffer();
            if (host.IndexOf("neuvoo", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new NeuvooOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as NeuvooOffer);
            }
            else if (host.IndexOf("jobillico", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new JobIllicoOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as JobIllicoOffer);
            }
            else if (host.IndexOf("itjobs", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new ItJobsOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as ItJobsOffer);
            }
            else if (host.IndexOf("mayahtt", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new MayaHttOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as MayaHttOffer);
            }
            else if (host.IndexOf("ziprecruiter", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new ZipRecruiterOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as ZipRecruiterOffer);
            }
            else if (host.IndexOf("dice", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new DiceOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as DiceOffer);
            }
            else if (host.IndexOf("careerbuilder", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new CareerBuilderOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as CareerBuilderOffer);
            }
            else if (host.IndexOf("uapinc", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new UapIncOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as UapIncOffer);
            }
            else if (host.IndexOf("corningjobs", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new CorningJobsOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as CorningJobsOffer);
            }
            else if (host.IndexOf("isarta", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new IsartaOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as IsartaOffer);
            }
            else if (host.IndexOf("emploisti", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new EmploisTiOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as EmploisTiOffer);
            }
            else if (host.IndexOf("espresso-jobs", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new EspressoJobsOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as EspressoJobsOffer);
            }
            else if (host.IndexOf("glassdoor", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new GlassDoorOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as GlassDoorOffer);
            }
            else if (host.IndexOf("jobboom", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new JobBoomOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as JobBoomOffer);
            }
            else if (host.IndexOf("workhoppers", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new WorkHoppersOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as WorkHoppersOffer);
            }
            else if (host.IndexOf("monster", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new MonsterOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as MonsterOffer);
            }
            else if (host.IndexOf("workjam", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                abstractOffer = new WorkJamOffer(this.BodyHtmlNode);
                this.WebJob.SetAbstractOffer(abstractOffer: abstractOffer as WorkJamOffer);
            }
            else
                abstractOffer = new AbstractOffer(this.BodyHtmlNode);
        }

        private AbstractOffer GetJobOfferFromHost(string host)
        {
            string searchString = String.Empty;

            searchString = new NeuvooOffer(this.BodyHtmlNode).ToString().ToLowerInvariant().Replace(" ", "");

            if (host.IndexOf(searchString, StringComparison.InvariantCultureIgnoreCase) >= 0)
                return new NeuvooOffer(this.BodyHtmlNode);
        }

        /// <summary>Gets the tag of the char set in head HTML node from.</summary>
        /// <param name="tagValue">The tag value.</param>
        /// <returns>String of tag value</returns>
        private string GetTagValueInHeadMetaHtmlNodeFromIndex(string tagValue)
        {
            int? index = this.FindIndexInHeadMetaHtmlNode(tagValue);

            return index.HasValue ?
                           this.HeadMetaHtmlNodes[index.Value].OuterHtml
                               .Replace("\"", "").Replace("<", "").Replace(">", "")
                               .ToLowerInvariant().Split(new[] { tagValue }, StringSplitOptions.None)[1] :
                           String.Empty;
        }

        /// <summary>Finds the index in head meta HTML node.</summary>
        /// <param name="charset">The char set.</param>
        /// <returns>Index if found</returns>
        private int? FindIndexInHeadMetaHtmlNode(string charset)
        {
            HtmlNodeCollection htmlHeadMetaNodeCollection = this.HeadHtmlNode.SelectNodes("//meta");
            int index = -1;

            for(int i = 0; i < htmlHeadMetaNodeCollection.Count ; i++)
                if (htmlHeadMetaNodeCollection[i].OuterHtml.Contains(charset))
                    index = i;

            return index >= 0 ? index : (int?) null;
        }

        /// <summary>Gets the HTML head title.</summary>
        /// <param name="nodeName"></param>
        /// <returns>Title</returns>
        private string GetHtmlHeadNodeInnerText(string nodeName)
        {
            HtmlNode htmlNode = this.HeadHtmlNode.SelectSingleNode("//" + nodeName);

            return htmlNode != null && !String.IsNullOrWhiteSpace(htmlNode.InnerText)
                ? htmlNode.InnerText
                : String.Empty ;
        }

        /// <summary>Finds the in head meta.</summary>
        /// <param name="tag">The tag.</param>
        /// <returns>String content from tag in meta</returns>
        private string FindInHtmlHeadMeta(string tag)
        {
            HtmlNode metaHtmlNode = this.HtmlDocument.DocumentNode.SelectSingleNode($"//meta[@name='{tag}']");

            return metaHtmlNode != null ? metaHtmlNode.GetAttributeValue("content", "") : String.Empty;
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
