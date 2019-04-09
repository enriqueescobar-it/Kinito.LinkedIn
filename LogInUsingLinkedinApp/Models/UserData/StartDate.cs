/**
* StartDate.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:35:19 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="StartDate" />
    /// </summary>
    public class StartDate
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Month
        /// </summary>
        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the Year
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        #endregion
    }
}
