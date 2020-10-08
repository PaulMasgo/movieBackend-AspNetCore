namespace MovieApi.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}