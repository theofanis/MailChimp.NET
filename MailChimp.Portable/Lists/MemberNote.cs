using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MemberNote
    {
        /// <summary>
        /// the note id
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// the text entered
        /// </summary>
        [JsonProperty("note")]
        public string Note
        {
            get;
            set;
        }

        /// <summary>
        /// the date the note was created
        /// </summary>
        [JsonProperty("created")]
        public string Created
        {
            get;
            set;
        }

        /// <summary>
        /// the date the note was last updated
        /// </summary>
        [JsonProperty("updated")]
        public string Updated
        {
            get;
            set;
        }

        /// <summary>
        /// the name of the user who created the note. This can change as users update their profile.
        /// </summary>
        [JsonProperty("created_by_name")]
        public string CreatedByName
        {
            get;
            set;
        }
    }
}
