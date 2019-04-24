/**
* ZipRecruiterOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="ZipRecruiterOffer" />
    /// </summary>
    public class ZipRecruiterOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="ZipRecruiterOffer"/> class.</summary>
        public ZipRecruiterOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ZipRecruiterOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public ZipRecruiterOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
        }
    }
}
