using Testing.Models;
using Testing.Repositories;

namespace Testing.Services
{
    public class EmpServices
    {
        private readonly IEmpRepositories _repository;

        public EmpServices(IEmpRepositories repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _repository.GetId(id);
        }

        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }

        public void DeleteEmployee(int id)
        {
            _repository.Delete(id);
        }
    }
}