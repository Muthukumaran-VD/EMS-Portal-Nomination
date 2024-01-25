using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;

namespace EMS_Portal_Nomination.Pages
{
    public class UserNominationViewBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }

        public List<UserNomination> UserNominations { get; set; }

        [Parameter]
        public string? EmailId { get; set; }
       
        protected override async Task OnParametersSetAsync()
        {
            var emailId = EmailId ?? "";
            await GetUserNominationDataByEmailId(emailId);
        }

        private async Task GetUserNominationDataByEmailId(string emailId)
        {
            UserNominations = await DBService.GetNominationsByEmailId(emailId);
        }

    }
}



