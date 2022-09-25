using HackathonKnowOthers.Models;
using HackathonKnowOthers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HackathonKnowOthers.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IGraphService _graphService;

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Alias { get; set; }

        [BindProperty]
        public string ProfilePhoto { get; set; }

        [BindProperty]
        public GraphUserDetails UserDetails { get; set; }

        [BindProperty]
        public GraphUserDetails Manager { get; set; }

        [BindProperty]
        public DirectReports DirectReports { get; set; }

        [BindProperty]
        public Emails Emails { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IGraphService graphService)
        {
            _logger = logger;
            _graphService = graphService;
        }

        public async Task<IActionResult> OnGet()
        {
            ErrorMessage = null;
            try
            {
                if (Alias != null)
                {
                    ProfilePhoto = await _graphService.GetProfilePhoto(Alias);

                    var userDetailsString = await _graphService.GetUser(Alias);
                    var userDetails = JsonConvert.DeserializeObject<GraphUserDetails>(userDetailsString);
                    if (userDetails.id == string.Empty)
                    {
                        throw new Exception($"Cannot find person with alias {Alias}");
                    }
                    UserDetails = userDetails;

                    var managerString = await _graphService.GetManager(Alias);
                    Manager = JsonConvert.DeserializeObject<GraphUserDetails>(managerString);

                    var directReportsString = await _graphService.GetDirectReports(Alias);
                    DirectReports = JsonConvert.DeserializeObject<DirectReports>(directReportsString);

                    var emailsString = await _graphService.GetEmails($"{Alias}@microsoft.com");
                    Emails = JsonConvert.DeserializeObject<Emails>(emailsString);
                }
            }
            catch (Exception ex)
            {
                UserDetails = null;
                ErrorMessage = ex.Message;
            }

            return Page();
        }
    }
}