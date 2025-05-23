using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class PickupRouteType
    {
        public PickupRouteType()
        {
            //Driver = new HashSet<Driver>();
            PickupSchedule = new HashSet<PickupSchedule>();
        }

        public int PickupRouteTypeId { get; set; }
        public string PickupRouteTypeName { get; set; }
        public int Display { get; set; }
        public string Action { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        //public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<PickupSchedule> PickupSchedule { get; set; }
    }
}
