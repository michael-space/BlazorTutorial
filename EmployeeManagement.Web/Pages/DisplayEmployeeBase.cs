using BlazorTutorial.Components;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeChecked { get; set; }

        [Parameter]

        [Inject]
        public IEmployeeService EmployeeService { get; set; } 

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeChecked.InvokeAsync((bool)e.Value);
        }

        protected ConfirmModalBase DeleteConfirmationModal { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmationModal.ShowModal();
        }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
    }
}
