using Newtonsoft.Json;
using System.Collections.Generic;

namespace MailChimp.Reports
{
    /// <summary>
    /// optional - various extra options based on the campaign type
    /// </summary>
   
   public class ReportSummary
    {
        /// <summary>
        ///Number of email addresses in campaign that had syntactical errors.
        /// </summary>
       [JsonProperty("syntax_errors")]
       public int SyntaxErrors
       {
           get;
           set;
       }
       /// <summary>
       ///Number of email addresses in campaign that hard bounced.
       /// </summary>
       [JsonProperty("hard_bounces")]
       public int HardBounces
       {
           get;
           set;
       }
       /// <summary>
       ///Number of email addresses in campaign that soft bounced.
       /// </summary>
       [JsonProperty("soft_bounces")]
       public int SoftBounces
       {
           get;
           set;
       }
       /// <summary>
       ///Number of email addresses in campaign that unsubscribed.
       /// </summary>
       [JsonProperty("unsubscribes")]
       public int Unsubscribes { get; set; }
       /// <summary>
       ///Number of email addresses in campaign that reported campaign for abuse.
       /// </summary>
       [JsonProperty("abuse_reports")]
       public int AbuseReports { get; set; }
       /// <summary>
       ///Number of times email was forwarded to a friend.
       /// </summary>
       [JsonProperty("forwards")]
       public int Forwards { get; set; }
       /// <summary>
       ///Number of times a forwarded email was opened.
       /// </summary>
       [JsonProperty("forwards_opens")]
       public int ForwardsOpens { get; set; }
       /// <summary>
       ///Number of times the campaign was opened.
       /// </summary>
       [JsonProperty("opens")]
       public int Opens { get; set; }
       /// <summary>
       ///Date of the last time the email was opened.
       /// </summary>
       [JsonProperty("last_open")]
       public string LastOpen { get; set; }
       /// <summary>
       ///Number of people who opened the campaign.
       /// </summary>
       [JsonProperty("unique_opens")]
       public int UniqueOpens { get; set; }
       /// <summary>
       ///Number of times a link in the campaign was clicked.
       /// </summary>
       [JsonProperty("clicks")]
       public int Clicks { get; set; }
       /// <summary>
       ///Number of unique recipient/click pairs for the campaign.
       /// </summary>
       [JsonProperty("unique_clicks")]
       public int UniqueClicks { get; set; }
       /// <summary>
       ///Date of the last time a link in the email was clicked.
       /// </summary>
       [JsonProperty("last_click")]
       public string LastClick { get; set; }
       /// <summary>
       ///Number of unique recipients who clicked on a link in the campaign.
       /// </summary>
       [JsonProperty("users_who_clicked")]
       public int UsersWhoClicked { get; set; }
       /// <summary>
       ///Number of email addresses campaign was sent to.
       /// </summary>
       [JsonProperty("emails_sent")]
       public int EmailsSent { get; set; }
       /// <summary>
       ///total number of unique likes (Facebook)
       /// </summary>
       [JsonProperty("unique_likes")]
       public int UniqueLikes { get; set; }
       /// <summary>
       ///total number of recipients who liked (Facebook) the campaign
       /// </summary>
       [JsonProperty("recipient_likes")]
       public int RecipientLikes { get; set; }
       /// <summary>
       ///total number of likes (Facebook) that came from Facebook
       /// </summary>
       [JsonProperty("facebook_likes")]
       public int FacebookLikes { get; set; }
       /// <summary>
       ///Various rates/percentages for the account's selected industry - empty otherwise. These will vary across calls, do not use them for anything important.
       /// </summary>
       [JsonProperty("industry")]
       public Industry Industry { get; set; }
       /// <summary>
       ///If this was an absplit campaign, stats for the A and B groups will be returned - otherwise this is empty
       /// </summary>
       [JsonProperty("absplit")]
       public Absplit Absplit { get; set; }
       /// <summary>
       ///If this campaign was a Timewarp campaign, an array of structs from each timezone stats exist for. Each will contain:
       /// </summary>
       [JsonProperty("timewarp")]
       public List<Timewarp> Timewarps{ get; set; }
       /// <summary>
       ///structs for the first 24 hours of the campaign, per-hour stats:
       /// </summary>
       [JsonProperty("timeseries")]
       public List<Timeseries> Timeseries { get; set; }
    }
}
