/**
* ItJobsOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 22-04-2019
* OR 4/22/2019 1:06:18 PM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    using System;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ItJobsOffer" />
    /// </summary>
    public class ItJobsOffer : AbstractOffer
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="ItJobsOffer"/> class.</summary>
        public ItJobsOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public ItJobsOffer(HtmlNode bodyHtmlNode)
        {
            this.MetaTitle = this.GetMetaTile(bodyHtmlNode);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = this.GetMetaDate(bodyHtmlNode);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
        }
        #endregion

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "ItJobs";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTile(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("offer-title", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
        {
            string[] stringArray = bodyHtmlNode.Descendants("a")
                .First(x => x.Attributes["class"] != null &&
                            x.Attributes["class"].Value == "offer-employer-more")
                .Attributes["href"].Value.Replace("//", "/")
                .TrimEnd('/').Split('/');
            Array.Resize(ref stringArray, stringArray.Length - 1);

            return stringArray.LastOrDefault();
        }

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromDivClassInBodyHtmlNode("offer-location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaDate(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromSpanClassInBodyHtmlNode("offer-date", bodyHtmlNode);

        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => "ItJobs MetaSource";
        #endregion

        #region PrivateMethods
        #endregion
    }
}
