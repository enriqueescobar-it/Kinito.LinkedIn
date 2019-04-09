/**
* TokenResponse.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:25:04 AM
**/

namespace LogInUsingLinkedinApp.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="TokenResponse" />
    /// </summary>
    public class TokenResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Access_token
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string Access_token { get; set; }

        /// <summary>
        /// Gets or sets the Expires_in
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int Expires_in { get; set; }

        #endregion
    }
}
