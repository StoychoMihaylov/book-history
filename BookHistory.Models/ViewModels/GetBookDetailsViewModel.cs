namespace BookHistory.Models.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class GetBookDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<BookEditHistoryViewModel> BookEditHistories { get; set; }
        public ICollection<string> AuthorNames { get; set; }
    }
}
