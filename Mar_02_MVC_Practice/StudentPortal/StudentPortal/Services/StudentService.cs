using StudentPortal.Models;
using StudentPortal.Repositories;

namespace StudentPortal.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Student>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Student?> GetAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateAsync(Student student) => _repo.AddAsync(student);
        public Task UpdateAsync(Student student) => _repo.UpdateAsync(student);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<List<Student>> SearchAsync(string? q) => _repo.SearchAsync(q);
    }
}