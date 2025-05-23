using BBBSLI.DSS.MobileApp.Application.Donors.Query;
using BBBSLI.DSS.MobileApp.Domain.Contracts;
using BBBSLI.DSS.MobileApp.Domain.ViewModel;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using BBBSLI.DSS.MobileApp.Utility.Application.Queries;
using BBBSLI.DSS.MobileApp.Utility.Domain.Mappings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Application.Donors.Query
{
    public class GetDonorByIdQueryHandler : IQueryHandler<GetDonorByIdQuery, DonorViewModel>
    {
        private readonly IDonorsRepository _donorsRepository;

        public GetDonorByIdQueryHandler(IDonorsRepository donorsRepository)
        {
            _donorsRepository = donorsRepository;
        }

        public async Task<DonorViewModel> Handle(GetDonorByIdQuery query, CancellationToken cancellationToken)
        {
            var resultDb = await _donorsRepository.GetDonorInforByIDAsync(query.DonorId, mail: null, phoneNumber: null, cancellationToken);
            var result = resultDb.MapTo<DonorViewModel>();

            return result;
        }
    }
}
