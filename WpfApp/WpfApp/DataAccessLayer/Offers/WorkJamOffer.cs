/**
* WorkJamOffer.cs
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
    /// Defines the <see cref="WorkJamOffer" />
    /// </summary>
    public class WorkJamOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="WorkJamOffer"/> class.</summary>
        public WorkJamOffer() : this(null, String.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorkJamOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang">The language.</param>
        public WorkJamOffer(HtmlNode bodyHtmlNode, string lang)
        {
            this.CultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.CultureInfo);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "WorkJam";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this + " MetaTitle";

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this + " MetaCompany";

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this + " MetaLocation";

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
            => base.GetMetaDate(bodyHtmlNode);

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this + " MetaSource";
        #endregion

        #region PrivateMethods
        #endregion
    }
}
