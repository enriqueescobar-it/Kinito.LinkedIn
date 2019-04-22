/**
* ItJobsOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 22-04-2019
* OR 4/22/2019 1:06:18 PM
**/
namespace WpfApp.DataAccessLayer.Jobs
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="ItJobsOffer" />
    /// </summary>
    public class ItJobsOffer : AbstractOffer
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="ItJobsOffer"/> class.</summary>
        public ItJobsOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public ItJobsOffer(HtmlNode bodyHtmlNode)
        {
            this.MetaTitle = this.GetMetaTile(bodyHtmlNode);
        }
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        protected sealed override string GetMetaTile(HtmlNode bodyHtmlNode)
            => this.GetJobMetaFromH1ClassInBodyHtmlNode("offer-title", bodyHtmlNode);
        #endregion

        #region PrivateMethods
        /// <summary>Gets the job meta from class identifier.</summary>
        /// <param name="h1Class">The identifier H1 class.</param>
        /// <param name="bodyHtmlNode"></param>
        /// <returns>String meta info</returns>
        private string GetJobMetaFromH1ClassInBodyHtmlNode(string h1Class, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//h1[@class ='" + h1Class + "']").InnerText.TrimStart().TrimEnd().Trim();
        #endregion
    }
}
