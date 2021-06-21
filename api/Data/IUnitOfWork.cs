using System;
using System.Threading.Tasks;
using Api.Data.IRepositories;

namespace Api.Data
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository {get; }
        IIdentificationTypesRepository IdentificationTypesRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}