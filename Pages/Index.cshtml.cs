using KnockoutJsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace KnockoutJsWeb.Pages
{
    public class IndexModel : PageModel
    {
      

        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public IList<Department> Departments { get; set; } = new List<Department>();

        public void OnGet()
        {

        }

      
}
}
