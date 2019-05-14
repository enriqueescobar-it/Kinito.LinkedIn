/**
* ZipRecruiterOffer.cs
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
    /// Defines the <see cref="ZipRecruiterOffer" />
    /// </summary>
    public class ZipRecruiterOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="ZipRecruiterOffer"/> class.</summary>
        public ZipRecruiterOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ZipRecruiterOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public ZipRecruiterOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.CultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            bool isExpired = bodyHtmlNode.InnerText.IndexOf("expired:", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? "Title expired" : this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = isExpired ? "Company expired" : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? "Location expired" : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired
                ? Convert.ToDateTime(base.GetMetaDate(bodyHtmlNode), this.CultureInfo)
                : Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.CultureInfo);
            this.MetaSource = isExpired ? base.GetMetaSource(bodyHtmlNode) : this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = isExpired ? base.GetMetaMap(bodyHtmlNode) : this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "ZipRecruiter";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("job_title", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH3ClassInBodyHtmlNode("inner_wrapper", bodyHtmlNode)
                .Split(new []{"in"}, StringSplitOptions.None)[0].TrimStart().TrimEnd().Trim();

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromSpanDataNameInBodyHtmlNode("address", bodyHtmlNode)
                /*.Split('\n')[1].TrimStart().TrimEnd().Trim()*/;

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = DateTime.Today;
            string s = this.GetInnerTextFromDivClassInBodyHtmlNode("job_more_section", bodyHtmlNode)
                           .Split(new[] { "Posted date:" }, StringSplitOptions.None)[1].TrimStart().TrimEnd().Trim()
                           .Split('\n')[0];
            string seed = " day";

            if (s.Contains(seed))
            {
                int count = int.Parse(s.Split(new[] { seed }, StringSplitOptions.None)[0]);
                today = today.AddDays(-count);
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
