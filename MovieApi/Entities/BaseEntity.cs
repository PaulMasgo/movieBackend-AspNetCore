using System;

namespace MovieApi.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Create { get; set; }
        public bool State { get; set; }
    }
}