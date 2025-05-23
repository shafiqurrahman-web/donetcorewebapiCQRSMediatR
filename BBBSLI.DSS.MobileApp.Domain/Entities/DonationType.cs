using System;
using System.Collections.Generic;

namespace BBBSLI.DSS.MobileApp.Domain.Entities;

public sealed class DonationType
{
    public int DonationTypeId { get; set; }

    public string Name { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public  ICollection<Donation> Donation { get; set; } = new List<Donation>();
}
