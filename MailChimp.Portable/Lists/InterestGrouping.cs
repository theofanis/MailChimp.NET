using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Interest grouping
    /// </summary>
    
    public class InterestGrouping
    {
        /// <summary>
        /// Grouping "id" from lists/interest-groupings (either this or name must be present) - 
        /// this id takes precedence and can't change (unlike the name)
        /// </summary>
        [JsonProperty("id")]
        public int Id
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
        public List<InnerGroup> GroupNames
        {
            get;
            set;
        }
        
        
        public class InnerGroup
        {
            [JsonProperty("bit")]
            public int Bit { get; set; }

            [JsonProperty("subscribers")]
            public int Subscribers { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("display_order")]
            public int DisplayOrder { get; set; }
        }

        public Grouping ToGrouping()
        {
            return new Grouping()
                {
                    Id = Id,
                    Name = Name,
                    GroupNames = GroupNames == null ? new List<string>() : GroupNames.Select(x => x.Name).ToList()
                };
        }
    }
}