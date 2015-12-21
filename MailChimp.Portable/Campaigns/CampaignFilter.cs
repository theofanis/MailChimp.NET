using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    
    public class CampaignFilter
    {
        /// <summary>
        /// optional - return the campaign using a know campaign_id. Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }

        /// <summary>
        /// optional - return the child campaigns using a known parent campaign_id. Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// optional - the list to send this campaign to - get lists using lists(). Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns from this folder id - get folders using campaignFolders(). Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("folder_id")]
        public int? FolderId
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns using this template id - get templates using templates(). Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("template_id")]
        public int? TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// optional - return campaigns of a specific status - one of "sent", "save", "paused", "schedule", "sending". Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// optional - return campaigns of a specific type - one of "regular", "plaintext", "absplit", "rss", "auto". Accepts multiples separated by commas when not using exact matching.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns that have this "From Name"
        /// </summary>
        [JsonProperty("from_name")]
        public string FromName
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns that have this "Reply-to Email"
        /// </summary>
        [JsonProperty("from_email")]
        public string FromEmail
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns that have this title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns that have this subject
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns that have been sent since this date/time (in GMT) - - 24 hour format in GMT, eg "2013-12-30 20:30:00" - if this is invalid the whole call fails
        /// </summary>
        [JsonProperty("sendtime_start")]
        public string SendtimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show campaigns that have been sent before this date/time (in GMT) - - 24 hour format in GMT, eg "2013-12-30 20:30:00" - if this is invalid the whole call fails
        /// </summary>
        [JsonProperty("sendtime_end")]
        public string SendtimeEnd
        {
            get;
            set;
        }

        /// <summary>
        /// optional - whether to return just campaigns with or without segments
        /// </summary>
        [JsonProperty("uses_segment")]
        public bool? UsesSegment
        {
            get;
            set;
        }

        /// <summary>
        /// optional - flag for whether to filter on exact values when filtering, or search within content for filter values - defaults to true. Using this disables the use of any filters that accept multiples.
        /// </summary>
        [JsonProperty("exact")]
        public bool? Exact
        {
            get;
            set;
        }
    }
}
