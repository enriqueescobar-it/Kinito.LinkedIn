/**
* AbstractOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 3:30:07 PM
**/
namespace WpfApp.DataAccessLayer
{
    using System;

    using Newtonsoft.Json;

    using HtmlAgilityPack;

    /// <summary>
    /// Defines the <see cref="AbstractOffer" />
    /// </summary>
    public class AbstractOffer : IParseable
    {
        #region AbstractPorperties
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

        #region AbstractConstructor
        /// <summary>Initializes a new instance of the <see cref="AbstractOffer"/> class.</summary>
        public AbstractOffer() : this(null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AbstractOffer"/> class.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public AbstractOffer(HtmlNode bodyHtmlNode)
        {
        }
        #endregion

        #region PublicMethods
        /// <summary>Converts to JSON.</summary>
        /// <returns>JSON representation string</returns>
        public string ToJson() => JsonConvert.SerializeObject(this);
        #endregion

        #region PublicOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => "AbstractOffer";
        #endregion

        #region ProtectedVirtualMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public virtual string GetMetaTile(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public virtual string GetMetaCompany(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public virtual string GetMetaLocation(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public virtual string GetMetaDate(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        /// <returns></returns>
        public virtual string GetMetaSource(HtmlNode bodyHtmlNode) => String.Empty;
        #endregion
    }
}
