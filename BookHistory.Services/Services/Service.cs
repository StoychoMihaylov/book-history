namespace BookHistory.Services.Services
{
    using BookHistory.Data.Interfaces;

    public class Service
    {
        public Service(IBookHistoryDbContext context)
        {
            this.Context = context;
        }

        protected IBookHistoryDbContext Context { get; set; }
    }
}
