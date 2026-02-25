using System.ComponentModel.DataAnnotations;

namespace InputValidate.Models
{
    public class Department
    {
        public int DeptId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Department Name must be at least 2 characters")]
        public string DeptName { get; set; }

        [Required]
        public string DeptCode { get; set; }
    }
}