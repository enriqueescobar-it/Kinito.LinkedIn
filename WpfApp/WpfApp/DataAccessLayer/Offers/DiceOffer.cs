/**
* DiceOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="DiceOffer" />
    /// </summary>
    public class DiceOffer : AbstractOffer
    {
        /// <summary>Initializes a new instance of the <see cref="DiceOffer"/> class.</summary>
        public DiceOffer() : this(null, String.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DiceOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <param name="lang"></param>
        /// <param name="uri"></param>
        public DiceOffer(HtmlNode bodyHtmlNode, string lang, Uri uri)
        {
            this.MetaCultureInfo = (!String.IsNullOrWhiteSpace(lang))
                ? new CultureInfo(lang)
                : CultureInfo.InvariantCulture;
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaTitleId = this.GetMetaTitleId(uri);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = Convert.ToDateTime(this.GetMetaDate(bodyHtmlNode), this.MetaCultureInfo);
            this.MetaUri = this.GetMetaUri(uri);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "Dice";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("jobTitle", bodyHtmlNode);

        /// <summary>Gets the meta title identifier.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override string GetMetaTitleId(Uri uri)
            => uri.AbsolutePath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromSpanIdInBodyHtmlNode("hiringOrganizationName", bodyHtmlNode);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromLiClassInBodyHtmlNode("location", bodyHtmlNode);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = base.GetMetaDate(bodyHtmlNode);
            string s = this.GetInnerTextFromLiClassInBodyHtmlNode("posted hidden-xs", bodyHtmlNode)
                           .Split(new[] { "Posted " }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault()/*
                           .Split(new[] { " ago" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()*/;
            string seed = " ago";
            int count = 0;

            if (s.Contains(seed))
            {
                s = s.Split(new[] { seed }, StringSplitOptions.None).FirstOrDefault();
                seed = " day";
                today = DateTime.Today;

                if (s.Contains(seed))
                {
                    count = int.Parse(s.Split(new[] { seed }, StringSplitOptions.None).FirstOrDefault());
                    today = today.AddDays(-count);
                }
            }

            return today;
        }

        /// <summary>Gets the meta URI.</summary>
        /// <param name="uri">The URI.</param>
        public sealed override Uri GetMetaUri(Uri uri)
            => (uri?.AbsoluteUri.Contains("?") == true)
                ? new Uri(uri.AbsoluteUri.Split('?')[0])
                : uri;

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaSource(HtmlNode bodyHtmlNode)
            => base.GetMetaSource(bodyHtmlNode) + this.MetaCompany.Replace(" ", "+") + "+" +
               this.MetaLocation.Replace(" ", "+");

        /// <summary>Gets the meta map.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaMap(HtmlNode bodyHtmlNode)
            => base.GetMetaMap(bodyHtmlNode) + this.MetaCompany.Replace(" ", "+") + "+" +
               this.MetaLocation.Replace(" ", "+");
        #endregion

        #region PrivateMethods
        #endregion
    }
}
