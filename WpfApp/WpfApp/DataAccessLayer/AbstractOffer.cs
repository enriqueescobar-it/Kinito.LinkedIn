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
    public class AbstractOffer
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

        /// <summary>Gets the inner text from a class in body HTML node.</summary>
        /// <param name="aClass">a class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public string GetInnerTextFromAClassInBodyHtmlNode(string aClass, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//a[@class ='" + aClass + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Gets the inner text from div class in body HTML node.</summary>
        /// <param name="divClass">The div class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public string GetInnerTextFromDivClassInBodyHtmlNode(string divClass, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//div[@class ='" + divClass + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Gets the HTML node from div class in body HTML node.</summary>
        /// <param name="divClass">The div class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public HtmlNode GetHtmlNodeFromDivClassInBodyHtmlNode(string divClass, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//div[@class ='" + divClass + "']");

        /// <summary>Gets the inner text from div identifier.</summary>
        /// <param name="divId">The div identifier.</param>
        /// <param name="bodyHtmlNode"></param>
        public string GetInnerTextFromDivIdInBodyHtmlNode(string divId, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//div[@id ='" + divId + "']").InnerText.TrimStart().TrimEnd().Trim();


        /// <summary>Gets the HTML node from div identifier in body HTML node.</summary>
        /// <param name="divId">The div identifier.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public HtmlNode GetHtmlNodeFromDivIdInBodyHtmlNode(string divId, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//div[@id ='" + divId + "']");

        /// <summary>Gets the inner text from class identifier.</summary>
        /// <param name="h1Class">The identifier H1 class.</param>
        /// <param name="bodyHtmlNode"></param>
        public string GetInnerTextFromH1ClassInBodyHtmlNode(string h1Class, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//h1[@class ='" + h1Class + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Gets the inner text from class identifier.</summary>
        /// <param name="h2Class">The identifier H2 class.</param>
        /// <param name="bodyHtmlNode"></param>
        public string GetInnerTextFromH2ClassInBodyHtmlNode(string h2Class, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//h2[@class ='" + h2Class + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Gets the inner text from h3 class in body HTML node.</summary>
        /// <param name="h3Class">The h3 class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public string GetInnerTextFromH3ClassInBodyHtmlNode(string h3Class, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//h3[@class ='" + h3Class + "']").InnerText.TrimStart().TrimEnd().Trim();


        /// <summary>Gets the inner text from td class in body HTML node.</summary>
        /// <param name="tdClass">The td class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public string GetInnerTextFromTdClassInBodyHtmlNode(string tdClass, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//td[@class ='" + tdClass + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Gets the inner text from span class in body HTML node.</summary>
        /// <param name="spanClass">The span class.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public string GetInnerTextFromSpanClassInBodyHtmlNode(string spanClass, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//span[@class ='" + spanClass + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Gets the inner text from span data name in body HTML node.</summary>
        /// <param name="spanDataName">Name of the span data.</param>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public string GetInnerTextFromSpanDataNameInBodyHtmlNode(string spanDataName, HtmlNode bodyHtmlNode)
            => bodyHtmlNode.SelectSingleNode("//span[@data-name ='" + spanDataName + "']").InnerText.TrimStart().TrimEnd().Trim();

        /// <summary>Chomps the specified string to chomp.</summary>
        /// <param name="stringToChomp">The string to chomp.</param>
        /// <returns>String chomp</returns>
        public string Chomp(string stringToChomp)
            => stringToChomp.TrimStart('\t').TrimEnd('\t').Trim('\t')
                .TrimStart('\n').TrimEnd('\n').Trim('\n')
                .TrimStart().TrimEnd().Trim();
        #endregion

        #region ProtectedVirtualMethods
        /// <summary>Gets the meta tile.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public virtual string GetMetaTile(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta company.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public virtual string GetMetaCompany(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta location.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public virtual string GetMetaLocation(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta date.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public virtual string GetMetaDate(HtmlNode bodyHtmlNode) => String.Empty;

        /// <summary>Gets the meta source.</summary>
        /// <param name="bodyHtmlNode">The body HTML node.</param>
        public virtual string GetMetaSource(HtmlNode bodyHtmlNode) => String.Empty;
        #endregion

        #region PrivateMethods
        #endregion
    }
}
