using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    public class IdentificationType : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public IdentificationType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllIdentificationType()
        {
            var identificationTypes = await _unitOfWork.IdentificationTypesRepository.ListAll();
            return Ok(identificationTypes);
        }
    }
}