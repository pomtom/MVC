using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        public string Name { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}