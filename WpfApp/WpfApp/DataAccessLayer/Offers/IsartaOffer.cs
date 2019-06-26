/**
* IsartaOffer.cs
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
    /// Defines the <see cref="IsartaOffer" />
    /// </summary>
    public class IsartaOffer : AbstractOffer, IParseable
    {
        /// <summary>Initializes a new instance of the <see cref="IsartaOffer"/> class.</summary>
        public IsartaOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="IsartaOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public IsartaOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaTitleId = this.GetMetaTitleId(uri);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaCompanyId = this.GetMetaCompanyId(uri);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = this.GetMetaDate(bodyHtmlNode);
            this.MetaUri = this.GetMetaUri(uri);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "Isarta";
        #endregion

        #region InterfaceMethods
        /// <summary>Gets the meta title identifier.</summary>
        /// <param name="uri">The URI.</param>
        public string GetMetaTitleId(Uri uri)
            => uri.Query.Split(new[] { "&utm_source" }, StringSplitOptions.RemoveEmptyEntries)[0]
                .Split('=').LastOrDefault();

        /// <summary>Gets the meta company identifier.</summary>
        /// <param name="uri">The URI.</param>
        public string GetMetaCompanyId(Uri uri) => base.MetaCompanyId;
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH2ClassInBodyHtmlNode("offreEmploi", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("offrCmpgn", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH3ClassInBodyHtmlNode("Lieu", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = base.GetMetaDate(bodyHtmlNode);
            string s = this.GetInnerTextFromTdClassInBodyHtmlNode("table table-curved", bodyHtmlNode)
                        .Split(':')[1].Replace(" \t", "").Split('\t')[0].TrimStart().TrimEnd().Trim()
                        .Replace("&nbsp;", "");

            if (!String.IsNullOrWhiteSpace(s))
            {
                today = Convert.ToDateTime(DateTime.Today, this.MetaCultureInfo);
                int count = s.Split('/').Length;

                if (count == 3)
                    today = Convert.ToDateTime(s, this.MetaCultureInfo);
            }

            return Convert.ToDateTime(s, this.MetaCultureInfo);
        }

        /// <summary>Gets the meta URI.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override Uri GetMetaUri(Uri uri)
            => (uri?.AbsoluteUri.Contains("?") == true)
                ? new Uri(uri.AbsoluteUri.Split(new[] { "&utm_source" }, StringSplitOptions.None)[0])
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
