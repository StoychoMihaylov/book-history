namespace BookHistory.Services.Interfaces
{
    using BookHistory.Models.BindingModels;
    using BookHistory.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookService
    {
        /// <summary>
        /// Create and persist new book to the database. Creation of relational entities(Authors) is included.
        /// </summary>
        /// <param name="bookBm"></param>
        /// <returns></returns>
        Task<Guid> CreateNewBook(CreateBookBindingModel bookBm);

        /// <summary>
        /// Get list of books.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<GetListOfBooksViewModel>> GetListOfBooks();

        /// <summary>
        /// Edit existing boook.
        /// </summary>
        /// <param name="bookBm"></param>
        /// <returns></returns>
        Task EditBook(EditBookBindingModel bookBm);
        Task<GetBookDetailsViewModel> GetBookDetails(Guid id);
    }
}
