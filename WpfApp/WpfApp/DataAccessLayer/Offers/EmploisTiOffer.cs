/**
* EmploisTiOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

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
        public EmploisTiOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "EmploisTI";
        #endregion
    }
}
