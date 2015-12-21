using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Ecomm
{
    
    public class OrderItemResult
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

        [JsonProperty("product_name")]
        public string ProductName
        {
            get;
            set;
        }

        [JsonProperty("product_sku")]
        public string ProductSKU
        {
            get;
            set;
        }

        [JsonProperty("product_category_id")]
        public int ProductCategoryId
        {
            get;
            set;
        }

        [JsonProperty("product_category_name")]
        public string ProductCategoryName
        {
            get;
            set;
        }

        [JsonProperty("qty")]
        public int Quantity
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
