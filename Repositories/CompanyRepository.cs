using Dapper;
using WebApiDapperApp.Contracts;
using WebApiDapperApp.Entities;
using WebApiDapperApp.Persistance;

namespace WebApiDapperApp.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            string query = "SELECT * FROM Companies";

            using var connection = this._context.CreateConnection();
            var companies = await connection.QueryAsync<Company>(query);

            return companies.ToList();
        }

        public async Task<Company> GetCompany(int id)
        {
            string query = "SELECT * FROM Companies WHERE Id = @Id";

            using var connection = this._context.CreateConnection();
            var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { Id = id });

            return company;
        }
    }
}
