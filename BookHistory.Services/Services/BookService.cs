namespace BookHistory.Services.Services
{
    using BookHistory.Data.Entities;
    using BookHistory.Data.Interfaces;
    using BookHistory.Models.BindingModels;
    using BookHistory.Models.ViewModels;
    using BookHistory.Services.Exceptions;
    using BookHistory.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : Service, IBookService
    {
        private readonly IAuthorService authorService;

        public BookService(IBookHistoryDbContext context, IAuthorService authorService)
           : base(context) 
        {
            this.authorService = authorService;
        }

        public async Task<Guid> CreateNewBook(CreateBookBindingModel bookBm)
        {
            var book = new Book() 
            { 
                Title = bookBm.Title,
                Description = bookBm.Description,
                PublishDate = DateTime.Now,
                Book_Author = await CreateBook_AuthorJointTableRelations(bookBm.AuthorNames)
            };

            await this.Context.Books.AddAsync(book);
            await this.Context.SaveChangesAsync();

            return book.Id;
        }

        private async Task<ICollection<Book_Author>> CreateBook_AuthorJointTableRelations(ICollection<string> authorNames)
        {
            if (authorNames.Count < 1)
                return null;

            var bookAuthorJoinTables = new List<Book_Author>();

            foreach (var authorName in authorNames)
            {
                var bookAuthorJoinTable = new Book_Author();
                var author = await this.authorService.FindOrCreateNewAuthor(authorName);
                bookAuthorJoinTable.AuthorId = author.Id;
                bookAuthorJoinTables.Add(bookAuthorJoinTable);
            }

            return bookAuthorJoinTables;
        }

        public async Task<ICollection<GetListOfBooksViewModel>> GetListOfBooks()
        {
            return await this.Context.Books
                .AsNoTracking()
                .Include(x => x.BookEditHistories)
                .Include(x => x.Book_Author)
                    .ThenInclude(x => x.Author)
                .Select(book => new GetListOfBooksViewModel 
                {
                    Id = book.Id,
                    Title = book.Title,
                    Authors = book.Book_Author
                        .Where(joinTable => joinTable.BookId == book.Id)
                        .Select(x => x.Author.Name)
                        .ToArray()
                })
                .ToArrayAsync();
        }

        public async Task EditBook(EditBookBindingModel bookBm)
        {
            var book = await this.Context.Books
                .Include(x => x.BookEditHistories)
                .Include(x => x.Book_Author)
                    .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == bookBm.Id);

            if (book == null)
            {
                throw new NotFoundException($"Book {bookBm.Title} doesn't exists.");
            }

            await DetectBookChanges(book, bookBm);
            this.Context.Books.Update(book);
            await this.Context.SaveChangesAsync();
        }

        private async Task DetectBookChanges(Book book, EditBookBindingModel bookBm)
        {
            var editHistory = new BookEditHistory();
            editHistory.DateOfEdit = DateTime.Now;

            // Detect Title change
            if (!book.Title.Equals(bookBm.Title))
            {
                book.Title = bookBm.Title;
                editHistory.TitleChanges = $"\"{book.Title}\" title was changed to \"{bookBm.Title}\".";
            }

            // Detect Description change
            if (!book.Description.Equals(bookBm.Description))
            {
                book.Description = bookBm.Description;
                editHistory.DescriptionChanges = $"Description: \"{book.Description}\" was changed to: \"{bookBm.Description}\"";
            }

            // Detect Authors change
            var bookAuthors = book.Book_Author.Select(x => x.Author.Name);
            if (bookAuthors.Except(bookBm.AuthorNames).ToArray().Length > 0 || bookBm.AuthorNames.Except(bookAuthors).ToArray().Length > 0)
            {
                editHistory.AuthorChanges = $"\"{string.Join(", ", bookAuthors)}\" changed to \"{string.Join(", ", bookBm.AuthorNames)}\"";
                await ReplaceBookAuthors(book, bookBm);
            }

            book.BookEditHistories.Add(editHistory);
        }

        private async Task ReplaceBookAuthors(Book book, EditBookBindingModel bookBm)
        {
            book.Book_Author.Clear();
            foreach (var authorName in bookBm.AuthorNames)
            {
                var bookAuthorJoinTable = new Book_Author();
                var author = await this.authorService.FindOrCreateNewAuthor(authorName);
                bookAuthorJoinTable.AuthorId = author.Id;
                book.Book_Author.Add(bookAuthorJoinTable);
            }
        }

        public async Task<GetBookDetailsViewModel> GetBookDetails(Guid id)
        {
            var book = await this.Context.Books
                .AsNoTracking()
                .Include(x => x.BookEditHistories)
                .Include(x => x.Book_Author)
                    .ThenInclude(x => x.Author)
                .Where(x => x.Id == id)
                .Select(book => new GetBookDetailsViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    BookEditHistories = book.BookEditHistories
                        .Select(x => new BookEditHistoryViewModel 
                        {
                            DateOfEdit = x.DateOfEdit,
                            TitleChanges = x.TitleChanges,
                            DescriptionChanges = x.DescriptionChanges,
                            AuthorChanges = x.AuthorChanges,
                        }).ToArray(),
                    AuthorNames = book.Book_Author
                        .Where(joinTable => joinTable.BookId == book.Id)
                        .Select(x => x.Author.Name)
                        .ToArray()
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                throw new NotFoundException($"Book with id:{id} doesn't exits.");
            }

            return book;
        }
    }
}
