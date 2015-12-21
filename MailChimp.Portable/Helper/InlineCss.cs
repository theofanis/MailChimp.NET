using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Send your HTML content to have the CSS inlined and optionally remove the original styles.
    /// More information: http://apidocs.mailchimp.com/api/2.0/helper/inline-css.php
    /// </summary>
    
    public class InlineCss
    {
        /// <summary>
        /// Your HTML content with all CSS inlined, just like if we sent it.
        /// </summary>
        [JsonProperty("html")]
        public string Html
        {
            get;
            set;
        }
    }
}
