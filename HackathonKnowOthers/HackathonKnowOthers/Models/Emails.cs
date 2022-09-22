using Newtonsoft.Json;

namespace HackathonKnowOthers.Models
{
    public class Emails
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }
        public List<Value> value { get; set; }
    }

    public class Value
    {
        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }
        public string id { get; set; }
        public DateTime createdDateTime { get; set; }
        public string subject { get; set; }
    }
}
