using Newtonsoft.Json;

namespace MailChimp.Folders
{
    
    public class FolderListResult
    {
        /// <summary>
        /// Folder Id for the given folder, this can be used in the campaigns() function to filter on.
        /// </summary>
        [JsonProperty("folder_id")]
        public int FolderId { get; set; }

        /// <summary>
        /// Name of the given folder
        /// </summary>
        [JsonProperty("name")]
        public string FolderName { get; set; }

        /// <summary>
        /// The date/time the folder was created
        /// </summary>
        [JsonProperty("date_created")]
        public string DateCreated { get; set; }

        /// <summary>
        /// The type of the folders being returned, just to make sure you know.
        /// </summary>
        [JsonProperty("type")]
        public string FolderType { get; set; }

        /// <summary>
        ///  number of items in the folder.
        /// </summary>
        [JsonProperty("cnt")]
        public int FolderItemCount { get; set; }
    }
}
