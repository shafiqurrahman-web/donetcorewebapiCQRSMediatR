namespace BBBSLI.DSS.MobileApp.Utility.Application.Contracts
{
    using MediatR;

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}