using Blazored.SessionStorage;
using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMS_Portal_Nomination.Pages
{
    public class UserNominationListBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        [Inject]
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public List<UserNomination> UserObj { get; set; }

        public string CurrentUserEmail { get; set; }

        public string CurrentRole { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = HttpContextAccessor.HttpContext.User;
            // Retrieve user email from ClaimsPrincipal
            CurrentUserEmail = user.FindFirst(ClaimTypes.Email)?.Value;
            Console.WriteLine(CurrentUserEmail);

            UserObj = await DBService.GetNominations();

            var session = new SessionState
            {
                Email = CurrentUserEmail,
                IsAuthenticated = true,
            };

            await SessionStorage.SetItemAsync("Session", session);

            // Fetch the roles and email for the current user
            var currentUserRoleEmail = await DBService.GetCurrentRoleAndEmail(CurrentUserEmail);

            // Print only the RoleName from each RoleMapping
            foreach (var roleMapping in currentUserRoleEmail)
            {
                CurrentRole = roleMapping.RoleName;
            }
        }

        public async Task<List<RoleMapping>> GetCurrentuser()
        {
            var currentUserDetails = new List<RoleMapping>
            {
                new RoleMapping
                {
                    RoleName = CurrentRole,
                    UserID = CurrentUserEmail
                }
            };

            return currentUserDetails;
        }
    }
}
