using WebApiDapperApp.Entities;

namespace WebApiDapperApp.Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
    }
}
