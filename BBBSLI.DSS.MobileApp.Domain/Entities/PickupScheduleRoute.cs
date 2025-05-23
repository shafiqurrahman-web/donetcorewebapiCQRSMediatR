using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class PickupScheduleRoute
    {
        public int PickupScheduleRouteId { get; set; }
        public int RouteId { get; set; }
        public int ScheduleId { get; set; }

        public virtual Route Route { get; set; }
        public virtual PickupSchedule Schedule { get; set; }
    }
}
