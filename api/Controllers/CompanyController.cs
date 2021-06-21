using System;
using System.Threading.Tasks;
using Api.Data;
using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    public class CompanyController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompany([FromQuery] int nit)
        {
            var company = await _unitOfWork.CompanyRepository.GetCompanyByNit(nit);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> AddCompany([FromBody] Company company)
        {
            try
            {
                if (company.Nit == 900674335)
                {
                    return BadRequest("Your identification number is blacklisted");
                }
                if (await _unitOfWork.CompanyRepository.AnyId(company.Nit))
                {
                    return BadRequest("Identification number already Exists");
                }
                await _unitOfWork.CompanyRepository.AddCompany(company);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult UpdateCompany([FromBody] Company company)
        {
            _unitOfWork.CompanyRepository.UpdateCompany(company);
            return Ok();
        }
    }
}