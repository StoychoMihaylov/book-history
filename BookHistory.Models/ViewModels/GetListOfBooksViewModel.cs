namespace BookHistory.Models.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class GetListOfBooksViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<string> Authors { get; set; }
    }
}
