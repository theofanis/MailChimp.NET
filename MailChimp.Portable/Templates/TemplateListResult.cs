using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Templates
{
    /// <summary>
    /// Retrieve various templates available in the system, allowing some thing similar to our template gallery to be created.
    /// </summary>
    
    public class TemplateListResult
    {
        /// <summary>
        /// matching user templates
        /// </summary>
        [JsonProperty("user")]
        public List<TemplateListInfo> UserTemplates
        {
            get;
            set;
        }
        /// <summary>
        /// matching Gallery templates
        /// </summary>
        [JsonProperty("gallery")]
        public List<TemplateListInfo> GalleryTemplates
        {
            get;
            set;
        }
        /// <summary>
        /// matching Base templates
        /// </summary>
        [JsonProperty("base")]
        public List<TemplateListInfo> BaseTemplates
        {
            get;
            set;
        }
    }
}
