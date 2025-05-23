using BBBSLI.DSS.MobileApp.Domain.Contracts;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.PickupDate;
using BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Infrastructure.Persistence
{
    public class PickupDateRepository : IPickupDateRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadonlyDbContext _readonlyDbContext;

        public PickupDateRepository(IReadonlyDbContext readonlyDbContext, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readonlyDbContext = readonlyDbContext;
        }

        public async Task<List<AvailablePickupDatesVM>> GetPickUpDateByZipCodeAsync(string zipCode, CancellationToken cancellationToken = default)
        {
            List<AvailablePickupDatesVM> pickupDates = await (
                from r in _readonlyDbContext.Query<Route>()
                join p in _readonlyDbContext.Query<PickupSchedule>() on r.RouteId equals p.RouteId
                where r.ZipCode == zipCode
                select new AvailablePickupDatesVM
                {
                    Date = p.DateKey.Value.ToString(),
                    RouteName = p.Route.RouteName,
                }).ToListAsync(cancellationToken);

            return pickupDates;
        }
    }
}
