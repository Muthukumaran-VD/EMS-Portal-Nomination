using Microsoft.AspNetCore.Components;
using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;

namespace EMS_Portal_Nomination.Login
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }
        public Sign Logindata { get; set; } = new();
        public bool ShowError { get; set; } = false; // Add a property to control error visibility

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task CheckLogin()
        {
            bool isValid = await DBService.ValidateLogin(Logindata);

            if (isValid)
            {
                NavigationManager.NavigateTo("usernominationlist");
            }
            else
            {
                ShowError = true;
                StateHasChanged();
            }
        }

    }
}
