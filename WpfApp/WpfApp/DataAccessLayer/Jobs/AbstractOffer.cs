/**
* AbstractOffer.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 17-04-2019
* OR 4/17/2019 3:30:07 PM
**/

namespace WpfApp.DataAccessLayer.Jobs
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="AbstractOffer" />
    /// </summary>
    public class AbstractOffer
    {
        /// <summary>Converts to json.</summary>
        /// <returns></returns>
        public virtual string ToJson() => JsonConvert.SerializeObject(this);
    }
}
