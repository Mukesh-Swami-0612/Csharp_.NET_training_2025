using System.Collections.Generic;
using Testing.Models;

namespace Testing.Repositories
{
    public interface IEmpRepositories
    {
        Employee GetId(int id);

        IReadOnlyList<Employee> GetAll();

        void Add(Employee employee);

        void Update(Employee employee);

        void Delete(int id);
    }
}