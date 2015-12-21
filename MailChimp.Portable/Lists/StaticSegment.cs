using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class StaticSegment
    {
        /// <summary>
        /// the static segment id
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// static segment name
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// the date the static segment was created
        /// </summary>
        [JsonProperty("added")]
        public string Added
        {
            get;
            set;
        }
    }
}
