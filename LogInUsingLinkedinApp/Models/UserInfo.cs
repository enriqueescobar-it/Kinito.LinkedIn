/**
* UserInfo.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:31:38 AM
**/

namespace LogInUsingLinkedinApp.Models
{
    using Newtonsoft.Json;
    using LogInUsingLinkedinApp.Models.UserData;

    /// <summary>
    /// Defines the <see cref="UserInfo" />
    /// </summary>
    public class UserInfo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ApiStandardProfileRequest
        /// </summary>
        [JsonProperty(PropertyName = "apiStandardProfileRequest")]
        public ApiStandardProfileRequest ApiStandardProfileRequest { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress
        /// </summary>
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the FormattedName
        /// </summary>
        [JsonProperty(PropertyName = "formattedName")]
        public string FormattedName { get; set; }

        /// <summary>
        /// Gets or sets the Headline
        /// </summary>
        [JsonProperty(PropertyName = "headline")]
        public string Headline { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Industry
        /// </summary>
        [JsonProperty(PropertyName = "industry")]
        public string Industry { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the MaidenName
        /// </summary>
        [JsonProperty(PropertyName = "maidenName")]
        public string MaidenName { get; set; }

        /// <summary>
        /// Gets or sets the NumConnections
        /// </summary>
        [JsonProperty(PropertyName = "numConnections")]
        public int NumConnections { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NumConnectionsCapped
        /// </summary>
        [JsonProperty(PropertyName = "numConnectionsCapped")]
        public bool NumConnectionsCapped { get; set; }

        /// <summary>
        /// Gets or sets the PictureUrl
        /// </summary>
        [JsonProperty(PropertyName = "pictureUrl")]
        public string PictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the Positions
        /// </summary>
        [JsonProperty(PropertyName = "positions")]
        public Positions Positions { get; set; }

        /// <summary>
        /// Gets or sets the PublicProfileUrl
        /// </summary>
        [JsonProperty(PropertyName = "publicProfileUrl")]
        public string PublicProfileUrl { get; set; }

        /// <summary>
        /// Gets or sets the SiteStandardProfileRequest
        /// </summary>
        [JsonProperty(PropertyName = "siteStandardProfileRequest")]
        public SiteStandardProfileRequest SiteStandardProfileRequest { get; set; }

        /// <summary>
        /// Gets or sets the Summary
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        #endregion
    }
}
