/**
* ApiStandardProfileRequest.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:50:39 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="ApiStandardProfileRequest" />
    /// </summary>
    public class ApiStandardProfileRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Headers
        /// </summary>
        [JsonProperty(PropertyName = "headers")]
        public Headers Headers { get; set; }

        /// <summary>
        /// Gets or sets the Url
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        #endregion
    }
}
