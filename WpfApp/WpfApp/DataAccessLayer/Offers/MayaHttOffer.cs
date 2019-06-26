/**
* MayaHttOffer.cs
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
    /// Defines the <see cref="MayaHttOffer" />
    /// </summary>
    public class MayaHttOffer : AbstractOffer, IParseable
    {
        /// <summary>Initializes a new instance of the <see cref="MayaHttOffer"/> class.</summary>
        public MayaHttOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MayaHttOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public MayaHttOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaTitleId = this.GetMetaTitleId(uri);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaCompanyId = this.GetMetaCompanyId(uri);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "MayaHtt";
        #endregion

        #region InterfaceMethods
        /// <summary>Gets the meta title identifier.</summary>
        /// <param name="uri">The URI.</param>
        public string GetMetaTitleId(Uri uri) => base.MetaTitleId;

        /// <summary>Gets the meta company identifier.</summary>
        /// <param name="uri">The URI.</param>
        public string GetMetaCompanyId(Uri uri) => base.MetaCompanyId;
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
