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
        /// <param name="uri"></param>
        /// <exception cref="HtmlParseError"></exception>
        public WebJobScraper(HtmlDocument htmlDocument, Uri uri)
        {
            string host = uri.Host;
            this.HtmlDocument = htmlDocument;
            this.HeadHtmlNode = htmlDocument.DocumentNode.SelectSingleNode("//head");
            this.HeadMetaHtmlNodes = htmlDocument.DocumentNode.SelectNodes("//html/head/meta");
            this.BodyHtmlNode = htmlDocument.DocumentNode.SelectSingleNode("//body");
            this.Lang = this.SetTagFromNode("html", "lang");
            this.XmlLang = this.SetTagFromNode("html", "xml:lang");

            this.WebJob = new WebJob(this.Lang, this.XmlLang);
            this.WebJob.SetTitle(this.GetHtmlHeadNodeInnerText(nodeName:"title"));
            this.WebJob.SetEncoding(this.GetTagValueInHeadMetaHtmlNodeFromIndex(tagValue:"charset="));
            AbstractOffer abstractOffer;

            if (this.IsItCareerBuilder(host))
                abstractOffer = new CareerBuilderOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsCorningJobs(host))
                abstractOffer = new CorningJobsOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsDice(host))
                abstractOffer = new DiceOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsEmploisTi(host))
                abstractOffer = new EmploisTiOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsEspressoJobs(host))
                abstractOffer = new EspressoJobsOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsGlassDoor(host))
                abstractOffer = new GlassDoorOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsIsarta(host))
                abstractOffer = new IsartaOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsItJobs(host))
                abstractOffer = new ItJobsOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsJobBoom(host))
                abstractOffer = new JobBoomOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsJobIllico(host))
                abstractOffer = new JobIllicoOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsMayaHtt(host))
                abstractOffer = new MayaHttOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsMonster(host))
                abstractOffer = new MonsterOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsNeuvoo(host))
                abstractOffer = new NeuvooOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsUapInc(host))
                abstractOffer = new CvManagerOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsWorkHoppers(host))
                abstractOffer = new WorkHoppersOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsWorkJam(host))
                abstractOffer = new WorkJamOffer(this.BodyHtmlNode, this.Lang, uri);
            else if (this.IsZipRecruiter(host))
                abstractOffer = new ZipRecruiterOffer(this.BodyHtmlNode, this.Lang, uri);
            else
                abstractOffer = new AbstractOffer(this.BodyHtmlNode, this.Lang, uri);

            this.WebJob.SetAbstractOffer(abstractOffer);
        }

        #region PrivateMethods
        /// <summary>Determines whether [is it career builder] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is it career builder] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsItCareerBuilder(string host) => this.IsPublisher("CareerBuilder", host);

        /// <summary>Determines whether [is corning jobs] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is corning jobs] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsCorningJobs(string host) => this.IsPublisher("CorningJobs", host);

        /// <summary>Determines whether [is dice] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is dice] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsDice(string host) => this.IsPublisher("Dice", host);

        /// <summary>Determines whether [is emplois ti] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is emplois ti] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsEmploisTi(string host) => this.IsPublisher("EmploisTI", host);

        /// <summary>Determines whether [is espresso jobs] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is espresso jobs] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsEspressoJobs(string host) => this.IsPublisher("Espresso-Jobs", host);

        /// <summary>Determines whether [is glass door] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is glass door] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsGlassDoor(string host) => this.IsPublisher("GlassDoor", host);

        /// <summary>Determines whether [is isarta] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is isarta] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsIsarta(string host) => this.IsPublisher("Isarta", host);

        /// <summary>Determines whether [is it jobs] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is it jobs] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsItJobs(string host) => this.IsPublisher("ItJobs", host);

        /// <summary>Determines whether [is job boom] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is job boom] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsJobBoom(string host) => this.IsPublisher("JobBoom", host);

        /// <summary>Determines whether [is job illico] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is job illico] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsJobIllico(string host) => this.IsPublisher("JobIllico", host);

        /// <summary>Determines whether [is maya HTT] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is maya HTT] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsMayaHtt(string host) => this.IsPublisher("MayaHtt", host);

        /// <summary>Determines whether [is monster] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is monster] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsMonster(string host) => this.IsPublisher("Monster", host);

        /// <summary>Determines whether [is neuvoo] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is neuvoo] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsNeuvoo(string host) => this.IsPublisher("Neuvoo", host);

        /// <summary>Determines whether [is uap inc] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is uap inc] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsUapInc(string host) => this.IsPublisher("CvManager", host);

        /// <summary>Determines whether [is work hoppers] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is work hoppers] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsWorkHoppers(string host) => this.IsPublisher("WorkHoppers", host);

        /// <summary>Determines whether [is work jam] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is work jam] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsWorkJam(string host) => this.IsPublisher("WorkJam", host);

        /// <summary>Determines whether [is zip recruiter] [the specified host].</summary>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is zip recruiter] [the specified host]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsZipRecruiter(string host) => this.IsPublisher("ZipRecruiter", host);

        /// <summary>Determines whether [is publisher] [the specified publisher].</summary>
        /// <param name="publisher">The publisher.</param>
        /// <param name="host">The host.</param>
        /// <returns><SPAN class=code>true</SPAN> if [is publisher] [the specified publisher]; otherwise, <SPAN class=code>false</SPAN>.</returns>
        private bool IsPublisher(string publisher, string host)
            => host.IndexOf(publisher.ToLowerInvariant().Replace(" ", ""), StringComparison.InvariantCultureIgnoreCase) >= 0;
        #endregion

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
