/**
* AppConfig.cs
* BY DESKTOP-BG640NB\EESCOBAR
* ON 09-04-2019
* OR 4/9/2019 10:25:44 AM
**/

namespace LogInUsingLinkedinApp.Utils
{
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// To get configuration from web config file
    /// </summary>
    public class AppConfig
    {
        #region Methods
        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="key">The key<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string Get(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            else
                throw new Exception("Configuration Key not configured properly. Key Name: " + key);
        }
        #endregion
    }
}
