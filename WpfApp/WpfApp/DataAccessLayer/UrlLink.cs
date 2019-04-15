/**
* UrlLink.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 12-04-2019
* OR 4/12/2019 4:11:48 PM
**/

namespace WpfApp.DataAccessLayer
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="UrlLink" />
    /// </summary>
    public class UrlLink
    {
        #region Properties
        /// <summary>Gets the absolute path.</summary>
        /// <value>The absolute path.</value>
        public string AbsolutePath { get; internal set; }

        /// <summary>Gets the host.</summary>
        /// <value>The host.</value>
        public string Host { get; internal set; }

        /// <summary>Returns true if ... is valid.</summary>
        /// <value>The is valid.</value>
        public bool IsValid { get; internal set; }

        /// <summary>Gets the link.</summary>
        /// <value>The link.</value>
        public string Link { get; internal set; }

        /// <summary>Gets the port.</summary>
        /// <value>The port.</value>
        public int? Port { get; internal set; }

        /// <summary>Gets the query.</summary>
        /// <value>The query.</value>
        public string Query { get; internal set; }

        /// <summary>Gets the scheme.</summary>
        /// <value>The scheme.</value>
        public string Scheme { get; internal set; }

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
            this.Link = link.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            Uri uri = null;

            if (Uri.IsWellFormedUriString(this.Link, UriKind.Absolute))
                Uri.TryCreate(this.Link, UriKind.Absolute, out uri);

            this.Url = uri ?? new Uri(this.Link, UriKind.Absolute);
            this.IsValid = (this.Url != null) && this.SetValidity(this.Url);
            this.AbsolutePath = this.Url?.AbsolutePath;
            this.Host = this.Url?.Host;
            this.Port = this.Url?.Port;
            this.Query = this.Url?.Query;
            this.Scheme = this.Url?.Scheme;

        }
        #endregion

        #region PrivateMethods
        /// <summary>Sets the validity.</summary>
        /// <param name="aUri"></param>
        private bool SetValidity(Uri aUri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage result = httpClient.GetAsync(aUri).Result;
                HttpStatusCode statusCode = result.StatusCode;

                switch (statusCode)
                {

                    case HttpStatusCode.Accepted:
                        return true;
                    case HttpStatusCode.OK:
                        return true;
                    default:
                        return false;
                }
            }
        }
        #endregion
    }
}
