namespace BBBSLI.DSS.MobileApp.Utility.Application.Contracts
{
    using MediatR;

    public interface INonTransactionCommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}