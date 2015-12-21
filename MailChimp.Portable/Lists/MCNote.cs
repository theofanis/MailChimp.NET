﻿using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Mailchimp note information
    /// </summary>
    
    public class MCNote
    {
        /// <summary>
        /// the note to set. this is required unless you're deleting a note
        /// </summary>
        [JsonProperty("note")]
        public string Note
        {
            get;
            set;
        }

        /// <summary>
        /// the note id to operate on. not including this (or using an invalid id) causes a new note to be added
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// if the "id" key exists and is valid, an "update" key may be set 
        /// to "append" (default), "prepend", "replace", or "delete" to handle 
        /// how we should update existing notes. "delete", obviously, will only work 
        /// with a valid "id" - passing that along with "note" and an 
        /// invalid "id" is wrong and will be ignored.
        /// </summary>
        [JsonProperty("action")]
        public string Action
        {
            get;
            set;
        }
    }
}
