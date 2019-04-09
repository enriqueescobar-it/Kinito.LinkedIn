/**
* Company.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:36:47 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Company" />
    /// </summary>
    public class Company
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the Industry
        /// </summary>
        [JsonProperty(PropertyName = "industry")]
        public string Industry { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Size
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        #endregion
    }
}
