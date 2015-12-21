using Newtonsoft.Json;

namespace MailChimp.Helper
{
    
    public class Matches
    {
        /// <summary>
        /// containing the total matches and current results
        /// </summary>
        [JsonProperty("exact_matches")]
        public Match ExactMatches
        {
            get;
            set;
        }

        /// <summary>
        /// containing the total matches and current results
        /// </summary>
        [JsonProperty("full_search")]
        public Match FullSearch
        {
            get;
            set;
        }
    }
}

