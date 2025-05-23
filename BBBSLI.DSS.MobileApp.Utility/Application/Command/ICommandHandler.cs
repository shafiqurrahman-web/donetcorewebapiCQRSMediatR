namespace BBBSLI.DSS.MobileApp.Utility.Application.Command
{
    using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
    using MediatR;

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}