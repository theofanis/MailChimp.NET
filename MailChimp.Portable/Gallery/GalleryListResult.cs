using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Gallery
{
    
    public class GalleryListResult
    {
        /// <summary>
        /// the total matching items 
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        [JsonProperty("data")]
        public List<Gallery> Galleries
        {
            get;
            set;
        }
    }
}
