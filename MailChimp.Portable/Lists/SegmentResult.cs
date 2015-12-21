using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class SegmentResult
    {
        /// <summary>
        /// array of structs with data for each segment
        /// </summary>
        [JsonProperty("static")]
        public List<StaticSegmentResult> StaticResult
        {
            get;
            set;
        }

        /// <summary>
        /// array of structs with data for each segment
        /// </summary>
        [JsonProperty("saved")]
        public List<SavedSegmentResult> SavedResult
        {
            get;
            set;
        }
    }
}
