namespace BookHistory.Data.Entities
{
    using System;

    public class BookEditHistory
    {
        public Guid Id { get; set; }
        public DateTime DateOfEdit { get; set; }
        public string TitleChanges { get; set; }
        public string DescriptionChanges { get; set; }
        public string AuthorChanges { get; set; }
        public virtual Book Book { get; set; }
    }
}
