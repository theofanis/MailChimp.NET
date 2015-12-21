using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class SubscriberLocation
    {
        /// <summary>
        /// the country name
        /// </summary>
        [JsonProperty("country")]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// the ISO 3166 2 digit country code
        /// </summary>
        [JsonProperty("cc")]
        public string CountryCode
        {
            get;
            set;
        }

        /// <summary>
        /// the percent of subscribers in the country
        /// </summary>
        [JsonProperty("percent")]
        public double Percent
        {
            get;
            set;
        }

        /// <summary>
        /// the total number of subscribers in the country
        /// </summary>
        [JsonProperty("total")]
        public double Total
        {
            get;
            set;
        }
    }
}
