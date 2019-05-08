/**
* JobBoomOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 24-04-2019
* OR 4/24/2019 10:52:10 AM
**/
namespace WpfApp.DataAccessLayer.Offers
{
    using HtmlAgilityPack;
    using System;

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
            this.MetaTitle = this.GetMetaTitle(bodyHtmlNode);
            this.MetaCompany = this.GetMetaCompany(bodyHtmlNode);
            this.MetaLocation = this.GetMetaLocation(bodyHtmlNode);
            this.MetaDate = this.GetMetaDate(bodyHtmlNode);
            this.MetaSource = this.GetMetaSource(bodyHtmlNode);
            this.MetaMap = this.GetMetaMap(bodyHtmlNode);
        }

        #region PublicSealedOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public sealed override string ToString() => "JobBoom";
        #endregion

        #region ProtectedSealedOverrideMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaTitle(HtmlNode bodyHtmlNode)
            => this.GetInnerTextFromH1ClassInBodyHtmlNode("jobDescHeaderTitle", bodyHtmlNode);

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaCompany(HtmlNode bodyHtmlNode)
            => this.Chomp(this.GetInnerTextFromH2ClassInBodyHtmlNode("hideOnSticky", bodyHtmlNode)
                .Replace("\t", "").Replace(" \n", "").Replace("\n\n", "\n").Split('\n')[0]);

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override string GetMetaLocation(HtmlNode bodyHtmlNode)
            => this.Chomp(this.GetInnerTextFromH2ClassInBodyHtmlNode("hideOnSticky", bodyHtmlNode)
                .Replace("\t", "").Replace(" \n", "").Replace("\n\n", "\n").Split('\n')[1]);

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public sealed override DateTime GetMetaDate(HtmlNode bodyHtmlNode)
        {
            DateTime today = base.GetMetaDate(bodyHtmlNode);
            string s = this.GetInnerTextFromSpanClassInBodyHtmlNode("jobDescHeaderJobPublishedStatus", bodyHtmlNode);
            string seed = "Publié il y a ";
            int count = 0;

            if (s.Contains(seed))
            {
                s = s.Split(new[] { seed }, StringSplitOptions.None)[1];
                seed = " jour";
                today = DateTime.Today;

                if (s.Contains(seed))
                {
                    count = int.Parse(s.Split(new[] {seed}, StringSplitOptions.None)[0]);
                    today = today.AddDays(-count);
                }
            }

            return today;
        }

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
