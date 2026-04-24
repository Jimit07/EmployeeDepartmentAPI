using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentAPI.Models.Entities
{
    public class Department
    {
        [Key]
        public int Dep_ID{ get; set; }

        [Required (ErrorMessage ="Enter Department Name")]
        public  string DepartmentName{ get; set; }


        //Navigation property
        //Department can contain many employees 1 to many relation 
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
