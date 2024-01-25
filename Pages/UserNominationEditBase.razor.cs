using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMS_Portal_Nomination.Pages
{
    public class UserNominationEditBase : ComponentBase
    {
        [Inject]
        public DBService DBService { get; set; }

        public List<UserNomination> UserNominations { get; set; }

        [Parameter]
        public string? EmailId { set; get; }

        [Parameter]
        public UserNomination Employee { get; set; } = new UserNomination();

        protected override async Task OnParametersSetAsync()
        {
            var emailId = EmailId ?? "";
            await GetUserNominationDataByEmailId(emailId);
        }

        private async Task GetUserNominationDataByEmailId(string emailId)
        {
            UserNominations = await DBService.GetNominationsByEmailId(emailId);
        }

        protected async Task UpdateEditNomination(UserNomination employee)
        {
            Debug.WriteLine("**" + employee.Name);
            await DBService.UpdateNewNomination(employee);
        }

    }
}
