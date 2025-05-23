using BBBSLI.DSS.MobileApp.Domain.Contracts;
using BBBSLI.DSS.MobileApp.Domain.Entities;
using BBBSLI.DSS.MobileApp.Domain.ViewModel;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using BBBSLI.DSS.MobileApp.Utility.Application.Queries;
using BBBSLI.DSS.MobileApp.Utility.Domain.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BBBSLI.DSS.MobileApp.Application.Donors.Query
{
    public class GetDonorByQueryHandler : IQueryHandler<GetDonorByQuery, DonorViewModel>
    {
        private readonly IDonorsRepository _donorsRepository;

        public GetDonorByQueryHandler(IDonorsRepository donorsRepository)
        {
            _donorsRepository = donorsRepository;
        }
        public async Task<DonorViewModel> Handle(GetDonorByQuery query, CancellationToken cancellationToken)
        {
            var resultDb = await this._donorsRepository.GetDonorInforByIDAsync(query.DonorId, query.Email, query.PhoneNumber, cancellationToken);
            var result = resultDb.MapTo<DonorViewModel>();
            return result;
        }

    }
}
