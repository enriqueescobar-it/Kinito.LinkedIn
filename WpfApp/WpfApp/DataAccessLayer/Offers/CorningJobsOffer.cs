/**
* CorningJobsOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="CorningJobsOffer" />
    /// </summary>
    public class CorningJobsOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="CorningJobsOffer"/> class.</summary>
        public CorningJobsOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CorningJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public CorningJobsOffer(HtmlNode bodyHtmlNode) : base(bodyHtmlNode)
        {
        }
    }
}
