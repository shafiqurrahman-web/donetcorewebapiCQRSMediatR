using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using BBBSLI.DSS.MobileApp.Domain.Entities; // Add the correct namespace for your DonorAddress entity
using BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext;
using BBBSLI.DSS.MobileApp.Application.Donor.Query;

using MediatR; // Add the correct namespace for your DbContext

public class ZipCodeExistenceQueryHandler : IRequestHandler<ZipCodeExistenceQuery, bool>
{
    private readonly IReadonlyDbContext _readonlyDbContext;

    public ZipCodeExistenceQueryHandler(IReadonlyDbContext readonlyDbContext)
    {
        _readonlyDbContext = readonlyDbContext;
    }

    public async Task<bool> Handle(ZipCodeExistenceQuery request, CancellationToken cancellationToken)
    {
        // Query the database to check the existence of the provided ZIP code
        return await _readonlyDbContext.Query<DonorAddress>()
            .AnyAsync(da => da.ZipCode == request.ZipCode, cancellationToken);
    }

}
