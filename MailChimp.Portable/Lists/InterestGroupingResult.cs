using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class InterestGroupingResult
    {
        /// <summary>
        /// the id of the newly created interest grouping
        /// </summary>
        [JsonProperty("id")]
        public int id
        {
            get;
            set;
        }
    }
}
