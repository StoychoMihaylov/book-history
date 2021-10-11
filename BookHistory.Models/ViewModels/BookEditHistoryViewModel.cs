namespace BookHistory.Models.ViewModels
{
    using System;

    public class BookEditHistoryViewModel
    {
        public DateTime DateOfEdit { get; set; }
        public string TitleChanges { get; set; }
        public string DescriptionChanges { get; set; }
        public string AuthorChanges { get; set; }
    }
}
