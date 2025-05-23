using BBBSLI.DSS.MobileApp.API.DTOs.Donor;
using BBBSLI.DSS.MobileApp.API.DTOs.PickupDate;
using BBBSLI.DSS.MobileApp.Application.Donors.Query;
using BBBSLI.DSS.MobileApp.Application.PickupDate;
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using BBBSLI.DSS.MobileApp.Utility.Domain.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BBBSLI.DSS.MobileApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickupDateController : ControllerBase
    {
        private readonly IBuildingBlock _buildingBlock;
        public PickupDateController(IBuildingBlock buildingBlock)
        {
            _buildingBlock = buildingBlock;
        }
        [HttpGet("Zipcode")]
        public async Task<IActionResult> GetPickupDateByZipcode([FromQuery]  GetPickupDateByQuery query, CancellationToken cancellationToken)
        {

            //GetPickupDateByQuery parameter = pickupdateQueryDto.MapTo<GetPickupDateByQuery>();
            var result = await _buildingBlock.ExecuteQueryAsync(query, cancellationToken);
            return Ok(result);
        }
    }
}
