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
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public CultureInfo CultureInfo { get; internal set; }
    }
}
