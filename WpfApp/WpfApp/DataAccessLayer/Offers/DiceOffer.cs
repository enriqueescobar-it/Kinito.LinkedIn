/**
* DiceOffer.cs
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
    /// Defines the <see cref="DiceOffer" />
    /// </summary>
    public class DiceOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="DiceOffer"/> class.</summary>
        public DiceOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DiceOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        public DiceOffer(HtmlNode bodyHtmlNode, string lang) : base(bodyHtmlNode, lang)
        {
            this.CultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = this.GetMetaDate(bodyHtmlNode);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "Dice";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("jobTitle", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromSpanIdInBodyHtmlNode("hiringOrganizationName", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromLiClassInBodyHtmlNode("location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            string s = this.GetInnerTextFromLiClassInBodyHtmlNode("posted hidden-xs", bodyHtmlNode)
                           .Split(new[] { "Posted " }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault()
                           .Split(new[] { " ago" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()
                           .Split(new[] { " day" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            int i = int.Parse(s);

            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - i);
        }

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
