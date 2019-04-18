/**
* JobillicoOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 8:19:27 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="JobillicoOffer" />
    /// </summary>
    public class JobillicoOffer : AbstractOffer
    {
        #region Properties
        /// <summary>Gets the meta title.</summary>
        /// <value>The meta title.</value>
        public string MetaTitle { get; internal set; }

        /// <summary>Gets the meta company.</summary>
        /// <value>The meta company.</value>
        public string MetaCompany { get; internal set; }

        /// <summary>Gets the meta location.</summary>
        /// <value>The meta location.</value>
        public string MetaLocation { get; internal set; }

        /// <summary>Gets the meta date.</summary>
        /// <value>The meta date.</value>
        public string MetaDate { get; internal set; }

        /// <summary>Gets the meta source.</summary>
        /// <value>The meta source.</value>
        public string MetaSource { get; internal set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="JobillicoOffer"/> class.
        /// </summary>
        /// <param name="bodyHtmlNode">The bodyHtmlNode<see cref="HtmlNode"/></param>
        public JobillicoOffer(HtmlNode bodyHtmlNode)
        {
            var v = bodyHtmlNode;
        }
        #endregion
    }
}
