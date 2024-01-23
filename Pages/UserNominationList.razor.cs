using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;

namespace EMS_Portal_Nomination.Pages
{
    public class UserNominationListBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }

        public List<UserNomination> UserObj { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserObj = await DBService.GetNominations();
        }
    }
}
