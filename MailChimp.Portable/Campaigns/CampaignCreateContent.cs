using Newtonsoft.Json;
using System.Collections.Generic;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// the content for this campaign - use a struct with the one of the following keys:
    /// </summary>

    public class CampaignCreateContent
    {
        /// <summary>
        /// for raw/pasted HTML content
        /// </summary>
        [JsonProperty("html")]
        public string HTML
        {
            get;
            set;
        }
        /// <summary>
        /// when using a template instead of raw HTML, each key should be the unique mc:edit area name from the template.
        /// </summary>
        [JsonProperty("sections")]
        public Dictionary<string, string> Sections
        {
            get;
            set;
        }
        /// <summary>
        /// for the plain-text version
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// to have us pull in content from a URL. Note, this will override any other content options - for lists with Email Format options, you'll need to turn on generate_text as well
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// to send a Base64 encoded archive file for us to import all media from. Note, this will override any other content options - for lists with Email Format options, you'll need to turn on generate_text as well
        /// </summary>
        [JsonProperty("archive")]
        public string Archive
        {
            get;
            set;
        }
        /// <summary>
        ///optional - only necessary for the "archive" option. Supported formats are: zip, tar.gz, tar.bz2, tar, tgz, tbz . If not included, we will default to zip
        /// </summary>
        [JsonProperty("archive_type")]
        public string ArchiveType
        {
            get;
            set;
        }
    }
}
