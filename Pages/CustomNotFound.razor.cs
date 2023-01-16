using Microsoft.AspNetCore.Components;

namespace WebAssemblyF.Pages
{
    public partial class CustomNotFound
        {
            [Inject]
            public NavigationManager NavigationManager { get; set; }
            public void NavigateToHome()
            {
                NavigationManager.NavigateTo("/");
            }
        }
}
