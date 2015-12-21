using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// For RSS Campaigns 
    /// </summary>
    
    public class CampaignTypeRssOptions
    {
        public CampaignTypeRssOptions()
        {
            Schedule = "daily";
            ScheduledHour = "4";
            ScheduledWeekday = "1";
        }
        /// <summary>
        /// The URL to pull RSS content from - it will be verified and must exist
        /// </summary>
        [JsonProperty("url")]
        public string URL
        {
            get;
            set;
        }
        /// <summary>
        /// optional one of "daily", "weekly", "monthly" - defaults to "daily"
        /// </summary>
        [JsonProperty("schedule")]
        public string Schedule
        {
            get;
            set;
        }
        /// <summary>
        /// optional an hour between 0 and 24 - default to 4 (4am local time) - applies to all schedule types
        /// </summary>
        [JsonProperty("schedule_hour")]
        public string ScheduledHour
        {
            get;
            set;
        }
        /// <summary>
        /// optional for "weekly" only, a number specifying the day of the week to send: 0 (Sunday) - 6 (Saturday) - defaults to 1 (Monday)
        /// </summary>
        [JsonProperty("schedule_weedkday")]
        public string ScheduledWeekday
        {
            get;
            set;
        }
        /// <summary>
        ///optional for "monthly" only, a number specifying the day of the month to send (1 - 28) or "last" for the last day of a given month. Defaults to the 1st day of the month
        /// </summary>
        [JsonProperty("schedule_monthday")]
        public string ScheduledMonthday
        {
            get;
            set;
        }
        /// <summary>
        ///optional used for "daily" schedules only, an array of the ISO-8601 weekday numbers to send on
        /// </summary>
        [JsonProperty("days")]
        public CampaignScheduleDays ScheduledDays
        {
            get;
            set;
        }
      

    }
}
