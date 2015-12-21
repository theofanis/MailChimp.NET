using Newtonsoft.Json;

namespace MailChimp.Users
{
    /// <summary>
    /// The current user's details
    /// </summary>
    
    public class UserProfile
    {
        /// <summary>
        /// the login id for this login
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// the username used to log in
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// a display name for the account - empty first/last names will return the username
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// the email tied to the account used for passwords resets and the ilk
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// the role assigned to the account
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// if available, the url for the login's avatar
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// the globally unique user id for the user account connected to
        /// </summary>
        [JsonProperty("global_user_id")]
        public string GlobalUserId { get; set; }

        /// <summary>
        /// the datacenter unique id for the user account connected to, like helper/account-details
        /// </summary>
        [JsonProperty("dc_unique_id")]
        public string DCUniqueId { get; set; }

        /// <summary>
        /// The name of the account to which the API key belongs
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
    }
}
