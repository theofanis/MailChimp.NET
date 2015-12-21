using Newtonsoft.Json;

namespace MailChimp.Folders
{
    
    public class FolderActionResult
    {
        /// <summary>
        /// whether the call worked. Realistically 
        /// this will always be true as errors will 
        /// be thrown otherwise.
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete
        {
            get;
            set;
        }
    }
}
