using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Templates
{
    /// <summary>
    /// The values to updates - while both are optional, at least one should be provided. Both can be updated at the same time.
    /// </summary>
    
    public class TemplateUpdateValue
    {
        /// <summary>
        /// The name for the template - names must be unique and a max of 50 bytes
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A string specifying the entire template to be created. This is NOT campaign content. They are intended to utilize our template language.
        /// </summary>
        [JsonProperty("html")]
        public string Html
        {
            get;
            set;
        }

        /// <summary>
        /// The folder to put this template in - 0 or a blank values will remove it from a folder.
        /// </summary>
        [JsonProperty("folder_id")]
        public int? FolderId
        {
            get;
            set;
        }
    }
}
