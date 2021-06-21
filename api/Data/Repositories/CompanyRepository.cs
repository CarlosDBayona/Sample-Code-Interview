using System.Threading.Tasks;
using Api.Data.IRepositories;
using api.Model;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        public async Task<Company> GetCompanyByNit(int nit)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(c => c.Nit == nit);
            return company;
        }

        public async Task<bool> AnyId(int id)
        {
            return await _context.Companies.AnyAsync(c => c.Nit == id);
        }
    }
}