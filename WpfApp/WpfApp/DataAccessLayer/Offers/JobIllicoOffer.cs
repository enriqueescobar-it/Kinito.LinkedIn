/**
* JobillicoOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 8:19:27 PM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the <see cref="JobIllicoOffer" />
    /// </summary>
    public class JobIllicoOffer : AbstractOffer
    {
        #region Properties
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="JobIllicoOffer"/> class.</summary>
        public JobIllicoOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JobIllicoOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public JobIllicoOffer(HtmlNode bodyHtmlNode, string lang, Uri uri) : base(bodyHtmlNode)
        {
            bool isExpired =
                    bodyHtmlNode.InnerText.IndexOf("expired", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    bodyHtmlNode.InnerText.IndexOf("deactivated", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    bodyHtmlNode.InnerText.IndexOf("expirée", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    bodyHtmlNode.InnerText.IndexOf("désactivée", StringComparison.InvariantCultureIgnoreCase) >= 0;
            this.MetaTitle = isExpired ? "Title expired" : this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = isExpired ? "Company expired" : this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = isExpired ? "Location expired" : this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = isExpired ? base.GetMetaDate(bodyHtmlNode) : this.GetMetaDate(bodyHtmlNode);
            this.MetaSource = isExpired ? uri.AbsoluteUri : this.GetMetaSource(bodyHtmlNode);
        }
        #endregion

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "JobIllico";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("h1-class art-head", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH2ClassInBodyHtmlNode("companyName", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetHtmlNodeFromDivClassInBodyHtmlNode("main-article-content col-md-8", bodyHtmlNode)
                .SelectSingleNode("//p//a//span").InnerText.Trim().TrimStart().TrimEnd()
                .Replace(Environment.NewLine, "").Replace("    ","");

        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
            => DateTime.Today;

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => @"https://www.google.com/search?q=" + this.MetaCompany.Replace(" ", "+") + "+" +
               this.MetaLocation.Replace(" ", "+");
        #endregion

        #region PrivateMethods
        #endregion
    }
}
