using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// Criteria to segment a list on - See http://apidocs.mailchimp.com/api/2.0/campaigns/segment-test.php for full list of segmentation options
    /// </summary>
    
    public class CampaignSegmentCriteria
    {
        /// <summary>
        /// The field to segment the list on e.g. date: Select based on the signup date
        /// </summary>
        [JsonProperty("field")]
        public string Field
        {
            get;
            set;
        }
        /// <summary>
        /// The operator to be applied e.g. equals would be "eq", less than "lt", greater than "gt" 
        /// </summary>
        [JsonProperty("op")]
        public string Operator
        {
            get;
            set;
        }
        /// <summary>
        /// The value to use for the comparison
        /// </summary>
        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// The extra value required for certain types of comparision E.g. "geoin" - zipcode to be used as a centre point
        /// </summary>
        [JsonProperty("extra")]
        public string Extra
        {
            get;
            set;
        }
    }
}
