using BBBSLI.DSS.MobileApp.Domain.Contracts;
using BBBSLI.DSS.MobileApp.Domain.Entities;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext;
using BBBSLI.DSS.MobileApp.Utility.Application;
using BBBSLI.DSS.MobileApp.Utility.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Infrastructure.Persistence
{
    public class DonorsRepository : IDonorsRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadonlyDbContext _readonlyDbContext;

        public DonorsRepository(
             IReadonlyDbContext readonlyDbContext,
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._readonlyDbContext = readonlyDbContext;
        }
        public async Task<DonorViewModel> GetDonorInforByIDAsync(int donorid, string mail, string phoneNumber, CancellationToken cancellationToken)
        {

            IQueryable<Donor> donorQuery = _readonlyDbContext.Query<Donor>()
                                               .Where(d => d.IsActive == true);
            if (donorid > 0)
            {
                donorQuery = donorQuery.Where(d => d.DonorId == donorid);
            }
            if (!mail.IsNullOrBlank())
            {
                donorQuery = donorQuery.Where(d => d.Email == mail);
            }
            if (!phoneNumber.IsNullOrBlank())
            {
                donorQuery = donorQuery.Where(d => d.PhoneNumber == phoneNumber);
            }

            DonorViewModel donorData = await donorQuery.To<DonorViewModel>()
                                                .FirstOrDefaultAsync(cancellationToken);
            return donorData;
        }


        public async Task AddOrUpdateDonorDataAsync(Donor donor, CancellationToken cancellationToken)
        {
            Donor donorFromDb = await this._unitOfWork.Repository<Donor>()
                                                 .Where(s => s.DonorId == donor.DonorId
                                                       && s.IsActive == true)
                                                 .FirstOrDefaultAsync(cancellationToken);

            if (donorFromDb == null)
            {
                await this._unitOfWork.Repository<Donor>().AddAsync(donor
                //    new Donor
                //    {
                //    Id = Guid.NewGuid(),
                //    Sfcode = settingModel.SfCode,
                //    IsInventory = settingModel.IsInventory,
                //    IsProduction = settingModel.IsProduction,
                //    IsActive = true,
                //}
                    );
            }
            else
            {
                this._unitOfWork.Patch(donorFromDb, donor);
            }
        }
    }
}
