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
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "Dice";
        #endregion
    }
}
