
using BBBSLI.DSS.MobileApp.API.DTOs.Donor;
using BBBSLI.DSS.MobileApp.Application.Donors.Query;
using BBBSLI.DSS.MobileApp.Domain.Contracts;
using BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext;
using BBBSLI.DSS.MobileApp.Infrastructure.Persistence;
using BBBSLI.DSS.MobileApp.Utility.Application;
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using BBBSLI.DSS.MobileApp.Utility.Infrastructure;
using BOH.BuildingBlocks.Infrastructure.Configuration;
using MediatR;
using System.Runtime.CompilerServices;

namespace BBBSLI.DSS.MobileApp.API.Extensions
{
    public static class ServiceExtenstion
    {
        public static IServiceCollection DependancyResolver(this IServiceCollection services)
        {
            services.AddScoped<IBuildingBlock, BuildingBlock>();
            //services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IExecutionContextAccessor, ExecutionContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReadonlyDbContext, ReadonlyDbContext>();


            services.AddScoped<IDonorsRepository, DonorsRepository>();
            services.AddScoped<IPickupDateRepository, PickupDateRepository>();


            return services;
        }
        public static IServiceCollection RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(GetDonorByQuery).Assembly));

            return services;
        }
    }
}
