/**
* Headers.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:51:29 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Headers" />
    /// </summary>
    public class Headers
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        [JsonProperty(PropertyName = "_total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the Values
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public List<HeaderValue> Values { get; set; }

        #endregion
    }
}
