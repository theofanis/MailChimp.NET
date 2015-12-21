using Newtonsoft.Json;
using System.Collections.Generic;

namespace MailChimp.Gallery
{
    
    public class GalleryFoldersResult
    {
        /// <summary>
        /// The total matching folders
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        [JsonProperty("data")]
        public List<GalleryFolder> Folders
        {
            get;
            set;
        }
    }
}
