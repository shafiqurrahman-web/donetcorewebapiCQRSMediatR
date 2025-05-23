using BBBSLI.DSS.MobileApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;

public sealed class DonorViewModel
{
    public int DonorId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string Salutation { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Organization { get; set; }

    public int DonorStatusId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public int DateKey { get; set; }

    public bool IsPhonePreferred { get; set; }

    public bool IsEmailPreferred { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public string AlternatePhone { get; set; }

    public bool? IsActive { get; set; }

    public bool IsSmspreferred { get; set; }

    public bool? IsNewsletterEmailSubscribed { get; set; }

    public bool? IsMassRescheduleEmailSubscribed { get; set; }

    public bool? IsFillerBlastEmailSubscribed { get; set; }

    public string TwilioMessageReplys { get; set; }

    public string CarrierMobileCountryCode { get; set; }

    public string CarrierMobileNetworkCode { get; set; }

    public string CarrierName { get; set; }

    public string CarrierType { get; set; }

    public string CarrierErrorCode { get; set; }

    public string CarrierException { get; set; }

    public bool? ApilookupStatus { get; set; }

    public bool? Ismigrated { get; set; }

    public bool? SmsOptInSubscribe { get; set; }

    public bool? SmsOptInUnSubscribe { get; set; }

}
