using Newtonsoft.Json;

namespace MailChimp.Gallery
{
    
    public class AddGalleryFolderResult
    {
        /// <summary>
        /// the id of the new folder
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// the name of the new folder
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
    }
}