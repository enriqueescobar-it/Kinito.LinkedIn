/**
* IParseable.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 25-04-2019
* OR 4/25/2019 12:34:08 AM
**/
namespace WpfApp.DataAccessLayer
{
    using HtmlAgilityPack;

    #region Interfaces
    /// <summary>
    /// Defines the <see cref="IParseable" />
    /// </summary>
    interface IParseable
    {
        #region Methods

        #region PublicOverrideMethods
        /// <summary>
        /// The ToJson
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        string ToJson();
        #endregion

        string GetMetaTile(HtmlNode bodyHtmlNode);

        #endregion
    }

    #endregion
}
