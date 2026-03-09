using MyCompanyApp.API.DTOs;

namespace MyCompanyApp.API.Services
{
    public interface IPersonService
    {
        Task<(List<PersonDto>, int)> GetPeople(int page, int pageSize, string search);
    }
}