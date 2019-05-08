/**
* EmploisTiOffer.cs
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
    /// Defines the <see cref="EmploisTiOffer" />
    /// </summary>
    public class EmploisTiOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="EmploisTiOffer"/> class.</summary>
        public EmploisTiOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EmploisTiOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        public EmploisTiOffer(HtmlNode bodyHtmlNode, string lang) : base(bodyHtmlNode)
        {
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.Chomp(this.GetMetaLocation(bodyHtmlNode));
            this.MetaDate = Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), new CultureInfo(lang));
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "EmploisTI";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("page-title", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetHtmlNodeFromDivIdInBodyHtmlNode("ajax-box-content", bodyHtmlNode)
                .SelectSingleNode("//article").ChildNodes.LastOrDefault().ChildNodes[3].ChildNodes[1]
                .InnerHtml.TrimStart().TrimEnd().Trim()
                .Replace("\t", "").Replace(" \n", "").Replace("\n", "")
                .Split(new[] { "span" }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Replace("<", ">").Replace("/", ">").Replace(">", "");

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetHtmlNodeFromDivIdInBodyHtmlNode("ajax-box-content", bodyHtmlNode)
                .SelectSingleNode("//article").ChildNodes.LastOrDefault().ChildNodes[3].ChildNodes[3]
                .InnerHtml.TrimStart().TrimEnd().Trim()
                .Replace("\t", "").Replace(" \n", "").Replace("\n", "")
                .Split(new[] { "span" }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Replace("<", ">").Replace("/", ">").Replace(">", "");

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
            => base.GetMetaDate(bodyHtmlNode);

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
