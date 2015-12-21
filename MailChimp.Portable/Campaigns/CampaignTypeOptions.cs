using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// optional - various extra options based on the campaign type
    /// </summary>
   
   public class CampaignTypeOptions
    {
        /// <summary>
        ///For RSS Campaigns
        /// </summary>
       [JsonProperty("rss")]
       public CampaignTypeRssOptions RssOptions
       {
           get;
           set;
       }
       
       /// <summary>
       ///For A/B Split campaigns
       /// </summary>
       [JsonProperty("absplit")]
       public CampaignTypeAbsplitOptions ABSplitOption
       {
           get;
           set;
       }

       /// <summary>
       ///For AutoResponder campaigns
       /// </summary>
       [JsonProperty("auto")]
       public CampaignTypeAutoResponderOptions AutoResponder
       {
           get;
           set;
       }

    }
}
