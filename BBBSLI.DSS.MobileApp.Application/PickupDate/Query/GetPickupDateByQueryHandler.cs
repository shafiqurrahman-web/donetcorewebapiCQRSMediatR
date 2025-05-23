using BBBSLI.DSS.MobileApp.Application.Donors.Query;
using BBBSLI.DSS.MobileApp.Domain.Contracts;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.PickupDate;
using BBBSLI.DSS.MobileApp.Utility.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Application.PickupDate.Query
{
    public class GetPickupDateByQueryHandler : IQueryHandler<GetPickupDateByQuery, List<AvailablePickupDatesVM>>
    {
        private readonly IPickupDateRepository _pickupDateRepository;
        public GetPickupDateByQueryHandler(IPickupDateRepository pickupDateRepository)
        {
            _pickupDateRepository = pickupDateRepository;
            
        }
        public async Task<List<AvailablePickupDatesVM>> Handle(GetPickupDateByQuery request, CancellationToken cancellationToken)
        {
          var result =   _pickupDateRepository.GetPickUpDateByZipCodeAsync(request.Zipcode, cancellationToken).GetAwaiter().GetResult();
            return result;
        }
    }
}
