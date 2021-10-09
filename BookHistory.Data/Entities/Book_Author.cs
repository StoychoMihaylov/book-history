namespace BookHistory.Data.Entities
{
    using System;

    public class Book_Author
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
