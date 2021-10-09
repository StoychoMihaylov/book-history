namespace BookHistory.Data.Interfaces
{
    using BookHistory.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBookHistoryDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
