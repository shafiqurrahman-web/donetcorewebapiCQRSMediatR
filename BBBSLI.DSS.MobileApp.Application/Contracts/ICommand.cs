namespace BBBSLI.DSS.MobileApp.Application.Contracts
{
    using System;
    using System.Dynamic;
    using MediatR;

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface ICommand : IRequest<Unit>
    {
        Guid Id { get; }
    }
}