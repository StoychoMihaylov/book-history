namespace BookHistory.Data.Context
{
    using BookHistory.Data.Entities;
    using BookHistory.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class BookHistoryDbContext : DbContext, IBookHistoryDbContext
    {
        public BookHistoryDbContext(DbContextOptions<BookHistoryDbContext> options)
           : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookEditHistory> BookEditHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to many
            modelBuilder.Entity<Book>()
                .HasMany(x => x.BookEditHistories)
                .WithOne(x => x.Book)
                .OnDelete(DeleteBehavior.Cascade);

            //Many to many join table
            modelBuilder.Entity<Book_Author>()
                .HasKey(x => new { x.BookId, x.AuthorId });

            modelBuilder.Entity<Book_Author>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Book_Author)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Book_Author)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
