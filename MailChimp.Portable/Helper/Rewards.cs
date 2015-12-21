using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Includes details for the account including credits and
    /// inspections earned, number of referrals, referral details, 
    /// and rewards used
    /// </summary>
    
    public class Rewards
    {
        /// <summary>
        /// the total number of referrals this month
        /// </summary>
        [JsonProperty("referrals_this_month")]
        public int ReferralsThisMonth
        {
            get;
            set;
        }

        /// <summary>
        /// whether or not we notify the user when rewards are earned
        /// </summary>
        [JsonProperty("notify_on")]
        public string NotifyOn
        {
            get;
            set;
        }

        /// <summary>
        /// the email address address used for rewards notifications
        /// </summary>
        [JsonProperty("notify_email")]
        public string NotifyEmail
        {
            get;
            set;
        }

        /// <summary>
        /// Email credits earned
        /// </summary>
        [JsonProperty("credits")]
        public RewardEarnings Credits
        {
            get;
            set;
        }

        /// <summary>
        /// Inbox Inspections earned
        /// </summary>
        [JsonProperty("inspections")]
        public RewardEarnings Inspections
        {
            get;
            set;
        }

        /// <summary>
        /// A list of referrals
        /// </summary>
        [JsonProperty("referrals")]
        public List<RewardReferrals> Referrals
        {
            get;
            set;
        }

        /// <summary>
        /// A list of applied rewards
        /// </summary>
        [JsonProperty("applied")]
        public List<RewardApplied> AppliedRewards
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Describes credits / inspections earnings
    /// </summary>
    public class RewardEarnings
    {
        /// <summary>
        /// credits earned this month
        /// </summary>
        [JsonProperty("this_month")]
        public int ThisMonth
        {
            get;
            set;
        }

        /// <summary>
        /// credits earned all time
        /// </summary>
        [JsonProperty("total_earned")]
        public int TotalEarned
        {
            get;
            set;
        }

        /// <summary>
        /// credits remaining
        /// </summary>
        [JsonProperty("remaining")]
        public int Remaining
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Describes each reward referral
    /// </summary>
    public class RewardReferrals
    {
        /// <summary>
        /// the name of the account
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// the email address associated with the account
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// the signup date for the account
        /// </summary>
        [JsonProperty("signup_date")]
        public string SignupDate
        {
            get;
            set;
        }

        /// <summary>
        /// the source for the referral
        /// </summary>
        [JsonProperty("type")]
        public string ReferralType
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Describes each applied reward
    /// </summary>
    public class RewardApplied
    {
        /// <summary>
        /// the number of credits user
        /// </summary>
        [JsonProperty("value")]
        public int Value
        {
            get;
            set;
        }

        /// <summary>
        /// the date appplied
        /// </summary>
        [JsonProperty("date")]
        public string Date
        {
            get;
            set;
        }

        /// <summary>
        /// the order number credits were applied to
        /// </summary>
        [JsonProperty("order_id")]
        public int OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// the order description
        /// </summary>
        [JsonProperty("order_desc")]
        public string OrderDescription
        {
            get;
            set;
        }
    }
}
