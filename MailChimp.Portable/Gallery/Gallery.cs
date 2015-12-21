using Newtonsoft.Json;

namespace MailChimp.Gallery
{
    
    public class Gallery
    {
        /// <summary>
        /// The id of the file
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
        /// The creation date for the item
        /// </summary>
        [JsonProperty("time")]
        public string Time
        {
            get;
            set;
        }

        /// <summary>
        /// The file size in bytes
        /// </summary>
        [JsonProperty("size")]
        public int Size
        {
            get;
            set;
        }

        /// <summary>
        /// The url to the actual item in the gallery
        /// </summary>
        [JsonProperty("full")]
        public string Full
        {
            get;
            set;
        }

        /// <summary>
        /// A url for a thumbnail that can be used to represent the item, generally an image thumbnail or an icon for a file type
        /// </summary>
        [JsonProperty("thumb")]
        public string Thumb
        {
            get;
            set;
        }
    }
}
