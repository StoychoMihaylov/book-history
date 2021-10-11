namespace BookHistory.Services.Services
{
    using BookHistory.Data.Entities;
    using BookHistory.Data.Interfaces;
    using BookHistory.Models.ViewModels;
    using BookHistory.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorService : Service, IAuthorService
    {
        public AuthorService(IBookHistoryDbContext context)
          : base(context)
        {}

        public async Task<Author> FindOrCreateNewAuthor(string authorName)
        {
            var author = await this.Context.Authors
                   .AsNoTracking()
                   .FirstOrDefaultAsync(author => author.Name == authorName);

            if (author == null)
            {
                var newAuthor = new Author
                {
                    Name = authorName,
                };

                await this.Context.Authors.AddAsync(newAuthor);
                await this.Context.SaveChangesAsync();

                return newAuthor;
            }

            return author;
        }

        public async Task<ICollection<GetListOfAuthorNamesViewModel>> GetListOfAuthorNames()
        {
            return await this.Context.Authors
                .AsNoTracking()
                .Select(x => new GetListOfAuthorNamesViewModel { Name = x.Name})
                .ToArrayAsync();
        }
    }
}
