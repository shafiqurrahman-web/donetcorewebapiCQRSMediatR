using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class WebSiteDonation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CrossStreet { get; set; }
        public int? ItemLocationId { get; set; }
        public int? ResidenceTypeId { get; set; }
        public DateTime? PickupDate { get; set; }
        public string Instructions { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsSmspreferred { get; set; }
        public bool IsEmailPreferred { get; set; }
        public bool IsPhonePreferred { get; set; }
        public int? ScheduleId { get; set; }
        public int? DonorAddressId { get; set; }
    }
}
