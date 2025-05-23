using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.PickupDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Contracts
{
    public interface IPickupDateRepository
    {
        Task <List<AvailablePickupDatesVM>> GetPickUpDateByZipCodeAsync(string ZipCode, CancellationToken cancellationToken);

    }
}
