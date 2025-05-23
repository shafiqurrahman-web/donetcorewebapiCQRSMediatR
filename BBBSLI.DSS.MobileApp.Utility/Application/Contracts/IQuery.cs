namespace BBBSLI.DSS.MobileApp.Utility.Application.Contracts
{
    using MediatR;

    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}