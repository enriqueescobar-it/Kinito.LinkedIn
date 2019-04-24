/**
* WorkHoppersOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="WorkHoppersOffer" />
    /// </summary>
    public class WorkHoppersOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="WorkHoppersOffer"/> class.</summary>
        public WorkHoppersOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorkHoppersOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public WorkHoppersOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "WorkHoppers";
        #endregion
    }
}
