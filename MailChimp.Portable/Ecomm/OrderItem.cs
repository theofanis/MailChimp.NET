using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Ecomm
{
    
    public class OrderItem
    {
        [JsonProperty("line_num")]
        public int LineNumber
        {
            get;
            set;
        }

        [JsonProperty("product_id")]
        public int ProductId
        {
            get;
            set;
        }

        [JsonProperty("sku")]
        public string SKU
        {
            get;
            set;
        }

        [JsonProperty("product_name")]
        public string ProductName
        {
            get;
            set;
        }

        [JsonProperty("category_id")]
        public int CategoryId
        {
            get;
            set;
        }

        [JsonProperty("category_name")]
        public string CategoryName
        {
            get;
            set;
        }

        [JsonProperty("qty")]
        public double Quantity
        {
            get;
            set;
        }

        [JsonProperty("cost")]
        public double Cost
        {
            get;
            set;
        }

    }
}
