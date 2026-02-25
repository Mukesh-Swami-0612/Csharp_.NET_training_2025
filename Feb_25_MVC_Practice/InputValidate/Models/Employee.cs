using System.ComponentModel.DataAnnotations;

namespace InputValidate.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Employee Name must be at least 2 characters")]
        public string EmpName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(1, 1000000)]
        public decimal Salary { get; set; }

        [Required]
        public int DeptId { get; set; }

        public string DeptName { get; set; }
    }
}