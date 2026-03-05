using System.Collections.Generic;
using System.Linq;
using Testing.Models;

namespace Testing.Repositories
{
    public class EmpRepositories : IEmpRepositories
    {
        private static List<Employee> employees = new List<Employee>();

        public Employee GetId(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public IReadOnlyList<Employee> GetAll()
        {
            return employees;
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == employee.Id);

            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.Salary = employee.Salary;
            }
        }

        public void Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                employees.Remove(emp);
            }
        }
    }
}