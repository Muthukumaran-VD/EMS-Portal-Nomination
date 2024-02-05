using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace EMS_Portal_Nomination.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public string CurrentUserEmail { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        // Add this method in your controller or Blazor component class
        public void NavigateToLogin()
        {
            NavigationManager.NavigateTo("Identity/Account/Login", true);
        }

        protected override async Task OnInitializedAsync()
        {
            var user = HttpContextAccessor.HttpContext.User;
            // Retrieve user email from ClaimsPrincipal
            CurrentUserEmail = user.FindFirst(ClaimTypes.Email)?.Value;

            // Check your condition and navigate if needed
            if (CurrentUserEmail == null)
            {
                // Invoke the navigation method from the controller
                NavigateToLogin();
            }
            else
            {
                NavigationManager.NavigateTo("usernominationlist");
            }
        }
    }
}
