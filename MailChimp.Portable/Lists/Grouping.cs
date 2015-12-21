using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Interest grouping
    /// </summary>
    
    public class Grouping
    {
        /// <summary>
        /// Grouping "id" from lists/interest-groupings (either this or name must be present) - 
        /// this id takes precedence and can't change (unlike the name)
        /// </summary>
        [JsonProperty("id")]
        public int? Id
        {
            get;
            set;
        }

        /// <summary>
        /// Grouping "name" from lists/interest-groupings (either this or id must be present)
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// an array of valid group names for this grouping.
        /// </summary>
        [JsonProperty("groups")]
        public List<string> GroupNames
        {
            get;
            set;
        }

        /// <summary>
        /// An array of group name and interest structs.
        /// </summary>
        [JsonProperty("groups")]
        public List<GroupInterest> GroupInterests
        {
            get;
            set;
        }

        
        public class GroupInterest
        {
            [JsonProperty("name")]
            public string Name
            {
                get;
                set;
            }

            [JsonProperty("interested")]
            public bool Interested
            {
                get;
                set;
            }
        }
    }
}
