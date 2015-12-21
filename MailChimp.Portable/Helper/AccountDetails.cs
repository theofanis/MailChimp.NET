using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Account information including payments made, plan info, 
    /// some account stats, installed modules, contact info, and more. No private 
    /// information like Credit Card numbers is available.
    /// More information: http://apidocs.mailchimp.com/api/2.0/helper/account-details.php
    /// </summary>
    
    public class AccountDetails
    {
        /// <summary>
        /// The Account username
        /// </summary>
        [JsonProperty("username")]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// The Account user unique id (for building some links)
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the Account is in Trial mode (can only send campaigns to less than 100 emails)
        /// </summary>
        [JsonProperty("is_trial")]
        public bool IsTrial
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the Account has been approved for purchases
        /// </summary>
        [JsonProperty("is_approved")]
        public bool IsApproved
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the Account has been activated
        /// </summary>
        [JsonProperty("has_activated")]
        public bool HasActivated
        {
            get;
            set;
        }

        /// <summary>
        /// The timezone for the Account - default is "US/Eastern"
        /// </summary>
        [JsonProperty("timezone")]
        public string TimeZone
        {
            get;
            set;
        }

        /// <summary>
        /// Plan Type - "monthly", "payasyougo", or "free"
        /// </summary>
        [JsonProperty("plan_type")]
        public string PlanType
        {
            get;
            set;
        }

        /// <summary>
        /// only for Monthly plans - the lower tier for list size
        /// </summary>
        [JsonProperty("plan_low")]
        public int PlanLow
        {
            get;
            set;
        }

        /// <summary>
        /// only for Monthly plans - the upper tier for list size
        /// </summary>
        [JsonProperty("plan_high")]
        public int PlanHigh
        {
            get;
            set;
        }

        /// <summary>
        /// only for Monthly plans - the start date for a monthly plan
        /// </summary>
        [JsonProperty("plan_start_date")]
        public string PlanStartDate
        {
            get;
            set;
        }

        /// <summary>
        /// only for Free and Pay-as-you-go plans - emails credits left for the account
        /// </summary>
        [JsonProperty("emails_left")]
        public int EmailsLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the account is finishing Pay As You Go credits before switching to a Monthly plan
        /// </summary>
        [JsonProperty("pending_monthly")]
        public bool PendingMonthly
        {
            get;
            set;
        }

        /// <summary>
        /// date of first payment
        /// </summary>
        [JsonProperty("first_payment")]
        public string FirstPayment
        {
            get;
            set;
        }

        /// <summary>
        /// date of most recent payment
        /// </summary>
        [JsonProperty("last_payment")]
        public string LastPayment
        {
            get;
            set;
        }

        /// <summary>
        /// total number of times the account has been logged into via the web
        /// </summary>
        [JsonProperty("times_logged_in")]
        public int TimesLoggedIn
        {
            get;
            set;
        }

        /// <summary>
        /// date/time of last login via the web
        /// </summary>
        [JsonProperty("last_login")]
        public string LastLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Monkey Rewards link for our Affiliate program
        /// </summary>
        [JsonProperty("affilate_link")]
        public string AffiliateLink
        {
            get;
            set;
        }

        /// <summary>
        /// Contact details for the account
        /// </summary>
        [JsonProperty("contact")]
        public Contact ContactInfo
        {
            get;
            set;
        }

        /// <summary>
        /// A list of addon modules installed in the account
        /// </summary>
        [JsonProperty("modules")]
        public List<Module> ModuleInfo
        {
            get;
            set;
        }

        /// <summary>
        /// A list of orders for the account
        /// </summary>
        [JsonProperty("orders")]
        public List<Order> OrderInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Rewards details for the account including credits and inspections earned, 
        /// number of referrals, referral details, and rewards used
        /// </summary>
        [JsonProperty("rewards")]
        public Rewards RewardInfo
        {
            get;
            set;
        }

        /// <summary>
        /// A list of each connected integration that can be used with campaigns
        /// </summary>
        [JsonProperty("integrations")]
        public List<Integration> IntegrationInfo
        {
            get;
            set;
        }
    }
}
