using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;

namespace EMS_Portal_Nomination.Pages
{
    public class MasterDataAddRoletBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }
        public Role Role { get; set; } = new();
        protected async Task AddRole()
        {
            await DBService.AddNewRole(Role);
        }
    }
}

