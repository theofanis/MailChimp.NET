using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MergeVarOptions
    {
        /// <summary>
        /// The new tag for an existing MergeVar.  This is used for updates only.
        /// 10 bytes max, valid characters: "A-Z 0-9 _" no spaces, dashes, etc.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag
        {
            get;
            set;
        }

        /// <summary>
        /// The new long name for an existing MergeVar.   This is used for updates only.
        /// 50 characters max.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// One of text, number, radio, dropdown, date, address, phone, url, imagurl, zip, birthday.
        /// This currently can not be updated once the field is created.
        /// </summary>
        [JsonProperty("field_type")]
        public string FieldType
        {
            get;
            set;
        }

        /// <summary>
        /// Is this field required, defaults to false
        /// </summary>
        [JsonProperty("req")]
        public bool? Required
        {
            get;
            set;
        }

        /// <summary>
        /// optional indicates whether the field is displayed in public - defaults to true 
        /// </summary>
        [JsonProperty("public")]
        public bool? Public
        {
            get;
            set;
        }

        /// <summary>
        /// optional indicates whether the field is displayed in the app's list member view - defaults to true 
        /// </summary>
        [JsonProperty("show")]
        public bool? Show
        {
            get;
            set;
        }

        /// <summary>
        /// The order this merge tag should be displayed in - this will cause existing values to be reset so this fits 
        /// </summary>
        [JsonProperty("order")]
        public int? Order
        {
            get;
            set;
        }

        /// <summary>
        /// optional the default value for the field. Defaults to blank - max 255 bytes 
        /// </summary>
        [JsonProperty("default_value")]
        public string DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// optional the help text to be used with some newer forms. Defaults to blank - max 255 bytes
        /// </summary>
        [JsonProperty("helptext")]
        public string HelpText
        {
            get;
            set;
        }

        /// <summary>
        /// optional kind of - an array of strings to use as the choices for radio and dropdown type fields 
        /// </summary>
        [JsonProperty("choices")]
        public string[] Choices
        {
            get;
            set;
        }

        /// <summary>
        /// optional only valid for birthday and date fields. 
        /// For birthday type, must be "MM/DD" (default) or "DD/MM". 
        /// For date type, must be "MM/DD/YYYY" (default) or "DD/MM/YYYY". 
        /// Any other values will be converted to the default. 
        /// </summary>
        [JsonProperty("dateformat")]
        public string DateFormat
        {
            get;
            set;
        }

        /// <summary>
        /// optional "US" is the default - any other value will cause them to be unformatted (international) 
        /// </summary>
        [JsonProperty("phoneformat")]
        public string PhoneFormat
        {
            get;
            set;
        }

        /// <summary>
        /// optional the ISO 3166 2 digit character code for the default country. Defaults to "US". 
        /// Anything unrecognized will be converted to the default. 
        /// </summary>
        [JsonProperty("defaultcountry")]
        public string DefaultCountry
        {
            get;
            set;
        }
 
    }
}
