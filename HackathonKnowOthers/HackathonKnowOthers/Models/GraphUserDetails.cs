using Newtonsoft.Json;

namespace HackathonKnowOthers.Models
{
    public class GraphUserDetails
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public string id { get; set; } = string.Empty;
        public string delveLink => $"https://msit.delve.office.com/?u={id}&v=work";
        public string displayName { get; set; } = string.Empty;
        public string jobTitle { get; set; } = string.Empty;
        public string officeLocation { get; set; } = string.Empty;
        public string userPrincipalName { get; set; } = string.Empty;
        public string birthday { get; set; } = string.Empty;
        public string aboutMe { get; set; } = string.Empty;
        public object preferredLanguage { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public object state { get; set; } = string.Empty;
        public object country { get; set; } = string.Empty;
        public List<string> businessPhones { get; set; } = new List<string>();
        public List<string> interests { get; set; } = new List<string>();
        public List<string> pastProjects { get; set; } = new List<string>();
        public List<string> skills { get; set; } = new List<string>();
        public List<string> schools { get; set; } = new List<string>();
    }
}
