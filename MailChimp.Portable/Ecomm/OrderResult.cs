using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Ecomm
{
    
    public class OrderResult
    {
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

        [JsonProperty("order_id")]
        public string OrderId
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

        [JsonProperty("order_total")]
        public double OrderTotal
        {
            get;
            set;
        }

        [JsonProperty("tax_total")]
        public double TaxTotal
        {
            get;
            set;
        }

        [JsonProperty("ship_total")]
        public double ShipTotal
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

        [JsonProperty("items")]
        public List<OrderItemResult> Items
        {
            get;
            set;
        }

    }
}
