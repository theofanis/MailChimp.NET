using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Templates
{
    /// <summary>
    /// Create a new user template, NOT campaign content. These templates can then be applied while creating campaigns.
    /// </summary>
    
    public class TemplateAddResult
    {
        /// <summary>
        /// The new template id, otherwise an error is thrown.
        /// </summary>
        [JsonProperty("template_id")]
        public int TemplateId
        {
            get;
            set;
        }
    }
}
