/**
* DiceOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

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
        public DiceOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
            this.MetaTitle = this.GetMetaTile(bodyHtmlNode);
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
        public sealed override string GetMetaTile(HtmlNode bodyHtmlNode)
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
        public sealed override string GetMetaDate(HtmlNode bodyHtmlNode)
            => this + " MetaDate";

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this + " MetaSource";
        #endregion

        #region PrivateMethods
        #endregion
    }
}
