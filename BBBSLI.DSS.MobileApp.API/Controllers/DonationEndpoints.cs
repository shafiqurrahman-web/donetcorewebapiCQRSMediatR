using BBBSLI.DSS.MobileApp.API.DTOs.Donor;
using BBBSLI.DSS.MobileApp.Application.Contracts;
using BBBSLI.DSS.MobileApp.Application.Donors.Query;
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using BBBSLI.DSS.MobileApp.Utility.Domain.Mappings;
using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Threading;


namespace BBBSLI.DSS.MobileApp.API.Controllers
{
    public class DonationEndPoints : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //first data then any method injection
            app.MapPost("api/GetDonationData", CheckExistingDonor).WithName(nameof(CheckExistingDonor));
            app.MapGet("api/GetDataById/{id}", CheckExistingDonor).WithName("GetDataById");

            // var routePrefixwithGroup = app.MapGroup("api/Donor").RequireRateLimiting<>(policyname)
            //var routePrefixwithGroup = app.MapGroup("api/Donor").RequireAuthorization("authorizationPolicy");
            var routePrefixwithGroup = app.MapGroup("api/Donor");
            routePrefixwithGroup.MapGet("", CheckExistingDonor).WithName("checkDonors");
            routePrefixwithGroup.MapPost("{id}", CheckExistingDonor).WithName(nameof(CheckExistingDonor));

        }


        public static async Task<IResult> CheckExistingDonor(DonorQueryDto donorQueryDto, IBuildingBlock buildingBlock, CancellationToken cancellationToken)
        {
            // GetDonorByQuery parameter = new(donor.DonorId,donor.Email, donor.PhoneNumber);
            GetDonorByQuery parameter = donorQueryDto.MapTo<GetDonorByQuery>();
            var result = await buildingBlock.ExecuteQueryAsync(parameter, cancellationToken);
            return Results.Ok(result);
        }

        public static async Task<Results<Ok<DonorQueryDto>, NotFound<string>>> GetDonorData(DonorQueryDto donorQueryDto, IBuildingBlock buildingBlock, CancellationToken cancellationToken)
        {
            //strongly type in the endpoint
            try
            {
                GetDonorByQuery parameter = donorQueryDto.MapTo<GetDonorByQuery>();
                var result = await  buildingBlock.ExecuteQueryAsync(parameter, cancellationToken);
                DonorQueryDto finalResult =   result.MapTo<DonorQueryDto>();
                return TypedResults.Ok(finalResult);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound(ex.Message);
            }
           
        }




    }
}
