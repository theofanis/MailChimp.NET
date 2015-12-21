using Newtonsoft.Json;

namespace MailChimp.Reports
{
    /// <summary>
    /// optional - various extra options based on the campaign type
    /// </summary>
   
   public class Industry
    {
       /// <summary>
       ///the selected industry
       /// </summary>
       [JsonProperty("type")]
       public string Type { get; set; }
       /// <summary>
       ///industry open rate
       /// </summary>
       [JsonProperty("open_rate")]
       public float OpenRate { get; set; }
       /// <summary>
       ///industry click rate
       /// </summary>
       [JsonProperty("click_rate")]
       public float ClickRate { get; set; }
       /// <summary>
       ///industry bounce rate
       /// </summary>
       [JsonProperty("bounce_rate")]
       public float BounceRate { get; set; }
       /// <summary>
       ///industry unopen rate
       /// </summary>
       [JsonProperty("unopen_rate")]
       public float UnopenRate { get; set; }
       /// <summary>
       ///industry unsub rate
       /// </summary>
       [JsonProperty("unsub_rate")]
       public float UnsubRate { get; set; }
       /// <summary>
       ///industry abuse rate
       /// </summary>
       [JsonProperty("abuse_rate")]
       public float AbuseRate { get; set; }
    }
}
