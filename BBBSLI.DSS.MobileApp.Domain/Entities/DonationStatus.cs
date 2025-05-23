using System;
using System.Collections.Generic;

namespace BBBSLI.DSS.MobileApp.Domain.Entities;

public sealed class DonationStatus
{
    public int DonationStatusId { get; set; }

    public string Name { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public  ICollection<Donation> Donation { get; set; } = new List<Donation>();

    public  ICollection<DonationTransaction> DonationTransaction { get; set; } = new List<DonationTransaction>();
}
