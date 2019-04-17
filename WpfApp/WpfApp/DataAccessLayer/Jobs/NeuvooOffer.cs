/**
* NeuvooOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 3:30:59 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="NeuvooOffer" />
    /// </summary>
    public class NeuvooOffer : AbstractOffer
    {
        #region Properties
        /// <summary>Gets the body HTML node.</summary>
        /// <value>The body HTML node.</value>
        public HtmlNode BodyHtmlNode { get; internal set; }

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
        /// Initializes a new instance of the <see cref="NeuvooOffer"/> class.
        /// </summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        public NeuvooOffer(HtmlNode bodyHtmlNode)
        {
            this.BodyHtmlNode = bodyHtmlNode;
            this.MetaTitle = this.GetJobMetaFromDivId("job-meta-title");
            this.MetaCompany= this.GetJobMetaFromDivId("job-meta-company");
            this.MetaLocation = this.GetJobMetaFromDivId("job-meta-location");
            this.MetaDate = this.GetJobMetaFromDivId("job-meta-date");
            this.MetaSource = this.GetJobMetaFromDivId("job-meta-source");
        }
        #endregion

        #region PrivateMethods
        /// <summary>Gets the job meta from div identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private string GetJobMetaFromDivId(string id)
            => this.BodyHtmlNode.SelectSingleNode("//div[@id ='" + id + "']").InnerText.TrimStart().TrimEnd().Trim();
        #endregion
    }
}
