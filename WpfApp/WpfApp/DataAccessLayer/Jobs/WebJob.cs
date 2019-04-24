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

    using Newtonsoft.Json;

    using WpfApp.DataAccessLayer.Offers;

    /// <summary>
    /// Defines the <see cref="WebJob" />
    /// </summary>
    public class WebJob
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>Gets the culture information.</summary>
        /// <value>The culture information.</value>
        public CultureInfo CultureInfo { get; internal set; }

        /// <summary>Gets the XML culture information.</summary>
        /// <value>The XML culture information.</value>
        public CultureInfo XmlCultureInfo { get; internal set; }

        /// <summary>Gets the encoding.</summary>
        /// <value>The encoding.</value>
        public Encoding Encoding { get; internal set; }

        /// <summary>Gets the abstract offer.</summary>
        /// <value>The abstract offer.</value>
        public AbstractOffer AbstractOffer { get; internal set; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="WebJob"/> class.</summary>
        /// <param name="language">The language.</param>
        /// <param name="xmlLanguage">The XML language.</param>
        public WebJob(string language, string xmlLanguage)
        {
            bool langIsNull = String.IsNullOrWhiteSpace(language);
            bool xmlLangIsNull = String.IsNullOrWhiteSpace(xmlLanguage);

            if (!langIsNull) this.CultureInfo = new CultureInfo(language);
            if (!xmlLangIsNull) this.XmlCultureInfo = new CultureInfo(xmlLanguage);

            if (langIsNull && !xmlLangIsNull) this.CultureInfo = this.XmlCultureInfo;
            if (!langIsNull && xmlLangIsNull) this.XmlCultureInfo = this.CultureInfo;

            if (langIsNull && this.CultureInfo == null) this.CultureInfo = new CultureInfo("en-US");
            if (xmlLangIsNull && this.XmlCultureInfo == null) this.XmlCultureInfo = new CultureInfo("en-US");

        }
        #endregion

        /*#region PublicOverrideMethods
        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
            => this + "\nTitle:\t" + this.Title + "\nCultureInfo:\t" + this.CultureInfo +
            "\nXmlCultureInfo:\t" + this.XmlCultureInfo + "\nEncoding:\t" + this.Encoding +
            "\nAbstractOffer:\t" + this.AbstractOffer;
        #endregion*/

        #region PublicMethods
        /// <summary>Sets the title.</summary>
        /// <param name="innerText">The inner text.</param>
        public void SetTitle(string innerText) => this.Title = innerText.TrimStart().TrimEnd().Trim();

        /// <summary>Sets the encoding.</summary>
        /// <param name="encoding">The encoding.</param>
        public void SetEncoding(string encoding)
        {
            if (encoding.Equals("UTF-7", StringComparison.InvariantCultureIgnoreCase))
                this.Encoding = Encoding.UTF7;
            else if (encoding.Equals("UTF-8", StringComparison.InvariantCultureIgnoreCase))
                this.Encoding = Encoding.UTF8;
            else if (encoding.Equals("UTF-32", StringComparison.InvariantCultureIgnoreCase))
                this.Encoding = Encoding.UTF32;
            else if (encoding.Equals("ascii", StringComparison.InvariantCultureIgnoreCase))
                this.Encoding = Encoding.ASCII;
            else if (encoding.Equals("unicode", StringComparison.InvariantCultureIgnoreCase))
                this.Encoding = Encoding.Unicode;
            else if (encoding.Equals("big-indian", StringComparison.InvariantCultureIgnoreCase))
                this.Encoding = Encoding.BigEndianUnicode;
            else this.Encoding = Encoding.Default;
        }

        /// <summary>Sets the abstract offer.</summary>
        /// <param name="abstractOffer">The abstract offer.</param>
        public void SetAbstractOffer(AbstractOffer abstractOffer) => this.AbstractOffer = abstractOffer;

        /// <summary>Converts to JSON.</summary>
        /// <returns>JSON representation string</returns>
        public string ToJson() => JsonConvert.SerializeObject(this);
        #endregion
    }
}
