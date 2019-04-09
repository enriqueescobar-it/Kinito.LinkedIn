/**
* Location.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:35:47 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Location" />
    /// </summary>
    public class Location
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }
}
