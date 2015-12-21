using Newtonsoft.Json;

namespace MailChimp.Campaigns
{

    public class Campaign
    {
        /// <summary>
        /// Campaign Id (used for all other campaign functions)
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// The Campaign id used in our web app, allows you to create a link directly to it
        /// </summary>
        [JsonProperty("web_id")]
        public int WebId
        {
            get;
            set;
        }

        /// <summary>
        /// The List used for this campaign
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// The Folder this campaign is in
        /// </summary>
        [JsonProperty("folder_id")]
        public int FolderId
        {
            get;
            set;
        }

        /// <summary>
        /// The Template this campaign uses
        /// </summary>
        [JsonProperty("template_id")]
        public int TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// How the campaign's content is put together - one of 'template', 'html', 'url'
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Title of the campaign
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// The type of campaign this is (regular,plaintext,absplit,rss,inspection,auto)
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Creation time for the campaign
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Send time for the campaign - also the scheduled time for scheduled campaigns.
        /// </summary>
        [JsonProperty("send_time")]
        public string SendTime
        {
            get;
            set;
        }

        /// <summary>
        /// Number of emails email was sent to
        /// </summary>
        [JsonProperty("emails_sent")]
        public int EmailsSent
        {
            get;
            set;
        }

        /// <summary>
        /// Status of the given campaign (save,paused,schedule,sending,sent)
        /// </summary>
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// From name of the given campaign
        /// </summary>
        [JsonProperty("from_name")]
        public string FromName
        {
            get;
            set;
        }

        /// <summary>
        /// Reply-to email of the given campaign
        /// </summary>
        [JsonProperty("from_email")]
        public string FromEmail
        {
            get;
            set;
        }

        /// <summary>
        /// Subject of the given campaign
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Custom "To:" email string using merge variables
        /// </summary>
        [JsonProperty("to_name")]
        public string ToName
        {
            get;
            set;
        }

        /// <summary>
        /// Archive link for the given campaign
        /// </summary>
        [JsonProperty("archive_url")]
        public string ArchiveUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the campaign content's css was auto-inlined
        /// </summary>
        [JsonProperty("inline_css")]
        public bool InlineCSS
        {
            get;
            set;
        }

        /// <summary>
        /// Either "google" if enabled or "N" if disabled
        /// </summary>
        [JsonProperty("analytics")]
        public string Analytics
        {
            get;
            set;
        }

        /// <summary>
        /// The name/tag the campaign's links were tagged with if analytics were enabled.
        /// </summary>
        [JsonProperty("analytics_tag")]
        public string AnalyticsTag
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the campaign was authenticated
        /// </summary>
        [JsonProperty("authenticate")]
        public bool Authenticate
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not ecomm360 tracking was appended to links
        /// </summary>
        [JsonProperty("ecomm360")]
        public bool Ecomm360
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the campaign was auto tweeted after sending
        /// </summary>
        [JsonProperty("auto_tweet")]
        public bool AutoTweet
        {
            get;
            set;
        }

        /// <summary>
        /// A comma delimited list of Facebook Profile/Page Ids the 
        /// campaign was posted to after sending. If not used, blank.
        /// </summary>
        [JsonProperty("auto_fb_post")]
        public string AutoFacebookPost
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the auto_footer was manually turned on
        /// </summary>
        [JsonProperty("auto_footer")]
        public bool AutoFooter
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the campaign used Timewarp
        /// </summary>
        [JsonProperty("timewarp")]
        public bool Timewarp
        {
            get;
            set;
        }

        /// <summary>
        /// The time, in GMT, that the Timewarp campaign is being sent. 
        /// For A/B Split campaigns, this is blank and is instead in 
        /// their schedule_a and schedule_b in the type_opts array
        /// </summary>
        [JsonProperty("timewarp_schedule")]
        public string TimewarpSchedule
        {
            get;
            set;
        }

        /// <summary>
        /// the unique id of the parent campaign 
        /// (currently only valid for rss children)
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// a string marked-up with HTML explaining the segment 
        /// used for the campaign in plain English
        /// </summary>
        [JsonProperty("segment_text")]
        public string SegmentText
        {
            get;
            set;
        }

        [JsonProperty("segment_opts")]
        [JsonConverter(typeof(SingleArrayValueConverter<CampaignSegmentOptions>))]
        public CampaignSegmentOptions SegmentOpts
        {
            get;
            set;
        }

        /// <summary>
        /// total number of comments left on this campaign
        /// </summary>
        [JsonProperty("comments_total")]
        public int CommentsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// total number of unread comments for this campaign 
        /// based on the login the apikey belongs to
        /// </summary>
        [JsonProperty("comments_unread")]
        public int CommentsUnread
        {
            get;
            set;
        }
    }
}
