/**
* CorningJobsOffer.cs
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
    /// Defines the <see cref="CorningJobsOffer" />
    /// </summary>
    public class CorningJobsOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="CorningJobsOffer"/> class.</summary>
        public CorningJobsOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CorningJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public CorningJobsOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            bool isExpired =
                bodyHtmlNode.InnerText.IndexOf("this position has been filled", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaTitleId = isExpired ? base.GetMetaTitleId(uri) : this.GetMetaTitleId(uri);
            this.MetaCompany = isExpired ? base.GetMetaCompany(bodyHtmlNode) : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? base.GetMetaLocation(bodyHtmlNode) : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo)
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            this.MetaUri = isExpired ? base.GetMetaUri(uri) : this.GetMetaUri(uri);
            this.MetaSource = uri.AbsoluteUri;
            this.MetaMap = this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "CorningJobs";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1IdInBodyHtmlNode("job-title", bodyHtmlNode);

        /// <summary>Gets the meta title identifier.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override string GetMetaTitleId(Uri uri)
            => uri.AbsolutePath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromSpanItemPropInBodyHtmlNode("hiringOrganization", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromSpanClassInBodyHtmlNode("jobGeoLocation", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            string s = this.GetInnerTextFromSpanItemPropInBodyHtmlNode("datePosted", bodyHtmlNode);
            string seed = ", ";
            int count = 0;

            if (s.Contains(seed))
            {
                today = Convert.ToDateTime(DateTime.Today, this.MetaCultureInfo);
                count = s.Split(new []{seed}, StringSplitOptions.None).Length;

                if (count == 2)
                    today = Convert.ToDateTime(s, this.MetaCultureInfo);
            }

            return today;
        }

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
