/**
* NeuvooOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 3:30:59 PM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the <see cref="NeuvooOffer" />
    /// </summary>
    public class NeuvooOffer : AbstractOffer
    {
        #region Properties
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="NeuvooOffer"/> class.</summary>
        public NeuvooOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="NeuvooOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public NeuvooOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            bool isExpired = bodyHtmlNode.InnerText
                            .IndexOf("We are sorry the job you are looking for is no longer available.",
                            StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? base.GetMetaTitle(bodyHtmlNode)  : this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = isExpired ? base.GetMetaCompany(bodyHtmlNode) : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? base.GetMetaLocation(bodyHtmlNode) : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo)
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            this.MetaUri = isExpired ? base.GetMetaUri(uri) : this.GetMetaUri(uri);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = isExpired ? base.GetMetaMap(bodyHtmlNode) : this.GetMetaMap(bodyHtmlNode);
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
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-title", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-company", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = base.GetMetaDate(bodyHtmlNode);
            string s = this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-date", bodyHtmlNode);
            string seed = "d ago";
            int count = 0;

            if (s.Contains(" ago"))
            {
                today = DateTime.Today;

                if (s.Contains(seed))
                {
                    s = s.Split(new[] { seed }, StringSplitOptions.None)[0];
                    count = int.Parse(s);
                    today = today.AddDays(-count);
                }

            }

            return today;
        }

        /// <summary>Gets the meta URI.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override Uri GetMetaUri(Uri uri)
            => (uri?.AbsoluteUri.Contains("?") == true)
                ? new Uri(uri.AbsoluteUri.Split(new[] { "&pag=" }, StringSplitOptions.None)[0])
                : uri;

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
        {
            string s = this.GetInnerTextFromDivIdInBodyHtmlNode("job-meta-source", bodyHtmlNode);

            return String.IsNullOrWhiteSpace(s)
                ? base.GetMetaSource(bodyHtmlNode) + this.MetaCompany.Replace(" ", "+") + "+" +
                  this.MetaLocation.Replace(" ", "+")
                : s;
        }

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
