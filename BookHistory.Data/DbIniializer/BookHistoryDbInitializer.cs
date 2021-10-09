namespace BookHistory.Data.DbIniializer
{
    using BookHistory.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class BookHistoryDbInitializer
    {
        public static void SeedDb(BookHistoryDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
