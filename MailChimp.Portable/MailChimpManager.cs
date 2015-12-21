﻿using System;
using System.Collections.Generic;
using System.Linq;
using MailChimp.Campaigns;
using MailChimp.Ecomm;
using MailChimp.Errors;
using MailChimp.Folders;
using MailChimp.Gallery;
using MailChimp.Helper;
using MailChimp.Lists;
using MailChimp.Reports;
using MailChimp.Templates;
using MailChimp.Users;
//using ServiceStack.Text;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp
{
    #region Interface
    public interface IMailChimpManager
    {
        /// <summary>
        /// Gets / sets your API key for all operations.  
        /// For help getting your API key, please see 
        /// http://kb.mailchimp.com/article/where-can-i-find-my-api-key
        /// </summary>
        string APIKey { get; set; }

        /// <summary>
        /// Get the content (both html and text) for a campaign either as it would appear in the campaign archive or as the raw, original content
        /// </summary>
        /// <param name="cId">the campaign id to get content for (can be gathered using GetCampaigns())</param>
        /// <param name="view">optional one of "archive" (default), "preview" (like our popup-preview) or "raw"</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <returns></returns>
        CampaignContent GetCampaignContent(string cId, string view = "archive", EmailParameter emailParam = null);

        /// <summary>
        ///Create a new draft campaign to send. You can not have more than 32,000 campaigns in your account.
        ///See http://apidocs.mailchimp.com/api/2.0/campaigns/create.php for explanation of full options.
        /// </summary>
        /// <param name="type">The Campaign Type to create - one of "regular", "plaintext", "absplit", "rss", "auto"</param>
        /// <param name="options">A struct of the standard options for this campaign.</param>
        /// <param name="content">The content for this campaign </param>
        /// <param name="segmentOptions">optional - if you wish to do Segmentation with this campaign this array should contain: see CampaignSegmentTest(). It's suggested that you test your options against campaignSegmentTest().</param>
        /// <param name="typeOptions">optional - various extra options based on the campaign type</param>
        /// <returns></returns>
        Campaign CreateCampaign(string type, CampaignCreateOptions options, CampaignCreateContent content, CampaignSegmentOptions segmentOptions = null, CampaignTypeOptions typeOptions = null);

        /// <summary>
        /// Delete a campaign. Seriously, "poof, gone!" - be careful! 
        /// Seriously, no one can undelete these.
        /// </summary>
        /// <param name="cId">the Campaign Id to delete</param>
        /// <returns></returns>
        CampaignActionResult DeleteCampaign(string cId);

        /// <summary>
        /// Get the list of campaigns and their details matching the specified filters
        /// </summary>
        /// <param name="filterParam">Filters to apply</param>
        /// <param name="start">control paging of campaigns, start results at this campaign #</param>
        /// <param name="limit">control paging of campaigns, number of campaigns to return with each call</param>
        /// <param name="sort_field">one of "create_time", "send_time", "title", "subject" . Invalid values will fall back on "create_time" - case insensitive</param>
        /// <param name="sort_dir">"DESC" for descending (default), "ASC" for Ascending. Invalid values will fall back on "DESC" - case insensitive.</param>
        /// <returns></returns>
        CampaignListResult GetCampaigns(CampaignFilter filterParam = null, int start = 0, int limit = 25, string sort_field = "create_time", string sort_dir = "DESC");

        /// <summary>
        /// Pause an AutoResponder or RSS campaign from sending
        /// </summary>
        /// <param name="cId">the id of the campaign to pause</param>
        /// <returns></returns>
        CampaignActionResult PauseCampaign(string cId);

        /// <summary>
        /// Replicate a campaign.
        /// </summary>
        /// <param name="cId">the id of the campaign to replicate</param>
        /// <returns></returns>
        Campaign ReplicateCampaign(string cId);

        /// <summary>
        /// Resume sending an AutoResponder or RSS campaign
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        CampaignActionResult ResumeCampaign(string cId);

        /// <summary>
        /// Schedule a campaign to be sent in batches sometime in the future. 
        /// Only valid for "regular" campaigns
        /// </summary>
        /// <param name="cId">the id of the campaign to schedule</param>
        /// <param name="scheduleTime">the time to schedule the campaign.</param>
        /// <param name="numBatches">the number of batches between 2 and 26 to send</param>
        /// <param name="staggerMins">the number of minutes between each batch - 5, 10, 15, 20, 25, 30, or 60</param>
        /// <returns></returns>
        CampaignActionResult ScheduleBatchCampaign(string cId, string scheduleTime, int numBatches = 2, int staggerMins = 5);

        /// <summary>
        /// Schedule a campaign to be sent in the future
        /// </summary>
        /// <param name="cId">the id of the campaign to schedule</param>
        /// <param name="scheduleTime">the time to schedule the campaign. For A/B Split "schedule" campaigns, the time for Group A - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        /// <param name="scheduleTimeB">the time to schedule Group B of an A/B Split "schedule" campaign - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        /// <returns></returns>
        CampaignActionResult ScheduleCampaign(string cId, string scheduleTime, string scheduleTimeB = "");

        /// <summary>
        ///Allows one to test their segmentation rules before creating a campaign using them. 
        /// </summary>
        /// <param name="listId">The list id to test</param>
        /// <param name="options">The segmentation options to apply</param>
        /// <returns></returns>
        CampaignSegmentTestResult CampaignSegmentTest(string listId, CampaignSegmentOptions options);

        /// <summary>
        /// Send a given campaign immediately. 
        /// For RSS campaigns, this will "start" them
        /// </summary>
        /// <param name="cId">the id of the campaign</param>
        /// <returns></returns>
        CampaignActionResult SendCampaign(string cId);

        /// <summary>
        /// Send a test of this campaign to the provided email addresses
        /// </summary>
        /// <param name="cId">the id of the campaign to test</param>
        /// <param name="testEmails">an array of email address to 
        /// receive the test message</param>
        /// <param name="sendType">by default just html is sent - can be "html" or "text" send specify the format</param>
        /// <returns></returns>
        CampaignActionResult SendCampaignTest(string cId, List<string> testEmails = null, string sendType = "html");

        /// <summary>
        /// Unschedule a campaign that is scheduled to be sent in the future
        /// </summary>
        /// <param name="cId">the id of the campaign to unschedule</param>
        /// <returns></returns>
        CampaignActionResult UnscheduleCampaign(string cId);

        /// <summary>
        /// Update just about any setting besides type for a campaign that has not been sent. See campaigns/create() for details.
        /// </summary>
        /// <param name="cid">The Campaign Id to update</param>
        /// <param name="name">The parameter name ( see campaigns/create() ). This will be that parameter name (options, content, segment_opts) except "type_opts", which will be the name of the type - rss, auto, etc. The campaign "type" can not be changed.</param>
        /// <param name="value">An appropriate set of values for the parameter ( see campaigns/create() ). For additional parameters, this is the same value passed to them.</param>
        /// <returns>Updated campaign details and any errors</returns>
        CampaignUpdateResult UpdateCampaign(string cid, string name, object value);

        /// <summary>
        /// Get the HTML template content sections for a campaign. 
        /// Note that this will return very jagged, non-standard results based on the template a campaign is using. 
        /// You only want to use this if you want to allow editing template sections in your application. 
        /// </summary>
        /// <param name="cId">the campaign id to get content for</param>
        /// <returns>content containing all content section for the campaign - section name are dependent upon the template used</returns>
        Dictionary<string, string> GetCampaignTemplateContent(string cId);

        /// <summary>
        /// Import Ecommerce Order Information to be used for Segmentation
        /// </summary>
        /// <param name="order">information pertaining to the order that has completed</param>
        /// <returns></returns>
        CompleteResult AddOrder(Ecomm.Order order);

        /// <summary>
        /// Delete Ecommerce Order Information used for segmentation.
        /// </summary>
        /// <param name="storeId">the store id the order belongs to</param>
        /// <param name="orderId">the order id (generated by the store) to delete</param>
        /// <returns></returns>
        CompleteResult DeleteOrder(string storeId, string orderId);

        /// <summary>
        /// Retrieve the Ecommerce Orders for an account
        /// </summary>
        /// <param name="campaignId">limit the returned orders to a particular campaign</param>
        /// <param name="start">the page number to start at - defaults to 1st page of data (page 0)</param>
        /// <param name="limit">the number of results to return - defaults to 100, upper limit set at 500</param>
        /// <param name="since">pull only messages since this time - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        OrderListResult GetOrders(string campaignId = null, int start = 0, int limit = 100, string since = null);

        /// <summary>
        /// List all the folders of a certain type
        /// </summary>
        /// <param name="folderType">the type of folders to return "campaign", "autoresponder", or "template"</param>
        /// <returns></returns>
        List<FolderListResult> GetFolders(string folderType);

        /// <summary>
        /// Add a new folder to file campaigns, autoresponders, or templates in
        /// </summary>
        /// <param name="folderName">a unique name for a folder (max 100 bytes)</param>
        /// <param name="folderType">the type of folder to create - one of "campaign", "autoresponder", or "template".</param>
        /// <returns></returns>
        FolderAddResult AddFolder(string folderName, string folderType);

        /// <summary>
        /// Delete a campaign, autoresponder, or template folder. Note that this will simply make whatever was in the folder appear unfiled, no other data is removed
        /// </summary>
        /// <param name="fId"></param>
        /// <param name="folderType"></param>
        /// <returns></returns>
        FolderActionResult DeleteFolder(int fId, string folderType);

        /// <summary>
        /// Update the name of a folder for campaigns, autoresponders, or templates
        /// </summary>
        /// <param name="fId">the folder id to update</param>
        /// <param name="folderName">a new, unique name for the folder (max 100 bytes)</param>
        /// <param name="folderType">the type of folder to update - one of "campaign", "autoresponder", or "template"</param>
        /// <returns></returns>
        FolderActionResult UpdateFolder(int fId, string folderName, string folderType);

        /// <summary>
        /// Add a file to a folder
        /// </summary>
        /// <param name="fileId">the id of the file you want to add to a folder, as returned by the list call </param>
        /// <param name="folderId">the id of the folder to add the file to, as returned by the listFolders call </param>
        bool GalleryFolderAddFileTo(int fileId, int folderId);

        /// <summary>
        /// Adds a folder to the file gallery
        /// </summary>
        /// <param name="name">the name of the folder to add (255 character max) </param>
        AddGalleryFolderResult GalleryFolderAdd(string name);

        /// <summary>
        /// Return a section of the image gallery
        /// </summary>
        /// <param name="type">Optional the gallery type to return - images or files - default to images</param>
        /// <param name="start">Optional for large data sets, the page number to start at - defaults to 1st page of data (page 0)</param>
        /// <param name="limit">Optional for large data sets, the number of results to return - defaults to 25, upper limit set at 100</param>
        /// <param name="sortBy">Optional field to sort by - one of size, time, name - defaults to time </param>
        /// <param name="sortDir">Optional field to sort by - one of asc, desc - defaults to desc</param>
        /// <param name="searchTerm">Optional a term to search for in names</param>
        /// <param name="folderId">Optional to return files that are in a specific folder</param>
        /// <returns></returns>
        GalleryListResult GetGalleries(string type = "images", int start = 0, int limit = 25, string sortBy = "time", string sortDir = "desc", string searchTerm = null, int folderId = 0);

        GalleryFoldersResult GetGalleryFolders(int start = 0, int limit = 25, string searchTerm = null);

        /// <summary>
        /// Remove all files from a folder
        /// </summary>
        /// <remarks>the files are not deleted, they are only removed from the folder</remarks>
        /// <param name="folderId">the id of the folder to remove the file from</param>
        bool GalleryFolderRemoveAllFilesFrom(int folderId);

        /// <summary>
        /// Remove a file from a folder
        /// </summary>
        /// <param name="fileId">the id of the file you want to remove from the folder</param>
        /// <param name="folderId">the id of the folder to remove the file from</param>
        bool GalleryFolderRemoveFileFrom(int fileId, int folderId);

        /// <summary>
        /// Remove a folder
        /// </summary>
        /// <param name="folderId">the id of the folder to remove</param>
        bool GalleryFolderRemove(int folderId);

        /// <summary>
        /// Get all email addresses that complained about a campaign sent to a list
        /// </summary>
        /// <param name="listId">the list id to pull abuse reports for (can be gathered using GetLists())</param>
        /// <param name="start">optional for large data sets, the page number to start at - defaults to 1st page of data (page 0)</param>
        /// <param name="limit">optional for large data sets, the number of results to return - defaults to 500, upper limit set at 1000</param>
        /// <param name="since">optional pull only messages since this time - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        /// <returns></returns>
        AbuseResult GetListAbuseReports(string listId, int start = 0, int limit = 500, string since = "");

        /// <summary>
        /// Access up to the previous 180 days of daily detailed aggregated activity stats for a given list. Does not include AutoResponder activity.
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <returns></returns>
        List<ListActivity> GetListActivity(string listId);

        /// <summary>
        /// Get the most recent 100 activities for particular list members (open, click, bounce, unsub, abuse, sent to, etc.)
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="listOfEmails">an array of up to 50 email structs</param>
        /// <returns></returns>
        MemberActivityResult GetMemberActivity(string listId, List<EmailParameter> listOfEmails);

        /// <summary>
        /// Subscribe a batch of email addresses to a list at once. Maximum batch sizes vary based 
        /// on the amount of data in each record, though you should cap them 
        /// at 5k - 10k records, depending on your experience. These calls are also 
        /// long, so be sure you increase your timeout values.
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="listOfEmails"></param>
        /// <param name="doubleOptIn"></param>
        /// <param name="updateExisting"></param>
        /// <param name="replaceInterests"></param>
        /// <returns></returns>
        BatchSubscribeResult BatchSubscribe(string listId, List<BatchEmailParameter> listOfEmails, bool doubleOptIn = true, bool updateExisting = false, bool replaceInterests = true);

        /// <summary>
        /// Unsubscribe a batch of email addresses from a list
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="listOfEmails">array of emails to unsubscribe</param>
        /// <param name="deleteMember">flag to completely delete the member from your list instead of just unsubscribing, default to false</param>
        /// <param name="sendGoodbye">flag to send the goodbye email to the email addresses, defaults to true</param>
        /// <param name="sendNotify">flag to send the unsubscribe notification email to the address defined in the list email notification settings, defaults to false</param>
        /// <returns></returns>
        BatchUnsubscribeResult BatchUnsubscribe(string listId, List<EmailParameter> listOfEmails, bool deleteMember = false, bool sendGoodbye = true, bool sendNotify = false);

        /// <summary>
        /// Retrieve all of the lists defined for your user account
        /// </summary>
        /// <param name="filterParam">filters to apply to this query - all are optional</param>
        /// <param name="start">optional - control paging of lists, start results at this list #, defaults to 1st page of data (page 0)</param>
        /// <param name="limit">optional - control paging of lists, number of lists to return with each call, defaults to 25 (max=100)</param>
        /// <param name="sort_field">optional - "created" (the created date, default) or "web" (the display order in the web app). Invalid values will fall back on "created" - case insensitive.</param>
        /// <param name="sort_dir">optional - "DESC" for descending (default), "ASC" for Ascending - case insensitive. Note: to get the exact display order as the web app you'd use "web" and "ASC"</param>
        /// <returns></returns>
        ListResult GetLists(ListFilter filterParam = null, int start = 0, int limit = 25, string sort_field = "created", string sort_dir = "DESC");

        /// <summary>
        /// Add an interest group for a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        CompleteResult AddListInterestGroup(string listId, string group_name, int grouping_id);

        /// <summary>
        /// Deletes an interest group of a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        CompleteResult DeleteListInterestGroup(string listId, string group_name, int grouping_id);

        /// <summary>
        /// Change the name of an Interest Group of a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        CompleteResult UpdateListInterestGroup(string listId, string old_name, string new_name, int grouping_id);

        /// <summary>
        /// Add a new Interest Grouping - if interest groups for the List are not yet enabled, adding the first grouping will automatically turn them on.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        InterestGroupingResult AddListInterestGrouping(string listId, string name, string type, List<string> groups);

        /// <summary>
        /// Delete an existing Interest Grouping - this will permanently delete all contained interest groups and will remove those selections from all list members
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        CompleteResult DeleteListInterestGrouping(string listId, int grouping_id);

        /// <summary>
        /// Update an existing Interest Grouping
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        CompleteResult UpdateListInterestGrouping(string listId, int grouping_id, string name, string value);

        /// <summary>
        /// Retrieve the interest groups for a list.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="counts">Optional: whether or not to return subscriber counts for each group. Defaults to false since that slows this call down a ton for large lists.</param>
        /// <returns></returns>
        List<InterestGrouping> GetListInterestGroupings(string listId, bool counts = false);

        /// <summary>
        /// Retrieve the locations (countries) that the list's subscribers have been tagged to based on geocoding their IP address
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <returns></returns>
        List<SubscriberLocation> GetLocationsForList(string listId);

        /// <summary>
        /// Get all the information for particular members of a list
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="listOfEmails">an array of up to 50 email address struct to retrieve member information for</param>
        /// <returns></returns>
        MemberInfoResult GetMemberInfo(string listId, List<EmailParameter> listOfEmails);

        /// <summary>
        /// Get all of the list members for a list that are of a particular status and 
        /// potentially matching a segment. This will cause locking, so don't run multiples at once.
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="status">optional - the status to get members for - one of(subscribed, unsubscribed, cleaned)</param>
        /// <param name="start">for large data sets, the page number to start at</param>
        /// <param name="limit">for large data sets, the number of results to return - defaults to 25, upper limit set at 100</param>
        /// <param name="sort_field">the data field to sort by - mergeX (1-30), your custom merge tags, "email", "rating","last_update_time", or "optin_time" - invalid fields will be ignored</param>
        /// <param name="sort_dir">the direct - ASC or DESC</param>
        /// <param name="segment">refine the members list by segments (maximum of 5 conditions)</param>
        /// <returns></returns>
        MembersResult GetAllMembersForList(string listId, string status = "subscribed", int start = 0, int limit = 25, string sort_field = "", string sort_dir = "ASC", CampaignSegmentOptions segment = null);

        /// <summary>
        /// Subscribe the provided email to a list. By default this sends a 
        /// confirmation email - you will not see new members until the 
        /// link contained in it is clicked!
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="mergeVars">optional merges for the email (FNAME, LNAME, etc.)</param>
        /// <param name="emailType">optional email type preference for the email (html or text - defaults to html)</param>
        /// <param name="doubleOptIn">optional flag to control whether a double opt-in confirmation message is sent, defaults to true. Abusing this may cause your account to be suspended.</param>
        /// <param name="updateExisting">optional flag to control whether existing subscribers should be updated instead of throwing an error, defaults to false</param>
        /// <param name="replaceInterests">optional flag to determine whether we replace the interest groups with the groups provided or we add the provided groups to the member's interest groups (optional, defaults to true)</param>
        /// <param name="sendWelcome">optional if your double_optin is false and this is true, we will send your lists Welcome Email if this subscribe succeeds - this will *not* fire if we end up updating an existing subscriber. If double_optin is true, this has no effect. defaults to false.</param>
        /// <returns></returns>
        /// <example>
        /// The example below shows how to add your own merge parameters by passing your own class that inherits from MergeVar:
        /// <code>
        /// [System.Runtime.Serialization.DataContract]
        /// public class MyMergeVar : MergeVar
        /// {
        ///     [System.Runtime.Serialization.DataMember(Name = "FNAME")]
        ///     public string FirstName { get; set; }
        ///     [System.Runtime.Serialization.DataMember(Name = "LNAME")]
        ///     public string LastName { get; set; }
        /// }
        /// 
        /// MailChimpManager mc = new MailChimpManager("YourApiKeyHere-us2");
        /// EmailParameter email = new EmailParameter()
        /// {
        ///     Email = "customeremail@righthere.com"
        /// };
        /// MyMergeVar myMergeVars = new MyMergeVar();
        /// myMergeVars.Groupings = new List&lt;Grouping&gt;();
        /// myMergeVars.Groupings.Add(new Grouping());
        /// myMergeVars.Groupings[0].Id = 1234; // replace with your grouping id
        /// myMergeVars.Groupings[0].GroupNames = new List&lt;string&gt;();
        /// myMergeVars.Groupings[0].GroupNames.Add("Your Group Name");
        /// myMergeVars.FirstName = "Testy";
        /// myMergeVars.LastName = "Testerson";
        /// EmailParameter results = mc.Subscribe(strListID, email, myMergeVars);
        /// </code>
        /// </example>
        EmailParameter Subscribe(string listId, EmailParameter emailParam, MergeVar mergeVars = null, string emailType = "html", bool doubleOptIn = true, bool updateExisting = false, bool replaceInterests = true, bool sendWelcome = false);

        /// <summary>
        /// Updates the member in the list with the matching emailParam  
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="mergeVars">merges for the email (new-email, FNAME, LNAME, etc.)</param>
        /// <param name="emailType">optional email type preference for the email (html or text), leave blank to keep the existing preference</param>
        /// <param name="replaceInterests">optional flag to determine whether we replace the interest groups with the groups provided or we add the provided groups to the member's interest groups (optional, defaults to true)</param>
        /// <returns></returns>
        EmailParameter UpdateMember(string listId, EmailParameter emailParam, MergeVar mergeVars, string emailType = "", bool replaceInterests = true);

        /// <summary>
        /// Unsubscribe the given email address from the list
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="deleteMember">optional - flag to completely delete the member from your list instead of just unsubscribing, default to false</param>
        /// <param name="sendGoodbye">optional - flag to send the goodbye email to the email address, defaults to true</param>
        /// <param name="sendNotify">optional - flag to send the unsubscribe notification email to the address defined in the list email notification settings, defaults to true</param>
        /// <returns></returns>
        UnsubscribeResult Unsubscribe(string listId, EmailParameter emailParam, bool deleteMember = false, bool sendGoodbye = true, bool sendNotify = true);

        /// <summary>
        /// Get the list of merge tags for a given list, including their name, tag, and required setting
        /// </summary>
        /// <param name="listIds">the list ids to retrieve merge vars for. Get by calling lists/list() - max of 100 </param>
        MergeVarResult GetMergeVars(IEnumerable<string> listIds);

        /// <summary>
        /// Add a new merge tag to a given list
        /// </summary>
        /// <param name="listId">The list id to connect to</param>
        /// <param name="tag">The merge tag to add, e.g. FNAME. 
        /// 10 bytes max, valid characters: "A-Z 0-9 _" no spaces, dashes, etc.</param>
        /// <param name="name">The long description of the tag being added, used for user displays - max 50 bytes</param>
        /// <param name="options">optional Various options for this merge var</param>
        /// <returns></returns>
        MergeVarItemResult AddMergeVar(string listId, string tag, string name, MergeVarOptions options = null);

        /// <summary>
        /// Update most parameters for a merge tag on a given list. You cannot currently change the merge type
        /// </summary>
        /// <param name="listId">The list id to connect to</param>
        /// <param name="tag">The merge tag to update</param>
        /// <param name="options">updated options for this merge var</param>
        /// <returns></returns>
        MergeVarItemResult UpdateMergeVar(string listId, string tag, MergeVarOptions options);

        /// <summary>
        /// Delete a merge tag from a given list and all its members. 
        /// Seriously - the data is removed from all members as well!
        /// Note that on large lists this method may seem a bit slower than calls you typically make.
        /// </summary>
        /// <param name="listId">the list id to connect to.</param>
        /// <param name="tag">The merge tag to delete</param>
        /// <returns></returns>
        CompleteResult DeleteMergeVar(string listId, string tag);

        /// <summary>
        /// Completely resets all data stored in a merge var on a list. 
        /// All data is removed and this action can not be undone.
        /// </summary>
        /// <param name="listId">the list id to connect to.</param>
        /// <param name="tag">The merge tag to reset</param>
        /// <returns></returns>
        CompleteResult ResetMergeVar(string listId, string tag);

        /// <summary>
        /// Sets a particular merge var to the specified value for every list member. 
        /// Only merge var ids 1 - 30 may be modified this way.  This is generally a dirty method unless 
        /// you're fixing data since you should probably be using default_values and/or conditional content. 
        /// As with lists/merge-var-reset(), this can not be undone.
        /// </summary>
        /// <param name="listId">the list id to connect to.</param>
        /// <param name="tag">The merge tag to set</param>
        /// <param name="value">The value to set to</param>
        /// <returns></returns>
        CompleteResult SetMergeVar(string listId, string tag, string value);

        /// <summary>
        /// Save a segment against a list for later use.
        /// There is no limit to the number of segments which can be saved. Static Segments are not tied to any merge data, interest groups, etc.
        /// They essentially allow you to configure an unlimited number of custom segments which will have standard performance.
        /// When using proper segments, Static Segments are one of the available options for segmentation just as if you used a merge var (and they can be used with other segmentation options), though performance may degrade at that point.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentName">Name of the static segment.</param>
        /// <returns></returns>
        StaticSegmentAddResult AddStaticSegment(string listId, string staticSegmentName);

        /// <summary>
        /// Save a segment against a list for later use. There is no limit to the number of segments which can be saved. 
        /// Static Segments are not tied to any merge data, interest groups, etc. They essentially allow you to configure 
        /// an unlimited number of custom segments which will have standard performance. When using proper segments, 
        /// Static Segments are one of the available options for segmentation just as if you used a merge var (and they 
        /// can be used with other segmentation options), though performance may degrade at that point. Saved Segments 
        /// (called "auto-updating" in the app) are essentially just the match+conditions typically used.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="segmentOptions">Various options for the new segment</param>
        /// <returns></returns>
        SegmentAddResult AddSegment(string listId, AddCampaignSegmentOptions segmentOptions);

        /// <summary>
        /// Delete a static segment. Note that this will, of course, remove any member affiliations with the segment
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to delete - get from getStaticSegmentsForList()</param>
        /// <returns></returns>
        StaticSegmentActionResult DeleteStaticSegment(string listId, int staticSegmentID);

        /// <summary>
        /// Add list members to a static segment. 
        /// It is suggested that you limit batch size to no more than 10,000 addresses per call. 
        /// Email addresses must exist on the list in order to be included - this will not subscribe them to the list!
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to delete - get from getStaticSegmentsForList()</param>
        /// <param name="emails">Array of emails to add to the segment</param>
        /// <returns></returns>
        StaticSegmentMembersAddResult AddStaticSegmentMembers(string listId, int staticSegmentID, List<EmailParameter> emails);

        /// <summary>
        /// Remove list members to a static segment. 
        /// It is suggested that you limit batch size to no more than 10,000 addresses per call. 
        /// Email addresses must exist on the list in order to be included - this will not unsubscribe them from the list!
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to delete - get from getStaticSegmentsForList()</param>
        /// <param name="emails">Array of emails to remove from the segment</param>
        /// <returns></returns>
        StaticSegmentMembersDeleteResult DeleteStaticSegmentMembers(string listId, int staticSegmentID, List<EmailParameter> emails);

        /// <summary>
        /// Resets a static segment - removes all members from the static segment. 
        /// Note: does not actually affect list member data
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to be reset - get from getStaticSegmentsForList()</param>
        /// <returns></returns>
        StaticSegmentActionResult ResetStaticSegment(string listId, int staticSegmentID);

        /// <summary>
        /// Retrieve all of the Static Segments for a list.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <returns></returns>
        List<StaticSegmentResult> GetStaticSegmentsForList(string listId);

        /// <summary>
        /// Retrieve all of Saved Segments for a list.
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="segmentType">optional - optional, if specified should be "static" or "saved" and will limit the returned entries to that type</param>
        /// <returns></returns>
        SegmentResult GetSegmentsForList(string listId, string segmentType);

        /// <summary>
        /// Return the Webhooks configured for the given list
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <returns></returns>
        List<WebhookInfo> GetWebhooks(string listId);

        /// <summary>
        /// Add a new Webhook URL for the given list
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="url">a valid URL for the Webhook - it will be validated. note that a url may only exist on a list once.</param>
        /// <param name="actions">optional - optional a hash of actions to fire this Webhook for</param>
        /// <param name="sources">optional - optional sources to fire this Webhook for</param>
        /// <returns></returns>
        WebhookAddResult AddWebhook(string listId, string url, WebhookActions actions = null, WebhookSources sources = null);

        /// <summary>
        /// Delete an existing Webhook URL from a given list
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="url">the URL of a Webhook on this list</param>
        /// <returns></returns>
        CompleteResult DeleteWebhook(string listId, string url);

        /// <summary>
        /// Retrieve lots of account information including payments made, plan info, 
        /// some account stats, installed modules, contact info, and more. No private 
        /// information like Credit Card numbers is available.
        /// More information: http://apidocs.mailchimp.com/api/2.0/helper/account-details.php
        /// </summary>
        /// <param name="exclude">Allows controlling which extra arrays are returned since they can 
        /// slow down calls. Valid keys are "modules", "orders", "rewards-credits", 
        /// "rewards-inspections", "rewards-referrals", "rewards-applied", "integrations". 
        /// Hint: "rewards-referrals" is typically the culprit. To avoid confusion, 
        /// if data is excluded, the corresponding key will not be returned at all.</param>
        /// <returns></returns>
        AccountDetails GetAccountDetails(string[] exclude = null);

        /// <summary>
        /// Retrieve minimal data for all Campaigns a member was sent
        /// </summary>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="filterListId">A list_id to limit the campaigns to</param>
        /// <returns>an array of structs containing campaign data for each matching campaign</returns>
        List<CampaignForEmail> GetCampaignsForEmail(EmailParameter emailParam, string filterListId = "");

        /// <summary>
        /// Retrieve minimal List data for all lists a member is subscribed to.
        /// </summary>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <returns></returns>
        List<ListForEmail> GetListsForEmail(EmailParameter emailParam);

        /// <summary>
        /// Return the current Chimp Chatter messages for an account.
        /// </summary>
        /// <returns></returns>
        List<ChimpChatterMessage> GetChimpChatter();

        /// <summary>
        /// "Ping" the MailChimp API - a simple method you can call that will 
        /// return a constant value as long as everything is good. Note than unlike 
        /// most all of our methods, we don't throw an Exception if we are having 
        /// issues. You will simply receive a different string back that will explain 
        /// our view on what is going on.
        /// </summary>
        /// <returns></returns>
        PingMessage Ping();

        /// <summary>
        /// Search account wide or on a specific list using the specified query terms
        /// </summary>
        /// <returns></returns>
        Matches SearchMembers(string query, string listId = "", int offest = 0);

        /// <summary>
        /// Send your HTML content to have the CSS inlined and optionally remove the original styles.
        /// More information: http://apidocs.mailchimp.com/api/2.0/helper/inline-css.php
        /// </summary>
        /// <param name="html">Your HTML content</param>
        /// <param name="strip_css">optional - optional Whether you want the CSS <style> tags stripped from the returned document. Defaults to false.</param>
        /// <returns></returns>
        InlineCss InlineCss(string html, bool strip_css = false);

        List<VerifiedDomain> GetVerifiedDomains();

        /// <summary>
        /// Invite a user to your account
        /// </summary>
        /// <param name="email">A valid email address to send the invitation to</param>
        /// <param name="role">the role to assign to the user - one of viewer, author, manager, admin</param>
        /// <param name="message">an optional message to include. Plain text any HTML tags will be stripped</param>
        /// <returns></returns>
        UserActionResult InviteUser(string email, string role = "viewer", string message = "");

        /// <summary>
        /// Resend an invite a user to your account. Note, if the same address has been invited multiple times, 
        /// this will simpy re-send the most recent invite
        /// </summary>
        /// <param name="email">A valid email address to resend an invitation to</param>
        /// <returns></returns>
        UserActionResult InviteResend(string email);

        /// <summary>
        /// Revoke an invitation sent to a user to your account. Note, if the same address has been invited multiple times, this will simpy revoke the most recent invite
        /// </summary>
        /// <param name="email">A valid email address to revoke</param>
        /// <returns></returns>
        UserActionResult InviteRevoke(string email);

        /// <summary>
        /// Retrieve the list of pending users invitations have been sent for.
        /// </summary>
        /// <returns></returns>
        List<UserInvite> GetInvites();

        /// <summary>
        /// Retrieve the list of active logins.
        /// </summary>
        /// <returns></returns>
        List<UserLoginsResult> GetLogins();

        /// <summary>
        /// Retrieve the profile for the login owning the provided API Key
        /// </summary>
        /// <returns></returns>
        UserProfile GetUserProfile();

        /// <summary>
        /// Create a new user template, NOT campaign content. These templates can then be applied while creating campaigns.
        /// </summary>
        /// <param name="templateName">The name for the template - names must be unique and a max of 50 bytes</param>
        /// <param name="html">A string specifying the entire template to be created. This is NOT campaign content. They are intended to utilize our template language.</param>
        /// <param name="folderId">Optional - the folder to put this template in.</param>
        /// <returns></returns>
        TemplateAddResult AddTemplate(string templateName, string html, int? folderId = null);

        /// <summary>
        /// Delete (deactivate) a user template
        /// </summary>
        /// <param name="templateId">The id of the user template to delete</param>
        /// <returns></returns>
        TemplateDeleteResult DeleteTemplate(int templateId);

        /// <summary>
        /// Pull details for a specific template to help support editing
        /// </summary>
        /// <param name="templateId">The template id - get from templates/list()</param>
        /// <param name="type">Optional - optional the template type to load - one of 'user', 'gallery', 'base', defaults to user.</param>
        /// <returns></returns>
        TemplateInformationResult GetTemplateInformation(int templateId, string type = null);

        /// <summary>
        /// Retrieve various templates available in the system, allowing some thing similar to our template gallery to be created.
        /// </summary>
        /// <param name="templateTypes">optional - optional the types of templates to return</param>
        /// <param name="templateFilters">optional - optional options to control how inactive templates are returned, if at alld</param>
        /// <returns></returns>
        TemplateListResult GetTemplates(TemplateTypes templateTypes = null, TemplateFilters templateFilters = null);

        /// <summary>
        /// Undelete (reactivate) a user template
        /// </summary>
        /// <param name="templateId">The id of the user template to reactivate.</param>
        /// <returns></returns>
        TemplateUndeleteResult UndeleteTemplate(int templateId);

        /// <summary>
        /// Replace the content of a user template, NOT campaign content.
        /// </summary>
        /// <param name="templateId">The id of the user template to update</param>
        /// <param name="value">The values to updates - while both are optional, at least one should be provided. Both can be updated at the same time.</param>
        /// <returns></returns>
        TemplateUpdateResult UpdateTemplate(int templateId, TemplateUpdateValue value);

        /// <summary>
        /// Retrieve summary stats of campaign.
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <returns></returns>
        ReportSummary GetReportSummary(string cId);

        /// <summary>
        /// Get email addresses the campaign was sent to
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        SentToMembers GetReportSentTo(string cId, SentToLimits opts = null);

        /// <summary>
        /// Retrieve click of campaign.
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <returns></returns>
        Clicks GetReportClicks(string cId);

        /// <summary>
        /// Return the list of email addresses that clicked on a given url, and how many times they clicked
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="tId">the campaign id to get click stats for (can be gathered using campaigns/list())</param>
        /// <param name="opts">optional -  various options for controlling returned data</param>
        /// <returns></returns>
        ClickDetail GetReportClickDetail(string cId, int tId, ClickDetailOptions opts = null);

        /// <summary>
        /// Retrieve the list of email addresses that did not open a given campaign
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        NotOpened GetReportNotOpened(string cId, CommonOptions opts = null);

        /// <summary>
        /// Get all unsubscribed email addresses for a given campaign
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        Unsubscribes GetReportUnsubscribes(string cId, CommonOptions opts = null);

        /// <summary>
        /// Retrieve the full bounce messages for the given campaign. Note that this can return very large amounts of data depending 
        /// on how large the campaign was and how much cruft the bounce provider returned. 
        /// Also, messages over 30 days old are subject to being removed
        /// </summary>
        /// <param name="cId">the campaign id to pull bounces for</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        BounceMessages GetReportBounceMessages(string cId, BounceMessagesOptions opts = null);

        /// <summary>
        /// Retrieve the list of email addresses that opened a given campaign with how many times they opened
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        Opened GetReportOpened(string cId, OpenedOptions opts = null);
    }
    #endregion

    /// <summary>
    /// .NET API Wrapper for the Mailchimp v2.0 API.
    /// More information here: http://apidocs.mailchimp.com/api/2.0/
    /// </summary>
    public class MailChimpManager : IMailChimpManager
    {
        #region Fields and properties

        /// <summary>
        /// The HTTPS endpoint for the API.  
        /// See http://apidocs.mailchimp.com/api/2.0/#api-endpoints for more information
        /// </summary>
        private string _httpsUrl = "https://{0}.api.mailchimp.com/2.0/{1}.json";

        /// <summary>
        /// The datacenter prefix.  This will be automatically determined
        /// based on your API key
        /// </summary>
        private string _dataCenterPrefix = string.Empty;

        private HttpClient _httpClient;

        #endregion

        #region Constructors and API key

        //  Default constructor
        public MailChimpManager()
        {
            // Lists.MergeVar.RegisterMergeVarFieldValuesJsonConversion();
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Get the datacenter prefix based on the API key passed
        /// </summary>
        /// <param name="apiKey">v2.0 Mailchimp API key</param>
        /// <returns></returns>
        private string GetDatacenterPrefix(string apiKey)
        {
            //  The key should contain a '-'.  If it doesn't, throw an exception:
            if (!apiKey.Contains("-"))
            {
                throw new ArgumentException("API key is not valid.  Must be a valid v2.0 Mailchimp API key.");
            }

            return apiKey.Split('-')[1];
        }

        /// <summary>
        /// Create an instance of the wrappper with your API key
        /// </summary>
        /// <param name="apiKey">The MailChimp API key to use</param>
        public MailChimpManager(string apiKey)
            : this()
        {
            this.APIKey = apiKey;
            this._dataCenterPrefix = GetDatacenterPrefix(apiKey);
        }

        /// <summary>
        /// Create an instance of the wrapper with an Access Token and a datacenter prefix
        /// -- Primarily used when OAuth has been used to connect to MailChimp
        /// </summary>
        /// <param name="accessToken">The access token obtained through an OAuth call</param>
        /// <param name="dataCenterPrefix">The data center prefix obtained following an OAuth call</param>
        public MailChimpManager(string accessToken, string dataCenterPrefix)
            :this()
        {
            this.APIKey = accessToken;
            this._dataCenterPrefix = dataCenterPrefix;
        }

        /// <summary>
        /// Gets / sets your API key for all operations.  
        /// For help getting your API key, please see 
        /// http://kb.mailchimp.com/article/where-can-i-find-my-api-key
        /// </summary>
        public string APIKey
        {
            get;
            set;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Formats a date parameter for the mailchimp API.  If date is equal to DateTime.MinValue, then an empty string is returned.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConvertDateTimeToMailChimpAPI(DateTime date)
        {
            string strDate = (date == DateTime.MinValue) ? "" : date.ToString("yyyy-MM-dd HH:mm:ss");
            return strDate;
        }

        /// <summary>
        /// Formats a date parameter for the mailchimp API.  If date is null or equal to DateTime.MinValue, then an empty string is returned.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConvertDateTimeToMailChimpAPI(DateTime? date)
        {
            if (date.HasValue)
            {
                return ConvertDateTimeToMailChimpAPI(date.Value);
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region API: Campaigns

        /// <summary>
        /// Get the content (both html and text) for a campaign either as it would appear in the campaign archive or as the raw, original content
        /// </summary>
        /// <param name="cId">the campaign id to get content for (can be gathered using GetCampaigns())</param>
        /// <param name="view">optional one of "archive" (default), "preview" (like our popup-preview) or "raw"</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <returns></returns>
        public CampaignContent GetCampaignContent(string cId, string view = "archive", EmailParameter emailParam = null)
        {
            //  Our api action:
            string apiAction = "campaigns/content";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                options = new
                {
                    view = view,
                    email = emailParam
                }
            };

            //  Make the call:
            return MakeAPICall<CampaignContent>(apiAction, args);
        }

        /// <summary>
        ///Create a new draft campaign to send. You can not have more than 32,000 campaigns in your account.
        ///See http://apidocs.mailchimp.com/api/2.0/campaigns/create.php for explanation of full options.
        /// </summary>
        /// <param name="type">The Campaign Type to create - one of "regular", "plaintext", "absplit", "rss", "auto"</param>
        /// <param name="options">A struct of the standard options for this campaign.</param>
        /// <param name="content">The content for this campaign </param>
        /// <param name="segmentOptions">optional - if you wish to do Segmentation with this campaign this array should contain: see CampaignSegmentTest(). It's suggested that you test your options against campaignSegmentTest().</param>
        /// <param name="typeOptions">optional - various extra options based on the campaign type</param>
        /// <returns></returns>
        public Campaign CreateCampaign(string type, CampaignCreateOptions options, CampaignCreateContent content, CampaignSegmentOptions segmentOptions = null, CampaignTypeOptions typeOptions = null)
        {
            //  Our api action:
            string apiAction = "campaigns/create";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                type = type,
                options = options,
                content = content,
                segment_opts = segmentOptions,
                type_opts = typeOptions
            };
            //  Make the call:
            return MakeAPICall<Campaign>(apiAction, args);
        }

        /// <summary>
        /// Delete a campaign. Seriously, "poof, gone!" - be careful! 
        /// Seriously, no one can undelete these.
        /// </summary>
        /// <param name="cId">the Campaign Id to delete</param>
        /// <returns></returns>
        public CampaignActionResult DeleteCampaign(string cId)
        {
            //  Our api action:
            string apiAction = "campaigns/delete";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        /// <summary>
        /// Get the list of campaigns and their details matching the specified filters
        /// </summary>
        /// <param name="filterParam">Filters to apply</param>
        /// <param name="start">control paging of campaigns, start results at this campaign #</param>
        /// <param name="limit">control paging of campaigns, number of campaigns to return with each call</param>
        /// <param name="sort_field">one of "create_time", "send_time", "title", "subject" . Invalid values will fall back on "create_time" - case insensitive</param>
        /// <param name="sort_dir">"DESC" for descending (default), "ASC" for Ascending. Invalid values will fall back on "DESC" - case insensitive.</param>
        /// <returns></returns>
        public CampaignListResult GetCampaigns(CampaignFilter filterParam = null, int start = 0, int limit = 25, string sort_field = "create_time", string sort_dir = "DESC")
        {
            //  Our api action:
            string apiAction = "campaigns/list";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                filters = filterParam,
                start = start,
                limit = limit,
                sort_field = sort_field,
                sort_dir = sort_dir
            };

            //  Make the call:
            return MakeAPICall<CampaignListResult>(apiAction, args);
        }

        /// <summary>
        /// Pause an AutoResponder or RSS campaign from sending
        /// </summary>
        /// <param name="cId">the id of the campaign to pause</param>
        /// <returns></returns>
        public CampaignActionResult PauseCampaign(string cId)
        {
            //  Our api action:
            string apiAction = "campaigns/pause";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        //  campaigns/ready

        /// <summary>
        /// Replicate a campaign.
        /// </summary>
        /// <param name="cId">the id of the campaign to replicate</param>
        /// <returns></returns>
        public Campaign ReplicateCampaign(string cId)
        {
            //  Our api action:
            string apiAction = "campaigns/replicate";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<Campaign>(apiAction, args);
        }

        /// <summary>
        /// Resume sending an AutoResponder or RSS campaign
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public CampaignActionResult ResumeCampaign(string cId)
        {
            //  Our api action:
            string apiAction = "campaigns/resume";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        /// <summary>
        /// Schedule a campaign to be sent in batches sometime in the future. 
        /// Only valid for "regular" campaigns
        /// </summary>
        /// <param name="cId">the id of the campaign to schedule</param>
        /// <param name="scheduleTime">the time to schedule the campaign.</param>
        /// <param name="numBatches">the number of batches between 2 and 26 to send</param>
        /// <param name="staggerMins">the number of minutes between each batch - 5, 10, 15, 20, 25, 30, or 60</param>
        /// <returns></returns>
        public CampaignActionResult ScheduleBatchCampaign(string cId, string scheduleTime, int numBatches = 2, int staggerMins = 5)
        {
            //  Our api action:
            string apiAction = "campaigns/schedule-batch";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                schedule_time = scheduleTime,
                num_batches = numBatches,
                stagger_mins = staggerMins
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        /// <summary>
        /// Schedule a campaign to be sent in the future
        /// </summary>
        /// <param name="cId">the id of the campaign to schedule</param>
        /// <param name="scheduleTime">the time to schedule the campaign. For A/B Split "schedule" campaigns, the time for Group A - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        /// <param name="scheduleTimeB">the time to schedule Group B of an A/B Split "schedule" campaign - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        /// <returns></returns>
        public CampaignActionResult ScheduleCampaign(string cId, string scheduleTime, string scheduleTimeB = "")
        {
            //  Our api action:
            string apiAction = "campaigns/schedule";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                schedule_time = scheduleTime,
                schedule_time_b = scheduleTimeB
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        /// <summary>
        ///Allows one to test their segmentation rules before creating a campaign using them. 
        /// </summary>
        /// <param name="listId">The list id to test</param>
        /// <param name="options">The segmentation options to apply</param>
        /// <returns></returns>
        public CampaignSegmentTestResult CampaignSegmentTest(string listId, CampaignSegmentOptions options)
        {
            //  Our api action:
            string apiAction = "campaigns/segment-test";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                list_id = listId,
                options = options
            };
            //  Make the call:
            return MakeAPICall<CampaignSegmentTestResult>(apiAction, args);
        }

        /// <summary>
        /// Send a given campaign immediately. 
        /// For RSS campaigns, this will "start" them
        /// </summary>
        /// <param name="cId">the id of the campaign</param>
        /// <returns></returns>
        public CampaignActionResult SendCampaign(string cId)
        {
            //  Our api action:
            string apiAction = "campaigns/send";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        /// <summary>
        /// Send a test of this campaign to the provided email addresses
        /// </summary>
        /// <param name="cId">the id of the campaign to test</param>
        /// <param name="testEmails">an array of email address to 
        /// receive the test message</param>
        /// <param name="sendType">by default just html is sent - can be "html" or "text" send specify the format</param>
        /// <returns></returns>
        public CampaignActionResult SendCampaignTest(string cId, List<string> testEmails = null, string sendType = "html")
        {
            //  Our api action:
            string apiAction = "campaigns/send-test";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                test_emails = testEmails,
                send_type = sendType
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        //  template-content

        /// <summary>
        /// Unschedule a campaign that is scheduled to be sent in the future
        /// </summary>
        /// <param name="cId">the id of the campaign to unschedule</param>
        /// <returns></returns>
        public CampaignActionResult UnscheduleCampaign(string cId)
        {
            //  Our api action:
            string apiAction = "campaigns/unschedule";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<CampaignActionResult>(apiAction, args);
        }

        /// <summary>
        /// Update just about any setting besides type for a campaign that has not been sent. See campaigns/create() for details.
        /// </summary>
        /// <param name="cid">The Campaign Id to update</param>
        /// <param name="name">The parameter name ( see campaigns/create() ). This will be that parameter name (options, content, segment_opts) except "type_opts", which will be the name of the type - rss, auto, etc. The campaign "type" can not be changed.</param>
        /// <param name="value">An appropriate set of values for the parameter ( see campaigns/create() ). For additional parameters, this is the same value passed to them.</param>
        /// <returns>Updated campaign details and any errors</returns>
        public CampaignUpdateResult UpdateCampaign(string cid, string name, object value)
        {
            string apiAction = "campaigns/update";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cid,
                name = name,
                value = value
            };

            //  Make the call:
            return MakeAPICall<CampaignUpdateResult>(apiAction, args);
        }

        /// <summary>
        /// Get the HTML template content sections for a campaign. 
        /// Note that this will return very jagged, non-standard results based on the template a campaign is using. 
        /// You only want to use this if you want to allow editing template sections in your application. 
        /// </summary>
        /// <param name="cId">the campaign id to get content for</param>
        /// <returns>content containing all content section for the campaign - section name are dependent upon the template used</returns>
        public Dictionary<string, string> GetCampaignTemplateContent(string cId)
        {
            //  Our api action:
            const string apiAction = "campaigns/template-content";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<Dictionary<string, string>>(apiAction, args);
        }

        #endregion

        #region API: Ecommerce

        /// <summary>
        /// Import Ecommerce Order Information to be used for Segmentation
        /// </summary>
        /// <param name="order">information pertaining to the order that has completed</param>
        /// <returns></returns>
        public CompleteResult AddOrder(Ecomm.Order order)
        {
            //  Our api action:
            string apiAction = "ecomm/order-add";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                order = order
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Delete Ecommerce Order Information used for segmentation.
        /// </summary>
        /// <param name="storeId">the store id the order belongs to</param>
        /// <param name="orderId">the order id (generated by the store) to delete</param>
        /// <returns></returns>
        public CompleteResult DeleteOrder(string storeId, string orderId)
        {
            //  Our api action:
            string apiAction = "ecomm/order-del";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                store_id = storeId,
                order_id = orderId
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the Ecommerce Orders for an account
        /// </summary>
        /// <param name="campaignId">limit the returned orders to a particular campaign</param>
        /// <param name="start">the page number to start at - defaults to 1st page of data (page 0)</param>
        /// <param name="limit">the number of results to return - defaults to 100, upper limit set at 500</param>
        /// <param name="since">pull only messages since this time - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        public OrderListResult GetOrders(string campaignId = null, int start = 0, int limit = 100, string since = null)
        {
            //  Our api action:
            string apiAction = "ecomm/orders";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = campaignId,
                start = start,
                limit = limit,
                since = since
            };

            //  Make the call:
            return MakeAPICall<OrderListResult>(apiAction, args);
        }

        #endregion

        #region API: Folders

        /// <summary>
        /// List all the folders of a certain type
        /// </summary>
        /// <param name="folderType">the type of folders to return "campaign", "autoresponder", or "template"</param>
        /// <returns></returns>
        public List<FolderListResult> GetFolders(string folderType)
        {
            //  Our api action:
            string apiAction = "folders/list";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                type = folderType
            };

            //  Make the call:
            return MakeAPICall<List<FolderListResult>>(apiAction, args);
        }

        /// <summary>
        /// Add a new folder to file campaigns, autoresponders, or templates in
        /// </summary>
        /// <param name="folderName">a unique name for a folder (max 100 bytes)</param>
        /// <param name="folderType">the type of folder to create - one of "campaign", "autoresponder", or "template".</param>
        /// <returns></returns>
        public FolderAddResult AddFolder(string folderName, string folderType)
        {
            //  Our api action:
            string apiAction = "folders/add";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                name = folderName,
                type = folderType
            };

            //  Make the call:
            return MakeAPICall<FolderAddResult>(apiAction, args);
        }

        /// <summary>
        /// Delete a campaign, autoresponder, or template folder. Note that this will simply make whatever was in the folder appear unfiled, no other data is removed
        /// </summary>
        /// <param name="fId"></param>
        /// <param name="folderType"></param>
        /// <returns></returns>
        public FolderActionResult DeleteFolder(int fId, string folderType)
        {
            //  Our api action:
            string apiAction = "folders/del";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                fid = fId,
                type = folderType
            };

            //  Make the call:
            return MakeAPICall<FolderActionResult>(apiAction, args);
        }

        /// <summary>
        /// Update the name of a folder for campaigns, autoresponders, or templates
        /// </summary>
        /// <param name="fId">the folder id to update</param>
        /// <param name="folderName">a new, unique name for the folder (max 100 bytes)</param>
        /// <param name="folderType">the type of folder to update - one of "campaign", "autoresponder", or "template"</param>
        /// <returns></returns>
        public FolderActionResult UpdateFolder(int fId, string folderName, string folderType)
        {
            //  Our api action:
            string apiAction = "folders/update";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                fid = fId,
                name = folderName,
                type = folderType
            };

            //  Make the call:
            return MakeAPICall<FolderActionResult>(apiAction, args);
        }


        #endregion

        #region API: Gallery

        /// <summary>
        /// Add a file to a folder
        /// </summary>
        /// <param name="fileId">the id of the file you want to add to a folder, as returned by the list call </param>
        /// <param name="folderId">the id of the folder to add the file to, as returned by the listFolders call </param>
        public bool GalleryFolderAddFileTo(int fileId, int folderId)
        {
            //  Our api action:
            string apiAction = "gallery/add-file-to-folder";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                file_id = fileId,
                folder_id = folderId
            };

            //  Make the call:
            return MakeAPICall<bool>(apiAction, args);
        }

        /// <summary>
        /// Adds a folder to the file gallery
        /// </summary>
        /// <param name="name">the name of the folder to add (255 character max) </param>
        public AddGalleryFolderResult GalleryFolderAdd(string name)
        {
            //  Our api action:
            string apiAction = "gallery/add-folder";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                name = name
            };

            //  Make the call:
            return MakeAPICall<AddGalleryFolderResult>(apiAction, args);
        }

        /// <summary>
        /// Return a section of the image gallery
        /// </summary>
        /// <param name="type">Optional the gallery type to return - images or files - default to images</param>
        /// <param name="start">Optional for large data sets, the page number to start at - defaults to 1st page of data (page 0)</param>
        /// <param name="limit">Optional for large data sets, the number of results to return - defaults to 25, upper limit set at 100</param>
        /// <param name="sortBy">Optional field to sort by - one of size, time, name - defaults to time </param>
        /// <param name="sortDir">Optional field to sort by - one of asc, desc - defaults to desc</param>
        /// <param name="searchTerm">Optional a term to search for in names</param>
        /// <param name="folderId">Optional to return files that are in a specific folder</param>
        /// <returns></returns>
        public GalleryListResult GetGalleries(string type = "images", int start = 0, int limit = 25, string sortBy = "time", string sortDir = "desc", string searchTerm = null, int folderId = 0)
        {
            //  Our api action:
            string apiAction = "gallery/list";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                opts = new
                {
                    type = type,
                    start = start,
                    limit = limit,
                    sort_by = sortBy,
                    sort_dir = sortDir,
                    search_term = searchTerm,
                    folder_id = folderId
                }
            };

            //  Make the call:
            return MakeAPICall<GalleryListResult>(apiAction, args);
        }

        public GalleryFoldersResult GetGalleryFolders(int start = 0, int limit = 25, string searchTerm = null)
        {
            //  Our api action:
            string apiAction = "gallery/list-folders";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                opts = new
                {
                    start = start,
                    limit = limit,
                    search_term = searchTerm
                }
            };

            //  Make the call:
            return MakeAPICall<GalleryFoldersResult>(apiAction, args);
        }

        /// <summary>
        /// Remove all files from a folder
        /// </summary>
        /// <remarks>the files are not deleted, they are only removed from the folder</remarks>
        /// <param name="folderId">the id of the folder to remove the file from</param>
        public bool GalleryFolderRemoveAllFilesFrom(int folderId)
        {
            //  Our api action:
            string apiAction = "gallery/remove-all-files-from-folder";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                folder_id = folderId
            };

            //  Make the call:
            return MakeAPICall<bool>(apiAction, args);
        }

        /// <summary>
        /// Remove a file from a folder
        /// </summary>
        /// <param name="fileId">the id of the file you want to remove from the folder</param>
        /// <param name="folderId">the id of the folder to remove the file from</param>
        public bool GalleryFolderRemoveFileFrom(int fileId, int folderId)
        {
            //  Our api action:
            string apiAction = "gallery/remove-file-from-folder";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                file_id = fileId,
                folder_id = folderId
            };

            //  Make the call:
            return MakeAPICall<bool>(apiAction, args);
        }

        /// <summary>
        /// Remove a folder
        /// </summary>
        /// <param name="folderId">the id of the folder to remove</param>
        public bool GalleryFolderRemove(int folderId)
        {
            //  Our api action:
            string apiAction = "gallery/remove-folder";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                folder_id = folderId
            };

            //  Make the call:
            return MakeAPICall<bool>(apiAction, args);
        }

        #endregion

        #region API: Lists

        /// <summary>
        /// Get all email addresses that complained about a campaign sent to a list
        /// </summary>
        /// <param name="listId">the list id to pull abuse reports for (can be gathered using GetLists())</param>
        /// <param name="start">optional for large data sets, the page number to start at - defaults to 1st page of data (page 0)</param>
        /// <param name="limit">optional for large data sets, the number of results to return - defaults to 500, upper limit set at 1000</param>
        /// <param name="since">optional pull only messages since this time - 24 hour format in GMT, eg "2013-12-30 20:30:00"</param>
        /// <returns></returns>
        public AbuseResult GetListAbuseReports(string listId, int start = 0, int limit = 500, string since = "")
        {
            //  Our api action:
            string apiAction = "lists/abuse-reports";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                start = start,
                limit = limit,
                since = since
            };

            //  Make the call:
            return MakeAPICall<AbuseResult>(apiAction, args);
        }

        /// <summary>
        /// Access up to the previous 180 days of daily detailed aggregated activity stats for a given list. Does not include AutoResponder activity.
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <returns></returns>
        public List<ListActivity> GetListActivity(string listId)
        {
            //  Our api action:
            string apiAction = "lists/activity";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId
            };

            //  Make the call:
            return MakeAPICall<List<ListActivity>>(apiAction, args);
        }

        /// <summary>
        /// Get the most recent 100 activities for particular list members (open, click, bounce, unsub, abuse, sent to, etc.)
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="listOfEmails">an array of up to 50 email structs</param>
        /// <returns></returns>
        public MemberActivityResult GetMemberActivity(string listId, List<EmailParameter> listOfEmails)
        {
            //  Our api action:
            string apiAction = "lists/member-activity";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                emails = listOfEmails
            };

            //  Make the call:
            return MakeAPICall<MemberActivityResult>(apiAction, args);
        }

        /// <summary>
        /// Subscribe a batch of email addresses to a list at once. Maximum batch sizes vary based 
        /// on the amount of data in each record, though you should cap them 
        /// at 5k - 10k records, depending on your experience. These calls are also 
        /// long, so be sure you increase your timeout values.
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="listOfEmails"></param>
        /// <param name="doubleOptIn"></param>
        /// <param name="updateExisting"></param>
        /// <param name="replaceInterests"></param>
        /// <returns></returns>
        public BatchSubscribeResult BatchSubscribe(string listId, List<BatchEmailParameter> listOfEmails, bool doubleOptIn = true, bool updateExisting = false, bool replaceInterests = true)
        {
            //  Our api action:
            string apiAction = "lists/batch-subscribe";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                batch = listOfEmails,
                double_optin = doubleOptIn,
                update_existing = updateExisting,
                replace_interests = replaceInterests
            };

            //  Make the call:
            return MakeAPICall<BatchSubscribeResult>(apiAction, args);
        }

        /// <summary>
        /// Unsubscribe a batch of email addresses from a list
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="listOfEmails">array of emails to unsubscribe</param>
        /// <param name="deleteMember">flag to completely delete the member from your list instead of just unsubscribing, default to false</param>
        /// <param name="sendGoodbye">flag to send the goodbye email to the email addresses, defaults to true</param>
        /// <param name="sendNotify">flag to send the unsubscribe notification email to the address defined in the list email notification settings, defaults to false</param>
        /// <returns></returns>
        public BatchUnsubscribeResult BatchUnsubscribe(string listId, List<EmailParameter> listOfEmails, bool deleteMember = false, bool sendGoodbye = true, bool sendNotify = false)
        {
            //  Our api action:
            string apiAction = "lists/batch-unsubscribe";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                batch = listOfEmails,
                delete_member = deleteMember,
                send_goodbye = sendGoodbye,
                send_notify = sendNotify
            };

            //  Make the call:
            return MakeAPICall<BatchUnsubscribeResult>(apiAction, args);
        }

        /// <summary>
        /// Retrieve all of the lists defined for your user account
        /// </summary>
        /// <param name="filterParam">filters to apply to this query - all are optional</param>
        /// <param name="start">optional - control paging of lists, start results at this list #, defaults to 1st page of data (page 0)</param>
        /// <param name="limit">optional - control paging of lists, number of lists to return with each call, defaults to 25 (max=100)</param>
        /// <param name="sort_field">optional - "created" (the created date, default) or "web" (the display order in the web app). Invalid values will fall back on "created" - case insensitive.</param>
        /// <param name="sort_dir">optional - "DESC" for descending (default), "ASC" for Ascending - case insensitive. Note: to get the exact display order as the web app you'd use "web" and "ASC"</param>
        /// <returns></returns>
        public ListResult GetLists(ListFilter filterParam = null, int start = 0, int limit = 25, string sort_field = "created", string sort_dir = "DESC")
        {
            //  Our api action:
            string apiAction = "lists/list";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                filters = filterParam,
                start = start,
                limit = limit,
                sort_field = sort_field,
                sort_dir = sort_dir
            };

            //  Make the call:
            return MakeAPICall<ListResult>(apiAction, args);
        }
        /// <summary>
        /// Add an interest group for a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public CompleteResult AddListInterestGroup(string listId, string group_name, int grouping_id)
        {
            //  Our api action:
            string apiAction = "lists/interest-group-add";
            //lists/interest-group-add (string apikey, string id, string group_name, int grouping_id)


            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                group_name,
                grouping_id,
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Deletes an interest group of a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public CompleteResult DeleteListInterestGroup(string listId, string group_name, int grouping_id)
        {
            //  Our api action:
            string apiAction = "lists/interest-group-del";
            //lists/interest-group-del (string apikey, string id, string group_name, int grouping_id)


            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                group_name,
                grouping_id,
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Change the name of an Interest Group of a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public CompleteResult UpdateListInterestGroup(string listId, string old_name, string new_name, int grouping_id)
        {
            //  Our api action:
            string apiAction = "lists/interest-group-update";
            //lists/interest-group-update (string apikey, string old_name, string new_name, int grouping_id)


            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                old_name,
                new_name,
                grouping_id,
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Add a new Interest Grouping - if interest groups for the List are not yet enabled, adding the first grouping will automatically turn them on.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public InterestGroupingResult AddListInterestGrouping(string listId, string name, string type, List<string> groups)
        {
            //  Our api action:
            string apiAction = "lists/interest-grouping-add";
            //lists/interest-grouping-add (string apikey, string id, string name, string type, array groups)


            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                name,
                type,
                groups,
            };

            //  Make the call:
            return MakeAPICall<InterestGroupingResult>(apiAction, args);
        }
        /// <summary>
        /// Delete an existing Interest Grouping - this will permanently delete all contained interest groups and will remove those selections from all list members
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public CompleteResult DeleteListInterestGrouping(string listId, int grouping_id)
        {
            //  Our api action:
            string apiAction = "lists/interest-grouping-del";
            //lists/interest-grouping-del (string apikey, int grouping_id)


            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                grouping_id,
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }
        /// <summary>
        /// Update an existing Interest Grouping
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public CompleteResult UpdateListInterestGrouping(string listId, int grouping_id, string name, string value)
        {
            //  Our api action:
            string apiAction = "lists/interest-grouping-update";
            //lists/interest-grouping-update (string apikey, int grouping_id, string name, string value)


            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                grouping_id,
                name,
                value
            };

            //  Make the call:
            return MakeAPICall<CompleteResult>(apiAction, args);
        }      
 
        /// <summary>
        /// Retrieve the interest groups for a list.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="counts">Optional: whether or not to return subscriber counts for each group. Defaults to false since that slows this call down a ton for large lists.</param>
        /// <returns></returns>
        public List<InterestGrouping> GetListInterestGroupings(string listId, bool counts = false)
        {
            //  Our api action:
            string apiAction = "lists/interest-groupings";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                counts = counts
            };

            //  Make the call:
            return MakeAPICall<List<InterestGrouping>>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the locations (countries) that the list's subscribers have been tagged to based on geocoding their IP address
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <returns></returns>
        public List<SubscriberLocation> GetLocationsForList(string listId)
        {
            //  Our api action:
            string apiAction = "lists/locations";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId
            };

            //  Make the call:
            return MakeAPICall<List<SubscriberLocation>>(apiAction, args);
        }

        /// <summary>
        /// Get all the information for particular members of a list
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="listOfEmails">an array of up to 50 email address struct to retrieve member information for</param>
        /// <returns></returns>
        public MemberInfoResult GetMemberInfo(string listId, List<EmailParameter> listOfEmails)
        {
            //  Our api action:
            string apiAction = "lists/member-info";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                emails = listOfEmails
            };

            //  Make the call:
            return MakeAPICall<MemberInfoResult>(apiAction, args);
        }

        /// <summary>
        /// Get all of the list members for a list that are of a particular status and 
        /// potentially matching a segment. This will cause locking, so don't run multiples at once.
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="status">optional - the status to get members for - one of(subscribed, unsubscribed, cleaned)</param>
        /// <param name="start">for large data sets, the page number to start at</param>
        /// <param name="limit">for large data sets, the number of results to return - defaults to 25, upper limit set at 100</param>
        /// <param name="sort_field">the data field to sort by - mergeX (1-30), your custom merge tags, "email", "rating","last_update_time", or "optin_time" - invalid fields will be ignored</param>
        /// <param name="sort_dir">the direct - ASC or DESC</param>
        /// <param name="segment">refine the members list by segments (maximum of 5 conditions)</param>
        /// <returns></returns>
        public MembersResult GetAllMembersForList(string listId, string status = "subscribed", int start = 0, int limit = 25, string sort_field = "", string sort_dir = "ASC", CampaignSegmentOptions segment = null)
        {
            //  Our api action:
            string apiAction = "lists/members";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                status = status,
                opts = new
                {
                    start = start,
                    limit = limit,
                    sort_field = sort_field,
                    sort_dir = sort_dir,
                    segment = segment
                }
            };

            //  Make the call:
            return MakeAPICall<MembersResult>(apiAction, args);
        }

        /// <summary>
        /// Subscribe the provided email to a list. By default this sends a 
        /// confirmation email - you will not see new members until the 
        /// link contained in it is clicked!
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="mergeVars">optional merges for the email (FNAME, LNAME, etc.)</param>
        /// <param name="emailType">optional email type preference for the email (html or text - defaults to html)</param>
        /// <param name="doubleOptIn">optional flag to control whether a double opt-in confirmation message is sent, defaults to true. Abusing this may cause your account to be suspended.</param>
        /// <param name="updateExisting">optional flag to control whether existing subscribers should be updated instead of throwing an error, defaults to false</param>
        /// <param name="replaceInterests">optional flag to determine whether we replace the interest groups with the groups provided or we add the provided groups to the member's interest groups (optional, defaults to true)</param>
        /// <param name="sendWelcome">optional if your double_optin is false and this is true, we will send your lists Welcome Email if this subscribe succeeds - this will *not* fire if we end up updating an existing subscriber. If double_optin is true, this has no effect. defaults to false.</param>
        /// <returns></returns>
        /// <example>
        /// The example below shows how to add your own merge parameters by passing your own class that inherits from MergeVar:
        /// <code>
        /// [System.Runtime.Serialization.DataContract]
        /// public class MyMergeVar : MergeVar
        /// {
        ///     [System.Runtime.Serialization.DataMember(Name = "FNAME")]
        ///     public string FirstName { get; set; }
        ///     [System.Runtime.Serialization.DataMember(Name = "LNAME")]
        ///     public string LastName { get; set; }
        /// }
        /// 
        /// MailChimpManager mc = new MailChimpManager("YourApiKeyHere-us2");
        /// EmailParameter email = new EmailParameter()
        /// {
        ///     Email = "customeremail@righthere.com"
        /// };
        /// MyMergeVar myMergeVars = new MyMergeVar();
        /// myMergeVars.Groupings = new List&lt;Grouping&gt;();
        /// myMergeVars.Groupings.Add(new Grouping());
        /// myMergeVars.Groupings[0].Id = 1234; // replace with your grouping id
        /// myMergeVars.Groupings[0].GroupNames = new List&lt;string&gt;();
        /// myMergeVars.Groupings[0].GroupNames.Add("Your Group Name");
        /// myMergeVars.FirstName = "Testy";
        /// myMergeVars.LastName = "Testerson";
        /// EmailParameter results = mc.Subscribe(strListID, email, myMergeVars);
        /// </code>
        /// </example>
        public EmailParameter Subscribe(string listId, EmailParameter emailParam, MergeVar mergeVars = null, string emailType = "html", bool doubleOptIn = true, bool updateExisting = false, bool replaceInterests = true, bool sendWelcome = false)
        {
            //  Our api action:
            string apiAction = "lists/subscribe";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                email = emailParam,
                merge_vars = mergeVars,
                email_type = emailType,
                double_optin = doubleOptIn,
                update_existing = updateExisting,
                replace_interests = replaceInterests,
                send_welcome = sendWelcome
            };

            //  Make the call:
            return MakeAPICall<EmailParameter>(apiAction, args);
        }

        /// <summary>
        /// Updates the member in the list with the matching emailParam  
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="mergeVars">merges for the email (new-email, FNAME, LNAME, etc.)</param>
        /// <param name="emailType">optional email type preference for the email (html or text), leave blank to keep the existing preference</param>
        /// <param name="replaceInterests">optional flag to determine whether we replace the interest groups with the groups provided or we add the provided groups to the member's interest groups (optional, defaults to true)</param>
        /// <returns></returns>
        public EmailParameter UpdateMember(string listId, EmailParameter emailParam, MergeVar mergeVars, string emailType = "", bool replaceInterests = true)
        {
            const string apiAction = "lists/update-member";

            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                email = emailParam,
                merge_vars = mergeVars,
                email_type = emailType,
                replace_interests = replaceInterests
            };

            //  Make the call:
            return MakeAPICall<EmailParameter>(apiAction, args);

        }

        /// <summary>
        /// Unsubscribe the given email address from the list
        /// </summary>
        /// <param name="listId">the list id to connect to (can be gathered using GetLists())</param>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="deleteMember">optional - flag to completely delete the member from your list instead of just unsubscribing, default to false</param>
        /// <param name="sendGoodbye">optional - flag to send the goodbye email to the email address, defaults to true</param>
        /// <param name="sendNotify">optional - flag to send the unsubscribe notification email to the address defined in the list email notification settings, defaults to true</param>
        /// <returns></returns>
        public UnsubscribeResult Unsubscribe(string listId, EmailParameter emailParam, bool deleteMember = false, bool sendGoodbye = true, bool sendNotify = true)
        {
            //  Our api action:
            string apiAction = "lists/unsubscribe";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                email = emailParam,
                delete_member = deleteMember,
                send_goodbye = sendGoodbye,
                send_notify = sendNotify
            };

            //  Make the call:
            return MakeAPICall<UnsubscribeResult>(apiAction, args);
        }

        /// <summary>
        /// Get the list of merge tags for a given list, including their name, tag, and required setting
        /// </summary>
        /// <param name="listIds">the list ids to retrieve merge vars for. Get by calling lists/list() - max of 100 </param>
        public MergeVarResult GetMergeVars(IEnumerable<string> listIds)
        {
            string apiAction = "lists/merge-vars";

            object args = new
            {
                apikey = this.APIKey,
                id = listIds
            };

            return MakeAPICall <MergeVarResult>(apiAction, args);
        }

        /// <summary>
        /// Add a new merge tag to a given list
        /// </summary>
        /// <param name="listId">The list id to connect to</param>
        /// <param name="tag">The merge tag to add, e.g. FNAME. 
        /// 10 bytes max, valid characters: "A-Z 0-9 _" no spaces, dashes, etc.</param>
        /// <param name="name">The long description of the tag being added, used for user displays - max 50 bytes</param>
        /// <param name="options">optional Various options for this merge var</param>
        /// <returns></returns>
        public MergeVarItemResult AddMergeVar(string listId, string tag, string name, MergeVarOptions options = null)
        {
            string apiAction = "lists/merge-var-add";

            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                tag = tag,
                name = name,
                options = options
            };

            return MakeAPICall<MergeVarItemResult>(apiAction, args);
        }

        /// <summary>
        /// Update most parameters for a merge tag on a given list. You cannot currently change the merge type
        /// </summary>
        /// <param name="listId">The list id to connect to</param>
        /// <param name="tag">The merge tag to update</param>
        /// <param name="options">updated options for this merge var</param>
        /// <returns></returns>
        public MergeVarItemResult UpdateMergeVar(string listId, string tag, MergeVarOptions options)
        {
            string apiAction = "lists/merge-var-update";

            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                tag = tag,
                options = options
            };

            return MakeAPICall<MergeVarItemResult>(apiAction, args);
        }
        /// <summary>
        /// Delete a merge tag from a given list and all its members. 
        /// Seriously - the data is removed from all members as well!
        /// Note that on large lists this method may seem a bit slower than calls you typically make.
        /// </summary>
        /// <param name="listId">the list id to connect to.</param>
        /// <param name="tag">The merge tag to delete</param>
        /// <returns></returns>
        public CompleteResult DeleteMergeVar(string listId, string tag)
        {
            string apiAction = "lists/merge-var-del";

            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                tag = tag
            };

            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Completely resets all data stored in a merge var on a list. 
        /// All data is removed and this action can not be undone.
        /// </summary>
        /// <param name="listId">the list id to connect to.</param>
        /// <param name="tag">The merge tag to reset</param>
        /// <returns></returns>
        public CompleteResult ResetMergeVar(string listId, string tag)
        {
            string apiAction = "lists/merge-var-reset";

            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                tag = tag
            };

            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Sets a particular merge var to the specified value for every list member. 
        /// Only merge var ids 1 - 30 may be modified this way.  This is generally a dirty method unless 
        /// you're fixing data since you should probably be using default_values and/or conditional content. 
        /// As with lists/merge-var-reset(), this can not be undone.
        /// </summary>
        /// <param name="listId">the list id to connect to.</param>
        /// <param name="tag">The merge tag to set</param>
        /// <param name="value">The value to set to</param>
        /// <returns></returns>
        public CompleteResult SetMergeVar(string listId, string tag, string value)
        {
            string apiAction = "lists/merge-var-set";

            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                tag = tag,
                value = value
            };

            return MakeAPICall<CompleteResult>(apiAction, args);
        }

        /// <summary>
        /// Save a segment against a list for later use.
        /// There is no limit to the number of segments which can be saved. Static Segments are not tied to any merge data, interest groups, etc.
        /// They essentially allow you to configure an unlimited number of custom segments which will have standard performance.
        /// When using proper segments, Static Segments are one of the available options for segmentation just as if you used a merge var (and they can be used with other segmentation options), though performance may degrade at that point.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentName">Name of the static segment.</param>
        /// <returns></returns>
        public StaticSegmentAddResult AddStaticSegment(string listId, string staticSegmentName)
        {
            // our api action:
            string apiAction = "lists/static-segment-add";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                name = staticSegmentName
            };
            return MakeAPICall<StaticSegmentAddResult>(apiAction, args);
        }

        /// <summary>
        /// Save a segment against a list for later use. There is no limit to the number of segments which can be saved. 
        /// Static Segments are not tied to any merge data, interest groups, etc. They essentially allow you to configure 
        /// an unlimited number of custom segments which will have standard performance. When using proper segments, 
        /// Static Segments are one of the available options for segmentation just as if you used a merge var (and they 
        /// can be used with other segmentation options), though performance may degrade at that point. Saved Segments 
        /// (called "auto-updating" in the app) are essentially just the match+conditions typically used.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="segmentOptions">Various options for the new segment</param>
        /// <returns></returns>
        public SegmentAddResult AddSegment(string listId, AddCampaignSegmentOptions segmentOptions)
        {
            // our api action:
            const string apiAction = "lists/segment-add";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                opts = segmentOptions,
            };
            return MakeAPICall<SegmentAddResult>(apiAction, args);
        }

        /// <summary>
        /// Delete a static segment. Note that this will, of course, remove any member affiliations with the segment
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to delete - get from getStaticSegmentsForList()</param>
        /// <returns></returns>
        public StaticSegmentActionResult DeleteStaticSegment(string listId, int staticSegmentID)
        {
            // our api action:
            string apiAction = "lists/static-segment-del";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                seg_id = staticSegmentID,
            };
            return MakeAPICall<StaticSegmentActionResult>(apiAction, args);
        }

        /// <summary>
        /// Add list members to a static segment. 
        /// It is suggested that you limit batch size to no more than 10,000 addresses per call. 
        /// Email addresses must exist on the list in order to be included - this will not subscribe them to the list!
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to delete - get from getStaticSegmentsForList()</param>
        /// <param name="emails">Array of emails to add to the segment</param>
        /// <returns></returns>
        public StaticSegmentMembersAddResult AddStaticSegmentMembers(string listId, int staticSegmentID, List<EmailParameter> emails)
        {
            // our api action:
            string apiAction = "lists/static-segment-members-add";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                seg_id = staticSegmentID,
                batch = emails
            };
            return MakeAPICall<StaticSegmentMembersAddResult>(apiAction, args);
        }
        /// <summary>
        /// Remove list members to a static segment. 
        /// It is suggested that you limit batch size to no more than 10,000 addresses per call. 
        /// Email addresses must exist on the list in order to be included - this will not unsubscribe them from the list!
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to delete - get from getStaticSegmentsForList()</param>
        /// <param name="emails">Array of emails to remove from the segment</param>
        /// <returns></returns>
        public StaticSegmentMembersDeleteResult DeleteStaticSegmentMembers(string listId, int staticSegmentID, List<EmailParameter> emails)
        {
            // our api action:
            string apiAction = "lists/static-segment-members-del";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                seg_id = staticSegmentID,
                batch = emails
            };
            return MakeAPICall<StaticSegmentMembersDeleteResult>(apiAction, args);
        }

        /// <summary>
        /// Resets a static segment - removes all members from the static segment. 
        /// Note: does not actually affect list member data
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <param name="staticSegmentID">The id of the static segment to be reset - get from getStaticSegmentsForList()</param>
        /// <returns></returns>
        public StaticSegmentActionResult ResetStaticSegment(string listId, int staticSegmentID)
        {
            // our api action:
            string apiAction = "lists/static-segment-reset";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                seg_id = staticSegmentID,
            };
            return MakeAPICall<StaticSegmentActionResult>(apiAction, args);
        }

        /// <summary>
        /// Retrieve all of the Static Segments for a list.
        /// </summary>
        /// <param name="listId">The list id to connect to (can be gathered using GetLists())</param>
        /// <returns></returns>
        public List<StaticSegmentResult> GetStaticSegmentsForList(string listId)
        {
            // our api action:
            string apiAction = "lists/static-segments";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
            };
            return MakeAPICall<List<StaticSegmentResult>>(apiAction, args);
        }
		
	    /// <summary>
        /// Retrieve all of Saved Segments for a list.
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="segmentType">optional - optional, if specified should be "static" or "saved" and will limit the returned entries to that type</param>
        /// <returns></returns>
        public SegmentResult GetSegmentsForList(string listId, string segmentType)
        {
            // our api action:
            string apiAction = "lists/segments";

            // create our arguements object:
            object args = new
            {
                apikey = this.APIKey,
                id = listId,
                type = segmentType
            };
            return MakeAPICall<SegmentResult>(apiAction, args);
        }

        /// <summary>
        /// Return the Webhooks configured for the given list
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <returns></returns>
        public List<WebhookInfo> GetWebhooks(string listId)
        {
            // our api action:
            string apiAction = "lists/webhooks";

            // create our arguements object:
            object args = new
            {
                apikey = APIKey,
                id = listId
            };
            return MakeAPICall<List<WebhookInfo>>(apiAction, args);
        }

        /// <summary>
        /// Add a new Webhook URL for the given list
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="url">a valid URL for the Webhook - it will be validated. note that a url may only exist on a list once.</param>
        /// <param name="actions">optional - optional a hash of actions to fire this Webhook for</param>
        /// <param name="sources">optional - optional sources to fire this Webhook for</param>
        /// <returns></returns>
        public WebhookAddResult AddWebhook(string listId, string url, WebhookActions actions = null, WebhookSources sources = null)
        {
            // our api action:
            string apiAction = "lists/webhook-add";

            // create our arguements object:
            object args = new
            {
                apikey = APIKey,
                id = listId,
                url = url,
                actions = actions,
                sources = sources
            };
            return MakeAPICall<WebhookAddResult>(apiAction, args);
        }

        /// <summary>
        /// Delete an existing Webhook URL from a given list
        /// </summary>
        /// <param name="listId">the list id to connect to. Get by calling lists/list()</param>
        /// <param name="url">the URL of a Webhook on this list</param>
        /// <returns></returns>
        public CompleteResult DeleteWebhook(string listId, string url)
        {
            // our api action:
            string apiAction = "lists/webhook-del";

            // create our arguements object:
            object args = new
            {
                apikey = APIKey,
                id = listId,
                url = url,
            };
            return MakeAPICall<CompleteResult>(apiAction, args);
        }
        #endregion

        #region API: Helper

        /// <summary>
        /// Retrieve lots of account information including payments made, plan info, 
        /// some account stats, installed modules, contact info, and more. No private 
        /// information like Credit Card numbers is available.
        /// More information: http://apidocs.mailchimp.com/api/2.0/helper/account-details.php
        /// </summary>
        /// <param name="exclude">Allows controlling which extra arrays are returned since they can 
        /// slow down calls. Valid keys are "modules", "orders", "rewards-credits", 
        /// "rewards-inspections", "rewards-referrals", "rewards-applied", "integrations". 
        /// Hint: "rewards-referrals" is typically the culprit. To avoid confusion, 
        /// if data is excluded, the corresponding key will not be returned at all.</param>
        /// <returns></returns>
        public AccountDetails GetAccountDetails(string[] exclude = null)
        {
            //  Our api action:
            string apiAction = "helper/account-details";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                exclude = exclude
            };

            //  Make the call:
            return MakeAPICall<AccountDetails>(apiAction, args);
        }

        /// <summary>
        /// Retrieve minimal data for all Campaigns a member was sent
        /// </summary>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <param name="filterListId">A list_id to limit the campaigns to</param>
        /// <returns>an array of structs containing campaign data for each matching campaign</returns>
        public List<CampaignForEmail> GetCampaignsForEmail(EmailParameter emailParam, string filterListId = "")
        {
            //  Our api action:
            string apiAction = "helper/campaigns-for-email";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                email = emailParam,
                options = new
                {
                    list_id = filterListId
                }
            };

            //  Make the call:
            return MakeAPICall<List<CampaignForEmail>>(apiAction, args);
        }

        /// <summary>
        /// Retrieve minimal List data for all lists a member is subscribed to.
        /// </summary>
        /// <param name="emailParam">An object a with one fo the following keys: email, euid, leid. Failing to provide anything will produce an error relating to the email address</param>
        /// <returns></returns>
        public List<ListForEmail> GetListsForEmail(EmailParameter emailParam)
        {
            //  Our api action:
            string apiAction = "helper/lists-for-email";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                email = emailParam
            };

            //  Make the call:
            return MakeAPICall<List<ListForEmail>>(apiAction, args);
        }

        /// <summary>
        /// Return the current Chimp Chatter messages for an account.
        /// </summary>
        /// <returns></returns>
        public List<ChimpChatterMessage> GetChimpChatter()
        {
            //  Our api action:
            string apiAction = "helper/chimp-chatter";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey
            };

            //  Make the call:
            return MakeAPICall<List<ChimpChatterMessage>>(apiAction, args);
        }

        /// <summary>
        /// "Ping" the MailChimp API - a simple method you can call that will 
        /// return a constant value as long as everything is good. Note than unlike 
        /// most all of our methods, we don't throw an Exception if we are having 
        /// issues. You will simply receive a different string back that will explain 
        /// our view on what is going on.
        /// </summary>
        /// <returns></returns>
        public PingMessage Ping()
        {
            //  Our api action:
            string apiAction = "helper/ping";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey
            };

            //  Make the call:
            return MakeAPICall<PingMessage>(apiAction, args);
        }

        /// <summary>
        /// Search account wide or on a specific list using the specified query terms
        /// </summary>
        /// <returns></returns>
        public Matches SearchMembers(string query, string listId = "", int offest = 0)
        {
            //  Our api action:
            string apiAction = "helper/search-members";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                query = query,
                id = listId,
                offest = offest
            };

            //  Make the call:
            return MakeAPICall<Matches>(apiAction, args);
        }

        /// <summary>
        /// Send your HTML content to have the CSS inlined and optionally remove the original styles.
        /// More information: http://apidocs.mailchimp.com/api/2.0/helper/inline-css.php
        /// </summary>
        /// <param name="html">Your HTML content</param>
        /// <param name="strip_css">optional - optional Whether you want the CSS <style> tags stripped from the returned document. Defaults to false.</param>
        /// <returns></returns>
        public InlineCss InlineCss(string html, bool strip_css = false)
        {
            //  Our api action:
            string apiAction = "helper/inline-css";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                html = html,
                strip_css = strip_css
            };

            //  Make the call:
            return MakeAPICall<InlineCss>(apiAction, args);
        }

        public List<VerifiedDomain> GetVerifiedDomains()
        {
            //  Our api action:
            string apiAction = "helper/verified-domains";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey
            };

            //  Make the call:
            return MakeAPICall<List<VerifiedDomain>>(apiAction, args);
        }

        #endregion

        #region API: Users

        /// <summary>
        /// Invite a user to your account
        /// </summary>
        /// <param name="email">A valid email address to send the invitation to</param>
        /// <param name="role">the role to assign to the user - one of viewer, author, manager, admin</param>
        /// <param name="message">an optional message to include. Plain text any HTML tags will be stripped</param>
        /// <returns></returns>
        public UserActionResult InviteUser(string email, string role = "viewer", string message = "")
        {
            //  Our api action:
            string apiAction = "users/invite";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                email = email,
                role = role,
                msg = message
            };

            //  Make the call:
            return MakeAPICall<UserActionResult>(apiAction, args);
        }

        /// <summary>
        /// Resend an invite a user to your account. Note, if the same address has been invited multiple times, 
        /// this will simpy re-send the most recent invite
        /// </summary>
        /// <param name="email">A valid email address to resend an invitation to</param>
        /// <returns></returns>
        public UserActionResult InviteResend(string email)
        {
            //  Our api action:
            string apiAction = "users/invite-resend";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                email = email
            };

            //  Make the call:
            return MakeAPICall<UserActionResult>(apiAction, args);
        }

        /// <summary>
        /// Revoke an invitation sent to a user to your account. Note, if the same address has been invited multiple times, this will simpy revoke the most recent invite
        /// </summary>
        /// <param name="email">A valid email address to revoke</param>
        /// <returns></returns>
        public UserActionResult InviteRevoke(string email)
        {
            //  Our api action:
            string apiAction = "users/invite-revoke";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                email = email
            };

            //  Make the call:
            return MakeAPICall<UserActionResult>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the list of pending users invitations have been sent for.
        /// </summary>
        /// <returns></returns>
        public List<UserInvite> GetInvites()
        {
            //  Our api action:
            string apiAction = "users/invites";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey
            };

            //  Make the call:
            return MakeAPICall<List<UserInvite>>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the list of active logins.
        /// </summary>
        /// <returns></returns>
        public List<UserLoginsResult> GetLogins()
        {
            //  Our api action:
            string apiAction = "users/logins";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey
            };

            //  Make the call:
            return MakeAPICall<List<UserLoginsResult>>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the profile for the login owning the provided API Key
        /// </summary>
        /// <returns></returns>
        public UserProfile GetUserProfile()
        {
            //  Our api action:
            string apiAction = "users/profile";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey
            };

            //  Make the call:
            return MakeAPICall<UserProfile>(apiAction, args);
        }

        #endregion

        #region API: Templates

        /// <summary>
        /// Create a new user template, NOT campaign content. These templates can then be applied while creating campaigns.
        /// </summary>
        /// <param name="templateName">The name for the template - names must be unique and a max of 50 bytes</param>
        /// <param name="html">A string specifying the entire template to be created. This is NOT campaign content. They are intended to utilize our template language.</param>
        /// <param name="folderId">Optional - the folder to put this template in.</param>
        /// <returns></returns>
        public TemplateAddResult AddTemplate(string templateName, string html, int? folderId = null)
        {
            //  Our api action:
            string apiAction = "templates/add";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                name = templateName,
                html = html,
                folder_id = folderId
            };

            //  Make the call:
            return MakeAPICall<TemplateAddResult>(apiAction, args);
        }

        /// <summary>
        /// Delete (deactivate) a user template
        /// </summary>
        /// <param name="templateId">The id of the user template to delete</param>
        /// <returns></returns>
        public TemplateDeleteResult DeleteTemplate(int templateId)
        {
            //  Our api action:
            string apiAction = "templates/del";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                template_id = templateId,
            };

            //  Make the call:
            return MakeAPICall<TemplateDeleteResult>(apiAction, args);
        }

        /// <summary>
        /// Pull details for a specific template to help support editing
        /// </summary>
        /// <param name="templateId">The template id - get from templates/list()</param>
        /// <param name="type">Optional - optional the template type to load - one of 'user', 'gallery', 'base', defaults to user.</param>
        /// <returns></returns>
        public TemplateInformationResult GetTemplateInformation(int templateId, string type = null)
        {
            //  Our api action:
            string apiAction = "templates/info";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                template_id = templateId,
                type = type
            };

            //  Make the call:
            return MakeAPICall<TemplateInformationResult>(apiAction, args);
        }

        /// <summary>
        /// Retrieve various templates available in the system, allowing some thing similar to our template gallery to be created.
        /// </summary>
        /// <param name="templateTypes">optional - optional the types of templates to return</param>
        /// <param name="templateFilters">optional - optional options to control how inactive templates are returned, if at alld</param>
        /// <returns></returns>
        public TemplateListResult GetTemplates(TemplateTypes templateTypes = null, TemplateFilters templateFilters = null)
        {
            //  Our api action:
            string apiAction = "templates/list";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                types = templateTypes,
                filters = templateFilters
            };

            //  Make the call:
            return MakeAPICall<TemplateListResult>(apiAction, args);
        }

        /// <summary>
        /// Undelete (reactivate) a user template
        /// </summary>
        /// <param name="templateId">The id of the user template to reactivate.</param>
        /// <returns></returns>
        public TemplateUndeleteResult UndeleteTemplate(int templateId)
        {
            //  Our api action:
            string apiAction = "templates/undel";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                template_id = templateId,
            };

            //  Make the call:
            return MakeAPICall<TemplateUndeleteResult>(apiAction, args);
        }

        /// <summary>
        /// Replace the content of a user template, NOT campaign content.
        /// </summary>
        /// <param name="templateId">The id of the user template to update</param>
        /// <param name="value">The values to updates - while both are optional, at least one should be provided. Both can be updated at the same time.</param>
        /// <returns></returns>
        public TemplateUpdateResult UpdateTemplate(int templateId, TemplateUpdateValue value)
        {
            //  Our api action:
            string apiAction = "templates/update";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                template_id = templateId,
                values = value
            };

            //  Make the call:
            return MakeAPICall<TemplateUpdateResult>(apiAction, args);
        }

        #endregion

        #region API: Reports

        /// <summary>
        /// Retrieve summary stats of campaign.
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <returns></returns>
        public ReportSummary GetReportSummary(string cId)
        {
            //  Our api action:
            string apiAction = "reports/summary";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<ReportSummary>(apiAction, args);
        }


        /// <summary>
        /// Get email addresses the campaign was sent to
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        public SentToMembers GetReportSentTo(string cId, SentToLimits opts = null)
        {
            //  Our api action:
            string apiAction = "reports/sent-to";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                opts = opts
            };

            //  Make the call:
            return MakeAPICall<SentToMembers>(apiAction, args);
        }

        /// <summary>
        /// Retrieve click of campaign.
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <returns></returns>
        public Clicks GetReportClicks(string cId)
        {
            //  Our api action:
            string apiAction = "reports/clicks";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId
            };

            //  Make the call:
            return MakeAPICall<Clicks>(apiAction, args);
        }

        /// <summary>
        /// Return the list of email addresses that clicked on a given url, and how many times they clicked
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="tId">the campaign id to get click stats for (can be gathered using campaigns/list())</param>
        /// <param name="opts">optional -  various options for controlling returned data</param>
        /// <returns></returns>
        public ClickDetail GetReportClickDetail(string cId, int tId, ClickDetailOptions opts = null)
        {
            //  Our api action:
            string apiAction = "reports/click-detail";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                tid = tId,
                opts = opts
            };

            //  Make the call:
            return MakeAPICall<ClickDetail>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the list of email addresses that did not open a given campaign
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        public NotOpened GetReportNotOpened(string cId, CommonOptions opts = null)
        {
            //  Our api action:
            string apiAction = "reports/not-opened";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                opts = opts
            };

            //  Make the call:
            return MakeAPICall<NotOpened>(apiAction, args);
        }

        /// <summary>
        /// Get all unsubscribed email addresses for a given campaign
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        public Unsubscribes GetReportUnsubscribes(string cId, CommonOptions opts = null)
        {
            //  Our api action:
            string apiAction = "reports/unsubscribes";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                opts = opts
            };

            //  Make the call:
            return MakeAPICall<Unsubscribes>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the full bounce messages for the given campaign. Note that this can return very large amounts of data depending 
        /// on how large the campaign was and how much cruft the bounce provider returned. 
        /// Also, messages over 30 days old are subject to being removed
        /// </summary>
        /// <param name="cId">the campaign id to pull bounces for</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        public BounceMessages GetReportBounceMessages(string cId, BounceMessagesOptions opts = null)
        {
            //  Our api action:
            string apiAction = "reports/bounce-messages";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                opts = opts
            };

            //  Make the call:
            return MakeAPICall<BounceMessages>(apiAction, args);
        }

        /// <summary>
        /// Retrieve the list of email addresses that opened a given campaign with how many times they opened
        /// </summary>
        /// <param name="cId">the Campaign Id</param>
        /// <param name="opts">optional - various options for controlling returned data</param>
        /// <returns></returns>
        public Opened GetReportOpened(string cId, OpenedOptions opts = null)
        {
            //  Our api action:
            string apiAction = "reports/opened";

            //  Create our arguments object:
            object args = new
            {
                apikey = this.APIKey,
                cid = cId,
                opts = opts
            };

            //  Make the call:
            return MakeAPICall<Opened>(apiAction, args);
        }
        #endregion

        #region Generic API calling method

        /// <summary>
        /// Generic API call.  Expects to be able to serialize the results
        /// to the specified type
        /// </summary>
        /// <typeparam name="T">The specified results type</typeparam>
        /// <param name="apiAction">The API action.  Example: helper/account-details</param>
        /// <param name="args">The object that will be serialized as the JSON parameters to the API call</param>
        /// <returns></returns>
        private T MakeAPICall<T>(string apiAction, object args)
        {
            //  First, make sure the datacenter prefix is set properly.  
            //  If it's not, throw an exception:
            if (string.IsNullOrEmpty(_dataCenterPrefix))
                throw new Exception("API key not valid (datacenter not specified)");

            //  Next, construct the full url based on the passed apiAction:
            string fullUrl = string.Format(_httpsUrl, _dataCenterPrefix, apiAction);

            //  Initialize the results to return:
            T results = default(T);

            var response = _httpClient.PostAsync(
                        fullUrl,
                        new StringContent(JsonConvert.SerializeObject(args), Encoding.UTF8))
                        .Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                var apiError = JsonConvert.DeserializeObject<ApiError>(responseBody);
                throw new MailChimpAPIException(apiError.Error, null, apiError);
            }

            results = JsonConvert.DeserializeObject<T>(responseBody, new JsonSerializerSettings()
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });

            //  Return the results
            return results;
        }

        #endregion

    }
}
