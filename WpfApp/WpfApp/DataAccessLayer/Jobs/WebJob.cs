/**
* WebJob.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 16-04-2019
* OR 4/16/2019 12:39:07 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using System.Globalization;

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
        #endregion
    }
}
