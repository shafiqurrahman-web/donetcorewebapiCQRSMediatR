using BBBSLI.DSS.MobileApp.API.DTOs.Donor;
using BBBSLI.DSS.MobileApp.Application.Donor.Query;
using BBBSLI.DSS.MobileApp.Application.Donors.Query;
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using BBBSLI.DSS.MobileApp.Utility.Domain.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BBBSLI.DSS.MobileApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IBuildingBlock _buildingBlock;
        public DonorsController(IBuildingBlock buildingBlock)
        {
            _buildingBlock = buildingBlock;
        }
        [HttpGet]
        public async Task<IActionResult> GetDonor([FromQuery] DonorQueryDto donorQueryDto, CancellationToken cancellationToken)
        {

            GetDonorByQuery parameter = donorQueryDto.MapTo<GetDonorByQuery>();
            //new(donorQueryDto.DonorId, donorQueryDto.Email, donor.PhoneNumber);
            var result = await _buildingBlock.ExecuteQueryAsync(parameter, cancellationToken);
            return Ok(result);



        }
        [HttpGet("{donorId}")]
        public async Task<IActionResult> GetDonorById(int donorId, CancellationToken cancellationToken)
        {
            var query = new GetDonorByIdQuery { DonorId = donorId };
            var result = await _buildingBlock.ExecuteQueryAsync(query, cancellationToken);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(); 
            }
        }

        [HttpGet("check-zip/{zipCode}")]
        public async Task<IActionResult> CheckZipCodeExistence(string zipCode, CancellationToken cancellationToken)
        {
            var query = new ZipCodeExistenceQuery(zipCode);
            var exists = await _buildingBlock.ExecuteQueryAsync<bool>(query, cancellationToken);

            if (exists)
            {
                return Ok(new { Existence = true, Message = "ZIP code exists." });
            }
            else
            {
                return NotFound(new { Existence = false, Message = "ZIP code does not exist." });
            }
        }





    }
}
