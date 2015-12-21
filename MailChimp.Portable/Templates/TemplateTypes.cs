using Newtonsoft.Json;

namespace MailChimp.Templates
{
    /// <summary>
    /// optional - the types of templates to return
    /// </summary>
    
    public class TemplateTypes
    {
        public TemplateTypes()
        {
            User = true;
            Gallery = false;
            Base = false;
        }
        /// <summary>
        ///Custom templates for this user account. Defaults to true.
        /// </summary>
        [JsonProperty("user")]
        public bool User
        {
            get;
            set;
        }
        /// <summary>
        ///Templates from our Gallery. Note that some templates that require extra configuration are withheld. (eg, the Etsy template). Defaults to false.
        /// </summary>
        [JsonProperty("gallery")]
        public bool Gallery
        {
            get;
            set;
        }
        /// <summary>
        /// Our "start from scratch" extremely basic templates. Defaults to false.
        /// </summary>
        [JsonProperty("base")]
        public bool Base
        {
            get;
            set;
        }
    }
}
