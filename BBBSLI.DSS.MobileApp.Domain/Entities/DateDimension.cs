using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Entities
{
    public partial class DateDimension
    {
        public DateDimension()
        {
            Donation = new HashSet<Donation>();
            DonationPickupDates = new HashSet<DonationPickupDates>();
            Donor = new HashSet<Donor>();
            PickupSchedule = new HashSet<PickupSchedule>();
            //User = new HashSet<User>();
        }
        [Key]
        public int DateKey { get; set; }
        public DateTime Date { get; set; }
        public byte Day { get; set; }
        public string DaySuffix { get; set; }
        public byte Weekday { get; set; }
        public string WeekDayName { get; set; }
        public bool IsWeekend { get; set; }
        public bool IsHoliday { get; set; }
        public string HolidayText { get; set; }
        public byte DowinMonth { get; set; }
        public short DayOfYear { get; set; }
        public byte WeekOfMonth { get; set; }
        public byte WeekOfYear { get; set; }
        public byte IsoweekOfYear { get; set; }
        public byte Month { get; set; }
        public string MonthName { get; set; }
        public byte Quarter { get; set; }
        public string QuarterName { get; set; }
        public int Year { get; set; }
        public string Mmyyyy { get; set; }
        public string MonthYear { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
        public DateTime LastDayOfMonth { get; set; }
        public DateTime FirstDayOfQuarter { get; set; }
        public DateTime LastDayOfQuarter { get; set; }
        public DateTime FirstDayOfYear { get; set; }
        public DateTime LastDayOfYear { get; set; }
        public DateTime FirstDayOfNextMonth { get; set; }
        public DateTime FirstDayOfNextYear { get; set; }

        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<DonationPickupDates> DonationPickupDates { get; set; }
        public virtual ICollection<Donor> Donor { get; set; }
        public virtual ICollection<PickupSchedule> PickupSchedule { get; set; }
        //public virtual ICollection<User> User { get; set; }
    }
}
