/**
* ZipRecruiterOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using System;
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="ZipRecruiterOffer" />
    /// </summary>
    public class ZipRecruiterOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="ZipRecruiterOffer"/> class.</summary>
        public ZipRecruiterOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ZipRecruiterOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public ZipRecruiterOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
            bool isExpired = bodyHtmlNode.InnerText.IndexOf("expired:", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? "ZipTitle" : this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = isExpired ? "ZipCompany" : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? "ZipLocation" : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired ? "ZipDate" : this.GetMetaDate(bodyHtmlNode);
            this.MetaSource = isExpired ? "ZipSource" : this.GetMetaSource(bodyHtmlNode);
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
            => this.GetInnerTextFromDivClassInBodyHtmlNode("job_more_section", bodyHtmlNode)
                .Split('\n')[1].TrimStart().TrimEnd().Trim();

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaDate(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivClassInBodyHtmlNode("job_more_section", bodyHtmlNode)
                .Split(new []{"Posted date:"}, StringSplitOptions.None)[1].TrimStart().TrimEnd().Trim()
                .Split('\n')[0];

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this + " MetaSource";
        #endregion

        #region PrivateMethods
        #endregion
    }
}
