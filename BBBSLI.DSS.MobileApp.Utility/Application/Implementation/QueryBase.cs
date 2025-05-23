using BBBSLI.DSS.MobileApp.Utility.Application.Contracts;

namespace BBBSLI.DSS.MobileApp.Utility.Application.Implementation
{
   

    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        protected QueryBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected QueryBase(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}