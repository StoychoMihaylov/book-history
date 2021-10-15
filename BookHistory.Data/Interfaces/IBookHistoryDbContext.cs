namespace BookHistory.Data.Interfaces
{
    using BookHistory.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBookHistoryDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookEditHistory> BookEditHistories { get; set; }

        ChangeTracker ChangeTracker { get;}

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
