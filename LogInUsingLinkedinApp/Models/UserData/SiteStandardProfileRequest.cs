/**
* SiteStandardProfileRequest.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:32:34 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="SiteStandardProfileRequest" />
    /// </summary>
    public class SiteStandardProfileRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Url
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        #endregion
    }
}
