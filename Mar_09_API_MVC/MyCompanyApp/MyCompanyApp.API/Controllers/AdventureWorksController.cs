using Microsoft.AspNetCore.Mvc;
using MyCompanyApp.API.Services;

namespace MyCompanyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdventureWorksController : ControllerBase
    {
        private readonly IPersonService _service;

        public AdventureWorksController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople(int page = 1, int pageSize = 10, string search = "")
        {
            var (data, totalRecords) = await _service.GetPeople(page, pageSize, search);

            return Ok(new
            {
                totalRecords,
                page,
                pageSize,
                data
            });
        }
    }
}