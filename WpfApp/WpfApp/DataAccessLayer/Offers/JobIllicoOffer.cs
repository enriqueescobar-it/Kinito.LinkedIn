/**
* JobillicoOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 8:19:27 PM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="JobIllicoOffer" />
    /// </summary>
    public class JobIllicoOffer : AbstractOffer
    {
        #region Properties
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="JobIllicoOffer"/> class.</summary>
        public JobIllicoOffer() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobIllicoOffer"/> class.
        /// </summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        public JobIllicoOffer(HtmlNode bodyHtmlNode)
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

        /*#region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString()
            => base.ToString() + " as JobIllicoOffer\nTitle:\t" + this.MetaTitle + "\n" +
               "Company:\t" + this.MetaCompany + "\nLocation:\t" + this.MetaLocation + "\n" +
               "Date:\t" + this.MetaDate + "\nSource:\t" + this.MetaSource;
        #endregion*/
    }
}
