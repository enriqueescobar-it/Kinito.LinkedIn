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
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="CareerBuilderOffer" />
    /// </summary>
    public class CareerBuilderOffer : AbstractOffer, IParseable
    {
        /// <summary>Initializes a new instance of the <see cref="CareerBuilderOffer"/> class.</summary>
        public CareerBuilderOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CareerBuilderOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public CareerBuilderOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            bool isExpired =
                bodyHtmlNode.InnerText.IndexOf("Has Expired...", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? base.GetMetaTitle(bodyHtmlNode) : this.GetMetaTitle(bodyHtmlNode);
            this.MetaTitleId = isExpired ? base.MetaTitleId : this.GetMetaTitleId(uri);
            this.MetaCompany = isExpired ? base.GetMetaCompany(bodyHtmlNode) : this.GetMetaCompany(bodyHtmlNode);
            this.MetaCompanyId = this.GetMetaCompanyId(uri);
            this.MetaLocation = isExpired ? base.GetMetaLocation(bodyHtmlNode) : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo)
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            this.MetaUri = isExpired ? base.GetMetaUri(uri) : this.GetMetaUri(uri);
            this.MetaSource = uri.AbsoluteUri;
            this.MetaMap = isExpired ? base.GetMetaMap(bodyHtmlNode) : this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "CareerBuilder";
        #endregion

        #region InterfaceMethods
        /// <summary>Gets the meta title identifier.</summary>
        /// <param name="uri">The URI.</param>
        public string GetMetaTitleId(Uri uri)
            => uri.AbsolutePath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

        /// <summary>Gets the meta company identifier.</summary>
        /// <param name="uri">The URI.</param>
        public string GetMetaCompanyId(Uri uri) => base.MetaCompanyId;
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => base.GetInnerTextFromSpanIdInBodyHtmlNode("CBBody_JobTitle", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => base.GetInnerTextFromSpanIdInBodyHtmlNode("CBBody_CompanyName", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => base.GetInnerTextFromSpanIdInBodyHtmlNode("CBBody_Location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
            => Convert.ToDateTime(base.GetInnerTextFromSpanIdInBodyHtmlNode("CBBody_Posted", bodyHtmlNode), this.MetaCultureInfo);


        /// <summary>Gets the meta URI.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override Uri GetMetaUri(Uri uri)
            => (uri?.AbsoluteUri.Contains("?") == true)
                ? new Uri(uri.AbsoluteUri.Split('?')[0])
                : uri;

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => base.GetMetaSource(bodyHtmlNode) + this.MetaCompany.Replace(" ", "+") + "+" +
               this.MetaLocation.Replace(" ", "+");

        /// <summary>Gets the meta map.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaMap(HtmlNode bodyHtmlNode)
            => base.GetMetaMap(bodyHtmlNode) + this.MetaCompany.Replace(" ", "+") + "+" +
               this.MetaLocation.Replace(" ", "+");
        #endregion

        #region PrivateMethods
        #endregion
    }
}
