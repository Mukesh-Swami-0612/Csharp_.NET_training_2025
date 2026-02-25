using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public static class FakeDatabase
    {
        public static List<Department> Departments = new List<Department>();
        public static List<Employee> Employees = new List<Employee>();
    }
}