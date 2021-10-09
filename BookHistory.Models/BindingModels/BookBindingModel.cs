using System.Collections.Generic;

namespace BookHistory.Models.BindingModels
{
    public class BookBindingModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> AuthorNames { get; set; }
    }
}
