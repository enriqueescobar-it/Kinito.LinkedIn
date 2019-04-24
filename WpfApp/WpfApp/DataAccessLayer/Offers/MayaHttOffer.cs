/**
* MayaHttOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="MayaHttOffer" />
    /// </summary>
    public class MayaHttOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="MayaHttOffer"/> class.</summary>
        public MayaHttOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MayaHttOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public MayaHttOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
        }
    }
}
