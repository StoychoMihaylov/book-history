namespace BookHistory.Models.BindingModels
{
    using System.Collections.Generic;

    public class CreateBookBindingModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> AuthorNames { get; set; }
    }
}
