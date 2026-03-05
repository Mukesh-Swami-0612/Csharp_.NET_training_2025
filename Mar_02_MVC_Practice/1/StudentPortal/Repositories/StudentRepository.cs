using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _context;

        public StudentRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> SearchAsync(string? q)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(s =>
                    s.FullName.Contains(q) ||
                    s.Email.Contains(q));
            }

            return await query.ToListAsync();
        }
    }
}