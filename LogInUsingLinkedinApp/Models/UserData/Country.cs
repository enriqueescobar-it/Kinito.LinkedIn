/**
* Country.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:36:25 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Country" />
    /// </summary>
    public class Country
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }
}
