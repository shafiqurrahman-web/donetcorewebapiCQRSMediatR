namespace BOH.BuildingBlocks.Infrastructure.Configuration
{
    using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;
    using MediatR;

    public class BuildingBlock : IBuildingBlock
    {
        private readonly IMediator _mediator;

        public BuildingBlock(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <inheritdoc/>
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);

        }

        /// <inheritdoc/>
        public async Task<TResult> ExecuteCommandAsync<TResult>(INonTransactionCommand<TResult> command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }
        public async Task<TResult> ExecuteQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken)
            where TQuery : IQuery<TResult>
        {
            return await _mediator.Send(query, cancellationToken);
        }



    }
}