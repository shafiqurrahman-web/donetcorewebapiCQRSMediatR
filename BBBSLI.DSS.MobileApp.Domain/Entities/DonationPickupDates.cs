using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class DonationPickupDates
    {
        public int DonationPickupId { get; set; }
        public int? DonationId { get; set; }
        public int? DateKey { get; set; }

        public virtual DateDimension DateKeyNavigation { get; set; }
        public virtual Donation Donation { get; set; }
    }
}
