using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorTutorial.Components
{
    public class ConfirmModalBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "Confirmation";

        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure?";

        public void ShowModal()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task Button_Click(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
