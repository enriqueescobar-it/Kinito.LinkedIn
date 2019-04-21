/**
* JobillicoOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 8:19:27 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="JobillicoOffer" />
    /// </summary>
    public class JobillicoOffer : AbstractOffer
    {
        #region Properties
        /// <summary>Gets the meta title.</summary>
        /// <value>The meta title.</value>
        public string MetaTitle { get; internal set; }

        /// <summary>Gets the meta company.</summary>
        /// <value>The meta company.</value>
        public string MetaCompany { get; internal set; }

        /// <summary>Gets the meta location.</summary>
        /// <value>The meta location.</value>
        public string MetaLocation { get; internal set; }

        /// <summary>Gets the meta date.</summary>
        /// <value>The meta date.</value>
        public string MetaDate { get; internal set; }

        /// <summary>Gets the meta source.</summary>
        /// <value>The meta source.</value>
        public string MetaSource { get; internal set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="JobillicoOffer"/> class.
        /// </summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        public JobillicoOffer(HtmlNode bodyHtmlNode)
        {
            HtmlNode jobHtmlNode = this.GetHtmlNodeFromDivIdInBodyHtmlNode(bodyHtmlNode, "printJobSection");
            HtmlNode companyHtmlNode = this.GetHtmlNodeFromH2ClassInJobHtmlNode(jobHtmlNode, "main-article-content col-md-8");
            this.MetaTitle = this.GetMetaTitleFromJobHtmlNode(jobHtmlNode, "h1-class art-head");
            var v = this.GetFromHtml(companyHtmlNode);//.InnerHtml; //.Replace("  ", " ").Replace("  ", " ");
        }

        private HtmlNode GetFromHtml(HtmlNode companyHtmlNode)
        {
            return companyHtmlNode.ChildNodes.FindFirst("article").FirstChild;
        }

        /// <summary>Gets the HTML node from h2 class in job HTML node.</summary>
        /// <param name="jobHtmlNode">The job HTML node.</param>
        /// <param name="h2Class">The h2 class.</param>
        /// <returns></returns>
        private HtmlNode GetHtmlNodeFromH2ClassInJobHtmlNode(HtmlNode jobHtmlNode, string h2Class)
            => jobHtmlNode.SelectSingleNode("//div[@class ='" + h2Class + "']");

        /// <summary>Gets the meta title from job HTML node.</summary>
        /// <param name="jobHtmlNode">The job HTML node.</param>
        /// <param name="h1Class"></param>
        /// <returns>String on inner text</returns>
        private string GetMetaTitleFromJobHtmlNode(HtmlNode jobHtmlNode, string h1Class)
            => jobHtmlNode.SelectSingleNode("//h1[@class ='" + h1Class + "']").InnerText.TrimStart().TrimEnd().Trim();

        #endregion

        #region PrivateMethods
        /// <summary>Gets the HTML node from div identifier in body HTML node.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private HtmlNode GetHtmlNodeFromDivIdInBodyHtmlNode(HtmlNode bodyHtmlNode, string id)
            => bodyHtmlNode.SelectSingleNode("//div[@id ='" + id + "']");
        #endregion
    }
}
