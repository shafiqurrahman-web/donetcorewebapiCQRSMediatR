using BBBSLI.DSS.MobileApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors
{
    public class DonationViewModel
    {
        public int DonationId { get; set; }


        public int? DonorAddressId { get; set; }

        public int DonationTypeId { get; set; }

        public int DwastatusId { get; set; }

        public int? ItemWeight { get; set; }

        public int DonorSourceId { get; set; }

        public int DonationStatusId { get; set; }

        public int? ItemLocationId { get; set; }
       
    }
}
