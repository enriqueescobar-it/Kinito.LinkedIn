/**
* EspressoJobsOffer.cs
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
    /// Defines the <see cref="EspressoJobsOffer" />
    /// </summary>
    public class EspressoJobsOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="EspressoJobsOffer"/> class.</summary>
        public EspressoJobsOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EspressoJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public EspressoJobsOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            bool isExpired =
                bodyHtmlNode.InnerText.IndexOf("ev, marketing & Web", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? base.GetMetaTitle(bodyHtmlNode) : this.GetMetaTitle(bodyHtmlNode);
            this.MetaTitleId = isExpired ? base.GetMetaTitleId(uri) : this.GetMetaTitleId(uri);
            this.MetaCompany = isExpired ? base.GetMetaCompany(bodyHtmlNode) : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? base.GetMetaLocation(bodyHtmlNode) : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo)
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            this.MetaUri = isExpired ? base.GetMetaUri(uri) : this.GetMetaUri(uri);
            this.MetaSource = isExpired ? this.MetaUri.AbsoluteUri : this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = isExpired ? base.GetMetaMap(bodyHtmlNode) : this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "Espresso-Jobs";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("title-login", bodyHtmlNode);

        /// <summary>Gets the meta title identifier.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override string GetMetaTitleId(Uri uri)
            => (this.MetaCultureInfo == new CultureInfo("fr"))
                ? uri.AbsolutePath.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries)[0]
                : uri.AbsolutePath.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries)[1];

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH3ClassInBodyHtmlNode("value", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => base.GetUlHtmlNodeNodeFromDivClassInBodyHtmlNode("vacancy__item-content", bodyHtmlNode)
                .ChildNodes[5].InnerText.Replace("\t", "").Replace("\n", " ").TrimStart().TrimEnd().Trim()
                .Split(':').LastOrDefault().TrimStart().TrimEnd().Trim();

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = base.GetMetaDate(bodyHtmlNode);
            string s = base.GetUlHtmlNodeNodeFromDivClassInBodyHtmlNode("vacancy__item-content", bodyHtmlNode)
                           .ChildNodes[9].InnerText.Replace("\t", "").Replace("\n", " ").TrimStart().TrimEnd().Trim()
                           .Split(':').LastOrDefault().TrimStart().TrimEnd().Trim();

            if (!String.IsNullOrWhiteSpace(s))
            {
                today = DateTime.Today;
                int count = s.Count(Char.IsWhiteSpace);

                if (count == 2)
                    today = Convert.ToDateTime(s, this.MetaCultureInfo);
            }

            return today;
        }

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
