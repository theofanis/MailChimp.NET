using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Information about a given list
    /// </summary>
    
    public class ListInfo
    {
        /// <summary>
        /// The list id for this list. This will be used for all other list management functions.
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// The list id used in our web app, allows you to create a link directly to it
        /// </summary>
        [JsonProperty("web_id")]
        public int WebId
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the list.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The date that this list was created.
        /// </summary>
        [JsonProperty("date_created")]
        public string DateCreated
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the List supports multiple formats for emails or just HTML
        /// </summary>
        [JsonProperty("email_type_option")]
        public bool EmailTypeOption
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not campaigns for this list use the Awesome Bar in archives by default
        /// </summary>
        [JsonProperty("use_awesomebar")]
        public bool UseAwesomebar
        {
            get;
            set;
        }

        /// <summary>
        /// Default From Name for campaigns using this list
        /// </summary>
        [JsonProperty("default_from_name")]
        public string DefaultFromName
        {
            get;
            set;
        }

        /// <summary>
        /// Default From Email for campaigns using this list
        /// </summary>
        [JsonProperty("default_from_email")]
        public string DefaultFromEmail
        {
            get;
            set;
        }

        /// <summary>
        /// Default Subject Line for campaigns using this list
        /// </summary>
        [JsonProperty("default_subject")]
        public string DefaultSubject
        {
            get;
            set;
        }

        /// <summary>
        /// Default Language for this list's forms
        /// </summary>
        [JsonProperty("default_language")]
        public string DefaultLanguage
        {
            get;
            set;
        }

        /// <summary>
        /// An auto-generated activity score for the list (0 - 5)
        /// </summary>
        [JsonProperty("list_rating")]
        public double ListRating
        {
            get;
            set;
        }

        /// <summary>
        /// Our eepurl shortened version of this list's subscribe form (will not change)
        /// </summary>
        [JsonProperty("subscribe_url_short")]
        public string SubscribeUrlShort
        {
            get;
            set;
        }

        /// <summary>
        /// The full version of this list's subscribe form (host will vary)
        /// </summary>
        [JsonProperty("subscribe_url_long")]
        public string SubscribeUrlLong
        {
            get;
            set;
        }

        /// <summary>
        /// The email address to use for this list's <a href="http://kb.mailchimp.com/article/how-do-i-import-a-campaign-via-email-email-beamer/">Email Beamer</a>
        /// </summary>
        [JsonProperty("beamer_address")]
        public string BeamerAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Whether this list is Public (pub) or Private (prv). Used internally for projects like <a href="http://blog.mailchimp.com/introducing-wavelength/" target="_blank">Wavelength</a>
        /// </summary>
        [JsonProperty("visibility")]
        public string Visibility
        {
            get;
            set;
        }
        
        [JsonProperty("stats")]
        public ListStats Stats { get; set; }

        
        public class ListStats
        {
            [JsonProperty("member_count")]
            public double MemberCount { get; set; }

            [JsonProperty("unsubscribe_count")]
            public double UnsubscribeCount { get; set; }
        
            [JsonProperty("cleaned_count")]
            public double CleanedCount { get; set; }

            [JsonProperty("member_count_since_send")]
            public double MemberCountSinceSend { get; set; }

            [JsonProperty("unsubscribe_count_since_send")]
            public double UnsubscribeCountSinceSend { get; set; }

            [JsonProperty("cleaned_count_since_send")]
            public double CleanedCountSinceSend { get; set; }

            [JsonProperty("campaign_count")]
            public double CampaignCount { get; set; }
            
            [JsonProperty("grouping_count")]
            public double GroupingCount { get; set; }

            [JsonProperty("group_count")]
            public double GroupCount { get; set; }

            [JsonProperty("merge_var_count")]
            public double MergeVarCount { get; set; }

            [JsonProperty("avg_sub_rate")]
            public double AvgSubRate { get; set; }

            [JsonProperty("avg_unsub_rate")]
            public double AvgUnsubRate { get; set; }

            [JsonProperty("target_sub_rate")]
            public double TargetSubRate { get; set; }

            [JsonProperty("open_rate")]
            public double OpenRate { get; set; }

            [JsonProperty("click_rate")]
            public double ClickRate { get; set; }

            [JsonProperty("date_last_campaign")]
            public System.DateTime DateLastCampaign { get; set; }
        }

    }
}
