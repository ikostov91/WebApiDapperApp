using Microsoft.AspNetCore.Mvc;
using WebApiDapperApp.Contracts;

namespace WebApiDapperApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await this._companyRepository.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await this._companyRepository.GetCompany(id);
            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}
