namespace BookHistory.Models.BindingModels
{
    using System;
    using System.Collections.Generic;

    public class EditBookBindingModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> AuthorNames { get; set; }
    }
}
