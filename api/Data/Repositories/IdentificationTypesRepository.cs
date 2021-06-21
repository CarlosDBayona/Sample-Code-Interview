using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.IRepositories;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class IdentificationTypesRepository : IIdentificationTypesRepository
    {
        private readonly DataContext _context;

        public IdentificationTypesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<IdentificationType>> ListAll()
        {
            return await _context.IdentificationTypes.ToListAsync();
        }
    }
}