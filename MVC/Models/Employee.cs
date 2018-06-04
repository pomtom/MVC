using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }

        public virtual Department Departments { get; set; }

        [Required]
        public string SelectedDepartmentId { get; set; }

        [NotMapped]
        public string SelectedDepartmentName { get; set; }

        [NotMapped]
        public IEnumerable<Department> DeptList { get; set; }
    }
}