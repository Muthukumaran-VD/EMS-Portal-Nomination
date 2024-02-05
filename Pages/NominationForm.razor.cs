using Blazored.SessionStorage;
using EMS_Portal_Nomination.Data;
using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace EMS_Portal_Nomination.Pages
{
    public class NominationFormBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }

        [Inject]
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public UserNomination Employee { get; set; } = new UserNomination();

        protected bool ShowLoader { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Role> Roles { get; set; }

        public string currentUser { get; set; }

        public string CurrentUserEmail { get; set; }
        

        public string CurrentRole { get; set; }

        protected override async Task OnInitializedAsync()
        {

            ShowLoader = true;
            Employee.AwardNomination = "Best Coder";
            var user = HttpContextAccessor.HttpContext.User;
            // Retrieve user email from ClaimsPrincipal
            CurrentUserEmail = user.FindFirst(ClaimTypes.Email)?.Value;
            // Fetch the roles and email for the current user
            var currentUserRoleEmail = await DBService.GetCurrentRoleAndEmail(CurrentUserEmail);

            // Print only the RoleName from each RoleMapping
            foreach (var roleMapping in currentUserRoleEmail)
            {
                CurrentRole = roleMapping.RoleName;
            }
            await GetRoles();
            ShowLoader = false;

        }

        protected async Task AddNomination()
        {
            ShowLoader = true;
            await DBService.AddNewNomination(Employee);
            NavigationManager.NavigateTo("usernominationlist");
            ShowLoader = false;
        }

        protected async Task GetRoles()
        {
            Roles = await DBService.GetRoles();
        }
    }
}
