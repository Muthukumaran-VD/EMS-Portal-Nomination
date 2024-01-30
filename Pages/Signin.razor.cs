using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Portal_Nomination.Pages
{
    public class SigninBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }
        public Sign Sign { get; set; } = new();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task AddUsernameAndPassword()
        {
            await DBService.AddSign(Sign);
            NavigationManager.NavigateTo("login");
        }
    }
}
