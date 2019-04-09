/**
* Positions.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:33:58 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Positions" />
    /// </summary>
    public class Positions
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
        public List<Experience> Values { get; set; }

        #endregion
    }
}
