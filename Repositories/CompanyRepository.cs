using Dapper;
using System.Data;
using WebApiDapperApp.Contracts;
using WebApiDapperApp.DTOs;
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

        public async Task<Company> CreateNewCompany(CreateNewCompanyDTO createNewCompanyDTO)
        {
            // SCOPED_IDENTITY - Returns the last identity value inserted into an identity column in the same scope.
            // A scope is a module: a stored procedure, trigger, function, or batch.
            // Therefore, if two statements are in the same stored procedure, function, or batch, they are in the same scope.
            string query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)" +
                "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", createNewCompanyDTO.Name, DbType.String);
            parameters.Add("Address", createNewCompanyDTO.Address, DbType.String);
            parameters.Add("Country", createNewCompanyDTO.Country, DbType.String);

            using var connection = this._context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(query, parameters);

            var createdCompany = new Company
            {
                Id = id,
                Name = createNewCompanyDTO.Name,
                Address = createNewCompanyDTO.Address,
                Country = createNewCompanyDTO.Country
            };

            return createdCompany;
        }
    }
}
