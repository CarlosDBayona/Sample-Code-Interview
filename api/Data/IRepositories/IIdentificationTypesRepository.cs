using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace Api.Data.IRepositories
{
    public interface IIdentificationTypesRepository
    {
        public Task<List<IdentificationType>> ListAll();
    }
}