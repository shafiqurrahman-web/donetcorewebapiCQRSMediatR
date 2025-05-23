using BBBSLI.DSS.MobileApp.Domain.ViewModel.PickupDate;
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Application.PickupDate
{
    public class GetPickupDateByQuery : IQuery<List<AvailablePickupDatesVM>>
    {
        public string Zipcode { get; set; }
        
    }
}

