using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class PickupSchedule
    {
        public PickupSchedule()
        {
            //DailyDriverRoute = new HashSet<DailyDriverRoute>();
            //DailyDriverScannedCopy = new HashSet<DailyDriverScannedCopy>();
            //Donation = new HashSet<Donation>();
            //FillerBlastHistory = new HashSet<FillerBlastHistory>();
            //MassRescheduleRescheduledSchedule = new HashSet<MassReschedule>();
            //MassRescheduleSchedule = new HashSet<MassReschedule>();
            //MassRescheduleStatus = new HashSet<MassRescheduleStatus>();
            //PickupReminder = new HashSet<PickupReminder>();
            PickupScheduleRoute = new HashSet<PickupScheduleRoute>();
        }

        public int ScheduleId { get; set; }
        public int RouteId { get; set; }
        public int PickupRouteTypeId { get; set; }
        public int MaxPickup { get; set; }
        public int? CurrentCount { get; set; }
        public int? NoPickup { get; set; }
        public int SuccessRate { get; set; }
        public int? DateKey { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual DateDimension DateKeyNavigation { get; set; }
        public virtual PickupRouteType PickupRouteType { get; set; }
        public virtual Route Route { get; set; }
        //public virtual ICollection<DailyDriverRoute> DailyDriverRoute { get; set; }
        //public virtual ICollection<DailyDriverScannedCopy> DailyDriverScannedCopy { get; set; }
        //public virtual ICollection<Donation> Donation { get; set; }
        //public virtual ICollection<FillerBlastHistory> FillerBlastHistory { get; set; }
        //public virtual ICollection<MassReschedule> MassRescheduleRescheduledSchedule { get; set; }
        //public virtual ICollection<MassReschedule> MassRescheduleSchedule { get; set; }
        //public virtual ICollection<MassRescheduleStatus> MassRescheduleStatus { get; set; }
        //public virtual ICollection<PickupReminder> PickupReminder { get; set; }
        public virtual ICollection<PickupScheduleRoute> PickupScheduleRoute { get; set; }
    }
}

