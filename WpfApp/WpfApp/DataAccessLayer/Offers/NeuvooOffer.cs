/**
* NeuvooOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 3:30:59 PM
**/
namespace WpfApp.DataAccessLayer.Offers
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
        public sealed override string ToString() => "Neuvoo";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaTile(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-title", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-company", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaDate(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-date", bodyHtmlNode);

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-source", bodyHtmlNode);
        #endregion

        #region PrivateMethods
        #endregion
    }
}
