using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDBOperations.Models
{
    public class Department
    {
        public Department()
        {
            this.Employee = new HashSet<Employee>();
        }

        [Display(Name = "Department")]
        public int Id { get; set; }

        [Display(Name = "Department")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
