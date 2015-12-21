using Newtonsoft.Json;

namespace MailChimp.Reports
{
    /// <summary>
    /// optional - various extra options based on the campaign type
    /// </summary>
   
   public class Timewarp
    {
       /// <summary>
       ///opens for this timezone
       /// </summary>
       [JsonProperty("opens")]
        public int Opens { get; set; }
       /// <summary>
       ///the date/time of the last open for this timezone
       /// </summary>
       [JsonProperty("last_open")]
       public string last_open { get; set; }
        /// <summary>
       ///the unique opens for this timezone
       /// </summary>
       [JsonProperty("unique_opens")]
       public int UniqueOpens { get; set; }
        /// <summary>
       ///the total clicks for this timezone
       /// </summary>
       [JsonProperty("clicks")]
       public int Clicks { get; set; }
        /// <summary>
       ///the date/time of the last click for this timezone
       /// </summary>
       [JsonProperty("last_click")]
       public string LastClick { get; set; }
        /// <summary>
       ///the total bounces for this timezone
       /// </summary>
       [JsonProperty("bounces")]
       public int Bounces { get; set; }
        /// <summary>
       ///the total number of members sent to in this timezone
       /// </summary>
       [JsonProperty("total")]
       public int Total { get; set; }
        /// <summary>
       ///the total number of members delivered to in this timezone
       /// </summary>
       [JsonProperty("sent")]
       public int Sent { get; set; }
       
    }
}
