using Newtonsoft.Json;

namespace MailChimp.Reports
{
    /// <summary>
    /// optional - various extra options based on the campaign type
    /// </summary>
   
   public class Timeseries
    {
       /// <summary>
       ///The timestemp in Y-m-d H:00:00 format
       /// </summary>
       [JsonProperty("timestamp")]
       public string Timestamp { get; set; }
       /// <summary>
       ///the total emails sent during the hour
       /// </summary>
       [JsonProperty("emails_sent")]
       public int EmailsSent { get; set; }
        /// <summary>
       ///unique opens seen during the hour
       /// </summary>
       [JsonProperty("unique_opens")]
       public int UniqueOpens { get; set; }
        /// <summary>
       ///unique clicks seen during the hour
       /// </summary>
       [JsonProperty("recipients_click")]
       public int RecipientsClick { get; set; }
    }
}
