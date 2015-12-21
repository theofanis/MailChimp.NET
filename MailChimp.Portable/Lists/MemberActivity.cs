using MailChimp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Lists
{
    
    public class MemberActivity
    {
        /// <summary>
        /// THe email address of the list member
        /// </summary>
        [JsonProperty("email")]
        public EmailParameter Email
        {
            get;
            set;
        }

        /// <summary>
        /// A collection containing the activity for a list member
        /// </summary>
        [JsonProperty("activity")]
        public List<MemberActivityItem> Activity
        {
            get;
            set;
        }
    }
}
