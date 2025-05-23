
using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
using MediatR;

namespace BBBSLI.DSS.MobileApp.Application.Donor.Query
{
    public class ZipCodeExistenceQuery : IRequest<bool>, IQuery<bool>
    {
        public string ZipCode { get; set; }

        public ZipCodeExistenceQuery(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}
