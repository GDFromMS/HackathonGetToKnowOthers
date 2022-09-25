using System.Net.Http.Headers;

namespace HackathonKnowOthers.Services
{
    public class GraphService : IGraphService
    {
        private readonly HttpClient _httpClient;

        public GraphService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://graph.microsoft.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
        }

        public async Task<string> GetDirectReports(string alias)
        {
            string url = $"v1.0/users/{alias}@microsoft.com/directReports?$select=displayName,userPrincipalName";

            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetEmails(string emailId)
        {
            var url = $"v1.0/me/messages?$filter=(createdDateTime) lt {DateTime.UtcNow.ToString("o")} AND (sender/emailAddress/address) eq '{emailId}'&$select=createdDateTime,subject&orderby=createdDateTime desc&$top=20";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetManager(string alias)
        {
            string url = $"v1.0/users/{alias}@microsoft.com/manager?$select=displayName,userPrincipalName";

            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetProfilePhoto(string alias)
        {
            string url = $"v1.0/users/{alias}@microsoft.com/photo/$value";
            var response = await _httpClient.GetAsync(url);
            byte[] imageByteData = await response.Content.ReadAsByteArrayAsync();
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            return string.Format("data:image/png;base64,{0}", imageBase64Data);
        }

        public async Task<string> GetUser(string alias)
        {
            string url = $"v1.0/users/{alias}@microsoft.com?$select=id,displayName,officeLocation,userPrincipalName,skills,interests,pastProjects,preferredLanguage,city,state,country,schools,jobTitle,aboutMe,birthday,businessPhones";

            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }


    }
}
