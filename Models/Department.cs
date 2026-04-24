using System.ComponentModel.DataAnnotations;

namespace KnockoutJsWeb.Models
{
    public class Department
    {
        public int Dep_ID { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
