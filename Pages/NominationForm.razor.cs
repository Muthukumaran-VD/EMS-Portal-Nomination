using EMS_Portal_Nomination.Data;
using EMS_Portal_Nomination.Models;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;


namespace EMS_Portal_Nomination.Pages
{
    public class NominationFormBase : ComponentBase 
    {
        [Inject]
        public DBService DBService { get; set; }
        public UserNomination Employee { get; set; } = new();

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employee.AwardNomination = "Best Coder";
        }

        protected async Task AddNomination()
        {
            await DBService.AddNewNomination(Employee);
            NavigationManager.NavigateTo("usernominationlist");
        }
    }
}
