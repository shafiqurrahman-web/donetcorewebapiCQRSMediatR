using BBBSLI.DSS.MobileApp.Domain.Entities;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Domain.Contracts
{
    public interface IDonorsRepository
    {
       //  Task<Donor> GetDonorInforByIDAsync(Donor donor, CancellationToken cancellationToken);
        Task<DonorViewModel> GetDonorInforByIDAsync(int donorid, string mail, string phoneNumber, CancellationToken cancellationToken);

    }
}
