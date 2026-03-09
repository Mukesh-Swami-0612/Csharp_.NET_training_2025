using MyCompanyApp.API.DTOs;
using MyCompanyApp.API.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace MyCompanyApp.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMemoryCache _cache;

        public PersonService(IPersonRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<(List<PersonDto>, int)> GetPeople(int page, int pageSize, string search)
        {
            var cacheKey = $"people_{page}_{pageSize}_{search}";

            if (!_cache.TryGetValue(cacheKey, out (List<PersonDto>, int) cachedData))
            {
                cachedData = await _repository.GetPeople(page, pageSize, search);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set(cacheKey, cachedData, cacheOptions);
            }

            return cachedData;
        }
    }
}