using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class Route
    {
        public Route()
        {
            //ItemsLeftbehind = new HashSet<ItemsLeftbehind>();
            PickupSchedule = new HashSet<PickupSchedule>();
            PickupScheduleRoute = new HashSet<PickupScheduleRoute>();
        }

        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string ZipCode { get; set; }
        public int Display { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        //public virtual ICollection<ItemsLeftbehind> ItemsLeftbehind { get; set; }
        public virtual ICollection<PickupSchedule> PickupSchedule { get; set; }
        public virtual ICollection<PickupScheduleRoute> PickupScheduleRoute { get; set; }
    }
}
