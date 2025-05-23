namespace BBBSLI.DSS.MobileApp.Utility.Application.Contracts
{
    public interface IBuildingBlock
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);

        Task<TResult> ExecuteCommandAsync<TResult>(INonTransactionCommand<TResult> command, CancellationToken cancellationToken);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
        Task<TResult> ExecuteQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult>;

    }


}