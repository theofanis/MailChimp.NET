using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Templates
{
    /// <summary>
    /// Replace the content of a user template, NOT campaign content.
    /// </summary>
    
    public class TemplateUpdateResult
    {
        /// <summary>
        /// Whether the call worked. Reallistically this will always be true as errors will be thrown otherwise.
        /// </summary>
        [JsonProperty("complete")]
        public bool Completed
        {
            get;
            set;
        }
    }
}
