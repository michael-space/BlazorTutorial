using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel : Employee
    {
        [CompareProperty("Email", ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
    }
}
