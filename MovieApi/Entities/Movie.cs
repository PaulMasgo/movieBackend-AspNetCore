using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Premiere { get; set; }
        public string Photo { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}