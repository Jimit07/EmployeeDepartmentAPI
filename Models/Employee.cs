using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnockoutJsWeb.Models
{
    public class Employee
    {
        public int Employee_Id { get; set; }

        [Required]
        public string Name { get; set; }
        public required int Dep_ID { get; set; }

    }
}
