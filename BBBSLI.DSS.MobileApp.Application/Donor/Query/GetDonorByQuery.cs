using BBBSLI.DSS.MobileApp.Domain.Entities;
using BBBSLI.DSS.MobileApp.Domain.ViewModel.Donors;
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Application.Donors.Query
{
    public class GetDonorByQuery:  IQuery<DonorViewModel>
    {
        //public GetDonorByQuery(int donorid, string mail, string phoneNumber)
        //{
        //    this.DonorId = donorid;
        //    this.Email= mail;
        //    this.PhoneNumber = phoneNumber; 
        //}
        public int DonorId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }

    public record GetDonorByQuery1(int DonorId, string Email, string PhoneNumber): IQuery<DonorViewModel>;
}
