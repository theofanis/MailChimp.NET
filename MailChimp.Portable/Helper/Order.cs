using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Represents each order for the account
    /// </summary>
    
    public class Order
    {
        /// <summary>
        /// The order id
        /// </summary>
        [JsonProperty("order_id")]
        public int OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// The order type - either "monthly" or "credits"
        /// </summary>
        [JsonProperty("type")]
        public string OrderType
        {
            get;
            set;
        }

        /// <summary>
        /// The order amount
        /// </summary>
        [JsonProperty("amount")]
        public double Amount
        {
            get;
            set;
        }

        /// <summary>
        /// The order date
        /// </summary>
        [JsonProperty("date")]
        public string Date
        {
            get;
            set;
        }

        /// <summary>
        /// The total credits used
        /// </summary>
        [JsonProperty("credits_used")]
        public double CreditsUsed
        {
            get;
            set;
        }
    }
}
