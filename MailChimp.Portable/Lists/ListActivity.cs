using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class ListActivity
    {
        [JsonProperty("user_id")]
        public string UserId
        {
            get;
            set;
        }

        [JsonProperty("day")]
        public string Date
        {
            get;
            set;
        }

        [JsonProperty("emails_sent")]
        public int EmailSent
        {
            get;
            set;
        }

        [JsonProperty("unique_opens")]
        public int UniqueOpens
        {
            get;
            set;
        }

        [JsonProperty("recipient_clicks")]
        public int RecipientClicks
        {
            get;
            set;
        }

        [JsonProperty("hard_bounce")]
        public int HardBounce
        {
            get;
            set;
        }

        [JsonProperty("soft_bounce")]
        public int SoftBounce
        {
            get;
            set;
        }

        [JsonProperty("abuse_reports")]
        public int AbuseReports
        {
            get;
            set;
        }

        [JsonProperty("subs")]
        public int Subscriptions
        {
            get;
            set;
        }

        [JsonProperty("unsubs")]
        public int Unsubscriptions
        {
            get;
            set;
        }

        [JsonProperty("other_adds")]
        public int OtherAdds
        {
            get;
            set;
        }

        [JsonProperty("other_removes")]
        public int OtherRemoves
        {
            get;
            set;
        }
    }
}
