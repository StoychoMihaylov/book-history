namespace BookHistory.Services.Interfaces
{
    using BookHistory.Data.Entities;
    using BookHistory.Models.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        /// <summary>
        /// Try to find author with the given name and if not present create new.
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        Task<Author> FindOrCreateNewAuthor(string authorName);

        /// <summary>
        /// Get collection of all athour names.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<GetListOfAuthorNamesViewModel>> GetListOfAuthorNames();
    }
}
