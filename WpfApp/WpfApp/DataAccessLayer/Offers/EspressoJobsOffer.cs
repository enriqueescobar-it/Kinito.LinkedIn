/**
* EspressoJobsOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;

    using System.Linq;

    /// <summary>
    /// Defines the <see cref="EspressoJobsOffer" />
    /// </summary>
    public class EspressoJobsOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="EspressoJobsOffer"/> class.</summary>
        public EspressoJobsOffer() : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EspressoJobsOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="host"></param>
        public EspressoJobsOffer(HtmlNode bodyHtmlNode, string host) : base(bodyHtmlNode, host)
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
        public sealed override string ToString() => "Espresso-Jobs";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTile(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("title-login", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH3ClassInBodyHtmlNode("value", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetUlHtmlNodeNodeFromDivClassInBodyHtmlNode("vacancy__item-content", bodyHtmlNode)
                .ChildNodes[5].InnerText.Replace("\t", "").Replace("\n", " ").TrimStart().TrimEnd().Trim()
                .Split(':').FirstOrDefault().TrimStart().TrimEnd().Trim();

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaDate(HtmlNode bodyHtmlNode)
            => this.GetUlHtmlNodeNodeFromDivClassInBodyHtmlNode("vacancy__item-content", bodyHtmlNode)
                .ChildNodes[9].InnerText.Replace("\t", "").Replace("\n", " ").TrimStart().TrimEnd().Trim()
                .Split(':').FirstOrDefault().TrimStart().TrimEnd().Trim();

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => this + " MetaSource";
        #endregion

        #region PrivateMethods
        /// <summary>Gets the ul HTML node node from div class in body HTML node.</summary>
        /// <param name="divClass">The div class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        private HtmlNode GetUlHtmlNodeNodeFromDivClassInBodyHtmlNode(string divClass, HtmlNode bodyHtmlNode)
            => this.GetHtmlNodeFromDivClassInBodyHtmlNode(divClass, bodyHtmlNode).ChildNodes[1];
        #endregion
    }
}
