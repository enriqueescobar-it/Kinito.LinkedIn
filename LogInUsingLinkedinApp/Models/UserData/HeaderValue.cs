/**
* HeaderValue.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:53:28 AM
**/

namespace LogInUsingLinkedinApp.Models.UserData
{
    using Newtonsoft.Json;

    //* JsonProperty(PropertyName = "name") attribute used here
    //* to map json property name with object property name
    //* while deserializing a json into object
    /// <summary>
    /// Defines the <see cref="HeaderValue" />
    /// </summary>
    public class HeaderValue
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        #endregion
    }
}
