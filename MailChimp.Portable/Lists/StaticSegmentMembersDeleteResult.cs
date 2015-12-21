using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
   public class StaticSegmentMembersDeleteResult
    {
            /// <summary>
            /// the total number of successful removals
            /// </summary>
            [JsonProperty("success_count")]
            public int successCount
            {
                get;
                set;
            }
            /// <summary>
            /// the total number of unsuccessful removals
            /// </summary>
            [JsonProperty("error_count")]
            public int errorCount
            {
                get;
                set;
            }
            /// <summary>
            /// Error information
            /// </summary>
            [JsonProperty("errors")]
            public List<ListError> Errors
            {
                get;
                set;
            }
        }
}
