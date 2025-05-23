namespace BBBSLI.DSS.MobileApp.Application.Donors.Query
{
    using BBBSLI.DSS.MobileApp.Domain.ViewModel;
    using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
    using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;

    public class GetDonorByIdQuery : IQuery<DonorViewModel>
    {
        public int DonorId { get; init; }
    }
}
