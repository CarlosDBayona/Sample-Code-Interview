using System;
using System.Threading.Tasks;
using api.Model;

namespace Api.Data.IRepositories
{
    public interface ICompanyRepository
    {
        public Task AddCompany(Company company);

        public void UpdateCompany(Company company);

        public Task<Company> GetCompanyByNit(int nit);

        public Task<bool> AnyId(int id);
    }
}