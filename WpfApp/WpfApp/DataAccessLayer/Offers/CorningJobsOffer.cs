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

    /// <summary>
    /// Defines the <see cref="CorningJobsOffer" />
    /// </summary>
    public class CorningJobsOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="CorningJobsOffer"/> class.</summary>
        public CorningJobsOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CorningJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public CorningJobsOffer(HtmlNode bodyHtmlNode, string lang, Uri uri) : base(bodyHtmlNode, lang)
        {
            this.CultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            bool isExpired =
                bodyHtmlNode.InnerText.IndexOf("this position has been filled", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = isExpired ? "Company expired" : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? "Location expired" : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.CultureInfo)
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.CultureInfo);
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

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this + " MetaCompany";

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this + " MetaLocation";

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            string s = this.GetInnerTextFromSpanItemPropInBodyHtmlNode("datePosted", bodyHtmlNode);
            return base.GetMetaDate(bodyHtmlNode);
        }

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this + " MetaSource";

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
