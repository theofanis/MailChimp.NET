﻿using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// For A/B Split campaigns
    /// </summary>
   
   public class CampaignTypeAbsplitOptions
   {
       public CampaignTypeAbsplitOptions()
       {
           WaitUnits = 86400;
           WaitTime = 1;
       }
       /// <summary>
       /// The values to segment based on. 
       /// Currently, one of: "subject", "from_name", "schedule". NOTE, for "schedule", you will need to call campaignSchedule() separately!
       /// </summary>
       [JsonProperty("split_test")]
       public string SplitTest
       {
           get;
           set;
       }
       /// <summary>
       /// How the winner will be picked, one of: "opens" (by the open_rate), "clicks" (by the click rate), "manual" (you pick manually)
       /// </summary>
       [JsonProperty("pick_winner")]
       public string PickWinner
       {
           get;
           set;
       }
       /// <summary>
       /// optional the default time unit to wait before auto-selecting a winner - use "3600" for hours, "86400" for days. Defaults to 86400.
       /// </summary>
       [JsonProperty("wait_units")]
       public int WaitUnits
       {
           get;
           set;
       }
       /// <summary>
       /// optional the number of units to wait before auto-selecting a winner - defaults to 1, so if not set, a winner will be selected after 1 Day.
       /// </summary>
       [JsonProperty("wait_time")]
       public int WaitTime
       {
           get;
           set;
       }
       /// <summary>
       /// optional this is a percentage of what size the Campaign's List plus any segmentation options results in. "schedule" type forces 50%, all others default to 10%
       /// </summary>
       [JsonProperty("split_size")]
       public int SplitSize
       {
           get;
           set;
       }
       /// <summary>
       /// optional sort of, required when split_test is "from_name"
       /// </summary>
       [JsonProperty("from_name_a")]
       public string FromNameA
       {
           get;
           set;
       }
       /// <summary>
       /// optional sort of, required when split_test is "from_name"
       /// </summary>
       [JsonProperty("from_name_b")]
       public string FromNameB
       {
           get;
           set;
       }
       /// <summary>
       /// optional sort of, required when split_test is "from_email"
       /// </summary>
       [JsonProperty("from_email_a")]
       public string FromEmailA
       {
           get;
           set;
       }
       /// <summary>
       /// optional sort of, required when split_test is "from_email"
       /// </summary>
       [JsonProperty("from_email_b")]
       public string FromEmailB
       {
           get;
           set;
       }
       /// <summary>
       /// optional sort of, required when split_test is "subject"
       /// </summary>
       [JsonProperty("subject_a")]
       public string SubjectA
       {
           get;
           set;
       }
       /// <summary>
       /// optional sort of, required when split_test is "subject"
       /// </summary>
       [JsonProperty("subject_b")]
       public string SubjectB
       {
           get;
           set;
       }

   }
}
