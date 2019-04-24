/**
* JobBoomOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="JobBoomOffer" />
    /// </summary>
    public class JobBoomOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="JobBoomOffer"/> class.</summary>
        public JobBoomOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JobBoomOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public JobBoomOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
        }
    }
}
