namespace HackathonKnowOthers.Services
{
    public interface IGraphService
    {
        public Task<string> GetUser(string alias);

        public Task<string> GetManager(string alias);

        public Task<string> GetDirectReports(string alias);

        public Task<string> GetEmails(string emailId);

        public Task<string> GetProfilePhoto(string alias);
    }
}
