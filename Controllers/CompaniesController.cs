using Microsoft.AspNetCore.Mvc;
using WebApiDapperApp.Contracts;
using WebApiDapperApp.DTOs;

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

        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await this._companyRepository.GetCompany(id);
            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCompany(CreateNewCompanyDTO dto)
        {
            var createdCompany = await this._companyRepository.CreateNewCompany(dto);
            return CreatedAtRoute("GetCompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDTO dto)
        {
            var dbCompany = await this._companyRepository.GetCompany(id);
            if (dbCompany is null)
            {
                return NotFound();
            }

            await this._companyRepository.UpdateCompany(id, dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var dbCompany = await this._companyRepository.GetCompany(id);
            if (dbCompany is null)
            {
                return NotFound();
            }

            await this._companyRepository.DeleteCompany(id);
            return NoContent();
        }

        [HttpGet("ByEmployeeId/{employeeId}")]
        public async Task<IActionResult> GetCompanyByEmployee(int employeeId)
        {
            var company = await this._companyRepository.GetCompanyByEmployeeId(employeeId);
            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet("{id}/WithEmployees")]
        public async Task<IActionResult> GetCompanyWithEmployees(int id)
        {
            var company = await this._companyRepository.GetCompanyWithEmployees(id);
            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet("MultipleWithEmployees")]
        public async Task<IActionResult> GetCompaniesWithEmployees()
        {
            var companies = await this._companyRepository.GetCompaniesWithEmployees();

            return Ok(companies);
        }

        [HttpPost("CreateMultiple")]
        public async Task<IActionResult> CreateMultipleCompanies(IEnumerable<CreateNewCompanyDTO> companiesDto)
        {
            await this._companyRepository.CreateMultipleCompanies(companiesDto);

            return Ok();
        }
    }
}
