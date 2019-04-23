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
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="NeuvooOffer"/> class.</summary>
        public NeuvooOffer() : base(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NeuvooOffer"/> class.
        /// </summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        public NeuvooOffer(HtmlNode bodyHtmlNode)
        {
            this.MetaTitle = this.GetMetaTile(bodyHtmlNode);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.GetMetaCompany(bodyHtmlNode);
            this.MetaDate = this.GetMetaDate(bodyHtmlNode);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
        }
        #endregion

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString()
            => base.ToString() + " as " + this + "\nTitle:\t" + this.MetaTitle + "\n" +
               "Company:\t" + this.MetaCompany + "\nLocation:\t" + this.MetaLocation + "\n" +
               "Date:\t" + this.MetaDate + "\nSource:\t" + this.MetaSource;
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        protected sealed override string GetMetaTile(HtmlNode bodyHtmlNode)
            => this.GetJobMetaFromDivIdInBodyHtmlNode("job-meta-title", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        protected sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetJobMetaFromDivIdInBodyHtmlNode("job-meta-company", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        protected sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetJobMetaFromDivIdInBodyHtmlNode("job-meta-location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        protected sealed override string GetMetaDate(HtmlNode bodyHtmlNode)
            => this.GetJobMetaFromDivIdInBodyHtmlNode("job-meta-date", bodyHtmlNode);

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        protected sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this.GetJobMetaFromDivIdInBodyHtmlNode("job-meta-source", bodyHtmlNode);
        #endregion

        #region PrivateMethods
        /// <summary>Gets the job meta from div identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bodyHtmlNode"></param>
        /// <returns>String meta info</returns>
        private string GetJobMetaFromDivIdInBodyHtmlNode(string id, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//div[@id ='" + id + "']").InnerText.TrimStart().TrimEnd().Trim();
        #endregion
    }
}
