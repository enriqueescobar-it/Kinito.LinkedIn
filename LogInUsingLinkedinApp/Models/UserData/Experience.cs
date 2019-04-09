/**
* Experience.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:34:44 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Experience" />
    /// </summary>
    public class Experience
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Company
        /// </summary>
        [JsonProperty(PropertyName = "company")]
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsCurrent
        /// </summary>
        [JsonProperty(PropertyName = "isCurrent")]
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Gets or sets the Location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the StartDate
        /// </summary>
        [JsonProperty(PropertyName = "startDate")]
        public StartDate StartDate { get; set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        #endregion
    }
}
