namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        public string DeptName { get; set; }
    }
}