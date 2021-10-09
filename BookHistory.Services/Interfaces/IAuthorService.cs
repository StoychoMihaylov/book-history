namespace BookHistory.Services.Interfaces
{
    using BookHistory.Data.Entities;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        /// <summary>
        /// Try to find author with the given name and if not present create new.
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        Task<Author> FindOrCreateNewAuthor(string authorName);
    }
}
