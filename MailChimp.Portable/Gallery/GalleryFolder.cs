using Newtonsoft.Json;

namespace MailChimp.Gallery
{
    
    public class GalleryFolder
    {
        /// <summary>
        /// The id of the folder
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// The file name
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The number of files in the folder
        /// </summary>
        [JsonProperty("file_count")]
        public int FileCount
        {
            get;
            set;
        }
    }
}
