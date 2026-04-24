using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDepartmentAPI.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Employee_Id {get; set; }

        [Required(ErrorMessage = "Enter Name")]

        public string Name { get; set; }

        [ForeignKey("Department")]

        public int Dep_ID { get; set; }

        //1 to 1 relationship
        public Department Department { get; set; } 

    }
}
