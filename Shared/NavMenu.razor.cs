using Blazored.SessionStorage;
using EMS_Portal_Nomination.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMS_Portal_Nomination.Shared
{
    public class NavMenuBase : ComponentBase
    {
        public SessionState State { get; set; }

        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            State = await SessionStorage.GetItemAsync<SessionState>("Session");
            StateHasChanged();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            State = await SessionStorage.GetItemAsync<SessionState>("Session");
            StateHasChanged();
        }

        //protected async override Task OnInitializedAsync()
        //{
        //    State = await SessionStorage.GetItemAsync<SessionState>("Session");
        //    StateHasChanged();
        //}

        protected override async Task OnInitializedAsync()
        {
            State = await SessionStorage.GetItemAsync<SessionState>("Session");
            StateHasChanged();
        }
    }
}