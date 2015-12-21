using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Ecomm
{
    
    public class Order
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }

        [JsonProperty("email_id")]
        public string EmailId
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        [JsonProperty("total")]
        public double Total
        {
            get;
            set;
        }

        [JsonProperty("order_date")]
        public string OrderDate
        {
            get;
            set;
        }

        [JsonProperty("shipping")]
        public double Shipping
        {
            get;
            set;
        }

        [JsonProperty("tax")]
        public double Tax
        {
            get;
            set;
        }

        [JsonProperty("store_id")]
        public string StoreId
        {
            get;
            set;
        }

        [JsonProperty("store_name")]
        public string StoreName
        {
            get;
            set;
        }

        [JsonProperty("items")]
        public List<OrderItem> Items
        {
            get;
            set;
        }
    }
}
