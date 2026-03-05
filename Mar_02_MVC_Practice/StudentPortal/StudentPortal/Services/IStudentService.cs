using StudentPortal.Models;

namespace StudentPortal.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetAsync(int id);
        Task CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<List<Student>> SearchAsync(string? q);
    }
}