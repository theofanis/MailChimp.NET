using Newtonsoft.Json;

namespace MailChimp.Folders
{
    
    public class FolderAddResult
    {
        /// <summary>
        /// the folder_id of the newly created folder.
        /// </summary>
        [JsonProperty("folder_id")]
        public int NewFolderId
        {
            get;
            set;
        }
    }
}
