using System.Collections.Generic;
using Newtonsoft.Json;
using MailChimp.Helper;

namespace MailChimp.Lists
{
    
    public class BatchEmailParameter
    {
        public BatchEmailParameter()
        {
            this.EmailType = "html";
        }

        /// <summary>
        /// Email information for the customer
        /// </summary>
        [JsonProperty("email")]
        public EmailParameter Email
        {
            get;
            set;
        }

        /// <summary>
        /// for the email type option (html or text).  Defaults to html
        /// </summary>
        [JsonProperty("email_type")]
        public string EmailType
        {
            get;
            set;
        }

        /// <summary>
        /// data for the various list specific and special merge vars
        /// </summary>
        [JsonProperty("merge_vars")]
        public MergeVar MergeVars
        {
            get;
            set;
        }
    }
}
