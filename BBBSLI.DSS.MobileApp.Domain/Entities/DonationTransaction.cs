using System;
using System.Collections.Generic;

namespace BBBSLI.DSS.MobileApp.Domain.Entities;

public sealed class DonationTransaction
{
    public int DonationTransactionId { get; set; }

    public int DonationId { get; set; }

    public string Action { get; set; }

    public string Comments { get; set; }

    public int DonationStatusId { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public int DateKey { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public  Donation Donation { get; set; }

    public  DonationStatus DonationStatus { get; set; }
}
