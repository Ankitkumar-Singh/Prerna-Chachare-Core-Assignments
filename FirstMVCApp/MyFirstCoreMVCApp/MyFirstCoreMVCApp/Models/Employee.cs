using System.ComponentModel.DataAnnotations;

namespace MyFirstCoreMVCApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "Name contains only alphabets and at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department cannot be empty")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "Department contains only alphabets and at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Department should contain only 50 characters")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Skills cannot be empty")]
        public Skills Skills { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        [RegularExpression("^([A-Za-z0-9, ]{3,})$", ErrorMessage = "Address contains alphabets, numbers and (,) and at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Address should contain only 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Gender cannot be empty")]
        public string Gender { get; set; }

        public bool AcceptTerms { get; set; }
    }

    // Enum to display skills dropdown
    public enum Skills
    {
        None,
        Programming,
        CommonOS,
        TechnicalWriting,
        ProjectManagement,
        DataAnalysis
    }
}
