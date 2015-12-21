using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Ecomm
{
    
    public class OrderListResult
    {
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        [JsonProperty("data")]
        public List<OrderResult> Orders
        {
            get;
            set;
        }
    }
}
