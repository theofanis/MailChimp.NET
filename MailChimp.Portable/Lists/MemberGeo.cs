using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Member geographic information (if present)
    /// </summary>
    
    public class MemberGeo
    {
        /// <summary>
        /// the latitude
        /// </summary>
        [JsonProperty("latitude")]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// the longitude
        /// </summary>
        [JsonProperty("longitude")]
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// GMT offset
        /// </summary>
        [JsonProperty("gmtoff")]
        public string GMTOffset
        {
            get;
            set;
        }

        /// <summary>
        /// GMT offset during daylight savings (if DST not observered, will be same as gmtoff)
        /// </summary>
        [JsonProperty("dstoff")]
        public string DSTOffset
        {
            get;
            set;
        }

        /// <summary>
        /// the timezone we've place them in
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone
        {
            get;
            set;
        }

        /// <summary>
        /// 2 digit ISO-3166 country code
        /// </summary>
        [JsonProperty("cc")]
        public string CountryCode
        {
            get;
            set;
        }

        /// <summary>
        /// generally state, province, or similar
        /// </summary>
        [JsonProperty("region")]
        public string Region
        {
            get;
            set;
        }
    }
}
