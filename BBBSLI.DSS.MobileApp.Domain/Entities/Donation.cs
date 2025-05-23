using System;
using System.Collections.Generic;

namespace BBBSLI.DSS.MobileApp.Domain.Entities;

public sealed  class Donation
{
    public int DonationId { get; set; }

    public int DonorId { get; set; }

    public int? DonorAddressId { get; set; }

    public int DonationTypeId { get; set; }

    public int DwastatusId { get; set; }

    public int? ItemWeight { get; set; }

    public int DonorSourceId { get; set; }

    public int DonationStatusId { get; set; }

    public int? ItemLocationId { get; set; }

    public int? PickupPriorityId { get; set; }

    public int? ScheduleId { get; set; }

    public bool IsDwa { get; set; }

    public bool IsDonationRouteException { get; set; }

    public bool IsMultipleDates { get; set; }

    public string Comments { get; set; }

    public string Instructions { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public int DateKey { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public bool IsMissedOrRescheduled { get; set; }

    public string MissedOrRescheduledReason { get; set; }

    public bool IsCancel { get; set; }

    public bool IsDoNotCall { get; set; }

    public  DonationStatus DonationStatus { get; set; }

    public  ICollection<DonationTransaction> DonationTransaction { get; set; } = new List<DonationTransaction>();
    public  ICollection<DonationPickupDates> DonationPickupDates { get; set; } = new List<DonationPickupDates>();

    public DonationType DonationType { get; set; }

    public  Donor Donor { get; set; }

}
