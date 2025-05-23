namespace BBBSLI.DSS.MobileApp.Utility.Application.Queries
{
    using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
    using MediatR;

    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
    

}