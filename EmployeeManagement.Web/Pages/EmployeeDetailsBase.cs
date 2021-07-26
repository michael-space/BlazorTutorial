using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        public string Coordinates { get; set; }

        public string ButtonText { get; set; } = "Hide Footer";

        public string CssClass { get; set; }

        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "hideFooter";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id ??= "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
    }
}
