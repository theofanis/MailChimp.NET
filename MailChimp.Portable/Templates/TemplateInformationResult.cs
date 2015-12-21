using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Templates
{
    /// <summary>
    /// Info to be used when editing
    /// </summary>
    
    public class TemplateInformationResult
    {
        /// <summary>
        /// The default content broken down into the named editable sections for the template - dependant upon template, so not documented
        /// </summary>
        [JsonProperty("default_content")]
        public Dictionary<string,string> DefaultContent
        {
            get;
            set;
        }

        /// <summary>
        /// The valid editable section names - dependant upon template, so not documented
        /// </summary>
        [JsonProperty("sections")]
        public List<string> Sections
        {
            get;
            set;
        }

        /// <summary>
        /// The full source of the template as if you exported it via our template editor.
        /// </summary>
        [JsonProperty("source")]
        public string Source
        {
            get;
            set;
        }

        [JsonProperty("preview")]
        public string Preview
        {
            get;
            set;
        }
    }
}
