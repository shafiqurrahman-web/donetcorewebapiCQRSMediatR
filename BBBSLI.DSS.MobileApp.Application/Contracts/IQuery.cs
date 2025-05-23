namespace BBBSLI.DSS.MobileApp.Application.Contracts
{
    using MediatR;

    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}