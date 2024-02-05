using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace EMS_Portal_Nomination.Shared
{
    public class MainLayoutBase : LayoutComponentBase
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
