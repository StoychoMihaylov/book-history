namespace BookHistory.Services.Interfaces
{
    using BookHistory.Models.BindingModels;
    using System;
    using System.Threading.Tasks;

    public interface IBookService
    {
        /// <summary>
        /// Create and persist new book to the database. Creation of relational entities(Authors) is included.
        /// </summary>
        /// <param name="bookBm"></param>
        /// <returns></returns>
        Task<Guid> CreateNewBook(BookBindingModel bookBm);
    }
}
