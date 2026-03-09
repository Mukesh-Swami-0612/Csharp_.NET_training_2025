using MyCompanyApp.API.DTOs;

namespace MyCompanyApp.API.Repositories
{
    public interface IPersonRepository
    {
        Task<(List<PersonDto>, int)> GetPeople(int page, int pageSize, string search);
    }
}