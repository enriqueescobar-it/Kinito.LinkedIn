/**
* WebJob.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 16-04-2019
* OR 4/16/2019 12:39:07 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="WebJob" />
    /// </summary>
    public class WebJob
    {
        #region Properties
        /// <summary>
        /// Gets or sets the CultureInfo
        /// </summary>
        public CultureInfo CultureInfo { get; internal set; }

        /// <summary>Gets the XML culture information.</summary>
        /// <value>The XML culture information.</value>
        public CultureInfo XmlCultureInfo { get; internal set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Gets or sets the PhysicalSite
        /// </summary>
        public string PhysicalSite { get; internal set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>Gets the encoding.</summary>
        /// <value>The encoding.</value>
        public Encoding Encoding { get; internal set; }
        #endregion

        /// <summary>Initializes a new instance of the <see cref="WebJob"/> class.</summary>
        /// <param name="language">The language.</param>
        /// <param name="xmlLanguage">The XML language.</param>
        public WebJob(string language, string xmlLanguage)
        {
            if (!String.IsNullOrWhiteSpace(language)) this.CultureInfo = new CultureInfo(language);
            if (!String.IsNullOrWhiteSpace(xmlLanguage)) this.XmlCultureInfo = new CultureInfo(xmlLanguage);

        }

        /// <summary>Sets the title.</summary>
        /// <param name="innerText">The inner text.</param>
        public void SetTitle(string innerText) => this.Title = innerText;
    }
}
