using WebApiDapperApp.DTOs;
using WebApiDapperApp.Entities;

namespace WebApiDapperApp.Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> CreateNewCompany(CreateNewCompanyDTO createNewCompanyDTO);
        public Task UpdateCompany(int id, UpdateCompanyDTO updateCompanyDto);
        public Task DeleteCompany(int id);
        public Task<Company> GetCompanyByEmployeeId(int id);
        public Task<Company?> GetCompanyWithEmployees(int id);
    }
}
