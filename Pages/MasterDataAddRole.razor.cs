using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace EMS_Portal_Nomination.Pages
{
    public class MasterDataAddRoletBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Role Role { get; set; } = new();
        protected async Task AddRole()
        {
            if (DBService != null && Role != null)
            {
                await DBService.AddNewRole(Role);
                NavigationManager.NavigateTo("usernominationlist");
            }
        }

    }
}

