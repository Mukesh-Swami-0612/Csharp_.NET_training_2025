using Microsoft.EntityFrameworkCore;
using MyCompanyApp.API.DTOs;
using MyCompanyApp.Data.Context;

namespace MyCompanyApp.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AdventureWorksContext _context;

        public PersonRepository(AdventureWorksContext context)
        {
            _context = context;
        }

        public async Task<(List<PersonDto>, int)> GetPeople(int page, int pageSize, string search)
        {
            var query = _context.People.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p =>
                    p.FirstName.Contains(search) ||
                    p.LastName.Contains(search));
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .Select(p => new PersonDto
                {
                    BusinessEntityId = p.BusinessEntityId,
                    PersonType = p.PersonType,
                    FirstName = p.FirstName,
                    MiddleName = p.MiddleName,
                    LastName = p.LastName
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, totalRecords);
        }
    }
}