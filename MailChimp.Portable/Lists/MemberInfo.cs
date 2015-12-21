﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// List member information
    /// </summary>
    
    public class MemberInfo
    {
        /// <summary>
        /// The unique id (euid) for this email address on an account
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// The email address associated with this record
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// The type of emails this customer asked to get: html or text
        /// </summary>
        [JsonProperty("email_type")]
        public string EmailType
        {
            get;
            set;
        }

        /// <summary>
        /// The subscription status for this email address, either pending, subscribed, unsubscribed, or cleaned
        /// </summary>
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// IP Address this address signed up from. This may be blank if single optin is used.
        /// </summary>
        [JsonProperty("ip_signup")]
        public string IPSignup
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time the double optin was initiated. This may be blank if single optin is used. (UTC time)
        /// </summary>
        [JsonProperty("timestamp_signup")]
        public DateTime? TimestampSignup
        {
            get;
            set;
        }

        /// <summary>
        /// IP Address this address opted in from
        /// </summary>
        [JsonProperty("ip_opt")]
        public string IPOptIn
        {
            get;
            set;
        }

        /// <summary>
				/// The date/time the optin completed. (UTC time)
        /// </summary>
        [JsonProperty("timestamp_opt")]
				public DateTime? TimestampOptIn
        {
            get;
            set;
        }

        /// <summary>
        /// the rating of the subscriber. This will be 1 - 5 as described 
        /// <a href="http://eepurl.com/f-2P" target="_blank">here</a>
        /// </summary>
        [JsonProperty("member_rating")]
        public int MemberRating
        {
            get;
            set;
        }

        /// <summary>
        /// If the user is unsubscribed and they unsubscribed from a specific campaign, 
        /// that campaign_id will be listed, otherwise this is not returned.
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }

        /// <summary>
				/// The date/time this email address entered it's current status (UTC time)
        /// </summary>
        [JsonProperty("timestamp")]
				public DateTime? Timestamp
        {
            get;
            set;
        }

        /// <summary>
				/// The last time this record was changed. If the record is old enough, this may be blank. (UTC time)
        /// </summary>
        [JsonProperty("info_changed")]
				public DateTime? InfoChanged
        {
            get;
            set;
        }

        /// <summary>
        /// The Member id used in our web app, allows you to create a link directly to it
        /// </summary>
        [JsonProperty("web_id")]
        public int WebId
        {
            get;
            set;
        }

        /// <summary>
        /// The Member id used in our web app, allows you to create a link directly to it
        /// </summary>
        [JsonProperty("leid")]
        public int LEId
        {
            get;
            set;
        }

        /// <summary>
        /// The list id the for the member record being returned
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// The list name the for the member record being returned
        /// </summary>
        [JsonProperty("list_name")]
        public string ListName
        {
            get;
            set;
        }

        /// <summary>
        /// if set/detected, a language code from <a href="http://kb.mailchimp.com/article/can-i-see-what-languages-my-subscribers-use#code" target="_blank">here</a>
        /// </summary>
        [JsonProperty("language")]
        public string Language
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the member is a <a href="http://mailchimp.com/features/golden-monkeys/" target="_blank">Golden Monkey</a> or not.
        /// </summary>
        [JsonProperty("is_gmonkey")]
        public bool IsGoldenMonkey
        {
            get;
            set;
        }

        /// <summary>
        /// the geographic information if we have it
        /// </summary>
        [JsonProperty("geo")]
        [JsonConverter(typeof(SingleArrayValueConverter<MemberGeo>))]
        public MemberGeo GeoData
        {
            get;
            set;
        }

        /// <summary>
        /// the client we've tracked the address as using
        /// </summary>
        [JsonProperty("clients")]
        [JsonConverter(typeof(SingleArrayValueConverter<Client>))]
        public Client ClientInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Static segments this member belongs to
        /// </summary>
        [JsonProperty("static_segments")]
        public List<StaticSegment> StaticSegments {
            get;
            set;
        }

        /// <summary>
        /// Notes entered for this member
        /// </summary>
        [JsonProperty("notes")]
        public List<MemberNote> Notes
        {
            get;
            set;
        }

        /// <summary>
        /// Merge variables that apply to this member
        /// </summary>
        [JsonProperty("merges")]
        public MergeVar MemberMergeInfo { get; set; }
    }
}
