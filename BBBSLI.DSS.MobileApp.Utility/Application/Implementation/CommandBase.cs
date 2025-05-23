using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;

namespace BBBSLI.DSS.MobileApp.Utility.Application.Implementation
{
    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            this.Id = id;
        }

        /// <inheritdoc/>
        public Guid Id { get; }
    }
}