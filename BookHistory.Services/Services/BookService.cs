namespace BookHistory.Services.Services
{
    using BookHistory.Data.Entities;
    using BookHistory.Data.Interfaces;
    using BookHistory.Models.BindingModels;
    using BookHistory.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookService : Service, IBookService
    {
        private readonly IAuthorService authorService;

        public BookService(IBookHistoryDbContext context, IAuthorService authorService)
           : base(context) 
        {
            this.authorService = authorService;
        }

        public async Task<Guid> CreateNewBook(BookBindingModel bookBm)
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

        public async Task<ICollection<Book_Author>> CreateBook_AuthorJointTableRelations(ICollection<string> authorNames)
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
    }
}
