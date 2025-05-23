using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class DonorAddress
    {
        public DonorAddress()
        {
            Donation = new HashSet<Donation>();
        }

        public int DonorAddressesId { get; set; }
        public int DonorId { get; set; }
        public int? AddressTypeId { get; set; }
        public string AddressNumber { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string StreetAddress { get; set; }
        public string CrossStreet { get; set; }
        public string HouseColor { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string ZipCode { get; set; }
        public string AddressUnit { get; set; }
        public string Instructions { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }

        //public virtual AddressType AddressType { get; set; }
        //public virtual City City { get; set; }
        //public virtual Country Country { get; set; }
        //public virtual StateMaster State { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
    }
}
