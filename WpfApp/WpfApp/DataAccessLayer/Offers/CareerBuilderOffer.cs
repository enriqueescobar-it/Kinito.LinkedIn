/**
* CareerBuilderOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the <see cref="CareerBuilderOffer" />
    /// </summary>
    public class CareerBuilderOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="CareerBuilderOffer"/> class.</summary>
        public CareerBuilderOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CareerBuilderOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="uri"></param>
        /// <param name="lang"></param>
        public CareerBuilderOffer(HtmlNode bodyHtmlNode, Uri uri, string lang) : base(bodyHtmlNode)
        {
            bool isExpired =
                bodyHtmlNode.InnerText.IndexOf("expired", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? "Title expired" : this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = isExpired ? "Company expired" : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? "Location expired" : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), new CultureInfo(lang))
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), new CultureInfo(lang));
            this.MetaSource = isExpired ? "Source expired" : uri.AbsoluteUri;
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "CareerBuilder";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this + " MetaTitle";

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this + " MetaCompany";

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this + " MetaLocation";

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
            => base.GetMetaDate(bodyHtmlNode);

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this + " MetaSource";
        #endregion

        #region PrivateMethods
        #endregion
    }
}
