using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Contact details for the account
    /// </summary>
    
    public class Contact
    {
        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("fname")]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty("lname")]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Email Address
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Company Name
        /// </summary>
        [JsonProperty("company")]
        public string Company
        {
            get;
            set;
        }

        /// <summary>
        /// Address Line 1
        /// </summary>
        [JsonProperty("address1")]
        public string Address1
        {
            get;
            set;
        }

        /// <summary>
        /// Address Line 2
        /// </summary>
        [JsonProperty("address2")]
        public string Address2
        {
            get;
            set;
        }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city")]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// State or Province
        /// </summary>
        [JsonProperty("state")]
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Zip or Postal Code
        /// </summary>
        [JsonProperty("zip")]
        public string Zip
        {
            get;
            set;
        }

        /// <summary>
        /// Country name
        /// </summary>
        [JsonProperty("country")]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Website URL
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonProperty("phone")]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Fax number
        /// </summary>
        [JsonProperty("fax")]
        public string Fax
        {
            get;
            set;
        }

    }
}
