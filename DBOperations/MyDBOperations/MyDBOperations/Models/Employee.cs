using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDBOperations.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "Name contains only alphabets and at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "City contains only alphabets and at least 3 characters")]
        [MaxLength(30, ErrorMessage = "City should contain only 30 characters")]
        public string City { get; set; }

        [ForeignKey("Id")]
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
