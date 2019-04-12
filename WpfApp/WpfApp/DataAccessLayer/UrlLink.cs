/**
* UrlLink.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 12-04-2019
* OR 4/12/2019 4:11:48 PM
**/

using System.Text;

namespace WpfApp.DataAccessLayer
{
    using System;

    /// <summary>
    /// Defines the <see cref="UrlLink" />
    /// </summary>
    public class UrlLink
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Url
        /// </summary>
        public Uri Url { get; internal set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlLink"/> class.
        /// - Scheme
        /// - Host
        /// - Port
        /// - Path
        /// - Query
        /// - Fragment
        /// </summary>
        /// <param name="link">The link<see cref="string"/></param>
        public UrlLink(string link)
        {
            link = link.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            Uri uri = null;

            if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
                Uri.TryCreate(link, UriKind.Absolute, out uri);

            this.Url = uri ?? new Uri(link, UriKind.Absolute);
        }
        #endregion
    }
}
